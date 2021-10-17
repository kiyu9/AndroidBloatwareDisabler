using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBloatwareDisabler
{
    public class PackageInformation
    {
        public string PackageName { get; }
        public bool Enabled { get; }

        public bool Checked { get; set; }

        public bool IsSystemPackage { get; }

        public bool CheckedChanged => Enabled != Checked;

        public PackageInformation(string packageName, bool enabled, bool @checked, bool isSystemPackage)
        {
            PackageName = packageName;
            Enabled = enabled;
            Checked = @checked;
            IsSystemPackage = isSystemPackage;
        }
    }
}
