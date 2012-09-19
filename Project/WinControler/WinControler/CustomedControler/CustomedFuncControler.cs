using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu.WinControler
{
    /// <summary>
    /// 自定义功能的控制器
    /// </summary>
    internal class CustomedFuncControler : Controler
    {
        public CustomedFuncControler()
        {
            Functions = DataAccess.Instance.GetCustomedFunc();
        }
        /// <summary>
        /// 功能集合
        /// </summary>
        public List<CustomedFunc> Functions
        {
            get;
            set;
        }
    
        public override void Send(int command)
        {
            Functions.ForEach(e =>
                {
                    if (e.Command == command)
                        e.Send();
                });
        }
    }
}
