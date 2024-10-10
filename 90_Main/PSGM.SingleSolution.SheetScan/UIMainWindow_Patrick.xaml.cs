using Emgu.CV;
using Emgu.CV.Structure;
using RC.Lib.Vision.SVSVistek;
using RCRobotDoosanControl;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PSGM.SingleSolution.SheetScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //#region 
            //if (_taskWorker.Status == TaskStatus.Running)
            //{
            //    Serilog.Log.Information("Another thread is already running ...");
            //}
            //else
            //{
            //    _cancellationTokenSourceWorker = new CancellationTokenSource();
            //    _tokenWorker = _cancellationTokenSourceWorker.Token;

            //    _taskWorker = Task.Run(async () =>
            //    {
            //        #region Old Task
            //        string[] allSubDirectoryies;
            //        string[] allFilesInSubDirectory;

            //        string destinationPathNew = string.Empty;
            //        string destinationPathFileNew = string.Empty;
            //        #endregion

            //        //Workflow workflow = new Workflow();

            //        bool[] isGrabbingImagePrevious = new bool[_svsVistek.Cameras.Count];
            //        foreach (var cam in _svsVistek.Cameras)
            //        {
            //            isGrabbingImagePrevious[_svsVistek.Cameras.IndexOf(cam)] = cam.IsGrabbingImage;
            //        }

            //        while (!_tokenWorker.IsCancellationRequested)
            //        {
            //            #region Old Task
            //            allSubDirectoryies = Directory.GetDirectories(_sourcePath);

            //            foreach (string subDirectory in allSubDirectoryies)
            //            {
            //                allFilesInSubDirectory = Directory.GetFiles(subDirectory);

            //                if (allFilesInSubDirectory.Length == 5)
            //                {
            //                    destinationPathNew = _destinationPath + Path.GetFileName(subDirectory);

            //                    if (!Directory.Exists(destinationPathNew))
            //                    {
            //                        Directory.CreateDirectory(destinationPathNew);

            //                        foreach (string file in allFilesInSubDirectory)
            //                        {
            //                            destinationPathFileNew = destinationPathNew + "\\" + Path.GetFileName(file);

            //                            File.Copy(file, destinationPathFileNew);
            //                        }

            //                        Directory.Delete(subDirectory, true);
            //                    }
            //                    else
            //                    {
            //                        //break;
            //                    }
            //                }
            //            }
            //            #endregion

            //            DbStorage_RootDirectory storage = Globals.DbStorageRaw_Context.RootDirectories.Where(p => p.Id == Globals.Machine.DirectoryIdInUse)
            //                                                                                            .Include(p => p.SubDirectories)
            //                                                                                                .ThenInclude(d => d.Files)
            //                                                                                                    .ThenInclude(f => f.QrCode)
            //                                                                                            .Include(p => p.Files)
            //                                                                                                .ThenInclude(f => f.QrCode)
            //                                                                                            .FirstOrDefault();

            //            foreach (SVSVistek_Camera cam in _svsVistek.Cameras)
            //            {
            //                // Change from 0 to 1 detected (Must be detected this way, because the image has not yet been saved)
            //                if (cam.IsGrabbingImage == true && isGrabbingImagePrevious[_svsVistek.Cameras.IndexOf(cam)] == false)
            //                {
            //                    DbStorage_SubDirectory direcorty = new DbStorage_SubDirectory()
            //                    {
            //                        //DirectoryId = Guid.NewGuid(),

            //                        Name = $"Imageset {storage.SubDirectories.Count()}",
            //                        Description = string.Empty,

            //                        RootDirectory = storage,

            //                        //StorageType = StorageType.Inherited,
            //                        //StoragePath = string.Empty,
            //                        //StorageUrl = string.Empty,
            //                        //StorageUrlPublic = string.Empty,



            //                        //ExtUsers = null,
            //                        //ExtUserGroups = null,
            //                        ////ExtDevice = null,
            //                        //ExtJobs = null

            //                        // FK
            //                        Files = null,
            //                        DirectorySize = 0,

            //                    };
            //                    Globals.DbStorageRaw_Context.SubDirectories.Add(direcorty);
            //                    Globals.DbStorageRaw_Context.SaveChanges();

            //                    // Save images to Storage-DataRaw and Database so that the images can be processed later (also from an external Worker)
            //                    foreach (Bitmap image in cam.ImagesRgb)
            //                    {
            //                        DbStorage_File file = new DbStorage_File()
            //                        {
            //                            //FileId = Guid.NewGuid(),

            //                            //Name = $"Image{i}",
            //                            //Description = string.Empty,

            //                            //SubDirectory = storage.First().SubDirectories.FirstOrDefault(),

            //                            //Extension = FileExtension.JPEG,
            //                            //FileSize = 0,

            //                            //StorageType = StorageType.Inherited,
            //                            //StoragePath = string.Empty,
            //                            //StorageUrl = string.Empty,
            //                            //StorageUrlPublic = string.Empty,

            //                            //QrCode = null,

            //                            // FK                    
            //                        };
            //                        Globals.DbStorageRaw_Context.Files.Add(file);
            //                        Globals.DbStorageRaw_Context.SaveChanges();

            //                        //Globals.Storage.S3[].MinioClient.PutObjectAsync("storage-raw", "images/" + folderGuid + "/" + imageGuid + ".jpeg", image.ToStream());


            //                        //Globals.Machine.ProjectInUse = _dbMain_Projects[0].ProjectId;
            //                        //Globals.Machine.OrganizationInUse = _dbMain_Projects[0].Organization.OrganizationId;
            //                        //Globals.Machine.UserInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
            //                        //Globals.Machine.SoftwareInUse = _dbMain_Projects[0].ExtSoftware[0].SoftwareId;
            //                    }






            //                }
            //            }

            //            await Task.Delay(250);
            //        }
            //    }, _tokenWorker);
            //}
            //#endregion





            #region 
            for (int i = 0; i < _taskWorker.Count(); i++)
            {
                if (_taskWorker[i].Status == TaskStatus.Running)
                {
                    Serilog.Log.Information("Another thread is already running ...");
                }
                else
                {
                    _cancellationTokenSourceWorker[i] = new CancellationTokenSource();
                    _tokenWorker[i] = _cancellationTokenSourceWorker[i].Token;

                    Thread.Sleep(25);

                    _taskWorker[i] = Task.Run(() => Worker(i), _tokenWorker[i]);
                }
            }
            #endregion







            #region 
            if (_taskCheck.Status == TaskStatus.Running)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _cancellationTokenSourceCheck = new CancellationTokenSource();
                _tokenCheck = _cancellationTokenSourceCheck.Token;

                _taskCheck = Task.Run(async () =>
                {
                    while (!_tokenCheck.IsCancellationRequested)
                    {
                        float vaccuum = 0.000f;
                        float vaccuumMinimum = 1.050f;

                        if (_sheetControl)
                        {
                            vaccuum = _doosan.Controllers[0].GetAnalogInput(GpioCtrlboxAnalogIndex.GPIO_CTRLBOX_ANALOG_INDEX_1);

                            if (vaccuum > vaccuumMinimum)
                            {
                                Serilog.Log.Error("Lost sheet ...");
                                Serilog.Log.Error($"Break --> vaccuum: {vaccuum}");
                                Serilog.Log.Error("Stop Robot ...");

                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    foreach (var item in _cancellationTokenSourceWorker)
                                    {
                                        item.Cancel();
                                    }
                                    _cancellationTokenSourceMain.Cancel();
                                    _cancellationTokenSourceCheck.Cancel();
                                }));

                                MoveDoublePageSensor(doublePageSensorPositon.In);

                                FansVoltage(5.000f, 5.000f);
                                FansDisable();

                                VaccuumPump(0.000f);

                                VccuumVentil(VaccuumVentil.Open);

                                await Task.Delay(1000);

                                VccuumVentil(VaccuumVentil.Close);
                            }
                        }

                        await Task.Delay(25);
                    }
                }, _tokenCheck);
            }
            #endregion

            #region
            if (_taskMain.Status == TaskStatus.Running)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _cancellationTokenSourceMain = new CancellationTokenSource();
                _tokenMain = _cancellationTokenSourceMain.Token;

                _taskMain = Task.Run(async () =>
                {
                    Serilog.Log.Information("Start Digitization (Patrick) ...");

                    #region Variables ...
                    float[] robotTargetVel = new float[] { 500.000f, 125.000f };
                    float[] robotTargetVelSlow = new float[] { 10.000f, 5.000f };
                    float[] robotTargetVelMed = new float[] { 250.000f, 125.000f };
                    float[] robotTargetVelFast = new float[] { 750.000f, 250.000f };
                    float[] robotTargetAcc = new float[] { 50.000f, 50.000f };
                    float[] robotTargetAccSlow = new float[] { 2.500f, 2.500f };
                    float[] robotTargetAccMed = new float[] { 250.500f, 125.500f };
                    float[] ronotTargetAccFast = new float[] { 500.000f, 250.000f };

                    float robotTargetTime = 0.0f;
                    MoveMode robotMoveMode = MoveMode.MOVE_MODE_ABSOLUTE;
                    MoveReference robotMoveReference = MoveReference.MOVE_REFERENCE_BASE;
                    BlendingSpeedType robotBlendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE;

                    float vaccuum = 0.000f;
                    float[] forces = new float[] { 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f };

                    float vaccuumMinimum = 1.000f;
                    float foreceMaximum = -50.000f;

                    bool errorInput1 = false;
                    bool errorInput2 = false;

                    int cradleLimit = -200000;

                    bool FistStart = false;
                    bool FistStartLeft = false;
                    bool FistStartRight = false;

                    bool IgnoreDoublepageSensor = false;

                    bool cancled = false;

                    string directoryImages = string.Empty;
                    #endregion

                    #region Initialize variables and controls ...
                    Serilog.Log.Debug("Initialize variables and controls ...");

                    _sheet = 1;
                    _sheetError = 0;
                    _sheetErrorSolved = 0;
                    _sheetErrorSolved1 = 0;
                    _sheetErrorSolved2 = 0;
                    _sheetErrorSolved3 = 0;

                    _ignoreDoublepageSensor = false;
                    _preparedPage = false;
                    _replacedPage = false;
                    _scanFinish = false;

                    // Read values from GUI
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        _sheetsToDigitalis = (int)Convert.ToDouble(txtSheetZ_Copy.Text.Replace(".", ","));

                        FistStart = (bool)chkFistStart.IsChecked;
                        FistStartLeft = (bool)chkFistStart_left.IsChecked;
                        FistStartRight = (bool)chkFistStart_right.IsChecked;

                        IgnoreDoublepageSensor = (bool)chkIgnoreDoublepageSensor.IsChecked;
                    }));

                    // Write values top GUI
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        pgbProgress.Minimum = 0;
                        pgbProgress.Maximum = _sheetsToDigitalis;
                        pgbProgress.Value = 0;

                        lblProgress.Content = string.Format("{0} / {1}", _sheet, _sheetsToDigitalis);
                        lblSheetZ_Copy6.Content = "Erros: " + _sheetError + " / Errors solved: " + SheetErrorSolved;
                        lblSheetZ_Copy7.Content = "Time: 0.000s";
                    }));

                    File.WriteAllText(@"C:\WorkDir\OBSStudio\TextFiles\Digitized.txt", string.Format("Sheet {0} --> Erros {1} thereof solved {2}", _sheetsToDigitalis, 0, 0));
                    #endregion

                    #region Initializre hardware ...
                    Serilog.Log.Information("Initialize hardware ...");

                    MoveDoublePageSensorASync(doublePageSensorPositon.In);

                    _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_AUTONOMOUS);

                    // Save hight for the robot
                    _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                    _poseCurrent[2] = _poseCurrent[2] - 50.000f;
                    _doosan.Controllers[0].MoveL(_poseCurrent, robotTargetVel, robotTargetAcc, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);

                    // Start position for the robot
                    _doosan.Controllers[0].MoveL(_poseStartRobot_Horitzontal, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                    await Task.Delay(250);

                    // Enable Output fans
                    FansEnable();

                    // Initialize Motors
                    SetupCradleMotors();
                    SetupDownholderMotors();
                    SetupDoublePageMotor();

                    // Initialize vaccuum ventil
                    VccuumVentil(VaccuumVentil.Close);
                    #endregion

                    Serilog.Log.Debug("Open all downholder ...");
                    MoveDownholderASync(downholderPositon.Open);

                    await Task.Delay(1250);

                    Serilog.Log.Debug("Calculate new height for zero level ...");
                    CalculateHeightForCradle();

                    //if (FistStart)
                    //{
                    //    // ToDo: ...
                    //    Serilog.Log.Error("Overwrite value for the first sheet (Filtzeinlage) ...");
                    //    _cradleRightZeroLevelPosition = -9500;
                    //}

                    Serilog.Log.Debug("Move cradle to start position ...");
                    MoveCradlesASync(_cradleLeftZeroLevelPosition, _cradleRightZeroLevelPosition);

                    await Task.Delay(1250);

                    if (FistStartLeft || FistStartLeft)
                    {
                        Serilog.Log.Debug("Move robot away for taking a picture ...");
                        _pose = new float[] { -300.000f, 6.250f, 600.000f, 0.000f, 90.000f, 180.000f };
                        _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                        _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                        Serilog.Log.Verbose("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);


                        if (FistStartRight && FistStartLeft)
                        {
                            // Camera 0
                            Serilog.Log.Debug("Save Picture - Cam " + _svsVistek.Cameras[0].DeviceInfo.DeviceInfo.serialNumber);

                            //directoryImages = _sourcePath + "\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff");
                            //Directory.CreateDirectory(directoryImages);

                            _svsVistek.Cameras[0].GrabImageHdrAsync(new long[] { 7500, 10000, 15000, 20000, 27500 });

                            // Camera 1
                            Serilog.Log.Debug("Save Picture - Cam " + _svsVistek.Cameras[1].DeviceInfo.DeviceInfo.serialNumber);

                            //directoryImages = _sourcePath + "\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff");
                            //Directory.CreateDirectory(directoryImages);

                            _svsVistek.Cameras[1].GrabImageHdrAsync(new long[] { 7500, 10000, 15000, 20000, 27500 });

                            // Wait for all cameras finished
                            while (_svsVistek.Cameras[0].IsGrabbingImage || _svsVistek.Cameras[1].IsGrabbingImage)
                            {
                                Thread.Sleep(5);
                            }
                        }
                        else if (FistStartRight)
                        {
                            Serilog.Log.Debug("Save Picture - Cam " + _svsVistek.Cameras[0].DeviceInfo.DeviceInfo.serialNumber);

                            //directoryImages = _sourcePath + "\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff");
                            //Directory.CreateDirectory(directoryImages);

                            _svsVistek.Cameras[0].GrabImageHdrAsync(new long[] { 7500, 10000, 15000, 20000, 27500 });

                            // Wait for all cameras finished
                            while (_svsVistek.Cameras[0].IsGrabbingImage)
                            {
                                Thread.Sleep(5);
                            }
                        }
                        else if (FistStartLeft)
                        {
                            Serilog.Log.Debug("Save Picture - Cam " + _svsVistek.Cameras[1].DeviceInfo.DeviceInfo.serialNumber);

                            //directoryImages = _sourcePath + "\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff");
                            //Directory.CreateDirectory(directoryImages);

                            _svsVistek.Cameras[1].GrabImageHdrAsync(new long[] { 7500, 10000, 15000, 20000, 27500 });

                            // Wait for all cameras finished
                            while (_svsVistek.Cameras[1].IsGrabbingImage)
                            {
                                Thread.Sleep(5);
                            }
                        }

                        // ToDo: Waiting time for camera ...
                        //Serilog.Log.Error("Wait for cameras ...");
                        //await Task.Delay(5000);

                        //// Write values to GUI
                        //if (FistStartRight)
                        //{
                        //    _imageRight = _svsVistek.Cameras[0].Image.ToImage<Bgr, byte>();

                        //    this.Dispatcher.Invoke((Action)(() =>
                        //    {
                        //        imgImage_Copy.Source = ToBitmapSource(_imageRight);
                        //    }));
                        //}

                        //if (FistStartLeft)
                        //{
                        //    _imageLeft = _svsVistek.Cameras[1].Image.ToImage<Bgr, byte>();

                        //    _imageLeft_GraphicalCode = AnalyseImage(ref _imageLeft);

                        //    this.Dispatcher.Invoke((Action)(() =>
                        //    {
                        //        imgImage_Copy1.Source = ToBitmapSource(_imageLeft);
                        //    }));
                        //}
                    }

                    Serilog.Log.Debug("Close all downholder ...");
                    MoveDownholderASync(downholderPositon.Close);

                    Serilog.Log.Debug("Reset stop watch ...");
                    _timer.Reset();
                    _timer.Start();

                    while (_sheet <= _sheetsToDigitalis)
                    {

                        if (!_tokenMain.IsCancellationRequested)
                        {
                            //// Check QR-Code of the page
                            //if (_imageLeft_GraphicalCode != null)
                            //{
                            //    if (_imageLeft_GraphicalCode.Length > 0)
                            //    {
                            //        this.Dispatcher.Invoke((Action)(() =>
                            //        {
                            //            txtSheetZ_Copy3.Text = _imageLeft_GraphicalCode[0].DecodedInfo;
                            //        }));

                            //        // Reset variables
                            //        _ignoreDoublepageSensor = false;
                            //        _preparedPage = false;
                            //        _replacedPage = false;
                            //        _scanFinish = false;

                            //        AnalyseQrCode(_imageLeft_GraphicalCode[0].DecodedInfo);
                            //    }
                            //}

                            Serilog.Log.Debug("Cradle safety check (height) ...");
                            if (_cradleLeftZeroLevelPosition < cradleLimit || _cradleRightZeroLevelPosition < cradleLimit)
                            {
                                Serilog.Log.Error("Zero Level reaches the Limit!!!");

                                Serilog.Log.Error("Zero Level Left: " + _cradleLeftZeroLevelPosition);
                                Serilog.Log.Error("Zero Level Right: " + _cradleRightZeroLevelPosition);

                                MoveDownholderASync(downholderPositon.Open);

                                await Task.Delay(5000);

                                Serilog.Log.Information("Check height again ...");
                                CalculateHeightForCradle();

                                await Task.Delay(1000);

                                MoveDownholderASync(downholderPositon.Close);
                            }
                            else if (_valuesDepthStandardDeviation[8] > _valuesDepthStandardDeviationMax || _valuesDepthStandardDeviation[9] > _valuesDepthStandardDeviationMax && !FistStart)
                            {
                                Serilog.Log.Error("Standard Deviation for hight control too high ...");
                                Serilog.Log.Error($"Left Cradle: {_valuesDepthStandardDeviation[8]} > {_valuesDepthStandardDeviationMax} || Right Cradle: {_valuesDepthStandardDeviation[9]} > {_valuesDepthStandardDeviationMax}");

                                Serilog.Log.Error("Zero Level Left: " + _cradleLeftZeroLevelPosition);
                                Serilog.Log.Error("Zero Level Right: " + _cradleRightZeroLevelPosition);

                                MoveDownholderASync(downholderPositon.Open);

                                await Task.Delay(5000);

                                Serilog.Log.Information("Check height again ...");
                                CalculateHeightForCradle();

                                await Task.Delay(1000);

                                MoveDownholderASync(downholderPositon.Close);
                            }
                            else
                            {
                                Serilog.Log.Debug("Zero Level Left: " + _cradleLeftZeroLevelPosition);
                                Serilog.Log.Debug("Zero Level Right: " + _cradleRightZeroLevelPosition);

                                Serilog.Log.Debug("Move cradle to start position (slightly below the fans so that the sheets can be separated better) ...");
                                MoveCradlesASync(_cradleLeftZeroLevelPosition - _cradleLeftDownToFan, _cradleRightZeroLevelPosition);

                                MoveDownholderASync(downholderPositon.Close);

                                MoveDoublePageSensorASync(doublePageSensorPositon.In);

                                FansEnable();

                                FansVoltage(12.500f, 12.500f);

                                Serilog.Log.Debug("Move robot to start pose (before move down to sheet) ...");
                                _pose = new float[] { _poseDownRobot_Vertical[0], _poseDownRobot_Vertical[1], _poseDownRobot_Vertical[2], _poseDownRobot_Vertical[3], _poseDownRobot_Vertical[4], _poseDownRobot_Vertical[5] };
                                _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                Serilog.Log.Debug("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                VaccuumPump(1.500f);
                                FansVoltage(10.000f, 10.000f);

                                Serilog.Log.Debug("Move robot to start pose (before move down to sheet) ...");
                                _pose[2] = _pose[2] + 15.0000f;
                                _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                Serilog.Log.Debug("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                Serilog.Log.Debug("Move robot slowly down for picking up the sheet ...");
                                _pose[2] += 50.000f;
                                _doosan.Controllers[0].MoveLAsync(_pose, robotTargetVelSlow, robotTargetAccSlow, robotTargetTime, robotMoveMode, robotMoveReference, robotBlendingSpeedType);

                                Serilog.Log.Debug("Move cradle left slightly up, for better picking the sheets with the robot ...");
                                MoveCradleLeftASync((long)((float)_cradleLeftZeroLevelPosition - DistanceToTurns(15.000f)));

                                while (true)
                                {
                                    forces = _doosan.Controllers[0].GetToolForce()._fForce;
                                    vaccuum = _doosan.Controllers[0].GetAnalogInput(GpioCtrlboxAnalogIndex.GPIO_CTRLBOX_ANALOG_INDEX_1);

                                    //Serilog.Log.Verbose($"Force: {forces[0]}, {forces[1]}, {forces[2]}");
                                    //Serilog.Log.Verbose($"Vaccuum: {vaccuum}");

                                    if (forces[2] <= foreceMaximum)
                                    {
                                        Serilog.Log.Debug($"Break --> force: {forces[2]}");
                                        break;
                                    }

                                    if (vaccuum < vaccuumMinimum)
                                    {
                                        Serilog.Log.Debug($"Break --> vaccuum: {vaccuum}");
                                        break;
                                    }

                                    await Task.Delay(25);
                                }

                                Serilog.Log.Debug("Stop robot ...");
                                _doosan.Controllers[0].Stop(StopType.STOP_TYPE_QUICK);
                                Serilog.Log.Information("Preasure ={0:000.000}, Force: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000}", vaccuum, forces[0], forces[1], forces[2], forces[3], forces[4], forces[5]);

                                FansVoltage(7.500f, 7.500f);

                                //Serilog.Log.Debug("Move cradle left slightly down, for better picking the sheets with the robot ...");
                                //MoveCradleLeftASync((long)((float)_cradleLeftZeroLevelPosition - (float)_cradleLeftDownToFan / 1.2500f));

                                MoveDownholderLeftASync(downholderPositon.NearlyClosed);

                                //VaccuumPump(1.250f);

                                Serilog.Log.Debug("Wait for sucking up the sheet ...");
                                await Task.Delay(250);

                                Serilog.Log.Debug("Move robot up for double page check ...");
                                _pose = new float[] { _poseDownRobot_Vertical[0], _poseDownRobot_Vertical[1], _poseDownRobot_Vertical[2], _poseDownRobot_Vertical[3], _poseDownRobot_Vertical[4], _poseDownRobot_Vertical[5] };
                                _pose[2] = _pose[2] - (20.000f * 2.000f) - 5.000f; // 20.000f Abstand von Zettel zum Sensor, 5.000f Abweichung "_poseDownRobot_Vertical" zum Sensor
                                _doosan.Controllers[0].MoveL(_pose, robotTargetVelMed, robotTargetAccMed, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);

                                FansVoltage(4.000f, 4.000f);

                                MoveDoublePageSensor(doublePageSensorPositon.Out);

                                Serilog.Log.Debug("Wait for double page sensor results ...");
                                await Task.Delay(250);

                                Serilog.Log.Debug("Read double page sensor results ...");
                                errorInput1 = _doosan.Controllers[0].GetDigitalInput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1);
                                errorInput2 = _doosan.Controllers[0].GetDigitalInput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_2);
                                Serilog.Log.Verbose($"Double page sensor: Input1 --> {errorInput1}, Input1 --> {errorInput2}");

                                //MoveDoublePageSensorASync(doublePageSensorPositon.In);

                                if (!(IgnoreDoublepageSensor || _ignoreDoublepageSensor || (_preparedPage && errorInput1 == true && errorInput2 == true) || (_preparedPage && errorInput1 == false && errorInput2 == true)))
                                {
                                    if (!(errorInput1 == true && errorInput2 == true))
                                    {
                                        _sheetError++;

                                        MoveDoublePageSensorASync(doublePageSensorPositon.In);

                                        if (errorInput1 == true && errorInput2 == false)
                                        {
                                            Serilog.Log.Error("No sheet ...");
                                        }
                                        else if (errorInput1 == false && errorInput2 == true)
                                        {
                                            Serilog.Log.Error("More than one sheet ...");
                                        }
                                        else if (errorInput1 == false && errorInput2 == false)
                                        {
                                            Serilog.Log.Error("Sheet detection error ...");
                                        }

                                        this.Dispatcher.Invoke((Action)(() => { lblSheetZ_Copy6.Content = "Erros: " + _sheetError + " / Errors solved: " + _sheetErrorSolved; }));

                                        Serilog.Log.Error("Start with another attempt to pickup a sheet ...");
                                        for (int i = 1; i <= 6; i++)
                                        {
                                            // Read values from GUI
                                            this.Dispatcher.Invoke((Action)(() =>
                                            {
                                                IgnoreDoublepageSensor = (bool)chkIgnoreDoublepageSensor.IsChecked;
                                            }));

                                            float fan1Speed = 16.000f;
                                            float fan2Speed = 16.000f;

                                            if (i >= 3)
                                            {
                                                fan1Speed = 20.000f;
                                                fan2Speed = 20.000f;
                                            }

                                            #region Variant 1
                                            Serilog.Log.Debug("Wait for releasing one Sheet ...");
                                            await Task.Delay(2500);

                                            MoveDoublePageSensor(doublePageSensorPositon.Out);

                                            Serilog.Log.Debug("Wait for double page sensor results ...");
                                            await Task.Delay(250);

                                            Serilog.Log.Debug("Read double page sensor results ...");
                                            errorInput1 = _doosan.Controllers[0].GetDigitalInput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1);
                                            errorInput2 = _doosan.Controllers[0].GetDigitalInput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_2);
                                            Serilog.Log.Verbose($"Double page sensor: Input1 --> {errorInput1}, Input1 --> {errorInput2}");

                                            //MoveDoublePageSensorASync(doublePageSensorPositon.In);

                                            if (IgnoreDoublepageSensor)
                                            {
                                                _sheetErrorSolved3++;
                                                this.Dispatcher.Invoke((Action)(() => { lblSheetZ_Copy6.Content = "Erros: " + _sheetError + " / Errors solved: " + SheetErrorSolved; }));

                                                break;
                                            }
                                            else if (errorInput1 == true && errorInput2 == false)
                                            {
                                                Serilog.Log.Error("No sheet ...");
                                            }
                                            else if (errorInput1 == false && errorInput2 == true)
                                            {
                                                Serilog.Log.Error("More than one sheet ...");
                                            }
                                            else if (errorInput1 == false && errorInput2 == false)
                                            {
                                                Serilog.Log.Error("Sheet detection error ...");
                                            }
                                            else
                                            {
                                                _sheetErrorSolved1++;
                                                this.Dispatcher.Invoke((Action)(() => { lblSheetZ_Copy6.Content = "Erros: " + _sheetError + " / Errors solved: " + SheetErrorSolved; }));

                                                break;
                                            }

                                            MoveDoublePageSensorASync(doublePageSensorPositon.In);
                                            #endregion

                                            #region Variant 2
                                            VaccuumPump(0.000f);

                                            MoveDownholderLeftASync(downholderPositon.Open);

                                            Serilog.Log.Debug("Move robot to start pose (before move down to sheet) ...");
                                            _pose = new float[] { _poseDownRobot_Vertical[0], _poseDownRobot_Vertical[1], _poseDownRobot_Vertical[2], _poseDownRobot_Vertical[3], _poseDownRobot_Vertical[4], _poseDownRobot_Vertical[5] };
                                            _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                            _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                            Serilog.Log.Debug("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                            Serilog.Log.Debug("Move robot to start pose (before move down to sheet) ...");
                                            _pose[2] = _pose[2] + 12.5000f;
                                            _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                            _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                            Serilog.Log.Debug("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                            VccuumVentil(VaccuumVentil.Open);

                                            MoveDownholderLeftASync(downholderPositon.Close);

                                            Serilog.Log.Debug("Wait for releasing the sheets ...");
                                            await Task.Delay(2500);
                                            ;
                                            VccuumVentil(VaccuumVentil.Close);

                                            // ############################## Restart Cycle ##############################
                                            FansVoltage(fan1Speed, fan2Speed);

                                            VaccuumPump(1.500f);

                                            Serilog.Log.Debug("Move robot slowly down for picking up the sheet ...");
                                            _pose[2] += 50.000f;
                                            _doosan.Controllers[0].MoveLAsync(_pose, robotTargetVelSlow, robotTargetAccSlow, robotTargetTime, robotMoveMode, robotMoveReference, robotBlendingSpeedType);

                                            Serilog.Log.Debug("Move cradle left slightly up, for better picking the sheets with the robot ...");
                                            MoveCradleLeftASync((long)((float)_cradleLeftZeroLevelPosition - DistanceToTurns(15.000f)));

                                            while (true)
                                            {
                                                forces = _doosan.Controllers[0].GetToolForce()._fForce;
                                                vaccuum = _doosan.Controllers[0].GetAnalogInput(GpioCtrlboxAnalogIndex.GPIO_CTRLBOX_ANALOG_INDEX_1);

                                                //Serilog.Log.Verbose($"Force: {forces[0]}, {forces[1]}, {forces[2]}");
                                                //Serilog.Log.Verbose($"Vaccuum: {vaccuum}");

                                                if (forces[2] <= foreceMaximum)
                                                {
                                                    Serilog.Log.Debug($"Break --> force: {forces[2]}");
                                                    break;
                                                }

                                                if (vaccuum < vaccuumMinimum)
                                                {
                                                    Serilog.Log.Debug($"Break --> vaccuum: {vaccuum}");
                                                    break;
                                                }

                                                await Task.Delay(25);
                                            }

                                            Serilog.Log.Debug("Stop robot ...");
                                            _doosan.Controllers[0].Stop(StopType.STOP_TYPE_QUICK);
                                            Serilog.Log.Information("Preasure ={0:000.000}, Force: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000}", vaccuum, forces[0], forces[1], forces[2], forces[3], forces[4], forces[5]);

                                            FansVoltage(fan1Speed, fan2Speed);

                                            Serilog.Log.Debug("Move cradle left slightly down, for better picking the sheets with the robot ...");
                                            MoveCradleLeftASync((long)((float)_cradleLeftZeroLevelPosition - (float)_cradleLeftDownToFan / 1.500f));

                                            MoveDownholderLeftASync(downholderPositon.NearlyClosed);

                                            VaccuumPump(1.250f);

                                            Serilog.Log.Debug("Wait for sucking up the sheet ...");
                                            await Task.Delay(250);

                                            Serilog.Log.Debug("Move robot up for double page check ...");
                                            _pose = new float[] { _poseDownRobot_Vertical[0], _poseDownRobot_Vertical[1], _poseDownRobot_Vertical[2], _poseDownRobot_Vertical[3], _poseDownRobot_Vertical[4], _poseDownRobot_Vertical[5] };
                                            _pose[2] = _poseDownRobot_Vertical[2] - (20.000f * 2.000f) - 5.000f; // 20.000f Abstand von Zettel zum Sensor, 5.000f Abweichung "_poseDownRobot_Vertical" zum Sensor
                                            _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);

                                            FansVoltage(10.000f, 10.000f);

                                            MoveDoublePageSensor(doublePageSensorPositon.Out);

                                            Serilog.Log.Debug("Wait for double page sensor results ...");
                                            await Task.Delay(250);

                                            Serilog.Log.Debug("Read double page sensor results ...");
                                            errorInput1 = _doosan.Controllers[0].GetDigitalInput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1);
                                            errorInput2 = _doosan.Controllers[0].GetDigitalInput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_2);
                                            Serilog.Log.Verbose($"Double page sensor: Input1 --> {errorInput1}, Input1 --> {errorInput2}");

                                            //MoveDoublePageSensorASync(doublePageSensorPositon.In);

                                            if (IgnoreDoublepageSensor)
                                            {
                                                _sheetErrorSolved3++;
                                                this.Dispatcher.Invoke((Action)(() => { lblSheetZ_Copy6.Content = "Erros: " + _sheetError + " / Errors solved: " + SheetErrorSolved; }));

                                                break;
                                            }
                                            else if (errorInput1 == true && errorInput2 == false)
                                            {
                                                Serilog.Log.Error("No sheet ...");
                                            }
                                            else if (errorInput1 == false && errorInput2 == true)
                                            {
                                                Serilog.Log.Error("More than one sheet ...");
                                            }
                                            else if (errorInput1 == false && errorInput2 == false)
                                            {
                                                Serilog.Log.Error("Sheet detection error ...");
                                            }
                                            else
                                            {
                                                _sheetErrorSolved2++;
                                                this.Dispatcher.Invoke((Action)(() => { lblSheetZ_Copy6.Content = "Erros: " + _sheetError + " / Errors solved: " + SheetErrorSolved; }));

                                                break;
                                            }

                                            MoveDoublePageSensorASync(doublePageSensorPositon.In);
                                            #endregion

                                            if (i >= 6)
                                            {
                                                Serilog.Log.Error("Too many retries ...");
                                                Serilog.Log.Error("Stop Robot ...");

                                                this.Dispatcher.Invoke((Action)(() =>
                                                {
                                                    _cancellationTokenSourceMain.Cancel();
                                                    _cancellationTokenSourceCheck.Cancel();
                                                }));

                                                VccuumVentil(VaccuumVentil.Open);

                                                MoveDoublePageSensor(doublePageSensorPositon.In);

                                                FansVoltage(5.000f, 5.000f);
                                                FansDisable();

                                                VaccuumPump(0.000f);

                                                VccuumVentil(VaccuumVentil.Close);

                                                await Task.Delay(2500);
                                            }
                                        }
                                    }
                                }
                                IgnoreDoublepageSensor = false;

                                // Write values top GUI
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    chkIgnoreDoublepageSensor.IsChecked = IgnoreDoublepageSensor;
                                }));


                                Serilog.Log.Information("Start sheet control ...");
                                _sheetControl = true;

                                FansVoltage(5.000f, 5.000f);

                                FansDisable();

                                Serilog.Log.Debug("Open downholder a little bit...");
                                //_nanotec[0].SetPositionASync(_nanotec[0].MotionController[5].DeviceHandle, (long)downholderPositon.Open);
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[5].DeviceHandle, 125);
                                //_nanotec[0].SetPositionASync(_nanotec[0].MotionController[6].DeviceHandle, (long)downholderPositon.Open);
                                //_nanotec[0].SetPositionASync(_nanotec[0].MotionController[7].DeviceHandle, (long)downholderPositon.Open);
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[6].DeviceHandle, 500);
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[7].DeviceHandle, 950);

                                Serilog.Log.Debug("Move robot to center ...");
                                _pose = new float[] { _poseCenterRobot_Horizontal[0], _poseCenterRobot_Horizontal[1], _poseCenterRobot_Horizontal[2], _poseCenterRobot_Horizontal[3], _poseCenterRobot_Horizontal[4], _poseCenterRobot_Horizontal[5] };
                                _pose[0] = _pose[0] - 25.000f;
                                _pose[0] = _pose[0] - 25.000f;
                                _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                Serilog.Log.Verbose("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                VaccuumPump(1.250f);

                                MoveDoublePageSensorASync(doublePageSensorPositon.In);

                                Serilog.Log.Debug("Close downholder...");
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[7].DeviceHandle, 250);
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[6].DeviceHandle, 950);
                                await Task.Delay(500);
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[7].DeviceHandle, 950);

                                FansLeftVoltage(16.000f);

                                MoveCradleLeftASync(_cradleLeftZeroLevelPosition);

                                Serilog.Log.Debug("Move cradle right slightly down, for better releasing the sheet with the robot ...");
                                MoveCradleRightASync((long)((float)_cradleRightZeroLevelPosition - DistanceToTurns(20.000f)));

                                Serilog.Log.Debug("Move robot to left side, slightly before releasing the sheet ...");
                                //_pose = new float[] { -170.000f, 6.250f, 690.000f, 0.000f, 90.000f, 180.000f };
                                _pose = new float[] { -182.500f, 6.250f, 725.000f, 0.000f, 78.750f, 180.000f };
                                _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                Serilog.Log.Verbose("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);




                                //FansEnable();

                                //FansVoltage(5.000f, 5.000f);

                                //_nextys.DcDcConverters[0].SetNominalOutputVoltage((int)(5.000 * 1000));
                                //_nextys.DcDcConverters[0].OutputEnable();
                                //_nextys.DcDcConverters[0].SetNominalOutputVoltage((int)(10.000 * 1000));




                                Serilog.Log.Debug("Move robot to left side, slightly before releasing the sheet ...");
                                _pose = new float[] { -190.000f - 2.500f, 6.250f, 750.000f, 0.000f, 67.500f, 180.000f };
                                _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                Serilog.Log.Verbose("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                Serilog.Log.Information("Stop sheet control ...");
                                _sheetControl = false;

                                VaccuumPump(0.000f);

                                VccuumVentil(VaccuumVentil.Open);

                                Serilog.Log.Debug("Move cradle right slightly down, for better releasing the sheet with the robot ...");
                                MoveCradleRightASync((long)((float)_cradleRightZeroLevelPosition - DistanceToTurns(30.000f)));

                                Serilog.Log.Debug("Close downholder ...");
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[5].DeviceHandle, (long)downholderPositon.Close);
                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[7].DeviceHandle, (long)downholderPositon.Close);

                                Serilog.Log.Debug("Move robot to left side, for releasing the sheet ...");
                                _pose = new float[] { -400.000f, 6.250f, 750.000f, 0.000f, 22.500f, 180.000f };
                                _doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                Serilog.Log.Verbose("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                Serilog.Log.Debug("Move robot away for placing the sheet in the cradle & taking a picture ...");
                                _pose = new float[] { -300.000f, 6.250f, 600.000f, 0.000f, 90.000f, 180.000f };
                                //_doosan.Controllers[0].MoveL(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, 0, robotBlendingSpeedType);
                                _doosan.Controllers[0].MoveLAsync(_pose, robotTargetVelFast, ronotTargetAccFast, robotTargetTime, robotMoveMode, robotMoveReference, robotBlendingSpeedType);
                                _poseCurrent = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                                Serilog.Log.Verbose("Pose calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", _pose[0], _pose[1], _pose[2], _pose[3], _pose[4], _pose[5], _poseCurrent[0], _poseCurrent[1], _poseCurrent[2], _poseCurrent[3], _poseCurrent[4], _poseCurrent[5]);

                                Serilog.Log.Debug("Open right downholder ...");
                                _nanotec[0].SetPosition(_nanotec[0].MotionController[4].DeviceHandle, 0);

                                VccuumVentil(VaccuumVentil.Close);

                                Serilog.Log.Debug("Close downholder ...");
                                MoveDownholderLeftASync(1000);
                                MoveDownholderRightASync(900);

                                FansEnable();
                                FansVoltage(12.500f, 10.000f);

                                MoveCradlesASync(_cradleLeftZeroLevelPosition - _cradleDownBeforePicture, _cradleRightZeroLevelPosition - _cradleDownBeforePicture);

                                await Task.Delay(2000);

                                FansVoltage(12.500f, 7.500f);

                                MoveCradlesASync(_cradleLeftZeroLevelPosition, _cradleRightZeroLevelPosition);

                                FansVoltage(5.000f, 5.000f);
                                FansDisable();

                                await Task.Delay(1500);

                                MoveDownholderASync(downholderPositon.Open);

                                await Task.Delay(500);

                                if (!_tokenMain.IsCancellationRequested)
                                {
                                    Serilog.Log.Debug("Take picture of both sheet ...");
                                    int camIndex = 0;

                                    foreach (SVSVistek_Camera cam in _svsVistek.Cameras)
                                    {
                                        Serilog.Log.Debug("Save Picture - Cam " + cam.DeviceInfo.DeviceInfo.serialNumber);

                                        //directoryImages = _sourcePath + "\\" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss.ffff");
                                        //Directory.CreateDirectory(directoryImages);

                                        cam.GrabImageHdrAsync(new long[] { 7500, 10000, 15000, 20000, 27500 });

                                        Thread.Sleep(25);

                                        camIndex++;
                                    }

                                    // Wait for all cameras finished
                                    while (_svsVistek.Cameras[0].IsGrabbingImage || _svsVistek.Cameras[1].IsGrabbingImage)
                                    {
                                        Thread.Sleep(5);
                                    }
                                }

                                // ToDo: Waiting time for camera ...
                                //Serilog.Log.Error("Wait for cameras ...");
                                //await Task.Delay(5000);

                                CalculateHeightForCradle();

                                MoveDownholderASync(downholderPositon.Close);

                                //_imageLeft = _svsVistek.Cameras[1].Image.ToImage<Bgr, byte>();
                                //_imageRight = _svsVistek.Cameras[0].Image.ToImage<Bgr, byte>();

                                //_imageLeft_GraphicalCode = AnalyseImage(ref _imageLeft);

                                // Write values top GUI
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    //imgImage_Copy1.Source = ToBitmapSource(_imageLeft);
                                    //imgImage_Copy.Source = ToBitmapSource(_imageRight);

                                    if (_timer.ElapsedMilliseconds > 0)
                                    {
                                        lblSheetZ_Copy7.Content = "Time: " + string.Format("{0:0.###}", (double)(_timer.ElapsedMilliseconds / 1000.000f / _sheet)) + "s";
                                    }

                                    _sheet++;

                                    if (_sheet <= _sheetsToDigitalis)
                                    {
                                        lblProgress.Content = string.Format("{0} / {1}", _sheet, _sheetsToDigitalis);

                                        File.WriteAllText(@"C:\WorkDir\OBSStudio\TextFiles\Digitized.txt", string.Format("Sheet {0} --> Erros {1} thereof solved {2}", _sheet, _sheetError, SheetErrorSolved));
                                        //File.WriteAllText(@"C:\WorkDir\OBSStudio\TextFiles\Digitized.txt", string.Format("Sheet {0} of {1} --> Erros {2} thereof solved {3}", _sheet, _sheets, _sheetError, solved));
                                    }
                                }));

                                // Read values from GUI
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    cancled = (bool)chkCancle.IsChecked;
                                }));

                                if (cancled)
                                {
                                    Serilog.Log.Error("Stop scanning ...");
                                    Serilog.Log.Error("Stop Robot ...");

                                    this.Dispatcher.Invoke((Action)(() =>
                                    {
                                        _cancellationTokenSourceMain.Cancel();
                                        _cancellationTokenSourceCheck.Cancel();
                                    }));

                                    MoveDoublePageSensor(doublePageSensorPositon.In);

                                    FansVoltage(5.000f, 5.000f);
                                    FansDisable();

                                    VaccuumPump(0.000f);

                                    VccuumVentil(VaccuumVentil.Close);

                                    await Task.Delay(2500);
                                }
                                else if (_scanFinish)
                                {
                                    Serilog.Log.Error("Scan finished ...");
                                    Serilog.Log.Error("Stop Robot ...");

                                    this.Dispatcher.Invoke((Action)(() =>
                                    {
                                        _cancellationTokenSourceMain.Cancel();
                                        _cancellationTokenSourceCheck.Cancel();
                                    }));

                                    MoveDoublePageSensor(doublePageSensorPositon.In);

                                    FansVoltage(5.000f, 5.000f);
                                    FansDisable();

                                    VaccuumPump(0.000f);

                                    VccuumVentil(VaccuumVentil.Close);
                                }

                                // Write values to GUI
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    chkCancle.IsChecked = false;
                                }));
                            }
                        }
                        else
                        {
                            Serilog.Log.Error("Thread cancled ...");
                            Serilog.Log.Error("Stop Robot ...");

                            this.Dispatcher.Invoke((Action)(() =>
                            {
                                _cancellationTokenSourceMain.Cancel();
                                _cancellationTokenSourceCheck.Cancel();
                            }));

                            MoveDoublePageSensor(doublePageSensorPositon.In);

                            FansVoltage(5.000f, 5.000f);
                            FansDisable();

                            VaccuumPump(0.000f);

                            VccuumVentil(VaccuumVentil.Open);

                            await Task.Delay(1000);

                            VccuumVentil(VaccuumVentil.Close);

                            _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);

                            Serilog.Log.Information("Robot cancled and finish, ready for new start ...");
                            return;
                        }
                    }

                    _timer.Stop();
                }, _tokenMain);
            }

            System.Drawing.Point ConvertPointFToPonint(System.Drawing.PointF value)
            {
                return new System.Drawing.Point((int)value.X, (int)value.Y);
            }
            #endregion
        }
    }
}
