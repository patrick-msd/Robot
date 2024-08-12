namespace RC.Lib.Motion
{
    public partial class Nanotec_Container
    {
        #region Homing
        /// <summary>
        /// Set the homing mode of the device.
        /// Purpose of the homing method is to align the position zero point of the controller with an encoder index or position switch.
        /// </summary>
        /// <param name="deviceHandle">Device handle.r</param>
        /// <param name="homingMode">Method to be used for referencing.</param>
        /// <param name="HomeOffset">Specifies the difference between the zero position of the controller and the reference point of the machine in user-defined units.</param>
        /// <param name="homingSpeedSwitch">Speed for the search of the switch.</param>
        /// <param name="homingSpeedZero">Speed for the search of the index.</param>
        /// <param name="homingMaxSpeed">Maximum speed for homing.</param>
        /// <param name="homingAcceleration">Starting acceleration and braking deceleration for homing.</param>
        /// <param name="homingMinCurrent">Minimum current threshold which, if exceeded, is to detect the blocking of the motor at a block.</param>
        /// <param name="homingBlockTime">Specifies the time in ms that the motor is to continue to run against the block after block detection.</param>
        public void SetupHoming(Nlc.DeviceHandle deviceHandle, int homingMode, int HomeOffset, int homingSpeedSwitch, int homingSpeedZero, int homingMaxSpeed, int homingAcceleration, int homingMinCurrent, int homingBlockTime)
        {
            // Set operation mode to Homing
            OperationMode(deviceHandle, OperationModeType.Homing);

            // Homing Method, please refer to the manual to select the method, fitting your applicaiotn
            WriteNumber(deviceHandle, homingMode, new Nlc.OdIndex((ushort)NanotecOdIndex.HomingMethod, 0x00), 8);

            // Specifies the difference between the zero position of the controller and the reference point of the machine in user-defined units.
            WriteNumber(deviceHandle, HomeOffset, new Nlc.OdIndex((ushort)NanotecOdIndex.HomeOffset, 0x00), 32);

            // Speed for the search of the switch
            WriteNumber(deviceHandle, homingSpeedSwitch, new Nlc.OdIndex((ushort)NanotecOdIndex.HomingSpeed, 0x01), 32);

            // Speed for the search of the index
            WriteNumber(deviceHandle, homingSpeedZero, new Nlc.OdIndex((ushort)NanotecOdIndex.HomingSpeed, 0x02), 32);

            // Maximum speed
            WriteNumber(deviceHandle, homingMaxSpeed, new Nlc.OdIndex((ushort)NanotecOdIndex.MaxMotorSpeed, 0x00), 32);

            // Starting acceleration and braking deceleration for homing
            WriteNumber(deviceHandle, homingAcceleration, new Nlc.OdIndex((ushort)NanotecOdIndex.HomingAcceleration, 0x00), 32);

            // Homing On Block Configuration: Minimum Current for Block Detection (only for Homing on Block)
            WriteNumber(deviceHandle, homingMinCurrent, new Nlc.OdIndex((ushort)NanotecOdIndex.HomingOnBlockConfiguration, 0x01), 32);

            // Homing On Block Configuration: Block Detection Time (only for Homing on Block)
            WriteNumber(deviceHandle, homingBlockTime, new Nlc.OdIndex((ushort)NanotecOdIndex.HomingOnBlockConfiguration, 0x02), 32);
        }

        public void StartHoming(Nlc.DeviceHandle deviceHandle)
        {
            // Start the Homing with a positive direction
            WriteNumber(deviceHandle, +1, new Nlc.OdIndex((ushort)NanotecOdIndex.Controlword, 0x00), 16);

            // Switch to Operation Enabled
            EnableOperation(deviceHandle);

            // Start the Homing
            NewSetPoint(deviceHandle, true);

            // Wait while homing is not complete (Bit 10 and Bit 12 are not set yet)
            while (!TargetReached(deviceHandle) & !NewSetPointAcknowledge(deviceHandle))
            {
                Thread.Sleep(1);
            }

            // Switch to Operation Disabled
            NewSetPoint(deviceHandle, false);

            // Switch to Operation Disabled
            Shutdown(deviceHandle);
        }

        public void StartHomingASync(Nlc.DeviceHandle deviceHandle)
        {
            // Start the Homing with a positive direction
            WriteNumber(deviceHandle, +1, new Nlc.OdIndex((ushort)NanotecOdIndex.Controlword, 0x00), 16);

            // Switch to Operation Enabled
            EnableOperation(deviceHandle);

            // Start the Homing
            NewSetPoint(deviceHandle, true);

            //// Wait while homing is not complete (Bit 10 and Bit 12 are not set yet)
            //while (!TargetReached(deviceHandle) & !NewSetPointAcknowledge(deviceHandle))
            //{
            //    Thread.Sleep(1);
            //}

            //// Switch to Operation Disabled
            //NewSetPoint(deviceHandle, false);

            //// Switch to Operation Disabled
            //Shutdown(deviceHandle);
        }

        #endregion

        #region "Positioning"
        public void SetupRangePositioning(Nlc.DeviceHandle deviceHandle, bool relative, int move, int minPosRange, int maxPosRange, int minPos, int maxPos, int homeOffset, int polarityInverted)
        {
            // Set the Mode to Profile Position
            OperationMode(deviceHandle, OperationModeType.ProfilePosition);
           
            // Switch to Operation Enabled
            EnableOperation(deviceHandle);

            // Set to absolute movement

            SetRelativMovement(deviceHandle, relative);

            ChangeSetPointMode(deviceHandle, move);

            //if (maxPosRange >= minPosRange)
            //{
            // Set the min position range limit
            WriteNumber(deviceHandle, minPosRange, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionLimit, 0x01), 32);

            // Set the max position range limit
            WriteNumber(deviceHandle, maxPosRange, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionLimit, 0x02), 32);
            //}

            //if (maxPos >= minPos)
            //{
            // Set the min position limit
            WriteNumber(deviceHandle, minPos, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionLimit, 0x01), 32);

            // Set the max position limit
            WriteNumber(deviceHandle, maxPos, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionLimit, 0x02), 32);
            //}

            // Set the home offset
            WriteNumber(deviceHandle, homeOffset, new Nlc.OdIndex((ushort)NanotecOdIndex.HomeOffset, 0x00), 32);

            // Set the polarity
            WriteNumber(deviceHandle, polarityInverted, new Nlc.OdIndex((ushort)NanotecOdIndex.Polarity, 0x00), 8);
        }

        public void SetAccelVelocityPositioning(Nlc.DeviceHandle deviceHandle, int jerk, int profileVelocity, int endVelocity, int profileAccel, int profileDecel, int quickStopDecel, int maxDecel, int maxAccel)
        {
            // ToDo: Enum ...
            //Motion profile type
            WriteNumber(deviceHandle, jerk, new Nlc.OdIndex((ushort)NanotecOdIndex.MotionProfileType, 0x00), 16);

            // Maximum speed
            WriteNumber(deviceHandle, profileVelocity, new Nlc.OdIndex((ushort)NanotecOdIndex.MaxMotorSpeed, 0x00), 32);

            // Set Profile Velocity
            WriteNumber(deviceHandle, profileVelocity, new Nlc.OdIndex((ushort)NanotecOdIndex.ProfileVelocity, 0x00), 32);

            // Set End Velocity
            WriteNumber(deviceHandle, endVelocity, new Nlc.OdIndex((ushort)NanotecOdIndex.EndVelocity, 0x00), 32);

            // Set Profile Acceleration
            WriteNumber(deviceHandle, profileAccel, new Nlc.OdIndex((ushort)NanotecOdIndex.ProfileAcceleration, 0x00), 32);

            // Set Profile Deceleration
            WriteNumber(deviceHandle, profileDecel, new Nlc.OdIndex((ushort)NanotecOdIndex.ProfileDeceleration, 0x00), 32);

            // Set the profile for Quickstop Deceleration
            WriteNumber(deviceHandle, quickStopDecel, new Nlc.OdIndex((ushort)NanotecOdIndex.QuickstopDeceleration, 0x00), 32);

            // Set the profile for Maximum Deceleration
            WriteNumber(deviceHandle, maxDecel, new Nlc.OdIndex((ushort)NanotecOdIndex.MaximumDeceleration, 0x00), 32);

            // Set the profile for Maximum Acceleration
            WriteNumber(deviceHandle, maxAccel, new Nlc.OdIndex((ushort)NanotecOdIndex.MaximumAcceleration, 0x00), 32);
        }

        public long SetPositionSync(Nlc.DeviceHandle deviceHandle, int targetPosition)
        {
            //Set the target position
            WriteNumber(deviceHandle, targetPosition, new Nlc.OdIndex((ushort)NanotecOdIndex.TargetPosition, 0x00), 32);

            // Switch to Operation Enabled
            NewSetPointTrigger(deviceHandle);

            while (!TargetReached(deviceHandle) & !NewSetPointAcknowledge(deviceHandle))
            {
                Thread.Sleep(1);
            }

            return ReadNumber(deviceHandle, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionActualValue, 0x00));
        }

        public long SetPosition(Nlc.DeviceHandle deviceHandle, long targetPosition)
        {
            // Set the target position
            WriteNumber(deviceHandle, targetPosition, new Nlc.OdIndex((ushort)NanotecOdIndex.TargetPosition, 0x00), 32);

            // Switch to Operation Enabled
            NewSetPointTrigger(deviceHandle);

            while (!TargetReached(deviceHandle) & !NewSetPointAcknowledge(deviceHandle))
            {
                Thread.Sleep(1);
            }

            return ReadNumber(deviceHandle, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionActualValue, 0x00));
        }

        public void SetPositionASync(Nlc.DeviceHandle deviceHandle, long targetPosition)
        {
            // Set the target position
            WriteNumber(deviceHandle, targetPosition, new Nlc.OdIndex((ushort)NanotecOdIndex.TargetPosition, 0x00), 32);

            // Switch to Operation Enabled
            NewSetPointTrigger(deviceHandle);

            //while (!TargetReached(deviceHandle) & !NewSetPointAcknowledge(deviceHandle))
            //{
            //    Thread.Sleep(1);
            //}

            //return ReadNumber(deviceHandle, new Nlc.OdIndex((ushort)MotionBusController.NanotecOdIndex.PositionActualValue, 0x00));
        }

        public void SetPositionRobotASyncccc(Nlc.DeviceHandle deviceHandle, int targetPosition)
        {
            long positionActualValue = ReadNumber(deviceHandle, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionActualValue, 0x00));

            // Set the target position
            WriteNumber(deviceHandle, positionActualValue + targetPosition, new Nlc.OdIndex((ushort)NanotecOdIndex.TargetPosition, 0x00), 32);

            // Switch to Operation Enabled
            NewSetPointTrigger(deviceHandle);

            //while (!TargetReached(deviceHandle) & !NewSetPointAcknowledge(deviceHandle))
            //{
            //    Thread.Sleep(1);
            //}

            //return ReadNumber(deviceHandle, new Nlc.OdIndex((ushort)MotionBusController.NanotecOdIndex.PositionActualValue, 0x00));
        }
        #endregion




        public long GetPosition(Nlc.DeviceHandle deviceHandle)
        {
            return ReadNumber(deviceHandle, new Nlc.OdIndex((ushort)NanotecOdIndex.PositionActualValue, 0x00));
        }




        #region "Velocity"
        public void SetupVelocity(Nlc.DeviceHandle deviceHandle, int jerk, int velProfileAccel, int maxAccel, int velProfileDecel, int quickStopDecel, int maxDecel, int velWindow, int velwindowTime, int velPolarityInverted, int positionBased)
        {
            // Set the Mode to Profile Velocity
            OperationMode(deviceHandle, OperationModeType.ProfileVelocity);

            //Motion profile type
            WriteNumber(deviceHandle, jerk, new Nlc.OdIndex((ushort)NanotecOdIndex.MotionProfileType, 0x00), 16);

            //Velocity Profile Acceleration
            WriteNumber(deviceHandle, velProfileAccel, new Nlc.OdIndex((ushort)NanotecOdIndex.ProfileAcceleration, 0x00), 32);

            //Set Maximum Acceleration
            WriteNumber(deviceHandle, maxAccel, new Nlc.OdIndex((ushort)NanotecOdIndex.MaximumAcceleration, 0x00), 32);

            //Set Profile Deceleration
            WriteNumber(deviceHandle, velProfileDecel, new Nlc.OdIndex((ushort)NanotecOdIndex.ProfileDeceleration, 0x00), 32);

            //Set Quickstop Deceleration
            WriteNumber(deviceHandle, quickStopDecel, new Nlc.OdIndex((ushort)NanotecOdIndex.QuickstopDeceleration, 0x00), 32);

            //Set Maximum Deceleration
            WriteNumber(deviceHandle, maxDecel, new Nlc.OdIndex((ushort)NanotecOdIndex.MaximumDeceleration, 0x00), 32);

            //Set Velocity Window
            WriteNumber(deviceHandle, velWindow, new Nlc.OdIndex((ushort)NanotecOdIndex.VelocityWindow, 0x00), 16);

            //Set Velocity Window Time
            WriteNumber(deviceHandle, velwindowTime, new Nlc.OdIndex((ushort)NanotecOdIndex.VelocityWindowTime, 0x00), 16);

            //Set the polarity
            WriteNumber(deviceHandle, velPolarityInverted, new Nlc.OdIndex((ushort)NanotecOdIndex.Polarity, 0x00), 8);

            // Set the ramp type
            WriteNumber(deviceHandle, positionBased, new Nlc.OdIndex((ushort)NanotecOdIndex.MotorDriveSubmodeSelect, 0x00), 32);
        }

        public void SetVelocity(Nlc.DeviceHandle deviceHandle, int targetVelocity)
        {
            //Set the target velocity
            WriteNumber(deviceHandle, targetVelocity, new Nlc.OdIndex((ushort)NanotecOdIndex.TargetVelocity, 0x00), 32);

            // Switch to Operation Enabled
            EnableOperation(deviceHandle);
        }
        #endregion

        #region "Torque"
        public void SetupTorque(Nlc.DeviceHandle deviceHandle, int maxTorque, int nominalCurrent, int torqueSlope, int torqueMode)
        {
            // Set the Mode to Profile Torque
            OperationMode(deviceHandle, OperationModeType.ProfileTorque);

            //Set the maximum torque
            WriteNumber(deviceHandle, maxTorque, new Nlc.OdIndex((ushort)NanotecOdIndex.MaximumTorque, 0x00), 16);

            //Set nominal current
            WriteNumber(deviceHandle, nominalCurrent, new Nlc.OdIndex((ushort)NanotecOdIndex.NominalCurrent, 0x00), 32);

            // Set torque slope
            WriteNumber(deviceHandle, torqueSlope, new Nlc.OdIndex((ushort)NanotecOdIndex.TorqueSlope, 0x00), 32);

            //Set Motor drive submode select
            WriteNumber(deviceHandle, torqueMode, new Nlc.OdIndex((ushort)NanotecOdIndex.MotorDriveSubmodeSelect, 0x00), 32);
        }

        public void SetTorque(Nlc.DeviceHandle deviceHandle, int targetTorque)
        {
            //Set the target torque
            WriteNumber(deviceHandle, targetTorque, new Nlc.OdIndex((ushort)NanotecOdIndex.TargetTorque, 0x00), 16);

            // Switch to Operation Enabled
            EnableOperation(deviceHandle);
        }
        #endregion
    }
}
