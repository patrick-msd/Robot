namespace RC.Lib.Vision.SVSVistek   
{
    //class SVSVistekContainer
    //{
    //    public SVSVistekApi myApi;
    //    public List<SVSVistekApi._SV_TL_INFO> sv_tl_info_list;
    //    public List<SVSVistekApi._SV_INTERFACE_INFO> sv_interface_info_list;
    //    public List<SVSVistekApi._SV_DEVICE_INFO> sv_Dev_info_list;
    //    public List<IntPtr> sv_cam_sys_hdl_list;
    //    public List<IntPtr> sv_interface_hdl_list;
    //    public List<SVSVistekCamera> Camlist;
    //    public bool initsdk_done;

    //    public SVSVistekContainer()
    //    {
    //        myApi = new SVSVistekApi();
    //        sv_tl_info_list = new List<SVSVistekApi._SV_TL_INFO>();
    //        sv_interface_info_list = new List<SVSVistekApi._SV_INTERFACE_INFO>();
    //        sv_cam_sys_hdl_list = new List<IntPtr>();
    //        sv_Dev_info_list = new List<SVSVistekApi._SV_DEVICE_INFO>();
    //        sv_interface_hdl_list = new List<IntPtr>();
    //        Camlist = new List<SVSVistekCamera>();

    //        initsdk_done = false;
    //    }

    //    ~SVSVistekContainer()
    //    {
    //        closeCameracontainer();
    //        sv_Dev_info_list.Clear();
    //        Camlist.Clear();
    //        sv_tl_info_list.Clear();
    //        sv_interface_info_list.Clear();
    //        sv_cam_sys_hdl_list.Clear();
    //        sv_interface_hdl_list.Clear();
    //    }

    //    public bool InitSDK()
    //    {
    //        if (initsdk_done)
    //        {
    //            return true;
    //        }

    //        string SVGenicamGentl = null;
    //        string SVGenicamRoot = null;
    //        string SVGenicamCache = null;
    //        string SVCLProtocol = null;
    //        bool is64Env = IntPtr.Size == 8;

    //        // Check whether the environment variable exists.
    //        SVGenicamRoot = Environment.GetEnvironmentVariable("SVS_GENICAM_ROOT");
    //        if (SVGenicamRoot == null)
    //        {
    //            Debug.WriteLine("GetEnvironmentVariableA SVS_GENICAM_ROOT failed! ");
    //            return false;
    //        }
    //        if (is64Env)
    //        {
    //            SVGenicamGentl = Environment.GetEnvironmentVariable("GENICAM_GENTL64_PATH");
    //            if (SVGenicamGentl == null)
    //            {
    //                Debug.WriteLine("GetEnvironmentVariableA GENICAM_GENTL64_PATH failed! ");
    //                return false;
    //            }
    //        }
    //        else
    //        {
    //            SVGenicamGentl = Environment.GetEnvironmentVariable("GENICAM_GENTL32_PATH");
    //            if (SVGenicamGentl == null)
    //            {
    //                Debug.WriteLine("GetEnvironmentVariableA GENICAM_GENTL32_PATH failed! ");
    //                return false;
    //            }
    //        }

    //        SVCLProtocol = Environment.GetEnvironmentVariable("SVS_GENICAM_CLPROTOCOL");
    //        if (SVCLProtocol == null)
    //        {
    //            Debug.WriteLine("GetEnvironmentVariableA SVS_GENICAM_CLPROTOCOL failed! ");
    //            return false;
    //        }

    //        SVGenicamCache = Environment.GetEnvironmentVariable("SVS_GENICAM_CACHE");
    //        if (SVGenicamCache == null)
    //        {
    //            Debug.WriteLine("GetEnvironmentVariableA SVS_GENICAM_CACHE failed! ");
    //            return false;
    //        }

    //        SVSVistekApi.SVSVistekApiReturn ret = myApi.SVS_LibInit(SVGenicamGentl, SVGenicamRoot, SVGenicamCache, SVCLProtocol);

    //        if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //        {
    //            Debug.WriteLine("SVS_LibInit  failed! ");
    //            return false;
    //        }

    //        initsdk_done = true;

    //        return true;
    //    }

    //    public void deviceDiscovery()
    //    {
    //        InitSDK();

    //        SVSVistekApi.SVSVistekApiReturn ret = SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS;

    //        //Open the System module
    //        UInt32 tlCount = 0;
    //        ret = myApi.SVS_LibSystemGetCount(ref tlCount);
    //        if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //        {
    //            Debug.WriteLine("GetEnvironmentVariableA SVS_GENICAM_CACHE failed! ");
    //            return;
    //        }

    //        uint timeout = 3000;
    //        bool bChanged = false;
    //        UInt32 numInterface = 0;

    //        // initialize device and get transport layer info
    //        for (UInt32 i = 0; i < tlCount; i++)
    //        {
    //            SVSVistekApi._SV_TL_INFO pInfoOut = new SVSVistekApi._SV_TL_INFO();

    //            ret = myApi.SVS_LibSystemGetInfo(i, ref pInfoOut);

    //            if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //            {
    //                continue;
    //            }

    //            string str = pInfoOut.tlType;
    //            if (0 != string.Compare("CL", str))
    //            {
    //                IntPtr sv_cam_sys_hdl = new IntPtr();
    //                ret = myApi.SVS_LibSystemOpen(i, ref sv_cam_sys_hdl);


    //                sv_cam_sys_hdl_list.Add(sv_cam_sys_hdl);
    //                myApi.SVS_SystemUpdateInterfaceList(sv_cam_sys_hdl, ref bChanged, timeout);

    //                ret = myApi.SVS_SystemGetNumInterfaces(sv_cam_sys_hdl, ref numInterface);
    //                for (uint j = 0; j < numInterface; j++)
    //                {

    //                    uint interfaceIdSize = 0;

    //                    string interfaceId = null;
    //                    interfaceIdSize = 512;
    //                    //Queries the ID of the interface at iIndex in the internal interface list .
    //                    ret = myApi.SVS_SystemGetInterfaceId(sv_cam_sys_hdl, j, ref interfaceId, ref interfaceIdSize);

    //                    if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //                    {
    //                        continue;
    //                    }


    //                    SVSVistekApi._SV_INTERFACE_INFO interfaceInfo = new SVSVistekApi._SV_INTERFACE_INFO();
    //                    ret = myApi.SVS_SystemInterfaceGetInfo(sv_cam_sys_hdl, interfaceId, ref interfaceInfo);
    //                    if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //                    {
    //                        continue;
    //                    }
    //                    sv_interface_info_list.Add(interfaceInfo);

    //                    // Queries the information about the interface on this System module
    //                    IntPtr hInterface = IntPtr.Zero;
    //                    ret = myApi.SVS_SystemInterfaceOpen(sv_cam_sys_hdl, interfaceId, ref hInterface);
    //                    if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //                    {
    //                        continue;
    //                    }

    //                    sv_interface_hdl_list.Add(hInterface);


    //                    //Updates the internal list of available devices on this interface.
    //                    ret = myApi.SVS_InterfaceUpdateDeviceList(hInterface, ref bChanged, timeout);
    //                    if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //                    {
    //                        continue;
    //                    }
    //                    //Queries the number of available devices on this interface
    //                    UInt32 numDevices = 0;
    //                    ret = myApi.SVS_InterfaceGetNumDevices(hInterface, ref numDevices);
    //                    if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //                    {
    //                        continue;
    //                    }

    //                    // Get device info for all available devices and add new device to the camera list.
    //                    for (UInt32 k = 0; k < numDevices; k++)
    //                    {
    //                        string deviceId = null;
    //                        uint deviceIdSize = 512;
    //                        ret = myApi.SVS_InterfaceGetDeviceId(hInterface, k, ref deviceId, ref deviceIdSize);
    //                        if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //                        {
    //                            continue;
    //                        }

    //                        SVSVistekApi._SV_DEVICE_INFO devInfo = new SVSVistekApi._SV_DEVICE_INFO();
    //                        ret = myApi.SVS_InterfaceDeviceGetInfo(hInterface, deviceId, ref devInfo);
    //                        sv_Dev_info_list.Add(devInfo);
    //                        sv_tl_info_list.Add(pInfoOut);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public void updateDevInfolist(uint timeout)
    //    {
    //        IntPtr hInterface = IntPtr.Zero;
    //        bool bChanged = false;
    //        sv_Dev_info_list.Clear();

    //        for (int j = 0; j < sv_interface_hdl_list.Count; j++)
    //        {
    //            hInterface = sv_interface_hdl_list.ElementAt(j);

    //            //Updates the internal list of available devices on this interface.
    //            SVSVistekApi.SVSVistekApiReturn ret = myApi.SVS_InterfaceUpdateDeviceList(hInterface, ref bChanged, timeout);
    //            if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //            {
    //                continue;
    //            }

    //            //Queries the number of available devices on this interface
    //            UInt32 numDevices = 0;
    //            ret = myApi.SVS_InterfaceGetNumDevices(hInterface, ref numDevices);
    //            if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //            {
    //                continue;
    //            }

    //            // Get device info for all available devices and add new device to the camera list.
    //            for (UInt32 k = 0; k < numDevices; k++)
    //            {
    //                string deviceId = null;
    //                uint deviceIdSize = 512;
    //                ret = myApi.SVS_InterfaceGetDeviceId(hInterface, k, ref deviceId, ref deviceIdSize);
    //                if (ret != SVSVistekApi.SVSVistekApiReturn.SV_ERROR_SUCCESS)
    //                {
    //                    continue;
    //                }

    //                SVSVistekApi._SV_DEVICE_INFO devInfo = new SVSVistekApi._SV_DEVICE_INFO();
    //                ret = myApi.SVS_InterfaceDeviceGetInfo(hInterface, deviceId, ref devInfo);
    //                sv_Dev_info_list.Add(devInfo);
    //            }
    //        }
    //    }

    //    public void closeCameracontainer()
    //    {
    //        if (Camlist.Count == 0)
    //            return;

    //        for (int j = 0; j < Camlist.Count; j++)
    //        {
    //            SVSVistekCamera cam = Camlist.ElementAt(j);
    //            cam.acquisitionStop();
    //            cam.StreamingChannelClose();
    //            cam.closeConnection();
    //            cam.featureInfolist.Clear();
    //        }

    //        sv_Dev_info_list.Clear();
    //        Camlist.Clear();

    //        for (int j = 0; j < sv_interface_hdl_list.Count; j++)
    //        {
    //            myApi.SVS_InterfaceClose(sv_interface_hdl_list.ElementAt(j));
    //        }

    //        for (int j = 0; j < sv_cam_sys_hdl_list.Count; j++)
    //        {
    //            myApi.SVS_SystemClose(sv_cam_sys_hdl_list.ElementAt(j));
    //        }
    //        myApi.SVS_LibClose();
    //    }
    //}
}
