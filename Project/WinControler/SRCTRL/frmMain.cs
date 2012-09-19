using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Recognition;
using Hu.WinControler;
using Hu.WinControler.Forms;
using System.Runtime.InteropServices;
using System.Threading;


namespace SRCTRL
{
    public partial class frmMain : Form
    {
        private SpeechRecognitionEngine rg;//语音识别引擎
        Dictionary<string, VicCmd> vicDic = new Dictionary<string, VicCmd>();   //语音命令字典
        Dictionary<string, string> keyDic = new Dictionary<string, string>();   //键盘按键映射字典
        string[] phrases;//语音词语
        WinControler controler;
        public frmMain()
        {
            InitializeComponent();
            LoadVoiceCommand();
            controler = new WinControler();
            
            #region 不可视按键的映射
            keyDic.Add("Back", "{BACKSPACE}");
            keyDic.Add("Pause", "{BREAK}");
            keyDic.Add("Capital", "{CAPSLOCK}");
            keyDic.Add("Delete", "{DELETE}");
            keyDic.Add("Down", "{DOWN}");
            keyDic.Add("End", "{END}");
            keyDic.Add("Return", "{ENTER}");
            keyDic.Add("Escape", "{ESC}");
            keyDic.Add("Help", "{HELP}");//未知
            keyDic.Add("Home", "{HOME}");
            keyDic.Add("Insert", "{INSERT}");
            keyDic.Add("Left", "{LEFT}");
            keyDic.Add("NumLock", "{NUMLOCK}");
            keyDic.Add("Next", "{PGDN}");
            keyDic.Add("PageUp", "{PGUP}");
            keyDic.Add("Print", "{PRTSC}");//未知
            keyDic.Add("Right", "{RIGHT}");
            keyDic.Add("Scroll", "{SCROLLLOCK}");
            keyDic.Add("Table", "{TAB}");//未知
            keyDic.Add("Up", "{UP}");
            keyDic.Add("F1", "{F1}");
            keyDic.Add("F2", "{F2}");
            keyDic.Add("F3", "{F3}");
            keyDic.Add("F4", "{F4}");
            keyDic.Add("F5", "{F5}");
            keyDic.Add("F6", "{F6}");
            keyDic.Add("F7", "{F7}");
            keyDic.Add("F8", "{F8}");
            keyDic.Add("F9", "{F9}");
            keyDic.Add("F10", "{F10}");
            keyDic.Add("F11", "{F11}");
            keyDic.Add("F12", "{F12}");
            keyDic.Add("F13", "{F13}");
            keyDic.Add("F14", "{F14}");
            keyDic.Add("F15", "{F15}");
            keyDic.Add("F16", "{F16}");
            keyDic.Add("Add", "{ADD}");
            keyDic.Add("Subtract", "{SUBTRACT}");
            keyDic.Add("Multiply", "{MULTIPLY}");
            keyDic.Add("Divide", "{DIVIDE}");
            keyDic.Add("Shift", "+");
            keyDic.Add("Control", "^");
            keyDic.Add("Alt", "%");
            keyDic.Add("+", "{+}");
            keyDic.Add("^", "{^}");
            keyDic.Add("%", "{%}");
            keyDic.Add("~", "{~}");
            keyDic.Add("{", "{{}");
            keyDic.Add("}", "{}}");
            keyDic.Add("(", "{(}");
            keyDic.Add(")", "{)}");
            
            
            #endregion
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeRecognizer(); //初始化语音识别引擎
            button1.PerformClick(); //激发开始识别按钮的点击事件
        }

        #region 语音识别相关
        /// <summary>
        /// 加载语音词语列表
        /// </summary>
        private void LoadVoiceCommand()
        {
            List<VicCmd> cmds = Tools.GetVoicCommand();
            List<string> pr = new List<string>();
            vicDic.Clear();
            cmds.ForEach(e => 
            {
                vicDic.Add(e.Description, e);
                pr.Add(e.Description);
            });
            
            //添加窗口控制项
            vicDic.Add("关闭窗口", new VicCmd {  Command=-1, Description="关闭窗口"});
            vicDic.Add("最大化", new VicCmd {  Command=(int)Win32.User32.SW.SW_MAXIMIZE, Description="最大化"});
            vicDic.Add("最小化", new VicCmd {  Command = (int)Win32.User32.SW.SW_MINIMIZE, Description = "最小化"});
            vicDic.Add("还原", new VicCmd {  Command = (int)Win32.User32.SW.SW_SHOWNORMAL, Description = "还原"});
            pr.Add("关闭窗口");
            pr.Add("最大化");
            pr.Add("最小化");
            pr.Add("还原");
            phrases = pr.ToArray();
            listBox1.DataSource = pr;
        }

