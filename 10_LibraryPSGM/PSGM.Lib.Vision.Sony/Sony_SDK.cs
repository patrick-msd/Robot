using System.Runtime.InteropServices;

namespace PSGM.Lib.Vision.Sony
{
    public partial class Sony_SDK
    {
        internal static class CameraFeature
        {
            //// SV_intfIString
            //public const string DeviceUserID = "DeviceUserID";
            ////....
            ////SV_intfIFloat
            //public const string AcquisitionFrameRate = "AcquisitionFrameRate";
            ////...
            ////SV_intfIInteger:
            //public const string SeqCount = "SeqCount";
            //public const string PayloadSize = "PayloadSize";
            //public const string TLParamsLocked = "TLParamsLocked";
            ////...
            ////SV_intfICommand:
            //public const string TriggerMode = "TriggerMode";
            //public const string AcquisitionStart = "AcquisitionStart";
            //public const string AcquisitionStop = "AcquisitionStop";
            //public const string TriggerSoftware = "TriggerSoftware";
            ////...
            //// SV_intfIEnumeration
            //public const string AcquisitionMode = "AcquisitionMode";
            ////...
            //// SV_intfIBoolean
            //public const string SeqEnablem = "SeqEnable";
            ////...
        }

        internal static class DefineConstants
        {
            public const string SonySDK_DLL = "Cr_Core.dll";    //public string SVGenSDK_DLL = IntPtr.Size == 8 ? "SVGenSDK64.DLL" : "SVGenSDK.DLL";
            public const string SonySDK_DLL64 = "Cr_Core.dll";

            //public const int SV_STRING_SIZE = 512;
            //public const int SV_GVSP_PIX_MONO = 0x01000000;
            //public const int SV_GVSP_PIX_RGB = 0x02000000;
            //public const int SV_GVSP_PIX_OCCUPY8BIT = 0x00080000;
            //public const int SV_GVSP_PIX_OCCUPY12BIT = 0x000C0000;
            //public const int SV_GVSP_PIX_OCCUPY16BIT = 0x00100000;
            //public const int SV_GVSP_PIX_OCCUPY24BIT = 0x00180000;
            //public const uint SV_GVSP_PIX_COLOR_MASK = 0xFF000000;
            //public const int SV_GVSP_PIX_EFFECTIVE_PIXELSIZE_MASK = 0x00FF0000;
            //public const int SV_GVSP_PIX_ID_MASK = 0x0000FFFF;
            //public const uint INFINIT = 0xFFFFFF;
        }

        public int SVCam_NO_EVENT = -1;

        public struct SV_LIB_VERSION
        {
            uint MajorVersion;
            uint MinorVersion;
            uint Revision;
            uint BuildVersion;
        }

        public enum SVSVistekApiReturn
        {
            //         SV_ERROR_SUCCESS = 0, ///< OK
            //                               ///
            //         SV_ERROR_UNKNOWN = -1001, ///< Generic error-code
            //SV_ERROR_NOT_INITIALIZED = -1002,
            //         SV_ERROR_NOT_IMPLEMENTED = -1003,
            //         SV_ERROR_RESOURCE_IN_USE = -1004,
            //         SV_ERROR_ACCESS_DENIED = -1005,
            //         SV_ERROR_INVALID_HANDLE = -1006,
            //         SV_ERROR_INVALID_ID = -1007,
            //         SV_ERROR_NO_MORE_DATA = -1008,
            //         SV_ERROR_INVALID_PARAMETER = -1009,
            //         SV_ERROR_FILE_IO = -1010,
            //         SV_ERROR_TIMEOUT = -1011,
            //         SV_ERROR_ABORT = -1012,

            //         SV_ERROR_NOT_OPENED = -2001,
            //         SV_ERROR_NOT_AVAILABLE = -2002,
            //         SV_ERROR_NOT_FOUND = -2003,
            //         SV_ERROR_BUFFER_TOO_SMALL = -2004,
            //         SV_ERROR_INVALID_FEATURE_TYPE = -2005,
            //         SV_ERROR_GENICAM_EXCEPTION = -2006,
            //         SV_ERROR_OUT_OF_MEMORY = -2007,
            //         SV_ERROR_GENICAM_DLL_NOT_FOUND = -2008,
            //         SV_ERROR_INVALID_GENICAM_CACHE_DIR = -2009,
            //         SV_ERROR_GENICAM_DLL_LOAD_FAILED = -2010,
            //         SV_ERROR_INVALID_CONFIG_FILE = -2011,
            //         SV_ERROR_LOG_DLL_NOT_LOADED = -2012,

            //         //SDK 2.5.0
            //         SV_ERROR_PIXEL_FORMAT_NOT_SUPPORTED = -2013,
            //         SV_ERROR_LIBPNG_DLL_NOT_LOADED = -2014,
            //         SV_ERROR_DLL_VERSION_MISMATCH = -2015
        }



        //SCRSDK::CrError





        internal static class NativeMethods
        {


            [DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "GetSDKVersion", CallingConvention = CallingConvention.Cdecl)]
            public static extern UInt32 Lib_GetSDKVersion();


            [DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "Init", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Lib_Init(uint logtype = 0);

            [DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "Release", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Lib_Release();


            [DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "EnumCameraObjects", CallingConvention = CallingConvention.Cdecl)]
            public static extern Error Lib_EnumCameraObjects(out IntPtr ppEnumCameraObjectInfo, byte timeInSec = 3);














            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraList(StringBuilder cameraList, int size);


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_OpenCamera(string cameraName);


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_CloseCamera();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraStatus();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraInfo(StringBuilder cameraInfo, int size);


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraModel(StringBuilder cameraModel, int size);


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraSerialNumber(StringBuilder cameraSerialNumber, int size);


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraFirmwareVersion(StringBuilder cameraFirmwareVersion, int size);


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryLevel();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryStatus();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryTemperature();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryCharging();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryChargingTime();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryChargingComplete();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryChargingError();


            //[DllImport(DefineConstants.SonySDK_DLL, EntryPoint = "SVLibInit", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int Sony_SDK_GetCameraBatteryChargingRequired();


        }

        public unsafe UInt32 GetSDKVersion()
        {
            return NativeMethods.Lib_GetSDKVersion();
        }

        public uint[] GetSDKVersionSplit()
        {
            uint version = NativeMethods.Lib_GetSDKVersion();

            uint major = (version & 0xFF000000) >> 24;
            uint minor = (version & 0x00FF0000) >> 16;
            uint patch = (version & 0x0000FF00) >> 8;

            return new uint[] { major, minor, patch };
        }


        public bool Init()
        {
            return NativeMethods.Lib_Init();
        }

        public bool Release()
        {
            return NativeMethods.Lib_Release();
        }

        

        public Error EnumCameraObjects(out IntPtr ppEnumCameraObjectInfo, byte timeInSec = 3)
        {
            return NativeMethods.Lib_EnumCameraObjects(out ppEnumCameraObjectInfo, timeInSec);
        }






    }
}
