#include "pch.h"
#include <msclr\marshal_cppstd.h>

#include "ControlEx.h"
#include "ControlC.h"
#include "ControlS.h"

using namespace std;
using namespace System;
using namespace System::IO;

namespace PSGMRobotDoosanControl
{
	////////////////////////////////////////////////////////////////////////////
	// Instance                                                               //
	////////////////////////////////////////////////////////////////////////////
	Doosan::Doosan()
	{
		_rbtCtrl = DRAFramework::_CreateRobotControl();

		_axisDirection = new float[NUM_TASK] { 1.00, 1.00, 1.00, 1.00, 1.00, 1.00 };

		// Initialisation Callback functions
		//ManagedTOnMonitoringStateCB^ OnMonitoringState = gcnew ManagedTOnMonitoringStateCB(this, &Doosan::OnMonitoringStateCB);
		//IntPtr OnMonitoringState_prt = Marshal::GetFunctionPointerForDelegate(OnMonitoringState);
		//DRAFramework::_set_on_monitoring_state(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringStateCB>(OnMonitoringState_prt.ToPointer()));
		//GC::KeepAlive(OnMonitoringState);
		//GC::KeepAlive(ManagedTOnMonitoringStateCBHandler);

		//ManagedTOnMonitoringDataCB^ OnMonitoringDataCB = gcnew ManagedTOnMonitoringDataCB(this, &Doosan::OnMonitoringDataCB);
		//IntPtr OnMonitoringDataCB_prt = Marshal::GetFunctionPointerForDelegate(OnMonitoringDataCB);
		//DRAFramework::_set_on_monitoring_data(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringDataCB>(OnMonitoringDataCB_prt.ToPointer()));
		//GC::KeepAlive(OnMonitoringDataCB);
		//GC::KeepAlive(ManagedTOnMonitoringDataCBHandler);

		//ManagedTOnMonitoringDataExCB^ OnMonitoringDataEx = gcnew ManagedTOnMonitoringDataExCB(this, &Doosan::OnMonitoringDataExCB);
		//IntPtr OnMonitoringDataEx_ptr = Marshal::GetFunctionPointerForDelegate(OnMonitoringDataEx);
		//DRAFramework::_set_on_monitoring_data_ex(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringDataExCB>(OnMonitoringDataEx_ptr.ToPointer()));
		//GC::KeepAlive(OnMonitoringDataEx_ptr);
		//GC::KeepAlive(OnMonitoringDataEx);
		//GC::KeepAlive(ManagedTOnMonitoringDataExCBHandler);

		//ManagedTOnMonitoringCtrlIOCB^ OnMonitoringCtrlIOCB = gcnew ManagedTOnMonitoringCtrlIOCB(this, &Doosan::OnMonitoringCtrlIO);
		//IntPtr OnMonitoringCtrlIOCB_ptr = Marshal::GetFunctionPointerForDelegate(OnMonitoringCtrlIOCB);
		//DRAFramework::_set_on_monitoring_ctrl_io(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringCtrlIOCB>(OnMonitoringCtrlIOCB_ptr.ToPointer()));
		//GC::KeepAlive(OnMonitoringCtrlIOCB);
		//GC::KeepAlive(ManagedTOnMonitoringCtrlIOCBHandler);

		//ManagedTOnMonitoringCtrlIOExCB^ OnMonitoringCtrlIOExCB = gcnew ManagedTOnMonitoringCtrlIOExCB(this, &Doosan::OnMonitoringCtrlIOEx);
		//IntPtr OnMonitoringCtrlIOExCB_ptr = Marshal::GetFunctionPointerForDelegate(OnMonitoringCtrlIOExCB);
		//DRAFramework::_set_on_monitoring_ctrl_io_ex(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringCtrlIOExCB>(OnMonitoringCtrlIOExCB_ptr.ToPointer()));
		//GC::KeepAlive(OnMonitoringCtrlIOExCB);
		//GC::KeepAlive(ManagedTOnMonitoringCtrlIOExCBHandler);

		//ManagedTOnMonitoringModbusCB^ OnMonitoringModbusCB = gcnew ManagedTOnMonitoringModbusCB(this, &Doosan::OnMonitoringModbus);
		//IntPtr OnMonitoringModbusCB_ptr = Marshal::GetFunctionPointerForDelegate(OnMonitoringModbusCB);
		//DRAFramework::_set_on_monitoring_modbus(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringModbusCB>(OnMonitoringModbusCB_ptr.ToPointer()));
		//GC::KeepAlive(OnMonitoringModbusCB);
		//GC::KeepAlive(ManagedTOnMonitoringModbusCBHandler);

		//ManagedTOnMonitoringSpeedModeCB^ OnMonitoringSpeedModeCB = gcnew ManagedTOnMonitoringSpeedModeCB(this, &Doosan::OnMonitoringSpeedMode);
		//IntPtr OnMonitoringSpeedModeCB_ptr = Marshal::GetFunctionPointerForDelegate(OnMonitoringSpeedModeCB);
		//DRAFramework::_set_on_monitoring_speed_mode(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringSpeedModeCB>(OnMonitoringSpeedModeCB_ptr.ToPointer()));
		//GC::KeepAlive(OnMonitoringSpeedModeCB);
		//GC::KeepAlive(ManagedTOnMonitoringSpeedModeCBHandler);

		//ManagedTOnMonitoringAccessControlCB^ OnMonitoringAccessControl = gcnew ManagedTOnMonitoringAccessControlCB(this, &Doosan::OnMonitoringAccessControlCB);
		//IntPtr OnMonitoringAccessControl_ptr = Marshal::GetFunctionPointerForDelegate(OnMonitoringAccessControl);
		//DRAFramework::_set_on_monitoring_access_control(_rbtCtrl, static_cast<DRAFramework::TOnMonitoringAccessControlCB>(OnMonitoringAccessControl_ptr.ToPointer()));
		//GC::KeepAlive(OnMonitoringAccessControl);
		//GC::KeepAlive(ManagedTOnMonitoringAccessControlCBHandler);

		//ManagedTOnLogAlarmCB^ OnLogAlarm = gcnew ManagedTOnLogAlarmCB(this, &Doosan::OnLogAlarmCB);
		//IntPtr OnLogAlarm_ptr = Marshal::GetFunctionPointerForDelegate(OnLogAlarm);
		//DRAFramework::_set_on_log_alarm(_rbtCtrl, static_cast<DRAFramework::TOnLogAlarmCB>(OnLogAlarm_ptr.ToPointer()));
		//GC::KeepAlive(OnLogAlarm);
		//GC::KeepAlive(ManagedTOnLogAlarmCBHandler);

		//ManagedTOnTpPopupCB^ OnTpPopupCB = gcnew ManagedTOnTpPopupCB(this, &Doosan::OnTpPopup);
		//IntPtr OnTpPopupCB_ptr = Marshal::GetFunctionPointerForDelegate(OnTpPopupCB);
		//DRAFramework::_set_on_tp_popup(_rbtCtrl, static_cast<DRAFramework::TOnTpPopupCB>(OnTpPopupCB_ptr.ToPointer()));
		//GC::KeepAlive(OnTpPopupCB);
		//GC::KeepAlive(ManagedTOnTpPopupCBHandler);

		//ManagedTOnTpLogCB^ OnTpLogCB = gcnew ManagedTOnTpLogCB(this, &Doosan::OnTpLog);
		//IntPtr OnTpLogCB_ptr = Marshal::GetFunctionPointerForDelegate(OnTpLogCB);
		//DRAFramework::_set_on_tp_log(_rbtCtrl, static_cast<DRAFramework::TOnTpLogCB>(OnTpLogCB_ptr.ToPointer()));
		//GC::KeepAlive(OnTpLogCB);
		//GC::KeepAlive(ManagedTOnTpLogCBHandler);

		//ManagedTOnTpProgressCB^ OnTpProgressCB = gcnew ManagedTOnTpProgressCB(this, &Doosan::OnTpProgress);
		//IntPtr OnTpProgressCB_ptr = Marshal::GetFunctionPointerForDelegate(OnTpProgressCB);
		//DRAFramework::_set_on_tp_progress(_rbtCtrl, static_cast<DRAFramework::TOnTpProgressCB>(OnTpProgressCB_ptr.ToPointer()));
		//GC::KeepAlive(OnTpProgressCB);
		//GC::KeepAlive(ManagedTOnTpProgressCBHandler);

		//ManagedTOnTpGetUserInputCB^ OnTpGetUserInputCB = gcnew ManagedTOnTpGetUserInputCB(this, &Doosan::OnTpGetUserInputCB);
		//IntPtr OnTpGetUserInputCB_ptr = Marshal::GetFunctionPointerForDelegate(OnTpGetUserInputCB);
		//DRAFramework::_set_on_tp_get_user_input(_rbtCtrl, static_cast<DRAFramework::TOnTpGetUserInputCB>(OnTpGetUserInputCB_ptr.ToPointer()));
		//GC::KeepAlive(OnTpGetUserInputCB);
		//GC::KeepAlive(ManagedTOnTpGetUserInputCBHandler);

		//ManagedTOnProgramStoppedCB^ OnProgramStoppedCB = gcnew ManagedTOnProgramStoppedCB(this, &Doosan::OnProgramStopped);
		//IntPtr OnProgramStoppedCB_ptr = Marshal::GetFunctionPointerForDelegate(OnProgramStoppedCB);
		//DRAFramework::_set_on_program_stopped(_rbtCtrl, static_cast<DRAFramework::TOnProgramStoppedCB>(OnProgramStoppedCB_ptr.ToPointer()));
		//GC::KeepAlive(OnProgramStoppedCB);
		//GC::KeepAlive(ManagedTOnProgramStoppedCBHandler);

		ManagedTOnHommingCompletedCB^ OnHommingCompleted = gcnew ManagedTOnHommingCompletedCB(this, &Doosan::OnHommingCompletedCB);
		IntPtr OnHommingCompleted_ptr = Marshal::GetFunctionPointerForDelegate(OnHommingCompleted);
		DRAFramework::_set_on_homming_completed(_rbtCtrl, static_cast<DRAFramework::TOnHommingCompletedCB>(OnHommingCompleted_ptr.ToPointer()));
		GC::KeepAlive(OnHommingCompleted);
		GC::KeepAlive(ManagedTOnHommingCompletedCBHandler);

		ManagedTOnTpInitializingCompletedCB^ OnTpInitializingCompleted = gcnew ManagedTOnTpInitializingCompletedCB(this, &Doosan::OnTpInitializingCompletedCB);
		IntPtr OnTpInitializingCompleted_ptr = Marshal::GetFunctionPointerForDelegate(OnTpInitializingCompleted);
		DRAFramework::_set_on_tp_initializing_completed(_rbtCtrl, static_cast<DRAFramework::TOnTpInitializingCompletedCB>(OnTpInitializingCompleted_ptr.ToPointer()));
		GC::KeepAlive(OnTpInitializingCompleted);
		GC::KeepAlive(ManagedTOnTpInitializingCompletedCBHandler);

		//ManagedTOnMasteringNeedCB^ OnMasteringNeedCB = gcnew ManagedTOnMasteringNeedCB(this, &Doosan::SetOnMasteringNeed);
		//IntPtr OnMasteringNeedCB_ptr = Marshal::GetFunctionPointerForDelegate(OnMasteringNeedCB);
		//DRAFramework::_set_on_mastering_need(_rbtCtrl, static_cast<DRAFramework::TOnMasteringNeedCB>(OnMasteringNeedCB_ptr.ToPointer()));
		//GC::KeepAlive(OnMasteringNeedCB);
		//GC::KeepAlive(ManagedTOnMasteringNeedCBHandler);

		ManagedTOnDisconnectedCB^ OnDisconnectedCB = gcnew ManagedTOnDisconnectedCB(this, &Doosan::OnDisconnected);
		IntPtr OnDisconnectedCB_ptr = Marshal::GetFunctionPointerForDelegate(OnDisconnectedCB);
		DRAFramework::_set_on_disconnected(_rbtCtrl, static_cast<DRAFramework::TOnDisconnectedCB>(OnDisconnectedCB_ptr.ToPointer()));
		GC::KeepAlive(OnDisconnectedCB);
		GC::KeepAlive(ManagedTOnDisconnectedCBHandler);
	}

	Doosan::~Doosan()
	{
		if (_rbtCtrl != nullptr)
		{
			DRAFramework::_DestroyRobotControl(_rbtCtrl);

			delete _rbtCtrl;
			_rbtCtrl = nullptr;

			delete _axisDirection;
		}
	}

