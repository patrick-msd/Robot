using Intel.RealSense;
using System.Diagnostics;
using System.Windows.Threading;

namespace RC.Vision.Intel.RealSense
{
    public partial class RealSense
    {
        public void Function2Start()

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
                // We create a FrameReleaser object that would track all newly allocated .NET frames,
                // and ensure deterministic finalization mat the end of scope
                using (var releaser = new FramesReleaser())
                {
                    foreach (ProcessingBlock p in blocks)
                    {
                        f = p.Process(f).DisposeWith(releaser);
                    }

                    f = f.ApplyFilter(_align).DisposeWith(releaser);
                    if (_updateDepthColorized != null)
                    {
                        f = f.ApplyFilter(_colorizer).DisposeWith(releaser);
                    }

                    FrameSet frames = f.As<FrameSet>().DisposeWith(releaser);

                    Frame color = frames[Stream.Color, Format.Rgb8].DisposeWith(releaser);
                    Frame depth = frames[Stream.Depth, Format.Z16].DisposeWith(releaser);
                    Frame depthColorized = frames[Stream.Depth, Format.Rgb8].DisposeWith(releaser);

                    // Combine the frames into a single result
                    //FrameSet res = src.AllocateCompositeFrame(color, depthColorized).DisposeWith(releaser);
                    FrameSet res = src.AllocateCompositeFrame(color, depth, depthColorized).DisposeWith(releaser);

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
                    var depthFrame = frames.DepthFrame.DisposeWith(frames);

                    #region Rendering frames
                    if (_updateColor != null)
                    {
                        // Render the frames
                        _dispatcher.Invoke(DispatcherPriority.Render, _updateColor, colorFrame);
                    }

                    if (_updateDepthColorized != null)
                    {
                        // We colorize the depth frame for visualization purposes
                        var colorizedDepth = frames.First<VideoFrame>(Stream.Depth, Format.Rgb8).DisposeWith(frames);
                        //var colorizedDepth = _colorizer.Process<VideoFrame>(depthFrame).DisposeWith(frames);

                        if (_updateDepthColorized != null)
                        {
                            // Render the frames
                            _dispatcher.Invoke(DispatcherPriority.Render, _updateDepthColorized, colorizedDepth);
                        }
                    }
                    #endregion

                    // Depth sensor sized to color sensor
                    var depthImage = new ushort[_colorProfile.Width * _colorProfile.Height];

                    // Depth sensor data to array
                    depthFrame.As<VideoFrame>().CopyTo(depthImage);
                    //using (var vf = depthFrame.As<VideoFrame>())
                    //{
                    //    vf.CopyTo(depthImage);
                    //}






                    ;







                    _swProcessingTime.Stop();
                    Debug.WriteLine($"Execution Time: {_swProcessingTime.ElapsedMilliseconds}ms");

                    _swProcessingTime.Reset();

                    _ctPipeline.Cancel();
                }
            });

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
    }
}