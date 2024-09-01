#include "pch.h"
#include <msclr\marshal_cppstd.h>

#include "CameraRemote_SDK.h"

#include "PSGMSony.h"
#include "Text.h"

using namespace std;
using namespace System;
using namespace System::IO;

namespace SonyCamerSDK
{
	//////////////////////////////////////////////////////////////////////////////
	//// Instance                                                               //
	//////////////////////////////////////////////////////////////////////////////
	//CrInt32u version = SCRSDK::GetSDKVersion();
	//int major = (version & 0xFF000000) >> 24;
	//int minor = (version & 0x00FF0000) >> 16;
	//int patch = (version & 0x0000FF00) >> 8;
	//// int reserved = (version & 0x000000FF);ance;


	//auto init_success = SCRSDK::Init();
	////if (!init_success) {
	////	cli::tout << "Failed to initialize Remote SDK. Terminating.\n";
	////	SDK::Release();
	////	std::exit(EXIT_FAILURE);
	////}
	////cli::tout << "Remote SDK successfully initialized.\n\n";


	Sony::Sony()
	{
		_cameraList = nullptr;

		_connectionTypeName = nullptr;
		_modelName = nullptr;
	}

	Sony::~Sony()
	{
		// Initialize the SDK
		//auto init_success = SCRSDK::Init();
		//if (!init_success) {
		//	cli::tout << "Failed to initialize Remote SDK. Terminating.\n";
		//	SDK::Release();
		//	std::exit(EXIT_FAILURE);
		//}
		//cli::tout << "Remote SDK successfully initialized.\n\n";
	}

	Sony::!Sony()
	{

	}




	CrInt32u Sony::GetSDKVersion()
	{
		return SCRSDK::GetSDKVersion();
	}

	bool Sony::Init()
	{
		return SCRSDK::Init();
	}

	bool Sony::Release()
	{
		return SCRSDK::Release();
	}

	SCRSDK::CrError Sony::EnumCameraObjects()
	{
		SCRSDK::ICrEnumCameraObjectInfo* cameraList = nullptr;
		SCRSDK::CrError error = SCRSDK::EnumCameraObjects(&cameraList);

		_cameraList = cameraList;

		return error;
	}

	//	auto ncams = camera_list->GetCount();


	//	for (CrInt32u i = 0; i < ncams; ++i) {
	//		auto camera_info = camera_list->GetCameraObjectInfo(i);
	//		text conn_type(camera_info->GetConnectionTypeName());
	//		text model(camera_info->GetModel());
	//		text id = TEXT("");
	//		//if (TEXT("IP") == conn_type) {
	//		   // SonyCamerSDK::NetworkInfo ni = parse_ip_info(camera_info->GetId(), camera_info->GetIdSize());
	//		   // id = ni.mac_address;
	//		//}
	//		//else id = ((TCHAR*)camera_info->GetId());
	//		SonyCamerSDK::tout << '[' << i + 1 << "] " << model.data() << " (" << id.data() << ")\n";
	//		OutputDebugString(model.data() << " (" << id.data() << ")\n"));
	//	}

	//	return ncams;
	//}

	int Sony::GetCameraCount()
	{
		return _cameraList->GetCount();
	}

	void Sony::GetCameraObjectInfo(int index)
	{
		auto camera_info = _cameraList->GetCameraObjectInfo(index);

		_connectionTypeName = camera_info->GetConnectionTypeName();
		_modelName = camera_info->GetModel();
	}


	String^ Sony::GetConnectionTypeName()
	{
		return gcnew String(_connectionTypeName);
	}

	String^ Sony::GetModelName()
	{
		return gcnew String(_modelName);
	}
}
