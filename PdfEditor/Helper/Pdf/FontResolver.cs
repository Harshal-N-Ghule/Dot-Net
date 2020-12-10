using System;
using Common;
using System.IO;
using PdfSharpCore.Fonts;


namespace PdfEditor.Helper.Pdf
{
    public class FontResolver : IFontResolver
    {
        private static readonly string InsightdbNormalFontTTF = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + "\\" + ConstantFont.InsightDBNormalFileName;
        private static readonly string ErasBoldITCFontTTF = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + "\\" + ConstantFont.ErasBoldITCFileName;
        private static readonly string TimesNewRomanTTF = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + "\\" + ConstantFont.TimesNewRomanFileName;

        public string DefaultFontName => InsightdbNormalFontTTF;

        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case ConstantFont.InsightDBNormal:
                    return LoadFontData(InsightdbNormalFontTTF);
                case ConstantFont.ErasBoldITC:
                    return LoadFontData(ErasBoldITCFontTTF);
                case ConstantFont.TimesNewRoman:
                    return LoadFontData(TimesNewRomanTTF);
            }
            return null;
        }

        private byte[] LoadFontData(string resourceName)
        {
            return File.ReadAllBytes(resourceName);
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            var fontName = familyName.ToLower();

            switch (fontName)
            {
                case ConstantFont.InsightDBNormal:
                    return new FontResolverInfo(ConstantFont.InsightDBNormal);
                case ConstantFont.ErasBoldITC:
                    return new FontResolverInfo(ConstantFont.ErasBoldITC);
                case ConstantFont.TimesNewRoman:
                    return new FontResolverInfo(ConstantFont.TimesNewRoman);

            }

            return PlatformFontResolver.ResolveTypeface("Arial", isBold, isItalic);
        }
    }
}

