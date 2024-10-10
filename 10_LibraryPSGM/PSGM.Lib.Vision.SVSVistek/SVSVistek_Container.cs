using Serilog;

namespace PSGM.Lib.Vision.SVSVistek
{
    public partial class SVSVistek_Container
    {
        #region Global variables
        // Device
        private bool _initSdkDone;

        private SVSVistek_Api _svsVistekApi;

        private List<SVSVistek_Camera> _cameras;
        public List<SVSVistek_Camera> Cameras { get { return _cameras; } set { _cameras = value; } }

        public List<SVSVistek_DeviceInfo> _deviceInfoList;
        public List<SVSVistek_DeviceInfo> DeviceInfoList { get { return _deviceInfoList; } set { _deviceInfoList = value; } }

        // Threading
        private bool _threadTerminate;
        private bool _threadDisplayIsRuning;
        private bool _threadAcquisionIsRuning;
        private bool _threadTakePicture;   

        // Original
        //delegate void SetStatusCallBack();
        //delegate void SetdisplayCallBack();
        //delegate void treeUpdateCallBack();
        //treeUpdateCallBack treeUpdate = null;
        //private static EventWaitHandle grab_image_is_done = new EventWaitHandle(true, EventResetMode.AutoReset);
        //private static EventWaitHandle display_is_done = new EventWaitHandle(true, EventResetMode.AutoReset);
        //public Bitmap[] display_img_rgb = new Bitmap[4];
        //public Bitmap[] display_img_mono = new Bitmap[4];
        //private Graphics gpanel;
        //private Rectangle outRectangle;
        //private bool newsize = false;
        //Bitmap resized = null;
        #endregion

        public SVSVistek_Container()
        {
            Log.Information("Initialize SVSVistek class ...");

            _cameras = new List<SVSVistek_Camera>();
            _svsVistekApi = new SVSVistek_Api();
            _deviceInfoList = new List<SVSVistek_DeviceInfo>();

            _initSdkDone = false;

            _threadTerminate = false;
            _threadDisplayIsRuning = false;
            _threadAcquisionIsRuning = false;

            _threadTakePicture = false;
        }

        ~SVSVistek_Container()
        {
            CloseCameraAll();

            _cameras.Clear();
            _deviceInfoList.Clear();

            _initSdkDone = false;

            _threadTerminate = false;
            _threadDisplayIsRuning = false;
            _threadAcquisionIsRuning = false;

            _threadTakePicture = false;
        }

        //public void startAcquisitionThread()
        //{
        //    _acqThread = null;
        //    _acqThreadIsRuning = true;
        //    _acqThread = new Thread(() => acqThread());
        //    _acqThread.Start();
        //}

        //public void acqThread()
        //{
        //    while (_acqThreadIsRuning)
        //    {
        //        if (_terminate)
        //            break;
        //        if (!CurrentCamera.Grab())
        //        {
        //            continue;
        //        }

        //        if (!display_is_done.WaitOne(10))
        //        {
        //            continue;
        //        }

        //        // Check if a RGB image( Bayer buffer format) arrived
        //        bool isImgRGB = false;
        //        int pDestLength = (int)(CurrentCamera.bufferInfoDest.iImageSize);
        //        int sizeX = (int)CurrentCamera.bufferInfoDest.iSizeX;
        //        int sizeY = (int)CurrentCamera.bufferInfoDest.iSizeY;
        //        CurrentID = Convert.ToString(CurrentCamera.bufferInfoDest.iImageId);

        //        if (((int)CurrentCamera.bufferInfoDest.iPixelType & SVSVistek_Api.DefineConstants.SV_GVSP_PIX_ID_MASK) >= 8)
        //        {
        //            isImgRGB = true;
        //            pDestLength = 3 * pDestLength;
        //        }

        //        initializeBuffer(isImgRGB, sizeX, sizeY);
        //        CurrentCamera.AddnewImageData(CurrentCamera.bufferInfoDest, isImgRGB);
        //        CurrentCamera.isrgb = isImgRGB;
        //        grab_image_is_done.Set();
        //    }
        //}

        //public void startdisplayThread()
        //{
        //    _dispThreadIsRuning = true;
        //    //_dispThread = new Thread(new ThreadStart(_dispThread));
        //    _dispThread = new Thread(() => dispThread());
        //    _dispThread.Start();
        //}

        //public void dispThread()
        //{
        //    while (_dispThreadIsRuning)
        //    {
        //        if (_terminate)
        //        {
        //            break;
        //        }
        //        setToDisplay();
        //        WaitHandle.SignalAndWait(display_is_done, grab_image_is_done);
        //    }
        //}

