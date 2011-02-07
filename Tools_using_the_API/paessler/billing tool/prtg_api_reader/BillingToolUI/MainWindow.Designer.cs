namespace Paessler.Billingtool
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Btn_GenReport = new System.Windows.Forms.Button();
            this.Ms_MainMenu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Lv_BillingReportList = new System.Windows.Forms.ListView();
            this.Lb_ReportGroups = new System.Windows.Forms.ListBox();
            this.Lbl_GroupsCaption = new System.Windows.Forms.Label();
            this.Lbl_ReportsCaption = new System.Windows.Forms.Label();
            this.Btn_AddGroup = new System.Windows.Forms.Button();
            this.Btn_DelGroup = new System.Windows.Forms.Button();
            this.Btn_EditGroup = new System.Windows.Forms.Button();
            this.Btn_EditReport = new System.Windows.Forms.Button();
            this.Btn_DelReport = new System.Windows.Forms.Button();
            this.Btn_AddReport = new System.Windows.Forms.Button();
            this.Btn_GenReportGroup = new System.Windows.Forms.Button();
            this.groupBox_reports = new System.Windows.Forms.GroupBox();
            this.groupBox_groups = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cms_reportMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_reportListViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_groupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_groupListViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_MainMenu.SuspendLayout();
            this.groupBox_reports.SuspendLayout();
            this.groupBox_groups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cms_reportMenu.SuspendLayout();
            this.cms_reportListViewMenu.SuspendLayout();
            this.cms_groupMenu.SuspendLayout();
            this.cms_groupListViewMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_GenReport
            // 
            this.Btn_GenReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_GenReport.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_GenReport.Location = new System.Drawing.Point(376, 375);
            this.Btn_GenReport.Name = "Btn_GenReport";
            this.Btn_GenReport.Size = new System.Drawing.Size(89, 23);
            this.Btn_GenReport.TabIndex = 8;
            this.Btn_GenReport.Text = "Run report";
            this.Btn_GenReport.UseVisualStyleBackColor = false;
            this.Btn_GenReport.Click += new System.EventHandler(this.Btn_GenReport_Click);
            // 
            // Ms_MainMenu
            // 
            this.Ms_MainMenu.AutoSize = false;
            this.Ms_MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Ms_MainMenu.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Ms_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem1});
            this.Ms_MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.Ms_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.Ms_MainMenu.Name = "Ms_MainMenu";
            this.Ms_MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Ms_MainMenu.Size = new System.Drawing.Size(816, 24);
            this.Ms_MainMenu.TabIndex = 0;
            this.Ms_MainMenu.Text = "MeinMenu";
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectServerToolStripMenuItem,
            this.serverConfigToolStripMenuItem,
            this.toolStripSeparator,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(84, 20);
            this.dateiToolStripMenuItem1.Text = "&Configuration";
            // 
            // selectServerToolStripMenuItem
            // 
            this.selectServerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectServerToolStripMenuItem.Name = "selectServerToolStripMenuItem";
            this.selectServerToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.selectServerToolStripMenuItem.Text = "Select server";
            // 
            // serverConfigToolStripMenuItem
            // 
            this.serverConfigToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.serverConfigToolStripMenuItem.Name = "serverConfigToolStripMenuItem";
            this.serverConfigToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.serverConfigToolStripMenuItem.Text = "Options";
            this.serverConfigToolStripMenuItem.Click += new System.EventHandler(this.serverConfigToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(134, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.beendenToolStripMenuItem.Text = "&Exit";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // Lv_BillingReportList
            // 
            this.Lv_BillingReportList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Lv_BillingReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lv_BillingReportList.FullRowSelect = true;
            this.Lv_BillingReportList.GridLines = true;
            this.Lv_BillingReportList.HideSelection = false;
            this.Lv_BillingReportList.Location = new System.Drawing.Point(6, 19);
            this.Lv_BillingReportList.MultiSelect = false;
            this.Lv_BillingReportList.Name = "Lv_BillingReportList";
            this.Lv_BillingReportList.ShowGroups = false;
            this.Lv_BillingReportList.Size = new System.Drawing.Size(584, 342);
            this.Lv_BillingReportList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.Lv_BillingReportList.TabIndex = 7;
            this.Lv_BillingReportList.UseCompatibleStateImageBehavior = false;
            this.Lv_BillingReportList.View = System.Windows.Forms.View.Details;
            this.Lv_BillingReportList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Lv_BillingReportList_ColumnClick);
            this.Lv_BillingReportList.ItemActivate += new System.EventHandler(this.Lv_BillingReportList_ItemActivate);
            this.Lv_BillingReportList.SelectedIndexChanged += new System.EventHandler(this.Lv_BillingReportList_SelectedIndexChanged);
            this.Lv_BillingReportList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lv_BillingReportList_MouseDown);
            this.Lv_BillingReportList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lv_BillingReportList_MouseUp);
            // 
            // Lb_ReportGroups
            // 
            this.Lb_ReportGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Lb_ReportGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_ReportGroups.FormattingEnabled = true;
            this.Lb_ReportGroups.Location = new System.Drawing.Point(6, 19);
            this.Lb_ReportGroups.Name = "Lb_ReportGroups";
            this.Lb_ReportGroups.Size = new System.Drawing.Size(204, 340);
            this.Lb_ReportGroups.TabIndex = 3;
            this.Lb_ReportGroups.SelectedIndexChanged += new System.EventHandler(this.Lb_ReportGroups_SelectedIndexChanged);
            this.Lb_ReportGroups.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lb_ReportGroups_MouseUp);
            // 
            // Lbl_GroupsCaption
            // 
            this.Lbl_GroupsCaption.AutoSize = true;
            this.Lbl_GroupsCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_GroupsCaption.Location = new System.Drawing.Point(12, 34);
            this.Lbl_GroupsCaption.Name = "Lbl_GroupsCaption";
            this.Lbl_GroupsCaption.Size = new System.Drawing.Size(47, 13);
            this.Lbl_GroupsCaption.TabIndex = 1;
            this.Lbl_GroupsCaption.Text = "Groups";
            this.Lbl_GroupsCaption.Visible = false;
            // 
            // Lbl_ReportsCaption
            // 
            this.Lbl_ReportsCaption.AutoSize = true;
            this.Lbl_ReportsCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ReportsCaption.Location = new System.Drawing.Point(175, 34);
            this.Lbl_ReportsCaption.Name = "Lbl_ReportsCaption";
            this.Lbl_ReportsCaption.Size = new System.Drawing.Size(51, 13);
            this.Lbl_ReportsCaption.TabIndex = 2;
            this.Lbl_ReportsCaption.Text = "Reports";
            this.Lbl_ReportsCaption.Visible = false;
            // 
            // Btn_AddGroup
            // 
            this.Btn_AddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_AddGroup.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_AddGroup.Location = new System.Drawing.Point(6, 375);
            this.Btn_AddGroup.Name = "Btn_AddGroup";
            this.Btn_AddGroup.Size = new System.Drawing.Size(44, 23);
            this.Btn_AddGroup.TabIndex = 4;
            this.Btn_AddGroup.Text = "Add";
            this.Btn_AddGroup.UseVisualStyleBackColor = false;
            this.Btn_AddGroup.Click += new System.EventHandler(this.Btn_AddGroup_Click);
            // 
            // Btn_DelGroup
            // 
            this.Btn_DelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_DelGroup.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_DelGroup.Location = new System.Drawing.Point(56, 375);
            this.Btn_DelGroup.Name = "Btn_DelGroup";
            this.Btn_DelGroup.Size = new System.Drawing.Size(58, 23);
            this.Btn_DelGroup.TabIndex = 5;
            this.Btn_DelGroup.Text = "Remove";
            this.Btn_DelGroup.UseVisualStyleBackColor = false;
            this.Btn_DelGroup.Click += new System.EventHandler(this.Btn_DelGroup_Click);
            // 
            // Btn_EditGroup
            // 
            this.Btn_EditGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_EditGroup.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_EditGroup.Location = new System.Drawing.Point(120, 375);
            this.Btn_EditGroup.Name = "Btn_EditGroup";
            this.Btn_EditGroup.Size = new System.Drawing.Size(89, 23);
            this.Btn_EditGroup.TabIndex = 6;
            this.Btn_EditGroup.Text = "Edit";
            this.Btn_EditGroup.UseVisualStyleBackColor = false;
            this.Btn_EditGroup.Click += new System.EventHandler(this.Btn_EditGroup_Click);
            // 
            // Btn_EditReport
            // 
            this.Btn_EditReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_EditReport.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_EditReport.Location = new System.Drawing.Point(120, 375);
            this.Btn_EditReport.Name = "Btn_EditReport";
            this.Btn_EditReport.Size = new System.Drawing.Size(89, 23);
            this.Btn_EditReport.TabIndex = 12;
            this.Btn_EditReport.Text = "Edit";
            this.Btn_EditReport.UseVisualStyleBackColor = false;
            this.Btn_EditReport.Click += new System.EventHandler(this.Btn_EditReport_Click);
            // 
            // Btn_DelReport
            // 
            this.Btn_DelReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_DelReport.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_DelReport.Location = new System.Drawing.Point(56, 375);
            this.Btn_DelReport.Name = "Btn_DelReport";
            this.Btn_DelReport.Size = new System.Drawing.Size(58, 23);
            this.Btn_DelReport.TabIndex = 11;
            this.Btn_DelReport.Text = "Remove";
            this.Btn_DelReport.UseVisualStyleBackColor = false;
            this.Btn_DelReport.Click += new System.EventHandler(this.Btn_DelReport_Click);
            // 
            // Btn_AddReport
            // 
            this.Btn_AddReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_AddReport.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_AddReport.Location = new System.Drawing.Point(6, 375);
            this.Btn_AddReport.Name = "Btn_AddReport";
            this.Btn_AddReport.Size = new System.Drawing.Size(44, 23);
            this.Btn_AddReport.TabIndex = 10;
            this.Btn_AddReport.Text = "Add";
            this.Btn_AddReport.UseVisualStyleBackColor = false;
            this.Btn_AddReport.Click += new System.EventHandler(this.Btn_AddReport_Click);
            // 
            // Btn_GenReportGroup
            // 
            this.Btn_GenReportGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_GenReportGroup.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_GenReportGroup.Location = new System.Drawing.Point(471, 375);
            this.Btn_GenReportGroup.Name = "Btn_GenReportGroup";
            this.Btn_GenReportGroup.Size = new System.Drawing.Size(119, 23);
            this.Btn_GenReportGroup.TabIndex = 9;
            this.Btn_GenReportGroup.Text = "Run report group";
            this.Btn_GenReportGroup.UseVisualStyleBackColor = false;
            this.Btn_GenReportGroup.Click += new System.EventHandler(this.Btn_GenReportGroup_Click);
            // 
            // groupBox_reports
            // 
            this.groupBox_reports.Controls.Add(this.Lv_BillingReportList);
            this.groupBox_reports.Controls.Add(this.Btn_GenReport);
            this.groupBox_reports.Controls.Add(this.Btn_GenReportGroup);
            this.groupBox_reports.Controls.Add(this.Btn_AddReport);
            this.groupBox_reports.Controls.Add(this.Btn_EditReport);
            this.groupBox_reports.Controls.Add(this.Btn_DelReport);
            this.groupBox_reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox_reports.Location = new System.Drawing.Point(0, 0);
            this.groupBox_reports.MinimumSize = new System.Drawing.Size(360, 0);
            this.groupBox_reports.Name = "groupBox_reports";
            this.groupBox_reports.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_reports.Size = new System.Drawing.Size(596, 404);
            this.groupBox_reports.TabIndex = 13;
            this.groupBox_reports.TabStop = false;
            this.groupBox_reports.Text = "Reports";
            // 
            // groupBox_groups
            // 
            this.groupBox_groups.Controls.Add(this.Lb_ReportGroups);
            this.groupBox_groups.Controls.Add(this.Btn_EditGroup);
            this.groupBox_groups.Controls.Add(this.Btn_AddGroup);
            this.groupBox_groups.Controls.Add(this.Btn_DelGroup);
            this.groupBox_groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_groups.Location = new System.Drawing.Point(0, 0);
            this.groupBox_groups.MinimumSize = new System.Drawing.Size(216, 404);
            this.groupBox_groups.Name = "groupBox_groups";
            this.groupBox_groups.Size = new System.Drawing.Size(216, 404);
            this.groupBox_groups.TabIndex = 14;
            this.groupBox_groups.TabStop = false;
            this.groupBox_groups.Text = "Groups";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_groups);
            this.splitContainer1.Panel1MinSize = 216;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox_reports);
            this.splitContainer1.Panel2MinSize = 390;
            this.splitContainer1.Size = new System.Drawing.Size(816, 404);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 15;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // cms_reportMenu
            // 
            this.cms_reportMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.toolStripSeparator1,
            this.addReportToolStripMenuItem,
            this.removeReportToolStripMenuItem,
            this.editReportToolStripMenuItem});
            this.cms_reportMenu.Name = "cms_reportMenu";
            this.cms_reportMenu.Size = new System.Drawing.Size(150, 98);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // addReportToolStripMenuItem
            // 
            this.addReportToolStripMenuItem.Name = "addReportToolStripMenuItem";
            this.addReportToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addReportToolStripMenuItem.Text = "Add Report";
            this.addReportToolStripMenuItem.Click += new System.EventHandler(this.addReportToolStripMenuItem_Click);
            // 
            // removeReportToolStripMenuItem
            // 
            this.removeReportToolStripMenuItem.Name = "removeReportToolStripMenuItem";
            this.removeReportToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeReportToolStripMenuItem.Text = "Remove Report";
            this.removeReportToolStripMenuItem.Click += new System.EventHandler(this.removeReportToolStripMenuItem_Click);
            // 
            // editReportToolStripMenuItem
            // 
            this.editReportToolStripMenuItem.Name = "editReportToolStripMenuItem";
            this.editReportToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.editReportToolStripMenuItem.Text = "Edit Report";
            this.editReportToolStripMenuItem.Click += new System.EventHandler(this.editReportToolStripMenuItem_Click);
            // 
            // cms_reportListViewMenu
            // 
            this.cms_reportListViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReportToolStripMenuItem1});
            this.cms_reportListViewMenu.Name = "cms_reportListViewMenu";
            this.cms_reportListViewMenu.Size = new System.Drawing.Size(127, 26);
            // 
            // addReportToolStripMenuItem1
            // 
            this.addReportToolStripMenuItem1.Name = "addReportToolStripMenuItem1";
            this.addReportToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.addReportToolStripMenuItem1.Text = "Add report";
            this.addReportToolStripMenuItem1.Click += new System.EventHandler(this.addReportToolStripMenuItem1_Click);
            // 
            // cms_groupMenu
            // 
            this.cms_groupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem1,
            this.toolStripSeparator2,
            this.addGroupToolStripMenuItem,
            this.removeGroupToolStripMenuItem,
            this.editGroupToolStripMenuItem});
            this.cms_groupMenu.Name = "cms_groupMenu";
            this.cms_groupMenu.Size = new System.Drawing.Size(145, 98);
            // 
            // runToolStripMenuItem1
            // 
            this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
            this.runToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.runToolStripMenuItem1.Text = "Run";
            this.runToolStripMenuItem1.Click += new System.EventHandler(this.runToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addGroupToolStripMenuItem.Text = "Add group";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // removeGroupToolStripMenuItem
            // 
            this.removeGroupToolStripMenuItem.Name = "removeGroupToolStripMenuItem";
            this.removeGroupToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.removeGroupToolStripMenuItem.Text = "Remove group";
            this.removeGroupToolStripMenuItem.Click += new System.EventHandler(this.removeGroupToolStripMenuItem_Click);
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.editGroupToolStripMenuItem.Text = "Edit group";
            this.editGroupToolStripMenuItem.Click += new System.EventHandler(this.editGroupToolStripMenuItem_Click);
            // 
            // cms_groupListViewMenu
            // 
            this.cms_groupListViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem1});
            this.cms_groupListViewMenu.Name = "cms_groupListViewMenu";
            this.cms_groupListViewMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // addGroupToolStripMenuItem1
            // 
            this.addGroupToolStripMenuItem1.Name = "addGroupToolStripMenuItem1";
            this.addGroupToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.addGroupToolStripMenuItem1.Text = "Add group";
            this.addGroupToolStripMenuItem1.Click += new System.EventHandler(this.addGroupToolStripMenuItem1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(816, 428);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Lbl_ReportsCaption);
            this.Controls.Add(this.Lbl_GroupsCaption);
            this.Controls.Add(this.Ms_MainMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Ms_MainMenu;
            this.MinimumSize = new System.Drawing.Size(812, 455);
            this.Name = "MainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRTG Billing Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Ms_MainMenu.ResumeLayout(false);
            this.Ms_MainMenu.PerformLayout();
            this.groupBox_reports.ResumeLayout(false);
            this.groupBox_groups.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cms_reportMenu.ResumeLayout(false);
            this.cms_reportListViewMenu.ResumeLayout(false);
            this.cms_groupMenu.ResumeLayout(false);
            this.cms_groupListViewMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_GenReport;
        private System.Windows.Forms.MenuStrip Ms_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverConfigToolStripMenuItem;
        private System.Windows.Forms.ListView Lv_BillingReportList;
        private System.Windows.Forms.ListBox Lb_ReportGroups;
        private System.Windows.Forms.Label Lbl_GroupsCaption;
        private System.Windows.Forms.Label Lbl_ReportsCaption;
        private System.Windows.Forms.Button Btn_AddGroup;
        private System.Windows.Forms.Button Btn_DelGroup;
        private System.Windows.Forms.Button Btn_EditGroup;
        private System.Windows.Forms.Button Btn_EditReport;
        private System.Windows.Forms.Button Btn_DelReport;
        private System.Windows.Forms.Button Btn_AddReport;
        private System.Windows.Forms.Button Btn_GenReportGroup;
        private System.Windows.Forms.GroupBox groupBox_reports;
        private System.Windows.Forms.GroupBox groupBox_groups;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip cms_reportMenu;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editReportToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms_reportListViewMenu;
        private System.Windows.Forms.ToolStripMenuItem addReportToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cms_groupMenu;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms_groupListViewMenu;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem1;
    }
}