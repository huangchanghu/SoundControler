using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu.WinControler
{
    /// <summary>
    /// 供外部调用的工具类
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 获取存在的语音命令列表
        /// </summary>
        /// <returns></returns>
        public static List<VicCmd> GetVoicCommand()
        {
            return DataAccess.Instance.GetVoiceCommand();
        }
    }
}
