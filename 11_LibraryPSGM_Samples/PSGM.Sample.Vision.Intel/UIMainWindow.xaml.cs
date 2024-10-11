using Intel.RealSense;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RC.Vision.Intel.Sample
{
    public static class MyExtensionMethods
    {
        // Copy the indicated entries from a two-dimensional array into a new array.
        // http://www.csharphelper.com/howtos/howto_subarray_extensions.html
        public static T[,] SubArray<T>(this T[,] values, int row_min, int row_max, int col_min, int col_max)
        {
            // Allocate the result array.
            int num_rows = row_max - row_min + 1;
            int num_cols = col_max - col_min + 1;
            T[,] result = new T[num_rows, num_cols];

            // Get the number of columns in the values array.
            int total_cols = values.GetUpperBound(1) + 1;
            int from_index = row_min * total_cols + col_min;
            int to_index = 0;
            for (int row = 0; row <= num_rows - 1; row++)
            {
                Array.Copy(values, from_index, result, to_index, num_cols);
                from_index += total_cols;
                to_index += num_cols;
            }

            return result;
        }
    }

    /// <summary>
    /// Interaction logic for UIMainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        private Context _ctx;

        //private Device _device;
        //private ReadOnlyCollection<Sensor> _sensors;

        private Pipeline _pipeline;
        //private PipelineProfile _pipelineProfile;

        //private CustomProcessingBlock _block;

        private Colorizer _colorizer;

        //private Config _cfg;
        //private Sensor _depthSensor;
        //private Sensor _colorSensor;

        private VideoStreamProfile _depthProfile;
        private VideoStreamProfile _colorProfile;

        private CancellationTokenSource _ctPipeline;

        private Stopwatch _swProcessingTime;

        private ushort[] _depth;

        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        private Colorizer colorizer = new Colorizer();
        //private Align align = new Align(Stream.Color);

        private Action<VideoFrame> _updateDepth;
        private Action<VideoFrame> _updateColor;


        RealSense _realSense = new RealSense();

        private List<ItemOn3DImage> _itemsOn3DImage;

        private float[] _valuesDepth1;
        private float[] _valuesDepth2;


        public MainWindow()
        {
            InitializeComponent();

            // Initialize variables
            _ctPipeline = new CancellationTokenSource();
            _swProcessingTime = new Stopwatch();

            // Initialize Realsense variables
            _ctx = new Context();

            _pipeline = new Pipeline();
            _colorizer = new Colorizer();

            _itemsOn3DImage = new List<ItemOn3DImage>();

            _valuesDepth1 = new float[10];
            _valuesDepth2 = new float[10];


            _realSense = new RealSense();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Cancle threads
            _ctPipeline.Cancel();

            // Clear variables
            //_realSense = null;
        }

        private void btnScanForDevices_Click(object sender, RoutedEventArgs e)
        {
            cmbDevices.Text = string.Empty;
            cmbDevices.Items.Clear();

            foreach (var device in _realSense.GetDevices())
            {
                cmbDevices.Items.Add(device.Info.GetInfo(CameraInfo.SerialNumber));
            }
        }

        private void btnConnectToSelectedDevice_Click(object sender, RoutedEventArgs e)
        {
            _realSense.ConnectToDevice(cmbDevices.Text);

            // Write device information
            Debug.WriteLine("\nUsing selected device, an {0}", _realSense.Device.Info[CameraInfo.Name]);
            Debug.WriteLine("Serial number: {0}", _realSense.Device.Info[CameraInfo.SerialNumber]);
            Debug.WriteLine("Firmware version: {0}", _realSense.Device.Info[CameraInfo.FirmwareVersion]);

            // Initialize Senosors            
            _realSense.InitializeStreamingProfileDepthSensor(0);
            _realSense.InitializeStreamingProfileColorSensor(0);
            //_realSense.InitializeStreamingProfileOfBothSensors(0, 0);

            // Config Streaming
            _realSense.StreamingConfigurationApply();

            // Start pipeline with streaming configuration
            _realSense.StreamingStart();
        }

        private void btnSamplin1_Click(object sender, RoutedEventArgs e)
        {
            _realSense.Function1Start();
        }

        private void btnSamplin2_Click(object sender, RoutedEventArgs e)
        {
            //_realSense.InitializeProcessingBlocks();

            _realSense.Function2Start();
        }

        private void btnSamplin1_Copy_Click(object sender, RoutedEventArgs e)
        {
            //_realSense.AllocateBitmapsForRendring(imgDepth, imgColor);

            _realSense._updateColor += MonitoringColor;
            _realSense._updateDepth += MonitoringDepth;
            _realSense._updateDepthColorized += MonitoringDepthColorized;
        }

        private void btnSamplin1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            _realSense.DisallocateBitmapsForRendring(imgDepth, imgColor);
        }






        private void MonitoringColor(VideoFrame data)
        {
            ;
            Debug.WriteLine("MonitoringColor");

            //// Depth sensor sized to color sensor
            //var depthImage = new ushort[_colorProfile.Width * _colorProfile.Height];

            //// Depth sensor data to array
            //data.As<VideoFrame>().CopyTo(depthImage);
            ////using (var vf = depthFrame.As<VideoFrame>())
            ////{
            ////    vf.CopyTo(depthImage);
            ////}



        }

        private void MonitoringDepth(VideoFrame data)
        {
            // Depth sensor sized to color sensor ...
            ushort[] depthImage = new ushort[data.Width * data.Height];
            data.As<VideoFrame>().CopyTo(depthImage);

            float oneMeter = 1.000f / _realSense.GetDepthScale();

            float[,] depthArray = new float[data.Width, data.Height];

            // Calculate height on the complet array ...
            for (int y = 0; y < data.Height; y++)
            {
                for (int x = 0; x < data.Width; x++)
                {
                    //depthArray[x, y] = depthImage[x + (y * data.Width)] / one_meter;
                    depthArray[x, y] = (depthImage[x + (y * data.Width)] / oneMeter) * 1000.000f;
                }
            }

            // Calculate mean value of the define element ...
            //float[,] array1 = asde.SubArray(110, 125, 257, 272);
            //float[,] array2 = asde.SubArray(405, 420, 258, 273);
            //float[,] array3 = asde.SubArray(408, 422, 511, 526);
            //float[,] array4 = asde.SubArray(110, 125, 511, 526);

            //float[,] array5 = asde.SubArray(655, 670, 250, 265);
            //float[,] array6 = asde.SubArray(940, 945, 250, 265);
            //float[,] array7 = asde.SubArray(940, 945, 515, 530);
            //float[,] array8 = asde.SubArray(650, 665, 515, 530);

            float[,] array9 = depthArray.SubArray(175, 375, 330, 455);
            float[,] array10 = depthArray.SubArray(695, 895, 330, 455);

            //_valuesDepth[0] = SumFloat(array1) / array1.Length;
            //_valuesDepth[1] = SumFloat(array2) / array2.Length;
            //_valuesDepth[2] = SumFloat(array3) / array3.Length;
            //_valuesDepth[3] = SumFloat(array4) / array4.Length;

            //_valuesDepth[4] = SumFloat(array5) / array5.Length;
            //_valuesDepth[5] = SumFloat(array6) / array6.Length;
            //_valuesDepth[6] = SumFloat(array7) / array7.Length;
            //_valuesDepth[7] = SumFloat(array8) / array8.Length;

            Calculation(array9, ref _valuesDepth1[8], ref _valuesDepth2[8]);
            Calculation(array10, ref _valuesDepth1[9], ref _valuesDepth2[9]);








            /*
            ushort max = depthImage.Max();
            max = 2500;
            ushort min = depthImage.Min();
            min = 1000;

            // 2D visualisation
            Image<Rgb, byte> realSenseRawArray2DTrimmedRgbNormizedByteDisplay = new Image<Rgb, byte>(data.Width, data.Height, new Rgb(System.Drawing.Color.White));

            Image<Gray, ushort> realSenseRawArray2DTrimmedByteGrayUshort = new Image<Gray, ushort>(data.Width, data.Height, new Gray(0));

            Image<Gray, byte> realSenseRawArray2DTrimmedGrayNormizedByte = new Image<Gray, byte>(data.Width, data.Height, new Gray(0));
            Image<Gray, ushort> realSenseRawArray2DTrimmedGrayNormizedUshort = new Image<Gray, ushort>(data.Width, data.Height, new Gray(0));

            //CvInvoke.MinMaxLoc(realSenseRawArray2DTrimmedByteGrayUshort, ref data.ROIMin, ref Globals.ItemsOn3DImage.LastOrDefault().ROIMax, ref Globals.ItemsOn3DImage.LastOrDefault().ROIMinPoint, ref Globals.ItemsOn3DImage.LastOrDefault().ROIMaxPoint);

            for (int x = 0; x < data.Width; x++)
            {
                for (int y = 0; y < data.Height; y++)
                {
                    ushort value = depthImage[x + (y * data.Width)];

                    //if (value < minn)
                    //{
                    //    //value = max; // Debugging for right min and max value
                    //    value = (ushort)(realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width) - 1]);

                    //    realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width)] = value;
                    //}
                    //else if (value > maxx)
                    //{
                    //    //value = min; // Debugging for right min and max value
                    //    value = (ushort)(realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width) - 1]);

                    //    realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width)] = value;
                    //}

                    realSenseRawArray2DTrimmedByteGrayUshort.Data[y, x, 0] = value;

                    //realSenseRawArray2DTrimmedGrayNormizedUshort.Data[y, x, 0] = Normierung(value, min, max);
                }
            }


            //Image<Gray, ushort> depthImageasd = new Image<Gray, ushort>(data.Height, data.Width);
            //depthImageasd.Bytes = depthImage;

            realSenseRawArray2DTrimmedGrayNormizedByte = realSenseRawArray2DTrimmedByteGrayUshort.Convert<byte>(delegate (ushort b) { return (byte)(Normierung(b, min, max) / 257); });
            CvInvoke.CvtColor(realSenseRawArray2DTrimmedGrayNormizedByte, realSenseRawArray2DTrimmedRgbNormizedByteDisplay, ColorConversion.Gray2Bgr);


            //// Convert too byte gray value image
            //realSenseRawArray2DTrimmedGrayNormizedByte = realSenseRawArray2DTrimmedGrayNormizedUshort.Convert<byte>(delegate (ushort b) { return (byte)(b / 257); });
            ////CvInvoke.Imshow("realSenseRawArray2DTrimmedGrayNormizedByte", realSenseRawArray2DTrimmedGrayNormizedByte);

            //// Convert to byte color image
            //CvInvoke.CvtColor(realSenseRawArray2DTrimmedGrayNormizedByte, realSenseRawArray2DTrimmedRgbNormizedByteDisplay, ColorConversion.Gray2Bgr);
            ////CvInvoke.Imshow("realSenseRawArray2DTrimmedRgbNormizedByte", realSenseRawArray2DTrimmedRgbNormizedByte);
            */



            //imgImage.Source = ToBitmapSource(realSenseRawArray2DTrimmedRgbNormizedByteDisplay);

            //;




            // Depth sensor data to array
            //data.As<VideoFrame>().CopyTo(depthImage);
            //using (var vf = depthFrame.As<VideoFrame>())
            //{
            //    vf.CopyTo(depthImage);
            //}
        }

        private void MonitoringDepthColorized(VideoFrame data)
        {
            // Depth sensor sized to color sensor
            //ushort[] depthImage = new ushort[data.Width * data.Height];
            //ushort[] depthImage = new ushort[data.Length];

            // Depth sensor data to array
            //data.As<VideoFrame>().CopyTo(depthImage);
            //using (var vf = depthFrame.As<VideoFrame>())
            //{
            //    vf.CopyTo(depthImage);
            //}

            ;

            // Depth sensor sized to color sensor
            //ushort[] depthImage = new ushort[data.Width * data.Height];
            //ushort[] depthImage = new ushort[data.Length];4


            var rect2 = new Int32Rect(0, 0, data.Width, data.Height);
            WriteableBitmap temp2 = new WriteableBitmap(data.Width, data.Height, 96d, 96d, PixelFormats.Rgb24, null);
            temp2.WritePixels(rect2, data.Data, data.Stride * data.Height, data.Stride);







            //data.As<VideoFrame>().CopyTo(depthImage);

            //ushort max = depthImage.Max();
            //max = 2500;
            //ushort min = depthImage.Min();
            //min = 1000;

            //// 2D visualisation
            //Image<Rgb, byte> realSenseRawArray2DTrimmedRgbNormizedByteDisplay = new Image<Rgb, byte>(data.Width, data.Height, new Rgb(System.Drawing.Color.White));

            //Image<Gray, ushort> realSenseRawArray2DTrimmedByteGrayUshort = new Image<Gray, ushort>(data.Width, data.Height, new Gray(0));

            //Image<Gray, byte> realSenseRawArray2DTrimmedGrayNormizedByte = new Image<Gray, byte>(data.Width, data.Height, new Gray(0));
            //Image<Gray, ushort> realSenseRawArray2DTrimmedGrayNormizedUshort = new Image<Gray, ushort>(data.Width, data.Height, new Gray(0));

            ////CvInvoke.MinMaxLoc(realSenseRawArray2DTrimmedByteGrayUshort, ref data.ROIMin, ref Globals.ItemsOn3DImage.LastOrDefault().ROIMax, ref Globals.ItemsOn3DImage.LastOrDefault().ROIMinPoint, ref Globals.ItemsOn3DImage.LastOrDefault().ROIMaxPoint);

            //for (int x = 0; x < data.Width; x++)
            //{
            //    for (int y = 0; y < data.Height; y++)
            //    {
            //        ushort value = depthImage[x + (y * data.Width)];

            //        //if (value < minn)
            //        //{
            //        //    //value = max; // Debugging for right min and max value
            //        //    value = (ushort)(realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width) - 1]);

            //        //    realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width)] = value;
            //        //}
            //        //else if (value > maxx)
            //        //{
            //        //    //value = min; // Debugging for right min and max value
            //        //    value = (ushort)(realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width) - 1]);

            //        //    realSenseRawArray1DSum[x + (y * Globals.appSettings.Cameras3D[0].depthProfile.Width)] = value;
            //        //}

            //        realSenseRawArray2DTrimmedByteGrayUshort.Data[y, x, 0] = value;

            //        //realSenseRawArray2DTrimmedGrayNormizedUshort.Data[y, x, 0] = Normierung(value, min, max);
            //    }
            //}


            ////Image<Gray, ushort> depthImageasd = new Image<Gray, ushort>(data.Height, data.Width);
            ////depthImageasd.Bytes = depthImage;

            //realSenseRawArray2DTrimmedGrayNormizedByte = realSenseRawArray2DTrimmedByteGrayUshort.Convert<byte>(delegate (ushort b) { return (byte)(Normierung(b, min, max) / 257); });
            //CvInvoke.CvtColor(realSenseRawArray2DTrimmedGrayNormizedByte, realSenseRawArray2DTrimmedRgbNormizedByteDisplay, ColorConversion.Gray2Bgr);


            ////// Convert too byte gray value image
            ////realSenseRawArray2DTrimmedGrayNormizedByte = realSenseRawArray2DTrimmedGrayNormizedUshort.Convert<byte>(delegate (ushort b) { return (byte)(b / 257); });
            //////CvInvoke.Imshow("realSenseRawArray2DTrimmedGrayNormizedByte", realSenseRawArray2DTrimmedGrayNormizedByte);

            ////// Convert to byte color image
            ////CvInvoke.CvtColor(realSenseRawArray2DTrimmedGrayNormizedByte, realSenseRawArray2DTrimmedRgbNormizedByteDisplay, ColorConversion.Gray2Bgr);
            //////CvInvoke.Imshow("realSenseRawArray2DTrimmedRgbNormizedByte", realSenseRawArray2DTrimmedRgbNormizedByte);


            //Image<Bgr, byte>








            Bitmap asdas = BitmapFromWriteableBitmap(temp2);

            Mat matt = GetMatFromSDImage(asdas); //This is your Image converted to Mat

            Image<Bgr, byte> mat = matt.Clone().ToImage<Bgr, byte>();


            Rectangle rect;
            int minus = 40;
            int plus = 10;

            //rect = new Rectangle(110, 257, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[0].ToString("0.000") + "mm", new System.Drawing.Point(110 - minus, 257 - plus), FontFace.HersheyDuplex, 0.5, new MCvScalar(0, 255, 0));

            //rect = new Rectangle(405, 258, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[1].ToString("0.000") + "mm", new System.Drawing.Point(405 - minus, 258 - plus), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);

            //rect = new Rectangle(408, 511, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[2].ToString("0.000") + "mm", new System.Drawing.Point(408 - minus, 511 - plus), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);

            //rect = new Rectangle(110, 511, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[3].ToString("0.000") + "mm", new System.Drawing.Point(110 - minus, 511 - plus), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);




            //rect = new Rectangle(655, 250, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[4].ToString("0.000") + "mm", new System.Drawing.Point(655 - minus, 250 - plus), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);

            //rect = new Rectangle(940, 250, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[5].ToString("0.000") + "mm", new System.Drawing.Point(940 - minus, 250 - plus), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);

            //rect = new Rectangle(940, 515, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[6].ToString("0.000") + "mm", new System.Drawing.Point(940 - minus, 515 - plus), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);

            //rect = new Rectangle(650, 515, 15, 15);
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            //CvInvoke.PutText(mat, _valuesDepth[7].ToString("0.000") + "mm", new System.Drawing.Point(650 - minus, 515 - plus), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);




            rect = new Rectangle(175, 330, 200, 125);
            CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            CvInvoke.PutText(mat, _valuesDepth1[8].ToString("0.000") + "mm", new System.Drawing.Point(175 + 100 - minus, 330 + 75 - 10), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);

            rect = new Rectangle(695, 330, 200, 125);
            CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            CvInvoke.PutText(mat, _valuesDepth1[9].ToString("0.000") + "mm", new System.Drawing.Point(695 + 100 - minus, 330 + 75 - 10), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);



            //rect = new Rectangle(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox4.Text));
            //CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 2, LineType.Filled, 0);


            //imgImage.Source = temp2;
            imgImage.Source = ToBitmapSource(mat);

            //;














            // Depth sensor data to array
            //data.As<VideoFrame>().CopyTo(depthImage);
            //using (var vf = depthFrame.As<VideoFrame>())
            //{
            //    vf.CopyTo(depthImage);
            //}

        }




        ushort Normierung(ushort value, ushort min, ushort max)
        {
            int Osl = 0;
            int Osh = 65534;
            int Isl = min;
            int Ish = max;

            int valueReturn = (Osh - Osl) / (Ish - Isl) * ((int)value - Isl) + Osl;

            if (valueReturn > Osh)
            {
                valueReturn = Osl;
            }
            else if (valueReturn < Osl)
            {
                valueReturn = Osh;
            }

            //outArray.Data[x, y, 0] = (ushort)value;

            return (ushort)valueReturn;
        }








        private System.Drawing.Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp)
        {
            System.Drawing.Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                enc.Save(outStream);
                bmp = new System.Drawing.Bitmap(outStream);
            }
            return bmp;
        }

        private Mat GetMatFromSDImage(System.Drawing.Image image)
        {
            int stride = 0;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            return cvImage.Mat;
        }













        private void btnSamplin1_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Image<Rgb, byte> image = getBookSize();  // Get book size   
            imgImage.Source = new WriteableBitmap(image.Width, image.Height, 96d, 96d, PixelFormats.Rgb24, null); ;








        }





        #region Image Converter
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

        public static BitmapSource ToBitmapSource(Image<Bgr, byte> image)
        {
            using (System.Drawing.Bitmap source = image.ToBitmap())
            {
                IntPtr ptr = source.GetHbitmap();
                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ptr, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(ptr);
                return bs;
            }
        }

        public static BitmapSource ToBitmapSource(Mat image)
        {
            using (System.Drawing.Bitmap source = image.ToBitmap())
            {
                IntPtr ptr = source.GetHbitmap();
                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ptr, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(ptr);
                return bs;
            }
        }


        private System.Drawing.Bitmap ToBitmap(WriteableBitmap writeBmp)
        {
            System.Drawing.Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                enc.Save(outStream);
                bmp = new System.Drawing.Bitmap(outStream);
            }
            return bmp;
        }

        private Mat ToMat(System.Drawing.Image image)
        {
            int stride = 0;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            return cvImage.Mat;
        }

        #endregion








        void Normierung(ref Image<Gray, ushort> inArray, ref Image<Gray, ushort> outArray, int x, int y, ushort min, ushort max)
        {
            int Osl = 0;
            int Osh = 65534;
            int Isl = min;
            int Ish = max;

            int value = (Osh - Osl) / (Ish - Isl) * ((int)inArray.Data[x, y, 0] - Isl) + Osl;

            if (value > Osh)
            {
                value = Osl;
            }
            else if (value < Osl)
            {
                value = Osh;
            }

            outArray.Data[x, y, 0] = (ushort)value;
        }


















        Image<Rgb, byte> getBookSize()
        {
            ;


            // Common settings
            int imageScale = 1;
            ushort imageCounts = 3;

            // Image manipulation
            int removePixels = 25;

            int matrixElementX = 2;
            int matrixElementY = 15;

            // RealSense variables
            float[] realSenseDepthScale = new float[imageCounts]; // One meter

            //ILNumerics.Array<double> realSenseRawArray1DSum = new ushort[_depthProfile.Width * _depthProfile.Height];

            //Image<Rgb, byte> realSenseRawArray2DTrimmedRgbNormizedByte = new Image<Rgb, byte>((Globals.applicationSettings.cameras3D[0].depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels), (Globals.applicationSettings.cameras3D[0].depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels), new Rgb(System.Drawing.Color.White));
            Image<Rgb, byte> realSenseRawArray2DTrimmedRgbNormizedByteDisplay = new Image<Rgb, byte>((_depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels), (_depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels), new Rgb(System.Drawing.Color.White));

            // Inizialize variables
            _itemsOn3DImage.Clear();


            for (int i = 0; i < imageCounts; i++)
            {
                #region You must use using when displaying the frame, otherwise it will prompt that Frame didn't arrived within 5000, and the Frame was not released correctly by .net.
                using (var frames = _pipeline.WaitForFrames())
                {
                    // Read Data
                    DepthFrame realSenseDepthFrame = frames.DepthFrame.DisposeWith(frames) as DepthFrame;
                    Intrinsics realSenseIntrinsics = frames.GetProfile<VideoStreamProfile>().GetIntrinsics();

                    // Temp data
                    ushort[] tempDepth = new ushort[_depthProfile.Width * _depthProfile.Height];

                    // Get depth scale value
                    //realSenseDepthScale[i] = 1f / _depthSensor.DepthScale;

                    // Copy depthvalues to array
                    realSenseDepthFrame.CopyTo(tempDepth);

                    // Add values to arrays (for mean value) 
                    //realSenseRawArray1DSum += (ILNumerics.Array<double>)tempDepth;

                    // Evaluation of the values
                    if (i == imageCounts - 1)
                    {
                        ;

                        // Variables
                        ushort minn = (ushort)(0.7 * realSenseDepthScale[0] * imageCounts);
                        ushort maxx = (ushort)(0.78 * realSenseDepthScale[0] * imageCounts);

                        // 2D visualisation
                        Image<Gray, ushort> realSenseRawArray2DTrimmedByteGrayUshort = new Image<Gray, ushort>((_depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels), (_depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels), new Gray(0));

                        Image<Gray, byte> realSenseRawArray2DTrimmedGrayNormizedByte = new Image<Gray, byte>((_depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels), (_depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels), new Gray(0));
                        Image<Gray, ushort> realSenseRawArray2DTrimmedGrayNormizedUshort = new Image<Gray, ushort>((_depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels), (_depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels), new Gray(0));

                        //// 3D visualisation
                        //ILNumerics.Array<float> iLdeepthArrayFloatLeft1 = new float[(_depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels), (_depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels)];
                        //ILNumerics.Array<float> iLdeepthArrayFloaRight1 = new float[(_depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels), (_depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels)];


                        ;


                        //// 1D to 2D Array with scaling and Min-/Max- Filter
                        //for (int x = matrixElementX + removePixels; x < (_depthProfile.Width / imageScale) - matrixElementX - removePixels; x++)
                        //{
                        //    for (int y = matrixElementY + removePixels; y < (_depthProfile.Height / imageScale) - matrixElementY - removePixels; y++)
                        //    {
                        //        ushort value = (ushort)(realSenseRawArray1DSum[x + (y * _depthProfile.Width)]);

                        //        if (value < minn)
                        //        {
                        //            //value = max; // Debugging for right min and max value
                        //            value = (ushort)(realSenseRawArray1DSum[x + (y * _depthProfile.Width) - 1]);

                        //            realSenseRawArray1DSum[x + (y * _depthProfile.Width)] = value;
                        //        }
                        //        else if (value > maxx)
                        //        {
                        //            //value = min; // Debugging for right min and max value
                        //            value = (ushort)(realSenseRawArray1DSum[x + (y * _depthProfile.Width) - 1]);

                        //            realSenseRawArray1DSum[x + (y * _depthProfile.Width)] = value;
                        //        }

                        //        realSenseRawArray2DTrimmedByteGrayUshort.Data[x - matrixElementX - removePixels, y - matrixElementY - removePixels, 0] = (ushort)(value / imageCounts);
                        //    }
                        //}


                        ;


                        // Calculate max and min valuse of the whole picture
                        _itemsOn3DImage.Add(new ItemOn3DImage()
                        {
                            name = "Whole image"
                        });
                        CvInvoke.MinMaxLoc(realSenseRawArray2DTrimmedByteGrayUshort, ref _itemsOn3DImage.LastOrDefault().ROIMin, ref _itemsOn3DImage.LastOrDefault().ROIMax, ref _itemsOn3DImage.LastOrDefault().ROIMinPoint, ref _itemsOn3DImage.LastOrDefault().ROIMaxPoint);


                        ;


                        // Filtering data
                        for (int x = 0; x < (_depthProfile.Width / imageScale) - (2 * matrixElementX) - (2 * removePixels); x++)
                        {
                            for (int y = 0; y < (_depthProfile.Height / imageScale) - (2 * matrixElementY) - (2 * removePixels); y++)
                            {
                                // No Filter                  
                                //NoFilter(ref realSenseRawArray2DTrimmedByteGrayUshort, ref iLdeepthArrayFloatLeft1, x, y, realSenseDepthScale[0]);

                                // Normierung
                                //Normierung(ref realSenseRawArray2DTrimmedByteGrayUshort, ref realSenseRawArray2DTrimmedGrayNormizedUshort, x, y, (ushort)(Globals.ItemsOn3DImage.LastOrDefault().ROIMin - 5), (ushort)(Globals.ItemsOn3DImage.LastOrDefault().ROIMax + 5));

                                // Medan filter
                                //MediaFilter(ref iLdeepthArray2D, ref iLdeepthArrayFloaRight1, x, matrixSizeX, matrixElementX, y, matrixSizeY, matrixElementY, removePixels, depthScale[0]);

                                // Mittelwert Filter
                                //MeanFilter(ref iLdeepthArray2D, ref iLdeepthArrayFloaRight1, x, matrixSizeX, matrixElementX, y, matrixSizeY, matrixElementY, removePixels, depthScale[0]);

                                // Minimum Filter
                                //MinFilter(ref iLdeepthArray2D, ref iLdeepthArrayFloaRight1, x, matrixSizeX, matrixElementX, y, matrixSizeY, matrixElementY, removePixels, depthScale[0]);

                                // Special Filter 1
                                //specialFilter1(ref iLdeepthArray2D, ref iLdeepthArrayFloaRight1, x, matrixSizeX, matrixElementX, y, matrixSizeY, matrixElementY, removePixels, deviation, depthScale[0]);
                            }
                        }


                        ;


                        // Convert too byte gray value image
                        realSenseRawArray2DTrimmedGrayNormizedByte = realSenseRawArray2DTrimmedGrayNormizedUshort.Convert<byte>(delegate (ushort b) { return (byte)(b / 257); });
                        //CvInvoke.Imshow("realSenseRawArray2DTrimmedGrayNormizedByte", realSenseRawArray2DTrimmedGrayNormizedByte);

                        // Convert to byte color image
                        CvInvoke.CvtColor(realSenseRawArray2DTrimmedGrayNormizedByte, realSenseRawArray2DTrimmedRgbNormizedByteDisplay, ColorConversion.Gray2Bgr);
                        //CvInvoke.Imshow("realSenseRawArray2DTrimmedRgbNormizedByte", realSenseRawArray2DTrimmedRgbNormizedByte);


                        ;


                        #region Create Rectangles and measure hights (Zero Position)
                        // Draw and calculate zero plane top side
                        DrawAndCalculatePlaneOfROI("Top rectangle for zero plane",
                                                    new System.Drawing.Rectangle(25, 25, realSenseRawArray2DTrimmedRgbNormizedByteDisplay.Width - 50, 50),
                                                    ref realSenseRawArray2DTrimmedByteGrayUshort,
                                                    ref realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                    realSenseDepthScale[0]);

                        // Draw and calculate zero plane buttom side
                        DrawAndCalculatePlaneOfROI("Buttom rectangle for zero plane",
                                                    new System.Drawing.Rectangle(25, realSenseRawArray2DTrimmedRgbNormizedByteDisplay.Height - 25 - 50, realSenseRawArray2DTrimmedRgbNormizedByteDisplay.Width - 50, 50),
                                                    ref realSenseRawArray2DTrimmedByteGrayUshort,
                                                    ref realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                    realSenseDepthScale[0]);
                        #endregion


                        ;


                        #region Create Rectangles and measure hight (items --> books, ...)
                        List<RotatedRect> boxList = GetElements(realSenseRawArray2DTrimmedGrayNormizedByte.Mat, 150, 125, 175);

                        if (boxList.Count > 0)
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                // Variables
                                float angle = boxList[j].Angle;
                                int centerX = (int)boxList[j].Center.X;
                                int centerY = (int)boxList[j].Center.Y;
                                int width = (int)boxList[j].Size.Width;
                                int height = (int)boxList[j].Size.Height;

                                RotatedRect rotatedRect;

                                #region Draw and calculate Whole book
                                // Draw polylines
                                CvInvoke.Polylines(realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                    Array.ConvertAll(boxList[j].GetVertices(),
                                                    System.Drawing.Point.Round),
                                                    true,
                                                    new Bgr(System.Drawing.Color.Orange).MCvScalar, 1);

                                rotatedRect = new RotatedRect(new System.Drawing.Point(centerX, centerY), new SizeF(width, height), angle);

                                DrawAndCalculatePlaneOfROI(string.Format("Whole rectangle for book #{0} plane", j + 1),
                                                            CvInvoke.BoundingRectangle(new Emgu.CV.Util.VectorOfPointF(rotatedRect.GetVertices())),
                                                            ref realSenseRawArray2DTrimmedByteGrayUshort,
                                                            ref realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                            realSenseDepthScale[0]);

                                // Calculate book size distance
                                try
                                {
                                    Vector2D vector = new Vector2D();
                                    Vector3D vector1 = new Vector3D();
                                    Vector3D vector2 = new Vector3D();

                                    // Left top corner
                                    vector.Y = centerX - width / 2;
                                    vector.X = centerY - height / 2;
                                    vector1 = CoordinateMapper.Map2DTo3D(realSenseIntrinsics, vector, realSenseDepthFrame.GetDistance((int)vector.X, (int)vector.Y));

                                    // Right buttom corner
                                    vector.Y = centerX + width / 2;
                                    vector.X = centerY + height / 2;
                                    vector2 = CoordinateMapper.Map2DTo3D(realSenseIntrinsics, vector, realSenseDepthFrame.GetDistance((int)vector.X, (int)vector.Y));

                                    // Calculate width of the book
                                    _itemsOn3DImage.LastOrDefault().ROISizeY = (float)Math.Sqrt(Math.Pow((double)(vector1.Y - vector2.Y), 2)) * 1000;
                                    _itemsOn3DImage.LastOrDefault().ROISizeYHalf = _itemsOn3DImage.LastOrDefault().ROISizeY / 2.0f;
                                    DrawText(ref realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                new System.Drawing.Point(centerX, centerY - height / 2 - 50),
                                                new Bgr(System.Drawing.Color.Purple).MCvScalar,
                                                "W" + _itemsOn3DImage.LastOrDefault().ROISizeY.ToString("0.00") + " mm");

                                    // Calculate height of the book
                                    _itemsOn3DImage.LastOrDefault().ROISizeX = (float)Math.Sqrt(Math.Pow((double)(vector1.X - vector2.X), 2)) * 1000;
                                    _itemsOn3DImage.LastOrDefault().ROISizeXHalf = _itemsOn3DImage.LastOrDefault().ROISizeX / 2.0f;
                                    DrawText(ref realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                new System.Drawing.Point(centerX - 225, centerY),
                                                new Bgr(System.Drawing.Color.Purple).MCvScalar,
                                                "H" + _itemsOn3DImage.LastOrDefault().ROISizeX.ToString("0.00") + " mm");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                #endregion

                                #region Draw and calculate book plane top side
                                rotatedRect = new RotatedRect(new System.Drawing.Point(centerX, centerY - (height / 2 - height / 8 - 25)), new SizeF(width - 50, height / 4), angle);

                                DrawAndCalculatePlaneOfROI(string.Format("Top rectangle for book #{0} plane", j + 1),
                                                            CvInvoke.BoundingRectangle(new Emgu.CV.Util.VectorOfPointF(rotatedRect.GetVertices())),
                                                            ref realSenseRawArray2DTrimmedByteGrayUshort,
                                                            ref realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                            realSenseDepthScale[0]);

                                CvInvoke.Polylines(realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                            Array.ConvertAll(rotatedRect.GetVertices(),
                                            System.Drawing.Point.Round),
                                            true,
                                            new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
                                #endregion

                                #region Draw and calculate book plane buttom side
                                rotatedRect = new RotatedRect(new System.Drawing.Point(centerX, centerY + (height / 2 - height / 8 - 25)), new SizeF(width - 50, height / 4), angle);

                                DrawAndCalculatePlaneOfROI(string.Format("Buttom rectangle for book #{0} plane", j + 1),
                                                        CvInvoke.BoundingRectangle(new Emgu.CV.Util.VectorOfPointF(rotatedRect.GetVertices())),
                                                        ref realSenseRawArray2DTrimmedByteGrayUshort,
                                                        ref realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                        realSenseDepthScale[0]);

                                CvInvoke.Polylines(realSenseRawArray2DTrimmedRgbNormizedByteDisplay,
                                                 Array.ConvertAll(rotatedRect.GetVertices(),
                                                 System.Drawing.Point.Round),
                                                 true,
                                                 new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
                                #endregion
                            }
                        }
                        #endregion

                        // Reset ROI
                        realSenseRawArray2DTrimmedByteGrayUshort.ROI = System.Drawing.Rectangle.Empty;

                        ;

                        // 3D image
                        //panel11.Scene.Remove(panel11.Scene.ElementAt(1));
                        //panel11.Scene.Add(new PlotCube(twoDMode: false)
                        //{
                        //    new Surface(iLdeepthArrayFloatLeft1, colormap: Colormaps.Jet)
                        //        {
                        //            new Colorbar()
                        //        }
                        //});

                        //CvInvoke.Imshow("Image Trimmed RGB", realSenseRawArray2DTrimmedRgbNormizedByteDisplay);
                    }
                }
                #endregion
            }

            // Stop RealSense
            //Globals.appSettings.Cameras3D[0].pipeline.Stop();

            return realSenseRawArray2DTrimmedRgbNormizedByteDisplay;
        }


        public List<RotatedRect> GetElements(Mat img, double threshold, double cannyThreshold1, double cannyThreshold2)
        {
            using (UMat cannyEdges = new UMat())
            {
                using (Mat triangleRectangleImage = new Mat(img.Size, DepthType.Cv8U, 3)) //image to draw triangles and rectangles on
                {
                    using (Mat lineImage = new Mat(img.Size, DepthType.Cv8U, 3)) //image to drtaw lines on
                    {
                        // Remove noise
                        CvInvoke.GaussianBlur(img, img, new System.Drawing.Size(9, 9), 0, 0, BorderType.Replicate);
                        //CvInvoke.Imshow("GaussianBlur Image", img);

                        // Calculate treshold
                        CvInvoke.Threshold(img, img, threshold, 255, ThresholdType.Binary);
                        //CvInvoke.Imshow("Threshold Image", img);

                        #region Canny and edge detection
                        CvInvoke.Canny(img, cannyEdges, cannyThreshold1, cannyThreshold2, 3, false);
                        //LineSegment2D[] lines = CvInvoke.HoughLinesP(cannyEdges,
                        //                                                1, //Distance resolution in pixel-related units
                        //                                                Math.PI / 45.0, //Angle resolution measured in radians.
                        //                                                20, //threshold
                        //                                                30, //min Line width
                        //                                                10); //gap between lines
                        #endregion

                        #region Find triangles and rectangles
                        //List<Triangle2DF> triangleList = new List<Triangle2DF>();
                        List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle

                        using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                        {
                            CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                            int count = contours.Size;

                            for (int i = 0; i < count; i++)
                            {
                                using (VectorOfPoint contour = contours[i])
                                using (VectorOfPoint approxContour = new VectorOfPoint())
                                {
                                    CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);

                                    if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                                    {
                                        //if (approxContour.Size == 3) //The contour has 3 vertices, it is a triangle
                                        //{
                                        //    System.Drawing.Point[] pts = approxContour.ToArray();
                                        //    triangleList.Add(new Triangle2DF(pts[0], pts[1], pts[2]));
                                        //}
                                        //else if (approxContour.Size == 4) //The contour has 4 vertices.
                                        if (approxContour.Size == 4) //The contour has 4 vertices.
                                        {
                                            #region determine if all the angles in the contour are within [80, 100] degree
                                            bool isRectangle = true;
                                            System.Drawing.Point[] pts = approxContour.ToArray();
                                            LineSegment2D[] edges = Emgu.CV.PointCollection.PolyLine(pts, true);

                                            for (int j = 0; j < edges.Length; j++)
                                            {
                                                double angle = Math.Abs(edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                                if (angle < 80 || angle > 100)
                                                {
                                                    isRectangle = false;
                                                    break;
                                                }
                                            }
                                            #endregion

                                            if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        //#region draw triangles and rectangles
                        ////triangleRectangleImage.SetTo(new MCvScalar(0));
                        ////foreach (Triangle2DF triangle in triangleList)
                        ////{
                        ////    CvInvoke.Polylines(triangleRectangleImage, Array.ConvertAll(triangle.GetVertices(), System.Drawing.Point.Round), true, new Bgr(System.Drawing.Color.DarkBlue).MCvScalar, 2);
                        ////}

                        //foreach (RotatedRect box in boxList)
                        //{
                        //    CvInvoke.Polylines(triangleRectangleImage, Array.ConvertAll(box.GetVertices(), System.Drawing.Point.Round), true, new Bgr(System.Drawing.Color.DarkOrange).MCvScalar, 2);
                        //}

                        ////Drawing a light gray frame around the image
                        //CvInvoke.Rectangle(triangleRectangleImage, new Rectangle(System.Drawing.Point.Empty, new System.Drawing.Size(triangleRectangleImage.Width - 1, triangleRectangleImage.Height - 1)), new MCvScalar(120, 120, 120));

                        ////Draw the labels
                        //CvInvoke.PutText(triangleRectangleImage, "Triangles and Rectangles", new System.Drawing.Point(20, 20), FontFace.HersheyDuplex, 0.5, new MCvScalar(120, 120, 120));

                        //CvInvoke.Imshow("Triagle and Rectangle Image", triangleRectangleImage);
                        //#endregion

                        //#region draw lines
                        //lineImage.SetTo(new MCvScalar(0));
                        //foreach (LineSegment2D line in lines)
                        //{
                        //    CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(System.Drawing.Color.Green).MCvScalar, 2);
                        //}

                        ////Drawing a light gray frame around the image
                        //CvInvoke.Rectangle(lineImage, new Rectangle(System.Drawing.Point.Empty, new System.Drawing.Size(lineImage.Width - 1, lineImage.Height - 1)), new MCvScalar(120, 120, 120));

                        ////Draw the labels
                        //CvInvoke.PutText(lineImage, "Lines", new System.Drawing.Point(20, 20), FontFace.HersheyDuplex, 0.5, new MCvScalar(120, 120, 120));

                        //CvInvoke.Imshow("Line Image", lineImage);
                        //#endregion

                        // Rotate rectange
                        List<RotatedRect> boxListNew = new List<RotatedRect>(); //a box is a rotated rectangle

                        foreach (RotatedRect item in boxList)
                        {
                            if (item.Size.Height < item.Size.Width)
                            {
                                boxListNew.Add(new RotatedRect(item.Center, new SizeF(item.Size.Height, item.Size.Width), 90 + item.Angle));
                            }
                            else
                            {
                                boxListNew.Add(item);
                            }
                        }

                        return boxListNew;
                    }
                }
            }
        }

        public void DrawAndCalculatePlaneOfROI(string name, System.Drawing.Rectangle ROI, ref Image<Gray, ushort> imgGray, ref Image<Rgb, byte> imgRGB, float depthScale)
        {
            _itemsOn3DImage.Add(new ItemOn3DImage()
            {
                name = name,
                ROI = ROI
            });

            // Draw rectangle to image
            CvInvoke.Rectangle(imgRGB, _itemsOn3DImage.LastOrDefault().ROI, new Rgb(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);

            // Set rectangle (ROI) on gray scale image and get values
            imgGray.ROI = _itemsOn3DImage.LastOrDefault().ROI;

            _itemsOn3DImage.LastOrDefault().ROIMean = CvInvoke.Mean(imgGray);
            _itemsOn3DImage.LastOrDefault().ROIMeanMM = _itemsOn3DImage.LastOrDefault().ROIMean.V0 / depthScale * 1000;

            CvInvoke.MinMaxLoc(imgGray, ref _itemsOn3DImage.LastOrDefault().ROIMin, ref _itemsOn3DImage.LastOrDefault().ROIMax, ref _itemsOn3DImage.LastOrDefault().ROIMinPoint, ref _itemsOn3DImage.LastOrDefault().ROIMaxPoint);
            _itemsOn3DImage.LastOrDefault().ROIMinMM = _itemsOn3DImage.LastOrDefault().ROIMin / depthScale * 1000;
            _itemsOn3DImage.LastOrDefault().ROIMaxMM = _itemsOn3DImage.LastOrDefault().ROIMax / depthScale * 1000;

            // Draw text
            string text = _itemsOn3DImage.LastOrDefault().ROIMeanMM.ToString("0.00") + " mm";
            FontFace font = FontFace.HersheySimplex;
            double fontScale = 1.0;
            int baseLine = 0;
            var textsize = CvInvoke.GetTextSize(text, font, fontScale, 2, ref baseLine);
            System.Drawing.Point drawPoint = new System.Drawing.Point(imgGray.ROI.X + imgGray.ROI.Width / 2 - textsize.Width / 2, imgGray.ROI.Y + imgGray.ROI.Height / 2 + textsize.Height / 2);

            CvInvoke.PutText(imgRGB, text, drawPoint, font, fontScale, new Bgr(System.Drawing.Color.Blue).MCvScalar);
        }

        public void DrawText(ref Image<Rgb, byte> img, System.Drawing.Point drawPoint, MCvScalar color, string text)
        {
            FontFace font = FontFace.HersheySimplex;
            double fontScale = 1.0;
            int baseLine = 0;
            var textsize = CvInvoke.GetTextSize(text, font, fontScale, 2, ref baseLine);

            CvInvoke.PutText(img,
                text,
                new System.Drawing.Point(drawPoint.X - textsize.Width / 2, drawPoint.Y + textsize.Height / 2),
                font,
                fontScale,
                color);
        }











        public class ItemOn3DImage
        {
            public string name;

            public System.Drawing.Rectangle ROI;

            public double ROIMin;
            public double ROIMinMM;
            public System.Drawing.Point ROIMinPoint;
            public double ROIMax;
            public double ROIMaxMM;
            public System.Drawing.Point ROIMaxPoint;
            public double ROIMeanMM;
            public MCvScalar ROIMean;

            public float ROISizeX;
            public float ROISizeXHalf;
            public float ROISizeY;
            public float ROISizeYHalf;

            public RotatedRect boxList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Mat img = CvInvoke.Imread("myimage.jpg", ImreadModes.AnyColor);
            //var img = new Image<Bgr, byte>("C:\\Users\\schnegg\\Downloads\\Screenshot 2024-01-20 235949.png");
            //Image<Bgr, byte> img = new Image<Bgr, byte>("C:\\Users\\schnegg\\Downloads\\IMG_202401
            //23_151225.jpg");
            //Image<Bgr, Byte>  img = new Image<Bgr, byte>("C:\\Users\\schnegg\\Downloads\\IMG_20240122_175521.jpg");

            Image<Bgr, Byte> img = new Image<Bgr, Byte>("C:\\Users\\msdit\\Downloads\\20240508_154801.6755_1.jpg");


            IInputArray img1arr = img;
            //IOutputArrayOfArrays img1arrr = img;
            //Mat pos = new Mat(1, 2, Emgu.CV.CvEnum.DepthType.Cv32S, 1);

            QRCodeDetector detector = new QRCodeDetector();
            //bool decoded = detector.Detect(img1arr, pos); //this returns true
            //var decoded = detector.DetectAndDecodeMulti(img1arr, img1arrr); //this returns true







            GraphicalCode[] asdasd = detector.DetectAndDecodeMulti(img1arr);

            // Draw polylines
            //CvInvoke.Polylines(img, Array.ConvertAll(boxList[j].GetVertices(), System.Drawing.Point.Round), true, new Bgr(System.Drawing.Color.Orange).MCvScalar, 1);
            CvInvoke.Line(img, ConvertPointFToPonint(asdasd[0].Points[0]), ConvertPointFToPonint(asdasd[0].Points[1]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
            CvInvoke.Line(img, ConvertPointFToPonint(asdasd[0].Points[1]), ConvertPointFToPonint(asdasd[0].Points[2]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
            CvInvoke.Line(img, ConvertPointFToPonint(asdasd[0].Points[2]), ConvertPointFToPonint(asdasd[0].Points[3]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
            CvInvoke.Line(img, ConvertPointFToPonint(asdasd[0].Points[3]), ConvertPointFToPonint(asdasd[0].Points[0]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);

            //CvInvoke.Rectangle(img, new System.Drawing.Rectangle(ConvertPointFToPonint(asdasd[0].Points[0]), new System.Drawing.Size(100, 100)), new Bgr(System.Drawing.Color.Red).MCvScalar, 2, LineType.EightConnected, 0);

            float lengthhh = asdasd[0].DecodedInfo.Length * 10.000f / 2.000f;
            float asdsa = (asdasd[0].Points[0].X + asdasd[0].Points[1].X) / 2 - lengthhh;

            CvInvoke.PutText(img, asdasd[0].DecodedInfo, new System.Drawing.Point((int)asdsa, (int)(asdasd[0].Points[3].Y + 50.000f)), FontFace.HersheySimplex, 1.0, new Bgr(System.Drawing.Color.Blue).MCvScalar, 2, LineType.EightConnected);

            imgImage.Source = ToBitmapSource(img);


            ;
        }


        public static void Calculation(float[,] values, ref float mean, ref float standardDeviation)
        {
            float sum = 0;

            for (int row = 0; row < values.GetLength(0); row++)
            {
                for (int col = 0; col < values.GetLength(1); col++)
                {
                    sum += values[row, col];
                }
            }
            mean = sum / values.Length;

            float sqDiff = 0;

            for (int row = 0; row < values.GetLength(0); row++)
            {
                for (int col = 0; col < values.GetLength(1); col++)
                {
                    sqDiff += (values[row, col] - mean) * (values[row, col] - mean);
                }
            }
            standardDeviation = (float)Math.Sqrt(sqDiff / mean);
        }

        System.Drawing.Point ConvertPointFToPonint(System.Drawing.PointF value)
        {
            return new System.Drawing.Point((int)value.X, (int)value.Y);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //// Load the image and compute the ratio of the old height to the new height, clone it, and resize it
            ////Mat img = CvInvoke.Imread("myimage.jpg", ImreadModes.AnyColor);
            //Image<Rgb, Byte> image = new Image<Rgb, Byte>("C:\\Users\\schnegg\\Downloads\\Screenshot 2024-01-20 235949.png");
            //Image<Rgb, Byte> orig_image = image.Copy();
            //CvInvoke.Imshow("orig", orig_image);
            ////CvInvoke.Resize(image, image, new System.Drawing.Size(250, 500));

            //Image<Gray, Byte> gray = new Image<Gray, Byte>(image.Width, image.Height, new Gray(0));
            //Image<Gray, Byte> blur = new Image<Gray, Byte>(image.Width, image.Height, new Gray(0));
            //Image<Gray, Byte> edged = new Image<Gray, Byte>(image.Width, image.Height, new Gray(0));
            //// Convert the image to grayscale, blur it, and find edges in the image
            //CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
            //CvInvoke.Imshow("CvtColor", gray);
            //CvInvoke.GaussianBlur(gray, blur, new System.Drawing.Size(5, 5), 0);
            //CvInvoke.Imshow("GaussianBlur", blur);
            //CvInvoke.Canny(gray, edged, 75, 200);
            //CvInvoke.Imshow("Canny", edged);






            //VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            //VectorOfVectorOfPoint contoursSorted = new VectorOfVectorOfPoint();
            //Mat hirarchy = new Mat();
            //// Find the contours in the edged image, keeping only the largest ones, and initialize the screen contour
            //CvInvoke.FindContours(edged, contours, hirarchy, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            ////CvInvoke.Sort(contours, contoursSorted, SortFlags.SortEveryRow); //cnts = sorted(cnts, key = cv2.contourArea, reverse = True)[:5]
            //CvInvoke.DrawContours(image, contours, -1, new Bgr(System.Drawing.Color.Lime).MCvScalar, 3);
            //CvInvoke.Imshow("contours", image);

            //VectorOfPoint approxContour = new VectorOfPoint();
            //VectorOfPoint doc_cnts = new VectorOfPoint();

            //for(int i =0; i< contours.Size; i++)
            //{
            //    double pri = CvInvoke.ArcLength(contours[i], true);
            //    CvInvoke.ApproxPolyDP(contours[i], approxContour, 0.05 * pri, true);

            //    if (approxContour.Size == 4)
            //    {
            //        doc_cnts = approxContour;
            //    }

            //}

            //CvInvoke.DrawContours(orig_image, contours, -1, new Bgr(System.Drawing.Color.Lime).MCvScalar, 3);
            //CvInvoke.Imshow("contourss", orig_image);




            ////            Image<Gray, Byte> warped = new Image<Gray, Byte>(image.Width, image.Height, new Gray(0));
            ////            Image<Gray, Byte> hirarchy = new Image<Gray, Byte>(image.Width, image.Height, new Gray(0));
            ////            // apply the four point transform to obtain a top-down view of the original image
            ////            warped = CvInvoke.fou four_point_transform(orig, screenCnt.reshape(4, 2) * ratio)
            ////# convert the warped image to grayscale, then threshold it
            ////# to give it that 'black and white' paper effect
            ////warped = cv2.cvtColor(warped, cv2.COLOR_BGR2GRAY)
            ////T = threshold_local(warped, 11, offset = 10, method = "gaussian")
            ////warped = (warped > T).astype("uint8") * 255
            ////# show the original and scanned images
            ////print("STEP 3: Apply perspective transform")
            ////cv2.imshow("Original", imutils.resize(orig, height = 650))
            ////cv2.imshow("Scanned", imutils.resize(warped, height = 650))
            ////cv2.waitKey(0)





            //Image<Bgr, byte> image = new Image<Bgr, byte>("C:\\Users\\schnegg\\Downloads\\Screenshot 2024-01-20 235949.png");
            //var image = new Image<Bgr, byte>("C:\\Users\\schnegg\\Downloads\\IMG_20240122_182850.jpg");
            Image<Bgr, byte> image = new Image<Bgr, byte>("C:\\Users\\schnegg\\Downloads\\IMG_20240123_162843.jpg");
            Image<Bgr, byte> imageOriginal = image.Copy();
            CvInvoke.Imshow("image", image);

            //var grayScaleImage = image.Convert<Gray, byte>();
            //CvInvoke.Imshow("contourss", grayScaleImage);

            //var blurredImage = grayScaleImage.SmoothGaussian(5, 5, 0, 0);
            //CvInvoke.Imshow("contourss", blurredImage);

            //Image<Gray, Byte> blur = new Image<Gray, Byte>(image.Width, image.Height, new Gray(0));
            //CvInvoke.GaussianBlur(grayScaleImage, blur, new System.Drawing.Size(5, 5), 0);

            var doc_cnts = new VectorOfPoint();
            int tasdasd = 0;

            using (var grayScaleImage1 = imageOriginal.Convert<Gray, byte>())
            {
                CvInvoke.Imshow("grayScaleImage1", grayScaleImage1);

                using (var blurredImage1 = grayScaleImage1.SmoothGaussian(5, 5, 0, 0))
                {
                    CvInvoke.Imshow("contourss", blurredImage1);

                    using (var cannyImage = new UMat())
                    {
                        CvInvoke.Canny(blurredImage1, cannyImage, 50, 150);
                        CvInvoke.Imshow("cannyImage", cannyImage);

                        using (var contours = new VectorOfVectorOfPoint())
                        {
                            CvInvoke.FindContours(cannyImage, contours, null, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);

                            CvInvoke.DrawContours(image, contours, -1, new Bgr(System.Drawing.Color.Lime).MCvScalar, 3);
                            CvInvoke.Imshow("contouasdrss", image);
                            image = imageOriginal.Copy();

                            //foreach (var contourVector in contours)
                            //{
                            //    using (var contour = new VectorOfPoint())
                            //    {
                            //        var peri = CvInvoke.ArcLength(contourVector, true);
                            //        CvInvoke.ApproxPolyDP(contourVector, contour, 0.1 * peri, true);
                            //        if (contour != null && contour.ToArray().Length == 4 && CvInvoke.IsContourConvex(contour))
                            //            return contour;
                            //    }
                            //}

                            for (int i = 0; i < contours.Size; i++)
                            {
                                var contour = new VectorOfPoint();

                                double pri = CvInvoke.ArcLength(contours[i], true);
                                CvInvoke.ApproxPolyDP(contours[i], contour, 0.02 * pri, true);

                                if (contour != null && contour.ToArray().Length == 4 && CvInvoke.IsContourConvex(contour))
                                {
                                    doc_cnts = contour;

                                    image = imageOriginal.Copy();
                                    CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[0]), ConvertPointFToPonint(doc_cnts[1]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
                                    CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[1]), ConvertPointFToPonint(doc_cnts[2]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
                                    CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[2]), ConvertPointFToPonint(doc_cnts[3]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
                                    CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[3]), ConvertPointFToPonint(doc_cnts[0]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
                                    CvInvoke.Imshow("imageasd" + i, image);
                                    tasdasd++;
                                }
                            }

                            //CvInvoke.DrawContours(image, doc_cnts, -1, new Bgr(System.Drawing.Color.Lime).MCvScalar, 3);
                            //CvInvoke.Imshow("contouasdrasdss", image);
                            //image = imageOriginal.Copy();
                        }
                    }
                }
            }


            CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[0]), ConvertPointFToPonint(doc_cnts[1]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
            CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[1]), ConvertPointFToPonint(doc_cnts[2]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
            CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[2]), ConvertPointFToPonint(doc_cnts[3]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
            CvInvoke.Line(image, ConvertPointFToPonint(doc_cnts[3]), ConvertPointFToPonint(doc_cnts[0]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);

            CvInvoke.Imshow("imageasd", image);





            ;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Image<Bgr, byte> image = new Image<Bgr, byte>("C:\\Users\\schnegg\\Downloads\\Screenshot 2024-01-20 235949.png");
            Image<Bgr, byte> segmentedImage = image.Copy();

            CvInvoke.Imshow("Hello World!", image);

            //float[,] scrp = { { 43, 18 }, { 280, 40 }, { 19, 223 }, { 304, 200 } };
            //float[,] dstp = { { 0, 0 }, { 320, 0 }, { 0, 240 }, { 320, 240 } };
            //float[,] homog = new float[3, 3];


            //Matrix<float> c1 = new Matrix<float>(scrp);
            //Matrix<float> c2 = new Matrix<float>(dstp);
            //Matrix<float> homogm = new Matrix<float>(homog);


            //Mat homogmm = CvInvoke.FindHomography(c1.Ptr, c2.Ptr, RobustEstimationAlgorithm.AllPoints, 0, homogm);
            //CvInvoke.GetPerspectiveTransform(c1, c2, homogm);

            //Image<Bgr, byte> newImage = image.WarpPerspective(homogm, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC, Emgu.CV.CvEnum.WARP.CV_WARP_DEFAULT, new Bgr(0, 0, 0));

            //CvInvoke.Imshow("newImage", newImage);


            CvInvoke.CornerHarris(segmentedImage, image, 2);
            CvInvoke.Normalize(image, image, 0, 255, NormType.MinMax, DepthType.Cv32F);








        }
    }
}
