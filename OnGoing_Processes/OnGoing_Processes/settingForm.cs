using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace OnGoing_Processes
{
    public partial class settingForm : Form
    {
        private const string APPLICATION_NAME = "ongoing_Procs";
        private RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        public settingForm(double o)
        {
            InitializeComponent();

            tBOcapacy.Value = (int)o;
            MyProperty = (int)o;
            label1.Text = string.Format("투명도 {0}%", MyProperty * 10);

            this.cBAutoStart.Checked = IsAutoStartApplication(APPLICATION_NAME);
        }

        #region 투명도
        private void tBOcapacy_Scroll(object sender, EventArgs e)
        {
            MyProperty = tBOcapacy.Value;
            label1.Text = string.Format("투명도 {0}%", MyProperty * 10);
        }

        private int o;

        public int MyProperty
        {
            get { return o; }
            set { o = value; }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        } // 닫기

        #region 자동실행

        private void cBAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cBAutoStart.Checked)
            {
                SetAutoStartApplication(APPLICATION_NAME, Application.ExecutablePath);
            }
            else
            {
                ResetAutoStartApplication(APPLICATION_NAME);
            }
        }

        public void SetAutoStartApplication(string applicationName, string applicationFilePath)
        {
            if (registryKey.GetValue(applicationName) == null)
            {
                registryKey.SetValue(applicationName, applicationFilePath);
            }
        } // 자동실행 

        public void ResetAutoStartApplication(string applicationName)
        {
            if (registryKey.GetValue(applicationName) != null)
            {
                registryKey.DeleteValue(applicationName, false);
            }
        } // 자동실행 취소
        
        public bool IsAutoStartApplication(string applicationName)
        {
            return registryKey.GetValue(applicationName) != null;
        } // 자동실행 어플리케이션 여부
        #endregion 
    }
}
