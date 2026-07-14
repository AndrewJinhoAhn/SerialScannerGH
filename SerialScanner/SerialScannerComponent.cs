using System;
using System.Collections.Generic;
using System.Management;
using System.Text.RegularExpressions;
using Grasshopper.Kernel;

namespace SerialScanner
{
    public class SerialScannerComponent : GH_Component
    {
        public SerialScannerComponent()
          : base("Serial Device Scanner", "SerialScan",
                 "Lists serial (COM) devices connected to this PC with their friendly names.",
                 "Appendage", "Device")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Refresh", "R", "Refresh device list. Use button instead of toggle.", GH_ParamAccess.item, true);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Port", "P", "COM port name.", GH_ParamAccess.list);
            pManager.AddTextParameter("Name", "N", "Device friendly name.", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool refresh = true;
            DA.GetData(0, ref refresh);

            var ports = new List<string>();
            var names = new List<string>();

            try
            {
                //get list of COM ports and their friendly names using WMI
                using (var searcher = new ManagementObjectSearcher(
                    "SELECT Name FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"))
                {
                    foreach (ManagementObject o in searcher.Get())
                    {
                        string name = o["Name"]?.ToString();
                        
                        if (string.IsNullOrEmpty(name)) continue;
                        var m = Regex.Match(name, @"\((COM\d+)\)");
                        if (!m.Success) continue;
                        ports.Add(m.Groups[1].Value);
                        names.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Scan failed: " + ex.Message);
                return;
            }

            if (ports.Count == 0)
                AddRuntimeMessage(GH_RuntimeMessageLevel.Remark, "No COM devices found.");

            DA.SetDataList(0, ports);
            DA.SetDataList(1, names);
        }

        public override GH_Exposure Exposure => GH_Exposure.primary;
        protected override System.Drawing.Bitmap Icon => IconLoader.Get("PortScan.png");
        public override Guid ComponentGuid => new Guid("b7e2c9a4-1d38-4f60-a5c2-9e0b3d7f6a18");
    }
}