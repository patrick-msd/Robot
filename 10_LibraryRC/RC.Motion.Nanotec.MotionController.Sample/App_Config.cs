using RC.Model;
using Serilog;
using System.Collections.Generic;

namespace RC.Motion.Nanotec.Sample
{
    public partial class App_Config
    {
        public static void AppConfiCreate()
        {
            Log.Information("Add \"Motion Controllers and Communicattion Device\" to database ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "Motion Controller",
                ApplicationDeviceLocation = "Machine",

                DeviceName = "Details see CAN Device ...",
                DeviceDescription = "Details see CAN Device ...",
                DeviceType = DeviceTypes.Motion,
                DeviceManufacturer = DeviceManufacturers.Nanotec,
                DeviceSerialnumber = "Details see CAN Device ...",

                InterfaceName = "USB-to-CAN Converter",
                InterfaceDescription = "USB-to-CAN V2 - Compact",
                InterfaceManufacturer = InterfaceManufacturers.IXXAT,
                InterfaceSerialnumber = "HW630322",

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = new Interface_Can()
                {
                    CanDevices = new List<Interface_CanDevice>()
                        {
                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 1,

                                DeviceName ="Cradle Right - 1",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 4,

                                DeviceName ="Cradle Right - 2",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 2,

                                DeviceName ="Cradle Left - 1",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 3,

                                DeviceName ="Cradle Left - 2",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 11,

                                DeviceName ="Downholder Right - 1",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 12,

                                DeviceName ="Downholder Right - 2",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 13,

                                DeviceName ="Downholder Left - 1",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 14,

                                DeviceName ="Downholder Left - 2",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },

                            new Interface_CanDevice()
                            {
                                Id = new System.Guid(),

                                CanDeviceId = 21,

                                DeviceName ="Doble Page Check",
                                DeviceDescription="",
                                DeviceType = DeviceTypes.Motion,
                                DeviceManufacturer =  DeviceManufacturers.Nanotec,
                                DeviceSerialnumber=""
                            },
                        }
                },
                Interfaces_Ethernet = null,
                Interfaces_Serial = null
            });
        }
    }
}
