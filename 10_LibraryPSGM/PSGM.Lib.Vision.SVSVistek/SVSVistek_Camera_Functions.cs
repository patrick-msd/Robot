namespace PSGM.Lib.Vision.SVSVistek
{
    public partial class SVSVistek_Camera
    {
        #region Set camera settings ...
        public SVSVistek_Api.SVSVistekApiReturn SetFeatureString(string feature, string value, uint bufferSize = 512)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr phFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }
            ret = _svsVistekApi.SVS_FeatureSetValueString(_hRemoteDevice, phFeature, value);

            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn SetFeatureBool(string feature, bool value)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr phFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }
            ret = _svsVistekApi.SVS_FeatureSetValueBool(_hRemoteDevice, phFeature, value);

            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn SetFeatureInt(string feature, int value)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr phFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }
            ret = _svsVistekApi.SVS_FeatureSetValueInt64(_hRemoteDevice, phFeature, value);

            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn SetFeatureDouble(string feature, double value)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr phFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }
            ret = _svsVistekApi.SVS_FeatureSetValueFloat(_hRemoteDevice, phFeature, value);

            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn SetFeatureEnum(string feature, string value)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr phFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }
            ret = _svsVistekApi.SVS_FeatureSetValueEnum(_hRemoteDevice, phFeature, value);

            return ret;
        }

        public SVSVistek_Api.SVSVistekApiReturn SetFan(FanControl value)
        {
            return SetFeatureEnum("FanControl", value.ToString().ToUpper());
        }

        public SVSVistek_Api.SVSVistekApiReturn SetExposureTime(double value)
        {
            return SetFeatureDouble("ExposureTime", value);
        }

        public SVSVistek_Api.SVSVistekApiReturn SetGain(double gain)
        {
            return SetFeatureDouble("Gain", gain);
        }

        public SVSVistek_Api.SVSVistekApiReturn[] SetWhiteBalance(double redBalance, double greenBalance, double blueBalance)
        {
            List<SVSVistek_Api.SVSVistekApiReturn> ret = new List<SVSVistek_Api.SVSVistekApiReturn>();

            // Set red balance
            ret.Add(SetFeatureEnum("BalanceRatioSelector", "Red"));
            ret.Add(SetFeatureDouble("BalanceRatio", redBalance));

            // Set green balance
            ret.Add(SetFeatureEnum("BalanceRatioSelector", "Green"));
            ret.Add(SetFeatureDouble("BalanceRatio", greenBalance));

            // Set blue balance
            ret.Add(SetFeatureEnum("BalanceRatioSelector", "Blue"));
            ret.Add(SetFeatureDouble("BalanceRatio", blueBalance));

            return ret.ToArray();
        }

        public SVSVistek_Api.SVSVistekApiReturn SetPixelSize(string value)
        {
            return SetFeatureEnum("PixelSize", value);
        }


        public SVSVistek_Api.SVSVistekApiReturn SetOffsetY(int value)
        {
            return SetFeatureInt("OffsetY", value);
        }
        public SVSVistek_Api.SVSVistekApiReturn SetOffsetX(int value)
        {
            return SetFeatureInt("OffsetX", value);
        }

        public SVSVistek_Api.SVSVistekApiReturn SetDeviceUserID(string value)
        {
            return SetFeatureString("DeviceUserID", value);
        }

        // ------------------ Image Format ------------------
        public SVSVistek_Api.SVSVistekApiReturn SetWidth(int value)
        {
            return SetFeatureInt("Width", value);
        }

        public SVSVistek_Api.SVSVistekApiReturn SetHeight(int value)
        {
            return SetFeatureInt("Height", value);
        }

        public SVSVistek_Api.SVSVistekApiReturn SetSensorPixelSize(SensorPixelSize value)
        {
            return SetFeatureEnum("SensorPixelSize", value.ToString());
        }
        public SVSVistek_Api.SVSVistekApiReturn SetPixelFormat(PixelFormat value)
        {
            return SetFeatureEnum("PixelFormat", value.ToString());
        }

        public SVSVistek_Api.SVSVistekApiReturn SetPixelColorFilter(string value)
        {
            return SetFeatureEnum("PixelColorFilter", value);
        }

        public SVSVistek_Api.SVSVistekApiReturn SetBinningHorizontal(int value)
        {
            return SetFeatureInt("BinningHorizontal", value);
        }

        public int GetBinningVertical()
        {
            return GetFeatureInt("BinningVertical");
        }

        public SVSVistek_Api.SVSVistekApiReturn SetBinningVertical(int value)
        {
            return SetFeatureInt("BinningVertical", value);
        }

        public bool GetReverseX()
        {
            return GetFeatureBool("ReverseX");
        }

        public SVSVistek_Api.SVSVistekApiReturn SetReverseX(bool value)
        {
            return SetFeatureBool("ReverseX", value);
        }
        #endregion

        #region Get camera settings ...
        public string GetFeatureString(string feature, uint bufferSize = 512)
        {
            IntPtr phFeature = IntPtr.Zero;
            _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            string ret = "";
            _svsVistekApi.SVS_FeatureGetValueString(_hRemoteDevice, phFeature, ref ret, bufferSize);

            return ret;
        }

        public bool GetFeatureBool(string feature)
        {
            IntPtr phFeature = IntPtr.Zero;
            _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            bool ret = false;
            _svsVistekApi.SVS_FeatureGetValueBool(_hRemoteDevice, phFeature, ref ret);

            return ret;
        }

        public int GetFeatureInt(string feature)
        {
            IntPtr phFeature = IntPtr.Zero;
            _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            long ret = 0;
            _svsVistekApi.SVS_FeatureGetValueInt64(_hRemoteDevice, phFeature, ref ret);

            return (int)ret;
        }

        public double GetFeatureFloat(string feature)
        {
            IntPtr phFeature = IntPtr.Zero;
            _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            double ret = 0;
            _svsVistekApi.SVS_FeatureGetValueFloat(_hRemoteDevice, phFeature, ref ret);

            return (double)ret;
        }

        public string GetFeatureEnum(string feature, uint bufferSize = 512)
        {
            IntPtr phFeature = IntPtr.Zero;
            _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, feature, ref phFeature);
            string ret = "";
            _svsVistekApi.SVS_FeatureGetValueEnum(_hRemoteDevice, phFeature, ref ret, bufferSize);

            return ret;
        }

        // ------------------ Device Control ------------------
        public string GetVendorName(uint bufferSize = 512)
        {
            return GetFeatureString("DeviceVendorName", bufferSize);
        }

        public string GetDeviceModelName(uint bufferSize = 512)
        {
            return GetFeatureString("DeviceModelName", bufferSize);
        }

        public string GetDeviceManufacturerInfo(uint bufferSize = 512)
        {
            return GetFeatureString("DeviceManufacturerInfo", bufferSize);
        }

        public string GetDeviceVersion(uint bufferSize = 512)
        {
            return GetFeatureString("DeviceVersion", bufferSize);
        }

        public string GetDeviceFirmwareVersion(uint bufferSize = 512)
        {
            return GetFeatureString("DeviceFirmwareVersion", bufferSize);
        }

        public string GetDeviceSerialNumber(uint bufferSize = 512)
        {
            return GetFeatureString("DeviceID", bufferSize);
        }

        public string GetDeviceUserID(uint bufferSize = 512)
        {
            return GetFeatureString("DeviceUserID", bufferSize);
        }

        public double GetDeviceTemperature()
        {
            return GetFeatureFloat("DeviceTemperature");
        }

        // ------------------ Image Format ------------------
        public int GetSensorWidth()
        {
            return GetFeatureInt("SensorWidth");
        }

        public int GetSensorHeight()
        {
            return GetFeatureInt("SensorHeight");
        }

        public int GetOffsetX()
        {
            return GetFeatureInt("OffsetX");
        }

        public int GetOffsetY()
        {
            return GetFeatureInt("OffsetY");
        }

        public int GetWidth()
        {
            return GetFeatureInt("Width");
        }

        public int GetHeight()
        {
            return GetFeatureInt("Height");
        }

        public int GetMaxWidth()
        {
            return GetFeatureInt("WidthMax");
        }

        public int GetMaxHeight()
        {
            return GetFeatureInt("HeightMax");
        }

        public string GetPixelSize(uint bufferSize = 512)
        {
            return GetFeatureEnum("PixelSize", bufferSize);
        }

        public string GetSensorPixelSize(uint bufferSize = 512)
        {
            return GetFeatureEnum("SensorPixelSize", bufferSize);
        }

        public string GetPixelFormat(uint bufferSize = 512)
        {
            return GetFeatureEnum("PixelFormat", bufferSize);
        }

        public string GetPixelColorFilter(uint bufferSize = 512)
        {
            return GetFeatureEnum("PixelColorFilter", bufferSize);
        }

        public int GetPixelDynamicRangeMin()
        {
            return GetFeatureInt("PixelDynamicRangeMin");
        }

        public int GetPixelDynamicRangeMax()
        {
            return GetFeatureInt("PixelDynamicRangeMax");
        }

        public int GetBinningHorizontal()
        {
            return GetFeatureInt("BinningHorizontal");
        }
        #endregion

        #region Camera functions ...
        public SVSVistek_Api.SVSVistekApiReturn DeviceReset(uint timeout = 5000)
        {
            SVSVistek_Api.SVSVistekApiReturn ret = SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS;
            IntPtr phFeature = IntPtr.Zero;
            ret = _svsVistekApi.SVS_FeatureGetByName(_hRemoteDevice, "DeviceReset", ref phFeature);
            if (ret != SVSVistek_Api.SVSVistekApiReturn.SV_ERROR_SUCCESS)
            {
                return ret;
            }
            ret = _svsVistekApi.SVS_FeatureCommandExecute(_hRemoteDevice, phFeature, timeout);

            return ret;
        }
        #endregion
    }
}