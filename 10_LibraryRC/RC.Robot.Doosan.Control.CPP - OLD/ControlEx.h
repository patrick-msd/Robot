#pragma once

#if defined(_WIN32)
#if defined(DRFL_EXPORTS)
#define DRFL_API __declspec(dllexport)
#else
#define DRFL_API __declspec(dllimport)
#endif
#endif

#if !defined(DRFL_API)
#define DRFL_API
#endif

#include <vcclr.h>
#include <stdio.h>
#include <string.h>

#include <DRFC.h>
#include <DRFL.h>
#include <DRFLEx.h>
#include <DRFS.h>

#include "ControlC.h"
#include "ControlS.h"
#include <thread>

using namespace std;
using namespace System;
using namespace System::IO;
using namespace System::Runtime::InteropServices;

namespace RCRobotDoosanControl
{
	// Define a delegate type
	public delegate void ManagedTOnMonitoringStateCB(const RobotState);
	public delegate void ManagedTOnMonitoringDataCB(IntPtr ptr);
	public delegate void ManagedTOnMonitoringDataCBSharp(const MonitoringData);
	public delegate void ManagedTOnMonitoringDataExCB(IntPtr ptr);
	public delegate void ManagedTOnMonitoringDataExCBCSharp(const MonitoringDataEx);
	public delegate void ManagedTOnMonitoringCtrlIOCB(IntPtr ptr);
	public delegate void ManagedTOnMonitoringCtrlIOCBCSharp(const MonitoringCtrlio);
	public delegate void ManagedTOnMonitoringCtrlIOExCB(IntPtr ptr);
	public delegate void ManagedTOnMonitoringCtrlIOExCBCSharp(const MonitoringCtrlioEx);
	public delegate void ManagedTOnMonitoringModbusCB(IntPtr ptr);
	public delegate void ManagedTOnMonitoringModbusCBCSharp(const MonitoringModbus);
	public delegate void ManagedTOnMonitoringSpeedModeCB(const MonitoringSpeed);
	public delegate void ManagedTOnMonitoringAccessControlCB(const MonitoringAccessControl);
	public delegate void ManagedTOnLogAlarmCB(IntPtr ptr);
	public delegate void ManagedTOnLogAlarmCBCSharp(const LogAlarm);
	public delegate void ManagedTOnTpPopupCB(IntPtr ptr);
	public delegate void ManagedTOnTpPopupCBCSharp(const MessagePopup);
	public delegate void ManagedTOnTpLogCB(const char[256]);
	public delegate void ManagedTOnTpProgressCB(IntPtr ptr);
	public delegate void ManagedTOnTpProgressCBCSharp(const MessageProgress);
	public delegate void ManagedTOnTpGetUserInputCB(IntPtr ptr);
	public delegate void ManagedTOnTpGetUserInputCBCSharp(const MessageInput);
	public delegate void ManagedTOnProgramStoppedCB(const ProgramStopCause);
	public delegate void ManagedTOnHommingCompletedCB();
	public delegate void ManagedTOnTpInitializingCompletedCB(int id);
	public delegate void ManagedTOnMasteringNeedCB();
	public delegate void ManagedTOnDisconnectedCB(int id);

	public delegate void ManagedTOnMonitoringRobotSystemCB();
	public delegate void ManagedTOnMonitoringUpdateModuleCB();
	public delegate void ManagedTOnMonitoringSafetyStateCB();

