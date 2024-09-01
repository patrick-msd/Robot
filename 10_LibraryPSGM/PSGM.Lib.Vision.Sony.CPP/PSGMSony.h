#pragma once

//#if defined(_WIN32)
//#if defined(DRFL_EXPORTS)
//#define DRFL_API __declspec(dllexport)
//#else
//#define DRFL_API __declspec(dllimport)
//#endif
//#endif

//#if !defined(DRFL_API)
//#define DRFL_API
//#endif

#include <vcclr.h>
#include <stdio.h>
#include <string.h>

#include "CameraRemote_SDK.h"

#include "CrCommandData.h"
#include "CrDefines.h"
#include "CrDeviceProperty.h"
#include "CrError.h"
#include "CrImageDataBlock.h"
#include "CrTypes.h"

#include "ICrCameraObjectInfo.h"

#include "Text.h"

#include <thread>

using namespace std;
using namespace System;
using namespace System::IO;
using namespace System::Runtime::InteropServices;

namespace SonyCamerSDK
{
	/// <summary>
	/// Doosan Robots API Wrapper for CSharp
	/// </summary>
	public ref class Sony
	{
	private:
		////////////////////////////////////////////////////////////////////////////
		// Variable                                                               //
		////////////////////////////////////////////////////////////////////////////
		//DRAFramework::LPROBOTCONTROL _rbtCtrl;

		//bool _hasControlAuthority = false;
		//bool _tpInitailizingComplted = false;
		//bool _mState = false;
		//bool _stop = false;
		//bool _alterFlag = false;

		SCRSDK::ICrEnumCameraObjectInfo* _cameraList;

		CrChar* _connectionTypeName;
		CrChar* _modelName;

		float* _axisDirection;

	public:
		Sony();
		~Sony(); // Dispose()
		!Sony(); // Finalize()




		CrInt32u GetSDKVersion();
		bool Init();
		bool Release();
		//int	EnumCameraObjects();
		SCRSDK::CrError	EnumCameraObjects();
		int GetCameraCount();
		void GetCameraObjectInfo(int index);
		String^ Sony::GetConnectionTypeName();
		String^ Sony::GetModelName();
	};
}
