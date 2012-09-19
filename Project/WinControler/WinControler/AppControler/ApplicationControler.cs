using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Hu.WinControler
{
    /// <summary>
    /// 程序控制器
    /// </summary>
    internal class ApplicationControler : Controler
    {
        private List<App> applications = DataAccess.Instance.GetApplications();   //获取应用程序列表

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command">命令代码</param>
        /// <param name="controlType">控制类型</param>
        public override void Send(int command)
        {
           Command = command;
           StartApplication(command);
           ExcuteFunction(command);
        }

        /// <summary>
        /// 发送命令,并且在此方法中修改选择应用程序标志
        /// </summary>
        /// <param name="command">要发送的命令</param>
        /// <param name="isSelectingApplication">是否处于选择程序的模式</param>
        public void Send(int command, ref bool isSelectingApplication)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 向所有已启动的程序发送功能命令
        /// </summary>
        private void ExcuteFunction(int command)
        {
           foreach(var app in applications.Where(e => e.Started))
           {
               app.SendFunction(command);
           }
        }

        /// <summary>
        /// 启动程序
        /// </summary>
        /// <param name="command">程序对应命令</param>
        public void StartApplication(int command)
        {
            try
            {
               App app = applications.Find(e => e.Command == command);
                if (app != null)
                {
                    if (app.Started)
                    {
                        IntPtr hwnd = app.Handle;
                        Win32.User32.SetForegroundWindow(hwnd);
                        Win32.User32.ShowWindow(hwnd, Win32.User32.SW.SW_SHOWNORMAL);
                    }
                    else
                    {
                        app.Start();
                        app.Started = true;
                    }
                }
            }
            catch (Exception e)
            {
                Msg.Show(e.Message);
            }
        }

        /// <summary>
        /// 将退出的程序从已启动程序列表中删除
        /// </summary>
        /// <param name="command">被删除程序对应的命令代码</param>
        public void ExitApplication(int command)
        {
            App app = applications.Find(e => e.Command == command);
            applications.Remove(app);
        }

        /// <summary>
        /// 判断程序是否已启动
        /// </summary>
        /// <param name="command">程序对应的命令代码</param>
        /// <returns>如果要启动的程序已经在已启动程序列表中则返回true，否则返回false</returns>
        //private bool HasStart(int command)
        //{
        //    App app = applications.Find(e => e.Command == command);
        //    if (app != null)
        //    {
        //        if (app.Started)
        //            return true;
        //        app.Start();
        //        app.Started = true;
        //    }
            
        //}

    }
}