        string startRecognizeText = "开始识别";
        string stopRecognizeText = "停止识别";
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(startRecognizeText))
            {
                Recognizing = true;
                button1.Text = stopRecognizeText;
            }
            else
            {
                Recognizing = false;
                button1.Text = startRecognizeText;
            }
        }

        
        /// <summary>
        /// 初始化语音识别引擎各项参数
        /// </summary>
        void InitializeRecognizer()
        {
            try
            {
               
                //构造语法
                Choices words = new Choices();
                words.Add(phrases);
                GrammarBuilder gb = new GrammarBuilder(words);
                Grammar grammar = new Grammar(gb);

                grammar.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(grammar_SpeechRecognized);
                rg = new SpeechRecognitionEngine();
                rg.SetInputToDefaultAudioDevice();
                rg.LoadGrammar(grammar);
                rg.LoadGrammar(new DictationGrammar());
               

                #region 鼠标定位识别语法加载
                Choices posWords = new Choices();
                posWords.Add(new string[] { "窗口网格", "窗口网格", "移动鼠标", "确定", "一", "二", "三", "四", "五", "六", "七", "八", "九", "单击", "左键单击", "双击", "左键双击", "右键单击", "右键双击" });
                GrammarBuilder posGrammarBuilder = new GrammarBuilder(posWords);
                Grammar posGrammar = new Grammar(posGrammarBuilder);
                posGrammar.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(new EventHandler<SpeechRecognizedEventArgs>(posGrammar_SpeechRecognized));
                rg.LoadGrammar(posGrammar);
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        bool recognizing;
        /// <summary>
        /// 启动或停止识别
        /// </summary>
        bool Recognizing
        {
            get
            {
                return recognizing;
            }
            set
            {
                try
                {
                    if (value)
                    {
                        rg.RecognizeAsync(RecognizeMode.Multiple);
                    }
                    else
                    {
                        rg.RecognizeAsyncStop();
                    }
                    recognizing = value;
                }
                catch (Exception e)
                {
                    MessageBox.Show("操作失败！\r\n" + e.Message);
                }
            }
        }


        /// <summary>
        /// 绑定到语音识别结果事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            VicCmd vc = vicDic[e.Result.Text];
            lbRecognizedText.Text = e.Result.Text;
            Thread t = new Thread(InvokeControlerAsync);
            t.Start(vc);
        }

        private void InvokeControlerAsync(object arg)
        {
            VicCmd vc = arg as VicCmd;
            if (vc != null)
                controler.SendCommand(vc.Command);
        } 
        #endregion

        /// <summary>
        /// 绑定到“配置”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         private void button2_Click(object sender, EventArgs e)
         {
             new MainConfigForm().ShowDialog(this);
             LoadVoiceCommand();
             Recognizing = false;
             InitializeRecognizer();
             Recognizing = true;
         }

      
        #region 鼠标定位相关
        // private SpeechRecognitionEngine mouseSR;
      
        
         private void posGrammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
         {
             lbRecognizedText.Text = e.Result.Text;
             Thread t = new Thread(ShowGridLine);
             t.Start(e.Result.Text);
         }
        

         [DllImport("User32.dll")]
         public static extern bool GetWindowRect(IntPtr hwnd, out Win32.GDI32.RECT rect);

          public void ShowGridLine(object text)
         {
             Rectangle rectangle = new Rectangle();
             switch (text.ToString())
             {
                 case "屏幕网格":
                 case "移动鼠标":
                     rectangle = Screen.PrimaryScreen.Bounds;
                     break;
                 case "窗口网格":
                     Win32.GDI32.RECT rec;
                     if (GetWindowRect(Win32.User32.GetForegroundWindow(), out rec))
                     {
                         rectangle = new Rectangle(rec.Left, rec.Top, rec.Right - rec.Left, rec.Bottom - rec.Top);
                         lbRecognizedText.Text = rec.Left + " " + rec.Top.ToString() + " " + rectangle.Width + " " + rectangle.Height;
                     }
                     break;
                 default:
                     return;
             }
             if (rectangle != null)
                 Application.Run(GridLineForm.GetInstance(rectangle));
              
             
         }
        #endregion

        //退出程序
         private void btnExit_Click(object sender, EventArgs e)
         {
             Application.Exit();
         }
    }
}
