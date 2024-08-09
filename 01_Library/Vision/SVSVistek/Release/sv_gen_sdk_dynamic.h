#ifndef _SV_GEN_SDK_DYNAMIC_H
#define _SV_GEN_SDK_DYNAMIC_H

#pragma warning(disable : 4996)
#include <windows.h>
#include <shlwapi.h>
#include <stdio.h>

typedef SV_RETURN(*Tfn_SVLibInit)(  const char *TLIPath,
                                    const char *genicamRootDir,
                                    const char *genicamCacheDir,
                                    const char *clProtocolDriverDir);
typedef SV_RETURN(*Tfn_SVLibSystemGetCount)(uint32_t *tlCount);
typedef SV_RETURN(*Tfn_SVLibSystemGetInfo)(uint32_t uiIndex, SV_TL_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVLibSystemOpen)(uint32_t uiIndex, SV_SYSTEM_HANDLE *phSystemOut);
typedef SV_RETURN(*Tfn_SVLibClose)(void);

typedef SV_RETURN(*Tfn_SVSystemGetInfo)(SV_SYSTEM_HANDLE hSystem, SV_TL_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVSystemUpdateInterfaceList)(SV_SYSTEM_HANDLE hSystem, bool8_t *pbChanged, uint32_t timeOut);
typedef SV_RETURN(*Tfn_SVSystemGetNumInterfaces)(SV_SYSTEM_HANDLE hSystem, uint32_t *piNumIfaces);
typedef SV_RETURN(*Tfn_SVSystemGetInterfaceId)(SV_SYSTEM_HANDLE hSystem, uint32_t Index, char* pInterfaceId, size_t *pSize);
typedef SV_RETURN(*Tfn_SVSystemInterfaceGetInfo)(SV_SYSTEM_HANDLE hSystem, const char *pInterfaceId, SV_INTERFACE_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVSystemInterfaceOpen)(SV_SYSTEM_HANDLE hSystem, const char *pInterfaceId, SV_INTERFACE_HANDLE *phInterfaceOut);
typedef SV_RETURN(*Tfn_SVSystemClose)(SV_SYSTEM_HANDLE hSystem);

typedef SV_RETURN(*Tfn_SVInterfaceGetInfo)(SV_INTERFACE_HANDLE hInterface, SV_INTERFACE_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVInterfaceUpdateDeviceList)(SV_INTERFACE_HANDLE hInterface, bool8_t *pbChanged, uint32_t timeOut);
typedef SV_RETURN(*Tfn_SVInterfaceGetNumDevices)(SV_INTERFACE_HANDLE hInterface, uint32_t *piDevices);
typedef SV_RETURN(*Tfn_SVInterfaceGetDeviceId)(SV_INTERFACE_HANDLE hInterface, uint32_t Index, char* pDeviceId, size_t *pSize);
typedef SV_RETURN(*Tfn_SVInterfaceDeviceGetInfo)(SV_INTERFACE_HANDLE hInterface, const char *pDeviceId, SV_DEVICE_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVInterfaceDeviceOpen)(  SV_INTERFACE_HANDLE hInterface,
                                                const char *pDeviceId,
                                                SV_DEVICE_ACCESS_FLAGS accessFlags,
                                                SV_DEVICE_HANDLE *phDeviceOut,
                                                SV_REMOTE_DEVICE_HANDLE *phRemoteDeviceOut);
typedef SV_RETURN(*Tfn_SVInterfaceClose)(SV_INTERFACE_HANDLE hInterface);

typedef SV_RETURN(*Tfn_SVDeviceGetInfo)(SV_DEVICE_HANDLE hDevice, SV_DEVICE_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVDeviceGetNumStreams)(SV_DEVICE_HANDLE hDevice, uint32_t *piStreams);
typedef SV_RETURN(*Tfn_SVDeviceGetStreamId)(SV_DEVICE_HANDLE hDevice, uint32_t Index, char* pStreamId, size_t *pSize);
typedef SV_RETURN(*Tfn_SVDeviceSaveSettings)(SV_DEVICE_HANDLE hDevice, const char *fileName);
typedef SV_RETURN(*Tfn_SVDeviceLoadSettings)(SV_DEVICE_HANDLE hDevice, const char *fileName);
typedef SV_RETURN(*Tfn_SVDeviceRead)(SV_DEVICE_HANDLE hDevice, uint64_t nAddress, void *pData, size_t *pSize);
typedef SV_RETURN(*Tfn_SVDeviceWrite)(SV_DEVICE_HANDLE hDevice, uint64_t nAddress, const void *pData, size_t *pSize);
typedef SV_RETURN(*Tfn_SVDeviceStreamOpen)(SV_DEVICE_HANDLE hDevice, const char *sDataStreamID, SV_STREAM_HANDLE *phStream);
typedef SV_RETURN(*Tfn_SVDeviceClose)(SV_DEVICE_HANDLE hDevice);

typedef SV_RETURN(*Tfn_SVStreamAcquisitionStart)(SV_STREAM_HANDLE hStream, SV_ACQ_START_FLAGS flags, uint64_t iNumToAcquire);
typedef SV_RETURN(*Tfn_SVStreamAcquisitionStop)(SV_STREAM_HANDLE hStream, SV_ACQ_STOP_FLAGS flags);
typedef SV_RETURN(*Tfn_SVStreamAnnounceBuffer)(SV_STREAM_HANDLE hStream, void *pBuffer, uint32_t uiSize, void *pPrivate, SV_BUFFER_HANDLE *phBuffer);
typedef SV_RETURN(*Tfn_SVStreamAllocAndAnnounceBuffer)(SV_STREAM_HANDLE hStream, uint32_t uiSize, void *pPrivate, SV_BUFFER_HANDLE *phBuffer);
typedef SV_RETURN(*Tfn_SVStreamRevokeBuffer)(SV_STREAM_HANDLE hStream, SV_BUFFER_HANDLE hBuffer, void **pBuffer, void **pPrivate);
typedef SV_RETURN(*Tfn_SVStreamQueueBuffer)(SV_STREAM_HANDLE hStream, SV_BUFFER_HANDLE hBuffer);
typedef SV_RETURN(*Tfn_SVStreamGetBufferId)(SV_STREAM_HANDLE hStream, uint32_t iIndex, SV_BUFFER_HANDLE *phBuffer);
typedef SV_RETURN(*Tfn_SVStreamFlushQueue)(SV_STREAM_HANDLE hStream, SV_ACQ_QUEUE_TYPE iOperation);
typedef SV_RETURN(*Tfn_SVStreamWaitForNewBuffer)(SV_STREAM_HANDLE hStream, void **ppUserData, SV_BUFFER_HANDLE *phBufferOut, uint32_t timeOut);
typedef SV_RETURN(*Tfn_SVStreamBufferGetInfo)(SV_STREAM_HANDLE hStream, SV_BUFFER_HANDLE hBuffer, SV_BUFFER_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVStreamClose)(SV_STREAM_HANDLE hStream);

typedef SV_RETURN(*Tfn_SVFeatureGetByName)(void *hModule, const char *featureName, SV_FEATURE_HANDLE *phFeature);
typedef SV_RETURN(*Tfn_SVFeatureGetByIndex)(void *hModule, uint32_t iIndex, SV_FEATURE_HANDLE *phFeature);
typedef SV_RETURN(*Tfn_SVFeatureGetInfo)(void *hModule, SV_FEATURE_HANDLE hFeature, SV_FEATURE_INFO *pInfoOut);
typedef SV_RETURN(*Tfn_SVFeatureGetValueBool)(void *hModule, SV_FEATURE_HANDLE hFeature, bool8_t *pBoolValue, bool verify, bool ignoreCache);
typedef SV_RETURN(*Tfn_SVFeatureGetValueInt64)(void *hModule, SV_FEATURE_HANDLE hFeature, int64_t *pInt64Value, bool verify, bool ignoreCache);
typedef SV_RETURN(*Tfn_SVFeatureGetValueFloat)(void *hModule, SV_FEATURE_HANDLE hFeature, double *pFloatValue, bool verify, bool ignoreCache);
typedef SV_RETURN(*Tfn_SVFeatureGetValueString)(void *hModule, SV_FEATURE_HANDLE hFeature, char *strValue, uint32_t bufferSize, bool verify, bool ignoreCache);
typedef SV_RETURN(*Tfn_SVFeatureGetValueInt64Enum)(void *hModule, SV_FEATURE_HANDLE hFeature, int64_t *pInt64Value, bool verify, bool ignoreCache);

