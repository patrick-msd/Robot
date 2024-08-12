using RC.Lib.PowerSupply;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RC.PowerSupply.Nextys.Sample
{
    /// <summary>
    /// Interaction logic for UIControlWindow.xaml
    /// </summary>
    public partial class UIControlWindow : Window
    {
        private Nextys_DcDcConverter _nextys;

        public UIControlWindowModel _model { get; set; }

        private bool _uiLoaded = false;

        public UIControlWindow(Nextys_DcDcConverter tmp)
        {
            InitializeComponent();

            _nextys = tmp;

            this.Title = $"Control DC/DC Converter (???)";
            //this.Title = $"Control DC/DC Converter ({_nextys.po.PortName})";

            _model = new UIControlWindowModel();
            DataContext = _model;

            // Disable Output
            _nextys.OutputDisable();

            // Set range
            _nextys._minOutputVoltage = (int)(4.5 * 1000);
            _nextys._maxOutputVoltage = (int)(24 * 1000);

            _nextys._minOutputCurrent = (int)(2 * 1000);
            _nextys._maxOutputCurrent = (int)(5 * 1000);

            // Set minimum values
            _nextys.SetNominalOutputVoltage((int)(4.5 * 1000));
            _nextys.SetMaximalOutputCurrent((int)(1.0 * 1000));

            // Monitoring event
            _nextys.Monitoring += Monitoring;

            _uiLoaded = true;
        }

        private void winControlWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void winControlWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Disable Output
            _nextys.OutputDisable();

            // Set Output values
            _nextys.SetNominalOutputVoltage((int)(sliNominalOutputVoltage.Value * 1000));
            _nextys.SetMaximalOutputCurrent((int)(sliNominalOutputCurrent.Value * 1000));

            // Disconnect
            _nextys.Disconnect();

            // Set Variables
            bntEnable.Content = "Disable";
        }

        private void bntEnable_Click(object sender, RoutedEventArgs e)
        {
            if (_nextys.GetOutputEnable() == NextysOutputEnable.Disable)
            {
                // enable output
                _nextys.OutputEnable();

                // set output values
                _nextys.SetNominalOutputVoltage((int)(sliNominalOutputVoltage.Value * 1000));
                _nextys.SetMaximalOutputCurrent((int)(sliNominalOutputCurrent.Value * 1000));

                // set variables
                bntEnable.Content = "disable";
            }
            else
            {
                _nextys.OutputDisable();

                bntEnable.Content = "enable";
            }
        }

        private void bntClose_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void sliNominalOutputVoltage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_uiLoaded == true)
            {
                if (_nextys.IsConnected)
                {
                    _nextys.SetNominalOutputVoltage((int)(e.NewValue * 1000));
                }
            }
        }

        private void sliNominalOutputCurrent_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_uiLoaded == true)
            {
                if (_nextys.IsConnected)
                {
                    _nextys.SetMaximalOutputCurrent((int)(e.NewValue * 1000));
                }
            }
        }

        private void cmbOperatingMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_uiLoaded == true)
            {
                if (_nextys.IsConnected)
                {
                    if (cmbOperatingMode.SelectedItem is ComboBoxItem selectedComboBoxItem)
                    {
                        string selectedText = selectedComboBoxItem.Content.ToString();
                        selectedText = selectedText.Replace(" ", "");

                        if (Enum.TryParse(selectedText, out NextysOperationMode selectedMode))
                        {
                            _nextys.SetOperatingMode(selectedMode);
                        }
                    }
                }
            }
        }

        private void cmbCurrentLimitation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_uiLoaded == true)
            {
                if (_nextys.IsConnected)
                {
                    _nextys.SetCurrentLimitation((NextysCurrentLimitation)cmbCurrentLimitation.SelectedIndex);
                }
            }
        }

        private void cmbLockSettings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_uiLoaded == true)
            {
                if (_nextys.IsConnected)
                {
                    if (cmbLockSettings.SelectedItem is ComboBoxItem selectedComboBoxItem)
                    {
                        string selectedText = selectedComboBoxItem.Content.ToString();
                        selectedText = selectedText.Replace(" ", "");

                        if (Enum.TryParse(selectedText, out NextysLockSettings selectedMode))
                        {
                            _nextys.SetLockSettings(selectedMode);
                        }
                    }
                }
            }
        }

        private void Monitoring(RC.Lib.PowerSupply.Nextys_DcDcConverter.MonitoringObject data)
        {
            if (_uiLoaded == true)
            {
                if (_nextys.IsConnected)
                {
                    _model.MaximalOutputCurrent = data.MaximalOutputCurrent;
                    _model.NominalOutputVoltage = data.NominalOutputVoltage;

                    _model.OutputVoltage = data.OutputVoltage;
                    _model.OutputCurrent = data.OutputCurrent;
                    _model.OutputPower = data.OutputPower;

                    _model.InputVoltage = data.InputVoltage;

                    _model.DcOk = data.DcOk;
                    _model.OutputDisabled = data.OutputDisabled;
                    _model.OutputShortCircuit = data.OutputShortCircuit;
                    _model.OutputOverload = data.OutputOverload;
                    _model.UsbPowered = data.UsbPowered;
                    _model.OverTemperatureWarning = data.OverTemperatureWarning;
                    _model.OverTemperatureError = data.OverTemperatureError;
                    _model.OutputOverVoltageError = data.OutputOverVoltageError;
                }
            }
        }
    }
}
