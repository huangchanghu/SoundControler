using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Hu.WinControler
{
    internal class App
    {
       // IntPtr hwnd;    //进程句柄
        Process process;
        List<AppFunction> functions = new List<AppFunction>();
        public App() { }
        public App(int command, string description,string path,bool started)
        {
            Command = command;
            Description = description;
            Path = path;
            Started = started;
        }

        //程序是否已启动
        public bool Started { get; set; }

        /// <summary>
        /// 程序主窗体句柄
        /// </summary>
        public IntPtr Handle
        {
            get { return process.MainWindowHandle;}
           // private set { this.hwnd = value; }
        }

        /// <summary>
        /// 关联的进程是否已退出
        /// </summary>
        /// <returns></returns>
        public bool HasExited
        {
            get { return process.HasExited; }
        }

        /// <summary>
        /// 应用程序的启动路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 应用程序描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 程序对应命令
        /// </summary>
        public int Command { get; set; }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command">要发送的功能命令</param>
        public void Send(int command)
        {
            SendFunction(command);
        }

        /// <summary>
        /// 发送命令,并且在此方法中修改选择应用程序标志
        /// </summary>
        /// <param name="command">要发送的命令</param>
        /// <param name="isSelectingApplication">是否处于选择程序的模式</param>
        public void Send(int command, ref bool isSelectingApplication)
        {
            throw new System.NotImplementedException("方法未实现:app.send(int,ref bool)");
        }

        /// <summary>
        /// 判断程序是否包含funtionCommand功能命令对应的功能
        /// </summary>
        /// <param name="functionCommand"></param>
        /// <returns></returns>
        public bool ContainsFunction(int functionCommand)
        {
            return functions.Exists(e => e.Command == functionCommand);
        }

        /// <summary>
        /// 执行程序功能
        /// </summary>
        /// <param name="functionCommand">功能命令</param>
        public void SendFunction(int functionCommand)
        {
                functions.ForEach(e =>
                {
                    if (e.Command == functionCommand && Handle == Win32.User32.GetForegroundWindow())
                        e.Send();
                });
        }


        #region 程序打开与关闭
        /// <summary>
        /// 启动程序
        /// </summary>
        /// <returns>启动成功则返回true，否则返回false</returns>
        public bool Start()
        {
            try
            {
                if (process == null)
                    process = Process.Start(Path);
                else
                    if (process.HasExited)
                        process.Start();
                return process != null;
            }
            catch
            {
                new Exception(string.Format("程序:\"{0}\"无法启动！",Path));
                return false;
            }
        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <returns>关闭成功则返回true,否则返回false</returns>
        public bool Close()
        {
            if (process != null && !process.HasExited)
            {
                process.CloseMainWindow();
                return process.HasExited;
            }
            else
                return false;

        } 
        #endregion


        #region 向程序添加功能
        /// <summary>
        /// 向程序添加功能
        /// </summary>
        /// <param name="func"></param>
        public void AddFunction(AppFunction function)
        {
            functions.Add(function);
        }

        /// <summary>
        /// 向程序添加功能集
        /// </summary>
        /// <param name="functions"></param>
        public void AddFunction(List<AppFunction> functions)
        {
            this.functions.AddRange(functions);
        } 
        #endregion

        public override string ToString()
        {
            return this.Description;
        }
    }
}
