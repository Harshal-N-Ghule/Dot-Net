using System;
using Common;
using System.IO;
using PdfEditor.Type;
using PdfEditor.Common;
using PdfEditor.Helper.FileHandling;

namespace PdfEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdfDocPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + Constants.pdfPath;
            var newPdfDocPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + Constants.newPdfPath;

            var text = "Hello World";

            var param = new PdfEditingParam
            {
                font = ConstantFont.InsightDBNormal,
                fontSize = 36,
                coordinateX = 353,
                coordinateY = 150,
                red = 11,
                green = 70,
                blue = 174
            };
            var data = PdfEditor.Helper.Pdf.PdfEditor.EditPdf(pdfDocPath, text, param);
            FileHelper.CreateNewFile(data , newPdfDocPath);
        }


        
    }
}