        //private void setToDisplay()
        //{
        //    if (!_acqThreadIsRuning)
        //    {
        //        return;
        //    }

        //    int currentIndex = CurrentCamera.destdataIndex;
        //    if (CurrentCamera.isrgb)
        //    {
        //        if (display_img_rgb[currentIndex] != null)
        //        {
        //            Stopwatch swProcessingTime = new Stopwatch();

        //            swProcessingTime.Reset();

        //            double dbl = display_img_rgb[currentIndex].Width / (double)display_img_rgb[currentIndex].Height;
        //            if (dbl < display_img_rgb[currentIndex].Width)
        //            {
        //                if ((int)((double)display_img_rgb[currentIndex].Height * dbl) <= display_img_rgb[currentIndex].Width)
        //                {
        //                    outRectangle.Width = (int)((double)display_img_rgb[currentIndex].Height * dbl);
        //                    outRectangle.Height = display_img_rgb[currentIndex].Height;

        //                    if (_takePicture)
        //                    {
        //                        resized = new Bitmap(display_img_rgb[currentIndex], (int)((double)display_img_rgb[currentIndex].Height * dbl), display_img_rgb[currentIndex].Height);
        //                        resized.Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff") + ".bmp", ImageFormat.MemoryBmp);

        //                        _takePicture = false;
        //                    }
        //                }
        //                else
        //                {
        //                    outRectangle.Width = display_img_rgb[currentIndex].Width;
        //                    outRectangle.Height = (int)((double)display_img_rgb[currentIndex].Width / dbl);

        //                    if (_takePicture)
        //                    {
        //                        resized = new Bitmap(display_img_rgb[currentIndex], display_img_rgb[currentIndex].Width, (int)((double)display_img_rgb[currentIndex].Width / dbl));
        //                        resized.Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff") + "bmp", ImageFormat.MemoryBmp);

        //                        _takePicture = false;
        //                    }
        //                }
        //            }

        //            swProcessingTime.Stop();
        //             Log.Debug($"Execution Time Camera {CurrentCamera.devInfo.serialNumber} : {_swProcessingTime.ElapsedMilliseconds - _oldTime}ms ...");
        //            _oldTime = _swProcessingTime.ElapsedMilliseconds;
        //        }
        //    }
        //    else
        //    {
        //        if (display_img_mono[currentIndex] != null)
        //        {
        //            Stopwatch swProcessingTime = new Stopwatch();

        //            swProcessingTime.Reset();

        //            //Bitmap resized = null;
        //            double dbl = display_img_mono[currentIndex].Width / (double)display_img_mono[currentIndex].Height;
        //            System.Drawing.Imaging.ColorPalette imgpal = display_img_mono[currentIndex].Palette;

        //            // Build bitmap palette Y8
        //            for (uint i = 0; i < 256; i++)
        //            {
        //                imgpal.Entries[i] = Color.FromArgb(0xFF, (byte)i, (byte)i, (byte)i);
        //            }

        //            display_img_mono[currentIndex].Palette = imgpal;
        //            //imgpal = display_img_mono[currentIndex].Palette;
        //            // gpanel.DrawImage(display_img_mono[currentIndex], outRectangle);
        //            if (_takePicture)
        //            {
        //                resized = new Bitmap(display_img_mono[currentIndex], display_img_mono[currentIndex].Width, (int)((double)display_img_mono[currentIndex].Width / dbl));
        //                resized.Save("C:\\Users\\msdit\\Desktop\\Aufnahmen\\SVS_Vistek-Sample\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff") + ".bmp", ImageFormat.MemoryBmp);

        //                _takePicture = false;
        //            }

        //            swProcessingTime.Stop();
        //             Log.Debug($"Execution Time Camera {CurrentCamera.devInfo.serialNumber} : {_swProcessingTime.ElapsedMilliseconds - _oldTime}ms ...");
        //            _oldTime = _swProcessingTime.ElapsedMilliseconds;
        //        }
        //    }

        //    CurrentCamera.destdataIndex++;
        //    if (CurrentCamera.destdataIndex == 4)
        //    {
        //        CurrentCamera.destdataIndex = 0;
        //    }
        //}

        //private void initializeBuffer(bool rgb, int camWidth, int camHeight)
        //{
        //    newsize = false;
        //    int k;

        //    if (CurrentCamera == null)
        //    {
        //        return;
        //    }

