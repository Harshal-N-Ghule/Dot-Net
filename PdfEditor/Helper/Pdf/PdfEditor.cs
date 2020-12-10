using System.IO;
using PdfEditor.Type;
using PdfSharpCore.Pdf;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Drawing;


namespace PdfEditor.Helper.Pdf
{
    public class PdfEditor
    {
        static PdfEditor()
        {
            GlobalFontSettings.FontResolver = new FontResolver();
        }
        
        public static byte[] EditPdf(string existingDocumentPath, string text, PdfEditingParam param)
        {
            int firstPage = 0;
            var newDocument = new PdfDocument();
            PdfDocument existingDocument = PdfReader.Open(existingDocumentPath, PdfDocumentOpenMode.Import);

            var page = newDocument.AddPage(existingDocument.Pages[firstPage]);
            var gfx = XGraphics.FromPdfPage(page);
            var brush = new XSolidBrush(XColor.FromArgb(param.red, param.green, param.blue));

            var Font = new XFont(param.font, param.fontSize, XFontStyle.Bold, XPdfFontOptions.UnicodeDefault);

            gfx.DrawString(text, Font, brush, param.coordinateX, param.coordinateY, XStringFormats.Center);

            byte[] certificatePdf = null;
            using (MemoryStream stream = new MemoryStream())
            {
                newDocument.Save(stream);
                certificatePdf = stream.ToArray();
            }

            return certificatePdf;
        }
    }
}