typedef SV_RETURN(*Tfn_SVFeatureSetValueBool)(void *hModule, SV_FEATURE_HANDLE hFeature, const bool8_t boolValue, bool verify);
typedef SV_RETURN(*Tfn_SVFeatureSetValueInt64)(void *hModule, SV_FEATURE_HANDLE hFeature, const int64_t int64Value, bool verify);
typedef SV_RETURN(*Tfn_SVFeatureSetValueFloat)(void *hModule, SV_FEATURE_HANDLE hFeature, const double floatValue, bool verify);
typedef SV_RETURN(*Tfn_SVFeatureSetValueString)(void *hModule, SV_FEATURE_HANDLE hFeature, const char *strValue, bool verify);
typedef SV_RETURN(*Tfn_SVFeatureSetValueInt64Enum)(void *hModule, SV_FEATURE_HANDLE hFeature, const int64_t int64Value, bool verify);
typedef SV_RETURN(*Tfn_SVFeatureCommandExecute)(void *hModule, SV_FEATURE_HANDLE hFeature, uint32_t Timeout, bool bWait);
typedef SV_RETURN(*Tfn_SVFeatureEnumSubFeatures)(void *hModule, SV_FEATURE_HANDLE hFeature, int32_t iIndex, char *subFeatureName, unsigned int bufferSize, int64_t *pValue);
typedef SV_RETURN(*Tfn_SVFeatureRegisterInvalidateCB)(void *hModule, SV_FEATURE_HANDLE hFeature, SV_CB_OBJECT objCb, SV_CB_FEATURE_INVALIDATED_PFN pfnFeatureInvalidateCb);
typedef SV_RETURN(*Tfn_SVFeatureUnRegisterInvalidateCB)(void *hModule, SV_FEATURE_HANDLE hFeature);

typedef SV_RETURN(*Tfn_SVUtilBuffer12BitTo8Bit)(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int pDestLength);
typedef SV_RETURN(*Tfn_SVUtilBuffer12BitTo16Bit)(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int pDestLength);
typedef SV_RETURN(*Tfn_SVUtilBuffer16BitTo8Bit)(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int pDestLength);
typedef SV_RETURN(*Tfn_SVUtilBufferBayerToRGB)(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int pDestLength);

typedef SV_RETURN(*Tfn_SVLogRegister)(const char *moduleName, const unsigned int debugLevel);
typedef SV_RETURN(*Tfn_SVLogEnableWindbg)(bool bEnable);
typedef SV_RETURN(*Tfn_SVLogEnableFileLogging)(bool bEnable, const char *logFileName);
typedef SV_RETURN(*Tfn_SVLogSetGlobalDebugLevel)(const unsigned int debugLevel);
typedef SV_RETURN(*Tfn_SVLogTraceA)(const char *moduleName, const unsigned int debugLevel, const char *format, ...);

//new functions 2.5.0
typedef SV_RETURN(*Tfn_SVUtilBufferBayerToRGB32)(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int pDestLength);
typedef SV_RETURN(*Tfn_SVLibIsVersionCompliant)(const SV_LIB_VERSION expectedVersion, SV_LIB_VERSION *pCurrentVersion);
typedef SV_RETURN(*Tfn_SVFeatureGetValueEnum)(void *hModule, SV_FEATURE_HANDLE hFeature, char *buffer, unsigned int bufferSize, bool verify, bool ignoreCache);
typedef SV_RETURN(*Tfn_SVFeatureSetValueEnum)(void *hModule, SV_FEATURE_HANDLE hFeature, const char *buffer, bool verify);
typedef SV_RETURN(*Tfn_SVDeviceSaveSettingsToString)(SV_DEVICE_HANDLE hDevice, char *buffer, uint32_t *pBufferSize);
typedef SV_RETURN(*Tfn_SVDeviceLoadSettingsFromString)(SV_DEVICE_HANDLE hDevice, const char *buffer);
typedef SV_RETURN(*Tfn_SVFeatureListRefresh)(void *hModule);
typedef SV_RETURN(*Tfn_SVUtilSaveImageToPNGFile)(const SV_BUFFER_INFO &info, const char* fileName);
typedef SV_RETURN(*Tfn_SVFeatureGetDescription)(void *hModule, SV_FEATURE_HANDLE hFeature, char *pBuffer, uint32_t bufferSize);
typedef SV_RETURN(*Tfn_SVFeatureRegisterInvalidateCB2)(void *hModule, SV_FEATURE_HANDLE hFeature, void *pContext, SV_CB_FEATURE_INVALIDATED_PFN2 pfnFeatureInvalidateCb);
//end new functions 2.5.0

//new functions 2.5.1
typedef SV_RETURN(*Tfn_SVEventRegister)(void *hModule, SV_EVENT_TYPE iEventID, SV_EVENT_HANDLE *phEvent);
typedef SV_RETURN(*Tfn_SVEventUnRegister)(void *hModule, SV_EVENT_TYPE iEventID);
typedef SV_RETURN(*Tfn_SVEventWait)(void *hModule, SV_EVENT_HANDLE hEvent, void *pBuffer, size_t *pSize, uint64_t iTimeout); //No data for now
typedef SV_RETURN(*Tfn_SVEventGetInfo)(void *hModule, SV_EVENT_HANDLE hEvent, SV_EVENT_INFO *pEventInfo);
typedef SV_RETURN(*Tfn_SVEventFlush)(void *hModule, SV_EVENT_HANDLE hEvent);
typedef SV_RETURN(*Tfn_SVEventKill)(void *hModule, SV_EVENT_HANDLE hEvent);
//end new functions 2.5.1

//new functions 2.5.2
typedef SV_RETURN(*Tfn_SVUtilSaveImageToFile)(const SV_BUFFER_INFO &info, const char* fileName, SV_IMAGE_FILE_TYPE fileType);
//end new functions 2.5.2

//new functions 2.5.4
typedef SV_RETURN(*Tfn_SVStreamGetInfo)(SV_STREAM_HANDLE hStream, SV_DS_INFO *pInfoOut);
//end new functions 2.5.4

//new functions 2.5.8
typedef SV_RETURN(*Tfn_SVFeatureSetValueRegister)(void* hModule, SV_FEATURE_HANDLE hFeature, const uint8_t* value, int64_t length, bool verify);
typedef SV_RETURN(*Tfn_SVFeatureGetValueRegister)(void* hModule, SV_FEATURE_HANDLE hFeature, char* strOut, uint32_t bufferSize, bool verify, bool ignoreCache);

//new function 2.5.12

typedef SV_RETURN(*Tfn_SVRegisterDeviceWrite)(SV_DEVICE_HANDLE hDevice, SV_FEATURE_HANDLE hFeature, const uint8_t *value, size_t *length, bool verify, size_t offset);


HMODULE g_hModule = 0;

Tfn_SVLibInit                       g_pFnSVLibInit = 0;
Tfn_SVLibSystemGetCount             g_pFnSVLibSystemGetCount = 0;
Tfn_SVLibSystemGetInfo              g_pFnSVLibSystemGetInfo = 0;
Tfn_SVLibSystemOpen                 g_pFnSVLibSystemOpen = 0;
Tfn_SVLibClose                      g_pFnSVLibClose = 0;
Tfn_SVSystemGetInfo                 g_pFnSVSystemGetInfo = 0;
Tfn_SVSystemUpdateInterfaceList     g_pFnSVSystemUpdateInterfaceList = 0;
Tfn_SVSystemGetNumInterfaces        g_pFnSVSystemGetNumInterfaces = 0;
Tfn_SVSystemGetInterfaceId          g_pFnSVSystemGetInterfaceId = 0;
Tfn_SVSystemInterfaceGetInfo        g_pFnSVSystemInterfaceGetInfo = 0;
Tfn_SVSystemInterfaceOpen           g_pFnSVSystemInterfaceOpen = 0;
Tfn_SVSystemClose                   g_pFnSVSystemClose = 0;
Tfn_SVInterfaceGetInfo              g_pFnSVInterfaceGetInfo = 0;
Tfn_SVInterfaceUpdateDeviceList     g_pFnSVInterfaceUpdateDeviceList = 0;
Tfn_SVInterfaceGetNumDevices        g_pFnSVInterfaceGetNumDevices = 0;
Tfn_SVInterfaceGetDeviceId          g_pFnSVInterfaceGetDeviceId = 0;
Tfn_SVInterfaceDeviceGetInfo        g_pFnSVInterfaceDeviceGetInfo = 0;
Tfn_SVInterfaceDeviceOpen           g_pFnSVInterfaceDeviceOpen = 0;
Tfn_SVInterfaceClose                g_pFnSVInterfaceClose = 0;

