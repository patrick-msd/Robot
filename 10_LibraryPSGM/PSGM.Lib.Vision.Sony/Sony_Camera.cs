using static PSGM.Lib.Vision.Sony.Sony_SDK;

namespace PSGM.Lib.Vision.Sony
{
    public partial class Sony_Camera
    {
        #region Global variables
        // DB link
        private Guid? _IdDb = null;
        public Guid? IdDb { get { return _IdDb; } set { _IdDb = value; } }

        // Robot
        private SonyCamerSDK.Sony _camera;
        public SonyCamerSDK.Sony Camera { get { return _camera; } set { _camera = value; } }

        private Sony_SDK _cameraa;
        //public Sony_SDK Cameraa { get { return _cameraa; } set { _cameraa = value; } }

        // TCP
        private string _ipAddress = "172.0.0.1";
        public string IpAddress { get { return _ipAddress; } }

        private int _port = 12345;
        public int Port { get { return _port; } }

        private int _connectionTimeout = 1000;
        public int ConnectionTimeout { get { return _connectionTimeout; } }

        // Robtor variables
        //public bool HasControlAuthority { get { return _robot._hasControlAuthority; } }

        float[] _axisDirection = new float[] { 1.000f, 1.000f, 1.000f, 1.000f, 1.000f, 1.000f };
        #endregion


        #region instance
        public Sony_Camera()
        {
            //_robot = new rcrobotdoosancontrol.doosan();
            _camera = new SonyCamerSDK.Sony();
            _cameraa = new Sony_SDK();
        }

        ~Sony_Camera()
        {
            // todo: ...

            //closeconnection();



            _camera = null;
            _cameraa = null;
        }
        #endregion


        #region Connection
        //public bool OpenConnection(string ipAddress = "172.0.0.1", int port = 0, int connectionTimeout = 1000)
        //{
        //    _ipAddress = ipAddress;
        //    _port = port;
        //    _connectionTimeout = connectionTimeout;

        //    return _robot.OpenConnection(ipAddress, (uint)port);
        //}

        //public bool CloseConnection()
        //{
        //    return _robot.CloseConnection();
        //}

        //// ToDo: ...
        ////public bool OpenRtConnection(string ipAddress = "172.0.0.1", int port = 0, int connectionTimeout = 1000)
        ////{
        ////    _ipAddress = ipAddress;
        ////    _port = port;
        ////    _connectionTimeout = connectionTimeout;

        ////    return _robot.OpenRtConnection(ipAddress, (uint)port);
        ////}

        //// ToDo: ...
        ////public bool CloseRtConnection()
        ////{
        ////    return _robot.CloseRtConnection();
        ////}
        #endregion


        #region Test
        public uint GetSDKVersion()
        {
            var asd = _cameraa.GetSDKVersion();
            var fgfg = _cameraa.GetSDKVersionSplit();

            bool sdd = _cameraa.Init();





            Sony_SDK SonyCameraAPI = new Sony_SDK();


            // Initialisiere die API
            if (!SonyCameraAPI.Init())
            {
                Console.WriteLine("Fehler bei der Initialisierung der API.");
                //return;
            }

            // Aufzählung der Kameras
            IntPtr enumCameraObjectInfoPtr;
            Error result = SonyCameraAPI.EnumCameraObjects(out enumCameraObjectInfoPtr);
            if (result != 0)
            {
                Console.WriteLine("Fehler bei der Aufzählung der Kameras.");
                SonyCameraAPI.Release();
                //return;
            }

            // Erstelle eine Instanz von EnumCameraObjectInfo
            EnumCameraObjectInfo enumCameraObjectInfo = new EnumCameraObjectInfo(enumCameraObjectInfoPtr);

            // Durchlaufe die Kameras und zeige Informationen an
            uint cameraCount = enumCameraObjectInfo.GetCount();
            for (uint i = 0; i < cameraCount; i++)
            {
                CameraObjectInfo cameraInfo = enumCameraObjectInfo.GetCameraObjectInfo(i);
                Console.WriteLine("Kamera Name: " + cameraInfo.GetName());
                Console.WriteLine("Kamera Modell: " + cameraInfo.GetModel());
                // Weitere Informationen können hier abgerufen werden
            }

            // Freigabe der Ressourcen
            enumCameraObjectInfo.Release();
            SonyCameraAPI.Release();
        }





















            return _camera.GetSDKVersion();
        }

        public uint[] GetSDKVersionSplit()
        {
            uint version = _camera.GetSDKVersion();

            uint major = (version & 0xFF000000) >> 24;
            uint minor = (version & 0x00FF0000) >> 16;
            uint patch = (version & 0x0000FF00) >> 8;

            return new uint[] { major, minor, patch };
        }


        public bool Init()
        {
            return _camera.Init();
        }

        public bool Release()
        {
            return _camera.Release();
        }

        public bool EnumCameraObjects()
        {
            _camera.EnumCameraObjects();
            int value = _camera.GetCameraCount();

            _camera.GetCameraObjectInfo(0);

            string ModelName = _camera.GetModelName();
            string ConnectionTypeName = _camera.GetConnectionTypeName();


            return false;
        }