	Doosan::!Doosan()
	{
		if (_rbtCtrl != nullptr)
		{
			delete _rbtCtrl;
			_rbtCtrl = nullptr;

			delete _axisDirection;
		}
	}

	////////////////////////////////////////////////////////////////////////////
	// Connection                                                             //
	////////////////////////////////////////////////////////////////////////////
	bool Doosan::OpenConnection(String^ ipAddress, unsigned int port)
	{
		if (nullptr != _rbtCtrl)
		{
			// Set default parameters
			if (String::IsNullOrEmpty(ipAddress)) { ipAddress = "192.168.137.50"; }
			if (port == 0) { port = 12345; }

			return DRAFramework::_open_connection(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(ipAddress), port);
		}
		else
		{
			return false;
		}
	}

	bool Doosan::CloseConnection()
	{
		if (nullptr != _rbtCtrl)
		{
			return DRAFramework::_close_connection(_rbtCtrl);
		}
		else
		{
			return false;
		}
	}

	// ToDo: ...
	//bool Doosan::OpenRtConnection(String^ ipAddress, unsigned int port)
	//{
	//	if (nullptr != _rbtCtrl)
	//	{
	//		// Set default parameters
	//		if (String::IsNullOrEmpty(ipAddress)) { ipAddress = "192.168.137.50"; }
	//		if (port == 0) { port = 12347; }

	//		return DRAFramework::_connect_rt_control(_rbtCtrl, msclr::interop::marshal_as<std::string>(ipAddress).c_str(), port);
	//	}
	//	else
	//	{
	//		return false;
	//	}
	//}

	// ToDo: ...
	//bool Doosan::CloseRtConnection()
	//{
	//	if (nullptr != _rbtCtrl)
	//	{
	//		DRAFramework::_close_rt_connection(_rbtCtrl);
	//	}
	//	else
	//	{
	//		return false;
	//	}
	//}


	////////////////////////////////////////////////////////////////////////////
	// Configuration                                                          //
	////////////////////////////////////////////////////////////////////////////
	void Doosan::SetAxisDirection(float X, float Y, float Z, float A, float B, float C)
	{
		_axisDirection[0] = X;
		_axisDirection[1] = Y;
		_axisDirection[2] = Z;
		_axisDirection[3] = A;
		_axisDirection[4] = B;
		_axisDirection[5] = X;
	}


	////////////////////////////////////////////////////////////////////////////
	// Attributes                                                             //
	////////////////////////////////////////////////////////////////////////////
	SystemVersion Doosan::GetSystemVersion()
	{
		SYSTEM_VERSION dataC = { '\0', };
		SystemVersion dataWrapper{};

		DRAFramework::_get_system_version(_rbtCtrl, &dataC);

		dataWrapper._szController = gcnew String(dataC._szController);
		dataWrapper._szFlangeBoard = gcnew String(dataC._szFlangeBoard);
		dataWrapper._szInterpreter = gcnew String(dataC._szInterpreter);
		dataWrapper._szInverter = gcnew String(dataC._szInverter);
		dataWrapper._szJTSBoard = gcnew String(dataC._szJTSBoard);
		dataWrapper._szRobotModel = gcnew String(dataC._szRobotModel);
		dataWrapper._szRobotSerial = gcnew String(dataC._szRobotSerial);
		dataWrapper._szSafetyBoard = gcnew String(dataC._szSafetyBoard);
		dataWrapper._szSmartTp = gcnew String(dataC._szSmartTp);

		return dataWrapper;
	};

	String^ Doosan::GetLibraryVersion()
	{
		return gcnew String(DRAFramework::_get_library_version(_rbtCtrl));
	};


	RobotMode Doosan::GetRobotMode()
	{
		return static_cast<RobotMode>(DRAFramework::_get_robot_mode(_rbtCtrl));
	};

	bool Doosan::SetRobotMode(RobotMode robotMode)
	{
		return DRAFramework::_set_robot_mode(_rbtCtrl, static_cast<ROBOT_MODE>(robotMode));
	};


	RobotState Doosan::GetRobotState()
	{
		return static_cast<RobotState>(DRAFramework::_get_robot_state(_rbtCtrl));
	};

	bool Doosan::SetRobotControl(RobotControl robotControl)
	{
		return DRAFramework::_SetRobotControl(_rbtCtrl, safe_cast<ROBOT_CONTROL>(robotControl));
	};

	ControlMode Doosan::GetControlMode()
	{
		return static_cast<ControlMode>(DRAFramework::_get_control_mode(_rbtCtrl));
	};


	RobotSystem Doosan::GetRobotSystem()
	{
		return static_cast<RobotSystem>(DRAFramework::_get_robot_system(_rbtCtrl));
	};

	bool Doosan::SetRobotSystem(RobotSystem robotSystem)
	{
		return DRAFramework::_set_robot_system(_rbtCtrl, static_cast<ROBOT_SYSTEM>(robotSystem));
	};


	bool Doosan::SetRobotSpeedMode(SpeedMode speedMode)
	{
		return DRAFramework::_set_robot_speed_mode(_rbtCtrl, static_cast<SPEED_MODE>(speedMode));
	}

	SpeedMode Doosan::GetRobotSpeedMode()
	{
		return static_cast<SpeedMode>(DRAFramework::_get_robot_speed_mode(_rbtCtrl));
	};


	RobotPose Doosan::GetCurrentPose(RobotSpace spaceType)
	{
		//// Set default parameters
		//if (resetType.IsDefined == true) { resetType = ROBOT_SPACE_JOINT; }

		LPROBOT_POSE dataC = DRAFramework::_get_current_pose(_rbtCtrl, static_cast<ROBOT_SPACE>(spaceType));
		RobotPose dataWrapper{};

		// Initialisation
		dataWrapper._fPosition = gcnew cli::array<float>(NUM_JOINT);

		// Cast
		dataWrapper._fPosition[0] = dataC->_fPosition[0];
		dataWrapper._fPosition[1] = dataC->_fPosition[1];
		dataWrapper._fPosition[2] = dataC->_fPosition[2];
		dataWrapper._fPosition[3] = dataC->_fPosition[3];
		dataWrapper._fPosition[4] = dataC->_fPosition[4];
		dataWrapper._fPosition[5] = dataC->_fPosition[5];

		return dataWrapper;
	};

	//cli::array<float>^ RCDoosan::GetCurrentRotm(Nullable<RCCoordinateSystem> targetRef)
	//{
	//#pragma region Set default parameters
	//	COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
	//	if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }
	//#pragma endregion
	//
	//	float returnC = 
	//	float returnValue[3]{};
	//	returnValue = _rbtCtrl->get_current_rotm(targetRefC);
	//
	//	return returnValue;
	//};

	unsigned char Doosan::GetCurrentSolutionSpace()
	{
		return DRAFramework::_get_current_solution_space(_rbtCtrl);
	};


	unsigned char Doosan::GetSolutionSpace(cli::array<float>^ targetPos)
	{
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		return DRAFramework::_get_solution_space(_rbtCtrl, targetPosC);
	};

	RobotPose Doosan::GetCurrentPosj()
	{
		LPROBOT_POSE dataC = DRAFramework::_get_current_posj(_rbtCtrl);
		RobotPose dataWrapper{};

		// Initialisation
		dataWrapper._fPosition = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fPosition[0] = dataC->_fPosition[0];
		dataWrapper._fPosition[1] = dataC->_fPosition[1];
		dataWrapper._fPosition[2] = dataC->_fPosition[2];
		dataWrapper._fPosition[3] = dataC->_fPosition[3];
		dataWrapper._fPosition[4] = dataC->_fPosition[4];
		dataWrapper._fPosition[5] = dataC->_fPosition[5];

		return dataWrapper;
	};

	RobotSpace Doosan::GetControlSpace()
	{
		return static_cast<RobotSpace>(DRAFramework::_get_control_space(_rbtCtrl));
	};

	RobotVel Doosan::GetCurrentVelj()
	{
		LPROBOT_VEL dataC = DRAFramework::_get_current_velj(_rbtCtrl);
		RobotVel dataWrapper{};

		// Initialisation
		dataWrapper._fVelocity = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fVelocity[0] = dataC->_fVelocity[0];
		dataWrapper._fVelocity[1] = dataC->_fVelocity[1];
		dataWrapper._fVelocity[2] = dataC->_fVelocity[2];
		dataWrapper._fVelocity[3] = dataC->_fVelocity[3];
		dataWrapper._fVelocity[4] = dataC->_fVelocity[4];
		dataWrapper._fVelocity[5] = dataC->_fVelocity[5];

		return dataWrapper;
	};

	RobotPose Doosan::GetDesiredPosj()
	{
		LPROBOT_POSE dataC = DRAFramework::_get_desired_posj(_rbtCtrl);
		RobotPose dataWrapper{};

		// Initialisation
		dataWrapper._fPosition = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fPosition[0] = dataC->_fPosition[0];
		dataWrapper._fPosition[1] = dataC->_fPosition[1];
		dataWrapper._fPosition[2] = dataC->_fPosition[2];
		dataWrapper._fPosition[3] = dataC->_fPosition[3];
		dataWrapper._fPosition[4] = dataC->_fPosition[4];
		dataWrapper._fPosition[5] = dataC->_fPosition[5];

		return dataWrapper;
	};

	RobotPose Doosan::GetCurnetToolFlangePosx()
	{
		LPROBOT_POSE dataC = DRAFramework::_get_current_tool_flange_posx(_rbtCtrl);
		RobotPose dataWrapper{};

		// Initialisation
		dataWrapper._fPosition = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fPosition[0] = dataC->_fPosition[0];
		dataWrapper._fPosition[1] = dataC->_fPosition[1];
		dataWrapper._fPosition[2] = dataC->_fPosition[2];
		dataWrapper._fPosition[3] = dataC->_fPosition[3];
		dataWrapper._fPosition[4] = dataC->_fPosition[4];
		dataWrapper._fPosition[5] = dataC->_fPosition[5];

		return dataWrapper;
	};

	RobotVel Doosan::GetCurrentVelx()
	{
		LPROBOT_VEL dtataC = DRAFramework::_get_current_velx(_rbtCtrl);
		RobotVel dataWrapper{};

		// Initialisation
		dataWrapper._fVelocity = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fVelocity[0] = dtataC->_fVelocity[0];
		dataWrapper._fVelocity[1] = dtataC->_fVelocity[1];
		dataWrapper._fVelocity[2] = dtataC->_fVelocity[2];
		dataWrapper._fVelocity[3] = dtataC->_fVelocity[3];
		dataWrapper._fVelocity[4] = dtataC->_fVelocity[4];
		dataWrapper._fVelocity[5] = dtataC->_fVelocity[5];

		return dataWrapper;
	};

	// get target task position
	// LPROBOT_POSE get_desired_posx()
	// {
	//		return _GetDesiredPosX(_rbtCtrl);
	// };

	RobotPose Doosan::GetDesiredPosx()
	{
		LPROBOT_POSE dataC = DRAFramework::_get_desired_posx(_rbtCtrl);
		RobotPose dataWrapper{};

		// Initialisation
		dataWrapper._fPosition = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fPosition[0] = dataC->_fPosition[0];
		dataWrapper._fPosition[1] = dataC->_fPosition[1];
		dataWrapper._fPosition[2] = dataC->_fPosition[2];
		dataWrapper._fPosition[3] = dataC->_fPosition[3];
		dataWrapper._fPosition[4] = dataC->_fPosition[4];
		dataWrapper._fPosition[5] = dataC->_fPosition[5];

		return dataWrapper;
	};


	RobotVel Doosan::GetDesiredVelx()
	{
		LPROBOT_VEL dataC = DRAFramework::_get_desired_velx(_rbtCtrl);
		RobotVel dataWrapper{};

		// Initialisation
		dataWrapper._fVelocity = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fVelocity[0] = dataC->_fVelocity[0];
		dataWrapper._fVelocity[1] = dataC->_fVelocity[1];
		dataWrapper._fVelocity[2] = dataC->_fVelocity[2];
		dataWrapper._fVelocity[3] = dataC->_fVelocity[3];
		dataWrapper._fVelocity[4] = dataC->_fVelocity[4];
		dataWrapper._fVelocity[5] = dataC->_fVelocity[5];

		return dataWrapper;
	};

