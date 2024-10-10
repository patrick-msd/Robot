namespace PSGM.Lib.Motion
{
    public partial class Nanotec_MotionController
    {
        // DB link
        private Guid? _IdDb = null;
        public Guid? IdDb { get { return _IdDb; } set { _IdDb = value; } }

        // Device information
        private uint _canDeviceId;
        public uint CanDeviceId { get { return _canDeviceId; } set { _canDeviceId = value; } }

        private Nlc.DeviceId _deviceId;
        public Nlc.DeviceId DeviceId { get { return _deviceId; } set { _deviceId = value; } }

        private Nlc.DeviceHandle _deviceHandle;
        public Nlc.DeviceHandle DeviceHandle { get { return _deviceHandle; } set { _deviceHandle = value; } }
    }
}