        //    if (rgb)
        //    {
        //        if (CurrentCamera.imagebufferRGB[0].dataLegth != 3 * camWidth * camHeight)
        //        {
        //            newsize = true;
        //        }

        //        for (k = 0; k < 4; k++)
        //        {
        //            unsafe
        //            {
        //                if (newsize)
        //                {
        //                    CurrentCamera.imagebufferRGB[k].imagebytes = new byte[3 * camWidth * camHeight];
        //                    //CurrentCamera.imagebufferRGB[k].imagebytes = new ushort[3 * camWidth * camHeight];
        //                }

        //                fixed (byte* ColorPtr = CurrentCamera.imagebufferRGB[k].imagebytes)
        //                //fixed (ushort* ColorPtr = CurrentCamera.imagebufferRGB[k].imagebytes)
        //                {
        //                    if (newsize)
        //                    {
        //                        display_img_rgb[k] = new Bitmap(camWidth, camHeight, (3 * camWidth), System.Drawing.Imaging.PixelFormat.Format24bppRgb, (IntPtr)ColorPtr);
        //                        //display_img_rgb[k] = new Bitmap(camWidth, camHeight, (3 * camWidth), System.Drawing.Imaging.PixelFormat.Format48bppRgb, (IntPtr)ColorPtr);
        //                    }

        //                    CurrentCamera.imagebufferRGB[k].sizeX = camWidth;
        //                    CurrentCamera.imagebufferRGB[k].sizeY = camHeight;
        //                    CurrentCamera.imagebufferRGB[k].dataLegth = 3 * camWidth * camHeight;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (CurrentCamera.imagebufferMono[0].dataLegth != camWidth * camHeight)
        //        {
        //            newsize = true;
        //        }

        //        for (k = 0; k < 4; k++)
        //        {
        //            unsafe
        //            {
        //                if (newsize)
        //                {
        //                    CurrentCamera.imagebufferMono[k].imagebytes = new byte[camWidth * camHeight];
        //                }

        //                fixed (byte* MonoPtr = CurrentCamera.imagebufferMono[k].imagebytes)
        //                {
        //                    if (newsize)
        //                    {
        //                        display_img_mono[k] = new Bitmap(camWidth, camHeight, camWidth, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, (IntPtr)MonoPtr);
        //                    }

        //                    CurrentCamera.imagebufferMono[k].sizeX = camWidth;
        //                    CurrentCamera.imagebufferMono[k].sizeY = camHeight;
        //                    CurrentCamera.imagebufferMono[k].dataLegth = camWidth * camHeight;
        //                }
        //            }
        //        }
        //    }
        //}













        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool InitSDK()
        {
            if (_initSdkDone)
            {
                return true;
            }

            string SVGenicamGentl = null;
            string SVGenicamRoot = null;
            string SVGenicamCache = null;
            string SVCLProtocol = null;
            bool is64Env = IntPtr.Size == 8;

            // Check whether the environment variable exists.
            SVGenicamRoot = Environment.GetEnvironmentVariable("SVS_GENICAM_ROOT");
            if (SVGenicamRoot == null)
            {
                Log.Debug("GetEnvironmentVariableA SVS_GENICAM_ROOT failed! ");
                return false;
            }

            if (is64Env)
            {
                SVGenicamGentl = Environment.GetEnvironmentVariable("GENICAM_GENTL64_PATH");
                if (SVGenicamGentl == null)
                {
                    Log.Debug("GetEnvironmentVariableA GENICAM_GENTL64_PATH failed! ");
                    return false;
                }
            }
            else
            {
                SVGenicamGentl = Environment.GetEnvironmentVariable("GENICAM_GENTL32_PATH");
                if (SVGenicamGentl == null)
                {
                    Log.Debug("GetEnvironmentVariableA GENICAM_GENTL32_PATH failed! ");
                    return false;
                }
            }

            SVCLProtocol = Environment.GetEnvironmentVariable("SVS_GENICAM_CLPROTOCOL");
            if (SVCLProtocol == null)
            {
                Log.Debug("GetEnvironmentVariableA SVS_GENICAM_CLPROTOCOL failed! ");
                return false;
            }

            SVGenicamCache = Environment.GetEnvironmentVariable("SVS_GENICAM_CACHE");
            if (SVGenicamCache == null)
            {
                Log.Debug("GetEnvironmentVariableA SVS_GENICAM_CACHE failed! ");
                return false;
            }

            SVSVistek_Api.SVSVistekApiReturn ret = _svsVistekApi.SVS_LibInit(SVGenicamGentl, SVGenicamRoot, SVGenicamCache, SVCLProtocol);

            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                Log.Debug("SVS_LibInit failed! ");
                return false;
            }

