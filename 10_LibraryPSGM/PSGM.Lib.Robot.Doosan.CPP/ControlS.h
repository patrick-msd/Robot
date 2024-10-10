#pragma once

#include "ControlC.h"

#ifdef __cplusplus
#include <vcclr.h>
#include <stdio.h>
#include <string.h>
#include <list>
using namespace std;
using namespace System;
using namespace System::IO;
#endif

namespace PSGMRobotDoosanControl
{
#pragma pack(1)

	public value struct SystemVersion {
		// smarttp version
		String^ _szSmartTp;
		// controller version
		String^ _szController;
		// interpreter version
		String^ _szInterpreter;
		// inverter version
		String^ _szInverter;
		// SafetyBoard version
		String^ _szSafetyBoard;
		// robot serial number
		String^ _szRobotSerial;
		// robot model number
		String^ _szRobotModel;
		// jts board version
		String^ _szJTSBoard;
		// flange board version
		String^ _szFlangeBoard;
	};

	public value struct RobotMonitoringJoint
	{
		// Position Actual Value in INC
		cli::array<float>^ _fActualPos;
		// Position Actual Value in ABS
		cli::array<float>^ _fActualAbs;
		// Velocity Actual Value
		cli::array<float>^ _fActualVel;
		// Joint Error
		cli::array<float>^ _fActualErr;
		// Target Position
		cli::array<float>^ _fTargetPos;
		// Target Velocity
		cli::array<float>^ _fTargetVel;
	};

	public value struct RobotMonitoringTask
	{
		// Position Actual Value(0: tool, 1: flange)
		cli::array<float, 2>^ _fActualPos;
		// Velocity Actual Value
		cli::array<float>^ _fActualVel;
		// Task Error
		cli::array<float>^ _fActualErr;
		// Target Position
		cli::array<float>^ _fTargetPos;
		// Target Velocity
		cli::array<float>^ _fTargetVel;
		// Solution Space
		unsigned char _iSolutionSpace;
		// Rotation Matrix
		cli::array<float, 2>^ _fRotationMatrix;
	};

	public value struct RobotMonitoringWorld
	{
		/* world to base relation */
		cli::array<float>^ _fActualW2B;
		/* Position Actual Value  (0:tool, 1:flange) */
		cli::array<float, 2>^ _fActualPos;
		/* Velocity Actual Value */
		cli::array<float>^ _fActualVel;
		/* External Task Force/Torque */
		cli::array<float>^ _fActualETT;
		/* Target Position */
		cli::array<float>^ _fTargetPos;;
		/* Target Velocity */
		cli::array<float>^ _fTargetVel;
		/* Rotation Matrix */
		cli::array<float, 2>^ _fRotationMatrix;
	};

	public value struct RobotMonitoringUser
	{
		/* actual user coord no */
		unsigned char _iActualUCN;
		/* base: 0 world: 2 */
		unsigned char _iParent;
		/* Position Actual Value  (0:tool, 1:flange) */
		cli::array<float, 2>^ _fActualPos;
		/* Velocity Actual Value */
		cli::array<float>^ _fActualVel;
		/* External Task Force/Torque */
		cli::array<float>^ _fActualETT;
		/* Target Position */
		cli::array<float>^ _fTargetPos;
		/* Target Velocity */
		cli::array<float>^ _fTargetVel;
		/* Rotation Matrix */
		cli::array<float, 2>^ _fRotationMatrix;
	};

	public value struct RobotMonitoringTorque
	{
		/* Dynamics Torque */
		cli::array<float>^ _fDynamicTor;
		/* Joint Torque Sensor Value */
		cli::array<float>^ _fActualJTS;
		/* External Joint Torque */
		cli::array<float>^ _fActualEJT;
		/* External Task Force/Torque */
		cli::array<float>^ _fActualETT;
	};

	public value struct RobotMonitoringState
	{
		// position control: 0, torque control: 1
		unsigned char _iActualMode;
		// joint space: 0, task space: 1
		unsigned char _iActualSpace;
	};

	public value struct RobotMonitoringData
	{
		RobotMonitoringState _tState;
		/* joint */
		RobotMonitoringJoint _tJoint;
		/* task */
		RobotMonitoringTask _tTask;
		/* torque */
		RobotMonitoringTorque _tTorque;
	};

	typedef RobotMonitoringData
		MonitoringControl;