	RobotForce Doosan::GetJointTorque()
	{
		LPROBOT_FORCE dataC = DRAFramework::_get_joint_torque(_rbtCtrl);
		RobotForce dataWrapper{};

		// Initialisation
		dataWrapper._fForce = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fForce[0] = dataC->_fForce[0];
		dataWrapper._fForce[1] = dataC->_fForce[1];
		dataWrapper._fForce[2] = dataC->_fForce[2];
		dataWrapper._fForce[3] = dataC->_fForce[3];
		dataWrapper._fForce[4] = dataC->_fForce[4];
		dataWrapper._fForce[5] = dataC->_fForce[5];

		return dataWrapper;
	};

	RobotForce Doosan::GetExternalTorque()
	{
		LPROBOT_FORCE dataC = DRAFramework::_get_external_torque(_rbtCtrl);
		RobotForce dataWrapper{};

		// Initialisation
		dataWrapper._fForce = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fForce[0] = dataC->_fForce[0];
		dataWrapper._fForce[1] = dataC->_fForce[1];
		dataWrapper._fForce[2] = dataC->_fForce[2];
		dataWrapper._fForce[3] = dataC->_fForce[3];
		dataWrapper._fForce[4] = dataC->_fForce[4];
		dataWrapper._fForce[5] = dataC->_fForce[5];

		return dataWrapper;
	};

	RobotForce Doosan::GetToolForce()
	{
		LPROBOT_FORCE dataC = DRAFramework::_get_tool_force(_rbtCtrl);
		RobotForce dataWrapper{};

		// Initialisation
		dataWrapper._fForce = gcnew cli::array<float>(6);

		// Cast
		dataWrapper._fForce[0] = dataC->_fForce[0];
		dataWrapper._fForce[1] = dataC->_fForce[1];
		dataWrapper._fForce[2] = dataC->_fForce[2];
		dataWrapper._fForce[3] = dataC->_fForce[3];
		dataWrapper._fForce[4] = dataC->_fForce[4];
		dataWrapper._fForce[5] = dataC->_fForce[5];

		return dataWrapper;
	};


	DrlProgramState Doosan::GetProgramState()
	{
		return static_cast<DrlProgramState>(DRAFramework::_get_program_state(_rbtCtrl));
	};

	void Doosan::SetSafeStopResetType(SafeStopResetType resetType)
	{
		//// Set default parameters
		//if (resetType.IsDefined == true) { resetType = SAFE_STOP_RESET_TYPE_DEFAULT; }

		DRAFramework::_set_safe_stop_reset_type(_rbtCtrl, static_cast<SAFE_STOP_RESET_TYPE>(resetType));
	}

	LogAlarm Doosan::GetLastAlarm()
	{
		LPLOG_ALARM dataC = DRAFramework::_get_last_alarm(_rbtCtrl);
		LogAlarm dataWrapper{};

		// Initialisation
		dataWrapper._szParam = gcnew cli::array<String^>(3);

		// Cast
		dataWrapper._iGroup = dataC->_iGroup;
		dataWrapper._iIndex = dataC->_iIndex;
		dataWrapper._iLevel = dataC->_iLevel;
		dataWrapper._szParam[0] = gcnew String(dataC->_szParam[0]);
		dataWrapper._szParam[1] = gcnew String(dataC->_szParam[1]);
		dataWrapper._szParam[2] = gcnew String(dataC->_szParam[2]);

		return dataWrapper;
	};


	float Doosan::GetOrientationError(cli::array<float>^ fPosition1, cli::array<float>^ fPosition2, TaskAxis taskAxis)
	{
		TASK_AXIS taskAxisC = static_cast<TASK_AXIS>(taskAxis);

		float fPosition1C[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			fPosition1C[i] = fPosition1[i];
		}

		float fPosition2C[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			fPosition2C[i] = fPosition2[i];
		}
		return  DRAFramework::_get_orientation_error(_rbtCtrl, fPosition1C, fPosition2C, taskAxisC);
	}


	////////////////////////////////////////////////////////////////////////////
	//  access control                                                        //
	////////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// manage access control
	/// </summary>
	/// <param name="accessControl"></param>
	/// <returns></returns>
	bool Doosan::ManageAccessControll(ManageAccessControl accessControl)
	{
		// ToDo: Test default parameter
		// Set default parameters
		//if (accessControl.IsDefined == false) { accessControl = RCManageAccessControl::MANAGE_ACCESS_CONTROL_REQUEST; }

		return DRAFramework::_manage_access_control(_rbtCtrl, static_cast<MANAGE_ACCESS_CONTROL>(accessControl));
	};


	//////////////////////////////////////////////////////////////////////////////
	//// Callback operation                                                     //
	//////////////////////////////////////////////////////////////////////////////
	// https://jike.in/?qa=1009924/callbacks-from-c-back-to-c%23

	void Doosan::OnMonitoringStateCB(const RobotState value)
	{
		// Call C# code
		if (Doosan::ManagedTOnMonitoringStateCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringStateCBHandler(value);
		}
	}

	void Doosan::OnMonitoringDataCB(IntPtr value)
	{
		MONITORING_DATA* dataC = (MONITORING_DATA*)value.ToPointer();
		MonitoringData valueWrapper{};

		// Cast from C++ to C# ...
		// MONITORING_CONTROL          _tCtrl;
		// ROBOT_MONITORING_STATE      _tState;
		// unsigned char               _iActualMode;
		valueWrapper._tCtrl._tState._iActualMode = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tState._iActualMode;
		// unsigned char               _iActualSpace;
		valueWrapper._tCtrl._tState._iActualSpace = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tState._iActualSpace;

		// ROBOT_MONITORING_JOINT      _tJoint;
		// float                       _fActualPos[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualPos = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualPos[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tJoint._fActualPos[i];
		}

