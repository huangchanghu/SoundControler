using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu.WinControler
{
    internal class CommandLine
    {
        /// <summary>
        /// 命令代码
        /// </summary>
        public int Command { get; set; }
        /// <summary>
        /// 命令行
        /// </summary>
        public string CmdLine { get; set; }
     
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set;}

        /// <summary>
        /// 执行前是否需确认
        /// </summary>
        public bool NeedConfirm { get; set; }
    }
}
