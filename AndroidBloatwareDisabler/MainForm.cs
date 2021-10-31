﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidBloatwareDisabler
{
    public partial class MainForm : Form
    {
        private const string PATH_DIR_ADB = @".\platform-tools";

        private readonly object mLocker = new();

        private readonly List<PackageInformation> mPackages = new();

        private enum FilterType
        {
            AllPackages,
            SystemPackages,
            ThirdpartyPackages,
            EnabledPackages,
            DisabledPackages,
            CheckedPackages,
            UncheckedPackages
        }

        public MainForm()
        {
            InitializeComponent();

            var tsmis = new[]
            {
                new { Tsmi = tsmi_dumpAllPackages, Filter = FilterType.AllPackages },
                new { Tsmi = tsmi_dumpSystemPackages, Filter = FilterType.SystemPackages },
                new { Tsmi = tsmi_dumpThirdpartyPackages, Filter = FilterType.ThirdpartyPackages },
                new { Tsmi = tsmi_dumpEnabledPackages, Filter = FilterType.EnabledPackages },
                new { Tsmi = tsmi_dumpDisabledPackages, Filter = FilterType.DisabledPackages },
                new { Tsmi = tsmi_dumpCheckedPackages, Filter = FilterType.CheckedPackages },
                new { Tsmi = tsmi_dumpUncheckedPackages, Filter = FilterType.UncheckedPackages }
            };
            foreach (var item in tsmis)
            {
                item.Tsmi.Tag = item.Filter;
                item.Tsmi.Click += Tsmi_DumpClick;
            }


            lv_devices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lv_deviceInformations.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lv_packages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            var cobitems = new[] {
                new { Display = Properties.Resources.AllPackages, Value = FilterType.AllPackages },
                new { Display = Properties.Resources.SystemPackages, Value = FilterType.SystemPackages },
                new { Display = Properties.Resources.ThirdpartyPackages, Value = FilterType.ThirdpartyPackages },
                new { Display = Properties.Resources.EnabledPackages, Value = FilterType.EnabledPackages },
                new { Display = Properties.Resources.DisabledPackages, Value = FilterType.DisabledPackages },
                new { Display = Properties.Resources.CheckedPackages, Value = FilterType.CheckedPackages },
                new { Display = Properties.Resources.UncheckedPackages, Value = FilterType.UncheckedPackages }
            };
            cob_filter.DisplayMember = "Display";
            cob_filter.ValueMember = "Value";
            cob_filter.DataSource = cobitems;
            cob_filter.SelectedIndex = 0;

            var g = cob_filter.CreateGraphics();
            var maxWidth = 0;
            foreach (var item in cobitems)
            {
                maxWidth = (int)Math.Max(maxWidth, g.MeasureString(item.Display, cob_filter.Font).Width);
            }
            cob_filter.DropDownWidth = maxWidth + 10;

            splitContainer2.Panel2Collapsed = true;
        }

        private void Tsmi_DumpClick(object sender, EventArgs e)
        {
            if ((sender is not ToolStripMenuItem tsmi)
                || (tsmi.Tag is not FilterType filterType)
                || (mPackages.Count < 1)
                )
            {
                return;
            }

            using var sfd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                FileName = "",
                Filter = $"{Properties.Resources.PackageNameOnly} (*.txt)|*.txt"
            };
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                goto EXIT;
            }

            var isLocked = false;
            try
            {
                Monitor.TryEnter(mLocker, ref isLocked);

                if (isLocked)
                {
                    var targets = filterType switch
                    {
                        FilterType.SystemPackages => mPackages.Where(pi => pi.IsSystemPackage),
                        FilterType.ThirdpartyPackages => mPackages.Where(pi => !pi.IsSystemPackage),
                        FilterType.EnabledPackages => mPackages.Where(pi => pi.Enabled),
                        FilterType.DisabledPackages => mPackages.Where(pi => !pi.Enabled),
                        FilterType.CheckedPackages => mPackages.Where(pi => pi.Checked),
                        FilterType.UncheckedPackages => mPackages.Where(pi => !pi.Checked),
                        _ => mPackages
                    };

                    if (targets.Count() > 0)
                    {
                        var result = sfd.FilterIndex switch
                        {
                            1 => DumpPackageNames(targets, sfd.FileName),
                            _ => -1
                        };

                        tssl_status.Text = (result >= 0) ? string.Format(Properties.Resources.PackagesDumped, result, DateTime.Now.ToString("HH:mm:ss.fff")) : string.Format(Properties.Resources.ThereIsNoPackageThatCanBeDump, DateTime.Now.ToString("HH:mm:ss.fff"));
                    }
                }
            }
            finally
            {
                if (isLocked)
                {
                    Monitor.Exit(mLocker);
                }
            }

        EXIT:
            sfd.Dispose();

            int DumpPackageNames(IEnumerable<PackageInformation> packages, string filePath)
            {
                using var sw = new StreamWriter(filePath, false, Encoding.UTF8);
                var written = 0;
                var totalCount = (double)packages.Count();

                tspb_progress.Value = 0;
                try
                {
                    foreach (var pkg in packages)
                    {
                        sw.WriteLine(pkg.PackageName);
                        written++;

                        tspb_progress.Value = (int)(written / totalCount + 0.5d);
                    }
                }
                catch
                {
                    if (written == 0)
                    {
                        written = -1;
                    }
                }
                finally
                {
                    sw.Close();
                }

                if (written == totalCount)
                {
                    tspb_progress.Value = 100;
                }

                return written;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _ = UpdateDeviceList();
        }

        private void Lv_devices_SelectedIndexChanged(object sender, EventArgs e)
        {
            lv_deviceInformations.Items.Clear();
            lv_packages.Items.Clear();

            if ((lv_devices.Items.Count < 1)
                || (!(lv_devices.Items[0].Tag is DeviceInformation di))
                )
            {
                return;
            }

            lv_deviceInformations.Items.Add(new ListViewItem(new[] { Properties.Resources.ListItem_Name, di.Name }));
            lv_deviceInformations.Items.Add(new ListViewItem(new[] { Properties.Resources.ListItem_Model, di.Model }));
            lv_deviceInformations.Items.Add(new ListViewItem(new[] { Properties.Resources.ListItem_Device, di.Device }));

            _ = UpdatePackageList(di.ID);
        }

        private void Tssl_scanDevices_Click(object sender, EventArgs e)
        {
            _ = UpdateDeviceList();
        }

        private void Cob_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPackageList();
        }

        private void Lv_packages_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var pkgInfo = e.Item.Tag as PackageInformation;

            pkgInfo.Checked = e.Item.Checked;

            var selectedFilter = (FilterType)(int)cob_filter.SelectedValue;
            
            if (((selectedFilter == FilterType.CheckedPackages) && (!e.Item.Checked))
                || ((selectedFilter == FilterType.UncheckedPackages) && e.Item.Checked)
                )
            {
                lv_packages.Items.Remove(e.Item);
            }
        }

        private void Tb_filter_Validated(object sender, EventArgs e)
        {
            RefreshPackageList();
        }

        private async Task UpdateDeviceList()
        {
            List<DeviceInformation> devices = new();

            await Task.Run(() =>
            {
                var isLocked = false;
                try
                {
                    Monitor.TryEnter(mLocker, 1000, ref isLocked);
                    if (!isLocked)
                    {
                        return;
                    }
                    var outputString = ADB("devices");

                    if (string.IsNullOrEmpty(outputString))
                    {
                        return;
                    }

                    using var reader = new StringReader(outputString);
                    if (reader.ReadLine() == null)  // skip "List of devices attached"
                        {
                        return;
                    }

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.IndexOf("\tdevice") <= 0)
                        {
                            continue;
                        }

                        devices.Add(new DeviceInformation(
                            id: line.Substring(0, line.IndexOf('\t')),
                            name: ADB("shell getprop ro.product.name"),
                            model: ADB("shell getprop ro.product.model"),
                            device: ADB("shell getprop ro.product.device")
                            ));
                    }
                    reader.Close();
                }
                finally
                {
                    if (isLocked)
                    {
                        Monitor.Exit(mLocker);
                    }
                }
            });

            Invoke((MethodInvoker)delegate
            {
                var lastSelectedDevice = lv_devices.SelectedItems.Count > 0 ? (lv_devices.SelectedItems[0].Tag as DeviceInformation) : null;

                lv_devices.SelectedIndexChanged -= Lv_devices_SelectedIndexChanged;

                lv_devices.Items.Clear();
                lv_deviceInformations.Items.Clear();
                lv_packages.Items.Clear();

                DeviceInformation selected = null;

                foreach (var device in devices)
                {
                    var s = device.ID == lastSelectedDevice?.ID;
                    if (s)
                    {
                        selected = device;
                    }

                    var item = new ListViewItem(device.ID)
                    {
                        Tag = device,
                        Selected = s
                    };

                    lv_devices.Items.Add(item);
                }

                if ((selected == null)
                    && (lv_devices.Items.Count > 0)
                    )
                {
                    lv_devices.Items[0].Selected = true;
                }

                lv_devices.SelectedIndexChanged += Lv_devices_SelectedIndexChanged;

                tssl_status.Text = string.Format(Properties.Resources.DevicesFound, devices.Count, DateTime.Now.ToString("HH:mm:ss.fff"));

                Lv_devices_SelectedIndexChanged(this, EventArgs.Empty);
            });
        }

        private async Task UpdatePackageList(string deviceID)
        {
            await Task.Run(() =>
            {
                var isLocked = false;

                try
                {
                    Monitor.TryEnter(mLocker, 0, ref isLocked);
                    if (!isLocked)
                    {
                        return;
                    }

                    mPackages.Clear();
                    const string STR_PACKAGE = "package:";

                    var arguments = new[] {
                        new { Enabled = false, IsSystemPackage = false },
                        new { Enabled = false, IsSystemPackage = true },
                        new { Enabled = true, IsSystemPackage = false },
                        new { Enabled = true, IsSystemPackage = true },
                    };

                    foreach (var argumentParam in arguments)
                    {
                        var outputString = ADB($"-s {deviceID} shell pm list packages -{(argumentParam.Enabled ? 'e' : 'd')} -{(argumentParam.IsSystemPackage ? 's' : '3')}");

                        if (string.IsNullOrEmpty(outputString))
                        {
                            return;
                        }

                        using var reader = new StringReader(outputString);
                        string line;
                        while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                        {
                            if (line.IndexOf(STR_PACKAGE) != 0)
                            {
                                break;
                            }

                            line = line.Substring(STR_PACKAGE.Length);

                            mPackages.Add(new PackageInformation(
                                packageName: line,
                                enabled: argumentParam.Enabled,
                                @checked: argumentParam.Enabled,
                                isSystemPackage: argumentParam.IsSystemPackage
                                ));
                        }
                        reader.Close();
                    }

                    mPackages.Sort((a, b) => a.PackageName.CompareTo(b.PackageName));
                }
                finally
                {
                    if (isLocked)
                    {
                        Monitor.Exit(mLocker);
                    }
                }
            });

            Invoke((MethodInvoker)delegate {
                tssl_status.Text = string.Format(Properties.Resources.PackagesFound, mPackages.Count, DateTime.Now.ToString("HH:mm:ss.fff"));
                RefreshPackageList();
            });
        }

        private void RefreshPackageList()
        {
            lv_packages.ItemChecked -= Lv_packages_ItemChecked;
            lv_packages.Items.Clear();            

            var selectedFilter = (FilterType)(int)cob_filter.SelectedValue;
            var filterText = tb_filter.Text;
            var enablePackageFiltering = !string.IsNullOrEmpty(filterText);

            List<ListViewItem> newItems = null;
            foreach (var package in mPackages)
            {
                if (((selectedFilter == FilterType.EnabledPackages) && (!package.Enabled))
                    || ((selectedFilter == FilterType.DisabledPackages) && package.Enabled)
                    || ((selectedFilter == FilterType.SystemPackages) && (!package.IsSystemPackage))
                    || ((selectedFilter == FilterType.ThirdpartyPackages) && package.IsSystemPackage)
                    || ((selectedFilter == FilterType.CheckedPackages) && (!package.Checked))
                    || ((selectedFilter == FilterType.UncheckedPackages) && package.Checked)
                    )
                {
                    continue;
                }

                if (enablePackageFiltering
                    && (!package.PackageName.Contains(filterText))
                    )
                {
                    continue;
                }

                if (newItems == null)
                {
                    newItems = new();
                }

                newItems.Add(new ListViewItem(package.PackageName)
                {
                    Tag = package,
                    Checked = package.Checked,
                    ForeColor = package.IsSystemPackage ? Color.Red : SystemColors.ControlText,
                    BackColor = package.Enabled ? SystemColors.ControlLightLight : SystemColors.ControlDark
                });
            }

            if ((newItems?.Count ?? 0) > 0)
            {
                lv_packages.Items.AddRange(newItems.ToArray());
            }
            lv_packages.ItemChecked += Lv_packages_ItemChecked;
        }

        private static readonly StringBuilder sSb = new StringBuilder();
        private static string ADB(string argument)
        {
            var PATH_ADB = Path.Combine(PATH_DIR_ADB, "adb.exe");

            if (!File.Exists(PATH_ADB))
            {
                return null;
            }
            sSb.Clear();

            using var proc = new Process();
            proc.StartInfo.FileName = PATH_ADB;
            proc.StartInfo.Arguments = argument;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.OutputDataReceived += Handler;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            proc.Close();

            var output = sSb.ToString();
            sSb.Clear();

            return output.Replace("\r\r\n", "\n");

            void Handler(object sender, DataReceivedEventArgs e)
            {
                sSb.AppendLine(e.Data);
            }
        }

        private void Tb_filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshPackageList();
                e.Handled = true;
                lv_packages.Focus();
            }
        }

        private void Tssl_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private BackgroundWorker mBw = null;
        private void Tssl_disableEnable_Click(object sender, EventArgs e)
        {
            SwitchPackageState();            
        }

        private void SwitchPackageState()
        {
            if ((lv_devices.SelectedItems.Count < 1)
                || (!Monitor.TryEnter(mLocker))
                )
            {
                return;
            }

            tspb_progress.Value = 0;

            var selectedDevice = lv_devices.SelectedItems[0].Tag as DeviceInformation;

            mBw = new BackgroundWorker
            { 
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true,
            };
            mBw.DoWork += MBw_DoWork;
            mBw.ProgressChanged += MBw_ProgressChanged;
            mBw.RunWorkerCompleted += MBw_RunWorkerCompleted;

            mBw.RunWorkerAsync(new {
                SelectedDevice = selectedDevice
            });
        }

        private void MBw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Monitor.Exit(mLocker);

            var darg = e.Result as dynamic;
            var selectedDevice = darg.SelectedDevice as DeviceInformation;

            (_ = UpdatePackageList(selectedDevice.ID))
                .ContinueWith(_ => Invoke((MethodInvoker) delegate {
                    tssl_status.Text = string.Format(Properties.Resources.PackagesSwitched, darg.SucceedPackage, DateTime.Now.ToString("HH:mm:ss.fff"));
                }));
        }

        private void MBw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var prPair = e.UserState as UserState;

            tspb_progress.Value = e.ProgressPercentage;
        }
        private class UserState
        {
            public string PackageName { get; set; }
            public bool? Result { get; set; }
        }
        private void MBw_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;
            var darg = e.Argument as dynamic;
            var succeedCount = 0;
            var failedCount = 0;
            var totalCount = mPackages.Count;
            var count = 0;
            var prPair = new UserState { PackageName = null, Result = null };

            foreach (var pinfo in mPackages)
            {
                prPair.PackageName = pinfo.PackageName;

                if (pinfo.CheckedChanged)
                {
                    var newState = pinfo.Checked ? "enabled" : "disabled-user";
                    var adbResponse = ADB($"shell pm {(pinfo.Checked ? "enable" : "disable-user --user 0")} {pinfo.PackageName}")?.Trim();
                    var result = adbResponse?.Contains($"Package {pinfo.PackageName} new state: {newState}") ?? false;

                    if (result)
                    {
                        prPair.Result = true;
                        succeedCount++;
                    }
                    else
                    {
                        prPair.Result = false;
                        failedCount++;
                    }
                }
                else
                {
                    prPair.Result = null;
                }

                count++;
                bw.ReportProgress(count * 100 / totalCount, prPair);
            }

        EXIT:
            e.Result = new
            {
                SelectedDevice = darg.SelectedDevice,
                SkippedPackage = totalCount - (succeedCount + failedCount),
                SucceedPackage = succeedCount,
                FailedPackage = failedCount
            };
        }
    }
}
