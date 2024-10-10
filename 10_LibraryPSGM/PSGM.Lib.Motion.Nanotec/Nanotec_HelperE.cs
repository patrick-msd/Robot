namespace PSGM.Lib.Motion
{
    //public partial class Nanotec
    //{
        public enum NanotecOdIndex : ushort
        {
            ModesOfOperation = 0x6060,
            ModesOfOperationDisplay = 0x6061,
            ModesOfOperationSelect = 0x6062,
            ModesOfOperationSet = 0x6063,
            HomingOffset = 0x607B,
            HomeOffset = 0x607C,
            Polarity = 0x607E,       

            ProfileVelocity = 0x6081,
            EndVelocity = 0x6082,
            ProfileAcceleration = 0x6083,
            ProfileDeceleration = 0x6084,
            QuickstopDeceleration = 0x6085,
            MaximumDeceleration = 0x60C6,
            MaximumAcceleration = 0x60C5,
            PositionLimit = 0x607D,
            TargetPosition = 0x607A,
            PositionActualValue = 0x6064,
            HomingMethod = 0x6098,
            HomingSpeed = 0x6099,
            HomingAcceleration = 0x609A,
            HomingOnBlockConfiguration = 0x203A,
            Controlword = 0x6040,
            Statusword = 0x6041,
            HomingStatus = 0x606C,
            HomingSwitchStatus = 0x2060,
            HomingZeroSpeed = 0x6091,
            HomingAccelerationSwitchSpeed = 0x6092,
            HomingSwitchSpeed = 0x6093,
            HomingZeroSpeedSwitchDistance = 0x6094,
            HomingSwitchDistance = 0x6095,
            HomingMethodSelect = 0x6096,
            HomingDirection = 0x6097,
            HomingSpeedSwitchDistance = 0x609B,
            HomingAccelerationSwitchDistance = 0x609C,
            HomingCurrentThreshold = 0x609D,
            HomingSpeedThreshold = 0x609E,
            HomingSwitchSpeedThreshold = 0x609F,
            HomingSwitchSpeedThresholdWindow = 0x60A0,
            TargetVelocity = 0x60FF,
            VelocityActualValue = 0x606C,
            TorqueActualValue = 0x6077,
            BeginAccelerationJerk = 0x60C2,
            BeginDecelerationJerk = 0x60C3,
            EndAccelerationJerk = 0x60C4,
            EndDecelerationJerk = 0x60C7,
            VelocityWindow = 0x606D,
            VelocityWindowTime = 0x606E,
            MotionProfileType = 0x6086,
            MotorDriveSubmodeSelect = 0x3202,
            TargetTorque = 0x6071,
            MaximumTorque = 0x6072,
            NominalCurrent = 0x2031,
            TorqueSlope = 0x6087,
            MaxMotorSpeed = 0x6080,
        }

        // https://de.nanotec.com/produkte/manual/PD2C_CANopen_DE/object_dictionary%2Fod_motion_0x6060.html
        public enum OperationModeType : long
        {
            AutoSetup = -2,
            StepDirection = -1,
            NoModeChange = 0,
            ProfilePosition = 1,
            VelocityMode = 2,
            ProfileVelocity = 3,
            ProfileTorque = 4,
            Reserved = 5,
            Homing = 6,
            InterpolatedPosition = 7,
            CyclicSynchronousPosition = 8,
            CyclicSynchronousVelocity = 9,
            CyclicSynchronousTorque = 10
        }

        public enum HomingModes : int
        {
            BlockNegative = -17,
            BlockPositive = -18,
            CurrentPosition = 35,
            SwitchNegative = 17,
            SwitchPositive = 18,
            NextEncoderIndexToLeft = 33,
            EncoderIndexAfterHittingSwitchNegative = 01,
            EncoderIndexAfterHittingSwitchPositive = 02,
            EncoderIndexAfterHittingBlockNegative = -1,
            EncoderIndexAfterHittingBlockPositive = -2
        }
    //}
}
