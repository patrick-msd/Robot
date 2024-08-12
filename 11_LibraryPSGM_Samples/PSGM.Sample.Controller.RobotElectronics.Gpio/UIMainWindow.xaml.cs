using RC.Lib.Control.RobotElectronics;
using Serilog;
using System;
using System.Windows;

namespace RC.Control.RobotElectronics.Sample
{
    /// <summary>
    /// Interaction logic for UIMainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        #region Global variables
        private RobotElectronics_Container? _robotElectronics;
        #endregion

        public UIMainWindow()
        {
            InitializeComponent();

            Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            Log.Information("Start main window ...");
        }

        private void winUIMainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            #region Inizialize variables ...
            _robotElectronics = Globals.Machine.Control.RobotElectronics;
            #endregion
        }

        private void winUIMainWindows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region Close control devices
            Log.Information("Cotnrol: Close devices and clean up variabels ...");

            try
            {
                if (_robotElectronics != null)
                {
                    for (int i = 0; i < _robotElectronics.Controllers.Count; i++)
                    {
                        _robotElectronics.Controllers[i].Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _robotElectronics.Controllers[0].Connect();
            _robotElectronics.Controllers[1].Connect();

            _robotElectronics.Controllers[0].SetRelay(Relay.Relay1, true);
            _robotElectronics.Controllers[1].SetRelay(Relay.Relay1, true);

            ;

            _robotElectronics.Controllers[0].SetRelay(Relay.Relay1, false);
            _robotElectronics.Controllers[1].SetRelay(Relay.Relay1, false);

            _robotElectronics.Controllers[0].Disconnect();
            _robotElectronics.Controllers[1].Disconnect();
        }
    }
}
