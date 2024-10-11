namespace PSGM.Helper
{
    public class Configuration_Control_RobotElectronicsV1_0_0
    {
        public float MinValue { get; set; } = 0.000f;

        public float MaxValue { get; set; } = 0.000f;

        public float DefaultValue { get; set; } = 0.000f;
    }

    public class Configuration_Motion_NanotecV1_0_0
    {
        public float MinPositionRange { get; set; } = 0.000f;
        public float MaxPositionRange { get; set; } = 0.000f;

        public float DefaultTargetPosition { get; set; } = 0.000f;

        public float MinPositionRangeLimit { get; set; } = 0.000f;
        public float MaxPositionRangeLimit { get; set; } = 0.000f;

        public float MinPositionLimit { get; set; } = 0.000f;
        public float MaxPositionLimit { get; set; } = 0.000f;

        public float HomeOffset { get; set; } = 0.000f;
        public float Polarity { get; set; } = 0.000f;

        public float MotorProfileType { get; set; } = 0.000f;

        public float ProfileVelocity { get; set; } = 0.000f;
        public float ProfileAcceleration { get; set; } = 0.000f;

        public float EndVelocity { get; set; } = 0.000f;

        public float ProfileDeceleration { get; set; } = 0.000f;

        public float QuickStopDeceleration { get; set; } = 0.000f;

        public float MaxAcceleration { get; set; } = 0.000f;
        public float MaxDeceleration { get; set; } = 0.000f;

        public float BeginAccelerationJerk { get; set; } = 0.000f;
        public float BeginDecelerationJerk { get; set; } = 0.000f;

        public float EndAccelerationJerk { get; set; } = 0.000f;
        public float EndDecelerationJerk { get; set; } = 0.000f;

        public float JerkLimit { get; set; } = 0.000f;

        public float PositionWindow { get; set; } = 0.000f;
        public float PositionWindowTime { get; set; } = 0.000f;

        public float FollowingErrorWindow { get; set; } = 0.000f;
        public float FollowingErrorTimeOut { get; set; } = 0.000f;
    }

    public class Configuration_Robot_DoosanV1_0_0
    {
        // ToDo: Accelaration, Decelaration, ...

        public float AnalogOutput1 { get; set; } = 0.000f;
        public float AnalogOutput2 { get; set; } = 0.000f;
        public float AnalogOutput3 { get; set; } = 0.000f;
        public float AnalogOutput4 { get; set; } = 0.000f;
        public float AnalogOutput5 { get; set; } = 0.000f;
        public float AnalogOutput6 { get; set; } = 0.000f;
        public float AnalogOutput7 { get; set; } = 0.000f;
        public float AnalogOutput8 { get; set; } = 0.000f;
        public float AnalogOutput9 { get; set; } = 0.000f;
        public float AnalogOutput10 { get; set; } = 0.000f;
        public float AnalogOutput11 { get; set; } = 0.000f;
        public float AnalogOutput12 { get; set; } = 0.000f;
        public float AnalogOutput13 { get; set; } = 0.000f;
        public float AnalogOutput14 { get; set; } = 0.000f;
        public float AnalogOutput15 { get; set; } = 0.000f;
        public float AnalogOutput16 { get; set; } = 0.000f;

        public float ToolAnalogOutput1 { get; set; } = 0.000f;
        public float ToolAnalogOutput2 { get; set; } = 0.000f;
        public float ToolAnalogOutput3 { get; set; } = 0.000f;
        public float ToolAnalogOutput4 { get; set; } = 0.000f;
        public float ToolAnalogOutput5 { get; set; } = 0.000f;
        public float ToolAnalogOutput6 { get; set; } = 0.000f;
        public float ToolAnalogOutput7 { get; set; } = 0.000f;
        public float ToolAnalogOutput8 { get; set; } = 0.000f;
        public float ToolAnalogOutput9 { get; set; } = 0.000f;
        public float ToolAnalogOutput10 { get; set; } = 0.000f;
        public float ToolAnalogOutput11 { get; set; } = 0.000f;
        public float ToolAnalogOutput12 { get; set; } = 0.000f;
        public float ToolAnalogOutput13 { get; set; } = 0.000f;
        public float ToolAnalogOutput14 { get; set; } = 0.000f;
        public float ToolAnalogOutput15 { get; set; } = 0.000f;
        public float ToolAnalogOutput16 { get; set; } = 0.000f;

        public bool DigitalOutput1 { get; set; } = false;
        public bool DigitalOutput2 { get; set; } = false;
        public bool DigitalOutput3 { get; set; } = false;
        public bool DigitalOutput4 { get; set; } = false;
        public bool DigitalOutput5 { get; set; } = false;
        public bool DigitalOutput6 { get; set; } = false;
        public bool DigitalOutput7 { get; set; } = false;
        public bool DigitalOutput8 { get; set; } = false;
        public bool DigitalOutput9 { get; set; } = false;
        public bool DigitalOutput10 { get; set; } = false;
        public bool DigitalOutput11 { get; set; } = false;
        public bool DigitalOutput12 { get; set; } = false;
        public bool DigitalOutput13 { get; set; } = false;
        public bool DigitalOutput14 { get; set; } = false;
        public bool DigitalOutput15 { get; set; } = false;
        public bool DigitalOutput16 { get; set; } = false;

        public bool ToolDigitalOutput1 { get; set; } = false;
        public bool ToolDigitalOutput2 { get; set; } = false;
        public bool ToolDigitalOutput3 { get; set; } = false;
        public bool ToolDigitalOutput4 { get; set; } = false;
        public bool ToolDigitalOutput5 { get; set; } = false;
        public bool ToolDigitalOutput6 { get; set; } = false;
        public bool ToolDigitalOutput7 { get; set; } = false;
        public bool ToolDigitalOutput8 { get; set; } = false;
        public bool ToolDigitalOutput9 { get; set; } = false;
        public bool ToolDigitalOutput10 { get; set; } = false;
        public bool ToolDigitalOutput11 { get; set; } = false;
        public bool ToolDigitalOutput12 { get; set; } = false;
        public bool ToolDigitalOutput13 { get; set; } = false;
        public bool ToolDigitalOutput14 { get; set; } = false;
        public bool ToolDigitalOutput15 { get; set; } = false;
        public bool ToolDigitalOutput16 { get; set; } = false;

        public List<Configuration_Robot_Doosan_ToolV1_0_0> Tools { get; set; } = new List<Configuration_Robot_Doosan_ToolV1_0_0>();
    }

    public class Configuration_Robot_Doosan_ToolV1_0_0
    {
        public string Name { get; set; } = string.Empty;

        public float CenterPositionX { get; set; } = 0.000f;
        public float CenterPositionY { get; set; } = 0.000f;
        public float CenterPositionZ { get; set; } = 0.000f;
        public float CenterPositionA { get; set; } = 0.000f;
        public float CenterPositionB { get; set; } = 0.000f;
        public float CenterPositionC { get; set; } = 0.000f;

        public float Weight { get; set; } = 0.000f;

        public float CenterOfGravityX { get; set; } = 0.000f;
        public float CenterOfGravityY { get; set; } = 0.000f;
        public float CenterOfGravityZ { get; set; } = 0.000f;

        public float InertialValueX { get; set; } = 0.000f;
        public float InertialValueY { get; set; } = 0.000f;
        public float InertialValueZ { get; set; } = 0.000f;
        public float InertialValueA { get; set; } = 0.000f;
        public float InertialValueB { get; set; } = 0.000f;
        public float InertialValueC { get; set; } = 0.000f;

        public void SetCenterPosition(float[] CenterPositions)
        {
            CenterPositionX = CenterPositions[0];
            CenterPositionY = CenterPositions[1];
            CenterPositionZ = CenterPositions[2];

            CenterPositionA = CenterPositions[3];
            CenterPositionB = CenterPositions[4];
            CenterPositionC = CenterPositions[5];
        }

        public float[] GetCenterPositions()
        {
            return new float[] { CenterPositionX, CenterPositionY, CenterPositionZ, CenterPositionA, CenterPositionB, CenterPositionC };
        }

        public void SetCenterOfGravity(float[] CenterOfGravity)
        {
            CenterOfGravityX = CenterOfGravity[0];
            CenterOfGravityY = CenterOfGravity[1];
            CenterOfGravityZ = CenterOfGravity[2];
        }

        public float[] GetCenterOfGravity()
        {
            return new float[] { CenterOfGravityX, CenterOfGravityY, CenterOfGravityZ };
        }

        public void SetInertialValues(float[] InertialValues)
        {
            InertialValueX = InertialValues[0];
            InertialValueY = InertialValues[1];
            InertialValueZ = InertialValues[2];

            InertialValueA = InertialValues[3];
            InertialValueB = InertialValues[4];
            InertialValueC = InertialValues[5];
        }

        public float[] GetInertialValues()
        {
            return new float[] { InertialValueX, InertialValueY, InertialValueZ, InertialValueA, InertialValueB, InertialValueC };
        }
    }
}