		// float                       _fActualAbs[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualAbs = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualAbs[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tJoint._fActualAbs[i];
		}

		// float                       _fActualVel[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualVel = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualVel[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tJoint._fActualVel[i];
		}

		// float                       _fActualErr[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualErr = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualErr[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tJoint._fActualErr[i];
		}

		// float                       _fTargetPos[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fTargetPos = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fTargetPos[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tJoint._fTargetPos[i];
		}

		// float                       _fTargetVel[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fTargetVel = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fTargetVel[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tJoint._fTargetVel[i];
		}

		// ROBOT_MONITORING_TASK       _tTask;
		// float                       _fActualPos[2][NUMBER_OF_JOINT]; 
		valueWrapper._tCtrl._tTask._fActualPos = gcnew cli::array<float, 2>(2, NUMBER_OF_JOINT);
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < NUMBER_OF_JOINT; j++)
			{
				valueWrapper._tCtrl._tTask._fActualPos[i, j] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTask._fActualPos[i][j];
			}
		}

		// float                       _fActualVel[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fActualVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fActualVel[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTask._fActualVel[i];
		}

		// float                       _fActualErr[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fActualErr = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fActualErr[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTask._fActualErr[i];
		}

		// float                       _fTargetPos[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fTargetPos = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fTargetPos[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTask._fTargetPos[i];
		}

		// float                       _fTargetVel[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fTargetVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fTargetVel[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTask._fTargetVel[i];
		}

		// unsigned char               _iSolutionSpace;
		valueWrapper._tCtrl._tTask._iSolutionSpace = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTask._iSolutionSpace;

		// float                       _fRotationMatrix[3][3];
		valueWrapper._tCtrl._tTask._fRotationMatrix = gcnew cli::array<float, 2>(3, 3);
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				valueWrapper._tCtrl._tTask._fRotationMatrix[i, j] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTask._fRotationMatrix[i][j];
			}
		}

		// ROBOT_MONITORING_TORQUE     _tTorque;
		// float                       _fDynamicTor[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fDynamicTor = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fDynamicTor[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTorque._fDynamicTor[i];
		}

		// float                       _fActualJTS[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fActualJTS = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fActualJTS[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTorque._fActualJTS[i];
		}

		// float                       _fActualEJT[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fActualEJT = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fActualEJT[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTorque._fActualEJT[i];
		}

		// float                       _fActualETT[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fActualETT = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fActualETT[i] = ((MONITORING_DATA*)value.ToPointer())->_tCtrl._tTorque._fActualETT[i];
		}

		// MONITORING_MISC             _tMisc;
		// double                       _dSyncTime;
		valueWrapper._tMisc._dSyncTime = ((MONITORING_DATA*)value.ToPointer())->_tMisc._dSyncTime;

		// unsigned char                _iActualDI[NUM_FLANGE_IO];
		valueWrapper._tMisc._iActualDI = gcnew cli::array<unsigned char>(NUM_FLANGE_IO);
		for (int i = 0; i < NUM_FLANGE_IO; i++)
		{
			valueWrapper._tMisc._iActualDI[i] = ((MONITORING_DATA*)value.ToPointer())->_tMisc._iActualDI[i];
		}

		// unsigned char                _iActualDO[NUM_FLANGE_IO];
		valueWrapper._tMisc._iActualDO = gcnew cli::array<unsigned char>(NUM_FLANGE_IO);
		for (int i = 0; i < NUM_FLANGE_IO; i++)
		{
			valueWrapper._tMisc._iActualDO[i] = ((MONITORING_DATA*)value.ToPointer())->_tMisc._iActualDO[i];
		}
		// unsigned char                _iActualBK[NUM_JOINT];
		valueWrapper._tMisc._iActualBK = gcnew cli::array<unsigned char>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tMisc._iActualBK[i] = ((MONITORING_DATA*)value.ToPointer())->_tMisc._iActualBK[i];
		}

		// unsigned int                 _iActualBT[NUM_BUTTON];
		valueWrapper._tMisc._iActualBT = gcnew cli::array<unsigned int  >(NUM_BUTTON);
		for (int i = 0; i < NUM_BUTTON; i++)
		{
			valueWrapper._tMisc._iActualBT[i] = ((MONITORING_DATA*)value.ToPointer())->_tMisc._iActualBT[i];
		}

		// float                        _fActualMC[NUM_JOINT];
		valueWrapper._tMisc._fActualMC = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tMisc._fActualMC[i] = ((MONITORING_DATA*)value.ToPointer())->_tMisc._fActualMC[i];
		}

		// float                        _fActualMT[NUM_JOINT];
		valueWrapper._tMisc._fActualMT = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tMisc._fActualMT[i] = ((MONITORING_DATA*)value.ToPointer())->_tMisc._fActualMT[i];
		}

		// Call C# code
		if (Doosan::ManagedTOnMonitoringDataCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringDataCBHandler(valueWrapper);
		}
	}

	void Doosan::OnMonitoringDataExCB(IntPtr value)
	{
		MONITORING_DATA_EX* valueC = (MONITORING_DATA_EX*)value.ToPointer();
		MonitoringDataEx valueWrapper{};

		// Cast from C++ to C# ...
		// MONITORING_CONTROL_EX       _tCtrl;
		// ROBOT_MONITORING_STATE      _tState;
		// unsigned char               _iActualMode;
		valueWrapper._tCtrl._tState._iActualMode = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tState._iActualMode;
		// unsigned char               _iActualSpace;
		valueWrapper._tCtrl._tState._iActualSpace = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tState._iActualSpace;

		// ROBOT_MONITORING_JOINT      _tJoint;
		// float                       _fActualPos[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualPos = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualPos[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tJoint._fActualPos[i];
		}

		// float                       _fActualAbs[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualAbs = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualAbs[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tJoint._fActualAbs[i];
		}

		// float                       _fActualVel[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualVel = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tJoint._fActualVel[i];
		}

		// float                       _fActualErr[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fActualErr = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fActualErr[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tJoint._fActualErr[i];
		}

		// float                       _fTargetPos[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fTargetPos = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fTargetPos[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tJoint._fTargetPos[i];
		}

		// float                       _fTargetVel[NUM_JOINT];
		valueWrapper._tCtrl._tJoint._fTargetVel = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tJoint._fTargetVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tJoint._fTargetVel[i];
		}

		// ROBOT_MONITORING_TASK       _tTask;
		// float                       _fActualPos[2][NUMBER_OF_JOINT]; 
		valueWrapper._tCtrl._tTask._fActualPos = gcnew cli::array<float, 2>(2, NUMBER_OF_JOINT);
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < NUMBER_OF_JOINT; j++)
			{
				valueWrapper._tCtrl._tTask._fActualPos[i, j] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTask._fActualPos[i][j];
			}
		}

		// float                       _fActualVel[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fActualVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fActualVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTask._fActualVel[i];
		}

		// float                       _fActualErr[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fActualErr = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fActualErr[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTask._fActualErr[i];
		}

		// float                       _fTargetPos[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fTargetPos = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fTargetPos[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTask._fTargetPos[i];
		}

		// float                       _fTargetVel[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tTask._fTargetVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tTask._fTargetVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTask._fTargetVel[i];
		}

		// unsigned char               _iSolutionSpace;
		valueWrapper._tCtrl._tTask._iSolutionSpace = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTask._iSolutionSpace;

		// float                       _fRotationMatrix[3][3];
		valueWrapper._tCtrl._tTask._fRotationMatrix = gcnew cli::array<float, 2>(3, 3);
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				valueWrapper._tCtrl._tTask._fRotationMatrix[i, j] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTask._fRotationMatrix[i][j];
			}
		}

		// ROBOT_MONITORING_TORQUE     _tTorque;
		// float                       _fDynamicTor[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fDynamicTor = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fDynamicTor[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTorque._fDynamicTor[i];
		}

		// float                       _fActualJTS[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fActualJTS = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fActualJTS[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTorque._fActualJTS[i];
		}

		// float                       _fActualEJT[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fActualEJT = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fActualEJT[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTorque._fActualEJT[i];
		}

		// float                       _fActualETT[NUM_JOINT];
		valueWrapper._tCtrl._tTorque._fActualETT = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tCtrl._tTorque._fActualETT[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tTorque._fActualETT[i];
		}

		// ROBOT_MONITORING_WORLD      _tWorld;
		// float                       _fActualW2B[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tWorld._fActualW2B = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tWorld._fActualW2B[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tWorld._fActualW2B[i];
		}

		// float                       _fActualPos[2][NUMBER_OF_JOINT]; 
		valueWrapper._tCtrl._tWorld._fActualPos = gcnew cli::array<float, 2>(2, NUMBER_OF_JOINT);
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < NUMBER_OF_JOINT; j++)
			{
				valueWrapper._tCtrl._tWorld._fActualPos[i, j] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tWorld._fActualPos[i][j];
			}
		}

		// float                       _fActualVel[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tWorld._fActualVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tWorld._fActualVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tWorld._fActualVel[i];
		}

		// float                       _fActualETT[NUMBER_OF_JOINT]; 
		valueWrapper._tCtrl._tWorld._fActualETT = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tWorld._fActualETT[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tWorld._fActualETT[i];
		}

		// float                       _fTargetPos[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tWorld._fTargetPos = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tWorld._fTargetPos[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tWorld._fTargetPos[i];
		}

		// float                       _fTargetVel[NUMBER_OF_JOINT];  
		valueWrapper._tCtrl._tWorld._fTargetVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tWorld._fTargetVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tWorld._fTargetVel[i];
		}

		// float                       _fRotationMatrix[3][3];
		valueWrapper._tCtrl._tWorld._fRotationMatrix = gcnew cli::array<float, 2>(3, 3);
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				valueWrapper._tCtrl._tWorld._fRotationMatrix[i, j] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tWorld._fRotationMatrix[i][j];
			}
		}

		// ROBOT_MONITORING_USER       _tUser;
		// unsigned char               _iActualUCN;
		valueWrapper._tCtrl._tUser._iActualUCN = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._iActualUCN;

		// unsigned char               _iParent;
		valueWrapper._tCtrl._tUser._iParent = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._iParent;

		// float                       _fActualPos[2][NUMBER_OF_JOINT]; 
		valueWrapper._tCtrl._tUser._fActualPos = gcnew cli::array<float, 2>(2, NUMBER_OF_JOINT);
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < NUMBER_OF_JOINT; j++)
			{
				valueWrapper._tCtrl._tUser._fActualPos[i, j] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._fActualPos[i][j];
			}
		}

		// float                       _fActualVel[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tUser._fActualVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tUser._fActualVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._fActualVel[i];
		}

		// float                       _fActualETT[NUMBER_OF_JOINT]; 
		valueWrapper._tCtrl._tUser._fActualETT = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tUser._fActualETT[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._fActualETT[i];
		}

		// float                       _fTargetPos[NUMBER_OF_JOINT];
		valueWrapper._tCtrl._tUser._fTargetPos = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tUser._fTargetPos[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._fTargetPos[i];
		}

		// float                       _fTargetVel[NUMBER_OF_JOINT];  
		valueWrapper._tCtrl._tUser._fTargetVel = gcnew cli::array<float>(NUMBER_OF_JOINT);
		for (int i = 0; i < NUMBER_OF_JOINT; i++)
		{
			valueWrapper._tCtrl._tUser._fTargetVel[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._fTargetVel[i];
		}

		// float                       _fRotationMatrix[3][3];
		valueWrapper._tCtrl._tUser._fRotationMatrix = gcnew cli::array<float, 2>(3, 3);
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				valueWrapper._tCtrl._tUser._fRotationMatrix[i, j] = ((MONITORING_DATA_EX*)value.ToPointer())->_tCtrl._tUser._fRotationMatrix[i][j];
			}
		}

		// MONITORING_MISC             _tMisc;
		// double                       _dSyncTime;
		valueWrapper._tMisc._dSyncTime = ((MONITORING_DATA_EX*)value.ToPointer())->_tMisc._dSyncTime;

		// unsigned char                _iActualDI[NUM_FLANGE_IO];
		valueWrapper._tMisc._iActualDI = gcnew cli::array<unsigned char>(NUM_FLANGE_IO);
		for (int i = 0; i < NUM_FLANGE_IO; i++)
		{
			valueWrapper._tMisc._iActualDI[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tMisc._iActualDI[i];
		}

		// unsigned char                _iActualDO[NUM_FLANGE_IO];
		valueWrapper._tMisc._iActualDO = gcnew cli::array<unsigned char>(NUM_FLANGE_IO);
		for (int i = 0; i < NUM_FLANGE_IO; i++)
		{
			valueWrapper._tMisc._iActualDO[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tMisc._iActualDO[i];
		}
		// unsigned char                _iActualBK[NUM_JOINT];
		valueWrapper._tMisc._iActualBK = gcnew cli::array<unsigned char>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tMisc._iActualBK[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tMisc._iActualBK[i];
		}

		// unsigned int                 _iActualBT[NUM_BUTTON];
		valueWrapper._tMisc._iActualBT = gcnew cli::array<unsigned int  >(NUM_BUTTON);
		for (int i = 0; i < NUM_BUTTON; i++)
		{
			valueWrapper._tMisc._iActualBT[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tMisc._iActualBT[i];
		}

		// float                        _fActualMC[NUM_JOINT];
		valueWrapper._tMisc._fActualMC = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tMisc._fActualMC[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tMisc._fActualMC[i];
		}

		// float                        _fActualMT[NUM_JOINT];
		valueWrapper._tMisc._fActualMT = gcnew cli::array<float>(NUM_JOINT);
		for (int i = 0; i < NUM_JOINT; i++)
		{
			valueWrapper._tMisc._fActualMT[i] = ((MONITORING_DATA_EX*)value.ToPointer())->_tMisc._fActualMT[i];
		}

		// Call C# code
		if (Doosan::ManagedTOnMonitoringDataExCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringDataExCBHandler(valueWrapper);
		}
	};

	void Doosan::OnMonitoringCtrlIO(IntPtr value)
	{
		// ToDo: ...
		MONITORING_CTRLIO* valueC = (MONITORING_CTRLIO*)value.ToPointer();
		MonitoringCtrlio valueWrapper{};

		// Call C# code
		if (Doosan::ManagedTOnMonitoringCtrlIOCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringCtrlIOCBHandler(valueWrapper);
		}
	}

	void Doosan::OnMonitoringCtrlIOEx(IntPtr value)
	{
		// ToDo: ...
		MONITORING_CTRLIO_EX* valueC = (MONITORING_CTRLIO_EX*)value.ToPointer();
		MonitoringCtrlioEx valueWrapper{};

		// Call C# code
		if (Doosan::ManagedTOnMonitoringCtrlIOExCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringCtrlIOExCBHandler(valueWrapper);
		}
	}

	void Doosan::OnMonitoringModbus(IntPtr value)
	{
		// ToDo: ...
		MONITORING_MODBUS* valueC = (MONITORING_MODBUS*)value.ToPointer();
		MonitoringModbus valueWrapper{};

		// Call C# code
		if (Doosan::ManagedTOnMonitoringModbusCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringModbusCBHandler(valueWrapper);
		}
	};

	void Doosan::OnMonitoringSpeedMode(const MonitoringSpeed value)
	{
		// ToDo: ...

		// Call C# code
		if (Doosan::ManagedTOnMonitoringSpeedModeCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringSpeedModeCBHandler(value);
		}
	};

	void Doosan::OnMonitoringAccessControlCB(const MonitoringAccessControl value)
	{
		// Call C# code
		if (Doosan::ManagedTOnMonitoringAccessControlCBHandler != nullptr)
		{
			Doosan::ManagedTOnMonitoringAccessControlCBHandler(value);
		}
	};

	void Doosan::OnLogAlarmCB(IntPtr ptr)
	{
		// ToDo: ...
		LogAlarm valueWrapper{};

		// Call C# code
		if (Doosan::ManagedTOnLogAlarmCBHandler != nullptr)
		{
			Doosan::ManagedTOnLogAlarmCBHandler(valueWrapper);
		}
	};

	void  Doosan::OnTpPopup(IntPtr ptr)
	{
		// ToDo: ...
		MessagePopup valueWrapper{};

		// Call C# code
		if (Doosan::ManagedTOnTpPopupCBHandler != nullptr)
		{
			Doosan::ManagedTOnTpPopupCBHandler(valueWrapper);
		}
	};

	//void  Doosan::SetOnTpLog(const char[256] value)
	//{
	//	// ToDo: ...

	//	// Call C# code
	//	if (Doosan::ManagedTOnTpLogCBHandler != nullptr)
	//	{
	//		Doosan::ManagedTOnTpLogCBHandler(value);
	//	}
	//};

	void  Doosan::OnTpProgress(IntPtr ptr)
	{
		// ToDo: ...
		MessageProgress valueWrapper{};

		// Call C# code
		if (Doosan::ManagedTOnTpProgressCBHandler != nullptr)
		{
			Doosan::ManagedTOnTpProgressCBHandler(valueWrapper);
		}
	};

	void  Doosan::OnTpGetUserInputCB(IntPtr ptr)
	{
		// ToDo: ...
		MessageInput valueWrapper{};

		// Call C# code
		if (Doosan::ManagedTOnTpGetUserInputCBHandler != nullptr)
		{
			Doosan::ManagedTOnTpGetUserInputCBHandler(valueWrapper);
		}
	};

	void Doosan::OnProgramStopped(const ProgramStopCause value)
	{
		// ToDo: ...

		// Call C# code
		if (Doosan::ManagedTOnProgramStoppedCBHandler != nullptr)
		{
			Doosan::ManagedTOnProgramStoppedCBHandler(value);
		}
	};

	void Doosan::OnHommingCompletedCB()
	{
		// Call C# code
		if (Doosan::ManagedTOnHommingCompletedCBHandler != nullptr)
		{
			Doosan::ManagedTOnHommingCompletedCBHandler();
		}
	};

	void Doosan::OnTpInitializingCompletedCB()
	{
		// Call C# code
		if (Doosan::ManagedTOnTpInitializingCompletedCBHandler != nullptr)
		{
			Doosan::ManagedTOnTpInitializingCompletedCBHandler();
		}
	};

	void Doosan::SetOnMasteringNeed()
	{
		// Call C# code
		if (Doosan::ManagedTOnMasteringNeedCBHandler != nullptr)
		{
			Doosan::ManagedTOnMasteringNeedCBHandler();
		}
	};

	void Doosan::OnDisconnected()
	{
		// Call C# code
		if (Doosan::ManagedTOnDisconnectedCBHandler != nullptr)
		{
			Doosan::ManagedTOnDisconnectedCBHandler();
		}
	};


	////////////////////////////////////////////////////////////////////////////
	//  Robot		                                                          //
	////////////////////////////////////////////////////////////////////////////

	//LPROBOT_POSE trans(float fSourcePos[NUM_TASK], float fOffset[NUM_TASK], COORDINATE_SYSTEM eSourceRef = COORDINATE_SYSTEM_BASE, COORDINATE_SYSTEM eTargetRef = COORDINATE_SYSTEM_BASE) 
	// { 
	// return _trans(_rbtCtrl, fSourcePos, fOffset, eSourceRef, eTargetRef);
	// };

	//LPROBOT_POSE ikin(float fSourcePos[NUM_TASK], unsigned char iSolutionSpace, COORDINATE_SYSTEM eTargetRef = COORDINATE_SYSTEM_BASE)
	// { 
	// return _ikin(_rbtCtrl, fSourcePos, iSolutionSpace, eTargetRef); 
	// };

	//LPINVERSE_KINEMATIC_RESPONSE ikin(float fSourcePos[NUM_TASK], unsigned char iSolutionSpace, COORDINATE_SYSTEM eTargetRef, unsigned char iRefPosOpt)
	// {
	// return _ikin_ex(_rbtCtrl, fSourcePos, iSolutionSpace, eTargetRef, iRefPosOpt); 
	// };

	//RobotPose FKin(cli::array<float>^ fSourcePos, [Optional] Nullable<CoordinateSystem> targetRef)
	//{
	//	// Set default parameters
	//	COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
	//	if (coodType.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(coodType.Value); }

	//	float fSourcePosC[NUM_TASK]{};
	//	for (int i = 0; i < NUM_TASK; i++)
	//	{
	//		fSourcePosC[i] = fSourcePos[i];
	//	}

	//	LPROBOT_TASK_POSE robotTaskPosexC = DRAFramework::_fkin(_rbtCtrl, fSourcePosC, targetRefC);
	//	RobotTaskPose robotTaskPosexWrapper{};


	//	return _fkin(_rbtCtrl, fSourcePos, eTargetRef);
	//};


	RobotTaskPose Doosan::GetCurrentPosx(Nullable<CoordinateSystem> coodType)
	{
		// Set default parameters
		COORDINATE_SYSTEM coodTypeC = COORDINATE_SYSTEM_BASE;
		if (coodType.HasValue) { coodTypeC = static_cast<COORDINATE_SYSTEM>(coodType.Value); }

		LPROBOT_TASK_POSE robotTaskPosexC = DRAFramework::_get_current_posx(_rbtCtrl, coodTypeC);
		RobotTaskPose robotTaskPosexWrapper{};

		// Initialisation
		robotTaskPosexWrapper._fTargetPos = gcnew cli::array<float>(NUM_TASK);

		// Conversion
		robotTaskPosexWrapper._iTargetSol = robotTaskPosexC->_iTargetSol;
		robotTaskPosexWrapper._fTargetPos[0] = robotTaskPosexC->_fTargetPos[0];
		robotTaskPosexWrapper._fTargetPos[1] = robotTaskPosexC->_fTargetPos[1];
		robotTaskPosexWrapper._fTargetPos[2] = robotTaskPosexC->_fTargetPos[2];
		robotTaskPosexWrapper._fTargetPos[3] = robotTaskPosexC->_fTargetPos[3];
		robotTaskPosexWrapper._fTargetPos[4] = robotTaskPosexC->_fTargetPos[4];
		robotTaskPosexWrapper._fTargetPos[5] = robotTaskPosexC->_fTargetPos[5];

		return robotTaskPosexWrapper;
	};

	RobotPose Doosan::GetDesiredPosx(Nullable<CoordinateSystem> coodType)
	{
		// Set default parameters
		COORDINATE_SYSTEM coodTypeC = COORDINATE_SYSTEM_BASE;
		if (coodType.HasValue) { coodTypeC = static_cast<COORDINATE_SYSTEM>(coodType.Value); }

		LPROBOT_POSE robotTaskPosexC = DRAFramework::_get_desired_posx(_rbtCtrl, coodTypeC);
		RobotPose robotTaskPosexWrapper{};

		// Initialisation
		robotTaskPosexWrapper._fPosition = gcnew cli::array<float>(NUM_TASK);

		// Conversion
		robotTaskPosexWrapper._fPosition[0] = robotTaskPosexC->_fPosition[0];
		robotTaskPosexWrapper._fPosition[1] = robotTaskPosexC->_fPosition[1];
		robotTaskPosexWrapper._fPosition[2] = robotTaskPosexC->_fPosition[2];
		robotTaskPosexWrapper._fPosition[3] = robotTaskPosexC->_fPosition[3];
		robotTaskPosexWrapper._fPosition[4] = robotTaskPosexC->_fPosition[4];
		robotTaskPosexWrapper._fPosition[5] = robotTaskPosexC->_fPosition[5];

		return robotTaskPosexWrapper;
	};


	//double Doosan::GetOverrideSpeed()
	//{
	//	return DRAFramework::_get_override_speed(_rbtCtrl);
	//};

	float Doosan::GetWorkpieceWeight()
	{
		return DRAFramework::_get_workpiece_weight(_rbtCtrl);
	};

	bool Doosan::ResetWorkpieceWeight()
	{
		return DRAFramework::_reset_workpiece_weight(_rbtCtrl);
	};

	bool Doosan::TpPopupResponse(PopupResponse eRes)
	{
		return DRAFramework::_tp_popup_response(_rbtCtrl, static_cast<POPUP_RESPONSE>(eRes));
	};

	bool Doosan::TpGetUserInputResponse(String^ strUserInput)
	{
		return DRAFramework::_tp_get_user_input_response(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(strUserInput));
	};


	////////////////////////////////////////////////////////////////////////////
	//  Motion Operations                                                     //
	////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// basci motion(hold to run)
	/// </summary>
	/// <param name="jogAxis"></param>
	/// <param name="moveReference"></param>
	/// <param name="velocity"></param>
	/// <returns></returns>
	bool Doosan::Jog(JogAxis jogAxis, MoveReference moveReference, float velocity)
	{
		return  DRAFramework::_jog(_rbtCtrl, static_cast<JOG_AXIS>(jogAxis), static_cast<MOVE_REFERENCE>(moveReference), velocity);
	};
	/// <summary>
	/// basci motion(hold to run)
	/// </summary>
	/// <param name="targetPos"></param>
	/// <param name="moveReference"></param>
	/// <param name="velocity"></param>
	/// <returns></returns>
	bool Doosan::MultiJog(cli::array<float>^ targetPos, MoveReference moveReference, float velocity)
	{
		// Initialisation
		float* targetPosC = new float[NUM_TASK];

		// Cast
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		return  DRAFramework::_multi_jog(_rbtCtrl, targetPosC, static_cast<MOVE_REFERENCE>(moveReference), velocity);
	};
	/// <summary>
	/// basci motion(hold to run)
	/// </summary>
	/// <param name="run"></param>
	/// <returns></returns>
	bool Doosan::Home(MoveHome mode, Nullable<unsigned char> run)
	{
		// Set default parameters
		unsigned char runC = 1;
		if (run.HasValue) { runC = run.Value; }

		return  DRAFramework::_move_home(_rbtCtrl, static_cast<MOVE_HOME>(mode), runC);
	};
	/// <summary>
	/// motion control: move stop
	/// </summary>
	/// <param name="stopType"></param>
	/// <returns></returns>
	bool Doosan::Stop(Nullable<StopType> stopType)
	{
		// Set default parameters
		STOP_TYPE stopTypeC = STOP_TYPE_QUICK;
		if (stopType.HasValue) { stopTypeC = static_cast<STOP_TYPE>(stopType.Value); }

		return  DRAFramework::_stop(_rbtCtrl, stopTypeC);
	};
	/// <summary>
	/// Motion control: move pause
	/// </summary>
	/// <returns></returns>
	bool Doosan::MovePause()
	{
		return  DRAFramework::_move_pause(_rbtCtrl);
	};
	/// <summary>
	/// Motion control: move resume
	/// </summary>
	/// <returns></returns>
	bool Doosan::MoveResume()
	{
		return  DRAFramework::_move_resume(_rbtCtrl);
	};
	/// <summary>
	/// Wait motion
	/// </summary>
	/// <returns></returns>
	bool Doosan::MoveWait()
	{
		return  DRAFramework::_mwait(_rbtCtrl);
	};


	LPROBOT_POSE Doosan::Trans(cli::array<float>^ sourcePos, cli::array<float>^ offset, Nullable <CoordinateSystem> sourceRef, Nullable <CoordinateSystem> targetRef) {

		COORDINATE_SYSTEM sourceRefC = COORDINATE_SYSTEM_BASE;
		COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;

		if (sourceRef.HasValue) { sourceRefC = static_cast<COORDINATE_SYSTEM>(sourceRef.Value); }
		if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }

		float sourcePosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			sourcePosC[i] = sourcePos[i];
		}


		float offsetC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			offsetC[i] = offset[i];
		}



		return DRAFramework::_trans(_rbtCtrl, sourcePosC, offsetC, sourceRefC, targetRefC);
	}

	LPROBOT_POSE Doosan::Fkin(cli::array<float>^ sourcePos, Nullable <CoordinateSystem> targetRef) {

		COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
		if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }

		float sourcePosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			sourcePosC[i] = sourcePos[i];
		}

		return DRAFramework::_fkin(_rbtCtrl, sourcePosC, targetRefC);

	}

	//LPROBOT_POSE ikin(float fSourcePos[NUM_TASK], unsigned char iSolutionSpace, COORDINATE_SYSTEM eTargetRef = COORDINATE_SYSTEM_BASE) { return _ikin(_rbtCtrl, fSourcePos, iSolutionSpace, eTargetRef); };
	LPROBOT_POSE Doosan::Ikin(cli::array<float>^ sourcePos, unsigned char solutionSpace, Nullable <CoordinateSystem> targetRef) {

		COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
		if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }

		float sourcePosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			sourcePosC[i] = sourcePos[i];
		}

		return DRAFramework::_ikin(_rbtCtrl, sourcePosC, solutionSpace, targetRefC);
	}


	/// <summary>
	/// motion control : joint move
	/// </summary>
	/// <param name="targetPos"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="blendingRadius"></param>
	/// <param name="blendingSpeedType"></param>
	/// <returns></returns>
	bool Doosan::MoveJ(cli::array<float>^ targetPos, float targetVel, float targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<float> blendingRadius, Nullable<BlendingSpeedType> blendingSpeedType)
	{
		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		float blendingRadiusC = 0.0f;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (blendingRadius.HasValue) { blendingRadiusC = blendingRadius.Value; }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }

		// Initialisation &  Cast
		float targetPosC[NUM_JOINT]{};
		for (int i = 0; i < NUM_JOINT; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		return  DRAFramework::_movej(_rbtCtrl, targetPosC, targetVel, targetAcc, targetTimeC, moveModeC, blendingRadiusC, blendingSpeedTypeC);
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="targetPos"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="blendingSpeedType"></param>
	/// <returns></returns>
	bool Doosan::MoveJAsync(cli::array<float>^ targetPos, float targetVel, float targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<BlendingSpeedType> blendingSpeedType)
	{
		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }

		// Initialisation &  Cast
		float targetPosC[NUM_JOINT]{};
		for (int i = 0; i < NUM_JOINT; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		return  DRAFramework::_amovej(_rbtCtrl, targetPosC, targetVel, targetAcc, targetTimeC, moveModeC, blendingSpeedTypeC);
	};
	/// <summary>
	/// motion control: linear move
	/// </summary>
	/// <param name="targetPos"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="moveReference"></param>
	/// <param name="blendingRadius"></param>
	/// <param name="blendingSpeedType"></param>
	/// <returns></returns>
	bool Doosan::MoveL(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<float> blendingRadius, Nullable<BlendingSpeedType> blendingSpeedType)
	{
		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		float blendingRadiusC = 0.0f;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(blendingSpeedType.Value); }
		if (blendingRadius.HasValue) { blendingRadiusC = blendingRadius.Value; }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }

		// Initialisation &  Cast
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}

		return  DRAFramework::_movel(_rbtCtrl, targetPosC, targetVelC, targetAccC, targetTimeC, moveModeC, moveReferenceC, blendingRadiusC, blendingSpeedTypeC);
	};
	/// <summary>
	/// linear motion
	/// </summary>
	/// <param name="targetPos"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="moveReference"></param>
	/// <param name="blendingSpeedType"></param>
	/// <returns></returns>
	bool Doosan::MoveLAsync(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<BlendingSpeedType> blendingSpeedType)
	{
		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(blendingSpeedType.Value); }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }

		// Initialisation &  Cast
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}

		return  DRAFramework::_amovel(_rbtCtrl, targetPosC, targetVelC, targetAccC, targetTimeC, moveModeC, moveReferenceC, blendingSpeedTypeC);
	};




	//needs to be tested

