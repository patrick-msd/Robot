namespace PSGM.Lib.Motion
{
    public partial class Nanotec_Container
    {
        public void QuickStop(Nlc.DeviceHandle deviceHandle)
        {
            while ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6041, 0x00)) & 0x20) != 0x00)
            {
                var value = ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFF70;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
        }

        public void EnableOperation(Nlc.DeviceHandle deviceHandle)
        {
            while ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6041, 0x00)) & 0xE9) != 0x21)
            {
                var value = (ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFF76) | 0x0006;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }

            while ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6041, 0x00)) & 0xEB) != 0x23)
            {
                var value = (ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFF77) | 0x0007;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }

            while ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6041, 0x00)) & 0xEF) != 0x27)
            {
                var value = (ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFF7F) | 0x000F;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
        }

        public void NewSetPoint(Nlc.DeviceHandle deviceHandle, bool newsetpoint)
        {
            if (newsetpoint)
            {
                var value = (ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) | 0x0010);
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
            else
            {
                var value = (ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFFEF);
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
        }

        public void NewSetPointTrigger(Nlc.DeviceHandle deviceHandle)
        {
            var value1 = (ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) | 0x0010);
            WriteNumber(deviceHandle, value1, new Nlc.OdIndex(0x6040, 0x00), 16);

            Thread.Sleep(1);

            var value2 = (ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFFEF);
            WriteNumber(deviceHandle, value2, new Nlc.OdIndex(0x6040, 0x00), 16);
        }

        public bool TargetReached(Nlc.DeviceHandle deviceHandle)
        {
            if ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6041, 0x00)) & 0x400) == 0x400)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NewSetPointAcknowledge(Nlc.DeviceHandle deviceHandle)
        {
            if ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6041, 0x00)) & 0x1000) == 0x1000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Shutdown(Nlc.DeviceHandle deviceHandle)
        {
            while ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6041, 0x00)) & 0xEF) != 0x21)
            {
                var value = ((ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFF76) | 0x0006);
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
        }

        public void ChangeSetPointMode(Nlc.DeviceHandle deviceHandle, int mode)
        {
            //ToDO: Set enum --> 1: Change set point immediately   2: Velocity will change before next set point    3: Velocity will change after next set point

            if (mode == 2)
            {
                var value = ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFFDF;
                value = value & 0xFFDF;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
            else if (mode == 3)
            {
                var value = ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) | 0x0200;
                value = value & 0xFFDF;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
            else
            {
                var value = ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) | 0x0020;                
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
        }

        public void SetRelativMovement(Nlc.DeviceHandle deviceHandle, bool relative)
        {   //ToDo: Enum --> true: relative movement    false: absolute movement

            if (relative)
            {
                var value = ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) | 0x0040;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
            else
            {
                var value = ReadNumber(deviceHandle, new Nlc.OdIndex(0x6040, 0x00)) & 0xFFBF;
                WriteNumber(deviceHandle, value, new Nlc.OdIndex(0x6040, 0x00), 16);
            }
        }

        /// <summary>
        /// Set the operation mode of the device.
        /// </summary>
        /// <param name="deviceHandle">Device handler.</param>
        /// <param name="operationMode">Operation Mode</param>
        public void OperationMode(Nlc.DeviceHandle deviceHandle, OperationModeType operationMode)
        {
            WriteNumber(deviceHandle, (long)operationMode, new Nlc.OdIndex(0x6060, 0x00), 8);
        }
    }
}
