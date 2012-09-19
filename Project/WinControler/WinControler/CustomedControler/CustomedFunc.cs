using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu.WinControler
{
    internal class CustomedFunc
    {
        /// <summary>
        /// 快捷键
        /// </summary>
        public string Keys
        {
            get;
            set;
        }

        /// <summary>
        /// 功能描述
        /// </summary>
        public string Desc
        {
            get;
            set;
        }

        /// <summary>
        /// 功能命令代码
        /// </summary>
        public int Command
        {
            get;
            set;
        }

        /// <summary>
        /// 执行此功能
        /// </summary>
        public void Send()
        {
            try
            {
                System.Windows.Forms.SendKeys.SendWait(Keys);
            }
            catch (Exception e)
            {
                Msg.Show(e.Message);
            }
        }

        public override string ToString()
        {
            return this.Desc;
        }
    }
}
