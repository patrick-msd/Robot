using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Intel.RealSense;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RC.Scan_SingleSolution
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        private void MonitoringColor(VideoFrame data)
        {
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

            Calculation(array9, ref _valuesDepthMean[8], ref _valuesDepthStandardDeviation[8]);
            Calculation(array10, ref _valuesDepthMean[9], ref _valuesDepthStandardDeviation[9]);






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
            CvInvoke.PutText(mat, _valuesDepthMean[8].ToString("0.000") + "mm", new System.Drawing.Point(175 + 100 - minus, 330 + 75 - 10), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);

            rect = new Rectangle(695, 330, 200, 125);
            CvInvoke.Rectangle(mat, rect, new Bgr(System.Drawing.Color.Lime).MCvScalar, 1, LineType.EightConnected, 0);
            CvInvoke.PutText(mat, _valuesDepthMean[9].ToString("0.000") + "mm", new System.Drawing.Point(695 + 100 - minus, 330 + 75 - 10), FontFace.HersheyDuplex, 0.5, new Bgr(System.Drawing.Color.Lime).MCvScalar);



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

        private Mat BitmapToMat(Bitmap image)
        {
            int stride = 0;

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.BitmapData bmpData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, image.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = image.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = image.Width * 4;
            }
            else
            {
                stride = image.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(image.Width, image.Height, stride, (IntPtr)bmpData.Scan0);

            image.UnlockBits(bmpData);

            return cvImage.Mat;
        }

        // Converting EmguCV image to WPF image
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

        public GraphicalCode[] AnalyseImage(ref Image<Bgr, Byte> image)
        {
            IInputArray img1arr = image;
            QRCodeDetector detector = new QRCodeDetector();

            GraphicalCode[] graphicalCode = detector.DetectAndDecodeMulti(img1arr);

            if (graphicalCode.Length >= 1)
            {
                // Draw polylines
                CvInvoke.Line(image, ConvertPointFToPonint(graphicalCode[0].Points[0]), ConvertPointFToPonint(graphicalCode[0].Points[1]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
                CvInvoke.Line(image, ConvertPointFToPonint(graphicalCode[0].Points[1]), ConvertPointFToPonint(graphicalCode[0].Points[2]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
                CvInvoke.Line(image, ConvertPointFToPonint(graphicalCode[0].Points[2]), ConvertPointFToPonint(graphicalCode[0].Points[3]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);
                CvInvoke.Line(image, ConvertPointFToPonint(graphicalCode[0].Points[3]), ConvertPointFToPonint(graphicalCode[0].Points[0]), new Bgr(System.Drawing.Color.Lime).MCvScalar, 2);

                float graphicalCodeLength = graphicalCode[0].DecodedInfo.Length * 10.000f / 2.000f;
                float graphicalCodePosition = (graphicalCode[0].Points[0].X + graphicalCode[0].Points[1].X) / 2 - graphicalCodeLength;

                CvInvoke.PutText(image, graphicalCode[0].DecodedInfo, new System.Drawing.Point((int)graphicalCodePosition, (int)(graphicalCode[0].Points[3].Y + 50.000f)), FontFace.HersheySimplex, 1.0, new Bgr(System.Drawing.Color.Blue).MCvScalar, 2, LineType.EightConnected);
            }

            return graphicalCode;
        }

        public void AnalyseQrCode(string decodedInfo)
        {
            // Scan finish
            if (decodedInfo == "3ba23423-127e-4f7c-8da9-dacb2e3af25b")
            {
                Serilog.Log.Information("Scan Finised ...");

                _scanFinish = true;
            }

            // Ignore doublepage sensor
            else if (decodedInfo == "3ba24363-191e-4b7c-8f29-daab2e30855b")
            {
                Serilog.Log.Information("Ignore doublepage sensor ...");

                _ignoreDoublepageSensor = true;
            }

            // Prepared Page
            else if (decodedInfo == "3ba21353-121e-4f7c-8fa9-dacb2e35825b")
            {
                Serilog.Log.Information("Prepared page --> Ignore doublepage sensor (>1) ...");

                _preparedPage = true;
            }

            // Replace image
            else if (decodedInfo.Contains("3bc23125-141e-3f1c-8af1"))
            {
                Serilog.Log.Information("Replace image ...");

                _replacedPage = true;
            }
        }

        System.Drawing.Point ConvertPointFToPonint(System.Drawing.PointF value)
        {
            return new System.Drawing.Point((int)value.X, (int)value.Y);
        }
    }
}
