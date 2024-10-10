using Serilog;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PSGM.Lib.Vision.SVSVistek
{
    public class NativeMethods
    {
        //[DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        [DllImport("kernel32.dll", EntryPoint = "RtlCopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    }

    public struct ImagebufferStruct
    {
        public byte[] imagebytes;

        public int sizeX;
        public int sizeY;

        public int dataLegth;
    };

    public struct ImagebufferStructUshort
    {
        public ushort[] imagebytes;

        public int sizeX;
        public int sizeY;

        public int dataLegth;
    };

    public partial class SVSVistek_Camera
    {
        #region Global variables
        // DB link
        private Guid _idDb = Guid.Empty;
        public Guid IdDb { get { return _idDb; } set { _idDb = value; } }

        private SVSVistek_Camera_Config _config;
        public SVSVistek_Camera_Config Config { get { return _config; } set { _config = value; } }

        // Image 
        public bool _isRgb;
        public bool IsRgb { get { return _isRgb; } }

        public int _imageSizeX;
        public int ImageSizeX { get { return _imageSizeX; } }

        public int _imageSizeY;
        public int ImageSizeY { get { return _imageSizeY; } }

        private int _bufferSize;
        private ImagebufferStruct[] _imageBufferRGB;
        //public imagebufferStructUshort[] imagebufferRGB = new imagebufferStructUshort[bufferSize];
        private ImagebufferStruct[] _imageBufferMono;

        private int _destDataIndex;

        private Bitmap[] _displayImgRgb;
        private Bitmap[] _displayImgMono;

        private Bitmap[] _imagesRgb;
        public Bitmap[] ImagesRgb { get { return _imagesRgb; } set { _imagesRgb = value; } }
        //private Bitmap[] _displayImgMono;

        private double[] _imagesRgbExposureTime;
        public double[] ImagesRgbExposureTime { get { return _imagesRgbExposureTime; } set { _imagesRgbExposureTime = value; } }

        private int _imagesRgbCount;
        public int ImagesRgbCount { get { return _imagesRgbCount; } set { _imagesRgbCount = value; } }


        private bool _grabImage = false;


        private bool _isGrabbingImage = false;
        public bool IsGrabbingImage { get { return _isGrabbingImage; } set { _isGrabbingImage = value; } }



        private IntPtr _imagPtr = IntPtr.Zero;

        private bool newSize = false;
        private Bitmap _imgResized;

        // Device
        private SVSVistek_Api _svsVistekApi;

        public IntPtr _hDevice = IntPtr.Zero;
        public IntPtr _hRemoteDevice = IntPtr.Zero;

        private SVSVistek_DeviceInfo _deviceInfo;
        public SVSVistek_DeviceInfo DeviceInfo { get { return _deviceInfo; } }
        //private SVSVistek_Api._SV_DEVICE_INFO _devInfo;
        //public SVSVistek_Api._SV_DEVICE_INFO DevInfo { get { return _devInfo; } }

        //public SVSVistek_Api._SV_TL_INFO _tlInfo;
        //public SVSVistek_Api._SV_TL_INFO TlInfo { get { return _tlInfo; } }

        //public SVSVistek_Api._SV_INTERFACE_INFO _interfaceInfo;
        //public SVSVistek_Api._SV_INTERFACE_INFO InterfaceInfo { get { return _interfaceInfo; } }

        // Thread
        private bool _threadTerminate = false;

        private Thread _threadAcq;
        private Thread _threadDisp;

        private bool _threadAcqIsRuning = false;
        private bool _threadDispIsRuning = false;

        private long _oldTime;
        private Stopwatch _swProcessingTime;






        //_camerasProcessingTime = new List<Stopwatch>();

















        //private List<SVSVistek_Camera> _cameras;
        //public List<SVSVistek_Camera> Cameras { get { return _cameras; } set { _cameras = value; } }











        public bool is_opened = false;



















        public string CurrentID = "";
        private Graphics? gpanel;
        delegate void SetStatusCallBack();
        delegate void SetdisplayCallBack();
        delegate void treeUpdateCallBack();
        treeUpdateCallBack treeUpdate = null;
        //private string feature_info = null;
        private Rectangle outRectangle;






        private EventWaitHandle grab_image_is_done = new EventWaitHandle(true, EventResetMode.AutoReset);
        private EventWaitHandle display_is_done = new EventWaitHandle(true, EventResetMode.AutoReset);













        private Bitmap _image;
        public Bitmap Image
        {
            get { return _image; }
        }






















        // Streaming
        public IntPtr hStream = IntPtr.Zero;
        private uint dsBufcount = 0;
        private bool isStreaming = false;
        public bool threadIsRuning = false;

        // Camera Feature 
        public Queue<SVSVistek_Api._SVCamFeaturInf> featureInfolist;
        public SVSVistek_Api._SV_BUFFER_INFO bufferInfoDest = new SVSVistek_Api._SV_BUFFER_INFO();
        public SVSVistek_Api._SV_BUFFER_INFO bufferInfosrc = new SVSVistek_Api._SV_BUFFER_INFO();
        #endregion

        public SVSVistek_Camera(SVSVistek_DeviceInfo deviceInfo)
        //public SVSVistek_Camera(SVSVistek_Api._SV_DEVICE_INFO deviceInfo, SVSVistek_Api._SV_TL_INFO tlInfo, SVSVistek_Api._SV_INTERFACE_INFO interfaceInfo)
        {
            _svsVistekApi = new SVSVistek_Api();

            _config = new SVSVistek_Camera_Config();

            // Image
            _isRgb = false;
            _imageSizeX = 0;
            _imageSizeY = 0;

            _bufferSize = 10;
            _imageBufferRGB = new ImagebufferStruct[_bufferSize];
            //_imageBufferRGB = new imagebufferStructUshort[bufferSize];
            _imageBufferMono = new ImagebufferStruct[_bufferSize];

            _destDataIndex = 0;

            _displayImgRgb = new Bitmap[_bufferSize];
            _displayImgMono = new Bitmap[_bufferSize];

            _imagesRgb = new Bitmap[_bufferSize];
            _imagesRgbExposureTime = new double[_bufferSize];

            // Device
            //_devInfo = deviceInfo;
            //_tlInfo = tlInfo;
            //_interfaceInfo = interfaceInfo;

            _deviceInfo = deviceInfo;











            featureInfolist = new Queue<SVSVistek_Api._SVCamFeaturInf>();
            _hRemoteDevice = new IntPtr();
            _hDevice = new IntPtr();

            bufferInfoDest.pImagePtr = IntPtr.Zero;
            bufferInfosrc.pImagePtr = IntPtr.Zero;







            _swProcessingTime = new Stopwatch();
        }

        ~SVSVistek_Camera()
        {
            if (isStreaming)
            {
                AcquisitionStop();
                StreamingChannelClose();
            }

            closeConnection();

            _svsVistekApi = null;


            //_tlInfoList = null;
            //_deviceInfoList = null;
            //_interfaceInfoList = null;

            //_pInterfaceHdlList = null;
            //_pCameraSystemHdlList = null;





            is_opened = false;
        }






        // Camera: Connection
        public SVSVistek_Api.SVSVistekApiReturn OpenConnection()
        {
            if (is_opened)
            {
                return 0;
            }

            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;

            //Open the device with device id (devInfo.uid) connected to the interface (devInfo.hParentIF)
            ret = _svsVistekApi.SVS_InterfaceDeviceOpen(_deviceInfo.DeviceInfo.hParentIF, _deviceInfo.DeviceInfo.uid, SVSVistek_Api.SV_DEVICE_ACCESS_FLAGS_LIST.SV_DEVICE_ACCESS_CONTROL, ref _hDevice, ref _hRemoteDevice);
            Debug.WriteLine("open connection");

            if (ret == SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                is_opened = true;
            }

            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn closeConnection()
        {
            // Debug.WriteLine("close connection");
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;

            ret = _svsVistekApi.SVS_DeviceClose(_hDevice);
            if (ret == SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                is_opened = false;
            }

            return ret;
        }

        public void GetFeatureValue(IntPtr hFeature, ref SVSVistek_Api._SVCamFeaturInf SvCamfeatureInfo)
        {
            _svsVistekApi.SVS_FeatureGetInfo(_hRemoteDevice, hFeature, ref SvCamfeatureInfo.SVFeaturInf);
            if ((int)SVSVistek_Api.SV_FEATURE_TYPE.SV_intfIInteger == SvCamfeatureInfo.SVFeaturInf.type)
            {
                Int64 value = 0;
                _svsVistekApi.SVS_FeatureGetValueInt64(_hRemoteDevice, hFeature, ref value);
                SvCamfeatureInfo.intValue = (ulong)value;
                string st = value.ToString();
                SvCamfeatureInfo.strValue = string.Copy(st);
            }
            else if ((int)SVSVistek_Api.SV_FEATURE_TYPE.SV_intfIFloat == SvCamfeatureInfo.SVFeaturInf.type)
            {
                double value = 0.0f;
                _svsVistekApi.SVS_FeatureGetValueFloat(_hRemoteDevice, hFeature, ref value);
                string st = value.ToString();
                SvCamfeatureInfo.strValue = string.Copy(st);
            }
            else if ((int)SVSVistek_Api.SV_FEATURE_TYPE.SV_intfIBoolean == SvCamfeatureInfo.SVFeaturInf.type)
            {
                bool value = false;
                _svsVistekApi.SVS_FeatureGetValueBool(_hRemoteDevice, hFeature, ref value);
                SvCamfeatureInfo.booValue = value;
                if (value)
                    SvCamfeatureInfo.strValue = "True";
                else
                    SvCamfeatureInfo.strValue = "False";
            }
            else if ((int)SVSVistek_Api.SV_FEATURE_TYPE.SV_intfICommand == SvCamfeatureInfo.SVFeaturInf.type)
            {
                SvCamfeatureInfo.strValue = " = > Execute Command";
            }
            else if ((int)SVSVistek_Api.SV_FEATURE_TYPE.SV_intfIString == SvCamfeatureInfo.SVFeaturInf.type)
            {
                _svsVistekApi.SVS_FeatureGetValueString(_hRemoteDevice, hFeature, ref SvCamfeatureInfo.strValue, SVSVistek_Api.DefineConstants.SV_STRING_SIZE);
            }
            else if ((int)SVSVistek_Api.SV_FEATURE_TYPE.SV_intfIEnumeration == SvCamfeatureInfo.SVFeaturInf.type)
            {
                int pInt64Value = 0;
                uint buffSize = SVSVistek_Api.DefineConstants.SV_STRING_SIZE;
                SVSVistek_Api.SVSVistekApiReturn ret = _svsVistekApi.SVS_FeatureEnumSubFeatures(_hRemoteDevice, hFeature, (int)SvCamfeatureInfo.SVFeaturInf.enumSelectedIndex, ref SvCamfeatureInfo.subFeatureName, buffSize, ref pInt64Value);
                SvCamfeatureInfo.intValue = (UInt64)pInt64Value;
                SvCamfeatureInfo.strValue = SvCamfeatureInfo.subFeatureName;
            }
        }

        public void GetDeviceFeatureList(SVSVistek_Api.SV_FEATURE_VISIBILITY visibility)
        {
            // DSDeleteContainer(featureInfolist);
            uint iIndex = 0;
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            while (true)
            {
                if (iIndex == 500)
                {
                    break;
                }

                IntPtr hFeature = IntPtr.Zero;
                ret = _svsVistekApi.SVS_FeatureGetByIndex(_hRemoteDevice, iIndex++, ref hFeature);

                if (SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS != ret)
                {
                    break;
                }

                //Create a new Feature structure and
                SVSVistek_Api._SVCamFeaturInf camFeatureInfo = new SVSVistek_Api._SVCamFeaturInf();
                ret = _svsVistekApi.SVS_FeatureGetInfo(_hRemoteDevice, hFeature, ref camFeatureInfo.SVFeaturInf);

                if (SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS != ret)
                {
                    //  Debug.WriteLine(" SVFeatureGetInfo Failed!:%d\n", ret);
                    continue;
                }

                //	retrive only a specific features 
                if (camFeatureInfo.SVFeaturInf.visibility > (uint)visibility || (int)SVSVistek_Api.SV_FEATURE_TYPE.SV_intfIPort == camFeatureInfo.SVFeaturInf.type)
                {
                    continue;
                }

                // get the current value and feature info 
                GetFeatureValue(hFeature, ref camFeatureInfo);
                //add the feature handle and remote device handle 
                camFeatureInfo.hFeature = hFeature;
                camFeatureInfo.hRemoteDevice = _hRemoteDevice;
                featureInfolist.Enqueue(camFeatureInfo);
            }
        }

        //  Stream: Channel creation and control
        public SVSVistek_Api.SVSVistekApiReturn StreamingChannelOpen()
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            string streamId0 = null;
            uint streamId0Size = 512;

            // retriev the stream ID 
            ret = _svsVistekApi.SVS_DeviceGetStreamId(_hDevice, 0, ref streamId0, ref streamId0Size);

            if (SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS != ret)
            {
                return ret;
            }

            // open the Streaming channel with the retrieved stream ID
            ret = _svsVistekApi.SVS_DeviceStreamOpen(_hDevice, streamId0, ref hStream);
            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn StreamingChannelClose()
        {
            return _svsVistekApi.SVS_SVStreamClose(hStream);
        }

        public bool Grab()
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr hBuffer = IntPtr.Zero;
            IntPtr Imagptr2 = IntPtr.Zero;

            uint timeout = 1000;
            ret = _svsVistekApi.SVS_StreamWaitForNewBuffer(hStream, ref Imagptr2, ref hBuffer, timeout);

            if (ret == SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                ret = _svsVistekApi.SVS_StreamBufferGetInfo(hStream, hBuffer, ref bufferInfosrc);
                if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                {
                    //  Debug.Write("ERROR TIMEOUT !!");
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (bufferInfosrc.pImagePtr == IntPtr.Zero)
            {
                return false;
            }

            if (bufferInfoDest.pImagePtr == IntPtr.Zero)
            {
                bufferInfoDest.pImagePtr = Marshal.AllocHGlobal(bufferInfosrc.iImageSize);
            }

            NativeMethods.CopyMemory(bufferInfoDest.pImagePtr, bufferInfosrc.pImagePtr, (uint)bufferInfosrc.iImageSize);

            bufferInfoDest.iImageSize = bufferInfosrc.iImageSize;
            bufferInfoDest.iSizeX = bufferInfosrc.iSizeX;
            bufferInfoDest.iSizeY = bufferInfosrc.iSizeY;
            bufferInfoDest.iPixelType = bufferInfosrc.iPixelType;
            bufferInfoDest.iImageId = bufferInfosrc.iImageId;
            bufferInfoDest.iTimeStamp = bufferInfosrc.iTimeStamp;
            // Queues a particular buffer for acquisition.
            ret = _svsVistekApi.SVS_StreamQueueBuffer(hStream, hBuffer);
            if (ret == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SVSVistek_Api.SVSVistekApiReturn AcquisitionStart(uint bufcount)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr hFeature = IntPtr.Zero;
            Int64 payloadSize = 0;

            //retrieve the payload size from device  if possible to allocate the buffers  
            _svsVistekApi.SVS_FeatureGetByName(hStream, SVSVistek_Api.CameraFeature.PayloadSize, ref hFeature);
            _svsVistekApi.SVS_FeatureGetValueInt64(hStream, hFeature, ref payloadSize);

            if (payloadSize == 0)
            {
                //retrieve the payload size from remote device to allocate the buffers
                _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, SVSVistek_Api.CameraFeature.PayloadSize, ref hFeature);
                _svsVistekApi.SVS_FeatureGetValueInt64(_hRemoteDevice, hFeature, ref payloadSize);
            }

            // allocat buffers with the retrieved payload size. 
            for (uint i = 0; i < bufcount; i++)
            {
                IntPtr hBuffer = IntPtr.Zero;
                _svsVistekApi.SVS_StreamAllocAndAnnounceBuffer(hStream, (uint)payloadSize, _imagPtr, ref hBuffer);
                if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
                {
                    continue;
                }

                ret = _svsVistekApi.SVS_StreamQueueBuffer(hStream, hBuffer);
                if (SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS != ret)
                {
                    continue;
                }
            }

            _svsVistekApi.SVS_StreamFlushQueue(hStream, SVSVistek_Api.SV_ACQ_QUEUE_TYPE_LIST.SV_ACQ_QUEUE_ALL_TO_INPUT);
            ret = _svsVistekApi.SVS_StreamAcquisitionStart(hStream, SVSVistek_Api.SV_ACQ_START_FLAGS_LIST.SV_ACQ_START_FLAGS_DEFAULT, SVSVistek_Api.DefineConstants.INFINIT);

            if (SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS != ret)
            {
                for (UInt32 i = 0; i < bufcount; i++)
                {
                    IntPtr hBuffer = IntPtr.Zero;
                    ret = _svsVistekApi.SVS_StreamGetBufferId(hStream, 0, ref hBuffer);

                    IntPtr pBuffer = IntPtr.Zero;
                    IntPtr imaptr = IntPtr.Zero;

                    if (IntPtr.Zero != hBuffer)
                    {
                        _svsVistekApi.SVS_StreamRevokeBuffer(hStream, hBuffer, ref pBuffer, ref (imaptr));
                    }
                }
            }

            // set acquisitionstart 
            uint ExecuteTimeout = 1000;
            hFeature = IntPtr.Zero;

            _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, SVSVistek_Api.CameraFeature.AcquisitionStart, ref hFeature);
            _svsVistekApi.SVS_FeatureCommandExecute(_hRemoteDevice, hFeature, ExecuteTimeout);
            hFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, SVSVistek_Api.CameraFeature.TLParamsLocked, ref hFeature);
            Int64 paramsLocked = 1;
            ret = _svsVistekApi.SVS_FeatureSetValueInt64(_hRemoteDevice, hFeature, paramsLocked);

            if (SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS == ret)
            {
                dsBufcount = bufcount;
            }
            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn AcquisitionStop()
        {
            _threadTerminate = true;

            _threadAcqIsRuning = false;
            _threadDispIsRuning = false;

            Thread.Sleep(125);

            while (_threadAcq.ThreadState == System.Threading.ThreadState.Running || _threadDisp.ThreadState == System.Threading.ThreadState.Running)
            {
                ;
            }

            _swProcessingTime.Stop();
            _swProcessingTime = null;

            Thread.Sleep(125);






            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;

            // set acquisitionstart 
            uint ExecuteTimeout = 1000;

            IntPtr hFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, SVSVistek_Api.CameraFeature.AcquisitionStop, ref hFeature);

            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }
            ret = _svsVistekApi.SVS_FeatureCommandExecute(_hRemoteDevice, hFeature, ExecuteTimeout);

            // 
            hFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, SVSVistek_Api.CameraFeature.TLParamsLocked, ref hFeature);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }

            ret = _svsVistekApi.SVS_FeatureSetValueInt64(_hRemoteDevice, hFeature, 0);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }

            ret = _svsVistekApi.SVS_StreamAcquisitionStop(hStream, SVSVistek_Api.SV_ACQ_STOP_FLAGS_LIST.SV_ACQ_STOP_FLAGS_DEFAULT);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }

            ret = _svsVistekApi.SVS_StreamFlushQueue(hStream, SVSVistek_Api.SV_ACQ_QUEUE_TYPE_LIST.SV_ACQ_QUEUE_INPUT_TO_OUTPUT);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }

            ret = _svsVistekApi.SVS_StreamFlushQueue(hStream, SVSVistek_Api.SV_ACQ_QUEUE_TYPE_LIST.SV_ACQ_QUEUE_OUTPUT_DISCARD);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }

            IntPtr hBuffer = IntPtr.Zero;
            IntPtr pBuffer = IntPtr.Zero;
            IntPtr pBuffer2 = IntPtr.Zero;

            for (UInt32 i = 0; i < dsBufcount; i++)
            {
                ret = _svsVistekApi.SVS_StreamGetBufferId(hStream, 0, ref hBuffer);

                if (hBuffer != IntPtr.Zero)
                {
                    _svsVistekApi.SVS_StreamRevokeBuffer(hStream, hBuffer, ref pBuffer, ref pBuffer2);
                }

                pBuffer = IntPtr.Zero;
                pBuffer2 = IntPtr.Zero;
                hBuffer = IntPtr.Zero;
            }








            _threadAcq = null;
            _threadDisp = null;


            return ret;
        }

        public void AddnewImageData(SVSVistek_Api._SV_BUFFER_INFO ImageInfo, bool isImgRGB)
        {
            // Obtain image information structure
            if (ImageInfo.pImagePtr == IntPtr.Zero)
            {
                return;
            }

            // New data index
            _destDataIndex++;
            if (_destDataIndex == _bufferSize)
            {
                _destDataIndex = 0;
            }

            // 8 bit Format
            if (((int)ImageInfo.iPixelType & SVSVistek_Api.DefineConstants.SV_GVSP_PIX_EFFECTIVE_PIXELSIZE_MASK) == SVSVistek_Api.DefineConstants.SV_GVSP_PIX_OCCUPY8BIT)
            {
                if (isImgRGB)
                {
                    _svsVistekApi.SVS_UtilBufferBayerToRGB(ImageInfo, ref _imageBufferRGB[_destDataIndex].imagebytes[0], _imageBufferRGB[_destDataIndex].dataLegth);
                }
                else
                {
                    Marshal.Copy(ImageInfo.pImagePtr, _imageBufferMono[_destDataIndex].imagebytes, 0, _imageBufferMono[_destDataIndex].dataLegth);
                }
            }
            // 12 bit Format
            else if (((int)ImageInfo.iPixelType & SVSVistek_Api.DefineConstants.SV_GVSP_PIX_EFFECTIVE_PIXELSIZE_MASK) == SVSVistek_Api.DefineConstants.SV_GVSP_PIX_OCCUPY12BIT)
            {
                if (isImgRGB)
                {
                    _svsVistekApi.SVS_UtilBufferBayerToRGB(ImageInfo, ref _imageBufferRGB[_destDataIndex].imagebytes[0], _imageBufferRGB[_destDataIndex].dataLegth);
                }
                else
                {
                    if (ImageInfo.pImagePtr != null)
                    {
                        // Convert to 8 bit 
                        _svsVistekApi.SVS_UtilBuffer12BitTo8Bit(ImageInfo, ref _imageBufferMono[_destDataIndex].imagebytes[0], _imageBufferMono[_destDataIndex].dataLegth);
                    }
                }
            }
            // 16 bit Format
            else
            {
                if (((int)ImageInfo.iPixelType & SVSVistek_Api.DefineConstants.SV_GVSP_PIX_EFFECTIVE_PIXELSIZE_MASK) == SVSVistek_Api.DefineConstants.SV_GVSP_PIX_OCCUPY16BIT)
                {
                    if (isImgRGB)
                    {
                        _svsVistekApi.SVS_UtilBufferBayerToRGB(ImageInfo, ref _imageBufferRGB[_destDataIndex].imagebytes[0], _imageBufferRGB[_destDataIndex].dataLegth);
                    }
                    else
                    {
                        if (ImageInfo.pImagePtr != null)
                        {
                            // Convert to 8 bit 
                            _svsVistekApi.SVS_UtilBuffer16BitTo8Bit(ImageInfo, ref _imageBufferMono[_destDataIndex].imagebytes[0], _imageBufferMono[_destDataIndex].dataLegth);
                        }
                    }
                }
            }
        }

























        /// <summary>
        /// Start continuously acquision
        /// </summary>
        public void StartAcquisionContinuously()
        {
            _threadTerminate = false;

            // Open streaming channel for the camera
            StreamingChannelOpen();

            // Initialize pointers for the camera
            if (bufferInfoDest.pImagePtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(bufferInfoDest.pImagePtr);
                bufferInfoDest.pImagePtr = IntPtr.Zero;
            }

            // Start acquision for the camera
            AcquisitionStart(10);

            // Start aquision thread for the camera
            if (!_threadAcqIsRuning)
            {
                AcquisitionThreadStart();
            }

            //// Start display thread for the camera
            //if (!_threadDispIsRuning)
            //{
            //    DisplayThreadStart();
            //}
        }



        public void StopAcquisionContinuouslyNEWWW()
        {
            _threadTerminate = true;

            // Stop acquision for the camera
            AcquisitionStop();

            // Open streaming channel for the camera
            StreamingChannelClose();

            // Clear pointers for the camera
            bufferInfoDest.pImagePtr = IntPtr.Zero;

            // Start aquision thread for the camera
            if (_threadAcqIsRuning)
            {
                _threadAcqIsRuning = false;

                Thread.Sleep(500);

                _threadAcq.Abort();
                _threadAcq = null;
            }

            // Start display thread for the camera
            if (_threadDispIsRuning)
            {
                _threadDispIsRuning = false;

                Thread.Sleep(500);

                _threadDisp.Abort();
                _threadDisp = null;
            }
        }






















        public void AcquisitionThreadStart()
        {
            _threadAcqIsRuning = true;

            _swProcessingTime.Start();
            _oldTime = _swProcessingTime.ElapsedMilliseconds;

            _threadAcq = null;
            _threadAcq = new Thread(() => AcquisitionThread());
            _threadAcq.Start();
        }

        private void AcquisitionThread()
        {
            while (_threadAcqIsRuning)
            {
                if (_threadTerminate)
                {
                    _swProcessingTime.Stop();
                    break;
                }

                if (!Grab())
                {
                    continue;
                }

                //if (!display_is_done.WaitOne(10))
                //{
                //    continue;
                //}

                // Check if a RGB image(Bayer buffer format) arrived
                bool isImgRGB = false;
                int pDestLength = (int)(bufferInfoDest.iImageSize);
                int sizeX = (int)bufferInfoDest.iSizeX;
                int sizeY = (int)bufferInfoDest.iSizeY;
                CurrentID = Convert.ToString(bufferInfoDest.iImageId);

                if (((int)bufferInfoDest.iPixelType & SVSVistek_Api.DefineConstants.SV_GVSP_PIX_ID_MASK) >= 8)
                {
                    isImgRGB = true;
                    pDestLength = 3 * pDestLength;
                }

                InitializeBuffer(isImgRGB, sizeX, sizeY);
                AddnewImageData(bufferInfoDest, isImgRGB);
                _isRgb = isImgRGB;
                //grab_image_is_done.Set();

                //Log.Verbose($"Current ID: {CurrentID} ...");
                //Log.Verbose($"Execution Time Camera {_deviceInfo.DeviceInfo.serialNumber} : {_swProcessingTime.ElapsedMilliseconds - _oldTime}ms ...");
                _oldTime = _swProcessingTime.ElapsedMilliseconds;
            }
        }

        private void Acquisition()
        {
            if (_threadTerminate)
            {
                _swProcessingTime.Stop();
            }

            Grab();


            //if (!display_is_done.WaitOne(10))
            //{
            //    continue;
            //}

            // Check if a RGB image(Bayer buffer format) arrived
            bool isImgRGB = false;
            int pDestLength = (int)(bufferInfoDest.iImageSize);
            int sizeX = (int)bufferInfoDest.iSizeX;
            int sizeY = (int)bufferInfoDest.iSizeY;
            CurrentID = Convert.ToString(bufferInfoDest.iImageId);

            if (((int)bufferInfoDest.iPixelType & SVSVistek_Api.DefineConstants.SV_GVSP_PIX_ID_MASK) >= 8)
            {
                isImgRGB = true;
                pDestLength = 3 * pDestLength;
            }

            InitializeBuffer(isImgRGB, sizeX, sizeY);
            AddnewImageData(bufferInfoDest, isImgRGB);
            _isRgb = isImgRGB;
            //grab_image_is_done.Set();

            //Log.Verbose($"Current ID: {CurrentID} ...");
            //Log.Verbose($"Execution Time Camera {_deviceInfo.DeviceInfo.serialNumber} : {_swProcessingTime.ElapsedMilliseconds - _oldTime}ms ...");
            _oldTime = _swProcessingTime.ElapsedMilliseconds;
        }






        public void DisplayThreadStart()
        {
            _threadDispIsRuning = true;

            _threadDisp = null;
            _threadDisp = new Thread(() => DisplayThread());
            _threadDisp.Start();
        }

        private void DisplayThread()
        {
            while (_threadDispIsRuning)
            {
                if (_threadTerminate)
                {
                    break;
                }

                setToDisplay();

                WaitHandle.SignalAndWait(display_is_done, grab_image_is_done);
            }
        }

        private void setToDisplay()
        {
            if (!_threadAcqIsRuning)
            {
                return;
            }

            int currentIndex = _destDataIndex;
            if (_isRgb)
            {
                if (_grabImage)
                //if (_grabImage && _takePictureHrd == -1)
                {
                    if (_grabImage)
                    {
                        //_displayImgRgb[currentIndex].Save($"{_fielPath}.bmp", ImageFormat.Bmp);

                        _grabImage = false;
                    }

                    //// Some lines a from SVS-Vistel Exmple ...
                    //double dbl = _displayImgRgb[currentIndex].Width / (double)_displayImgRgb[currentIndex].Height;
                    //if (dbl < _displayImgRgb[currentIndex].Width)
                    //{
                    //    if ((int)((double)_displayImgRgb[currentIndex].Height * dbl) <= _displayImgRgb[currentIndex].Width)
                    //    {
                    //        outRectangle.Width = (int)((double)_displayImgRgb[currentIndex].Height * dbl);
                    //        outRectangle.Height = _displayImgRgb[currentIndex].Height;

                    //        if (_takePicture)
                    //        {
                    //            _imgResized = new Bitmap(_displayImgRgb[currentIndex], (int)((double)_displayImgRgb[currentIndex].Height * dbl), _displayImgRgb[currentIndex].Height);
                    //            _imgResized.Save($"{_fielPath}_imgResized.bmp", ImageFormat.MemoryBmp);
                    //            _imgResized.Dispose();

                    //            _takePicture = false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        outRectangle.Width = _displayImgRgb[currentIndex].Width;
                    //        outRectangle.Height = (int)((double)_displayImgRgb[currentIndex].Width / dbl);

                    //        if (_takePicture)
                    //        {
                    //            _imgResized = new Bitmap(_displayImgRgb[currentIndex], _displayImgRgb[currentIndex].Width, (int)((double)_displayImgRgb[currentIndex].Width / dbl));
                    //            _imgResized.Save($"{_fielPath}_imgResized.bmp", ImageFormat.MemoryBmp);
                    //            _imgResized.Dispose();

                    //            _takePicture = false;
                    //        }
                    //    }
                    //}

                    Log.Verbose($"Execution Time Camera {_deviceInfo.DeviceInfo.serialNumber} : {_swProcessingTime.ElapsedMilliseconds - _oldTime}ms ...");
                    _oldTime = _swProcessingTime.ElapsedMilliseconds;
                }
            }
            else
            {
                if (_displayImgMono[currentIndex] != null)
                {
                    if (_grabImage)
                    //if (_grabImage && _takePictureHrd == -1)
                    {
                        //_displayImgMono[currentIndex].Save($"{_fielPath}.bmp", ImageFormat.Bmp);

                        _grabImage = false;
                    }

                    //// Some lines a from SVS - Vistel Exmple...
                    //double dbl = _displayImgMono[currentIndex].Width / (double)_displayImgMono[currentIndex].Height;
                    //ColorPalette imgpal = _displayImgMono[currentIndex].Palette;

                    //// Build bitmap palette Y8
                    //for (uint i = 0; i < 256; i++)
                    //{
                    //    imgpal.Entries[i] = Color.FromArgb(0xFF, (byte)i, (byte)i, (byte)i);
                    //}

                    //_displayImgMono[currentIndex].Palette = imgpal;
                    ////imgpal = _displayImgMono[currentIndex].Palette;
                    ////gpanel.DrawImage(_displayImgMono[currentIndex], outRectangle);
                    //if (_takePicture)
                    //{
                    //    _imgResized = new Bitmap(_displayImgMono[currentIndex], _displayImgMono[currentIndex].Width, (int)((double)_displayImgMono[currentIndex].Width / dbl));
                    //    _imgResized.Save($"{_fielPath}_imgResized.bmp", ImageFormat.MemoryBmp);
                    //    _imgResized.Dispose();

                    //    _takePicture = false;
                    //}

                    Log.Verbose($"Execution Time Camera {_deviceInfo.DeviceInfo.serialNumber} : {_swProcessingTime.ElapsedMilliseconds - _oldTime}ms ...");
                    _oldTime = _swProcessingTime.ElapsedMilliseconds;
                }
            }

            _destDataIndex++;
            if (_destDataIndex == _bufferSize)
            {
                _destDataIndex = 0;
            }
        }








        private void InitializeBuffer(bool rgb, int camWidth, int camHeight)
        {
            newSize = false;
            int k;

            //if (CurrentCamera == null)
            //{
            //    return;
            //}

            if (rgb)
            {
                if (_imageBufferRGB[0].dataLegth != 3 * camWidth * camHeight)
                {
                    newSize = true;
                }

                for (k = 0; k < _bufferSize; k++)
                {
                    unsafe
                    {
                        if (newSize)
                        {
                            _imageBufferRGB[k].imagebytes = new byte[3 * camWidth * camHeight];
                            //CurrentCamera.imagebufferRGB[k].imagebytes = new ushort[3 * camWidth * camHeight];
                        }

                        fixed (byte* ColorPtr = _imageBufferRGB[k].imagebytes)
                        //fixed (ushort* ColorPtr = CurrentCamera.imagebufferRGB[k].imagebytes)
                        {
                            if (newSize)
                            {
                                _displayImgRgb[k] = new Bitmap(camWidth, camHeight, (3 * camWidth), System.Drawing.Imaging.PixelFormat.Format24bppRgb, (IntPtr)ColorPtr);
                                //display_img_rgb[k] = new Bitmap(camWidth, camHeight, (3 * camWidth), System.Drawing.Imaging.PixelFormat.Format48bppRgb, (IntPtr)ColorPtr);
                            }

                            _imageBufferRGB[k].sizeX = camWidth;
                            _imageBufferRGB[k].sizeY = camHeight;
                            _imageBufferRGB[k].dataLegth = 3 * camWidth * camHeight;
                        }
                    }
                }
            }
            else
            {
                if (_imageBufferMono[0].dataLegth != camWidth * camHeight)
                {
                    newSize = true;
                }

                for (k = 0; k < 4; k++)
                {
                    unsafe
                    {
                        if (newSize)
                        {
                            _imageBufferMono[k].imagebytes = new byte[camWidth * camHeight];
                        }

                        fixed (byte* MonoPtr = _imageBufferMono[k].imagebytes)
                        {
                            if (newSize)
                            {
                                _displayImgMono[k] = new Bitmap(camWidth, camHeight, camWidth, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, (IntPtr)MonoPtr);
                            }

                            _imageBufferMono[k].sizeX = camWidth;
                            _imageBufferMono[k].sizeY = camHeight;
                            _imageBufferMono[k].dataLegth = camWidth * camHeight;
                        }
                    }
                }
            }
        }






        public Bitmap[] GrabImage()
        {
            if (!_threadTerminate)
            {
                _grabImage = true;

                return null;
            }
            else
            {
                return null;
            }
        }

        public void GrabImageHdrAsync(long[] exposureTime)
        {
            if (!_threadTerminate)
            {
                Thread hdr = new Thread(() => GrabImageHdrAsyncThread(exposureTime));
                hdr.Start();
            }
        }

        private void GrabImageHdrAsyncThread(long[] exposureTime)
        {
            _grabImage = true;
            _isGrabbingImage = true;


            _imagesRgb = new Bitmap[_bufferSize];

            _imagesRgbCount = exposureTime.Length;

            //int length = exposureTimeArray.Length;
            //int lenghtHalf = length / 2;
            //int sleepTime = 750;
            //long exposureTime = 5000;
            //Bitmap[] tmp = new Bitmap[length];



            //for (int i = 0; i < length; i++)
            //{
            //    sleepTime = sleepTimeArray[i];
            //    exposureTime = exposureTimeArray[i];

            //    SetExposureTime(exposureTime);

            //    Thread.Sleep(sleepTime);

            //    _displayImgRgb[_destdataIndex].Save($"{_fielPath}_{exposureTime}_Index{i}.bmp", ImageFormat.Bmp);
            //    //tmp[_takePictureHrd] = new Bitmap(_displayImgRgb[_destdataIndex]);

            //    if (i == lenghtHalf)
            //    {
            //        _image = new Bitmap(_displayImgRgb[_destdataIndex]);
            //    }

            //}






            //// New data index
            //_destDataIndex++;
            //if (_destDataIndex == _bufferSize)
            //{
            //    _destDataIndex = 0;
            //}






            //int i = 0;
            //int destDataIndexOld = _destDataIndex;

            //SetExposureTime(exposureTimeArray[i]);

            //while (true)
            //{
            //    if (_destDataIndex != destDataIndexOld)
            //    {
            //        _imagesRgb[i] = new Bitmap(_displayImgRgb[_destDataIndex]);

            //        destDataIndexOld = _destDataIndex;
            //        i++;

            //        if (i < exposureTimeArray.Length)
            //        {
            //            SetExposureTime(exposureTimeArray[i]);
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}




            Stopwatch swProcessingTime = new Stopwatch();
            swProcessingTime.Start();
            long oldTime = swProcessingTime.ElapsedMilliseconds;

            for (int i = 0; i < exposureTime.Length; i++)
            {
                SetExposureTime(exposureTime[i]);

                Acquisition();
                //Acquisition();
                //Acquisition();

                _imagesRgb[i] = new Bitmap(_displayImgRgb[_destDataIndex]);
                _imagesRgbExposureTime[i] = exposureTime[i];
            }

            // Reset exposure time
            SetExposureTime(exposureTime[0]);
            Acquisition();




            Log.Verbose($"Picture taking time : {swProcessingTime.ElapsedMilliseconds - oldTime}ms ...");
            swProcessingTime.Stop();

            //for (int i = 0; i < exposureTimeArray.Length; i++)
            //{
            //    tmp[i].Save($"{_fielPath}_{sleepTimeArray[i]}_Index{i}.bmp", ImageFormat.Bmp);
            //}





            /*
            tmp[3].Save($"{_fielPath}_Original.bmp", ImageFormat.Bmp);
            Mat imageMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(tmp[3]);
            OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageMat).Save($"{_fielPath}_OriginalMat.raw", ImageFormat.Bmp);

            Mat imageDenoised = imageMat;
            Mat imageDetailEnhance = imageMat;
            //Mat imageSuperResolution = imageMat;


            Cv2.FastNlMeansDenoisingColored(imageMat, imageDenoised, 3, 3, 7, 21);
            OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageDenoised).Save($"{_fielPath}_imageDenoised.raw", ImageFormat.Bmp);


            Cv2.DetailEnhance(imageMat, imageDetailEnhance, 5, 0.15f);
            OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageDetailEnhance).Save($"{_fielPath}_imageDetailEnhance.raw", ImageFormat.Bmp);
            */




            //FrameSource _frameSource = new FrameSource();
            //_frameSource.NextFrame(imageMat);
            //var asd = Cv2.CreateSuperResolution_BTVL1_CUDA();
            //asd.SetInput(_frameSource);
            //asd.NextFrame(dsadt);


            //var capture = new VideoCapture();
            //capture.Set(CaptureProperty.FrameWidth, 640);
            //capture.Set(CaptureProperty.FrameHeight, 480);
            //capture.Open(-1);
            //if (!capture.IsOpened())
            //    throw new Exception("capture initialization failed");

            //var fs = FrameSource.CreateCameraSource(-1);
            //var sr = SuperResolution.CreateBTVL1();
            //sr.SetInput(fs);

            //using (var normalWindow = new Window("normal"))
            //using (var srWindow = new Window("super resolution"))
            //{
            //    var normalFrame = new Mat();
            //    var srFrame = new Mat();
            //    while (true)
            //    {
            //        capture.Read(normalFrame);
            //        sr.NextFrame(srFrame);
            //        if (normalFrame.Empty() || srFrame.Empty())
            //            break;
            //        normalWindow.ShowImage(normalFrame);
            //        srWindow.ShowImage(srFrame);
            //        Cv2.WaitKey(100);
            //    }
            //}






            //var capture = new VideoCapture();
            ////capture.Set(CaptureProperty.FrameWidth, 640);
            ////capture.Set(CaptureProperty.FrameHeight, 480);
            //capture.Open(-1);
            ////if (!capture.IsOpened())
            ////    throw new Exception("capture initialization failed");

            //var fs = FrameSource.CreateFrameSource_Video_CUDA(-1);
            //var sr = SuperResolution.CreateBTVL1();
            //sr.SetInput(fs);

            //using (var normalWindow = new Window("normal"))
            //using (var srWindow = new Window("super resolution"))
            //{
            //    var normalFrame = new Mat();
            //    var srFrame = new Mat();
            //    while (true)
            //    {
            //        capture.Read(normalFrame);
            //        sr.NextFrame(srFrame);
            //        if (normalFrame.Empty() || srFrame.Empty())
            //            break;
            //        normalWindow.ShowImage(normalFrame);
            //        srWindow.ShowImage(srFrame);
            //        Cv2.WaitKey(100);
            //    }
            //}





            //Cv2.ImShow("esdfadsf", dst);


            //imageMat.SaveImage($"{_fielPath}_Original.bmp");
            //imageDenoised.SaveImage($"{_fielPath}_Denoised.bmp");
            //imageSuperResolution.SaveImage($"{_fielPath}_CreateSuperResolution_BTVL1_CUDA.bmp");


            //OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageSuperResolution).Save($"{_fielPath}_imageSuperResolution.raw", ImageFormat.Bmp);

            _isGrabbingImage = false;
            _grabImage = false;
        }




        //public Bitmap GetPicture()
        //{
        //    if (_imgResized != null)
        //    {
        //        return _imgResized;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}



















        ///// <summary>
        ///// Stop acquisition of current camera
        ///// </summary>
        ///// <returns></returns>
        //public bool StopCamera()
        //{
        //    try
        //    {
        //        _terminate = true;
        //        Debug.WriteLine("Stopping - " + devInfo.serialNumber);
        //        AcquisitionStop();
        //        StreamingChannelClose();
        //        closeConnection();

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









        public bool Distroy()
        {
            try
            {
                Log.Debug("Stopping - " + _deviceInfo.DeviceInfo.serialNumber);

                _threadTerminate = true;

                _threadAcqIsRuning = false;
                _threadDispIsRuning = false;
                _grabImage = false;






                //devInfo = null;
                featureInfolist = null;
                _hRemoteDevice = IntPtr.Zero;
                _hDevice = IntPtr.Zero;
                _svsVistekApi = null;
                bufferInfoDest.pImagePtr = IntPtr.Zero;
                bufferInfosrc.pImagePtr = IntPtr.Zero;

                //_tlInfoList = null;
                //_deviceInfoList = null;
                //_interfaceInfoList = null;

                //_pInterfaceHdlList = null;
                //_pCameraSystemHdlList = null;





                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"Error while detroying cam {_deviceInfo.DeviceInfo.serialNumber}: {ex}");

                return false;
            }
        }
























    }
}
