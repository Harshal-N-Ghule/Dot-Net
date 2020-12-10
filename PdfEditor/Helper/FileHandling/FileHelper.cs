using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PdfEditor.Helper.FileHandling
{
    public class FileHelper
    {
        public static void CreateNewFile(byte[] data, string path)
        {
            using (FileStream fs = File.Create(path))
            {
                fs.Write(data, 0, data.Length);
            }
        }
    }
}
