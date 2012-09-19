using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace SRCTRL
{
    public partial class GridLineForm : Form
    {

        #region 生成唯一静态实例
        private static GridLineForm gridLineForm = new GridLineForm();
        public static GridLineForm GetInstance(Rectangle rec)
        {
            gridLineForm.Positioning(rec);
            return gridLineForm;
        }
        private GridLineForm()
        {
            InitializeComponent();
            InitializeRecognizer();
            Recognizing = true;
        }
        #endregion

        #region 语音识别
         private SpeechRecognitionEngine rg;

         /// <summary>
         /// 开始进行语音识别
         /// </summary>
         void InitializeRecognizer()
         {
             try
             {
                 rg = new SpeechRecognitionEngine();
                 rg.SetInputToDefaultAudioDevice();
                 rg.LoadGrammar(new DictationGrammar());
               
                 Choices posWords = new Choices();
                 posWords.Add(new string[] { "确定", "一", "二","第二", "三", "四", "五", "六", "七", "八", "九", "单击", "左键单击", "双击", "左键双击", "右键单击", "右键双击" });
                 GrammarBuilder posGrammarBuilder = new GrammarBuilder(posWords);
                 Grammar posGrammar = new Grammar(posGrammarBuilder);
                 posGrammar.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(new EventHandler<SpeechRecognizedEventArgs>(grammar_SpeechRecognized));
                 rg.LoadGrammar(posGrammar);
             }
             catch (Exception e)
             {
                 MessageBox.Show(e.Message);
             }
         }

         /// <summary>
         /// 绑定到语音识别结果事件
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         void grammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
         {
             string text = e.Result.Text;
             int index = -1;
             switch (text)
             {
                 case "确定":
                     this.Hide();
                     break;
                 case "一": index = 1; break;
                 case "第二":
                 case "二": index = 2; break;
                 case "三": index = 3; break;
                 case "四": index = 4; break;
                 case "五": index = 5; break;
                 case "六": index = 6; break;
                 case "七": index = 7; break;
                 case "八": index = 8; break;
                 case "九": index = 9; break;
                 case "单击":
                 case "左键单击":
                     this.Hide();
                       Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN, 10, 10, 0,0);
                       Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_LEFTUP, 10, 10, 0, 0);
                       break;
                 case "双击":
                 case "左键双击":
                       this.Hide();
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN, 10, 10, 0, 0);
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_LEFTUP, 10, 10, 0, 0);
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN, 10, 10, 0, 0);
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_LEFTUP, 10, 10, 0, 0);
                     break;
                 case "右键单击":
                     this.Hide();
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_RIGHTDOWN, 10, 10, 0, 0);
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_RIGHTUP, 10, 10, 0, 0);
                     break;
                 case "右键双击":
                     this.Hide();
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_RIGHTDOWN, 10, 10, 0, 0);
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_RIGHTUP, 10, 10, 0, 0);
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_RIGHTDOWN, 10, 10, 0, 0);
                     Win32.User32.mouse_event(Win32.User32.MOUSEEVENTF.MOUSEEVENTF_RIGHTUP, 10, 10, 0, 0);
                     break;

                 default: break;
             }
             if (index > 0)
                 this.Positioning(index);
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
        #endregion

        #region 网格线绘制

        private GridUnit[] grids = new GridUnit[11];    //保存风格中各个格的中点位置,边框矩形
        /// <summary>
        /// 绘制风格线
        /// </summary>
        /// <param name="e"></param>
        private void DrawGridLine()
        {
            Graphics gr = CreateGraphics();
            gr.Clear(Color.White);
            int uHeight = this.Height / 3;  //网格单元高度
            int uWidth = this.Width / 3;    //网格单元宽度
            float pointY = uHeight / 2;    //第一个网格单元中数字的起始Y坐标
            float pointX = uWidth / 2;      //第一个网格单元中数字的起始X坐标

            //水平线
            gr.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new Point(this.Width, 0));
            gr.DrawLine(new Pen(Color.Red, 2), new Point(0, uHeight * 1), new Point(this.Width, uHeight * 1));
            gr.DrawLine(new Pen(Color.Red, 2), new Point(0, uHeight * 2), new Point(this.Width, uHeight * 2));
            gr.DrawLine(new Pen(Color.Red, 2), new Point(0, uHeight * 3), new Point(this.Width, uHeight * 3));

            //垂直线
            gr.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new Point(0, this.Height));
            gr.DrawLine(new Pen(Color.Red, 2), new Point(uWidth * 1, 0), new Point(uWidth * 1, this.Height));
            gr.DrawLine(new Pen(Color.Red, 2), new Point(uWidth * 2, 0), new Point(uWidth * 2, this.Height));
            gr.DrawLine(new Pen(Color.Red, 2), new Point(uWidth * 3, 0), new Point(uWidth * 3, this.Height));

            int fontSize = uWidth / 5;
            //绘文本
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = (int)(pointX + uWidth * i);
                    int y = (int)(pointY + uHeight * j);
                    grids[j * 3 + i + 1] = new GridUnit(new Point(x, y), new Rectangle(uWidth * i, uHeight * j, uWidth, uHeight));
                    gr.DrawString((j * 3 + i + 1).ToString(), new Font(FontFamily.Families.First(), fontSize > 0 ? fontSize : 1), new SolidBrush(Color.Red), new PointF(pointX + uWidth * i, pointY + uHeight * j));
                }
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            Positioning(Screen.PrimaryScreen.Bounds);
        }

        public void Positioning(int index)
        {
            if (index == 0)
            {
                Positioning(Screen.PrimaryScreen.Bounds);
                return;
            }
            if (index > 9 || index < 0) return;
            Win32.User32.SetCursorPos(PointToScreen(grids[index].Point).X, PointToScreen(grids[index].Point).Y);
            this.Width = grids[index].Rec.Width;
            this.Height = grids[index].Rec.Height;
            this.Location = PointToScreen(grids[index].Rec.Location);
            this.InvokePaint(this, new PaintEventArgs(this.CreateGraphics(), grids[index].Rec));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGridLine();
        }

        /// <summary>
        /// 让网格线全屏显示
        /// </summary>
        public void Positioning(Rectangle rec)
        {
            this.Width = rec.Width;
            this.Height = rec.Height;
            this.Location = rec.Location;

        }

    } 
        #endregion


        #region 网格单元类
    class GridUnit
    {
        public GridUnit(Point point, Rectangle rectangle)
        {
            Rec = rectangle;
            Point = point;
        }
        public Rectangle Rec { get; set; }
        public Point Point { get; set; }
    } 
    #endregion
}
