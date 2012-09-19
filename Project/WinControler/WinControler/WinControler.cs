using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hu.WinControler
{
    /// <summary>
    /// 此类为对外的接口,实现的功能有:程序控制(程序启动和功能控制),键盘控制,鼠标控制,鼠标定位.
    /// 各种功能模式的选择将根据传入的命令自动选择
    /// </summary>
    public class WinControler
    {
        List<Controler> controlers = new List<Controler>();
        public WinControler()
        {
            controlers.Add(new CommandLineControler());
            controlers.Add(new ApplicationControler());
            controlers.Add(new WindowControler());
            controlers.Add(new CustomedFuncControler());
        }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command">要发送的命令</param>
        public void SendCommand(int command)
        {
            //向每个控制器发送命令，拥有此命令的功能将被对应控制器触发
            controlers.ForEach(e => e.Send(command));
        }

       
    }
}
