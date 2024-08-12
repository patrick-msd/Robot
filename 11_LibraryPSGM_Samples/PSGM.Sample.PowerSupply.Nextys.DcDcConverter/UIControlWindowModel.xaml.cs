using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RC.PowerSupply.Nextys.Sample
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public class UIControlWindowModel : INotifyPropertyChanged
    {
        private ushort _modusAddress = 0;
        public ushort ModusAddress
        {
            get { return _modusAddress; }
            set
            {
                _modusAddress = value;
                OnPropertyChanged();
            }
        }

        private double _outputVoltage = 0;
        public double OutputVoltage
        {
            get { return _outputVoltage; }
            set
            {
                _outputVoltage = value;
                OnPropertyChanged();
            }
        }

        private double _nominalOutputVoltage = 0;
        public double NominalOutputVoltage
        {
            get { return _nominalOutputVoltage; }
            set
            {
                _nominalOutputVoltage = value;
                OnPropertyChanged();
            }
        }

        private double _outputCurrent = 0;
        public double OutputCurrent
        {
            get { return _outputCurrent; }
            set
            {
                _outputCurrent = value;
                OnPropertyChanged();
            }
        }

        private double _maximalOutputCurrent = 0;
        public double MaximalOutputCurrent
        {
            get { return _maximalOutputCurrent; }
            set
            {
                _maximalOutputCurrent = value;
                OnPropertyChanged();
            }
        }

        private double _outputPower = 0;
        public double OutputPower
        {
            get { return _outputPower; }
            set
            {
                _outputPower = value;
                OnPropertyChanged();
            }
        }

        private double _inputVoltage = 0;
        public double InputVoltage
        {
            get { return _inputVoltage; }
            set
            {
                _inputVoltage = value;
                OnPropertyChanged();
            }
        }

        private bool _dcOk = false;
        public bool DcOk
        {
            get { return _dcOk; }
            set
            {
                _dcOk = value;
                OnPropertyChanged();
            }
        }


        private bool _outputdisable = true;
        public bool OutputDisabled
        {
            get { return _outputdisable; }
            set
            {
                _outputdisable = value;
                OnPropertyChanged();
            }
        }

        private bool _outputShortCircuit = false;
        public bool OutputShortCircuit
        {
            get { return _outputShortCircuit; }
            set
            {
                _outputShortCircuit = value;
                OnPropertyChanged();
            }
        }

        private bool _outputOverload = false;
        public bool OutputOverload
        {
            get { return _outputOverload; }
            set
            {
                _outputOverload = value;
                OnPropertyChanged();
            }
        }

        private bool _usbPowered = false;
        public bool UsbPowered
        {
            get { return _usbPowered; }
            set
            {
                _usbPowered = value;
                OnPropertyChanged();
            }
        }

        private bool _overTemperatureWarning = false;
        public bool OverTemperatureWarning
        {
            get { return _overTemperatureWarning; }
            set
            {
                _overTemperatureWarning = value;
                OnPropertyChanged();
            }
        }

        private bool _overTemperatureError = false;
        public bool OverTemperatureError
        {
            get { return _overTemperatureError; }
            set
            {
                _overTemperatureError = value;
                OnPropertyChanged();
            }
        }

        private bool _outputOverVoltageError = false;
        public bool OutputOverVoltageError
        {
            get { return _outputOverVoltageError; }
            set
            {
                _outputOverVoltageError = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
