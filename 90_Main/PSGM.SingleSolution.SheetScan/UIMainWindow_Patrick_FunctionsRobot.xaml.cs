using RCRobotDoosanControl;
using System.Windows;

namespace PSGM.SingleSolution.SheetScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        void VaccuumPump(float voltage)
        {
            Serilog.Log.Verbose("Set vaccuum pump voltage to {0:0.000} ...", voltage);
            _doosan.Controllers[0].SetAnalogOutput(GpioCtrlboxAnalogIndex.GPIO_CTRLBOX_ANALOG_INDEX_1, voltage);
        }

        public enum VaccuumVentil : byte
        {
            Open = 0x01,
            Close = 0x00
        }

        void VccuumVentil(VaccuumVentil value)
        {
            if (value == VaccuumVentil.Open)
            {
                Serilog.Log.Verbose("Open vaccuum ventil ...");
                _robotElectronics.Controllers[1].SetRelay(RC.Lib.Control.RobotElectronics.Relay.Relay1, true, 0);
            }
            else
            {
                Serilog.Log.Verbose("Close vaccuum ventil ...");
                _robotElectronics.Controllers[1].SetRelay(RC.Lib.Control.RobotElectronics.Relay.Relay1, false, 0);
            }
        }
    }
}
