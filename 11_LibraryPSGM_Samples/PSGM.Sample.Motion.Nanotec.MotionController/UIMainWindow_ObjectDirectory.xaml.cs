using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;

namespace RC.Motion.Nanotec.Sample
{
    /// <summary>
    /// Interaction logic for UIMainWindow_ObjectDirectory.xaml
    /// </summary>
    public partial class UIMainWindow_ObjectDirectory : Window
    {
        private List<RC.Lib.Motion.Nanotec_Container>? _nanotec;
        private Thread _thread;
        public ObservableCollection<DataGridItem> Items { get; set; }

        public class DataGridItem
        {
            public string Description { get; set; }
            public string Index { get; set; }
            public string SubIndex { get; set; }
            public string Access { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
            public string DecimalValue { get; set; }
            public string BinaryValue { get; set; }
            public string Category { get; set; }
        }

        public UIMainWindow_ObjectDirectory(List<RC.Lib.Motion.Nanotec_Container>? nanotec, Thread thread)
        {
            InitializeComponent();

            _nanotec = nanotec;
            _thread = thread;

            Items = new ObservableCollection<DataGridItem>();
            ObjectDict.DataContext = Items;

            int motionControllerId = 0;

            //_nanotec[0].DeviceConnect(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

            Nlc.ObjectDictionary objectDictionary = (Nlc.ObjectDictionary)_nanotec[0].GetDeviceObjectDictionary(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

            for (ushort index = 0; index < ushort.MaxValue; index++)
            {
                var result = objectDictionary.getObjectEntry(index);
                if (!result.hasError())
                {
                    var entry = result.getResult();
                    var dataGridItem = new DataGridItem
                    {
                        Description = "",
                        Index = entry.getIndex().ToString("X4"),
                        SubIndex = entry.getMaxSubIndex().ToString("X2"),
                        Access = "",
                        Type = entry.getDataType().ToString(),
                        Value = "",
                        DecimalValue = "",
                        BinaryValue = "",
                        Category = ""
                    };
                    Items.Add(dataGridItem);
                }
            }
            //_nanotec[0].DeviceDisconnect(nanotec[0].MotionController[motionControllerId].DeviceHandle);
        }
    }
}
