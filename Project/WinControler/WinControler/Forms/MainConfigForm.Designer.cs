namespace Hu.WinControler.Forms
{
    partial class MainConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainConfigForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabCmdLine = new System.Windows.Forms.TabControl();
            this.tpApp = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddFunc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFuncVoiceDesc = new System.Windows.Forms.TextBox();
            this.tbFuncKeys = new System.Windows.Forms.TextBox();
            this.tbFuncDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgFuncs = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgApp = new System.Windows.Forms.DataGridView();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.tbAppVoiceDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAppDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnScanPath = new System.Windows.Forms.Button();
            this.tbAppPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpCmdLine = new System.Windows.Forms.TabPage();
            this.dgvCmdLineList = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.gpbCmdLine = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbConfirm = new System.Windows.Forms.CheckBox();
            this.tbCmdLineVoice = new System.Windows.Forms.TextBox();
            this.btnAddCmdLine = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbCmdLine = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tpCustomed = new System.Windows.Forms.TabPage();
            this.dgvCustomedFunc = new System.Windows.Forms.DataGridView();
            this.cuCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuVoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuKeys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCuAdd = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tbCuKeys = new System.Windows.Forms.TextBox();
            this.tbCuVoice = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdConfirm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            this.tabCmdLine.SuspendLayout();
            this.tpApp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncs)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgApp)).BeginInit();
            this.tpCmdLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdLineList)).BeginInit();
            this.gpbCmdLine.SuspendLayout();
            this.tpCustomed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomedFunc)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabCmdLine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 516);
            this.panel1.TabIndex = 0;
            // 
            // tabCmdLine
            // 
            this.tabCmdLine.Controls.Add(this.tpApp);
            this.tabCmdLine.Controls.Add(this.tpCmdLine);
            this.tabCmdLine.Controls.Add(this.tpCustomed);
            this.tabCmdLine.Location = new System.Drawing.Point(12, 13);
            this.tabCmdLine.Name = "tabCmdLine";
            this.tabCmdLine.SelectedIndex = 0;
            this.tabCmdLine.Size = new System.Drawing.Size(759, 491);
            this.tabCmdLine.TabIndex = 0;
            this.tabCmdLine.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabPage_Selected);
            // 
            // tpApp
            // 
            this.tpApp.Controls.Add(this.groupBox2);
            this.tpApp.Controls.Add(this.groupBox1);
            this.tpApp.Location = new System.Drawing.Point(4, 22);
            this.tpApp.Name = "tpApp";
            this.tpApp.Padding = new System.Windows.Forms.Padding(3);
            this.tpApp.Size = new System.Drawing.Size(751, 465);
            this.tpApp.TabIndex = 0;
            this.tpApp.Text = "程序配置";
            this.tpApp.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnAddFunc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbFuncVoiceDesc);
            this.groupBox2.Controls.Add(this.tbFuncKeys);
            this.groupBox2.Controls.Add(this.tbFuncDescription);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dgFuncs);
            this.groupBox2.Location = new System.Drawing.Point(7, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 247);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能项";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(647, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "_________________________________________________________________________________" +
                "__________________________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(9, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "添加功能项";
            // 
            // btnAddFunc
            // 
            this.btnAddFunc.Location = new System.Drawing.Point(662, 206);
            this.btnAddFunc.Name = "btnAddFunc";
            this.btnAddFunc.Size = new System.Drawing.Size(54, 30);
            this.btnAddFunc.TabIndex = 9;
            this.btnAddFunc.Text = "添加";
            this.btnAddFunc.UseVisualStyleBackColor = true;
            this.btnAddFunc.Click += new System.EventHandler(this.btnAddFunc_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(269, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "在键盘上按下此功能的快捷键。";
            // 
            // tbFuncVoiceDesc
            // 
            this.tbFuncVoiceDesc.Location = new System.Drawing.Point(470, 183);
            this.tbFuncVoiceDesc.Name = "tbFuncVoiceDesc";
            this.tbFuncVoiceDesc.Size = new System.Drawing.Size(245, 21);
            this.tbFuncVoiceDesc.TabIndex = 7;
            this.tbFuncVoiceDesc.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbFuncVoiceDesc.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // tbFuncKeys
            // 
            this.tbFuncKeys.Location = new System.Drawing.Point(83, 210);
            this.tbFuncKeys.Name = "tbFuncKeys";
            this.tbFuncKeys.Size = new System.Drawing.Size(180, 21);
            this.tbFuncKeys.TabIndex = 6;
            this.tbFuncKeys.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbFuncKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFuncKeys_KeyDown);
            this.tbFuncKeys.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // tbFuncDescription
            // 
            this.tbFuncDescription.Location = new System.Drawing.Point(83, 183);
            this.tbFuncDescription.Name = "tbFuncDescription";
            this.tbFuncDescription.Size = new System.Drawing.Size(180, 21);
            this.tbFuncDescription.TabIndex = 5;
            this.tbFuncDescription.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbFuncDescription.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "功能键：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "语音描述：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "功能描述：";
            // 
            // dgFuncs
            // 
            this.dgFuncs.AllowUserToAddRows = false;
            this.dgFuncs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFuncs.Location = new System.Drawing.Point(9, 21);
            this.dgFuncs.Name = "dgFuncs";
            this.dgFuncs.RowTemplate.Height = 23;
            this.dgFuncs.Size = new System.Drawing.Size(706, 127);
            this.dgFuncs.TabIndex = 0;
            this.dgFuncs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFuncs_CellClick);
            this.dgFuncs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
            this.dgFuncs.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgApp_EditingControlShowing);
            this.dgFuncs.DoubleClick += new System.EventHandler(this.dgApp_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dgApp);
            this.groupBox1.Controls.Add(this.btnAddApp);
            this.groupBox1.Controls.Add(this.tbAppVoiceDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbAppDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnScanPath);
            this.groupBox1.Controls.Add(this.tbAppPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "程序项";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(653, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "_________________________________________________________________________________" +
                "___________________________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "添加程序";
            // 
            // dgApp
            // 
            this.dgApp.AllowUserToAddRows = false;
            this.dgApp.AllowUserToDeleteRows = false;
            this.dgApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgApp.Location = new System.Drawing.Point(9, 102);
            this.dgApp.Name = "dgApp";
            this.dgApp.RowTemplate.Height = 23;
            this.dgApp.Size = new System.Drawing.Size(706, 91);
            this.dgApp.TabIndex = 8;
            this.dgApp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppDelete_OnDataGridViewCellClick);
            this.dgApp.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
            this.dgApp.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgApp_EditingControlShowing);
            this.dgApp.SelectionChanged += new System.EventHandler(this.dgApp_SelectionChanged);
            this.dgApp.DoubleClick += new System.EventHandler(this.dgApp_DoubleClick);
            // 
            // btnAddApp
            // 
            this.btnAddApp.Location = new System.Drawing.Point(640, 62);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(76, 23);
            this.btnAddApp.TabIndex = 7;
            this.btnAddApp.Text = "添加";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // tbAppVoiceDesc
            // 
            this.tbAppVoiceDesc.Location = new System.Drawing.Point(398, 64);
            this.tbAppVoiceDesc.Name = "tbAppVoiceDesc";
            this.tbAppVoiceDesc.Size = new System.Drawing.Size(236, 21);
            this.tbAppVoiceDesc.TabIndex = 6;
            this.tbAppVoiceDesc.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbAppVoiceDesc.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "语音描述：";
            // 
            // tbAppDescription
            // 
            this.tbAppDescription.Location = new System.Drawing.Point(103, 65);
            this.tbAppDescription.Name = "tbAppDescription";
            this.tbAppDescription.Size = new System.Drawing.Size(206, 21);
            this.tbAppDescription.TabIndex = 4;
            this.tbAppDescription.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbAppDescription.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "程序描述：";
            // 
            // btnScanPath
            // 
            this.btnScanPath.Location = new System.Drawing.Point(640, 34);
            this.btnScanPath.Name = "btnScanPath";
            this.btnScanPath.Size = new System.Drawing.Size(75, 23);
            this.btnScanPath.TabIndex = 2;
            this.btnScanPath.Text = "浏览...";
            this.btnScanPath.UseVisualStyleBackColor = true;
            this.btnScanPath.Click += new System.EventHandler(this.btnScanPath_Click);
            // 
            // tbAppPath
            // 
            this.tbAppPath.Location = new System.Drawing.Point(102, 36);
            this.tbAppPath.Name = "tbAppPath";
            this.tbAppPath.Size = new System.Drawing.Size(532, 21);
            this.tbAppPath.TabIndex = 1;
            this.tbAppPath.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbAppPath.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "程序启动路径：";
            // 
            // tpCmdLine
            // 
            this.tpCmdLine.Controls.Add(this.dgvCmdLineList);
            this.tpCmdLine.Controls.Add(this.label12);
            this.tpCmdLine.Controls.Add(this.gpbCmdLine);
            this.tpCmdLine.Location = new System.Drawing.Point(4, 22);
            this.tpCmdLine.Name = "tpCmdLine";
            this.tpCmdLine.Padding = new System.Windows.Forms.Padding(3);
            this.tpCmdLine.Size = new System.Drawing.Size(751, 465);
            this.tpCmdLine.TabIndex = 1;
            this.tpCmdLine.Text = "命令行配置";
            this.tpCmdLine.UseVisualStyleBackColor = true;
            // 
            // dgvCmdLineList
            // 
            this.dgvCmdLineList.AllowUserToAddRows = false;
            this.dgvCmdLineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCmdLineList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.CmdLine,
            this.Voice,
            this.CmdConfirm,
            this.Delete});
            this.dgvCmdLineList.Location = new System.Drawing.Point(7, 217);
            this.dgvCmdLineList.Name = "dgvCmdLineList";
            this.dgvCmdLineList.RowTemplate.Height = 23;
            this.dgvCmdLineList.Size = new System.Drawing.Size(736, 242);
            this.dgvCmdLineList.TabIndex = 2;
            this.dgvCmdLineList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCmdLineList_CellBeginEdit);
            this.dgvCmdLineList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCmdLineList_CellClick);
            this.dgvCmdLineList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCmdLineList_CellEndEdit);
            this.dgvCmdLineList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgApp_EditingControlShowing);
            this.dgvCmdLineList.DoubleClick += new System.EventHandler(this.dgApp_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(6, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "已存在命令列表：";
            // 
            // gpbCmdLine
            // 
            this.gpbCmdLine.Controls.Add(this.label16);
            this.gpbCmdLine.Controls.Add(this.cbConfirm);
            this.gpbCmdLine.Controls.Add(this.tbCmdLineVoice);
            this.gpbCmdLine.Controls.Add(this.btnAddCmdLine);
            this.gpbCmdLine.Controls.Add(this.label15);
            this.gpbCmdLine.Controls.Add(this.label14);
            this.gpbCmdLine.Controls.Add(this.tbCmdLine);
            this.gpbCmdLine.Controls.Add(this.label13);
            this.gpbCmdLine.ForeColor = System.Drawing.Color.Blue;
            this.gpbCmdLine.Location = new System.Drawing.Point(7, 7);
            this.gpbCmdLine.Name = "gpbCmdLine";
            this.gpbCmdLine.Size = new System.Drawing.Size(738, 192);
            this.gpbCmdLine.TabIndex = 0;
            this.gpbCmdLine.TabStop = false;
            this.gpbCmdLine.Text = "新增";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(325, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 12);
            this.label16.TabIndex = 8;
            this.label16.Text = "(建议选择，以免误操作)";
            // 
            // cbConfirm
            // 
            this.cbConfirm.AutoSize = true;
            this.cbConfirm.Checked = true;
            this.cbConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConfirm.ForeColor = System.Drawing.Color.Black;
            this.cbConfirm.Location = new System.Drawing.Point(225, 111);
            this.cbConfirm.Name = "cbConfirm";
            this.cbConfirm.Size = new System.Drawing.Size(96, 16);
            this.cbConfirm.TabIndex = 7;
            this.cbConfirm.Text = "执行前先确认";
            this.cbConfirm.UseVisualStyleBackColor = true;
            // 
            // tbCmdLineVoice
            // 
            this.tbCmdLineVoice.Location = new System.Drawing.Point(80, 109);
            this.tbCmdLineVoice.Name = "tbCmdLineVoice";
            this.tbCmdLineVoice.Size = new System.Drawing.Size(121, 21);
            this.tbCmdLineVoice.TabIndex = 5;
            this.tbCmdLineVoice.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbCmdLineVoice.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // btnAddCmdLine
            // 
            this.btnAddCmdLine.ForeColor = System.Drawing.Color.Black;
            this.btnAddCmdLine.Location = new System.Drawing.Point(656, 106);
            this.btnAddCmdLine.Name = "btnAddCmdLine";
            this.btnAddCmdLine.Size = new System.Drawing.Size(75, 51);
            this.btnAddCmdLine.TabIndex = 4;
            this.btnAddCmdLine.Text = "添加";
            this.btnAddCmdLine.UseVisualStyleBackColor = true;
            this.btnAddCmdLine.Click += new System.EventHandler(this.btnAddCmdLine_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(9, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(209, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "注意：新添加的命令重启程序后有效。";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(9, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "语音描述：";
            // 
            // tbCmdLine
            // 
            this.tbCmdLine.Location = new System.Drawing.Point(9, 37);
            this.tbCmdLine.Multiline = true;
            this.tbCmdLine.Name = "tbCmdLine";
            this.tbCmdLine.Size = new System.Drawing.Size(723, 62);
            this.tbCmdLine.TabIndex = 1;
            this.tbCmdLine.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbCmdLine.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(7, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "编写命令行：";
            // 
            // tpCustomed
            // 
            this.tpCustomed.Controls.Add(this.dgvCustomedFunc);
            this.tpCustomed.Controls.Add(this.groupBox3);
            this.tpCustomed.Location = new System.Drawing.Point(4, 22);
            this.tpCustomed.Name = "tpCustomed";
            this.tpCustomed.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomed.Size = new System.Drawing.Size(751, 465);
            this.tpCustomed.TabIndex = 2;
            this.tpCustomed.Text = "自定义";
            this.tpCustomed.UseVisualStyleBackColor = true;
            // 
            // dgvCustomedFunc
            // 
            this.dgvCustomedFunc.AllowUserToAddRows = false;
            this.dgvCustomedFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomedFunc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuCommand,
            this.cuVoice,
            this.cuKeys,
            this.cuDelete});
            this.dgvCustomedFunc.Location = new System.Drawing.Point(7, 108);
            this.dgvCustomedFunc.Name = "dgvCustomedFunc";
            this.dgvCustomedFunc.RowTemplate.Height = 23;
            this.dgvCustomedFunc.Size = new System.Drawing.Size(741, 351);
            this.dgvCustomedFunc.TabIndex = 1;
            this.dgvCustomedFunc.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCmdLineList_CellBeginEdit);
            this.dgvCustomedFunc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomedFunc_CellClick);
            this.dgvCustomedFunc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCmdLineList_CellEndEdit);
            this.dgvCustomedFunc.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgApp_EditingControlShowing);
            this.dgvCustomedFunc.DoubleClick += new System.EventHandler(this.dgApp_DoubleClick);
            // 
            // cuCommand
            // 
            this.cuCommand.HeaderText = "命令代码";
            this.cuCommand.Name = "cuCommand";
            this.cuCommand.ReadOnly = true;
            // 
            // cuVoice
            // 
            this.cuVoice.HeaderText = "语音命令";
            this.cuVoice.Name = "cuVoice";
            // 
            // cuKeys
            // 
            this.cuKeys.HeaderText = "快捷键";
            this.cuKeys.Name = "cuKeys";
            // 
            // cuDelete
            // 
            this.cuDelete.HeaderText = "";
            this.cuDelete.Name = "cuDelete";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.btnCuAdd);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.tbCuKeys);
            this.groupBox3.Controls.Add(this.tbCuVoice);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(739, 69);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "新增";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(448, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 12);
            this.label19.TabIndex = 5;
            this.label19.Text = "在键盘上直接按下快捷键";
            // 
            // btnCuAdd
            // 
            this.btnCuAdd.Location = new System.Drawing.Point(658, 11);
            this.btnCuAdd.Name = "btnCuAdd";
            this.btnCuAdd.Size = new System.Drawing.Size(75, 52);
            this.btnCuAdd.TabIndex = 4;
            this.btnCuAdd.Text = "添加";
            this.btnCuAdd.UseVisualStyleBackColor = true;
            this.btnCuAdd.Click += new System.EventHandler(this.btnCuAdd_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(240, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 3;
            this.label18.Text = "快捷键：";
            // 
            // tbCuKeys
            // 
            this.tbCuKeys.Location = new System.Drawing.Point(299, 18);
            this.tbCuKeys.Name = "tbCuKeys";
            this.tbCuKeys.Size = new System.Drawing.Size(143, 21);
            this.tbCuKeys.TabIndex = 2;
            this.tbCuKeys.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbCuKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFuncKeys_KeyDown);
            this.tbCuKeys.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // tbCuVoice
            // 
            this.tbCuVoice.Location = new System.Drawing.Point(78, 18);
            this.tbCuVoice.Name = "tbCuVoice";
            this.tbCuVoice.Size = new System.Drawing.Size(100, 21);
            this.tbCuVoice.TabIndex = 1;
            this.tbCuVoice.Enter += new System.EventHandler(this.textBox_Enter);
            this.tbCuVoice.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "语音命令：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.Filter = "可执行文件(*.exe)|*.exe|所有文件|*.*";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Command
            // 
            this.Command.HeaderText = "命令代码";
            this.Command.Name = "Command";
            this.Command.ReadOnly = true;
            this.Command.Width = 80;
            // 
            // CmdLine
            // 
            this.CmdLine.HeaderText = "命令行";
            this.CmdLine.Name = "CmdLine";
            this.CmdLine.Width = 230;
            // 
            // Voice
            // 
            this.Voice.HeaderText = "语音命令";
            this.Voice.Name = "Voice";
            // 
            // CmdConfirm
            // 
            this.CmdConfirm.HeaderText = "执行前确认";
            this.CmdConfirm.Name = "CmdConfirm";
            this.CmdConfirm.Width = 70;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.TrackVisitedState = false;
            this.Delete.Width = 60;
            // 
            // MainConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 516);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(802, 554);
            this.MinimumSize = new System.Drawing.Size(802, 554);
            this.Name = "MainConfigForm";
            this.Text = "配置控制项";
            this.Load += new System.EventHandler(this.MainConfigForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabCmdLine.ResumeLayout(false);
            this.tpApp.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgApp)).EndInit();
            this.tpCmdLine.ResumeLayout(false);
            this.tpCmdLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdLineList)).EndInit();
            this.gpbCmdLine.ResumeLayout(false);
            this.gpbCmdLine.PerformLayout();
            this.tpCustomed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomedFunc)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabCmdLine;
        private System.Windows.Forms.TabPage tpApp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddFunc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFuncVoiceDesc;
        private System.Windows.Forms.TextBox tbFuncKeys;
        private System.Windows.Forms.TextBox tbFuncDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgFuncs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgApp;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.TextBox tbAppVoiceDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAppDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnScanPath;
        private System.Windows.Forms.TextBox tbAppPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpCmdLine;
        private System.Windows.Forms.DataGridView dgvCmdLineList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gpbCmdLine;
        private System.Windows.Forms.TextBox tbCmdLineVoice;
        private System.Windows.Forms.Button btnAddCmdLine;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbCmdLine;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbConfirm;
        private System.Windows.Forms.TabPage tpCustomed;
        private System.Windows.Forms.DataGridView dgvCustomedFunc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnCuAdd;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbCuKeys;
        private System.Windows.Forms.TextBox tbCuVoice;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuVoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuKeys;
        private System.Windows.Forms.DataGridViewLinkColumn cuDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Command;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmdLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CmdConfirm;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}