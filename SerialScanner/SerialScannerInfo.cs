using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace SerialScanner
{
    public class SerialScannerInfo : GH_AssemblyInfo
    {
        public override string Name => "SerialScanner";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("314e337d-0409-43e3-9c39-a1980b79ad0f");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";

        //Return a string representing the version.  This returns the same version as the assembly.
        public override string AssemblyVersion => GetType().Assembly.GetName().Version.ToString();
    }
}