Tfn_SVDeviceGetInfo                 g_pFnSVDeviceGetInfo = 0;
Tfn_SVDeviceGetNumStreams           g_pFnSVDeviceGetNumStreams = 0;
Tfn_SVDeviceGetStreamId             g_pFnSVDeviceGetStreamId = 0;
Tfn_SVDeviceSaveSettings            g_pFnSVDeviceSaveSettings = 0;
Tfn_SVDeviceLoadSettings            g_pFnSVDeviceLoadSettings = 0;
Tfn_SVDeviceRead                    g_pFnSVDeviceRead = 0;
Tfn_SVDeviceWrite                   g_pFnSVDeviceWrite = 0;
Tfn_SVDeviceStreamOpen              g_pFnSVDeviceStreamOpen = 0;
Tfn_SVDeviceClose                   g_pFnSVDeviceClose = 0;

Tfn_SVStreamAcquisitionStart        g_pFnSVStreamAcquisitionStart = 0;
Tfn_SVStreamAcquisitionStop         g_pFnSVStreamAcquisitionStop = 0;
Tfn_SVStreamAnnounceBuffer          g_pFnSVStreamAnnounceBuffer = 0;
Tfn_SVStreamAllocAndAnnounceBuffer  g_pFnSVStreamAllocAndAnnounceBuffer = 0;
Tfn_SVStreamRevokeBuffer            g_pFnSVStreamRevokeBuffer = 0;
Tfn_SVStreamQueueBuffer             g_pFnSVStreamQueueBuffer = 0;
Tfn_SVStreamGetBufferId             g_pFnSVStreamGetBufferId = 0;
Tfn_SVStreamFlushQueue              g_pFnSVStreamFlushQueue = 0;
Tfn_SVStreamWaitForNewBuffer        g_pFnSVStreamWaitForNewBuffer = 0;
Tfn_SVStreamBufferGetInfo           g_pFnSVStreamBufferGetInfo = 0;
Tfn_SVStreamClose                   g_pFnSVStreamClose = 0;

Tfn_SVFeatureGetByName              g_pFnSVFeatureGetByName = 0;
Tfn_SVFeatureGetByIndex             g_pFnSVFeatureGetByIndex = 0;
Tfn_SVFeatureGetInfo                g_pFnSVFeatureGetInfo = 0;
Tfn_SVFeatureGetValueBool           g_pFnSVFeatureGetValueBool = 0;
Tfn_SVFeatureGetValueInt64          g_pFnSVFeatureGetValueInt64 = 0;
Tfn_SVFeatureGetValueFloat          g_pFnSVFeatureGetValueFloat = 0;
Tfn_SVFeatureGetValueString         g_pFnSVFeatureGetValueString = 0;
Tfn_SVFeatureGetValueRegister       g_pFnSVFeatureGetValueRegister = 0;
Tfn_SVFeatureGetValueInt64Enum      g_pFnSVFeatureGetValueInt64Enum = 0;

Tfn_SVFeatureSetValueBool           g_pFnSVFeatureSetValueBool = 0;
Tfn_SVFeatureSetValueInt64          g_pFnSVFeatureSetValueInt64 = 0;
Tfn_SVFeatureSetValueFloat          g_pFnSVFeatureSetValueFloat = 0;
Tfn_SVFeatureSetValueString         g_pFnSVFeatureSetValueString = 0;
Tfn_SVFeatureSetValueRegister       g_pFnSVFeatureSetValueRegister = 0;
Tfn_SVFeatureSetValueInt64Enum      g_pFnSVFeatureSetValueInt64Enum = 0;
Tfn_SVFeatureCommandExecute         g_pFnSVFeatureCommandExecute = 0;
Tfn_SVFeatureEnumSubFeatures        g_pFnSVFeatureEnumSubFeatures = 0;
Tfn_SVFeatureRegisterInvalidateCB   g_pFnSVFeatureRegisterInvalidateCB = 0;
Tfn_SVFeatureUnRegisterInvalidateCB g_pFnSVFeatureUnRegisterInvalidateCB = 0;

Tfn_SVUtilBuffer12BitTo8Bit         g_pFnSVUtilBuffer12BitTo8Bit = 0;
Tfn_SVUtilBuffer12BitTo16Bit        g_pFnSVUtilBuffer12BitTo16Bit = 0;
Tfn_SVUtilBuffer16BitTo8Bit         g_pFnSVUtilBuffer16BitTo8Bit = 0;
Tfn_SVUtilBufferBayerToRGB          g_pFnSVUtilBufferBayerToRGB = 0;

Tfn_SVLogRegister                   g_pFnSVLogRegister = 0;
Tfn_SVLogEnableWindbg               g_pFnSVLogEnableWindbg = 0;
Tfn_SVLogEnableFileLogging          g_pFnSVLogEnableFileLogging = 0;
Tfn_SVLogSetGlobalDebugLevel        g_pFnSVLogSetGlobalDebugLevel = 0;
Tfn_SVLogTraceA                     g_pFnSVLogTraceA = 0;

Tfn_SVUtilBufferBayerToRGB32        g_pFnSVUtilBufferBayerToRGB32 = 0;
Tfn_SVLibIsVersionCompliant         g_pFnSVLibIsVersionCompliant = 0;
Tfn_SVFeatureGetValueEnum           g_pFnSVFeatureGetValueEnum = 0;
Tfn_SVFeatureSetValueEnum           g_pFnSVFeatureSetValueEnum = 0;
Tfn_SVDeviceSaveSettingsToString    g_pFnSVDeviceSaveSettingsToString = 0;
Tfn_SVDeviceLoadSettingsFromString  g_pFnSVDeviceLoadSettingsFromString = 0;
Tfn_SVFeatureListRefresh            g_pFnSVFeatureListRefresh = 0;
Tfn_SVUtilSaveImageToPNGFile        g_pFnSVUtilSaveImageToPNGFile = 0;
Tfn_SVFeatureGetDescription         g_pFnSVFeatureGetDescription = 0;
Tfn_SVFeatureRegisterInvalidateCB2  g_pFnSVFeatureRegisterInvalidateCB2 = 0;

Tfn_SVEventRegister  				g_pFnSVEventRegister = 0;
Tfn_SVEventUnRegister            	g_pFnSVEventUnRegister = 0;
Tfn_SVEventWait        				g_pFnSVEventWait = 0;
Tfn_SVEventGetInfo                  g_pFnSVEventGetInfo = 0;
Tfn_SVEventFlush         			g_pFnSVEventFlush = 0;
Tfn_SVEventKill  					g_pFnSVEventKill = 0;

Tfn_SVUtilSaveImageToFile           g_pFnSVUtilSaveImageToFile = 0;

Tfn_SVStreamGetInfo                 g_pFnSVStreamGetInfo = 0;

Tfn_SVRegisterDeviceWrite           g_pFnSVRegisterDeviceWrite=0;

