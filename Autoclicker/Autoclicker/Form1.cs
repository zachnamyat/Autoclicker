using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Timers;

namespace Autoclicker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        bool isPressed = false;

        static void Clicker()
        {
            System.Threading.Thread.Sleep(1000);
            SetCursorPos(MousePosition.X, MousePosition.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, MousePosition.X, MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, MousePosition.X, MousePosition.Y, 0, 0);
        }

        public Form1()
        {
            InitializeComponent();
            this.StartButton.Click += new System.EventHandler(this.button_Click);

            Dur.Items.Add("Seconds");
            Dur.Items.Add("Milliseconds");
            Dur.SelectedIndex = 0;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;

            switch(thisButton.Name)
            {
                case "StartButton":
                    Dur.SelectedIndex = 0;
                    thisButton.Name = "StopButton";
                    thisButton.Text = "Stop";
                    isPressed = true;
                    while (isPressed == true)
                    {
                        //DO NOT START PROGRAM. IT WILL FUCK YOU
                        //Thread t = new Thread(Clicker);
                        //t.Start();
                    }
                    break;

                case "StopButton":
                    Dur.SelectedIndex = 1;
                    thisButton.Name = "StartButton";
                    thisButton.Text = "Start";
                    isPressed = false;
                    break;
            }
        }
    }
}
