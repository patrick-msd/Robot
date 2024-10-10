namespace PSGM.Helper
{
    public class Configuration_Control_RobotElectronicsV1_0_0
    {
        public float MinValue { get; set; } = 0.000f;

        public float MaxValue { get; set; } = 0.000f;

        public float DefaultValue { get; set; } = 0.000f;
    }

    public class Configuration_Motor_NanotecV1_0_0
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

        public float FlangeAnalogOutput1 { get; set; } = 0.000f;
        public float FlangeAnalogOutput2 { get; set; } = 0.000f;
        public float FlangeAnalogOutput3 { get; set; } = 0.000f;
        public float FlangeAnalogOutput4 { get; set; } = 0.000f;
        public float FlangeAnalogOutput5 { get; set; } = 0.000f;
        public float FlangeAnalogOutput6 { get; set; } = 0.000f;
        public float FlangeAnalogOutput7 { get; set; } = 0.000f;
        public float FlangeAnalogOutput8 { get; set; } = 0.000f;
        public float FlangeAnalogOutput9 { get; set; } = 0.000f;
        public float FlangeAnalogOutput10 { get; set; } = 0.000f;
        public float FlangeAnalogOutput11 { get; set; } = 0.000f;
        public float FlangeAnalogOutput12 { get; set; } = 0.000f;
        public float FlangeAnalogOutput13 { get; set; } = 0.000f;
        public float FlangeAnalogOutput14 { get; set; } = 0.000f;
        public float FlangeAnalogOutput15 { get; set; } = 0.000f;
        public float FlangeAnalogOutput16 { get; set; } = 0.000f;

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

        public bool FlangeDigitalOutput1 { get; set; } = false;
        public bool FlangeDigitalOutput2 { get; set; } = false;
        public bool FlangeDigitalOutput3 { get; set; } = false;
        public bool FlangeDigitalOutput4 { get; set; } = false;
        public bool FlangeDigitalOutput5 { get; set; } = false;
        public bool FlangeDigitalOutput6 { get; set; } = false;
        public bool FlangeDigitalOutput7 { get; set; } = false;
        public bool FlangeDigitalOutput8 { get; set; } = false;
        public bool FlangeDigitalOutput9 { get; set; } = false;
        public bool FlangeDigitalOutput10 { get; set; } = false;
        public bool FlangeDigitalOutput11 { get; set; } = false;
        public bool FlangeDigitalOutput12 { get; set; } = false;
        public bool FlangeDigitalOutput13 { get; set; } = false;
        public bool FlangeDigitalOutput14 { get; set; } = false;
        public bool FlangeDigitalOutput15 { get; set; } = false;
        public bool FlangeDigitalOutput16 { get; set; } = false;

        List<Configuration_Robot_Doosan_EndEffectorV1_0_0> EndEffectors { get; set; } = new List<Configuration_Robot_Doosan_EndEffectorV1_0_0>();
    }

    public class Configuration_Robot_Doosan_EndEffectorV1_0_0
    {
        public string Name { get; set; } = string.Empty;

        public float CenterPositionX = 0.000f;
        public float CenterPositionY = 0.000f;
        public float CenterPositionZ = 0.000f;
        public float CenterPositionA = 0.000f;
        public float CenterPositionB = 0.000f;
        public float CenterPositionC = 0.000f;

        float Weight = 0.000f;

        public float CenterOfGravityX = 0.000f;
        public float CenterOfGravityY = 0.000f;
        public float CenterOfGravityZ = 0.000f;

        public float InertiaValueX = 0.000f;
        public float InertiaValueY = 0.000f;
        public float InertiaValueZ = 0.000f;
        public float InertiaValueA = 0.000f;
        public float InertiaValueB = 0.000f;
        public float InertiaValueC = 0.000f;
    }
}
