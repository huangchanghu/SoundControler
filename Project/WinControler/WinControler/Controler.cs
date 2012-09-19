using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu.WinControler
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    internal abstract class Controler
    {
        private int _command;

        /// <summary>
        /// 命令
        /// </summary>
        public int Command
        {
            get
            {
                return this._command;
            }
            set
            {
                this._command = value;
            }
        }

        /// <summary>
        /// 启动命令对应的功能
        /// </summary>
        /// <param name="command">要发送的功能命令</param>
        /// <param name="controlType">控制类型</param>
        public abstract void Send(int command);
    }
}