SV_RETURN OpenSDK()
{
    char sdkDLL[MAX_PATH] = { 0 };
#ifdef SVS_SDK_DLL
	sprintf_s(sdkDLL, "%s", SDK_PATH);
#else
	#ifdef _WIN64
		char* pPath = getenv("SVS_SDK_BIN_64");
		if (pPath == NULL)
			return SV_ERROR_UNKNOWN;

		sprintf_s(sdkDLL, "%s\\SVGenSDK64.dll", pPath);
	#else
		char* pPath = getenv("SVS_SDK_BIN_32");

		if (pPath == NULL)
			return SV_ERROR_UNKNOWN;

		sprintf_s(sdkDLL, "%s\\SVGenSDK.dll", pPath);
	#endif
#endif

    g_hModule = LoadLibraryA(sdkDLL);
    if (g_hModule == NULL)
        return SV_ERROR_UNKNOWN;

    //load dll
    g_pFnSVLibInit = (Tfn_SVLibInit)GetProcAddress(g_hModule, "SVLibInit");
    g_pFnSVLibSystemGetCount = (Tfn_SVLibSystemGetCount)GetProcAddress(g_hModule, "SVLibSystemGetCount");
    g_pFnSVLibSystemGetInfo = (Tfn_SVLibSystemGetInfo)GetProcAddress(g_hModule, "SVLibSystemGetInfo");
    g_pFnSVLibSystemOpen = (Tfn_SVLibSystemOpen)GetProcAddress(g_hModule, "SVLibSystemOpen");
    g_pFnSVLibClose = (Tfn_SVLibClose)GetProcAddress(g_hModule, "SVLibClose");
    g_pFnSVSystemGetInfo = (Tfn_SVSystemGetInfo)GetProcAddress(g_hModule, "SVSystemGetInfo");
    g_pFnSVSystemUpdateInterfaceList = (Tfn_SVSystemUpdateInterfaceList)GetProcAddress(g_hModule, "SVSystemUpdateInterfaceList");
    g_pFnSVSystemGetNumInterfaces = (Tfn_SVSystemGetNumInterfaces)GetProcAddress(g_hModule, "SVSystemGetNumInterfaces");
    g_pFnSVSystemGetInterfaceId = (Tfn_SVSystemGetInterfaceId)GetProcAddress(g_hModule, "SVSystemGetInterfaceId");
    g_pFnSVSystemInterfaceGetInfo = (Tfn_SVSystemInterfaceGetInfo)GetProcAddress(g_hModule, "SVSystemInterfaceGetInfo");
    g_pFnSVSystemInterfaceOpen = (Tfn_SVSystemInterfaceOpen)GetProcAddress(g_hModule, "SVSystemInterfaceOpen");
    g_pFnSVSystemClose = (Tfn_SVSystemClose)GetProcAddress(g_hModule, "SVSystemClose");

    g_pFnSVInterfaceGetInfo = (Tfn_SVInterfaceGetInfo)GetProcAddress(g_hModule, "SVInterfaceGetInfo");
    g_pFnSVInterfaceUpdateDeviceList = (Tfn_SVInterfaceUpdateDeviceList)GetProcAddress(g_hModule, "SVInterfaceUpdateDeviceList");
    g_pFnSVInterfaceGetNumDevices = (Tfn_SVInterfaceGetNumDevices)GetProcAddress(g_hModule, "SVInterfaceGetNumDevices");
    g_pFnSVInterfaceGetDeviceId = (Tfn_SVInterfaceGetDeviceId)GetProcAddress(g_hModule, "SVInterfaceGetDeviceId");
    g_pFnSVInterfaceDeviceGetInfo = (Tfn_SVInterfaceDeviceGetInfo)GetProcAddress(g_hModule, "SVInterfaceDeviceGetInfo");
    g_pFnSVInterfaceDeviceOpen = (Tfn_SVInterfaceDeviceOpen)GetProcAddress(g_hModule, "SVInterfaceDeviceOpen");
    g_pFnSVInterfaceClose = (Tfn_SVInterfaceClose)GetProcAddress(g_hModule, "SVInterfaceClose");

    g_pFnSVDeviceGetInfo = (Tfn_SVDeviceGetInfo)GetProcAddress(g_hModule, "SVDeviceGetInfo");
    g_pFnSVDeviceGetNumStreams = (Tfn_SVDeviceGetNumStreams)GetProcAddress(g_hModule, "SVDeviceGetNumStreams");
    g_pFnSVDeviceGetStreamId = (Tfn_SVDeviceGetStreamId)GetProcAddress(g_hModule, "SVDeviceGetStreamId");
    g_pFnSVDeviceSaveSettings = (Tfn_SVDeviceSaveSettings)GetProcAddress(g_hModule, "SVDeviceSaveSettings");
    g_pFnSVDeviceLoadSettings = (Tfn_SVDeviceLoadSettings)GetProcAddress(g_hModule, "SVDeviceLoadSettings");
    g_pFnSVDeviceRead = (Tfn_SVDeviceRead)GetProcAddress(g_hModule, "SVDeviceRead");
    g_pFnSVDeviceWrite = (Tfn_SVDeviceWrite)GetProcAddress(g_hModule, "SVDeviceWrite");
    g_pFnSVDeviceStreamOpen = (Tfn_SVDeviceStreamOpen)GetProcAddress(g_hModule, "SVDeviceStreamOpen");
    g_pFnSVDeviceClose = (Tfn_SVDeviceClose)GetProcAddress(g_hModule, "SVDeviceClose");

    g_pFnSVStreamAcquisitionStart = (Tfn_SVStreamAcquisitionStart)GetProcAddress(g_hModule, "SVStreamAcquisitionStart");
    g_pFnSVStreamAcquisitionStop = (Tfn_SVStreamAcquisitionStop)GetProcAddress(g_hModule, "SVStreamAcquisitionStop");
    g_pFnSVStreamAnnounceBuffer = (Tfn_SVStreamAnnounceBuffer)GetProcAddress(g_hModule, "SVStreamAnnounceBuffer");
    g_pFnSVStreamAllocAndAnnounceBuffer = (Tfn_SVStreamAllocAndAnnounceBuffer)GetProcAddress(g_hModule, "SVStreamAllocAndAnnounceBuffer");
    g_pFnSVStreamRevokeBuffer = (Tfn_SVStreamRevokeBuffer)GetProcAddress(g_hModule, "SVStreamRevokeBuffer");
    g_pFnSVStreamQueueBuffer = (Tfn_SVStreamQueueBuffer)GetProcAddress(g_hModule, "SVStreamQueueBuffer");
    g_pFnSVStreamGetBufferId = (Tfn_SVStreamGetBufferId)GetProcAddress(g_hModule, "SVStreamGetBufferId");
    g_pFnSVStreamFlushQueue = (Tfn_SVStreamFlushQueue)GetProcAddress(g_hModule, "SVStreamFlushQueue");
    g_pFnSVStreamWaitForNewBuffer = (Tfn_SVStreamWaitForNewBuffer)GetProcAddress(g_hModule, "SVStreamWaitForNewBuffer");
    g_pFnSVStreamBufferGetInfo = (Tfn_SVStreamBufferGetInfo)GetProcAddress(g_hModule, "SVStreamBufferGetInfo");
    g_pFnSVStreamClose = (Tfn_SVStreamClose)GetProcAddress(g_hModule, "SVStreamClose");

    g_pFnSVFeatureGetByName = (Tfn_SVFeatureGetByName)GetProcAddress(g_hModule, "SVFeatureGetByName");
    g_pFnSVFeatureGetByIndex = (Tfn_SVFeatureGetByIndex)GetProcAddress(g_hModule, "SVFeatureGetByIndex");
    g_pFnSVFeatureGetInfo = (Tfn_SVFeatureGetInfo)GetProcAddress(g_hModule, "SVFeatureGetInfo");
    g_pFnSVFeatureGetValueBool = (Tfn_SVFeatureGetValueBool)GetProcAddress(g_hModule, "SVFeatureGetValueBool");
    g_pFnSVFeatureGetValueInt64 = (Tfn_SVFeatureGetValueInt64)GetProcAddress(g_hModule, "SVFeatureGetValueInt64");
    g_pFnSVFeatureGetValueFloat = (Tfn_SVFeatureGetValueFloat)GetProcAddress(g_hModule, "SVFeatureGetValueFloat");
    g_pFnSVFeatureGetValueString = (Tfn_SVFeatureGetValueString)GetProcAddress(g_hModule, "SVFeatureGetValueString");
    g_pFnSVFeatureGetValueRegister = (Tfn_SVFeatureGetValueRegister)GetProcAddress(g_hModule, "SVFeatureGetRegister");
    g_pFnSVFeatureGetValueInt64Enum = (Tfn_SVFeatureGetValueInt64Enum)GetProcAddress(g_hModule, "SVFeatureGetValueInt64Enum");

    g_pFnSVFeatureSetValueBool = (Tfn_SVFeatureSetValueBool)GetProcAddress(g_hModule, "SVFeatureSetValueBool");
    g_pFnSVFeatureSetValueInt64 = (Tfn_SVFeatureSetValueInt64)GetProcAddress(g_hModule, "SVFeatureSetValueInt64");
    g_pFnSVFeatureSetValueFloat = (Tfn_SVFeatureSetValueFloat)GetProcAddress(g_hModule, "SVFeatureSetValueFloat");
    g_pFnSVFeatureSetValueString = (Tfn_SVFeatureSetValueString)GetProcAddress(g_hModule, "SVFeatureSetValueString");
    g_pFnSVFeatureSetValueRegister = (Tfn_SVFeatureSetValueRegister)GetProcAddress(g_hModule, "SVFeatureSetRegister");
    g_pFnSVFeatureSetValueInt64Enum = (Tfn_SVFeatureSetValueInt64Enum)GetProcAddress(g_hModule, "SVFeatureSetValueInt64Enum");
    g_pFnSVFeatureCommandExecute = (Tfn_SVFeatureCommandExecute)GetProcAddress(g_hModule, "SVFeatureCommandExecute");
    g_pFnSVFeatureEnumSubFeatures = (Tfn_SVFeatureEnumSubFeatures)GetProcAddress(g_hModule, "SVFeatureEnumSubFeatures");
    g_pFnSVFeatureRegisterInvalidateCB = (Tfn_SVFeatureRegisterInvalidateCB)GetProcAddress(g_hModule, "SVFeatureRegisterInvalidateCB");
    g_pFnSVFeatureUnRegisterInvalidateCB = (Tfn_SVFeatureUnRegisterInvalidateCB)GetProcAddress(g_hModule, "SVFeatureUnRegisterInvalidateCB");

    g_pFnSVUtilBuffer12BitTo8Bit = (Tfn_SVUtilBuffer12BitTo8Bit)GetProcAddress(g_hModule, "SVUtilBuffer12BitTo8Bit");
    g_pFnSVUtilBuffer12BitTo16Bit = (Tfn_SVUtilBuffer12BitTo16Bit)GetProcAddress(g_hModule, "SVUtilBuffer12BitTo16Bit");
    g_pFnSVUtilBuffer16BitTo8Bit = (Tfn_SVUtilBuffer16BitTo8Bit)GetProcAddress(g_hModule, "SVUtilBuffer16BitTo8Bit");
    g_pFnSVUtilBufferBayerToRGB = (Tfn_SVUtilBufferBayerToRGB)GetProcAddress(g_hModule, "SVUtilBufferBayerToRGB");

    g_pFnSVLogRegister = (Tfn_SVLogRegister)GetProcAddress(g_hModule, "SVLogRegister");
    g_pFnSVLogEnableWindbg = (Tfn_SVLogEnableWindbg)GetProcAddress(g_hModule, "SVLogEnableWindbg");
    g_pFnSVLogEnableFileLogging = (Tfn_SVLogEnableFileLogging)GetProcAddress(g_hModule, "SVLogEnableFileLogging");
    g_pFnSVLogSetGlobalDebugLevel = (Tfn_SVLogSetGlobalDebugLevel)GetProcAddress(g_hModule, "SVLogSetGlobalDebugLevel");
    g_pFnSVLogTraceA = (Tfn_SVLogTraceA)GetProcAddress(g_hModule, "SVLogTraceA");

    g_pFnSVUtilBufferBayerToRGB32 = (Tfn_SVUtilBufferBayerToRGB32)GetProcAddress(g_hModule, "SVUtilBufferBayerToRGB32");
    g_pFnSVLibIsVersionCompliant = (Tfn_SVLibIsVersionCompliant)GetProcAddress(g_hModule, "SVLibIsVersionCompliant");
    g_pFnSVFeatureGetValueEnum = (Tfn_SVFeatureGetValueEnum)GetProcAddress(g_hModule, "SVFeatureGetValueEnum");
    g_pFnSVFeatureSetValueEnum = (Tfn_SVFeatureSetValueEnum)GetProcAddress(g_hModule, "SVFeatureSetValueEnum");
    g_pFnSVDeviceSaveSettingsToString = (Tfn_SVDeviceSaveSettingsToString)GetProcAddress(g_hModule, "SVDeviceSaveSettingsToString");
    g_pFnSVDeviceLoadSettingsFromString = (Tfn_SVDeviceLoadSettingsFromString)GetProcAddress(g_hModule, "SVDeviceLoadSettingsFromString");
    g_pFnSVFeatureListRefresh = (Tfn_SVFeatureListRefresh)GetProcAddress(g_hModule, "SVFeatureListRefresh");
    g_pFnSVUtilSaveImageToPNGFile = (Tfn_SVUtilSaveImageToPNGFile)GetProcAddress(g_hModule, "SVUtilSaveImageToPNGFile");

    g_pFnSVFeatureGetDescription = (Tfn_SVFeatureGetDescription)GetProcAddress(g_hModule, "SVFeatureGetDescription");
    g_pFnSVFeatureRegisterInvalidateCB2 = (Tfn_SVFeatureRegisterInvalidateCB2)GetProcAddress(g_hModule, "SVFeatureRegisterInvalidateCB2");

    g_pFnSVEventRegister = (Tfn_SVEventRegister)GetProcAddress(g_hModule, "SVEventRegister");
    g_pFnSVEventUnRegister  = (Tfn_SVEventUnRegister)GetProcAddress(g_hModule, "SVEventUnRegister");
    g_pFnSVEventGetInfo = (Tfn_SVEventGetInfo)GetProcAddress(g_hModule, "SVEventGetInfo");
    g_pFnSVEventWait  = (Tfn_SVEventWait)GetProcAddress(g_hModule, "SVEventWait");
    g_pFnSVEventFlush  = (Tfn_SVEventFlush)GetProcAddress(g_hModule, "SVEventFlush");
    g_pFnSVEventKill  = (Tfn_SVEventKill)GetProcAddress(g_hModule, "SVEventKill");

    g_pFnSVUtilSaveImageToFile  = (Tfn_SVUtilSaveImageToFile)GetProcAddress(g_hModule, "SVUtilSaveImageToFile");

    g_pFnSVStreamGetInfo = (Tfn_SVStreamGetInfo)GetProcAddress(g_hModule, "SVStreamGetInfo");
    g_pFnSVRegisterDeviceWrite = (Tfn_SVRegisterDeviceWrite)GetProcAddress(g_hModule, "SVRegisterDeviceWrite");


    if (!g_pFnSVLibInit ||
        !g_pFnSVLibSystemGetCount ||
        !g_pFnSVLibSystemGetInfo ||
        !g_pFnSVLibSystemOpen ||
        !g_pFnSVLibClose ||
        !g_pFnSVSystemGetInfo ||
        !g_pFnSVSystemUpdateInterfaceList ||
        !g_pFnSVSystemGetNumInterfaces ||
        !g_pFnSVSystemGetInterfaceId ||
        !g_pFnSVSystemInterfaceGetInfo ||
        !g_pFnSVSystemInterfaceOpen ||
        !g_pFnSVSystemClose ||
        !g_pFnSVInterfaceGetInfo ||
        !g_pFnSVInterfaceUpdateDeviceList ||
        !g_pFnSVInterfaceGetNumDevices ||
        !g_pFnSVInterfaceGetDeviceId ||
        !g_pFnSVInterfaceDeviceGetInfo ||
        !g_pFnSVInterfaceDeviceOpen ||
        !g_pFnSVInterfaceClose ||
        !g_pFnSVDeviceGetInfo ||
        !g_pFnSVDeviceGetNumStreams ||
        !g_pFnSVDeviceGetStreamId ||
        !g_pFnSVDeviceSaveSettings ||
        !g_pFnSVDeviceLoadSettings ||
        !g_pFnSVDeviceRead ||
        !g_pFnSVDeviceWrite ||
        !g_pFnSVDeviceStreamOpen ||
        !g_pFnSVDeviceClose ||
        !g_pFnSVStreamAcquisitionStart ||
        !g_pFnSVStreamAcquisitionStop ||
        !g_pFnSVStreamAnnounceBuffer ||
        !g_pFnSVStreamAllocAndAnnounceBuffer ||
        !g_pFnSVStreamRevokeBuffer ||
        !g_pFnSVStreamQueueBuffer ||
        !g_pFnSVStreamGetBufferId ||
        !g_pFnSVStreamFlushQueue ||
        !g_pFnSVStreamWaitForNewBuffer ||
        !g_pFnSVStreamBufferGetInfo ||
        !g_pFnSVStreamClose ||
        !g_pFnSVFeatureGetByName ||
        !g_pFnSVFeatureGetByIndex ||
        !g_pFnSVFeatureGetInfo ||
        !g_pFnSVFeatureGetValueBool ||
        !g_pFnSVFeatureGetValueInt64 ||
        !g_pFnSVFeatureGetValueFloat ||
        !g_pFnSVFeatureGetValueString ||
        !g_pFnSVFeatureGetValueRegister ||
        !g_pFnSVFeatureGetValueInt64Enum ||
        !g_pFnSVFeatureSetValueBool ||
        !g_pFnSVFeatureSetValueInt64 ||
        !g_pFnSVFeatureSetValueFloat ||
        !g_pFnSVFeatureSetValueString ||
        !g_pFnSVFeatureSetValueRegister ||
        !g_pFnSVFeatureSetValueInt64Enum ||
        !g_pFnSVFeatureCommandExecute ||
        !g_pFnSVFeatureEnumSubFeatures ||
        !g_pFnSVFeatureRegisterInvalidateCB ||
        !g_pFnSVFeatureUnRegisterInvalidateCB ||
        !g_pFnSVUtilBuffer12BitTo8Bit ||
        !g_pFnSVUtilBuffer12BitTo16Bit ||
        !g_pFnSVUtilBuffer16BitTo8Bit ||
        !g_pFnSVUtilBufferBayerToRGB ||
        !g_pFnSVLogRegister ||
        !g_pFnSVLogEnableWindbg ||
        !g_pFnSVLogEnableFileLogging ||
        !g_pFnSVLogSetGlobalDebugLevel ||
        !g_pFnSVLogTraceA ||
        !g_pFnSVUtilBufferBayerToRGB32 ||
        !g_pFnSVLibIsVersionCompliant ||
        !g_pFnSVFeatureGetValueEnum ||
        !g_pFnSVFeatureSetValueEnum ||
        !g_pFnSVDeviceSaveSettingsToString ||
        !g_pFnSVDeviceLoadSettingsFromString ||
        !g_pFnSVFeatureListRefresh ||
        !g_pFnSVUtilSaveImageToPNGFile ||
        !g_pFnSVFeatureGetDescription ||
        !g_pFnSVFeatureRegisterInvalidateCB2 ||
        !g_pFnSVEventRegister ||
        !g_pFnSVEventUnRegister ||
        !g_pFnSVEventWait ||
        !g_pFnSVEventGetInfo ||
        !g_pFnSVEventFlush ||
        !g_pFnSVEventKill  ||
        !g_pFnSVUtilSaveImageToFile ||
        !g_pFnSVRegisterDeviceWrite
        )
    {
        FreeLibrary(g_hModule);
        return SV_ERROR_UNKNOWN;
    }

    return SV_ERROR_SUCCESS;
}

