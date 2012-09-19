using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Hu.WinControler
{
    internal class CommandLineControler : Controler
    {
        private List<CommandLine> cmdLines;
        public CommandLineControler()
        {
            cmdLines = DataAccess.Instance.GetCommandLines();
           // Msg.Show(cmdLines[0].Description);
        }

        public override void Send(int command)
        {
            cmdLines.ForEach(e =>
            {
                if (e.Command == command)
                {
                    if(e.NeedConfirm)
                        if (MessageBox.Show(null, "是否确认执行\"" + e.Description + "\"命令?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
                    //执行命令行
                    ExecuteCommandAsync(e.CmdLine);
                    //ExectueCommand(e.CmdLine);
                }
            });
        }

        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="comandLine">命令行</param>
        public void ExectueCommand(object comandLine)
        {
             try
            {
                ProcessStartInfo si = new ProcessStartInfo("cmd", "/c " + comandLine);
                //si.RedirectStandardOutput = true;
                si.UseShellExecute = false;
                si.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = si;
                process.Start();
            }
            catch(Exception e)
            {
                Msg.Show(e.Message);
            }
        }

        /// <summary>
        /// 异步执行命令行
        /// </summary>
        /// <param name="commandLine">命令行</param>
        public void ExecuteCommandAsync(object commandLine)
        {
            try
            {
                Thread t = new Thread(ExectueCommand);
                t.IsBackground = true;
                t.Priority = ThreadPriority.AboveNormal;
                t.Start(commandLine);
            }
            catch
            {
                // Log the exception
            }
        }
    }
}
