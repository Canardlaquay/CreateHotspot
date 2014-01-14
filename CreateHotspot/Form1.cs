using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateHotspot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1 || textBox1.Text.Length > 32)
            {
                MessageBox.Show("SSID trop court/long");
            }
            else if (textBox2.Text.Length < 8 || textBox2.Text.Length > 64)
            {
                MessageBox.Show("Mot de passe trop court/long");
            }
            else
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C netsh wlan set hostednetwork mode =allow ssid=" + textBox1.Text + " key=" + textBox2.Text;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo2.FileName = "cmd.exe";
                startInfo2.Arguments = "/C netsh wlan start hostednetwork";
                process2.StartInfo = startInfo2;
                process2.Start();
                label4.ForeColor = Color.Green;
                label4.Text = "Running";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process3 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo3 = new System.Diagnostics.ProcessStartInfo();
            startInfo3.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo3.FileName = "cmd.exe";
            startInfo3.Arguments = "/C netsh wlan stop hostednetwork";
            process3.StartInfo = startInfo3;
            process3.Start();
            process3.WaitForExit();
            label4.ForeColor = Color.Red;
            label4.Text = "Stopped";
        }
    }
}