	public value struct RobotMonitoringDataEx
	{
		RobotMonitoringState _tState;
		/* joint */
		RobotMonitoringJoint _tJoint;
		/* task */
		RobotMonitoringTask _tTask;
		/* torque */
		RobotMonitoringTorque _tTorque;
		/* world */
		RobotMonitoringWorld _tWorld;
		/*user */
		RobotMonitoringUser _tUser;
	};

	typedef RobotMonitoringDataEx
		MonitoringControlEx;

	public	value struct MonitoringMisc
	{
		/* inner clock counter */
		double _dSyncTime;
		/* Flange Digtal Input data */
		cli::array<unsigned char>^ _iActualDI;
		/* Flange Digtal output data */
		cli::array<unsigned char>^ _iActualDO;
		/* brake state */
		cli::array<unsigned char>^ _iActualBK;
		/* robot button state */
		cli::array<unsigned int>^ _iActualBT;
		/* motor input current */
		cli::array<float>^ _fActualMC;
		/* motro current temperature */
		cli::array<float>^ _fActualMT;
	};

	public	value struct MonitoringData
	{
		MonitoringControl _tCtrl;
		/* misc. */
		MonitoringMisc _tMisc;
	};

	public value struct MonitoringDataEx
	{
		MonitoringControlEx _tCtrl;
		/* misc. */
		MonitoringMisc _tMisc;
	};

	public value struct ReadCtrlioInput
	{
		/* Digtal Input data */
		cli::array<unsigned char>^ _iActualDI;
#if 0
		/*  Analog Input type */
		cli::array<unsigned char>^ _iActualAT;
#endif
		/* Analog Input data */
		cli::array<float>^ _fActualAI;
		/* switch input data */
		cli::array<unsigned char>^ _iActualSW;
		/* Safety Input data */
		cli::array<unsigned char>^ _iActualSI;
		/* Encorder Input data */
		cli::array<unsigned char>^ _iActualEI;
		/* Encorder raw data */
		cli::array<unsigned int>^ _iAcutualED;
	};

	public value struct ReadCtrlioOutput
	{
		/* Digital Output data */
		cli::array<unsigned char>^ _iTargetDO;
#if 0
		/*  Analog Output type */
		cli::array<unsigned char>^ _fTargetAT;
#endif    
		/* Analog Output data */
		cli::array<float>^ _fTargetAO;
	};

	public value struct ReadCtrlioInputEx
	{
		/* Digtal Input data */
		cli::array<unsigned char>^ _iActualDI;
		/* Analog Input data */
		cli::array<float>^ _fActualAI;
		/* switch input data */
		cli::array<unsigned char>^ _iActualSW;
		/* Safety Input data */
		cli::array<unsigned char>^ _iActualSI;
		/*  Analog Input type */
		cli::array<unsigned char>^ _iActualAT;
	};

	public value struct ReadEncoderInput
	{
		/* Encorder strove signal */
		cli::array<unsigned char>^ _iActualES;
		/* Encorder raw data */
		cli::array<unsigned int>^ _iActualED;
		/* Encorder Reset signal */
		cli::array<unsigned char>^ _iActualER;
	};

	public value struct ReadCtrlioOutputEx
	{
		/* Digital Output data */
		cli::array<unsigned char>^ _iTargetDO;
		/* Analog Output data */
		cli::array<float>^ _fTargetAO;
		/*  Analog Output type */
		cli::array<unsigned char>^ _iTargetAT;
	};

	public value struct ReadProcessInput
	{
		/* Digtal Input data */
		cli::array<unsigned char>^ _iActualDI;
	};

	public value struct MonitoringCtrlio
	{
		/* input data */
		ReadCtrlioInput _tInput;
		/* output data */
		ReadCtrlioOutput _tOutput;
	};

	public value struct MonitoringCtrlioEx
	{
		/* input data */
		ReadCtrlioInputEx _tInput;
		/* output data */
		ReadCtrlioOutputEx _tOutput;
		/* input encoder data*/
		ReadEncoderInput _tEncoder;
		/* reserved data */
		cli::array<unsigned char>^ _szReserved;
	};

	public value struct ModbusRegister
	{
		/* modbus i/o name */
		cli::array<char>^ _szSymbol;
		/* modbus i/o  value */
		unsigned short _iValue;
	};

	public value struct MonitoringModbus
	{
		/* modbus i/o count */
		unsigned short _iRegCount;
		/* modbus i/o values */
		cli::array<ModbusRegister>^ _tRegister;
	};

