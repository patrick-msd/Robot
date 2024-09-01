namespace PSGM.Lib.Vision.Sony
{
    public partial class Sony_SDK
    {

        public class CameraObjectInfo
        {
            private IntPtr _cameraObjectInfo;

            public CameraObjectInfo(IntPtr cameraObjectInfo)
            {
                _cameraObjectInfo = cameraObjectInfo;
            }

            public void Release()
            {
                // Implementiere die Freigabe der Kameraobjektinformationen
            }

            // Weitere Methoden zur Abfrage der Kameraobjektinformationen
        }

        public class EnumCameraObjectInfo
        {
            private IntPtr _enumCameraObjectInfo;

            public EnumCameraObjectInfo(IntPtr enumCameraObjectInfo)
            {
                _enumCameraObjectInfo = enumCameraObjectInfo;
            }

            public uint GetCount()
            {
                // Hier wird die Anzahl der Kameraobjekte abgerufen
                // Beispiel: return SonyCameraAPI.GetCameraCount(_enumCameraObjectInfo);
                return 0;
            }

            public CameraObjectInfo GetCameraObjectInfo(uint index)
            {
                // Hier wird ein bestimmtes Kameraobjekt abgerufen
                // Beispiel: IntPtr cameraObjectInfoPtr = SonyCameraAPI.GetCameraObjectInfo(_enumCameraObjectInfo, index);
                // return new CameraObjectInfo(cameraObjectInfoPtr);
                return null;
            }

            public void Release()
            {
                // Hier wird die Freigabe der Aufzählung der Kameraobjektinformationen implementiert
                // Beispiel: SonyCameraAPI.ReleaseEnumCameraObjectInfo(_enumCameraObjectInfo);
            }
        }





        /*
        public class ICrCameraObjectInfo
        {
         //   public virtual void Nat Release() = 0;
	        //// device name
         //   public virtual char* GetName() const = 0;
         //   public virtual UInt32 GetNameSize() const = 0;

         //   // model name
         //   public virtual char* GetModel() const = 0;
         //   public virtual UInt32 GetModelSize() const = 0;

         //   // pid (usb)
         //   public virtual Int16 GetUsbPid() const = 0;

         //   // device id
         //   public virtual byte* GetId() const = 0;
         //   public virtual UInt32 GetIdSize() const = 0;
         //   public virtual UInt32 GetIdType() const = 0;

         //   // current device connection status
         //   public virtual UInt32 GetConnectionStatus() const = 0;
         //   public virtual char* GetConnectionTypeName() const = 0;
         //   public virtual char* GetAdaptorName() const = 0;

         //   // device UUID
         //   public virtual char* GetGuid() const = 0;

         //   // device pairing necessity
         //   public virtual char* GetPairingNecessity() const = 0;

         //   public virtual UInt16 GetAuthenticationState() const = 0;

         //   // device SSH Support
         //   public virtual UInt32 GetSSHsupport() const = 0;
        };

        //public class ICrEnumCameraObjectInfo
        //{
        //    public virtual UInt32 GetCount() const = 0;
        //    //public virtual const ICrCameraObjectInfo* GetCameraObjectInfo(CrInt32u index) const = 0;

        //    //public virtual void Release() = 0;
        //}



        [StructLayout(LayoutKind.Sequential)]
        public struct ICrEnumCameraObjectInfo
        {
            public UInt32 Count;
            //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DefineConstants.SV_STRING_SIZE)]
            //public string uid;
            //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DefineConstants.SV_STRING_SIZE)]
            //public string displayName;
            //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DefineConstants.SV_STRING_SIZE)]
            //public string tlType;
            //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DefineConstants.SV_STRING_SIZE)]
            ////extra info gev specific
            //public string ipAddress;
            //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DefineConstants.SV_STRING_SIZE)]
            //public string subnetMask;
            //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DefineConstants.SV_STRING_SIZE)]
            //public string macAddress;

        } */
    }
}