            _initSdkDone = true;

            return true;
        }

        /// <summary>
        /// Create a list of SVS Vistek Camera devices
        /// </summary>
        /// <param name="timeout">Timeout (default: 1000ms)</param>>
        /// <returns>Device info list</returns>
        //public List<SVSVistek_Api._SV_DEVICE_INFO>? DeviceDiscovery(uint timeout = 1000)        
        public List<SVSVistek_DeviceInfo>? DeviceDiscovery(uint timeout = 1000)
        {
            Log.Verbose("Start Device Discovery ...");

            if (_cameras.Count() == 0)
            {
                DeviceDiscoveryUpdateLists(timeout);
            }
            else
            {
                Log.Error("No devices are discover due to that de device lsit is not empty!");
            }

            return _deviceInfoList;
        }

        /// <summary>
        /// Update Device Lists of SVS Vistek Cameras
        /// </summary>
        /// <param name="timeout">Timeout (default: 1000ms)</param>
        private void DeviceDiscoveryUpdateLists(uint timeout = 1000)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;

            // Open the System module
            uint tlCount = 0;
            ret = _svsVistekApi.SVS_LibSystemGetCount(ref tlCount);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                Log.Error("Erro while device discovery!");
                return;
            }

            bool bChanged = false;
            uint numInterface = 0;

            // Initialize device and get transport layer info
            for (uint i = 0; i < tlCount; i++)
            {
                SVSVistek_Api._SV_TL_INFO pInfoOut = new SVSVistek_Api._SV_TL_INFO();

                ret = _svsVistekApi.SVS_LibSystemGetInfo(i, ref pInfoOut);
                if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                {
                    continue;
                }

                string str = pInfoOut.tlType;
                if (0 != string.Compare("CL", str))
                {
                    IntPtr sv_cam_sys_hdl = new IntPtr();
                    ret = _svsVistekApi.SVS_LibSystemOpen(i, ref sv_cam_sys_hdl);

                    _svsVistekApi.SVS_SystemUpdateInterfaceList(sv_cam_sys_hdl, ref bChanged, timeout);

                    ret = _svsVistekApi.SVS_SystemGetNumInterfaces(sv_cam_sys_hdl, ref numInterface);
                    for (uint j = 0; j < numInterface; j++)
                    {
                        string interfaceId = string.Empty;
                        uint interfaceIdSize = 512;

                        // Queries the ID of the interface at iIndex in the internal interface list
                        ret = _svsVistekApi.SVS_SystemGetInterfaceId(sv_cam_sys_hdl, j, ref interfaceId, ref interfaceIdSize);

                        if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                        {
                            continue;
                        }

                        // Queries the information about the interface on this Info module
                        SVSVistek_Api._SV_INTERFACE_INFO interfaceInfo = new SVSVistek_Api._SV_INTERFACE_INFO();
                        ret = _svsVistekApi.SVS_SystemInterfaceGetInfo(sv_cam_sys_hdl, interfaceId, ref interfaceInfo);
                        if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                        {
                            continue;
                        }

                        // Queries the information about the interface on this System module
                        IntPtr hInterface = IntPtr.Zero;
                        ret = _svsVistekApi.SVS_SystemInterfaceOpen(sv_cam_sys_hdl, interfaceId, ref hInterface);
                        if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                        {
                            continue;
                        }

                        // Updates the internal list of available devices on this interface
                        ret = _svsVistekApi.SVS_InterfaceUpdateDeviceList(hInterface, ref bChanged, timeout);
                        if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                        {
                            continue;
                        }

                        // Queries the number of available devices on this interface
                        uint numDevices = 0;
                        ret = _svsVistekApi.SVS_InterfaceGetNumDevices(hInterface, ref numDevices);
                        if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                        {
                            continue;
                        }

                        // Get device info for all available devices and add new device to the camera list
                        for (uint k = 0; k < numDevices; k++)
                        {
                            string deviceId = null;
                            uint deviceIdSize = 512;

                            ret = _svsVistekApi.SVS_InterfaceGetDeviceId(hInterface, k, ref deviceId, ref deviceIdSize);
                            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                            {
                                continue;
                            }

                            SVSVistek_Api._SV_DEVICE_INFO devInfo = new SVSVistek_Api._SV_DEVICE_INFO();
                            ret = _svsVistekApi.SVS_InterfaceDeviceGetInfo(hInterface, deviceId, ref devInfo);

                            Log.Verbose("Camera Name:" + devInfo.displayName + " Model:" + devInfo.model + " Serialnumber:" + devInfo.serialNumber + " found and added to device list ...");
                            _deviceInfoList.Add(new SVSVistek_DeviceInfo()
                            {
                                CameraSystemHardware = sv_cam_sys_hdl,
                                InterfaceInfo = interfaceInfo,
                                InterfaceHardware = hInterface,
                                DeviceInfo = devInfo
                            });
                        }
                    }
                }
            }
        }













        ///// <summary>
        ///// Stop acquisition of current camera
        ///// </summary>
        ///// <returns></returns>
        //public bool StopCamera()
        //{
        //    try
        //    {
        //        _terminate = true;
        //         Log.Debug("Stopping - " + CurrentCamera.devInfo.serialNumber);
        //        CurrentCamera.AcquisitionStop();
        //        CurrentCamera.StreamingChannelClose();
        //        // CurrentCamera.closeConnection();

        //        _acqThreadIsRuning = false;
        //        _dispThreadIsRuning = false;
        //        _takePicture = false;

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
        /// Close connection to all cameras
        /// </summary>
        /// <returns></returns>
        public bool CloseCameraAll()
        {
            try
            {
                _threadTerminate = true;
                if (_cameras != null)
                {
                    foreach (var cam in _cameras)
                    {
                        Log.Debug("Stopping - " + cam.DeviceInfo.DeviceInfo.serialNumber);
                        cam.AcquisitionStop();
                        cam.StreamingChannelClose();
                        cam.closeConnection();
                    }
                }

                _threadAcquisionIsRuning = false;
                _threadDisplayIsRuning = false;
                _threadTakePicture = false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        ///// <summary>
        ///// Open connection to specified camera
        ///// </summary>
        ///// <returns></returns>
        //public void OpenConnection(string serialNumber)
        //{
        //    int index = -1;

        //    // No serial number was passed
        //    if (string.IsNullOrEmpty(serialNumber))
        //    {
        //        MessageBox.Show("Can't open connecten to the camera acquision, because no serialnumber was given!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.No);
        //        return;
        //    }

        //    // Open connection of the camera
        //    for (int i = 0; i < _cameras.Count(); i++)
        //    {
        //        if (_cameras[i].devInfo.serialNumber.CompareTo(serialNumber) == 0)
        //        {
        //            index = i;

        //            CurrentCamera = _cameras[i];
        //            if (!CurrentCamera.is_opened)
        //            {
        //                CurrentCamera.openConnection();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Connection to the camera is already opened!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.No);
        //                return;
        //            }
        //        }
        //    }

        //    // No camera was found
        //    if (index == -1)
        //    {
        //        MessageBox.Show("No camera with the given serial found!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.No);
        //        return;
        //    }
        //}

        ///// <summary>
        ///// Start continuously acquision of the specified camera
        ///// </summary>
        ///// <param name="serialNumber">Serialnumber of the camera</param>
        //public void StartAcquisionContinuously()
        //{
        //    _terminate = false;

        //    // Open streaming channel for the camera
        //    CurrentCamera.StreamingChannelOpen();

        //    // Initialize pointers for the camera
        //    if (CurrentCamera.bufferInfoDest.pImagePtr != IntPtr.Zero)
        //    {
        //        Marshal.FreeHGlobal(CurrentCamera.bufferInfoDest.pImagePtr);
        //        CurrentCamera.bufferInfoDest.pImagePtr = IntPtr.Zero;
        //    }
        //    if (CurrentCamera.bufferInfoDest.pImagePtr != IntPtr.Zero)
        //    {
        //        Marshal.FreeHGlobal(CurrentCamera.bufferInfoDest.pImagePtr);
        //        CurrentCamera.bufferInfoDest.pImagePtr = IntPtr.Zero;
        //    }

        //    // Start acquision for the camera
        //    CurrentCamera.AcquisitionStart(1);

        //    // Start aquision thread for the camera
        //    if (!_acqThreadIsRuning)
        //        startAcquisitionThread();

        //    // Start display thread for the camera
        //    if (!_dispThreadIsRuning)
        //        startdisplayThread();
        //}

        //public void TakePicture()
        //{
        //    if (!_terminate)
        //    {
        //        _takePicture = true;
        //    }
        //}

        //public Bitmap GetPicture()
        //{
        //    if (resized != null)
        //    {
        //        return resized;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