	public value struct LogAlarm
	{
		/* message level */
		unsigned char _iLevel;
		/* group no */
		unsigned char _iGroup;
		/* message no */
		unsigned int _iIndex;
		/* message param */
		cli::array<String^>^ _szParam;
	};

	typedef LogAlarm
		MonitoringAlarm;

	public value struct MessageProgress
	{
		/* current step */
		unsigned char _iCurrentCount;
		/*  total step  */
		unsigned char _iTotalCount;
	};

	public value struct MessagePopup
	{
		/* message string */
		cli::array<char>^ _szText;
		/*  Message: 0, Warning: 1, Alarm: 2 */
		unsigned char _iLevel;
		/*  resuem and stop : 0, ok : 1 */
		unsigned char _iBtnType;

	};

	typedef MessagePopup
		MonitoringPopup;

	public value struct MessageInput
	{
		/* message string */
		cli::array<char>^ _szText;
		/*  int: 0, float: 1, string: 2 , bool: 3*/
		unsigned char _iType;
	};

	typedef MessageInput
		MonitoringInput;

	public value struct ConbtrolBrake
	{
		/* joint: 0~5 , all joint: 6 */
		unsigned char _iTargetAxs;
		/*  on: 1 off: 0 */
		unsigned char _bValue;
	};

	public value struct MovePosb
	{
		/*  q               */
		cli::array<float, 2>^ _fTargetPos;
		/* blending motion type (line: 0, circle: 1) */
		unsigned char _iBlendType;
		/* blending radius  */
		float _fBlendRad;
	};

	public value struct RobotPose
	{
		/* current pose */
		cli::array<float>^ _fPosition;
	};

	public value struct RobotVel
	{
		/* current velocity */
		cli::array<float>^ _fVelocity;
	};

	public value struct RobotVelll
	{
		/* current velocity */
		cli::array<float>^ _fVelocity;
	};

	public value struct RobotForce
	{
		/* current force */
		cli::array<float>^ _fForce;
	};

	public value struct RobotTaskPose
	{
		/* target pose */
		cli::array<float>^ _fTargetPos;
		/*  solution space: 0 ~ 7 */
		unsigned char _iTargetSol;

	};

	public value struct UserCoordinate
	{
		unsigned char _iReqId;
		unsigned char _iTargetRef;
		cli::array<float>^ _fTargetPos;
	};

	public value struct MeasureToolResponse
	{
		/* mass(kg) */
		float _fWeight;
		/* center of mass */
		cli::array<float>^ _fXYZ;
	};

	public value struct ConfigTcp
	{
		/* target pose */
		cli::array<float>^ _fTargetPos;
	};

	public value struct ConfigTool
	{
		/* mass(kg) */
		float _fWeight;
		/* center of mass */
		cli::array<float>^ _fXYZ;
		/* inertia */
		cli::array<float>^ _fInertia;
	};

	public value struct MeasureTcpResponse
	{
		/* mesure pose  */
		ConfigTcp _tTCP;
		/* mesure error */
		float _fError;
	};

	//value struct FlangSerialData
	//{
	//	unsigned char _iCommand;		// 0 : OPEN, 1: CLOSE
	//									// 2 : SEND, 3: RECV
	//	union {
	//		struct {
	//			/* Baudrate */
	//			cli::array<unsigned char>^ _szBaudrate;		// "0115200"(ASCII)
	//			/* Data Length */
	//			unsigned char _szDataLength;				// 0: 1bit, 7: 8bit
	//			/* Parity */
	//			unsigned char _szParity;					// 0x00 : Non-parity, 0x01 : Odd, 0x02 : Even
	//			/* Stop Bit */
	//			unsigned char _szStopBit;					// 0x01 : One stop bit, 0x02 : Two Stop bit
	//		} _tConfig;

	//		//unsigned char                   _szConfigData[10];

	//		struct {
	//			unsigned short _iLength;

	//			cli::array<unsigned char >^ _szValue;
	//		} _tValue;
	//	} _tData;
	//};

	public value struct FlangSerRxdInfo
	{
		/* size of serial data */
		short _iSize;      //max 256bytes
		/* raw serial data */
		cli::array<unsigned char>^ _cRxd;

	};

	public value struct ReadFlangSerial
	{
		// check ready to read
		unsigned char _bRecvFlag;    // 0: non-receive, 1: received
	};

	public value struct InverseKinematicResponse
	{
		/* target pose */
		cli::array<float>^ _fTargetPos;
		/* status */
		int _iStatus;
	};

#pragma pack()
}
