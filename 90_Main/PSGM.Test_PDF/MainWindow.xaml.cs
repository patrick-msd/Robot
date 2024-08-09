using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Windows;

namespace PSGM.Test_PDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_IgnoreDoublepageSensor(object sender, RoutedEventArgs e)
        {
            Guid guid = Guid.Parse("3ba24363-191e-4b7c-8f29-daab2e30855b");

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.H);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(0, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.DefaultTextStyle(x => x.FontSize(20));

                    //page.Header()
                    //    .Text("Hello PDF!")
                    //    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    //page.Content()
                    //    .Padding(50)
                    //    .Row(row =>
                    //    {
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //        row.ConstantColumn(20);
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //    });

                    page.Content()
                        .AlignMiddle()
                        .AlignCenter()
                        .Column(column =>
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Text("");
                                row.RelativeItem().AlignCenter().Text("");
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                                row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Text("Ignore Doublepage Sensor");
                                row.RelativeItem().AlignCenter().Text("Ignore Doublepage Sensor");
                            });
                        });

                    //page.Footer()
                    //    .AlignCenter()
                    //    .Text(x =>
                    //    {
                    //        x.Span("Page ");
                    //        x.CurrentPageNumber();
                    //    });
                });
            })
            .GeneratePdf(@"C:\WorkDir_RoboticScanner\01_Common\Ignore Doublepage Sensor.pdf");
        }

        private void Button_ReplaceImage(object sender, RoutedEventArgs e)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(0, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.DefaultTextStyle(x => x.FontSize(20));

                    //page.Header()
                    //    .Text("Hello PDF!")
                    //    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    //page.Content()
                    //    .Padding(50)
                    //    .Row(row =>
                    //    {
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //        row.ConstantColumn(20);
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //    });

                    for (int i = 0; i <= 1; i++)
                    {
                        Guid guid = Guid.Parse("3bc23125-141e-3f1c-8af1-da2b1e30855b");

                        QRCodeGenerator qrGenerator = new QRCodeGenerator();                        

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.H);
                        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                        byte[] qrCodeImage = qrCode.GetGraphic(20);

                        page.Content()
                            .AlignMiddle()
                            .AlignCenter()
                            .Column(column =>
                            {
                                column.Item().Row(row =>
                                {
                                    row.RelativeItem().AlignCenter().Text("");
                                    row.RelativeItem().AlignCenter().Text("");
                                });

                                column.Item().Row(row =>
                                {
                                    row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                                    row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                                });

                                column.Item().Row(row =>
                                {
                                    row.RelativeItem().AlignCenter().Text($"Replace Image #{i}");
                                    row.RelativeItem().AlignCenter().Text($"Replace Image #{i}");
                                });
                            });
                    }

                    //page.Footer()
                    //    .AlignCenter()
                    //    .Text(x =>
                    //    {
                    //        x.Span("Page ");
                    //        x.CurrentPageNumber();
                    //    });
                });
            })
            .GeneratePdf(@"C:\WorkDir_RoboticScanner\01_Common\Replace Image #1-50.pdf");
        }

        private void Button_PreparedPage(object sender, RoutedEventArgs e)
        {
            // ToDo: Add to Database ...

            Guid guid = Guid.Parse("3ba21353-121e-4f7c-8fa9-dacb2e35825b");

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.H);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(0, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.DefaultTextStyle(x => x.FontSize(20));

                    //page.Header()
                    //    .Text("Hello PDF!")
                    //    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    //page.Content()
                    //    .Padding(50)
                    //    .Row(row =>
                    //    {
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //        row.ConstantColumn(20);
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //    });

                    page.Content()
                        .AlignMiddle()
                        .AlignCenter()
                        .Column(column =>
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Text("");
                                row.RelativeItem().AlignCenter().Text("");
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                                row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Text("Prepared Page");
                                row.RelativeItem().AlignCenter().Text("Prepared Page");
                            });
                        });

                    //page.Footer()
                    //    .AlignCenter()
                    //    .Text(x =>
                    //    {
                    //        x.Span("Page ");
                    //        x.CurrentPageNumber();
                    //    });
                });
            })
            .GeneratePdf(@"C:\WorkDir_RoboticScanner\01_Common\Prepared Page.pdf");
        }

        private void Button_FinishScan(object sender, RoutedEventArgs e)
        {
            Guid guid = Guid.Parse("3ba23423-127e-4f7c-8da9-dacb2e3af25b");

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.H);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(0, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.DefaultTextStyle(x => x.FontSize(20));

                    //page.Header()
                    //    .Text("Hello PDF!")
                    //    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    //page.Content()
                    //    .Padding(50)
                    //    .Row(row =>
                    //    {
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //        row.ConstantColumn(20);
                    //        row.RelativeColumn().Width(10, Unit.Centimetre).Image(qrCodeImage);
                    //    });

                    page.Content()
                        .AlignMiddle()
                        .AlignCenter()
                        .Column(column =>
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Text("");
                                row.RelativeItem().AlignCenter().Text("");
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                                row.RelativeItem().AlignCenter().Width(12.500f, Unit.Centimetre).Image(qrCodeImage);
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Text("Finish Scan");
                                row.RelativeItem().AlignCenter().Text("Finish Scan");
                            });
                        });

                    //page.Footer()
                    //    .AlignCenter()
                    //    .Text(x =>
                    //    {
                    //        x.Span("Page ");
                    //        x.CurrentPageNumber();
                    //    });
                });
            })
            .GeneratePdf(@"C:\WorkDir_RoboticScanner\01_Common\Finish Scan.pdf");
        }
    }
}