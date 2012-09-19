using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Win32;

namespace Hu.WinControler
{
    internal class WindowControler : Controler
    {
        public override void Send(int command)
        {
            if (command == -1)
            {
                //Win32.User32.PostQuitMessage(0);//kao为神马这个不起作用
                System.Windows.Forms.SendKeys.SendWait("%{F4}");
            }
            else
            {
                try
                {
                    Win32.User32.ShowWindow(User32.GetForegroundWindow(), (User32.SW)command);
                }
                catch
                { }
            }
        }
    }
}
