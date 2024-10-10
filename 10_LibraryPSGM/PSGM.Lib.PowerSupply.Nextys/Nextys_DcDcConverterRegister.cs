namespace PSGM.Lib.PowerSupply
{
    public enum NextysModbusRegister : int
    {
        // Settings
        ModbusAddress = 0x100,                      // Modbus address
        NominalOutputVoltage = 0x1010,              // Nominal Output Voltage [V]
        MaximalOutputCurrent = 0x1011,              // Maximal Output Current [A]
        OperatingMode = 0x1012,                     // Operating mode (§3.1) --> 1. Single, 2.Paralell
        CurrentLimitation = 0x1013,                 // Current limitation (§3.2) --> 1. Hiccup, 2. Constant current
        OutputEnable = 0x1014,                      // Output enable --> 0. Disable, 1. Enable
        LockSettings = 0x1015,                      // Lock settings --> 0. Disable, 1. Enable

        // Metering
        OutputVoltage = 0x2000,                     // Output voltage [V]
        OutputCurrent = 0x2001,                     // Output current [C]
        OutputPower = 0x2002,                       // Output Power [W]
        InputVoltage = 0x2003,                      // InputVoltage

        // State
        DcOk = 0x4000,                              // DC OK
        OutputDisable = 0x4001,                     // Output disabled
        OutputShortCircuit = 0x4002,                // Output short circuit
        OutputOverload = 0x4003,                    // Output overload
        UsbPowered = 0x4004,                        // USB powered
        OverTemperatureWarning = 0x4005,            // Over temperature warning
        OverTemperatureError = 0x4006,              // Over temperature error
        OutputOverVoltageError = 0x4007             // Output over voltage error
    }
}
