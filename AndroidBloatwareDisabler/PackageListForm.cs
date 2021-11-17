using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidBloatwareDisabler
{
    public partial class PackageListForm : Form
    {
        public PackageListForm()
        {
            InitializeComponent();
        }

        public PackageListForm(IEnumerable<PackageInformation> disabling, IEnumerable<PackageInformation> enabling)
            : this()
        {

            foreach (var pi in disabling)
            {
                lv_disablingPackages.Items.Add(new ListViewItem(pi.PackageName)
                {
                    Tag = pi,
                    Checked = true,
                    ForeColor = pi.IsSystemPackage ? Color.Red : SystemColors.ControlText,
                    BackColor = pi.Enabled ? SystemColors.ControlLightLight : SystemColors.ControlDark
                });
            }
            foreach (var pi in enabling)
            {
                lv_enablingPackages.Items.Add(new ListViewItem(pi.PackageName)
                {
                    Tag = pi,
                    Checked = true,
                    ForeColor = pi.IsSystemPackage ? Color.Red : SystemColors.ControlText,
                    BackColor = pi.Enabled ? SystemColors.ControlLightLight : SystemColors.ControlDark
                });
            }
        }

        public IEnumerable<PackageInformation> DisablingPackages
        {
            get
            {
                var list = new List<PackageInformation>();

                foreach (var obj in lv_disablingPackages.Items)
                {
                    var lvi = obj as ListViewItem;
                    
                    if (lvi.Checked)
                    {
                        list.Add(lvi.Tag as PackageInformation);
                    }
                }

                return list;
            }
        }
        public IEnumerable<PackageInformation> EnablingPackages
        {
            get
            {
                var list = new List<PackageInformation>();

                foreach (var obj in lv_enablingPackages.Items)
                {
                    var lvi = obj as ListViewItem;

                    if (lvi.Checked)
                    {
                        list.Add(lvi.Tag as PackageInformation);
                    }
                }

                return list;
            }
        }
    }
}