/// <summary>
/// target position within the joint space
/// </summary>
/// <param name="targetPos"></param>
///	<param name="solutionSpace"></param>
/// <param name="targetVel"></param>
/// <param name="targetAcc"></param>
/// <param name="targetTime"></param>
/// <param name="moveMode"></param>
/// <param name="moveReference"></param>
/// <param name="blendingRadius"></param>
/// <param name="blendingSpeedType"></param>
/// <returns></returns>
	bool Doosan::MoveJX(cli::array<float>^ targetPos, unsigned char solutionSpace, float targetVel, float targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<float> blendingRadius, Nullable<BlendingSpeedType> blendingSpeedType)
	{
		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;
		float blendingRadiusC = 0.0f;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(blendingSpeedType.Value); }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }
		if (blendingRadius.HasValue) { blendingRadiusC = blendingRadius.Value; }

		// Initialisation &  Cast
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		return  DRAFramework::_movejx(_rbtCtrl, targetPosC, solutionSpace, targetVel, targetAcc, targetTimeC, moveModeC, moveReferenceC, blendingRadiusC, blendingSpeedTypeC);
	};



	//needs to be tested

	/// <summary>
	/// move along arc
	/// </summary>
	/// <param name="targetPos"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="moveReference"></param>
	/// <param name="targetAngle1"></param>
	/// <param name="targetAngle2"></param>
	/// <param name="blendingRadius"></param>
	/// <param name="blendingSpeedType"></param>
	/// <returns></returns>
	bool Doosan::MoveC(cli::array<cli::array<float>^>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<float> targetAngle1, Nullable<float> targetAngle2, Nullable<float> blendingRadius, Nullable<BlendingSpeedType> blendingSpeedType) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;
		float blendingRadiusC = 0.0f;
		float targetAngle1C = 0.0f;
		float targetAngle2C = 0.0f;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(blendingSpeedType.Value); }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }
		if (blendingRadius.HasValue) { blendingRadiusC = blendingRadius.Value; }
		if (targetAngle1.HasValue) { targetAngle1C = targetAngle1.Value; }
		if (targetAngle2.HasValue) { targetAngle2C = targetAngle2.Value; }


		// Initialisation &  Cast
		float targetPosC[2][NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				targetPosC[j][i] = targetPos[j][i];
			}
		}

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}


		return  DRAFramework::_movec(_rbtCtrl, targetPosC, targetVelC, targetAccC, targetTimeC, moveModeC, moveReferenceC, targetAngle1C, targetAngle2C, blendingRadiusC, blendingSpeedTypeC);
	};

	//needs to be tested

	/// <summary>
	/// move along spline curve - joints
	/// </summary>
	/// <param name="targetPos"></param>
	///	<param name="posCount"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <returns></returns>
	bool Doosan::MoveSJ(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, float targetVel, float targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }

		// Initialisation &  Cast
		float targetPosC[MAX_SPLINE_POINT][NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			for (int j = 0; j < (int)posCount; j++)
			{
				targetPosC[j][i] = targetPos[j][i];
			}
		}

		return DRAFramework::_movesj(_rbtCtrl, targetPosC, posCount, targetVel, targetAcc, targetTimeC, moveModeC);
	};



	//needs to be tested

	/// <summary>
	/// move along spline curve - cartesian
	/// </summary>
	/// <param name="targetPos"></param>
	///	<param name="posCount"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="moveReference"></param>
	/// <param name="velOpt"></param>
	/// <returns></returns>
	bool Doosan::MoveSX(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<SplineVelocityOption> velOpt) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		SPLINE_VELOCITY_OPTION velOptC = SPLINE_VELOCITY_OPTION_DEFAULT;


		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(moveReference.Value); }
		if (velOpt.HasValue) { velOptC = static_cast<SPLINE_VELOCITY_OPTION>(velOpt.Value); }

		// Initialisation &  Cast
		float targetPosC[MAX_SPLINE_POINT][NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			for (int j = 0; j < (int)posCount; j++)
			{
				targetPosC[j][i] = targetPos[j][i];
			}
		}

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}

		return DRAFramework::_movesx(_rbtCtrl, targetPosC, posCount, targetVelC, targetAccC, targetTimeC, moveModeC, moveReferenceC, velOptC);
	};


	/*
	bool Doosan::MoveB(cli::array<MOVE_POSB>^ targetPos, unsigned char posCount, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(moveReference.Value); }

		// Initialisation &  Cast
		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}

		return DRAFramework::_moveb(_rbtCtrl, targetPos, posCount, targetVelC, targetAccC, targetTimeC, moveModeC, moveReferenceC);
	}; */


	/// <summary>
	/// moving in spiral motion
	/// </summary>
	/// <param name="taskAxis"></param>
	/// <param name="revolution"></param>
	/// <param name="maximuRadius"></param>
	/// <param name="maximumLength"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveReference"></param>
	/// <returns></returns>
	bool Doosan::MoveSpiral(TaskAxis taskAxis, float revolution, float maximuRadius, float maximumLength, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveReference> moveReference) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_TOOL;
		TASK_AXIS taskAxisC = static_cast<TASK_AXIS>(taskAxis);


		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(moveReference.Value); }

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}


		return DRAFramework::_move_spiral(_rbtCtrl, taskAxisC, revolution, maximuRadius, maximumLength, targetVelC, targetAccC, targetTimeC, moveReferenceC);
	};


	/// <summary>
	/// moving in periodic motion
	/// </summary>
	/// <param name="amplitude"></param>
	/// <param name="periodic"></param>
	/// <param name="accelTime"></param>
	/// <param name="repeat"></param>
	/// <param name="moveReference"></param>
	/// <returns></returns>
	bool Doosan::MovePeriodic(cli::array<float>^ amplitude, cli::array<float>^ periodic, float accelTime, unsigned char repeat, Nullable<MoveReference> moveReference) {

		// Set default parameters
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_TOOL;

		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(moveReference.Value); }

		float amplitudeC[6]{};
		for (int i = 0; i < 6; i++)
		{
			amplitudeC[i] = amplitude[i];
		}

		float periodicC[6]{};
		for (int i = 0; i < 6; i++)
		{
			periodicC[i] = periodic[i];
		}

		return DRAFramework::_move_periodic(_rbtCtrl, amplitudeC, periodicC, accelTime, repeat, moveReferenceC);
	};


	//needs to be tested

	/// <summary>
	/// target position within the joint space - async
	/// </summary>
	/// <param name="targetPos"></param>
	///	<param name="solutionSpace"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="moveReference"></param>
	/// <param name="blendingSpeedType"></param>
	/// <returns></returns>
	bool Doosan::MoveJXAsync(cli::array<float>^ targetPos, unsigned char solutionSpace, float targetVel, float targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<BlendingSpeedType> blendingSpeedType)
	{
		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;


		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(blendingSpeedType.Value); }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }

		// Initialisation &  Cast
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		return  DRAFramework::_amovejx(_rbtCtrl, targetPosC, solutionSpace, targetVel, targetAcc, targetTimeC, moveModeC, moveReferenceC, blendingSpeedTypeC);
	};



	//needs to be tested

	/// <summary>
	/// move along arc -async
	/// </summary>
	/// <param name="targetPos"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="moveReference"></param>
	/// <param name="targetAngle1"></param>
	/// <param name="targetAngle2"></param>
	/// <param name="blendingSpeedType"></param>
	/// <returns></returns>
	bool Doosan::MoveCAsync(cli::array<cli::array<float>^>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<float> targetAngle1, Nullable<float> targetAngle2, Nullable<BlendingSpeedType> blendingSpeedType) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		BLENDING_SPEED_TYPE blendingSpeedTypeC = BLENDING_SPEED_TYPE_DUPLICATE;

		float targetAngle1C = 0.0f;
		float targetAngle2C = 0.0f;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(blendingSpeedType.Value); }
		if (blendingSpeedType.HasValue) { blendingSpeedTypeC = static_cast<BLENDING_SPEED_TYPE>(blendingSpeedType.Value); }
		if (targetAngle1.HasValue) { targetAngle1C = targetAngle1.Value; }
		if (targetAngle2.HasValue) { targetAngle2C = targetAngle2.Value; }


		// Initialisation &  Cast
		float targetPosC[2][NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				targetPosC[j][i] = targetPos[j][i];
			}
		}

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}


		return  DRAFramework::_amovec(_rbtCtrl, targetPosC, targetVelC, targetAccC, targetTimeC, moveModeC, moveReferenceC, targetAngle1C, targetAngle2C, blendingSpeedTypeC);
	};



	//needs to be tested

	/// <summary>
	/// move along spline curve - joints - async
	/// </summary>
	/// <param name="targetPos"></param>
	///	<param name="posCount"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <returns></returns>
	bool Doosan::MoveSJAsync(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, float targetVel, float targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;

		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }

		// Initialisation &  Cast
		float targetPosC[MAX_SPLINE_POINT][NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			for (int j = 0; j < (int)posCount; j++)
			{
				targetPosC[j][i] = targetPos[j][i];
			}
		}

		return DRAFramework::_amovesj(_rbtCtrl, targetPosC, posCount, targetVel, targetAcc, targetTimeC, moveModeC);
	};



	//needs to be tested

	/// <summary>
	/// move along spline curve - cartesian - async
	/// </summary>
	/// <param name="targetPos"></param>
	///	<param name="posCount"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveMode"></param>
	/// <param name="moveReference"></param>
	/// <param name="velOpt"></param>
	/// <returns></returns>
	bool Doosan::MoveSXAsync(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveMode> moveMode, Nullable<MoveReference> moveReference, Nullable<SplineVelocityOption> velOpt) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_MODE moveModeC = MOVE_MODE_ABSOLUTE;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_BASE;
		SPLINE_VELOCITY_OPTION velOptC = SPLINE_VELOCITY_OPTION_DEFAULT;


		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveMode.HasValue) { moveModeC = static_cast<MOVE_MODE>(moveMode.Value); }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(moveReference.Value); }
		if (velOpt.HasValue) { velOptC = static_cast<SPLINE_VELOCITY_OPTION>(velOpt.Value); }

		// Initialisation &  Cast
		float targetPosC[MAX_SPLINE_POINT][NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			for (int j = 0; j < (int)posCount; j++)
			{
				targetPosC[j][i] = targetPos[j][i];
			}
		}

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}

		return DRAFramework::_amovesx(_rbtCtrl, targetPosC, posCount, targetVelC, targetAccC, targetTimeC, moveModeC, moveReferenceC, velOptC);
	};


	/// <summary>
	/// moving in spiral motion - async
	/// </summary>
	/// <param name="taskAxis"></param>
	/// <param name="revolution"></param>
	/// <param name="maximuRadius"></param>
	/// <param name="maximumLength"></param>
	/// <param name="targetVel"></param>
	/// <param name="targetAcc"></param>
	/// <param name="targetTime"></param>
	/// <param name="moveReference"></param>
	/// <returns></returns>
	bool Doosan::MoveSpiralAsync(TaskAxis taskAxis, float revolution, float maximuRadius, float maximumLength, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, Nullable<float> targetTime, Nullable<MoveReference> moveReference) {

		// Set default parameters
		float targetTimeC = 0.0f;
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_TOOL;
		TASK_AXIS taskAxisC = static_cast<TASK_AXIS>(taskAxis);


		if (targetTime.HasValue) { targetTimeC = targetTime.Value; }
		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(moveReference.Value); }

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}


		return DRAFramework::_amove_spiral(_rbtCtrl, taskAxisC, revolution, maximuRadius, maximumLength, targetVelC, targetAccC, targetTimeC, moveReferenceC);
	};



	/// <summary>
	/// moving in periodic motion
	/// </summary>
	/// <param name="amplitude"></param>
	/// <param name="periodic"></param>
	/// <param name="accelTime"></param>
	/// <param name="repeat"></param>
	/// <param name="moveReference"></param>
	/// <returns></returns>
	bool Doosan::MovePeriodicAsync(cli::array<float>^ amplitude, cli::array<float>^ periodic, float accelTime, unsigned char repeat, Nullable<MoveReference> moveReference) {

		// Set default parameters
		MOVE_REFERENCE moveReferenceC = MOVE_REFERENCE_TOOL;

		if (moveReference.HasValue) { moveReferenceC = static_cast<MOVE_REFERENCE>(moveReference.Value); }

		float amplitudeC[6]{};
		for (int i = 0; i < 6; i++)
		{
			amplitudeC[i] = amplitude[i];
		}

		float periodicC[6]{};
		for (int i = 0; i < 6; i++)
		{
			periodicC[i] = periodic[i];
		}

		return DRAFramework::_amove_periodic(_rbtCtrl, amplitudeC, periodicC, accelTime, repeat, moveReferenceC);
	};






	////////////////////////////////////////////////////////////////////////////
	//  GPIO Operations                                                       //
	////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// Set digital output on flange
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <param name="onOff"></param>
	/// <returns></returns>
	bool Doosan::SetToolDigitalOutput(GpioToolDigitalIndex gpioIndex, bool onOff)
	{
		return DRAFramework::_set_tool_digital_output(_rbtCtrl, static_cast<GPIO_TOOL_DIGITAL_INDEX>(gpioIndex), onOff);
	};
	/// <summary>
	/// Get digital input on flange
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <returns></returns>
	bool Doosan::GetToolDigitalInput(GpioToolDigitalIndex gpioIndex)
	{
		return  DRAFramework::_get_tool_digital_input(_rbtCtrl, static_cast<GPIO_TOOL_DIGITAL_INDEX>(gpioIndex));
	};
	/// <summary>
	/// Get digital output on flange
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <returns></returns>
	bool Doosan::GetToolDigitalOutput(GpioToolDigitalIndex gpioIndex)
	{
		return  DRAFramework::_get_tool_digital_output(_rbtCtrl, static_cast<GPIO_TOOL_DIGITAL_INDEX>(gpioIndex));
	};
	/// <summary>
	/// Set digital ouput on control-box
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <param name="onOff"></param>
	/// <returns></returns>
	bool Doosan::SetDigitalOutput(GpioCtrlboxDigitalIndex gpioIndex, bool onOff)
	{
		return  DRAFramework::_set_digital_output(_rbtCtrl, static_cast<GPIO_CTRLBOX_DIGITAL_INDEX>(gpioIndex), onOff);
	};
	/// <summary>
	/// 
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <returns></returns>
	bool Doosan::GetDigitalOutput(GpioCtrlboxDigitalIndex gpioIndex)
	{
		return  DRAFramework::_get_digital_output(_rbtCtrl, static_cast<GPIO_CTRLBOX_DIGITAL_INDEX>(gpioIndex));
	};
	/// <summary>
	/// Get digital ouput on control-box
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <returns></returns>
	bool Doosan::GetDigitalInput(GpioCtrlboxDigitalIndex gpioIndex)
	{
		return DRAFramework::_get_digital_input(_rbtCtrl, static_cast<GPIO_CTRLBOX_DIGITAL_INDEX>(gpioIndex));
	};

	/// <summary>
	/// Set analog ouput on control-box
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	bool Doosan::SetAnalogOutput(GpioCtrlboxAnalogIndex gpioIndex, float value)
	{
		return  DRAFramework::_set_analog_output(_rbtCtrl, static_cast<GPIO_CTRLBOX_ANALOG_INDEX>(gpioIndex), value);
	};
	/// <summary>
	/// Get analog inut on control-box
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <returns></returns>
	float Doosan::GetAnalogInput(GpioCtrlboxAnalogIndex gpioIndex)
	{
		return  DRAFramework::_get_analog_input(_rbtCtrl, static_cast<GPIO_CTRLBOX_ANALOG_INDEX>(gpioIndex));
	};
	/// <summary>
	/// Set analog input type on control-box
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <param name="analogType"></param>
	/// <returns></returns>
	bool Doosan::SetModeAnalogInput(GpioCtrlboxAnalogIndex gpioIndex, GpioAnalogType analogType)
	{
		// ToDo: Test default parameter
		// Set default parameters ...
		// bool SetCtrlBoxAnalogInputType(RCGpioCtrlboxAnalogIndex gpioIndex, RCGpioAnalogType analogType = GPIO_ANALOG_TYPE_CURRENT)

		return  DRAFramework::_set_mode_analog_input(_rbtCtrl, static_cast<GPIO_CTRLBOX_ANALOG_INDEX>(gpioIndex), static_cast<GPIO_ANALOG_TYPE>(analogType));
	};
	/// <summary>
	/// Set analog output type on control-box
	/// </summary>
	/// <param name="gpioIndex"></param>
	/// <param name="analogType"></param>
	/// <returns></returns>
	bool Doosan::SetModeAnalogOutput(GpioCtrlboxAnalogIndex gpioIndex, GpioAnalogType analogType)
	{
		// ToDo: Test default parameter
		// Set default parameters ...
		// SetCtrlBoxAnalogOutputType(RCGpioCtrlboxAnalogIndex gpioIndex, RCGpioAnalogType analogType = GPIO_ANALOG_TYPE_CURRENT)

		return  DRAFramework::_set_mode_analog_output(_rbtCtrl, static_cast<GPIO_CTRLBOX_ANALOG_INDEX>(gpioIndex), static_cast<GPIO_ANALOG_TYPE>(analogType));
	};


	bool Doosan::GetToolAnalogInput(int ch) {
		return DRAFramework::_get_tool_analog_input(_rbtCtrl, ch);
	};

	bool Doosan::SetToolDigitalOutputLevel(Nullable<int> lv) {
		int lvC = 12;
		if (lv.HasValue) { lvC = static_cast<int>(lv); };
		return DRAFramework::_set_tool_digital_output_level(_rbtCtrl, lvC);
	};

	/*bool Doosan::SetToolDigitalOutputType(Nullable<int> port, Nullable<OutputType> outputType) {
		int portC = 1;
		if (port.HasValue) { portC = static_cast<int>(port); }

		OUTPUT_TYPE outputTypeC = OUTPUT_TYPE_PNP;
		if (outputType.hasValue) { outputTypeC = static_cast<OUTPUT_TYPE>(outputType); }
		return DRAFramework::_set_tool_digital_output_type(_rbtCtrl,portC,outputTypeC);
	};*/



	/*	bool Doosan::FlangeSerialOpen(Nullable <int> baudrate, Nullable <ByteSize> bytesize, Nullable < ParityCheck> parity, Nullable <StopBits> stopbits)
		{
			int baudrateC = 115200;
			if(baudrate.HasValue) { baudrateC = static_cast<int>(baudrate); }

			BYTE_SIZE bytesizeC = BYTE_SIZE_EIGHTBITS;
			if(bytesize.HasValue) { bytesizeC = static_cast<BYTE_SIZE>(bytesize);}

			PARITY_CHECK parityC = PARITY_CHECK_NONE;
			if(parity.HasValue) { parityC = static_cast<PARITY_CHECK>(parity);}

			STOP_BITS stopbitsC = STOPBITS_ONE;
			if(stopbits.HasValue) { stopbitsC = static_cast<STOP_BITS>(stopbits);}


			return DRAFramework::_flange_serial_open(_rbtCtrl, baudrateC, bytesizeC, parityC, stopbitsC);
		};


		bool Doosan::FlangeSerialClose(){
			return DRAFramework::_flange_serial_close(_rbtCtrl);
		};

		bool Doosan::FlangeSerialWrite(int size, char* sendData, Nullable<int> port)
		{
			int portC = 1;
			if (port.HasValue) { portC = static_cast<int>(port); }
			return DRAFramework::_flange_serial_write(_rbtCtrl,size,sendData,portC);
		};

		FLANGE_SER_RXD_INFO Doosan::FlangeSerialRead(Nullable<float> timeout, Nullable<int> port) {
			int timeoutC = -1;
			if (timeout.HasValue) { timeoutC = static_cast<int>(timeout); }

			int portC = 1;
			if (port.HasValue) { portC = static_cast<int>(port); }

			return DRAFramework::_flange_serial_read(_rbtCtrl, timeoutC, portC);
		};*/


		// ............
		// ............
		// ............





		////////////////////////////////////////////////////////////////////////////
		//  Configuration Operations                                               //
		////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Set tool(end-effector) information
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
	bool Doosan::SetTool(String^ symbol)
	{
		return DRAFramework::_set_tool(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(symbol));
	};
	/// <summary>
	/// Add tool(end-effector) information
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="weight"></param>
	/// <param name="cog"></param>
	/// <param name="inertia"></param>
	/// <returns></returns>
	bool Doosan::AddTool(String^ symbol, float weight, cli::array<float>^ cog, cli::array<float>^ inertia)
	{
		float cogC[3]{};
		for (int i = 0; i < 3; i++)
		{
			cogC[i] = cog[i];
		}

		float inertiaC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			inertiaC[i] = inertia[i];
		}

		return DRAFramework::_add_tool(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(symbol), weight, cogC, inertiaC);
	};
	/// <summary>
	/// Del tool(end-effector) informaiton
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	bool Doosan::DeleteTool(String^ symbol)
	{
		return DRAFramework::_del_tool(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(symbol));
	};
	/// <summary>
	/// Get tool(end-effector) information
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	String^ Doosan::GetTool()
	{
		return gcnew String(DRAFramework::_get_tool(_rbtCtrl));
	};

	/// <summary>
	/// Set robot tcp information
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	bool Doosan::SetTCP(String^ symbol)
	{
		return DRAFramework::_set_tcp(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(symbol));
	};
	/// <summary>
	/// Add robot tcp information
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="postion"></param>
	/// <returns></returns>
	bool Doosan::AddTCP(String^ symbol, cli::array<float>^ postion)
	{
		float postionC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			postionC[i] = postion[i];
		}

		return DRAFramework::_add_tcp(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(symbol), postionC);
	};
	/// <summary>
	/// Del robot tcp information
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	bool Doosan::DeleteTCP(String^ symbol)
	{
		return DRAFramework::_del_tcp(_rbtCtrl, (char*)(void*)Marshal::StringToHGlobalAnsi(symbol));
	};
	/// <summary>
	/// Get robot tcp information
	/// </summary>
	/// <returns></returns>
	String^ Doosan::GetTCP()
	{
		return gcnew String(DRAFramework::_get_tcp(_rbtCtrl));
	};

	/// <summary>
	/// Set robot tool shape information
	/// </summary>
	/// <param name="strSymbol"></param>
	/// <returns></returns>
	bool Doosan::SetToolShape(String^ strSymbol)
	{
		return DRAFramework::_set_tool_shape(_rbtCtrl, msclr::interop::marshal_as<std::string>(strSymbol).c_str());
	};
	///// <summary>
	///// Add robot tool shape information
	///// </summary>
	///// <returns></returns>
	//bool Doosan::AddToolShape(String^ strSymbol)
	//{
	//	return DRAFramework::_add_tool_shape(_rbtCtrl, msclr::interop::marshal_as<std::string>(strSymbol).c_str());;
	//};
	///// <summary>
	///// Del robot tool shape information
	///// </summary>
	///// <param name="strSymbol"></param>
	///// <returns></returns>
	//bool Doosan::DelToolShape(String^ strSymbol)
	//{
	//	return DRAFramework::_del_tool_shape(_rbtCtrl, msclr::interop::marshal_as<std::string>(strSymbol).c_str());
	//};
	/// <summary>
	/// Get robot tool shape information 
	/// </summary>
	/// <returns></returns>
	String^ Doosan::GetToolShape()
	{
		return gcnew String(DRAFramework::_get_tool_shape(_rbtCtrl));
	};

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	bool Doosan::SetUserHome()
	{
		return DRAFramework::_set_user_home(_rbtCtrl);
	};

	/// <summary>
	/// 
	/// </summary>
	/// <param name="eStopType"></param>
	/// <returns></returns>
	int Doosan::ServoOff(StopType stopType)
	{
		// Cast
		STOP_TYPE stopTypeC = static_cast<STOP_TYPE>(stopType);

		return DRAFramework::_servo_off(_rbtCtrl, stopTypeC);
	};
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	int Doosan::CheckMotion()
	{
		return DRAFramework::_check_motion(_rbtCtrl);
	};

	bool Doosan::ChangeCollisionSensitivity(float sensitivity) // 0~100 
	{
		return DRAFramework::_change_collision_sensitivity(_rbtCtrl, sensitivity);
	};


	bool Doosan::SetAutoServoOff(bool funcEnable, float elapseTime)
	{
		return DRAFramework::_set_auto_servo_off(_rbtCtrl, funcEnable, elapseTime);
	};


	////////////////////////////////////////////////////////////////////////////
	//  drl program Operations                                                //
	////////////////////////////////////////////////////////////////////////////

	///// <summary>
	///// Program start
	///// </summary>
	///// <param name="robotSystem"></param>
	///// <param name="drlProgram"></param>
	///// <returns></returns>
	//bool Doosan::DrlStart(RobotSystem robotSystem, string drlProgram)
	//{
	//	return DRAFramework::_drl_start(_rbtCtrl, static_cast<ROBOT_SYSTEM>(robotSystem), drlProgram.c_str());
	//};
	///// <summary>
	///// Program stop
	///// </summary>
	///// <param name="eStopType"></param>
	///// <returns></returns>
	//bool Doosan::DrlStop(StopType eStopType)
	//{
	//	// ToDo: Test default parameter
	//	// Set default parameters ...
	//	// STOP_TYPE eStopType = STOP_TYPE_QUICK
	//	return DRAFramework::_drl_stop(_rbtCtrl, static_cast<STOP_TYPE>(eStopType));
	//};
	///// <summary>
	///// Program pause
	///// </summary>
	///// <returns></returns>
	//bool Doosan::DrlPause()
	//{
	//	return DRAFramework::_drl_pause(_rbtCtrl);
	//};
	///// <summary>
	///// Program resume
	///// </summary>
	///// <returns></returns>
	//bool Doosan::DrlResume()
	//{
	//	return DRAFramework::_drl_resume(_rbtCtrl);
	//};
	/// <summary>
	/// WREWREW
	/// </summary>
	/// <param name="speed">ERQWETWT</param>
	/// <returns>QWETWET</returns>
	bool Doosan::ChangeOperationSpeed(float speed)
	{
		return  DRAFramework::_change_operation_speed(_rbtCtrl, speed);
	};

























	////////////////////////////////////////////////////////////////////////////
	// coordinate system control                                              //
	////////////////////////////////////////////////////////////////////////////
	// ToDo: Testing ...
	int Doosan::SetUserCartCoord1(int reqId, cli::array<float>^ targetPos, Nullable<CoordinateSystem> targetRef)
	{
		// Set default parameters
		COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
		if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }

		// Initialisation & Cast
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_set_user_cart_coord1(_rbtCtrl, reqId, targetPosC, targetRefC);
	};

	// ToDo: Testing ...
	int Doosan::SetUserCartCoord2(cli::array<float, 2>^ targetPos, cli::array<float>^ targetOrg, Nullable<CoordinateSystem> targetRef)
	{
		// Set default parameters
		COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
		if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }

		// Initialisation & Cast
		float targetPosC[3][NUM_TASK]{};
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < NUM_TASK; j++)
			{
				targetPosC[i][j] = targetPos[i, j];
			}
		}

		float targetOrgC[3]{};
		for (int i = 0; i < 3; i++)
		{
			targetOrgC[i] = targetOrg[i];
		}

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_set_user_cart_coord2(_rbtCtrl, targetPosC, targetOrgC, targetRefC);
	};

	// ToDo: Testing ...
	int Doosan::SetUserCartCoord3(cli::array<float, 2>^ targetVec, cli::array<float>^ targetOrg, Nullable<CoordinateSystem> targetRef)
	{
		// Set default parameters
		COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
		if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }

		// Initialisation & Cast
		float targetVecC[2][3]{};
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				targetVecC[i][j] = targetVec[i, j];
			}
		}

		float targetOrgC[3]{};
		for (int i = 0; i < 3; i++)
		{
			targetOrgC[i] = targetOrg[i];
		}

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_set_user_cart_coord3(_rbtCtrl, targetVecC, targetOrgC, targetRefC);
	};

	// ToDo: Testing ...
	RobotPose Doosan::CoordTransform(cli::array<float>^ targetPos, CoordinateSystem inCoordSystem, CoordinateSystem outCoordSystem)
	{
		// Set default parameters
		COORDINATE_SYSTEM inCoordSystemC = static_cast<COORDINATE_SYSTEM>(inCoordSystem);
		COORDINATE_SYSTEM outCoordSystemC = static_cast<COORDINATE_SYSTEM>(outCoordSystem);

		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		LPROBOT_POSE coordTransformC = DRAFramework::_coord_transform(_rbtCtrl, targetPosC, inCoordSystemC, outCoordSystemC);
		RobotPose coordTransformWrapper{};
		// ToDo: Test initialisation
		coordTransformWrapper._fPosition = gcnew cli::array<float>(NUM_JOINT);

		// ToDo: Test convertaion
		coordTransformWrapper._fPosition[0] = coordTransformC->_fPosition[0];
		coordTransformWrapper._fPosition[1] = coordTransformC->_fPosition[1];
		coordTransformWrapper._fPosition[2] = coordTransformC->_fPosition[2];
		coordTransformWrapper._fPosition[3] = coordTransformC->_fPosition[3];
		coordTransformWrapper._fPosition[4] = coordTransformC->_fPosition[4];
		coordTransformWrapper._fPosition[5] = coordTransformC->_fPosition[5];

		throw gcnew System::Exception("ToDo: Testing ...");
		return coordTransformWrapper;
	};

	// ToDo: Testing ...
	bool Doosan::SetRefCoord(CoordinateSystem targetCoordSystem)
	{
		// Set default parameters
		COORDINATE_SYSTEM targetCoordSystemC = static_cast<COORDINATE_SYSTEM>(targetCoordSystem);

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_set_ref_coord(_rbtCtrl, targetCoordSystemC);
	};

	// ToDo: Testing ...
	RobotPose Doosan::CalcCoord(unsigned short cnt, unsigned short inputMode, CoordinateSystem targetRef, cli::array<float>^ targetPos1, cli::array<float>^ targetPos2, cli::array<float>^ targetPos3, cli::array<float>^ targetPos4)
	{
		// Set default parameters
		COORDINATE_SYSTEM targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef);

		float targetPos1C[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPos1C[i] = targetPos1[i];
		}

		float targetPos2C[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPos2C[i] = targetPos2[i];
		}

		float targetPos3C[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPos3C[i] = targetPos3[i];
		}

		float targetPos4C[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPos4C[i] = targetPos4[i];
		}

		LPROBOT_POSE calcCoordC = DRAFramework::_calc_coord(_rbtCtrl, cnt, inputMode, targetRefC, targetPos1C, targetPos2C, targetPos3C, targetPos4C);
		RobotPose calcCoordWrapper{};
		// ToDo: Test initialisation
		calcCoordWrapper._fPosition = gcnew cli::array<float>(NUM_JOINT);

		// ToDo: Test convertaion
		calcCoordWrapper._fPosition[0] = calcCoordC->_fPosition[0];
		calcCoordWrapper._fPosition[1] = calcCoordC->_fPosition[1];
		calcCoordWrapper._fPosition[2] = calcCoordC->_fPosition[2];
		calcCoordWrapper._fPosition[3] = calcCoordC->_fPosition[3];
		calcCoordWrapper._fPosition[4] = calcCoordC->_fPosition[4];
		calcCoordWrapper._fPosition[5] = calcCoordC->_fPosition[5];

		throw gcnew System::Exception("ToDo: Testing ...");
		return calcCoordWrapper;
	};

	// ToDo: Testing ...
	UserCoordinate Doosan::GetUserCartCoord(int reqId)
	{
		LPUSER_COORDINATE userCartCoordC = DRAFramework::_get_user_cart_coord(_rbtCtrl, reqId);
		UserCoordinate userCartCoordWrapper{};
		// ToDo: Test initialisation
		userCartCoordWrapper._fTargetPos = gcnew cli::array<float>(NUM_TASK);

		// ToDo: Test convertaion
		userCartCoordWrapper._iReqId = userCartCoordC->_iReqId;
		userCartCoordWrapper._iTargetRef = userCartCoordC->_iTargetRef;
		userCartCoordWrapper._fTargetPos[0] = userCartCoordC->_fTargetPos[0];
		userCartCoordWrapper._fTargetPos[1] = userCartCoordC->_fTargetPos[1];
		userCartCoordWrapper._fTargetPos[2] = userCartCoordC->_fTargetPos[2];
		userCartCoordWrapper._fTargetPos[3] = userCartCoordC->_fTargetPos[3];
		userCartCoordWrapper._fTargetPos[4] = userCartCoordC->_fTargetPos[4];
		userCartCoordWrapper._fTargetPos[5] = userCartCoordC->_fTargetPos[5];

		throw gcnew System::Exception("ToDo: Testing ...");
		return userCartCoordWrapper;
	};

	// ToDo: Testing ...
	int Doosan::OverwritUuserCartCoord(bool targetUpdate, int reqId, float targetPos[NUM_TASK], Nullable<CoordinateSystem> targetRef)
	{
		// Set default parameters
		COORDINATE_SYSTEM targetRefC = COORDINATE_SYSTEM_BASE;
		if (targetRef.HasValue) { targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef.Value); }

		// Initialisation & Cast
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_overwrite_user_cart_coord(_rbtCtrl, targetUpdate, reqId, targetPosC, targetRefC);
	};

	// ToDo: Testing ...
	bool Doosan::EnablAlterMotion(int cycleTime, PATH_MODE pathMode, CoordinateSystem targetRef, cli::array<float>^ limitDpos, cli::array<float>^ limitDposPer)
	{
		// Set default parameters
		PATH_MODE pathModeC = static_cast<PATH_MODE>(pathMode);

		COORDINATE_SYSTEM targetRefC = static_cast<COORDINATE_SYSTEM>(targetRef);

		float limitDposC[2]{};
		for (int i = 0; i < 2; i++)
		{
			limitDposC[i] = limitDpos[i];
		}

		float limitDposPerC[2]{};
		for (int i = 0; i < 2; i++)
		{
			limitDposPerC[i] = limitDposPer[i];
		}

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_enable_alter_motion(_rbtCtrl, cycleTime, pathModeC, targetRefC, limitDposC, limitDposPerC);
	};

	// ToDo: Testing ...
	bool Doosan::DisableAlterMotion()
	{
		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_disable_alter_motion(_rbtCtrl);
	};

	// ToDo: Testing ...
	bool Doosan::AlterMotion(cli::array<float>^ targetPos)
	{
		// Set default parameters
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_alter_motion(_rbtCtrl, targetPosC);
	};

	// ToDo: Testing ...
	bool Doosan::SetSingularityHandling(SingularityAvoidance mode)
	{
		// Set default parameters
		SINGULARITY_AVOIDANCE modeC = static_cast<SINGULARITY_AVOIDANCE>(mode);

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_set_singularity_handling(_rbtCtrl, modeC);
	};

	// ToDo: Testing ...
	bool Doosan::ConfigProgramWatchVariable(VariableType division, DataType type, String^ name, String^ data)
	{
		// Set default parameters
		VARIABLE_TYPE divisionC = static_cast<VARIABLE_TYPE>(division);
		DATA_TYPE typeC = static_cast<DATA_TYPE>(type);

		throw gcnew System::Exception("ToDo: Testing ...");
		return DRAFramework::_config_program_watch_variable(_rbtCtrl, divisionC, typeC, msclr::interop::marshal_as<std::string>(name).c_str(), msclr::interop::marshal_as<std::string>(data).c_str());
	};

	// ToDo: Testing ...
	bool Doosan::SaveSubProgram(int targetType, String^ fileName, String^ drlProgram)
	{
		throw gcnew System::Exception("ToDo: Testing ...");
		return  DRAFramework::_save_sub_program(_rbtCtrl, targetType, msclr::interop::marshal_as<std::string>(fileName).c_str(), msclr::interop::marshal_as<std::string>(drlProgram).c_str());
	};

	bool Doosan::SetupMonitoringVersion(int version)
	{
		return DRAFramework::_setup_monitoring_version(_rbtCtrl, version);
	};

	bool Doosan::SystemShutDown()
	{
		return DRAFramework::_system_shut_down(_rbtCtrl);
	};

	bool Doosan::ServoJ(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime) {
		// Set default parameters
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		float targetVelC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetAccC[i] = targetAcc[i];
		}

		return DRAFramework::_servoj(_rbtCtrl, targetPosC, targetVelC, targetAccC, targetTime);
	};

	bool Doosan::ServoL(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime) {
		// Set default parameters
		float targetPosC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetPosC[i] = targetPos[i];
		}

		float targetVelC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}

		return DRAFramework::_servol(_rbtCtrl, targetPosC, targetVelC, targetAccC, targetTime);
	};

	bool Doosan::SpeedJ(cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime) {
		float targetVelC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetAccC[i] = targetAcc[i];
		}
		return DRAFramework::_speedj(_rbtCtrl, targetVelC, targetAccC, targetTime);
	}

	bool Doosan::SpeedL(cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime) {
		float targetVelC[NUM_TASK]{};
		for (int i = 0; i < NUM_TASK; i++)
		{
			targetVelC[i] = targetVel[i];
		}

		float targetAccC[2]{};
		for (int i = 0; i < 2; i++)
		{
			targetAccC[i] = targetAcc[i];
		}
		return DRAFramework::_speedl(_rbtCtrl, targetVelC, targetAccC, targetTime);
	}
}