        //int major = (version & 0xFF000000) >> 24;
        //int minor = (version & 0x00FF0000) >> 16;
        //int patch = (version & 0x0000FF00) >> 8;
        //// int reserved = (version & 0x000000FF);ance;


        #endregion


        //#region Configuration
        //void SetAxisDirection(float X, float Y, float Z, float A, float B, float C)
        //{
        //    _axisDirection[0] = X;
        //    _axisDirection[1] = Y;
        //    _axisDirection[2] = Z;
        //    _axisDirection[3] = A;
        //    _axisDirection[4] = B;
        //    _axisDirection[5] = C;

        //    _robot.SetAxisDirection(X, Y, Z, A, B, C);
        //}
        //#endregion


        //#region Attributes
        //public SystemVersion GetSystemVersion()
        //{
        //    return _robot.GetSystemVersion();
        //}

        //public string GetLibraryVersion()
        //{
        //    return _robot.GetLibraryVersion();
        //}


        //public RobotMode GetRobotMode()
        //{
        //    return _robot.GetRobotMode();
        //}

        //public bool SetRobotMode(RobotMode robotMode)
        //{
        //    return _robot.SetRobotMode(robotMode);
        //}


        //public RobotState GetRobotState()
        //{
        //    return _robot.GetRobotState();
        //}

        //public bool SetRobotControl(RobotControl robotControl)
        //{
        //    return _robot.SetRobotControl(robotControl);
        //}

        //public ControlMode GetControlMode()
        //{
        //    return _robot.GetControlMode();
        //}


        //public RobotSystem GetRobotSystem()
        //{
        //    return _robot.GetRobotSystem();
        //}

        //public bool SetRobotSystem(RobotSystem robotSystem)
        //{
        //    return _robot.SetRobotSystem(robotSystem);
        //}


        //public bool SetRobotSpeedMode(MonitoringSpeed robotMode)
        //{
        //    return _robot.SetRobotSpeedMode(robotMode);
        //}

        //public MonitoringSpeed GetRobotSpeedMode()
        //{
        //    return _robot.GetRobotSpeedMode();
        //}


        //public RobotPose GetCurrentPose(RobotSpace robotSpace)
        //{
        //    return _robot.GetCurrentPose(robotSpace);
        //}

        //// ToDo: ...
        ////public float[] GetCurrentRotm(...)
        ////{
        ////    return _robot.GetCurrentRotm(...);
        ////}

        //public byte GetCurrentSolutionSpace()
        //{
        //    return _robot.GetCurrentSolutionSpace();
        //}

        //public byte GetSolutionSpace(float[] targetPos)
        //{
        //    return _robot.GetSolutionSpace(targetPos);
        //}


        //public RobotPose GetCurrentPosj()
        //{
        //    return _robot.GetCurrentPosj();
        //}

        //public RobotSpace GetControlSpace()
        //{
        //    return _robot.GetControlSpace();
        //}

        //public RobotVel GetCurrentVelj()
        //{
        //    return _robot.GetCurrentVelj();
        //}

        //public RobotPose GetDesiredPosj()
        //{
        //    return _robot.GetDesiredPosj();
        //}

        //public RobotPose GetCurnetToolFlangePosx()
        //{
        //    return _robot.GetCurnetToolFlangePosx();
        //}

        //public RobotVel GetCurrentVelx()
        //{
        //    return _robot.GetCurrentVelx();
        //}

        //// ToDo: ...
        //// public LPROBOT_POSE get_desired_posx()
        //// {
        ////      return _GetDesiredPosX(_rbtCtrl);
        //// };

        //public RobotPose GetDesiredPosx()
        //{
        //    return _robot.GetDesiredPosx();
        //}

        //public RobotVel GetDesiredVelx()
        //{
        //    return _robot.GetDesiredVelx();
        //}

        //public RobotForce GetJointTorque()
        //{
        //    return _robot.GetJointTorque();
        //}

        //public RobotForce GetExternalTorque()
        //{
        //    return _robot.GetExternalTorque();
        //}

        //public RobotForce GetToolForce()
        //{
        //    return _robot.GetToolForce();
        //}


        //public DrlProgramState GetProgramState()
        //{
        //    return _robot.GetProgramState();
        //}

        //public void SetSafeStopResetType(SafeStopResetType resetType)
        //{
        //    _robot.SetSafeStopResetType(resetType);
        //}

        //public LogAlarm GetLastAlarm()
        //{
        //    return _robot.GetLastAlarm();
        //}


        //public float GetOrientationError(float[] fPosition1, float[] fPosition2, TaskAxis taskAxis)
        //{
        //    return _robot.GetOrientationError(fPosition1, fPosition2, taskAxis);
        //}
        //#endregion


        //#region Access control
        //bool ManageAccessControll(ManageAccessControl accessControl)
        //{
        //    return _robot.ManageAccessControll(accessControl);
        //}
        //#endregion

        //#region Callback


        //#endregion

        //#region Robot




        //public RobotTaskPose GetCurrentPosx()
        //{
        //    return _robot.GetCurrentPosx();
        //}




