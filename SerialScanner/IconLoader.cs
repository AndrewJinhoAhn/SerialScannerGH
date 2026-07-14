using System.Drawing;
using System.Reflection;

namespace SerialScanner
{
    internal static class IconLoader
    {
        public static Bitmap Get(string fileName) 
        {
            var asm = Assembly.GetExecutingAssembly();
            using (var s = asm.GetManifestResourceStream("SerialScanner.Resources." + fileName))
                return s == null ? null : new Bitmap(s);
        }
    }
}