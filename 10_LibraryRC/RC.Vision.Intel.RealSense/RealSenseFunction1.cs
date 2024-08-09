using Intel.RealSense;
using System.Diagnostics;
using System.Windows.Threading;

namespace RC.Vision.Intel.RealSense
{
    public partial class RealSense
    {
        public void Function1Start()
        {
            Task.Factory.StartNew(() =>
            {
                //ushort[] depthImage = new ushort[_depthProfile.Width * _depthProfile.Height];

                while (!_ctPipeline.Token.IsCancellationRequested)
                {
                    #region You must use using when displaying the frame, otherwise it will prompt that Frame didn't arrived within 5000, and the Frame was not released correctly by .net.
                    using (var frames = _pipeline.WaitForFrames())
                    {
                        _swProcessingTime.Start();

                        VideoFrame colorFrame = frames.ColorFrame.DisposeWith(frames);
                        VideoFrame depthFrame = frames.DepthFrame.DisposeWith(frames);

                        #region Rendering frames
                        if (_updateColor != null)
                        {
                            // Render the frames
                            _dispatcher.Invoke(DispatcherPriority.Render, _updateColor, colorFrame);
                        }

                        if (_updateDepth != null)
                        {
                            // Render the frames
                            _dispatcher.Invoke(DispatcherPriority.Render, _updateDepth, depthFrame);
                        }

                        if (_updateDepthColorized != null)
                        {
                            // We colorize the depth frame for visualization purposes
                            VideoFrame colorizedDepth = _colorizer.Process<VideoFrame>(depthFrame).DisposeWith(frames);

                            // Render the frames
                            if (_updateDepthColorized != null)
                            {
                                _dispatcher.Invoke(DispatcherPriority.Render, _updateDepthColorized, colorizedDepth);
                            }

                        }
                        #endregion



                        // Depth sensor data to array
                        //depthFrame.As<VideoFrame>().CopyTo(depthImage);


                        ;





                        // We colorize the depth frame for visualization purposes
                        //VideoFrame colorizedDepthFrame = _colorizer.Process<VideoFrame>(depthFrame).DisposeWith(frames);
                        //VideoFrame colorizedDepthFrame2 = depthFrame.ApplyFilter(_colorizer).As<VideoFrame>().DisposeWith(frames);



                        // Format24bppRgb color difference (specified format is 24 bits per pixel; red, green and blue components use 8 bits each. Related to cfg.EnableStream(Format.Rgb8))
                        //Bitmap newBitmapColor = new Bitmap(colorFrame.Width, colorFrame.Height, colorFrame.Stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, colorFrame.Data);
                        //Bitmap bitmapColor = new Bitmap(newBitmapColor);
                        //newBitmapColor.Dispose();
                        //Console.WriteLine("s: {0}", colorFrame.Number);

                        // Format24bppRgb color difference (specified format is 24 bits per pixel; red, green and blue components use 8 bits each. Related to cfg.EnableStream(Format.Rgb8))
                        //Bitmap newBitmapDepth = new Bitmap(depthFrame.Width, depthFrame.Height, depthFrame.Stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, depthFrame.Data);
                        //Bitmap bitmapDepth = new Bitmap(newBitmapDepth);
                        //newBitmapDepth.Dispose();
                        //Console.WriteLine("s: {0}", depthFrame.Number);

                        //Dispatcher.CurrentDispatcher.Invoke(new SetRealSenceVedio(SetRealSenceValueColor), bitmapColor);
                        //Dispatcher.CurrentDispatcher.Invoke(new SetRealSenceVedio(SetRealSenceValueDepth), bitmapDepth);




                        //var rect1 = new Int32Rect(0, 0, colorFrame.Width, colorFrame.Height);
                        //WriteableBitmap temp1 = new WriteableBitmap(colorFrame.Width, colorFrame.Height, 96d, 96d, PixelFormats.Rgb24, null);
                        //temp1.WritePixels(rect1, colorFrame.Data, colorFrame.Stride * colorFrame.Height, colorFrame.Stride);

                        //var rect2 = new Int32Rect(0, 0, colorizedDepthFrame.Width, colorizedDepthFrame.Height);
                        //WriteableBitmap temp2 = new WriteableBitmap(colorizedDepthFrame.Width, colorizedDepthFrame.Height, 96d, 96d, PixelFormats.Rgb24, null);
                        //temp2.WritePixels(rect2, colorizedDepthFrame.Data, colorizedDepthFrame.Stride * colorizedDepthFrame.Height, colorizedDepthFrame.Stride);

                        //Dispatcher.CurrentDispatcher.Invoke(new SetRealSenceVedio(SetRealSenceValueColor), BitmapFromWriteableBitmap(temp1));
                        //Dispatcher.CurrentDispatcher.Invoke(new SetRealSenceVedio(SetRealSenceValueDepth), BitmapFromWriteableBitmap(temp2));

                        //var depth = frames.First(x => x.Profile.Stream == Stream.Depth) as DepthFrame;
                        //var depth = frames.DepthFrame.DisposeWith(frames) as DepthFrame;

                        //Debug.WriteLine("The camera is pointing at an object " + depth.GetDistance(depth.Width / 2, depth.Height / 2) + " meters away\t");
                        //textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = "The camera is pointing at an object " + depth.GetDistance(depth.Width / 2, depth.Height / 2) + " meters away"; });

                        //depth.g



                        //            ///*
                        //            //float[] values = new float[depth.Width];

                        //            //int testt = int.Parse(textBox6.Text);

                        //            //for (int i = 0; i < depth.Width; i++)
                        //            //{
                        //            //    values[i] = depth.GetDistance(i, testt);
                        //            //}

                        //            //MakeGraph(values);




                        //            //int one_meter = (int)(1f / depthSensor.DepthScale);

                        //            //ushort[] depthh = new ushort[depth.Width * depth.Height];
                        //            //double[] depthhh = new double[depth.Width * depth.Height];

                        //            //depth.CopyTo(depthh);

                        //            //for (int i = 0; i < depth.Width * depth.Height; i++)
                        //            //{
                        //            //    depthhh[i] = ((double)depthh[i] / (double)one_meter) * 1000f;
                        //            //}
                        //            //*/


                        //            //////auto from_pixel = s.ruler_start.get_pixel(depth);
                        //            //////auto to_pixel = s.ruler_end.get_pixel(depth);

                        //            ////float[] upixel = new float[2]; // From pixel
                        //            ////float[] upoint = new float[3]; // From point (in 3D)

                        //            ////float[] vpixel = new float[2]; // To pixel
                        //            ////float[] vpoint = new float[3]; // To point (in 3D)

                        //            ////// Copy pixels into the arrays (to match rsutil signatures)
                        //            ////upixel[0] = static_cast<float>(u.first);
                        //            ////upixel[1] = static_cast<float>(u.second);
                        //            ////vpixel[0] = static_cast<float>(v.first);
                        //            ////vpixel[1] = static_cast<float>(v.second);

                        //            ////// Query the frame for distance
                        //            ////// Note: this can be optimized
                        //            ////// It is not recommended to issue an API call for each pixel
                        //            ////// (since the compiler can't inline these)
                        //            ////// However, in this example it is not one of the bottlenecks
                        //            //////auto udist = frame.get_distance(static_cast<int>(upixel[0]), static_cast<int>(upixel[1]));
                        //            //////auto vdist = frame.get_distance(static_cast<int>(vpixel[0]), static_cast<int>(vpixel[1]));

                        //            //// Deproject from pixel to point in 3D
                        //            //Intrinsics intr = frames.GetProfile<VideoStreamProfile>().GetIntrinsics();
                        //            ////Intel.RealSense.dep
                        //            ////rs2_deproject_pixel_to_point(upoint, &intr, upixel, udist);
                        //            ////rs2_deproject_pixel_to_point(vpoint, &intr, vpixel, vdist);

                        //            //// Calculate euclidean distance between the two points
                        //            ////float distance = sqrt(pow(upoint[0] - vpoint[0], 2.f) + pow(upoint[1] - vpoint[1], 2.f) + pow(upoint[2] - vpoint[2], 2.f));


                        //            ////Vector2D vector2 = new Vector2D();
                        //            ////Vector3D vector31 = new Vector3D();
                        //            ////Vector3D vector32 = new Vector3D();

                        //            ////vector2 = Map3DTo2D(intr, vector3);

                        //            ///*
                        //            //vector2.X = float.Parse(textBox2.Text);
                        //            //vector2.Y = 350.0f;

                        //            //vector31 = CoordinateMapper.Map2DTo3D(intr, vector2, depth.GetDistance((int)vector2.X, (int)vector2.Y));

                        //            //vector2.X = float.Parse(textBox4.Text);
                        //            //vector2.Y = 350.0f;

                        //            //vector32 = CoordinateMapper.Map2DTo3D(intr, vector2, depth.GetDistance((int)vector2.X, (int)vector2.Y));


                        //            //float x1 = Math.Abs(vector31.X) + Math.Abs(vector32.X);
                        //            //float y1 = Math.Abs(vector31.Y) + Math.Abs(vector32.Y);

                        //            //float distance1 = (float)Math.Sqrt(Math.Pow((double)(vector31.X - vector32.X), 2) + Math.Pow((double)(vector31.Y - vector32.Y), 2) + Math.Pow((double)(vector31.Z - vector32.Z), 2));
                        //            //float distance2 = (float)Math.Sqrt(Math.Pow((double)(vector31.X - vector32.X), 2));

                        //            //textBox5.Invoke((MethodInvoker)delegate { textBox5.Text = (distance1 * 100).ToString("0.00") + " cm"; });
                        //            //textBox3.Invoke((MethodInvoker)delegate { textBox3.Text = (distance2 * 100).ToString("0.00") + " cm"; });
                        //            //*/




                        ;



                        _swProcessingTime.Stop();
                        Debug.WriteLine($"Execution Time: {_swProcessingTime.ElapsedMilliseconds}ms");

                        _swProcessingTime.Reset();
                    }
                    #endregion
                }
                _pipeline.Stop();
            }, _ctPipeline.Token);
        }




    }
}