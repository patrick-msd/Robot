namespace PSGM.Lib.Vision.SVSVistek
{
    public class SVSVistek_DeviceInfo
    {
        private SVSVistek_Api._SV_DEVICE_INFO _deviceInfo;
        public SVSVistek_Api._SV_DEVICE_INFO DeviceInfo { get { return _deviceInfo; } set { _deviceInfo = value; } }


        private IntPtr _cameraSystemHardware;
        public IntPtr CameraSystemHardware { get { return _cameraSystemHardware; } set { _cameraSystemHardware = value; } }


        private SVSVistek_Api._SV_INTERFACE_INFO _interfaceInfo;
        public SVSVistek_Api._SV_INTERFACE_INFO InterfaceInfo { get { return _interfaceInfo; } set { _interfaceInfo = value; } }


        private IntPtr _interfaceHardware;
        public IntPtr InterfaceHardware { get { return _interfaceHardware; } set { _interfaceHardware = value; } }
    }
}
