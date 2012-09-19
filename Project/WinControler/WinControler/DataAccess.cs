using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hu.WinControler
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    internal  class DataAccess
    {
        private string connectString;   //数据库连接字符串
        

        private DataAccess()
        {
            connectString = @"Data Source=.\Hudb;Pooling=true;FailIfMissing=false";
        }


        #region 利用单例模式生成唯一实例
        private static DataAccess dataAccess = new DataAccess();
        /// <summary>
        /// 此类的唯一实例
        /// </summary>
        public static DataAccess Instance
        {
            get { return dataAccess; }
        } 
        #endregion

        #region 数据库查询

        /// <summary>
        /// 从数据库获取一个已配置的程序，并决定是否马上启动该程序
        /// </summary>
        /// <param name="command">已配置的该程序对应的命令</param>
        /// <param name="setup">setup为true则马上启动该程序，false则不启动</param>
        /// <returns>返回获取的程序</returns>
        public App GetApplication(int command, bool setup)
        {
            string sql = string.Format("select * from [App] where cmd={0}", command);
            DataSet ds = ExecuteQuery(sql);
            DataRow row = ds.Tables[0].Rows[0];
            App app = new App(int.Parse(row["Command"].ToString()), row["Desc"].ToString(), row["Path"].ToString(),false);
            app.AddFunction(GetFunctions(command));
            
            if (setup)
            {
                if (!app.Start())
                    throw new Exception("启动失败！");
            }
            return app;
        }

        /// <summary>
        /// 获取程序列表
        /// </summary>
        /// <returns></returns>
        public List<App> GetApplications()
        {
            List<App> apps = new List<App>();
            DataSet ds = ExecuteQuery("select * from [App]");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                apps.Add(new App { Command = int.Parse(row["Cmd"].ToString()), Description = row["Desc"].ToString(), Path = row["Path"].ToString() , Started = false});
            }
            return apps;
        }

        /// <summary>
        /// 获取已配置的程序的功能项集合
        /// </summary>
        /// <param name="AppCommand">将要获取功能项集合的程序对应的命令</param>
        /// <returns>功能的集合</returns>
        public List<AppFunction> GetFunctions(int AppCommand)
        {
         
            string sql = string.Format("select * from [Func] where App={0}", AppCommand);
            List<AppFunction> funcs = new List<AppFunction>();
            DataSet ds = ExecuteQuery(sql);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                AppFunction func = new AppFunction();
                func.Command = int.Parse(row["Command"].ToString());
                func.Description = row["Desc"].ToString();
                func.AppCmd = int.Parse(row["App"].ToString());
                func.SKeys = row["Keys"].ToString();
                funcs.Add(func);
            }
            return funcs;
        }

        /// <summary>
        /// 获取语音命令列表
        /// </summary>
        /// <returns></returns>
        public List<VicCmd> GetVoiceCommand()
        {
            List<VicCmd> vcmd = new List<VicCmd>();
            DataSet ds = ExecuteQuery("select * from viccmd");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                VicCmd vc = new VicCmd { Description = row["Desc"].ToString(), Command = int.Parse(row["Cmd"].ToString()) };
                vcmd.Add(vc);
            }
            return vcmd;
        }

        /// <summary>
        /// 获取已配置的所有命令行项
        /// </summary>
        /// <returns></returns>
        public List<CommandLine> GetCommandLines()
        {
            List<CommandLine> cmdLines = new List<CommandLine>();
            DataSet ds = ExecuteQuery("select * from [CommandLine]");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string t = row["Confirm"].ToString();
                CommandLine cLine = new CommandLine { Command = int.Parse(row["Command"].ToString()), CmdLine = row["CmdLine"].ToString(), Description = row["Description"].ToString(), NeedConfirm = bool.Parse(t == string.Empty ? "false" : t) };
                cmdLines.Add(cLine);
            }
            return cmdLines;
        }

        /// <summary>
        /// 获取自定义的功能项
        /// </summary>
        /// <returns></returns>
        public List<CustomedFunc> GetCustomedFunc()
        {
            List<CustomedFunc> funcs = new List<CustomedFunc>();
            DataSet ds = ExecuteQuery("select * from [CustomedFunc]");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CustomedFunc func = new CustomedFunc { Command = int.Parse(row["Command"].ToString()), Desc = row["Desc"].ToString(), Keys = row["Keys"].ToString() };
                funcs.Add(func);
            }
            return funcs;
        }


        /// <summary>
        /// 执行查询,并返回结果集
        /// </summary>
        /// <param name="sql">执行数据库查询的sql语句</param>
        /// <returns>查询结果数据集</returns>
        public DataSet ExecuteQuery(string sql)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(connectString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        /// <summary>
        /// 执行查询，但只返回第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(connectString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

        #endregion

        #region 数据库修改

        /// <summary>
        /// 向数据库添加新配置的程序
        /// </summary>
        /// <param name="description">程序描述</param>
        /// <param name="path">程序启动路径</param>
        /// /// <param name="command">程序命令代码</param>
        /// <returns>若添加成功则返回为此程序生成的命令代码，若添加失败则返回-1</returns>
        public int AddApplication(string description, string path,int command)
        {
            string sql = string.Format("insert into App ([Cmd],[Desc],[Path]) values ({0},'{1}','{2}')",
                command,description,path);
            if (ExecuteNonQuery(sql) > 0)
                return command;
            else
                return -1;
        }

        /// <summary>
        /// 向数据库添加新配置的程序，并添加对应的语音控制配置
        /// </summary>
        /// <param name="description">程序描述</param>
        /// <param name="path">程序启动路径</param>
        /// <param name="voiceCommand">语音命令代码</param>
        /// <param name="voiceDescription">语音描述</param>
        /// <returns>若添加成功则返回为此程序生成的命令代码，若添加失败则返回-1</returns>
        public int AddApplication(string description, string path,string voiceDescription)
        {
            int command = GetCommand(voiceDescription);
            if (command < 0) return -1;
            return AddApplication(description, path, command);
        }


        /// <summary>
        /// 删除一个程序配置项
        /// </summary>
        /// <param name="appCommand">程序命令代码</param>
        /// <returns>受影响的行数</returns>
        public int DeleteApplication(int appCommand)
        {
            ExecuteNonQuery("delete from Func where App=" + appCommand);
            return ExecuteNonQuery(string.Format("delete from app where Cmd={0}", appCommand));
         }

        /// <summary>
        /// 修改程序配置项
        /// </summary>
        /// <param name="cmd">程序命令代码</param>
        /// <param name="description">程序描述</param>
        /// <param name="path">程序启动路径</param>
        /// <param name="voiceDesription">程序对应的语音描述</param>
        /// <returns></returns>
        public bool UpdateApplication(int cmd, string description, string path, string voiceDesription)
        {
            DeleteApplication(cmd);
            return AddApplication(description,path,voiceDesription) >= 0;
        }

        /// <summary>
        /// 添加一个功能项
        /// </summary>
        /// <param name="appCmd">功能对应程序的命令代码</param>
        /// <param name="description">功能描述</param>
        /// <param name="keys">功能对应快捷键</param>
        /// <param name="voiceDescription">功能对应语音描述</param>
        /// <returns></returns>
        public bool AddFunction(int appCmd, string description, string keys, string voiceDescription)
        {
            int cmd = GetCommand(voiceDescription);
            if (cmd >= 0)
            {
                int count = (int)ExecuteNonQuery(string.Format("insert into [func] (cmd,keys,desc,app) values ({0},'{1}','{2}',{3})", cmd, keys, description, appCmd));
                return count > 0;
            }
            else
                return false;
        }

        /// <summary>
        /// 删除一个功能项
        /// </summary>
        /// <param name="command">功能命令代码</param>
        /// <param name="appCommand">此功能对应程序的命令代码</param>
        /// <returns>受影响的行数</returns>
        public bool DeleteFunction(int command, int appCommand)
        {
            return ExecuteNonQuery(string.Format("delete from [func] where cmd={0} and app={1}", command, appCommand)) > 0;
        }

        /// <summary>
        /// 更新一个功能配置项
        /// </summary>
        /// <param name="command">功能命令代码</param>
        /// <param name="description">功能描述</param>
        /// <param name="keys">功能快捷键</param>
        /// <param name="appCommand">功能对应的程序命令代码</param>
        /// <param name="voiceDescription">此功能的语音描述</param>
        /// <returns></returns>
        public bool UpdateFunction(int command, string description, string keys, int appCommand, string voiceDescription)
        {
            if (!DeleteFunction(command, appCommand)) return false;
            return AddFunction(appCommand,description,keys,voiceDescription);
        }

        /// <summary>
        /// 添加命令行配置项
        /// </summary>
        /// <param name="voice">语音命令</param>
        /// <param name="description">备注</param>
        /// <param name="commandLine">命令行</param>
        /// <returns></returns>
        public bool AddCommandLine(string voice, string commandLine, bool confirm)
        {
            try
            {
                int command = GetCommand(voice);
                return ExecuteNonQuery(string.Format("insert into [CommandLine] ([Description],[CmdLine],[Command],[Confirm]) values " +
                    "('{0}','{1}',{2},{3})", voice, commandLine, command,confirm?1:0)) > 0;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除一个命令行配置项
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool DeleteCommandLine(int command)
        {
            return ExecuteNonQuery(string.Format("delete from [CommandLine] where [Command] = {0}",command)) > 0;
        }

        /// <summary>
        /// 修改一个命令行配置项
        /// </summary>
        /// <param name="voice"></param>
        /// <param name="description"></param>
        /// <param name="commandLine"></param>
        /// <returns></returns>
        public bool UpdateCommandLine(int command, string voice, string commandLine, bool confirm)
        {
            if (DeleteCommandLine(command))
            {
                return AddCommandLine(voice,commandLine, confirm);
            }
            return false;
        }

        /// <summary>
        /// 添加自定义功能项
        /// </summary>
        /// <param name="voice"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool AddCustomedFunc(string voice, string keys)
        {
            int command = GetCommand(voice);
            if (command < 0) return false;
            return ExecuteNonQuery(string.Format("insert into [CustomedFunc] ([Command],[Desc],[Keys]) values ({0},'{1}','{2}')", command, voice, keys)) > 0;
        }
    
        /// <summary>
        /// 删除一个自定义功能项
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool DeleteCustomedFunc(int command)
        {
            return ExecuteNonQuery(string.Format("delete from [CustomedFunc] where [Command]={0}", command)) > 0;
        }

        /// <summary>
        /// 更新自定义功能项
        /// </summary>
        /// <param name="command"></param>
        /// <param name="voice"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool UpdateCustomedFunc(int command, string voice, string keys)
        {
            if (!DeleteCustomedFunc(command)) return false;
            return AddCustomedFunc(voice, keys);
        }

        
        /// <summary>
        /// 插入语音条目，并返回生成的command
        /// </summary>
        /// <param name="voice"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetCommand(string voice)
        {
            string sql = string.Format("select [Cmd] from [VicCmd] where [Desc]='{0}'",voice);
            object o = ExecuteScalar(sql);
            if (o == null)
            {
                ExecuteNonQuery(string.Format("insert into [VicCmd] ([Desc]) values('{0}')", voice));
                o = ExecuteScalar(sql);
            }
            if (o == null)
                return -1;
            else
                return int.Parse(o.ToString()); ;
        }

       
        /// <summary>
        /// 执行没有返回结果的sql命令,用于数据库数据的添加、修改、删除
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <returns>受影响的行数</returns>
        private int ExecuteNonQuery(string sql)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(connectString))
            {
                cnn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql,cnn);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
