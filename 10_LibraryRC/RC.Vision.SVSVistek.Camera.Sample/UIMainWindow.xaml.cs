using Microsoft.EntityFrameworkCore;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using RC.Lib.Vision.SVSVistek;
using RC.Model;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.RichTextBox.Themes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace RC.Vision.SVSVistek.Sample
{
    /// <summary>
    /// Interaction logic for UIMainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : System.Windows.Window
    {
        #region Global variables
        private SVSVistek_Container? _svsVistek;

        private static readonly object _syncRoot = new object();
        #endregion

        public UIMainWindow()
        {
            InitializeComponent();

            Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Sink((ILogEventSink)Log.Logger)
                                //.WriteTo.Debug(outputTemplate: Globals.LokiOutputTemplate)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels, textFormatter: new ExpressionTemplate("{ {@t, @mt, @l:u3}, @i, @x, @p} }\n"))
                                .WriteTo.RichTextBox(rtbLogger, outputTemplate: Globals.LokiOutputTemplate, syncRoot: _syncRoot, theme: RichTextBoxConsoleTheme.Colored)
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();

            Log.Information("Start main window ...");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Inizialize variables ...
            _svsVistek = Globals.Device.Vision.SVSVistek;
            #endregion
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CamerasClose(null, null);
        }

        private void rtbLogger_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtbLogger.ScrollToEnd();
        }

        private void CamerasDiscovery(object sender, RoutedEventArgs e)
        {
            Log.Debug("Discover SVS-Vistek cameras ...");
            _svsVistek.DeviceDiscovery();

            if (_svsVistek.DeviceInfoList != null)
            {
                foreach (SVSVistek_DeviceInfo cam in _svsVistek.DeviceInfoList)
                {
                    Log.Debug("Camera Name:" + cam.DeviceInfo.displayName + " Model:" + cam.DeviceInfo.model + " Serialnumber:" + cam.DeviceInfo.serialNumber + " found.");
                }
            }
        }

        private void CamerasInizialisation(object sender, RoutedEventArgs e)
        {
            Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            if (_svsVistek.Cameras != null)
            {
                List<Device> devices = Globals.Context.Devices.Where(p => p.DeviceManufacturer == DeviceManufacturers.SVSVistek && p.DeviceType == DeviceTypes.Vision)
                                                                                .Include(p => p.Interfaces_Ethernet)
                                                                                .ToList();
                List<SVSVistek_DeviceInfo> deviceInfo = null;

                foreach (Device device in devices)
                {
                    try
                    {
                        deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.DeviceSerialnumber).ToList();

                        if (deviceInfo.Count == 1)
                        {
                            if (device.InitialzeAtSplashscreen)
                            {
                                Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
                                _svsVistek.Cameras.Add(new SVSVistek_Camera(deviceInfo[0]));

                                // Link Hardware with DbContext
                                _svsVistek.Cameras.Last().IdDb = device.Interfaces_Ethernet.Id;
                            }

                            if (device.ConnectAtSplashscreen)
                            {
                                List<SVSVistek_Camera> cam = _svsVistek.Cameras.Where(p => p.DeviceInfo.DeviceInfo.serialNumber == device.DeviceSerialnumber).ToList();

                                if (deviceInfo.Count == 1)
                                {
                                    Log.Debug($"Open connection for camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                    cam[0].OpenConnection();

                                    Thread.Sleep(125);

                                    Log.Debug($"Initialize camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                    SVSVistek_Camera_Config config = SVSVistek_Camera_Config.ToJson(device.DeviceConfiguration);

                                    // ToDO: cam.DeviceReset();
                                    //Thread.Sleep(5000);

                                    // ToDo: All settings from DB 
                                    cam[0].SetFan(config.DevieControl.FanControl);

                                    cam[0].SetSensorPixelSize(config.ImageFormatControl.SensorPixelSize);
                                    cam[0].SetPixelFormat(config.ImageFormatControl.PixelFormat);
                                    cam[0].SetOffsetX(config.ImageFormatControl.XOffset);
                                    cam[0].SetOffsetY(config.ImageFormatControl.YOffset);
                                    cam[0].SetWidth(config.ImageFormatControl.Width);
                                    cam[0].SetHeight(config.ImageFormatControl.Height);

                                    cam[0].SetExposureTime(config.AcquisitionControl.ExposureTime);

                                    cam[0].SetGain(config.AnalogControl.Gain);
                                    cam[0].SetWhiteBalance(config.AnalogControl.BalanceWhiteRatioRed, config.AnalogControl.BalanceWhiteRatioGreen, config.AnalogControl.BalanceWhiteRatioBlue);
                                }
                                else
                                {
                                    // ToDo: ...
                                }
                            }
                        }
                        else
                        {
                            // ToDo: ...
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                        break;
                    }
                }
            }
        }

        private void CamerasStartAcquision(object sender, RoutedEventArgs e)
        {
            Log.Debug("Start acquision for the cameras ...");

            if (_svsVistek.Cameras != null)
            {
                List<Device> devices = Globals.Context.Devices.Where(p => p.DeviceManufacturer == DeviceManufacturers.SVSVistek && p.DeviceType == DeviceTypes.Vision)
                                                                                .Include(p => p.Interfaces_Ethernet)
                                                                                .ToList();
                List<SVSVistek_DeviceInfo> deviceInfo = null;

                foreach (Device device in devices)
                {
                    try
                    {
                        deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.DeviceSerialnumber).ToList();

                        if (deviceInfo.Count == 1)
                        {
                            if (device.AutoStartAtSplashscreen)
                            {
                                List<SVSVistek_Camera> cam = _svsVistek.Cameras.Where(p => p.DeviceInfo.DeviceInfo.serialNumber == device.DeviceSerialnumber).ToList();

                                if (deviceInfo.Count == 1)
                                {
                                    Log.Debug($"Start camera acquision {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                    cam[0].StartAcquisionContinuously();

                                    Thread.Sleep(1250);
                                }
                                else
                                {
                                    // ToDo: ...
                                }
                            }
                        }
                        else
                        {
                            // ToDo: ...
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                        break;
                    }
                }
            }
        }

        private void CamerasClose(object sender, RoutedEventArgs e)
        {
            #region Close vison devices
            Log.Information("Vision: Close devices and clean up variabels ...");

            try
            {
                //cam.CloseCameraAll();

                if (_svsVistek.Cameras != null)
                {
                    for (int i = 0; i < _svsVistek.Cameras.Count; i++)
                    {
                        Serilog.Log.Debug($"Closing Cam {_svsVistek.Cameras[i].DeviceInfo.DeviceInfo.serialNumber}");

                        _svsVistek.Cameras[i].AcquisitionStop();
                        _svsVistek.Cameras[i].StreamingChannelClose();
                        _svsVistek.Cameras[i].closeConnection();

                        //_svsVistek.Cameras[i].Distroy();

                        //_svsVistek.Cameras.Remove(_svsVistek.Cameras[i]);

                        Thread.Sleep(125);
                    }

                    _svsVistek.Cameras.Clear();
                }

                _svsVistek = null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            #endregion
        }

        private void SavePicture(object sender, RoutedEventArgs e)
        {
            try
            {
                Stopwatch swProcessingTime = new Stopwatch();
                long oldTime = 0;

                Mat image = new Mat();
                Mat imageTmp = new Mat();
                List<Mat> images = new List<Mat>();

                long[] exposureTime = new long[] { 7500, 10000, 15000, 20000, 27500 };

                swProcessingTime.Start();
                oldTime = swProcessingTime.ElapsedMilliseconds;

                foreach (SVSVistek_Camera cam in _svsVistek.Cameras)
                {
                    cam.GrabImageHdrAsync(exposureTime);

                    Thread.Sleep(25);
                }

                while (_svsVistek.Cameras[0].IsGrabbingImage || _svsVistek.Cameras[1].IsGrabbingImage)
                {
                    Thread.Sleep(5);
                }

                #region Save images
                _svsVistek.Cameras[0].ImagesRgb[0].Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\SoftwareTest\\Image0.bmp", ImageFormat.Bmp);
                _svsVistek.Cameras[0].ImagesRgb[1].Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\SoftwareTest\\Image1.bmp", ImageFormat.Bmp);
                _svsVistek.Cameras[0].ImagesRgb[2].Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\SoftwareTest\\Image2.bmp", ImageFormat.Bmp);
                _svsVistek.Cameras[0].ImagesRgb[3].Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\SoftwareTest\\Image3.bmp", ImageFormat.Bmp);
                _svsVistek.Cameras[0].ImagesRgb[4].Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\SoftwareTest\\Image4.bmp", ImageFormat.Bmp);

                // ToDo: Save images to S3-DataRaw
                #endregion

                #region Create HDR image
                for (int i = 0; i < 5; i++)
                {
                    images.Add(BitmapConverter.ToMat(_svsVistek.Cameras[0].ImagesRgb[i]));
                    images[i] = images[i].CvtColor(ColorConversionCodes.RGBA2RGB);

                    //Cv2.ImShow($"Image {i}", images[i]);
                }

                MergeMertens mergeMertens = MergeMertens.Create();
                mergeMertens.Process(images, image);

                ImageEncodingParam imageEncodingParam = new ImageEncodingParam(ImwriteFlags.JpegQuality, 100);
                image.ConvertScaleAbs(255.0).SaveImage("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\SoftwareTest\\ImageHDR.jpeg", imageEncodingParam);
                image.ConvertScaleAbs(255.0).SaveImage("C:\\tmp\\ImageHDR.jpeg", imageEncodingParam);

                // ToDo: Save images to S3-Data

                // Create Thumbnail
                // ToDo: Save images to S3-Thumbnail
                #endregion

                #region Create Darktable image
                // Usage example:
                string inputFilePath = @"C:/tmp/ImageHDR.jpeg";
                string outputDirectory = @"C:/Users/msdit/Desktop/Aufnahmen/SVS_Vistek-Sample/SoftwareTest/NewFolder/";

                ExecuteDarktableCommand(inputFilePath, outputDirectory);

                // ToDo: Save images to S3-Data

                // Create Thumbnail
                // ToDo: Save images to S3-Thumbnail
                #endregion

                Log.Information($"Picture taking time : {swProcessingTime.ElapsedMilliseconds - oldTime}ms ...");
                swProcessingTime.Stop();
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
            }
        }

        private void TakePicture1(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = 0;
                foreach (SVSVistek_Camera cam in _svsVistek.Cameras)
                {
                    Log.Debug("Take Picture - Cam " + index);
                    //Bitmap img = cam.Control.GetPicture();
                    index++;
                }

            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
            }
        }

        private void SetValues(object sender, RoutedEventArgs e)
        {

        }

        private void GetValues(object sender, RoutedEventArgs e)
        {

        }

        private void SetUiValuesCam1()
        {
            //if (_deviceInfoList == null || !_camera1.CurrentCamera.is_opened)
            //{
            //    return;
            //}

            //DeviceVendorName.Text = _camera1.GetVendorName();
            //DeviceModelName.Text = _camera1.GetDeviceModelName();
            //DeviceManufacturerInfo.Text = _camera1.GetDeviceManufacturerInfo();
            //DeviceVersion.Text = _camera1.GetDeviceVersion();
            //DeviceFirmwareVersion.Text = _camera1.GetDeviceFirmwareVersion();
            //DeviceSerialNumber.Text = _camera1.GetDeviceSerialNumber();
            //DeviceUserID.Text = _camera1.GetDeviceUserID();
            //DeviceTemperature.Text = _camera1.GetDeviceTemperature().ToString();
            //SensorWidth.Text = _camera1.GetSensorWidth().ToString();
            //SensorHeight.Text = _camera1.GetSensorHeight().ToString();
            //OffsetX.Text = _camera1.GetOffsetX().ToString();
            //OffsetY.Text = _camera1.GetOffsetY().ToString();
            //Width.Text = _camera1.GetWidth().ToString();
            //Height.Text = _camera1.GetHeight().ToString();
            //MaxWidth.Text = _camera1.GetMaxWidth().ToString();
            //MaxHeight.Text = _camera1.GetMaxHeight().ToString();
            //SensorPixelSize.SelectedValue = _camera1.GetSensorPixelSize().ToString();
            //PixelSize.Text = _camera1.GetPixelSize().ToString();
            //PixelFormat.SelectedValue = _camera1.GetPixelFormat().ToString();
            //PixelDynamicRangeMin.Text = _camera1.GetPixelDynamicRangeMin().ToString();
            //PixelDynamicRangeMax.Text = _camera1.GetPixelDynamicRangeMax().ToString();
            //BinningHorizontal.Text = _camera1.GetBinningHorizontal().ToString();
            //BinningVertical.Text = _camera1.GetBinningVertical().ToString();
            //ReverseX.IsChecked = _camera1.GetReverseX();
        }




        public void ExecuteDarktableCommand(string inputFilePath, string outputDirectory)
        {
            string darktablePath = @"C:\Program Files\darktable\bin\darktable-cli.exe";
            string arguments = $"\"{inputFilePath}\" \"C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\cam1.xmp\" \"{outputDirectory}\" --verbose --out-ext jpg";
            //./darktable-cli.exe "C:/Users/msdit/Desktop/Aufnahmen/SVS_Vistek-Sample/SoftwareTest/ImageHDR.jpeg" "C:/Users/msdit/Desktop/Aufnahmen/SVS_Vistek-Sample/cam1.xmp" "C:/Users/msdit/Desktop/Aufnahmen/SVS_Vistek-Sample/SoftwareTest/NewFolder" --verbose --out-ext jpg


            Process process = new Process();
            process.StartInfo.FileName = darktablePath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                string outputFilePath = outputDirectory + "ImageDarktable";
                //string outputFilePath = Path.Combine(outputDirectory, Path.GetFileName(inputFilePath));
                //File.Copy(inputFilePath, outputFilePath, true);
                //Console.WriteLine("File copied to: " + outputFilePath);
            }
            else
            {
                Console.WriteLine("Darktable command execution failed.");
            }
        }
    }
}
