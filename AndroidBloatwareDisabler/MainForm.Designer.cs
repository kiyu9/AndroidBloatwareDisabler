namespace AndroidBloatwareDisabler
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lv_devices = new System.Windows.Forms.ListView();
            this.ch_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_deviceInformations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cob_filter = new System.Windows.Forms.ComboBox();
            this.lbl_filter = new System.Windows.Forms.Label();
            this.lv_packages = new System.Windows.Forms.ListView();
            this.ch_packagename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tb_filter = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspb_progress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tssl_file = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_applyPackageList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tssl_dump = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dumpAllPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_dumpSystemPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dumpThirdpartyPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_dumpEnabledPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dumpDisabledPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_dumpCheckedPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dumpUncheckedPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tssl_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl_adb = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl_scanDevices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tssl_disableEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl_tools = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl_downloadAdbPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tssl_options = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.lv_devices);
            this.splitContainer1.Panel1.Controls.Add(this.lv_deviceInformations);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // lv_devices
            // 
            resources.ApplyResources(this.lv_devices, "lv_devices");
            this.lv_devices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_id});
            this.lv_devices.FullRowSelect = true;
            this.lv_devices.HideSelection = false;
            this.lv_devices.MultiSelect = false;
            this.lv_devices.Name = "lv_devices";
            this.lv_devices.UseCompatibleStateImageBehavior = false;
            this.lv_devices.View = System.Windows.Forms.View.Details;
            this.lv_devices.SelectedIndexChanged += new System.EventHandler(this.Lv_devices_SelectedIndexChanged);
            // 
            // ch_id
            // 
            resources.ApplyResources(this.ch_id, "ch_id");
            // 
            // lv_deviceInformations
            // 
            resources.ApplyResources(this.lv_deviceInformations, "lv_deviceInformations");
            this.lv_deviceInformations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_deviceInformations.FullRowSelect = true;
            this.lv_deviceInformations.HideSelection = false;
            this.lv_deviceInformations.MultiSelect = false;
            this.lv_deviceInformations.Name = "lv_deviceInformations";
            this.lv_deviceInformations.UseCompatibleStateImageBehavior = false;
            this.lv_deviceInformations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.cob_filter);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_filter);
            this.splitContainer2.Panel1.Controls.Add(this.lv_packages);
            this.splitContainer2.Panel1.Controls.Add(this.tb_filter);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            // 
            // cob_filter
            // 
            resources.ApplyResources(this.cob_filter, "cob_filter");
            this.cob_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_filter.FormattingEnabled = true;
            this.cob_filter.Name = "cob_filter";
            this.cob_filter.SelectedIndexChanged += new System.EventHandler(this.Cob_filter_SelectedIndexChanged);
            // 
            // lbl_filter
            // 
            resources.ApplyResources(this.lbl_filter, "lbl_filter");
            this.lbl_filter.Name = "lbl_filter";
            // 
            // lv_packages
            // 
            resources.ApplyResources(this.lv_packages, "lv_packages");
            this.lv_packages.CheckBoxes = true;
            this.lv_packages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_packagename});
            this.lv_packages.FullRowSelect = true;
            this.lv_packages.HideSelection = false;
            this.lv_packages.MultiSelect = false;
            this.lv_packages.Name = "lv_packages";
            this.lv_packages.UseCompatibleStateImageBehavior = false;
            this.lv_packages.View = System.Windows.Forms.View.Details;
            this.lv_packages.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.Lv_packages_ItemChecked);
            // 
            // ch_packagename
            // 
            resources.ApplyResources(this.ch_packagename, "ch_packagename");
            // 
            // tb_filter
            // 
            resources.ApplyResources(this.tb_filter, "tb_filter");
            this.tb_filter.Name = "tb_filter";
            this.tb_filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_filter_KeyDown);
            this.tb_filter.Validated += new System.EventHandler(this.Tb_filter_Validated);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_status,
            this.tspb_progress});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tssl_status
            // 
            resources.ApplyResources(this.tssl_status, "tssl_status");
            this.tssl_status.Name = "tssl_status";
            this.tssl_status.Spring = true;
            // 
            // tspb_progress
            // 
            resources.ApplyResources(this.tspb_progress, "tspb_progress");
            this.tspb_progress.Name = "tspb_progress";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_file,
            this.tssl_adb,
            this.tssl_tools});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // tssl_file
            // 
            resources.ApplyResources(this.tssl_file, "tssl_file");
            this.tssl_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_applyPackageList,
            this.toolStripSeparator7,
            this.tssl_dump,
            this.toolStripSeparator3,
            this.tssl_exit});
            this.tssl_file.Name = "tssl_file";
            // 
            // tsmi_applyPackageList
            // 
            resources.ApplyResources(this.tsmi_applyPackageList, "tsmi_applyPackageList");
            this.tsmi_applyPackageList.Name = "tsmi_applyPackageList";
            this.tsmi_applyPackageList.Click += new System.EventHandler(this.Tsmi_applyPackageList_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // tssl_dump
            // 
            resources.ApplyResources(this.tssl_dump, "tssl_dump");
            this.tssl_dump.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_dumpAllPackages,
            this.toolStripSeparator6,
            this.tsmi_dumpSystemPackages,
            this.tsmi_dumpThirdpartyPackages,
            this.toolStripSeparator4,
            this.tsmi_dumpEnabledPackages,
            this.tsmi_dumpDisabledPackages,
            this.toolStripSeparator5,
            this.tsmi_dumpCheckedPackages,
            this.tsmi_dumpUncheckedPackages});
            this.tssl_dump.Name = "tssl_dump";
            // 
            // tsmi_dumpAllPackages
            // 
            resources.ApplyResources(this.tsmi_dumpAllPackages, "tsmi_dumpAllPackages");
            this.tsmi_dumpAllPackages.Name = "tsmi_dumpAllPackages";
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // tsmi_dumpSystemPackages
            // 
            resources.ApplyResources(this.tsmi_dumpSystemPackages, "tsmi_dumpSystemPackages");
            this.tsmi_dumpSystemPackages.Name = "tsmi_dumpSystemPackages";
            // 
            // tsmi_dumpThirdpartyPackages
            // 
            resources.ApplyResources(this.tsmi_dumpThirdpartyPackages, "tsmi_dumpThirdpartyPackages");
            this.tsmi_dumpThirdpartyPackages.Name = "tsmi_dumpThirdpartyPackages";
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // tsmi_dumpEnabledPackages
            // 
            resources.ApplyResources(this.tsmi_dumpEnabledPackages, "tsmi_dumpEnabledPackages");
            this.tsmi_dumpEnabledPackages.Name = "tsmi_dumpEnabledPackages";
            // 
            // tsmi_dumpDisabledPackages
            // 
            resources.ApplyResources(this.tsmi_dumpDisabledPackages, "tsmi_dumpDisabledPackages");
            this.tsmi_dumpDisabledPackages.Name = "tsmi_dumpDisabledPackages";
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // tsmi_dumpCheckedPackages
            // 
            resources.ApplyResources(this.tsmi_dumpCheckedPackages, "tsmi_dumpCheckedPackages");
            this.tsmi_dumpCheckedPackages.Name = "tsmi_dumpCheckedPackages";
            // 
            // tsmi_dumpUncheckedPackages
            // 
            resources.ApplyResources(this.tsmi_dumpUncheckedPackages, "tsmi_dumpUncheckedPackages");
            this.tsmi_dumpUncheckedPackages.Name = "tsmi_dumpUncheckedPackages";
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // tssl_exit
            // 
            resources.ApplyResources(this.tssl_exit, "tssl_exit");
            this.tssl_exit.Name = "tssl_exit";
            this.tssl_exit.Click += new System.EventHandler(this.Tssl_exit_Click);
            // 
            // tssl_adb
            // 
            resources.ApplyResources(this.tssl_adb, "tssl_adb");
            this.tssl_adb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_scanDevices,
            this.toolStripSeparator2,
            this.tssl_disableEnable});
            this.tssl_adb.Name = "tssl_adb";
            // 
            // tssl_scanDevices
            // 
            resources.ApplyResources(this.tssl_scanDevices, "tssl_scanDevices");
            this.tssl_scanDevices.Name = "tssl_scanDevices";
            this.tssl_scanDevices.Click += new System.EventHandler(this.Tssl_scanDevices_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // tssl_disableEnable
            // 
            resources.ApplyResources(this.tssl_disableEnable, "tssl_disableEnable");
            this.tssl_disableEnable.Name = "tssl_disableEnable";
            this.tssl_disableEnable.Click += new System.EventHandler(this.Tssl_disableEnable_Click);
            // 
            // tssl_tools
            // 
            resources.ApplyResources(this.tssl_tools, "tssl_tools");
            this.tssl_tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_downloadAdbPackage,
            this.toolStripSeparator1,
            this.tssl_options});
            this.tssl_tools.Name = "tssl_tools";
            // 
            // tssl_downloadAdbPackage
            // 
            resources.ApplyResources(this.tssl_downloadAdbPackage, "tssl_downloadAdbPackage");
            this.tssl_downloadAdbPackage.Name = "tssl_downloadAdbPackage";
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // tssl_options
            // 
            resources.ApplyResources(this.tssl_options, "tssl_options");
            this.tssl_options.Name = "tssl_options";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_status;
        private System.Windows.Forms.ToolStripProgressBar tspb_progress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tssl_file;
        private System.Windows.Forms.ListView lv_devices;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem tssl_exit;
        private System.Windows.Forms.ToolStripMenuItem tssl_tools;
        private System.Windows.Forms.ToolStripMenuItem tssl_downloadAdbPackage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tssl_options;
        private System.Windows.Forms.ListView lv_deviceInformations;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lv_packages;
        private System.Windows.Forms.Label lbl_filter;
        private System.Windows.Forms.TextBox tb_filter;
        private System.Windows.Forms.ComboBox cob_filter;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ColumnHeader ch_id;
        private System.Windows.Forms.ColumnHeader ch_packagename;
        private System.Windows.Forms.ToolStripMenuItem tssl_adb;
        private System.Windows.Forms.ToolStripMenuItem tssl_scanDevices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tssl_disableEnable;
        private System.Windows.Forms.ToolStripMenuItem tssl_dump;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dumpSystemPackages;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dumpThirdpartyPackages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dumpEnabledPackages;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dumpDisabledPackages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dumpCheckedPackages;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dumpUncheckedPackages;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dumpAllPackages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmi_applyPackageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