	/// <summary>
	/// Doosan Robots API Wrapper for CSharp
	/// </summary>
	public ref class Doosan
	{
	private:
		////////////////////////////////////////////////////////////////////////////
		// Variable                                                               //
		////////////////////////////////////////////////////////////////////////////
		DRAFramework::LPROBOTCONTROL _rbtCtrl;


		//bool _hasControlAuthority = false;
		//bool _tpInitailizingComplted = false;
		//bool _mState = false;
		//bool _stop = false;
		//bool _alterFlag = false;


		float* _axisDirection;

	public:
		////////////////////////////////////////////////////////////////////////////
		// Variable                                                               //
		////////////////////////////////////////////////////////////////////////////

		bool _hasControlAuthority = false;
		bool _tpInitailizingComplted = false;
		bool _mState = false;
		bool _stop = false;
		bool _alterFlag = false;

		//float* _axisDirection;


		////////////////////////////////////////////////////////////////////////////
		// Delegate types                                                         //
		////////////////////////////////////////////////////////////////////////////
		//delegate void MyDelegate(String^ message);
		//delegate void ProgressDelegate(int progress);
		//delegate void StatusDelegate(String^ status);
		//delegate void ManagedCallbackHandler(int);
		//delegate void ManagedTOnTpInitializingCompletedCB1(int value, Doosan^ sender);
		//delegate void ManagedTOnTpInitializingCompletedCB2(int value);


		////////////////////////////////////////////////////////////////////////////
		// Instance                                                               //
		////////////////////////////////////////////////////////////////////////////
		Doosan();
		~Doosan(); // Dispose()
		!Doosan(); // Finalize()


		////////////////////////////////////////////////////////////////////////////
		// Connection                                                             //
		////////////////////////////////////////////////////////////////////////////
		bool OpenConnection(String^ ipAddress, unsigned int port);
		bool CloseConnection();

		// ToDo: ...
		//bool OpenRtConnection(String^ ipAddress, unsigned int port);
		// ToDo: ...
		//bool CloseRtConnection();


		////////////////////////////////////////////////////////////////////////////
		// Configuration                                                          //
		////////////////////////////////////////////////////////////////////////////
		void SetAxisDirection(float X, float Y, float Z, float A, float B, float C);


		////////////////////////////////////////////////////////////////////////////
		// Attributes                                                             //
		////////////////////////////////////////////////////////////////////////////
		SystemVersion GetSystemVersion();
		String^ GetLibraryVersion();

		RobotMode GetRobotMode();
		bool SetRobotMode(RobotMode RobotMode);

		RobotState GetRobotState();
		bool SetRobotControl(RobotControl robotControl);
		ControlMode GetControlMode();

		RobotSystem GetRobotSystem();
		bool SetRobotSystem(RobotSystem robotSystem);

		bool SetRobotSpeedMode(SpeedMode speedMode);
		SpeedMode GetRobotSpeedMode();

		RobotPose GetCurrentPose(RobotSpace spaceType);
		//cli::array<float>^ GetCurrentRotm([Optional] Nullable<RCCoordinateSystem> targetRef);
		unsigned char GetCurrentSolutionSpace();
		RobotPose GetCurrentPosj();
		RobotSpace GetControlSpace();
		RobotVel GetCurrentVelj();
		RobotPose GetDesiredPosj();
		RobotPose GetCurnetToolFlangePosx();
		RobotVel GetCurrentVelx();
		//LPROBOT_POSE get_desired_posx() { return _GetDesiredPosX(_rbtCtrl); };
		RobotPose GetDesiredPosx();
		RobotVel GetDesiredVelx();
		RobotForce GetJointTorque();
		RobotForce GetExternalTorque();
		RobotForce GetToolForce();

		DrlProgramState GetProgramState();

		void SetSafeStopResetType(SafeStopResetType resetType);

		LogAlarm GetLastAlarm();

		unsigned char GetSolutionSpace(cli::array<float>^ targetPos);

		// GetSafetyConfiguration ToDo?


		float GetOrientationError(cli::array<float>^ fPosition1, cli::array<float>^ fPosition2, TaskAxis TaskAxis);


		////////////////////////////////////////////////////////////////////////////
		// Access control                                                         //
		////////////////////////////////////////////////////////////////////////////

		// manage access control
		bool ManageAccessControll(ManageAccessControl accessControl);


		//////////////////////////////////////////////////////////////////////////////
		//// Callback operation                                                     //
		//////////////////////////////////////////////////////////////////////////////
		ManagedTOnMonitoringStateCB^ ManagedTOnMonitoringStateCBHandler;
		void OnMonitoringStateCB(const RobotState value);

		ManagedTOnMonitoringDataCBSharp^ ManagedTOnMonitoringDataCBHandler;
		void OnMonitoringDataCB(IntPtr value);

		ManagedTOnMonitoringDataExCBCSharp^ ManagedTOnMonitoringDataExCBHandler;
		void OnMonitoringDataExCB(IntPtr value);

		ManagedTOnMonitoringCtrlIOCBCSharp^ ManagedTOnMonitoringCtrlIOCBHandler;
		void OnMonitoringCtrlIO(IntPtr value);

		ManagedTOnMonitoringCtrlIOExCBCSharp^ ManagedTOnMonitoringCtrlIOExCBHandler;
		void OnMonitoringCtrlIOEx(IntPtr value);

		ManagedTOnMonitoringModbusCBCSharp^ ManagedTOnMonitoringModbusCBHandler;
		void OnMonitoringModbus(IntPtr value);

		ManagedTOnMonitoringSpeedModeCB^ ManagedTOnMonitoringSpeedModeCBHandler;
		void OnMonitoringSpeedMode(const MonitoringSpeed value);

		ManagedTOnMonitoringAccessControlCB^ ManagedTOnMonitoringAccessControlCBHandler;
		void OnMonitoringAccessControlCB(const MonitoringAccessControl value);

		ManagedTOnLogAlarmCBCSharp^ ManagedTOnLogAlarmCBHandler;
		void OnLogAlarmCB(IntPtr ptr);

		ManagedTOnTpPopupCBCSharp^ ManagedTOnTpPopupCBHandler;
		void OnTpPopup(IntPtr ptr);

		//ManagedTOnTpLogCB^ ManagedTOnTpLogCBHandler;
		//void SetOnTpLog(const char[256]);

		ManagedTOnTpProgressCBCSharp^ ManagedTOnTpProgressCBHandler;
		void OnTpProgress(IntPtr ptr);

		ManagedTOnTpGetUserInputCBCSharp^ ManagedTOnTpGetUserInputCBHandler;
		void OnTpGetUserInputCB(IntPtr ptr);

		ManagedTOnProgramStoppedCB^ ManagedTOnProgramStoppedCBHandler;
		void OnProgramStopped(const ProgramStopCause value);

		ManagedTOnHommingCompletedCB^ ManagedTOnHommingCompletedCBHandler;
		void OnHommingCompletedCB();

		ManagedTOnTpInitializingCompletedCB^ ManagedTOnTpInitializingCompletedCBHandler;
		void OnTpInitializingCompletedCB(int id);

		ManagedTOnMasteringNeedCB^ ManagedTOnMasteringNeedCBHandler;
		void SetOnMasteringNeed();

		ManagedTOnDisconnectedCB^ ManagedTOnDisconnectedCBHandler;
		void OnDisconnected(int id);

		













		// !!!!!!!!!!!!  FAST implemantation !!!!!!!!!!!!!!!!!!



		//LPROBOT_POSE trans(float fSourcePos[NUM_TASK], float fOffset[NUM_TASK], COORDINATE_SYSTEM eSourceRef = COORDINATE_SYSTEM_BASE, COORDINATE_SYSTEM eTargetRef = COORDINATE_SYSTEM_BASE) { return _trans(_rbtCtrl, fSourcePos, fOffset, eSourceRef, eTargetRef); };
		//LPROBOT_POSE ikin(float fSourcePos[NUM_TASK], unsigned char iSolutionSpace, COORDINATE_SYSTEM eTargetRef = COORDINATE_SYSTEM_BASE) { return _ikin(_rbtCtrl, fSourcePos, iSolutionSpace, eTargetRef); };
		//LPINVERSE_KINEMATIC_RESPONSE ikin(float fSourcePos[NUM_TASK], unsigned char iSolutionSpace, COORDINATE_SYSTEM eTargetRef, unsigned char iRefPosOpt) { return _ikin_ex(_rbtCtrl, fSourcePos, iSolutionSpace, eTargetRef, iRefPosOpt); };
		//LPROBOT_POSE fkin(float fSourcePos[NUM_JOINT], COORDINATE_SYSTEM eTargetRef = COORDINATE_SYSTEM_BASE) { return _fkin(_rbtCtrl, fSourcePos, eTargetRef); };

		//unsigned char get_solution_space(float fTargetPos[NUM_JOINT]) { return _get_solution_space(_rbtCtrl, fTargetPos); };
		RobotTaskPose GetCurrentPosx([Optional] Nullable<CoordinateSystem> coodType);
		//LPROBOT_POSE get_desired_posx(COORDINATE_SYSTEM eCoodType = COORDINATE_SYSTEM_BASE) { return _get_desired_posx(_rbtCtrl, eCoodType); };
		
		

		//double get_override_speed() { return _get_override_speed(_rbtCtrl); };

		//float get_workpiece_weight() { return _get_workpiece_weight(_rbtCtrl); };
		float GetWorkpieceWeight();

		//bool reset_workpiece_weight() { return _reset_workpiece_weight(_rbtCtrl); };
		bool ResetWorkpieceWeight();
		//bool tp_popup_response(POPUP_RESPONSE eRes) { return _tp_popup_response(_rbtCtrl, eRes); };
		//bool tp_get_user_input_response(string strUserInput) { return _tp_get_user_input_response(_rbtCtrl, strUserInput.c_str()); };


		////////////////////////////////////////////////////////////////////////////
		//  motion Operations                                                     //
		////////////////////////////////////////////////////////////////////////////
		bool Jog(JogAxis jogAxis, MoveReference moveReference, float velocity);
		bool MultiJog(cli::array<float>^ targetPos, MoveReference moveReference, float velocity);
		bool Home(MoveHome mode, [Optional] Nullable<unsigned char> run);


		bool Stop([Optional] Nullable<StopType> stopType);
		bool MovePause();
		bool MoveResume();
		bool MoveWait();
		LPROBOT_POSE Trans(cli::array<float>^ sourcePos, cli::array<float>^ offset, [Optional] Nullable <CoordinateSystem> sourceRef, [Optional] Nullable <CoordinateSystem> targetRef);
		LPROBOT_POSE Fkin(cli::array<float>^ sourcePos, [Optional] Nullable <CoordinateSystem> targetRef);
		LPROBOT_POSE Ikin(cli::array<float>^ sourcePos, unsigned char solutionSpace, [Optional] Nullable <CoordinateSystem> targetRef);
		

		bool ServoJ(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime);
		bool ServoL(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime);
		bool SpeedJ(cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime);
		bool SpeedL(cli::array<float>^ targetVel, cli::array<float>^ targetAcc, float targetTime);

		bool MoveJ(cli::array<float>^ targetPos, float targetVel, float targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<float> blendingRadius, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);
		//DRFL_API bool _movej_ex(LPROBOTCONTROL pCtrl, float fTargetPos[NUM_JOINT], float fTargetVel[NUM_JOINT], float fTargetAcc[NUM_JOINT], float fTargetTime = 0.f, MOVE_MODE eMoveMode = MOVE_MODE_ABSOLUTE, float fBlendingRadius = 0.f, BLENDING_SPEED_TYPE eBlendingType = BLENDING_SPEED_TYPE_DUPLICATE);
		bool MoveJAsync(cli::array<float>^ targetPos, float targetVel, float targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);
		bool MoveL(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<float> blendingRadius, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);
		bool MoveLAsync(cli::array<float>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);

		
		//needs to be tested
		bool MoveJX(cli::array<float>^ targetPos, unsigned char solutionSpace, float targetVel, float targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<float> blendingRadius, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);
		bool MoveC(cli::array<cli::array<float>^>^, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<float> targetAngle1, [Optional] Nullable<float> targetAngle2, [Optional] Nullable<float> blendingRadius, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);
		
		bool MoveSJ(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, float targetVel, float targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode);
		bool MoveSX(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<SplineVelocityOption> velOpt);
		
		bool MoveSpiral(TaskAxis taskAxis, float revolution, float maximuRadius, float maximumLength, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveReference> moveReference);

		bool MovePeriodic(cli::array<float>^ amplitude, cli::array<float>^ periodic, float accelTime, unsigned char repeat, [Optional] Nullable<MoveReference> moveReference);

		//bool MoveB(cli::array<MOVE_POSB>^ targetPos, unsigned char posCount, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference);
		
		bool MoveJXAsync(cli::array<float>^ targetPos, unsigned char solutionSpace, float targetVel, float targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);
		bool MoveCAsync(cli::array<cli::array<float>^>^ targetPos, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<float> targetAngle1, [Optional] Nullable<float> targetAngle2, [Optional] Nullable<BlendingSpeedType> blendingSpeedType);
		bool MoveSJAsync(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, float targetVel, float targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode);
		bool MoveSXAsync(cli::array<cli::array<float>^>^ targetPos, unsigned char posCount, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveMode> moveMode, [Optional] Nullable<MoveReference> moveReference, [Optional] Nullable<SplineVelocityOption> velOpt);

		//MoveBAsync todo...

		bool MoveSpiralAsync(TaskAxis taskAxis, float revolution, float maximuRadius, float maximumLength, cli::array<float>^ targetVel, cli::array<float>^ targetAcc, [Optional] Nullable<float> targetTime, [Optional] Nullable<MoveReference> moveReference);
		bool MovePeriodicAsync(cli::array<float>^ amplitude, cli::array<float>^ periodic, float accelTime, unsigned char repeat, [Optional] Nullable<MoveReference> moveReference);


		// ............
		// ............
		// ............




		////////////////////////////////////////////////////////////////////////////
		//  GPIO Operations                                                       //
		////////////////////////////////////////////////////////////////////////////
		// set digital output on flange
		bool SetToolDigitalOutput(GpioToolDigitalIndex gpioIndex, bool onOff);
		// get digital input on flange
		bool GetToolDigitalInput(GpioToolDigitalIndex gpioIndex);
		bool GetToolDigitalOutput(GpioToolDigitalIndex gpioIndex);
		// set digital ouput on control-box
		bool SetDigitalOutput(GpioCtrlboxDigitalIndex gpioIndex, bool onOff);
		bool GetDigitalOutput(GpioCtrlboxDigitalIndex gpioIndex);
		// get digital input on control-box
		bool GetDigitalInput(GpioCtrlboxDigitalIndex gpioIndex);

		// set analog ouput on control-box
		bool SetAnalogOutput(GpioCtrlboxAnalogIndex gpioIndex, float value);
		// get analog inut on control-box
		float GetAnalogInput(GpioCtrlboxAnalogIndex gpioIndex);
		// set analog input type on control-box
		bool SetModeAnalogInput(GpioCtrlboxAnalogIndex gpioIndex, GpioAnalogType analogType);
		// set analog output type on control-box
		bool SetModeAnalogOutput(GpioCtrlboxAnalogIndex gpioIndex, GpioAnalogType analogType);



		// ............
		// ............
		// ............



		////////////////////////////////////////////////////////////////////////////
		//  Configuration Operations                                               //
		////////////////////////////////////////////////////////////////////////////
		bool SetTool(String^ symbol);
		bool AddTool(String^ symbol, float weight, cli::array<float>^ cog, cli::array<float>^ inertia);
		bool DeleteTool(String^ symbol);
		String^ GetTool();

		bool SetTCP(String^ symbol);
		bool AddTCP(String^ symbol, cli::array<float>^ postion);
		bool DeleteTCP(String^ symbol);
		String^ GetTCP();

		bool SetToolShape(String^ strSymbol);
		//bool AddToolShape(String^ strSymbol);
		//bool DelToolShape(String^ strSymbol);
		String^ GetToolShape();

		bool SetUserHome();

		int ServoOff(StopType stopType);
		int CheckMotion();

		bool ChangeCollisionSensitivity(float sensitivity);

		bool SetAutoServoOff(bool funcEnable, float elapseTime);

		bool GetToolAnalogInput(int ch);

		bool SetToolDigitalOutputLevel([Optional]Nullable<int> lv);

		//bool SetToolDigitalOutputType([Optional] Nullable<int> port, [Optional] Nullable<OutputType> outputType);

	/*	bool FlangeSerialOpen(Nullable <int> baudrate, Nullable <ByteSize> bytesize, Nullable < ParityCheck> parity, Nullable <StopBits> stopbits);
		bool FlangeSerialClose();
		bool FlangeSerialWrite(int size, char* sendData, Nullable<int> port); 
		FLANGE_SER_RXD_INFO FlangeSerialRead(Nullable<float> timeout, Nullable<int> port);*/

		////////////////////////////////////////////////////////////////////////////
		//  drl program Operations                                                //
		////////////////////////////////////////////////////////////////////////////
		//bool DrlStart(RobotSystem robotSystem, string drlProgram);
		//bool DrlStop(StopType eStopType);
		//bool DrlPause();
		//bool DrlResume();
		bool ChangeOperationSpeed(float speed);







		////////////////////////////////////////////////////////////////////////////
		//  coordinate system control                                             //
		////////////////////////////////////////////////////////////////////////////
		int SetUserCartCoord1(int reqId, cli::array<float>^ targetPos, [Optional] Nullable<CoordinateSystem> targetRef);
		int SetUserCartCoord2(cli::array<float, 2>^ targetPos, cli::array<float>^ targetOrg, [Optional] Nullable<CoordinateSystem> targetRef);
		int SetUserCartCoord3(cli::array<float, 2>^ targetVec, cli::array<float>^ targetOrg, [Optional] Nullable<CoordinateSystem> targetRef);
		RobotPose CoordTransform(cli::array<float>^ targetPos, CoordinateSystem inCoordSystem, CoordinateSystem outCoordSystem);
		bool SetRefCoord(CoordinateSystem targetCoordSystem);
		RobotPose CalcCoord(unsigned short cnt, unsigned short inputMode, CoordinateSystem targetRef, cli::array<float>^ targetPos1, cli::array<float>^ targetPos2, cli::array<float>^ targetPos3, cli::array<float>^ targetPos4);
		UserCoordinate GetUserCartCoord(int reqId);
		int OverwritUuserCartCoord(bool targetUpdate, int reqId, float targetPos[NUM_TASK], [Optional] Nullable<CoordinateSystem> targetRef);
		bool EnablAlterMotion(int cycleTime, PATH_MODE pathMode, CoordinateSystem targetRef, cli::array<float>^ limitDpos, cli::array<float>^ limitDposPer);
		bool DisableAlterMotion();
		bool AlterMotion(cli::array<float>^ targetPos);
		bool SetSingularityHandling(SingularityAvoidance mode);
		bool ConfigProgramWatchVariable(VariableType division, DataType type, String^ name, String^ data);
		bool SaveSubProgram(int targetType, String^ fileName, String^ drlProgram);
		bool SetupMonitoringVersion(int version);
		bool SystemShutDown();
	};
}
