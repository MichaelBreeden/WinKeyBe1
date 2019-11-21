using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

using System.IO;
using System.Diagnostics;
namespace WinKeyBe1
{
    public partial class Form1 : Form
    {
        DateTime dtStart;
        public Form1()
        {
            InitializeComponent();
            this.DoubleClick += new EventHandler(Form1_DoubleClick);
            //this.Controls.Add(button1);
            //Process myProcess;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Falderall");
            //CalculatorMakePretty();
            //timer1.Start();

            textBoxStart.Text = DateTime.Now.ToShortTimeString();
            textBoxInterval.Text = timer1.Interval.ToString();
            //Process myProcess;
            if (Program.bWasStarted == false)
                doWriteKey("strToWrite");
            else
                Program.bWasStarted = true;
            timer1.Start();
            dtStart = DateTime.Now;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Send a key to the button when the user double-clicks anywhere  
        // on the form. 
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            // Send the enter key to the button, which raises the click  
            // event for the button. This works because the tab stop of  
            // the button is 0.
            SendKeys.Send("{ENTER}");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            // Get a handle to the Calculator application. The window class 
            // and window name were obtained using the Spy++ tool.
            IntPtr calculatorHandle = FindWindow("CalcFrame", "Calculator");

            // Verify that Calculator is a running process. 
            if (calculatorHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running.");
                return;
            }

            // Make Calculator the foreground application and send it  
            // a set of calculations.
            SetForegroundWindow(calculatorHandle);
            SendKeys.SendWait("9");
            */
            if (Program.myProcess.Responding)
            {
                Program.iCounter++;
                textBoxCount.Text = Program.iCounter.ToString();
                System.Windows.Forms.SendKeys.SendWait("1");
            }
            else
            {
                Program.myProcess.Kill();
            }

            string strTime = textBoxDone.Text;
            int iTime = 0;
            if (Int32.TryParse(strTime, out iTime) == true)
            {
                if (iTime > 0)
                {
                    DateTime dtNow = DateTime.Now;
                    DateTime dtThen = dtStart.AddMinutes((double)iTime);
                    if (dtThen < DateTime.Now)
                    {
                        System.Windows.Forms.SendKeys.SendWait("Done:" + DateTime.Now.ToShortTimeString());
                        this.Close();
                    }
                }
            
            }
        }

        void doWriteKey(string strToWrite)
        {
            //Process myProcess = new Process();
            Program.myProcess = new Process();

            Program.myProcess.StartInfo.FileName = @"notepad.exe";
            Program.myProcess.EnableRaisingEvents = true;

            Program.myProcess.Start();
            Program.myProcess.WaitForInputIdle(1000);
            if (Program.myProcess.Responding)
                System.Windows.Forms.SendKeys.SendWait("hithere");
            else
                Program.myProcess.Kill();        
        }



        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Send a series of key presses to the Calculator application. 
        //private void button1_Click(object sender, EventArgs e)
        private void CalculatorMakePretty()
        {
            // Get a handle to the Calculator application. The window class 
            // and window name were obtained using the Spy++ tool.
            //IntPtr calculatorHandle = FindWindow("CalcFrame", "Calculator");
            IntPtr calculatorHandle = FindWindow("NoteFrame", "NotePad");

            // Verify that Calculator is a running process. 
            if (calculatorHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running.");
                return;
            }

            // Make Calculator the foreground application and send it  
            // a set of calculations.
            SetForegroundWindow(calculatorHandle);
            SendKeys.SendWait("111");
            SendKeys.SendWait("*");
            SendKeys.SendWait("11");
            SendKeys.SendWait("=");
        }

        //private void textBoxInterval_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void textBoxNewInterval_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            int iTimerInterval = timer1.Interval;
            int iInterval = 0;
            if (Int32.TryParse(textBoxNewInterval.Text, out iInterval) == true)
            {
                if (iInterval > 2)
                {
                    timer1.Interval = iInterval * 1000;
                    textBoxInterval.Text = iInterval.ToString();
                }
            }
            else
            {
                textBoxNewInterval.Text = "";
            }
        }

        private void buttonSetDone_Click(object sender, EventArgs e)
        {
            ;
        }

    }
}