void CloseSDK()
{
    if (g_hModule != NULL)
    {
        FreeLibrary(g_hModule);
        g_hModule = NULL;
    }
}

SV_RETURN SVLibInit(const char *TLIPath ,
                    const char *genicamRootDir ,
                    const char *genicamCacheDir ,
                    const char *clProtocolDriverDir )
{
    SV_RETURN status = SV_ERROR_SUCCESS;

    if (g_hModule == NULL)
    {
        status = OpenSDK();
        if (SV_ERROR_SUCCESS != status)
            return status;
    }

    if (g_pFnSVLibInit)
        return g_pFnSVLibInit(TLIPath, genicamRootDir, genicamCacheDir, clProtocolDriverDir);

    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLibClose()
{
    SV_RETURN status = SV_ERROR_NOT_INITIALIZED;
    if (g_pFnSVLibClose)
    {
        status = g_pFnSVLibClose();
        CloseSDK();
    }

    return status;
}

SV_RETURN SVLibSystemGetCount(uint32_t *tlCount)
{
    if (g_pFnSVLibSystemGetCount)
        return g_pFnSVLibSystemGetCount(tlCount);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLibSystemGetInfo(uint32_t uiIndex, SV_TL_INFO *pInfoOut)
{
    if (g_pFnSVLibSystemGetInfo)
        return g_pFnSVLibSystemGetInfo(uiIndex, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLibSystemOpen(uint32_t uiIndex, SV_SYSTEM_HANDLE *phSystemOut)
{
    if (g_pFnSVLibSystemOpen)
        return g_pFnSVLibSystemOpen(uiIndex, phSystemOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVSystemGetInfo(SV_SYSTEM_HANDLE hSystem, SV_TL_INFO *pInfoOut)
{
    if (g_pFnSVSystemGetInfo)
        return g_pFnSVSystemGetInfo(hSystem, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVSystemUpdateInterfaceList(SV_SYSTEM_HANDLE hSystem, bool8_t *pbChanged, uint32_t timeOut)
{
    if (g_pFnSVSystemUpdateInterfaceList)
        return g_pFnSVSystemUpdateInterfaceList(hSystem, pbChanged, timeOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVSystemGetNumInterfaces(SV_SYSTEM_HANDLE hSystem, uint32_t *piNumIfaces)
{
    if (g_pFnSVSystemGetNumInterfaces)
        return g_pFnSVSystemGetNumInterfaces(hSystem, piNumIfaces);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVSystemGetInterfaceId(SV_SYSTEM_HANDLE hSystem, uint32_t Index, char* pInterfaceId, size_t *pSize)
{
    if (g_pFnSVSystemGetInterfaceId)
        return g_pFnSVSystemGetInterfaceId(hSystem, Index, pInterfaceId, pSize);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVSystemInterfaceGetInfo(SV_SYSTEM_HANDLE hSystem, const char *pInterfaceId, SV_INTERFACE_INFO *pInfoOut)
{
    if (g_pFnSVSystemInterfaceGetInfo)
        return g_pFnSVSystemInterfaceGetInfo(hSystem, pInterfaceId, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVSystemInterfaceOpen(SV_SYSTEM_HANDLE hSystem, const char *pInterfaceId, SV_INTERFACE_HANDLE *phInterfaceOut)
{
    if (g_pFnSVSystemInterfaceOpen)
        return g_pFnSVSystemInterfaceOpen(hSystem, pInterfaceId, phInterfaceOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVSystemClose(SV_SYSTEM_HANDLE hSystem)
{
    if (g_pFnSVSystemClose)
        return g_pFnSVSystemClose(hSystem);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVInterfaceGetInfo(SV_INTERFACE_HANDLE hInterface, SV_INTERFACE_INFO *pInfoOut)
{
    if (g_pFnSVInterfaceGetInfo)
        return g_pFnSVInterfaceGetInfo(hInterface, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVInterfaceUpdateDeviceList(SV_INTERFACE_HANDLE hInterface, bool8_t *pbChanged, uint32_t timeOut)
{
    if (g_pFnSVInterfaceUpdateDeviceList)
        return g_pFnSVInterfaceUpdateDeviceList(hInterface, pbChanged, timeOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVInterfaceGetNumDevices(SV_INTERFACE_HANDLE hInterface, uint32_t *piDevices)
{
    if (g_pFnSVInterfaceGetNumDevices)
        return g_pFnSVInterfaceGetNumDevices(hInterface, piDevices);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVInterfaceGetDeviceId(SV_INTERFACE_HANDLE hInterface, uint32_t Index, char* pDeviceId, size_t *pSize)
{
    if (g_pFnSVInterfaceGetDeviceId)
        return g_pFnSVInterfaceGetDeviceId(hInterface, Index, pDeviceId, pSize);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVInterfaceDeviceGetInfo(SV_INTERFACE_HANDLE hInterface, const char *pDeviceId, SV_DEVICE_INFO *pInfoOut)
{
    if (g_pFnSVInterfaceDeviceGetInfo)
        return g_pFnSVInterfaceDeviceGetInfo(hInterface, pDeviceId, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVInterfaceDeviceOpen(SV_INTERFACE_HANDLE hInterface,
                                const char *pDeviceId,
                                SV_DEVICE_ACCESS_FLAGS accessFlags,
                                SV_DEVICE_HANDLE *phDeviceOut,
                                SV_REMOTE_DEVICE_HANDLE *phRemoteDeviceOut)
{
    if (g_pFnSVInterfaceDeviceOpen)
        return g_pFnSVInterfaceDeviceOpen(hInterface, pDeviceId, accessFlags, phDeviceOut, phRemoteDeviceOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVInterfaceClose(SV_INTERFACE_HANDLE hInterface)
{
    if (g_pFnSVInterfaceClose)
        return g_pFnSVInterfaceClose(hInterface);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceGetInfo(SV_DEVICE_HANDLE hDevice, SV_DEVICE_INFO *pInfoOut)
{
    if (g_pFnSVDeviceGetInfo)
        return g_pFnSVDeviceGetInfo(hDevice, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceGetNumStreams(SV_DEVICE_HANDLE hDevice, uint32_t *piStreams)
{
    if (g_pFnSVDeviceGetNumStreams)
        return g_pFnSVDeviceGetNumStreams(hDevice, piStreams);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceGetStreamId(SV_DEVICE_HANDLE hDevice, uint32_t Index, char* pStreamId, size_t *pSize)
{
    if (g_pFnSVDeviceGetStreamId)
        return g_pFnSVDeviceGetStreamId(hDevice, Index, pStreamId, pSize);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceSaveSettings(SV_DEVICE_HANDLE hDevice, const char *fileName)
{
    if (g_pFnSVDeviceSaveSettings)
        return g_pFnSVDeviceSaveSettings(hDevice, fileName);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceLoadSettings(SV_DEVICE_HANDLE hDevice, const char *fileName)
{
    if (g_pFnSVDeviceLoadSettings)
        return g_pFnSVDeviceLoadSettings(hDevice, fileName);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceRead(SV_DEVICE_HANDLE hDevice, uint64_t nAddress, void *pData, size_t *pSize)
{
    if (g_pFnSVDeviceRead)
        return g_pFnSVDeviceRead(hDevice, nAddress, pData, pSize);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceWrite(SV_DEVICE_HANDLE hDevice, uint64_t nAddress, const void *pData, size_t *pSize)
{
    if (g_pFnSVDeviceWrite)
        return g_pFnSVDeviceWrite(hDevice, nAddress, pData, pSize);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceStreamOpen(SV_DEVICE_HANDLE hDevice, const char *sDataStreamID, SV_STREAM_HANDLE *phStream)
{
    if (g_pFnSVDeviceStreamOpen)
        return g_pFnSVDeviceStreamOpen(hDevice, sDataStreamID, phStream);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceClose(SV_DEVICE_HANDLE hDevice)
{
    if (g_pFnSVDeviceClose)
        return g_pFnSVDeviceClose(hDevice);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamAcquisitionStart(SV_STREAM_HANDLE hStream, SV_ACQ_START_FLAGS flags, uint64_t iNumToAcquire)
{
    if (g_pFnSVStreamAcquisitionStart)
        return g_pFnSVStreamAcquisitionStart(hStream, flags, iNumToAcquire);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamAcquisitionStop(SV_STREAM_HANDLE hStream, SV_ACQ_STOP_FLAGS flags)
{
    if (g_pFnSVStreamAcquisitionStop)
        return g_pFnSVStreamAcquisitionStop(hStream, flags);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamAnnounceBuffer(SV_STREAM_HANDLE hStream, void *pBuffer, uint32_t uiSize, void *pPrivate, SV_BUFFER_HANDLE *phBuffer)
{
    if (g_pFnSVStreamAnnounceBuffer)
        return g_pFnSVStreamAnnounceBuffer(hStream, pBuffer, uiSize, pPrivate, phBuffer);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamAllocAndAnnounceBuffer(SV_STREAM_HANDLE hStream, uint32_t uiSize, void *pPrivate, SV_BUFFER_HANDLE *phBuffer)
{
    if (g_pFnSVStreamAllocAndAnnounceBuffer)
        return g_pFnSVStreamAllocAndAnnounceBuffer(hStream, uiSize, pPrivate, phBuffer);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamRevokeBuffer(SV_STREAM_HANDLE hStream, SV_BUFFER_HANDLE hBuffer, void **pBuffer, void **pPrivate)
{
    if (g_pFnSVStreamRevokeBuffer)
        return g_pFnSVStreamRevokeBuffer(hStream, hBuffer, pBuffer, pPrivate);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamQueueBuffer(SV_STREAM_HANDLE hStream, SV_BUFFER_HANDLE hBuffer)
{
    if (g_pFnSVStreamQueueBuffer)
        return g_pFnSVStreamQueueBuffer(hStream, hBuffer);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamGetBufferId(SV_STREAM_HANDLE hStream, uint32_t iIndex, SV_BUFFER_HANDLE *phBuffer)
{
    if (g_pFnSVStreamGetBufferId)
        return g_pFnSVStreamGetBufferId(hStream, iIndex, phBuffer);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamFlushQueue(SV_STREAM_HANDLE hStream, SV_ACQ_QUEUE_TYPE iOperation)
{
    if (g_pFnSVStreamFlushQueue)
        return g_pFnSVStreamFlushQueue(hStream, iOperation);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamWaitForNewBuffer(SV_STREAM_HANDLE hStream, void **ppUserData, SV_BUFFER_HANDLE *phBufferOut, uint32_t timeOut)
{
    if (g_pFnSVStreamWaitForNewBuffer)
        return g_pFnSVStreamWaitForNewBuffer(hStream, ppUserData, phBufferOut, timeOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamBufferGetInfo(SV_STREAM_HANDLE hStream, SV_BUFFER_HANDLE hBuffer, SV_BUFFER_INFO *pInfoOut)
{
    if (g_pFnSVStreamBufferGetInfo)
        return g_pFnSVStreamBufferGetInfo(hStream, hBuffer, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamClose(SV_STREAM_HANDLE hStream)
{
    if (g_pFnSVStreamClose)
        return g_pFnSVStreamClose(hStream);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetByName(void *hModule, const char *featureName, SV_FEATURE_HANDLE *phFeature)
{
    if (g_pFnSVFeatureGetByName)
        return g_pFnSVFeatureGetByName(hModule, featureName, phFeature);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetByIndex(void *hModule, uint32_t iIndex, SV_FEATURE_HANDLE *phFeature)
{
    if (g_pFnSVFeatureGetByIndex)
        return g_pFnSVFeatureGetByIndex(hModule, iIndex, phFeature);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetInfo(void *hModule, SV_FEATURE_HANDLE hFeature, SV_FEATURE_INFO *pInfoOut)
{
    if (g_pFnSVFeatureGetInfo)
        return g_pFnSVFeatureGetInfo(hModule, hFeature, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetValueBool(void *hModule, SV_FEATURE_HANDLE hFeature, bool8_t *pBoolValue, bool verify, bool ignoreCache)
{
    if (g_pFnSVFeatureGetValueBool)
        return g_pFnSVFeatureGetValueBool(hModule, hFeature, pBoolValue, verify, ignoreCache);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetValueInt64(void *hModule, SV_FEATURE_HANDLE hFeature, int64_t *pInt64Value, bool verify, bool ignoreCache)
{
    if (g_pFnSVFeatureGetValueInt64)
        return g_pFnSVFeatureGetValueInt64(hModule, hFeature, pInt64Value, verify, ignoreCache);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetValueFloat(void *hModule, SV_FEATURE_HANDLE hFeature, double *pFloatValue, bool verify, bool ignoreCache)
{
    if (g_pFnSVFeatureGetValueFloat)
        return g_pFnSVFeatureGetValueFloat(hModule, hFeature, pFloatValue, verify, ignoreCache);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetValueString(void *hModule, SV_FEATURE_HANDLE hFeature, char *strValue, uint32_t bufferSize, bool verify, bool ignoreCache)
{
    if (g_pFnSVFeatureGetValueString)
        return g_pFnSVFeatureGetValueString(hModule, hFeature, strValue, bufferSize, verify, ignoreCache);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetRegister(void* hModule, SV_FEATURE_HANDLE hFeature, char* strValue, uint32_t bufferSize, bool verify, bool ignoreCache)
{
    if (g_pFnSVFeatureGetValueRegister)
        return g_pFnSVFeatureGetValueRegister(hModule, hFeature, strValue, bufferSize, verify, ignoreCache);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetValueInt64Enum(void *hModule, SV_FEATURE_HANDLE hFeature, int64_t *pInt64Value, bool verify, bool ignoreCache)
{
    if (g_pFnSVFeatureGetValueInt64Enum)
        return g_pFnSVFeatureGetValueInt64Enum(hModule, hFeature, pInt64Value, verify, ignoreCache);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureSetValueBool(void *hModule, SV_FEATURE_HANDLE hFeature, const bool8_t boolValue, bool verify)
{
    if (g_pFnSVFeatureSetValueBool)
        return g_pFnSVFeatureSetValueBool(hModule, hFeature, boolValue, verify);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureSetValueInt64(void *hModule, SV_FEATURE_HANDLE hFeature, const int64_t int64Value, bool verify)
{
    if (g_pFnSVFeatureSetValueInt64)
        return g_pFnSVFeatureSetValueInt64(hModule, hFeature, int64Value, verify);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureSetValueFloat(void *hModule, SV_FEATURE_HANDLE hFeature, const double floatValue, bool verify)
{
    if (g_pFnSVFeatureSetValueFloat)
        return g_pFnSVFeatureSetValueFloat(hModule, hFeature, floatValue, verify);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureSetValueString(void *hModule, SV_FEATURE_HANDLE hFeature, const char *strValue, bool verify)
{
    if (g_pFnSVFeatureSetValueString)
        return g_pFnSVFeatureSetValueString(hModule, hFeature, strValue, verify);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureSetRegister(void* hModule, SV_FEATURE_HANDLE hFeature, const uint8_t* value, int64_t length, bool verify)
{
    if (g_pFnSVFeatureSetValueRegister)
        return g_pFnSVFeatureSetValueRegister(hModule, hFeature, value, length, verify);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureSetValueInt64Enum(void *hModule, SV_FEATURE_HANDLE hFeature, const int64_t int64Value, bool verify)
{
    if (g_pFnSVFeatureSetValueInt64Enum)
        return g_pFnSVFeatureSetValueInt64Enum(hModule, hFeature, int64Value, verify);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureCommandExecute(void *hModule, SV_FEATURE_HANDLE hFeature, uint32_t Timeout, bool bWait)
{
    if (g_pFnSVFeatureCommandExecute)
        return g_pFnSVFeatureCommandExecute(hModule, hFeature, Timeout, bWait);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureEnumSubFeatures(void *hModule, SV_FEATURE_HANDLE hFeature, int32_t iIndex, char *subFeatureName, unsigned int bufferSize, int64_t *pValue)
{
    if (g_pFnSVFeatureEnumSubFeatures)
        return g_pFnSVFeatureEnumSubFeatures(hModule, hFeature, iIndex, subFeatureName, bufferSize, pValue);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureRegisterInvalidateCB(void *hModule, SV_FEATURE_HANDLE hFeature, SV_CB_OBJECT objCb, SV_CB_FEATURE_INVALIDATED_PFN pfnFeatureInvalidateCb)
{
    if (g_pFnSVFeatureRegisterInvalidateCB)
        return g_pFnSVFeatureRegisterInvalidateCB(hModule, hFeature, objCb, pfnFeatureInvalidateCb);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureUnRegisterInvalidateCB(void *hModule, SV_FEATURE_HANDLE hFeature)
{
    if (g_pFnSVFeatureUnRegisterInvalidateCB)
        return g_pFnSVFeatureUnRegisterInvalidateCB(hModule, hFeature);
    return SV_ERROR_NOT_IMPLEMENTED;
}

//Buffer
SV_RETURN SVUtilBuffer12BitTo8Bit(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int size)
{
    if (g_pFnSVUtilBuffer12BitTo8Bit)
        return g_pFnSVUtilBuffer12BitTo8Bit(srcInfo, pDest, size);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVUtilBuffer12BitTo16Bit(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int size)
{
    if (g_pFnSVUtilBuffer12BitTo16Bit)
        return g_pFnSVUtilBuffer12BitTo16Bit(srcInfo, pDest, size);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVUtilBuffer16BitTo8Bit(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int size)
{
    if (g_pFnSVUtilBuffer16BitTo8Bit)
        return g_pFnSVUtilBuffer16BitTo8Bit(srcInfo, pDest, size);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVUtilBufferBayerToRGB(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int size)
{
    if (g_pFnSVUtilBufferBayerToRGB)
        return g_pFnSVUtilBufferBayerToRGB(srcInfo, pDest, size);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLogRegister(const char *moduleName, const unsigned int debugLevel)
{
    if (g_pFnSVLogRegister)
        return g_pFnSVLogRegister(moduleName, debugLevel);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLogEnableWindbg(bool bEnable)
{
    if (g_pFnSVLogEnableWindbg)
        return g_pFnSVLogEnableWindbg(bEnable);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLogEnableFileLogging(bool bEnable, const char *logFileName)
{
    if (g_pFnSVLogEnableFileLogging)
        return g_pFnSVLogEnableFileLogging(bEnable, logFileName);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLogSetGlobalDebugLevel(const unsigned int debugLevel)
{
    if (g_pFnSVLogSetGlobalDebugLevel)
        return g_pFnSVLogSetGlobalDebugLevel(debugLevel);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLogTraceA(const char *moduleName, const unsigned int debugLevel, const char *format, ...)
{
    if (g_pFnSVLogTraceA)
    {
        va_list vl;
        va_start(vl, format);
        SV_RETURN ret = g_pFnSVLogTraceA(moduleName, debugLevel, format, vl);
        va_end(vl);
        return ret;
    }

    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVUtilBufferBayerToRGB32(SV_BUFFER_INFO srcInfo, unsigned char *pDest, int pDestLength)
{
    if (g_pFnSVUtilBufferBayerToRGB32)
        return g_pFnSVUtilBufferBayerToRGB32(srcInfo, pDest, pDestLength);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVLibIsVersionCompliant(const SV_LIB_VERSION expectedVersion, SV_LIB_VERSION *pCurrentVersion)
{
    if (g_pFnSVLibIsVersionCompliant)
        return g_pFnSVLibIsVersionCompliant(expectedVersion, pCurrentVersion);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetValueEnum(void *hModule, SV_FEATURE_HANDLE hFeature, char *buffer, unsigned int bufferSize, bool verify, bool ignoreCache)
{
    if (g_pFnSVFeatureGetValueEnum)
        return g_pFnSVFeatureGetValueEnum(hModule, hFeature, buffer, bufferSize, verify, ignoreCache);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureSetValueEnum(void *hModule, SV_FEATURE_HANDLE hFeature, const char *buffer, bool verify)
{
    if (g_pFnSVFeatureSetValueEnum)
        return g_pFnSVFeatureSetValueEnum(hModule, hFeature, buffer, verify);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceSaveSettingsToString(SV_DEVICE_HANDLE hDevice, char *buffer, uint32_t *pBufferSize)
{
    if (g_pFnSVDeviceSaveSettingsToString)
        return g_pFnSVDeviceSaveSettingsToString(hDevice, buffer, pBufferSize);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVDeviceLoadSettingsFromString(SV_DEVICE_HANDLE hDevice, const char *buffer)
{
    if (g_pFnSVDeviceLoadSettingsFromString)
        return g_pFnSVDeviceLoadSettingsFromString(hDevice, buffer);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureListRefresh(void *hModule)
{
    if (g_pFnSVFeatureListRefresh)
        return g_pFnSVFeatureListRefresh(hModule);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVUtilSaveImageToPNGFile(const SV_BUFFER_INFO &info, const char* fileName)
{
    if (g_pFnSVUtilSaveImageToPNGFile)
        return g_pFnSVUtilSaveImageToPNGFile(info, fileName);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureGetDescription(void *hModule, SV_FEATURE_HANDLE hFeature, char *pBuffer, uint32_t bufferSize)
{
    if (g_pFnSVFeatureGetDescription)
        return g_pFnSVFeatureGetDescription(hModule, hFeature, pBuffer, bufferSize);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVFeatureRegisterInvalidateCB2(void *hModule, SV_FEATURE_HANDLE hFeature, void *pContext, SV_CB_FEATURE_INVALIDATED_PFN2 pfnFeatureInvalidateCb)
{
    if (g_pFnSVFeatureRegisterInvalidateCB2)
        return g_pFnSVFeatureRegisterInvalidateCB2(hModule, hFeature, pContext, pfnFeatureInvalidateCb);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVEventRegister(void *hModule, SV_EVENT_TYPE iEventID, SV_EVENT_HANDLE *phEvent)
{
    if (g_pFnSVEventRegister)
        return g_pFnSVEventRegister(hModule, iEventID, phEvent);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVEventUnRegister(void *hModule, SV_EVENT_TYPE iEventID)
{
    if (g_pFnSVEventUnRegister)
        return g_pFnSVEventUnRegister(hModule, iEventID);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVEventWait(void *hModule, SV_EVENT_HANDLE hEvent, void *pBuffer, size_t *pSize, uint64_t iTimeout)
{
    if (g_pFnSVEventWait)
        return g_pFnSVEventWait(hModule, hEvent, pBuffer, pSize, iTimeout);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVEventGetInfo(void *hModule, SV_EVENT_HANDLE hEvent, SV_EVENT_INFO *pEventInfo)
{
    if (g_pFnSVEventGetInfo)
        return g_pFnSVEventGetInfo(hModule, hEvent, pEventInfo);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVEventFlush(void *hModule, SV_EVENT_HANDLE hEvent)
{
    if (g_pFnSVEventFlush)
        return g_pFnSVEventFlush(hModule, hEvent);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVEventKill(void *hModule, SV_EVENT_HANDLE hEvent)
{
    if (g_pFnSVEventKill )
        return g_pFnSVEventKill (hModule, hEvent);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVUtilSaveImageToFile(const SV_BUFFER_INFO &info, const char* fileName, SV_IMAGE_FILE_TYPE fileType)
{
    if (g_pFnSVUtilSaveImageToFile)
        return g_pFnSVUtilSaveImageToFile(info, fileName, fileType);
    return SV_ERROR_NOT_IMPLEMENTED;
}

SV_RETURN SVStreamGetInfo(SV_STREAM_HANDLE hStream, SV_DS_INFO *pInfoOut)
{
    if (g_pFnSVStreamGetInfo)
        return g_pFnSVStreamGetInfo(hStream, pInfoOut);
    return SV_ERROR_NOT_IMPLEMENTED;
}

 SV_RETURN SVRegisterDeviceWrite(SV_DEVICE_HANDLE hDevice, SV_FEATURE_HANDLE hFeature, const uint8_t *value, size_t *length, bool verify, size_t offset)
 {
	   if (g_pFnSVRegisterDeviceWrite)
        return g_pFnSVRegisterDeviceWrite(hDevice, hFeature, value, length, verify, offset);
    return SV_ERROR_NOT_IMPLEMENTED;	
 }
 
#endif //_SV_GEN_SDK_DYNAMIC_H
