using Intel.RealSense;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PSGM.Lib.Vision.Intel
{
    public partial class RealSense
    {
        private Context _ctx;

        private Device _device;
        public Device Device { get { return _device; } }


        private Pipeline _pipeline;
        //public Pipeline Pipeline { get { return _pipeline; } set { _pipeline = value; } }
        private PipelineProfile _pipelineProfile;
        public PipelineProfile PipelineProfile { get { return _pipelineProfile; } set { _pipelineProfile = value; } }

        private Config _cfg;
        private Sensor _depthSensor;
        private Sensor _colorSensor;

        private CustomProcessingBlock _block;

        private Colorizer _colorizer;
        private Align _align = new Align(Stream.Color);

        private VideoStreamProfile _depthProfile;
        private VideoStreamProfile _colorProfile;

        private CancellationTokenSource _ctPipeline;

        private Stopwatch _swProcessingTime;

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public event Action<VideoFrame> _updateColor;
        public event Action<VideoFrame> _updateDepth;
        public event Action<VideoFrame> _updateDepthColorized;

        private Dispatcher _dispatcher;

        private CustomProcessingBlock _customProcessingBlock;

        public RealSense()
        {
            // Initialize variables
            _ctPipeline = new CancellationTokenSource();
            _swProcessingTime = new Stopwatch();

            // Initialize Realsense variables
            _ctx = new Context();
            _cfg = new Config();

            _pipeline = new Pipeline();

            _colorizer = new Colorizer();

            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        public DeviceList GetDevices()
        {
            return _ctx.Devices;
        }

        public void ConnectToDevice(string deviceSerialNumber)
        {
            // Conect to device
            foreach (var device in _ctx.Devices)
            {
                if (device.Info.GetInfo(CameraInfo.SerialNumber) == deviceSerialNumber)
                {
                    _device = device;

                    // Write device information
                    Console.WriteLine("\nUsing selected device, an {0}", _device.Info[CameraInfo.Name]);
                    Console.WriteLine("    Serial number: {0}", _device.Info[CameraInfo.SerialNumber]);
                    Console.WriteLine("    Firmware version: {0}", _device.Info[CameraInfo.FirmwareVersion]);
                }
            }

            if (_device == null)
            {
                //MessageBox.Show("Could not find the corresponding Realsense camera！");
                return;
            }
        }

        public void InitializeStreamingProfileDepthSensor(int profilIndex)
        {
            ReadOnlyCollection<Sensor> sensors = _device.QuerySensors();
            _depthSensor = sensors[0];

            var tmp = _depthSensor.StreamProfiles
                                .Where(p => p.Stream == Stream.Depth)
                                .OrderBy(p => p.Framerate)
                                .Select(p => p.As<VideoStreamProfile>()).ToList();

            _depthProfile = tmp[profilIndex];
        }

        public void InitializeStreamingProfileColorSensor(int profilIndex)
        {
            ReadOnlyCollection<Sensor> sensors = _device.QuerySensors();
            _colorSensor = sensors[1];

            var tmp = _colorSensor.StreamProfiles
                    .Where(p => p.Stream == Stream.Color)
                    .OrderBy(p => p.Framerate)
                    .Select(p => p.As<VideoStreamProfile>()).ToList();

            _colorProfile = tmp[profilIndex];
        }

        public void InitializeStreamingProfileOfBothSensors(int profilIndexDepth, int profilIndexColor)
        {
            InitializeStreamingProfileDepthSensor(profilIndexDepth);
            InitializeStreamingProfileColorSensor(profilIndexColor);
        }

        public void StreamingConfigurationApply()
        {
            if (_depthProfile != null)
            {
                _cfg.EnableStream(Stream.Depth, _depthProfile.Width, _depthProfile.Height, _depthProfile.Format, _depthProfile.Framerate);
            }

            if (_colorProfile != null)
            {
                _cfg.EnableStream(Stream.Color, _colorProfile.Width, _colorProfile.Height, _colorProfile.Format, _colorProfile.Framerate);
            }
        }

        public void StreamingStart()
        {
            _pipelineProfile = _pipeline.Start(_cfg);
        }

        public void InitializeProcessingBlocks()
        {
            // Get the recommended processing blocks for the depth sensor
            List<ProcessingBlock> blocks = _depthSensor.ProcessingBlocks.ToList();

            _ctPipeline = new CancellationTokenSource();












            // Create custom processing block
            // For demonstration purposes it will:
            // a. Get a frameset
            // b. Run post-processing on the depth frame
            // c. Combine the result back into a frameset
            // Processing blocks are inherently thread-safe and play well with
            // other API primitives such as frame-queues, 
            // and can be used to encapsulate advanced operations.
            // All invocations are, however, synchronious so the high-level threading model
            // is up to the developer
            _customProcessingBlock = new CustomProcessingBlock((f, src) =>
            {
                // We create a FrameReleaser object that would track
                // all newly allocated .NET frames, and ensure deterministic finalization
                // at the end of scope. 
                using (var releaser = new FramesReleaser())
                {
                    foreach (ProcessingBlock p in blocks)
                        f = p.Process(f).DisposeWith(releaser);

                    f = f.ApplyFilter(_align).DisposeWith(releaser);
                    f = f.ApplyFilter(_colorizer).DisposeWith(releaser);

                    var frames = f.As<FrameSet>().DisposeWith(releaser);

                    var colorFrame = frames[Stream.Color, Format.Rgb8].DisposeWith(releaser);
                    var colorizedDepth = frames[Stream.Depth, Format.Rgb8].DisposeWith(releaser);

                    // Combine the frames into a single result
                    var res = src.AllocateCompositeFrame(colorizedDepth, colorFrame).DisposeWith(releaser);
                    // Send it to the next processing stage
                    src.FrameReady(res);
                }
            });


            // Register to results of processing via a callback:
            _customProcessingBlock.Start(f =>
            {
                using (var frames = f.As<FrameSet>())
                {
                    var colorFrame = frames.ColorFrame.DisposeWith(frames);
                    var colorizedDepth = frames.First<VideoFrame>(Stream.Depth, Format.Rgb8).DisposeWith(frames);

                    _dispatcher.Invoke(DispatcherPriority.Render, _updateDepthColorized, colorizedDepth);
                    _dispatcher.Invoke(DispatcherPriority.Render, _updateColor, colorFrame);

                    _swProcessingTime.Stop();
                    Debug.WriteLine($"Execution Time: {_swProcessingTime.ElapsedMilliseconds}ms");

                    _swProcessingTime.Reset();

                    _ctPipeline.Cancel();
                }
            });



            //var token = _tokenSource.Token;

            var t = Task.Factory.StartNew(() =>
            {
                while (!_ctPipeline.IsCancellationRequested)
                {
                    using (var frames = _pipeline.WaitForFrames())
                    {
                        _swProcessingTime.Start();

                        // Invoke custom processing block
                        _customProcessingBlock.Process(frames);
                    }
                }
            }, _ctPipeline.Token);

        }

        public void AllocateBitmapsForRendring(Image imgDepth, Image imgColor)
        {
            //// Allocate bitmaps for rendring.
            //try
            //{
            //    using (var p = _pipelineProfile.GetStream(Stream.Depth).As<VideoStreamProfile>())
            //    {
            //        imgDepth.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unable to find Depth Stream. " + ex.Message);
            //}
            //_updateDepth = UpdateImage(imgDepth);

            //try
            //{
            //    using (var p = _pipelineProfile.GetStream(Stream.Color).As<VideoStreamProfile>())
            //    {
            //        imgColor.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unable to find Color Stream. " + ex.Message);
            //}  
            //_updateColor = UpdateImage(imgColor);


            // Allocate bitmaps for rendring.
            // Since the sample aligns the depth frames to the color frames, both of the images will have the color resolution
            try
            {
                using (var p = _pipelineProfile.GetStream(Stream.Color).As<VideoStreamProfile>())
                {
                    imgColor.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);
                    imgDepth.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find Color Stream. " + ex.Message);
            }
            _updateColor += UpdateImage(imgColor);
            _updateDepthColorized += UpdateImage(imgDepth);
        }

        public void DisallocateBitmapsForRendring(Image imgDepth, Image imgColor)
        {
            imgDepth.Source = null;
            imgColor.Source = null;

            _updateColor = null;
            _updateDepthColorized = null;
        }

        static Action<VideoFrame> UpdateImage(Image img)
        {
            WriteableBitmap? wbmp = img.Source as WriteableBitmap;

            if (wbmp != null)
            {
                return new Action<VideoFrame>(frame =>
                {
                    Int32Rect rect = new Int32Rect(0, 0, frame.Width, frame.Height);
                    wbmp.WritePixels(rect, frame.Data, frame.Stride * frame.Height, frame.Stride);
                });
            }
            else
            {
                return null;
            }
        }

        public float GetDepthScale()
        {
            return _depthSensor.DepthScale;
        }
    }
}