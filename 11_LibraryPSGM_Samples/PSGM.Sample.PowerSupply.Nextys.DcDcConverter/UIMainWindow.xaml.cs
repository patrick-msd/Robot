using Microsoft.EntityFrameworkCore;
using PSGM.Model.DbMachine;
using RC.Lib.PowerSupply;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows;

namespace RC.PowerSupply.Nextys.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        private Nextys_Container? _nextys;

        public UIMainWindow()
        {
            InitializeComponent();

            Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            Log.Information("Start main window ...");
        }

        private void winUIMainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            #region Inizialize variables ...
            _nextys = Globals.Machine.PowerSupply.Nextys;
            #endregion

            if (_nextys.DcDcConverters.Count > 0)
            {
                foreach (Lib.PowerSupply.Nextys_DcDcConverter device in _nextys.DcDcConverters)
                {
                    //UIControlWindow subWindow = new UIControlWindow(1);
                    //subWindow.Owner = this;
                    //subWindow.Show();
                }
            }
        }

        private void winUIMainWindows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region Close power supply devices
            Log.Information("Power Supply: Close devices and clean up variabels ...");

            try
            {
                if (_nextys.DcDcConverters.Count > 0)
                {
                    foreach (Lib.PowerSupply.Nextys_DcDcConverter device in _nextys.DcDcConverters)
                    {
                        device.Disconnect();
                    }

                    _nextys.DcDcConverters.Clear();
                    _nextys = null;
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
            string portName = cmbSerialPort.Text;

            List<DbMachine_Device> serialDevice = Globals.DbMachine_Context.Devices.Where(p => p.Interfaces_Serial.PortName == portName)
                                                                                    .Include(i => i.Interfaces_Serial)
                                                                                    .ToList();

            Nextys_DcDcConverter tmp;

            if (serialDevice.Count == 1)
            {
                Log.Debug($"Open device with portname \"{portName}\".");

                tmp = _nextys.DcDcConverters.Where(p => p.IdDb == serialDevice[0].Interfaces_Serial.Id).First();

                tmp.Connect();
            }
            else
            {
                Log.Warning($"To many ot no device with portname \"{portName}\" found. Try to initials a new device!");

                Log.Debug($"Open device with portname \"{portName}\".");
                _nextys.DcDcConverters.Add(new Nextys_DcDcConverter(cmbSerialPort.Text.ToString(), int.Parse(txtBaudRate.Text), (Parity)Enum.Parse(typeof(Parity), cmbParity.Text), (StopBits)Enum.Parse(typeof(StopBits), cmbStopBit.Text), (Handshake)Enum.Parse(typeof(Handshake), cmbHandshake.Text), int.Parse(txtReadTimeout.Text), int.Parse(txtWriteTimeout.Text), 3, int.Parse(txtMonitoring.Text)));
                tmp = _nextys.DcDcConverters.Last();

                tmp.Connect();
            }

            if (tmp.IsConnected)
            {
                UIControlWindow subWindow = new UIControlWindow(tmp);
                subWindow.Owner = this;
                subWindow.Show();
            }
            else
            {
                Log.Error($"Device with portname \"{portName}\" not conencted!");
            }
        }
    }
}
