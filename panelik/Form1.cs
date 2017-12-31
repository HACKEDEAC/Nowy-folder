using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Management;
using MetroFramework.Forms;


namespace panelik
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public string GetHDDSerial()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                if (wmi_HD["SerialNumber"] != null)
                    return wmi_HD["SerialNumber"].ToString();
            }

            return string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("HWID: " + Environment.NewLine + GetHDDSerial(), Text);
            Clipboard.SetText(GetHDDSerial());
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            System.Net.WebClient Webforfuckinlog = new System.Net.WebClient();
            DateTime now = DateTime.Now;

            //Webforfuckinlog.DownloadString("" + GetHDDSerial() + " = " + " = " + now + "");
            System.Net.WebClient Wc = new System.Net.WebClient();
            string pplbanned = Wc.DownloadString("http://listahackeda.cba.pl/HWID.txt");
            string pplallowed = Wc.DownloadString("http://listahackeda.cba.pl/AHWID.TXT");
            if (pplbanned.Contains(GetHDDSerial()))
            {
                MessageBox.Show("You have been banned !", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            else if (pplallowed.Contains(GetHDDSerial()))
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();

            }
            else
            {
                MessageBox.Show("You're not whitelisted, make sure you sent Your" +
                    " Hwid to [name] and you bought our [product,exploit,hub etc].", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(-1);

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
