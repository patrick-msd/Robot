using OpenCvSharp;
using OpenCvSharp.Extensions;
using PSGM.Model.DbWorkflow;
using Serilog;
using System.Diagnostics;
using System.Drawing;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Image_Darktable_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            Configuration_DarktableV1_0_0? configuration = null;
            List<Configuration_DarktableV1_0_0> configurations = workflowItemLink.GetDarktableV1_0_0Configuration();

            configuration = configurations.Where(p => p.CameraId == _image_Data.CameraDeviceId).FirstOrDefault();

            if (configuration != null)
            {
                string inputFilePath = $"{_workingPath}/{_image_Data.FileId}.jpeg";
                string outputFilePath = $"{_workingPath}/{_image_Data.FileId}_Darktable.jpg";
                string sidecarFilePath = $"{_workingPath}/sidecar.xmp";

                File.WriteAllText(sidecarFilePath, configuration.DarktableSidecarFile);

                _image_Data.Image.SaveImage(inputFilePath, new ImageEncodingParam(ImwriteFlags.JpegQuality, 100));

                ExecuteCommandDarktable(configuration.DarktableExecutePath, configuration.DarktableExecuteArgumetns, inputFilePath, outputFilePath, sidecarFilePath);

                _image_Data.Image = BitmapConverter.ToMat(new Bitmap(outputFilePath)).CvtColor(ColorConversionCodes.RGBA2RGB);
            }
            else
            {
                Log.Error("Darktable V1.0.0 configuration not found ...");
            }
        }

        private void ExecuteCommandDarktable(string darktableExecutePath, string darktableExecuteArgumetns, string inputFilePath, string outputDirectory, string sidecarFilePath)
        {
            darktableExecuteArgumetns = darktableExecuteArgumetns.Replace("INPUT_FILE_PATH", inputFilePath);
            darktableExecuteArgumetns = darktableExecuteArgumetns.Replace("Output_FILE_PATH", outputDirectory);
            darktableExecuteArgumetns = darktableExecuteArgumetns.Replace("SIDECAR_FILE_PATH", sidecarFilePath);


            Process process = new Process();
            process.StartInfo.FileName = darktableExecutePath;
            process.StartInfo.Arguments = darktableExecuteArgumetns;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            //process.OutputDataReceived += (sender, e) => Debug.WriteLine(e.Data);
            //process.ErrorDataReceived += (sender, e) => Debug.WriteLine(e.Data);

            process.Start();
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();

            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                string outputFilePath = outputDirectory + "ImageDarktable";
                //string outputFilePath = Path.Combine(outputDirectory, Path.GetFileName(inputFilePath));
                //File.Copy(inputFilePath, outputFilePath, true);
                //Console.WriteLine("File copied to: " + outputFilePath);
            }
            else
            {
                Log.Error("Darktable command execution failed.");
            }
        }
    }
}
