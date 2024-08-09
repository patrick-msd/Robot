using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;
using System.Windows;

namespace RC.DynamicScripting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel model;

        public class Globals
        {
            public int NumberOfStudents;
            public int StudentsPerClass;
        }
        public class ParmModel
        {
            public string Name { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();

            model = new ViewModel(syntaxEdit1);
            this.DataContext = model;
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {

            //int sum = await CSharpScript.EvaluateAsync<int>("1 + 2");
            //double result1 = CSharpScript.EvaluateAsync<double>("System.Math.Pow(2,3)").GetAwaiter().GetResult();





            //var result = await CSharpScript.EvaluateAsync("5 + 5");
            //Debug.WriteLine(result); // 10

            //result = await CSharpScript.EvaluateAsync(@"""sample""");
            //Debug.WriteLine(result); // sample

            //result = await CSharpScript.EvaluateAsync(@"""sample"" + "" string""");
            //Debug.WriteLine(result); // sample string

            //result = await CSharpScript.EvaluateAsync("int x = 5; int y = 5; x"); //Note the last x is not contained in a proper statement
            //Debug.WriteLine(result); // 5







            //var globals = new Globals { NumberOfStudents = 80, StudentsPerClass = 15 };

            //double result2 = 0;
            //CSharpScript.EvaluateAsync<double>("NumberOfStudents/StudentsPerClass", globals: globals).ContinueWith(s => result2 = s.Result).Wait();

            ////Assert.AreEqual(globals.NumberOfStudents / globals.StudentsPerClass, result2);







            //string methodCode = @"string helloString =  $@""Hello {Name}, from Roslyn with CSharpScripting."";";
            //var model = new ParmModel { Name = "Rick" };

            //var opt = ScriptOptions.Default;
            //opt.AddReferences(typeof(string).Assembly, typeof(ParmModel).Assembly);
            //opt.AddImports("System");


            //var state = CSharpScript.RunAsync(methodCode, opt, model, model.GetType()).Result;

            //string result5 = state.Variables.FirstOrDefault(v => v.Name == "helloString")?.Value as string;

            //Debug.WriteLine(result5);




            var result6 = await CSharpScript.EvaluateAsync(syntaxEdit1.Text);
            Debug.WriteLine(result6); // 10
            ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}