        ////public double GetOverrideSpeed()
        ////{
        ////    return _robot.GetOverrideSpeed();
        ////}

        //public float GetWorkpieceWeight()
        //{
        //    return _robot.GetWorkpieceWeight();
        //}

        //public bool ResetWorkpieceWeight()
        //{
        //    return _robot.ResetWorkpieceWeight();
        //}

        //public bool TpPopupResponse(PopupResponse popupResponse)
        //{
        //    return _robot.TpPopupResponse(popupResponse);
        //}

        //bool TpGetUserInputResponse(string UserInputResponse)
        //{
        //    return _robot.TpGetUserInputResponse(UserInputResponse);
        //}
        //#endregion


        //#region Motion operations


        //#endregion











        //public bool SetupMonitoringVersion(int setupMonitoringVersion)
        //{
        //    return _robot.SetupMonitoringVersion(setupMonitoringVersion);
        //}












        //public bool SetDigitalOutput(GpioCtrlboxDigitalIndex gpioCtrlboxDigitalIndex, bool value)
        //{
        //    return _robot.SetDigitalOutput(gpioCtrlboxDigitalIndex, value);
        //}

        //public bool GetDigitalInput(GpioCtrlboxDigitalIndex gpioCtrlboxDigitalIndex)
        //{
        //    return _robot.GetDigitalInput(gpioCtrlboxDigitalIndex);
        //}

        //public bool SetAnalogOutput(GpioCtrlboxAnalogIndex gpioCtrlboxAnalogIndex, float value)
        //{
        //    return _robot.SetAnalogOutput(gpioCtrlboxAnalogIndex, value);
        //}

        //public float GetAnalogInput(GpioCtrlboxAnalogIndex gpioCtrlboxAnalogIndex)
        //{
        //    return _robot.GetAnalogInput(gpioCtrlboxAnalogIndex);
        //}

        //public bool AddTool(string symbol, float weight, float[] centerOfGravitiy, float[] inertiaValue)
        //{
        //    return _robot.AddTool(symbol, weight, centerOfGravitiy, inertiaValue);
        //}

        //public bool SetTool(string symbol)
        //{
        //    return _robot.SetTool(symbol);
        //}
        //public string GetTool()
        //{
        //    return _robot.GetTool();
        //}

        //public bool AddTCP(string symbol, float[] centerPosition)
        //{
        //    return _robot.AddTCP(symbol, centerPosition);
        //}

        //public bool SetTCP(string symbol)
        //{
        //    return _robot.SetTCP(symbol);
        //}

        //public string GetTCP()
        //{
        //    return _robot.GetTCP();
        //}



        //public bool MoveL(float[] targetPos, float[] targetVel, float[] targetAcc, float targetTime = 0.000f, MoveMode moveMode = MoveMode.MOVE_MODE_ABSOLUTE, MoveReference moveReference = MoveReference.MOVE_REFERENCE_BASE, float blendingRadius = 0.000f, BlendingSpeedType blendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE)
        //{
        //    return _robot.MoveL(targetPos, targetVel, targetAcc, targetTime, moveMode, moveReference, blendingRadius, blendingSpeedType);
        //}

        //public bool MoveLAsync(float[] targetPos, float[] targetVel, float[] targetAcc, float targetTime = 0.000f, MoveMode moveMode = MoveMode.MOVE_MODE_ABSOLUTE, MoveReference moveReference = MoveReference.MOVE_REFERENCE_BASE, BlendingSpeedType blendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE)
        //{
        //    return _robot.MoveLAsync(targetPos, targetVel, targetAcc, targetTime, moveMode, moveReference, blendingSpeedType);
        //}








        //public bool ChangeOperationSpeed(float operationSpeed)
        //{
        //    return _robot.ChangeOperationSpeed(operationSpeed);
        //}

        //public bool Stop(StopType stopType)
        //{
        //    return _robot.Stop(stopType);
        //}




        //public void RegisterEvents()
        //{
        //    //Register the callback
        //    _robot.ManagedTOnHommingCompletedCBHandler += OnHommingCompleted;
        //    ////_robot.ManagedTOnMonitoringDataCBHandler += OnMonitoringDataCB1;
        //    ////_robot.ManagedTOnMonitoringDataExCBHandler += OnMonitoringDataExCB1;
        //    ////_robot.ManagedTOnMonitoringCtrlIOCBHandler += OnMonitoringCtrlIOCB1;
        //    ////_robot.ManagedTOnMonitoringCtrlIOExCBHandler += OnMonitoringCtrlIOExCB1;
        //    ////_robot.ManagedTOnMonitoringStateCBHandler += OnMonitoringStateCB1;
        //    ////_robot.ManagedTOnMonitoringAccessControlCBHandler += OnMonitoingAccessControlCB1;
        //    _robot.ManagedTOnTpInitializingCompletedCBHandler += OnTpInitializingCompleted;
        //    ////_robot.ManagedTOnLogAlarmCBHandler += OnLogAlarm1;
        //    ////_robot.ManagedTOnProgramStoppedCBHandler += OnProgramStopped1;
        //    _robot.ManagedTOnDisconnectedCBHandler += OnDisconnected;
        //}



















    }
}
