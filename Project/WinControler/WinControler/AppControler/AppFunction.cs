using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hu.WinControler
{
    /// <summary>
    /// 被控制程序的功能项
    /// 在App类中被用
    /// </summary>
    internal class AppFunction
    {

        private List<short> keys;    //功能对应虚拟键集，用此形式则不用sKeys
        private string sKeys;   //按键形式则不用keys

        /// <summary>
        /// 字符串形式的按键命令
        /// </summary>
        public string SKeys
        {
            get { return sKeys; }
            set { sKeys = value; }
        }


        /// <summary>
        /// 功能对应程序的命令
        /// </summary>
        public int AppCmd{get;set;}
        

        /// <summary>
        /// 功能描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 功能对应命令
        /// </summary>
        public int Command { get; set; }

        /// <summary>
        /// 实现功能的虚拟键,请保持集合中元素的顺序，否则执行时可能会出现不可预期的错误
        /// </summary>
        public List<short> Keys
        {
            get
            {
                return this.keys;
            }
            set
            {
                this.keys = value;
            }
        }

        public void AddKey(short key)
        {
            this.keys.Add(key);
        }

        /// <summary>
        /// 将此功能发送到对应程序
        /// </summary>
        /// <param name="hwnd">要实现此功能的程序进程的句柄</param>
        public void Send(IntPtr hwnd)
        {
            //此方法尚未实现，未解决如何向不活动窗口发送击键消息
            //Methods.SendKeysDown(this.Keys.ToArray());
            //Methods.SendKeysUp(this.Keys.ToArray());
            throw new NotImplementedException("\"AppFunction.Send(IntPtr hwnd)\"此方法未实现");
        }

        /// <summary>
        /// 向活动应用程序发送击键
        /// </summary>
        public void Send()
        {
           try
            {
                SendKeys.SendWait(SKeys);
            }
            catch (Exception e)
            {
                Msg.Show(e.Message);
            }
        }

        public override string ToString()
        {
            return this.Description;
        }

    }
}
