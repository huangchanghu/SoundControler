using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace Hu.WinControler.Forms
{
    public partial class MainConfigForm : Form
    {
        int appSelectedRow = -1; //上边的Grid中当前选中的行的行号
        Dictionary<string, string> keyDic = new Dictionary<string, string>();//不可视按键的映射
        
        public MainConfigForm()
        {
            InitializeComponent();

            #region 不可视按键的映射
            keyDic.Add("Back", "{BACKSPACE}");
            keyDic.Add("Pause", "{BREAK}");
            keyDic.Add("Capital", "{CAPSLOCK}");
            keyDic.Add("Delete", "{DELETE}");
            keyDic.Add("Down", "{DOWN}");
            keyDic.Add("End", "{END}");
            keyDic.Add("Return", "{ENTER}");
            keyDic.Add("Escape", "{ESC}");
            keyDic.Add("Help", "{HELP}");//未知
            keyDic.Add("Home", "{HOME}");
            keyDic.Add("Insert", "{INSERT}");
            keyDic.Add("Left", "{LEFT}");
            keyDic.Add("NumLock", "{NUMLOCK}");
            keyDic.Add("Next", "{PGDN}");
            keyDic.Add("PageUp", "{PGUP}");
            keyDic.Add("Print", "{PRTSC}");//未知
            keyDic.Add("Right", "{RIGHT}");
            keyDic.Add("Scroll", "{SCROLLLOCK}");
            keyDic.Add("Table", "{TAB}");//未知
            keyDic.Add("Up", "{UP}");
            keyDic.Add("F1", "{F1}");
            keyDic.Add("F2", "{F2}");
            keyDic.Add("F3", "{F3}");
            keyDic.Add("F4", "{F4}");
            keyDic.Add("F5", "{F5}");
            keyDic.Add("F6", "{F6}");
            keyDic.Add("F7", "{F7}");
            keyDic.Add("F8", "{F8}");
            keyDic.Add("F9", "{F9}");
            keyDic.Add("F10", "{F10}");
            keyDic.Add("F11", "{F11}");
            keyDic.Add("F12", "{F12}");
            keyDic.Add("F13", "{F13}");
            keyDic.Add("F14", "{F14}");
            keyDic.Add("F15", "{F15}");
            keyDic.Add("F16", "{F16}");
            keyDic.Add("Add", "{ADD}");
            keyDic.Add("Subtract", "{SUBTRACT}");
            keyDic.Add("Multiply", "{MULTIPLY}");
            keyDic.Add("Divide", "{DIVIDE}");
            keyDic.Add("Shift", "+");
            keyDic.Add("Control", "^");
            keyDic.Add("Alt", "%");
            keyDic.Add("+", "{+}");
            keyDic.Add("^", "{^}");
            keyDic.Add("%", "{%}");
            keyDic.Add("~", "{~}");
            keyDic.Add("{", "{{}");
            keyDic.Add("}", "{}}");
            keyDic.Add("(", "{(}");
            keyDic.Add(")", "{)}");
            #endregion
        }

        private void MainConfigForm_Load(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void btnScanPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FileName.Trim() != "")
                {
                    if (File.Exists(openFileDialog1.FileName.Trim()))
                        tbAppPath.Text = openFileDialog1.FileName;
                }
            }
        }

        #region 程序配置相关

        private void LoadApplications()
        {
            DataSet ds = DataAccess.Instance.ExecuteQuery(string.Format("select a.[Cmd] '命令代码' , a.[Desc] '程序描述', a.[Path] '启动路径',v.[Desc] '语音描述'  from app a left join viccmd v on a.cmd = v.cmd limit 5000"));
            dgApp.DataSource = ds.Tables[0];
            AddAppColumns(dgApp, "appDeleteColumn");
            dgApp.Columns[0].ReadOnly = true;
        }

        /// <summary>
        /// 程序添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddApp_Click(object sender, EventArgs e)
        {
            if (tbAppPath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("程序路径不能为空！");
                return;
            }
            if (tbAppDescription.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入程序描述！");
                return;
            }
            if (tbAppVoiceDesc.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入语音描述！");
                return;
            }
            int appcmd = DataAccess.Instance.AddApplication(tbAppDescription.Text.Trim(), tbAppPath.Text.Trim(), tbAppVoiceDesc.Text.Trim());
            if (appcmd < 0) MessageBox.Show("添加失败！");
            else
            {
                MessageBox.Show("已添加！");
                tbAppPath.Text = string.Empty;
                tbAppDescription.Text = string.Empty;
                tbAppVoiceDesc.Text = string.Empty;
                LoadApplications();
            }
        }

        /// <summary>
        /// 添加删除列
        /// </summary>
        private void AddAppColumns(DataGridView grid, string columnName)
        {
            if (grid.Columns.Contains(columnName)) grid.Columns.Remove(columnName);//若此已存在则先将其删除
            DataGridViewButtonCell cell = new DataGridViewButtonCell();
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.ValueType = typeof(string);
            column.UseColumnTextForButtonValue = true;
            column.Name = columnName;
            column.HeaderText = "删除";
            column.CellTemplate = cell;
            grid.Columns.Add(column);
            foreach (var row in grid.Rows)
            {
                DataGridViewCell c = ((DataGridViewRow)row).Cells[columnName];
                c.Value = "删除";
            }
        }

        private void AppDelete_OnDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (!dgApp.Columns[e.ColumnIndex].Name.Equals("appDeleteColumn") || e.RowIndex < 0) return;
            if (MessageBox.Show(this, "是否确认删除！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
            int cmd = (int)dgApp.Rows[e.RowIndex].Cells[0].Value;
            DeleApplication(cmd);
        }

        /// <summary>
        /// 删除一个应用程序配置项
        /// </summary>
        /// <param name="appCommand">程序对应的命令代码</param>
        private void DeleApplication(int appCommand)
        {
            DataAccess.Instance.DeleteApplication(appCommand);
            LoadApplications();

            //加载下一个程序的功能列表
            if (dgApp.Rows.Count > 0)
                LoadFunctions((int)dgApp.CurrentRow.Cells[0].Value);
            //else
            //    dgFuncs.Rows.Clear();
        }


        private void dgApp_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).BeginEdit(true);
            }
            catch
            {
              
            }
        }

        private void dgApp_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.LightYellow;
        }

        private void dgApp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (appSelectedRow != dgApp.CurrentRow.Index)
                {
                    appSelectedRow = dgApp.CurrentRow.Index;
                    LoadFunctions((int)dgApp.Rows[appSelectedRow].Cells[0].Value);
                }
            }
            catch { }
        } 
        #endregion

        #region 程序功能配置相关
        /// <summary>
        /// 向Grid中加载给定程序命令代码对应程序的功能列表
        /// </summary>
        /// <param name="appCmd">程序命令代码</param>
        private void LoadFunctions(int appCmd)
        {
            string sql = string.Format("select f.cmd '命令代码',f.desc '功能描述',f.keys '快捷键',v.desc '语音描述' from [func] f left join viccmd v on f.cmd = v.cmd where f.app={0}",appCmd);
            DataSet ds = DataAccess.Instance.ExecuteQuery(sql);
            dgFuncs.DataSource = ds.Tables[0];
            AddAppColumns(dgFuncs, "funcDeleteColumn");
            dgFuncs.Columns[0].ReadOnly = true;
        }

        private void btnAddFunc_Click(object sender, EventArgs e)
        {
            if (dgApp.SelectedRows.Count < 0)
            {
                MessageBox.Show(this, "请先选中一个程序", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string desc = tbFuncDescription.Text.Trim();
            string vicDesc = tbFuncVoiceDesc.Text.Trim();
            string keys = tbFuncKeys.Text.Trim();
            if (desc == string.Empty)
            {
                MessageBox.Show(this,"请输入功能描述","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (vicDesc == string.Empty)
            {
                MessageBox.Show(this, "请输入语音描述", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (keys == string.Empty)
            {
                MessageBox.Show(this, "请输入功能快捷键", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (DataAccess.Instance.IsVoiceDescriptionExist(tbFuncVoiceDesc.Text.Trim()))
            //{
            //    MessageBox.Show("此语音描述已存在，请更改！");
            //    return;
            //}
            int appCmd = (int)dgApp.Rows[appSelectedRow].Cells[0].Value;
            keys = sKeys;
            sKeys = string.Empty;
            if (DataAccess.Instance.AddFunction(appCmd, desc, keys, vicDesc))
            {
                MessageBox.Show(this, "添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFunctions((int)dgApp.Rows[appSelectedRow].Cells[0].Value);//生新加载功能列表
                tbFuncDescription.Text = string.Empty;
                tbFuncKeys.Text = string.Empty;
                tbFuncVoiceDesc.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(this, "添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgFuncs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (!dgFuncs.Columns[e.ColumnIndex].Name.Equals("funcDeleteColumn") || e.RowIndex < 0) return;
            if (MessageBox.Show(this, "是否确认删除！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
            int cmd = (int)dgFuncs.Rows[e.RowIndex].Cells[0].Value;
            if (DataAccess.Instance.DeleteFunction(cmd, (int)dgApp.Rows[appSelectedRow].Cells[0].Value))
            {
                MessageBox.Show(this, "已删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFunctions((int)dgApp.Rows[appSelectedRow].Cells[0].Value);
            }
            else
            {
                MessageBox.Show(this, "删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        string sKeys;
        private void tbFuncKeys_KeyDown(object sender, KeyEventArgs e)
        {

            sKeys = string.Empty;
            string currentKey = keyDic.ContainsKey(e.KeyCode.ToString()) ? keyDic[e.KeyCode.ToString()] : e.KeyCode.ToString();
            string[] temp = e.Modifiers.ToString().Split(", ".ToCharArray());
            foreach (var t in temp)
            {
                if(keyDic.ContainsKey(t))
                    sKeys += keyDic[t];
            }
            if (sKeys != string.Empty)
            {
                sKeys += string.Format("({0})", currentKey);
            }
            else
                sKeys = currentKey;
           // tbFuncDescription.Text = sKeys;
            e.Handled = true;


            string showKeys = string.Empty;
            if (e.Control) showKeys += "Ctrl + ";
            if (e.Shift) showKeys += "Shift + ";
            if (e.Alt) showKeys += "Alt + ";
            showKeys += e.KeyCode.ToString();
            while(!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync(new DoWorkArg {  TextBox = sender as TextBox, Keys = showKeys});
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            DoWorkArg arg = e.Argument as DoWorkArg;
            if (arg != null)
                arg.TextBox.Text = arg.Keys;
        }

        /// <summary>
        /// 用于封装参数
        /// </summary>
        class DoWorkArg
        {
            public TextBox TextBox { get; set; }
            public string Keys { get; set; }
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.ColumnIndex == grid.ColumnCount - 1) return;
            if (grid.Name == "dgApp")
            {
                if (!DataAccess.Instance.UpdateApplication((int)grid[0, e.RowIndex].Value, grid[1, e.RowIndex].Value.ToString(),
                    grid[2, e.RowIndex].Value.ToString(), grid[3, e.RowIndex].Value.ToString()))
                {
                    MessageBox.Show("更新失败！");
                }
            }
            if (grid.Name == "dgFuncs")
            {
                if (!DataAccess.Instance.UpdateFunction((int)grid[0, e.RowIndex].Value, grid[1, e.RowIndex].Value.ToString(), grid[2, e.RowIndex].Value.ToString(), (int)dgApp.Rows[appSelectedRow].Cells[0].Value, grid[3, e.RowIndex].Value.ToString()))
                {
                    MessageBox.Show("更新失败！");
                }
            }
        }

        #region 命令行配置
        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCmdLine_Click(object sender, EventArgs e)
        {
            string cmdLine = tbCmdLine.Text.Trim();
            string desc = tbCmdLineVoice.Text.Trim();
            string voice = tbCmdLineVoice.Text.Trim();
            if (cmdLine == string.Empty)
            {
                MessageBox.Show("请输入命令行！");
                return;
            }
            if (voice == string.Empty)
            {
                MessageBox.Show("请输入语音命令！");
                return;
            }
            if (!DataAccess.Instance.AddCommandLine(voice,cmdLine, cbConfirm.Checked))
            {
                MessageBox.Show(this, "操作失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tbCmdLineVoice.Text = string.Empty;
            tbCmdLineVoice.Text = string.Empty;
            tbCmdLine.Text = string.Empty;
            LoadCmdLine();
        }

        /// <summary>
        /// 加载命令行列表
        /// </summary>
        private void LoadCmdLine()
        {
            dgvCmdLineList.Rows.Clear();
            List<CommandLine> cmdlines = DataAccess.Instance.GetCommandLines();
            cmdlines.ForEach(e =>
                {
                    dgvCmdLineList.Rows.Add(new object[]{ e.Command, e.CmdLine, e.Description, e.NeedConfirm, "删除"});
                });
        }

        /// <summary>
        /// 点击删除时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCmdLineList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCmdLineList.Columns.Count - 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show(this, "是否确认删除？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DataAccess.Instance.DeleteCommandLine(int.Parse(dgvCmdLineList.Rows[e.RowIndex].Cells["Command"].Value.ToString())))
                    {
                        LoadCmdLine();
                    }
                    else
                    {
                        MessageBox.Show(this,"操作失败!","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void tabPage_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == "tpCmdLine")
                LoadCmdLine();
            if (e.TabPage.Name == "tpCustomed")
                LoadCustomedFunc();
        }

        /// <summary>
        /// 对textbox进编辑时改变其背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.LightYellow;
        }

        /// <summary>
        /// 当编辑框推动焦点时，改变背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        string cellOldValue;
        private void dgvCmdLineList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellOldValue = (sender as DataGridView)[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgvCmdLineList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (cellOldValue.Equals(grid[e.ColumnIndex, e.RowIndex].Value.ToString())) return;
            if (grid.Name == "dgvCmdLineList")
            {
                if (!DataAccess.Instance.UpdateCommandLine(int.Parse(grid["Command", e.RowIndex].Value.ToString()), grid["Voice", e.RowIndex].Value.ToString(), grid["CmdLine", e.RowIndex].Value.ToString(), (bool)grid["CmdConfirm", e.RowIndex].Value))
                {
                    MessageBox.Show(this, "修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grid[e.ColumnIndex, e.RowIndex].Value = cellOldValue;
                }
            }
            if (grid.Name == "dgvCustomedFunc")
            {
                if (!DataAccess.Instance.UpdateCustomedFunc(int.Parse(grid["cuCommand", e.RowIndex].Value.ToString()), grid["cuVoice", e.RowIndex].Value.ToString(), grid["cuKeys", e.RowIndex].Value.ToString()))
                {
                    MessageBox.Show(this, "修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grid[e.ColumnIndex, e.RowIndex].Value = cellOldValue;
                }
            }
        }

        #endregion


        #region 自定义功能配置
        private void btnCuAdd_Click(object sender, EventArgs e)
        {
            string keys = tbCuKeys.Text.Trim();
            string voice = tbCuVoice.Text.Trim();
            if (voice == string.Empty)
            {
                MessageBox.Show("请输入语音命令！");
                return;
            }
            if (keys == string.Empty)
            {
                MessageBox.Show("请输入快捷键！");
                return;
            }
            if (!DataAccess.Instance.AddCustomedFunc(voice, sKeys))
            {
                MessageBox.Show(this, "操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadCustomedFunc();
            tbCuKeys.Text = string.Empty;
            tbCuVoice.Text = string.Empty;
        } 

        private void LoadCustomedFunc()
        {
            dgvCustomedFunc.Rows.Clear();
            List<CustomedFunc> funcs = DataAccess.Instance.GetCustomedFunc();
            funcs.ForEach(e =>
                {
                    dgvCustomedFunc.Rows.Add(new object[] { e.Command, e.Desc, e.Keys, "删除" });
                });
        }

        private void dgvCustomedFunc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomedFunc.Columns.Count - 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show(this, "是否确认删除？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DataAccess.Instance.DeleteCustomedFunc(int.Parse(dgvCustomedFunc.Rows[e.RowIndex].Cells["cuCommand"].Value.ToString())))
                    {
                        LoadCustomedFunc();
                    }
                    else
                    {
                        MessageBox.Show(this, "操作失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion
    }
}
