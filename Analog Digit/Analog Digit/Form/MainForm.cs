using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMMONS;

namespace Analog_Digit
{
    public partial class MainForm : Form
    {
        public AutoForm auto;
        public SelfForm self;
        public LogForm log;
        public SettingForm set;
        public OptionForm opt;
        public Analog analog;

        public string ErrorMsg = null;

        public MainForm()
        {
            InitializeComponent();
            analog = new Analog();

            if (analog.Connect(ref ErrorMsg))
            {
                MessageBox.Show("Connect", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AutoFormOpen();
                panel4.Height = 637;
            }
            else
            {
                MessageBox.Show("NI USB-6001을 연결해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CloseEveryForm()
        {
            BTN_AutoForm.Enabled = true;
            BTN_SelfForm.Enabled = true;
            BTN_LogForm.Enabled = true;
            BTN_SettingForm.Enabled = true;
            BTN_OptionForm.Enabled = true;

            if(auto != null)
            {
                auto.Close();
                auto.Dispose();
                auto = null;
            }
            if(self != null)
            {
                self.Close();
                self.Dispose();
                self = null;
            }
            if(log != null)
            {
                log.Close();
                log.Dispose();
                log = null;
            }
            if(set != null)
            {
                set.Close();
                set.Dispose();
                set = null;
            }
            if(opt != null)
            {
                opt.Close();
                opt.Dispose();
                opt = null;
            }
        }

        public void AutoFormOpen()
        {
            auto = new AutoForm(analog);
            auto.TopLevel = false;
            auto.Parent = dockingPannel;
            auto.FormBorderStyle = FormBorderStyle.None;
            auto.Show();
            BTN_AutoForm.Enabled = false;
        }

        public void SelfFormOpen()
        {
            self = new SelfForm(analog);
            self.TopLevel = false;
            self.Parent = dockingPannel;
            self.FormBorderStyle = FormBorderStyle.None;
            self.Show();
            BTN_SelfForm.Enabled = false;
        }

        public void LogFormOpen()
        {
            log = new LogForm();
            log.TopLevel = false;
            log.Parent = dockingPannel;
            log.FormBorderStyle = FormBorderStyle.None;
            log.Show();
            BTN_LogForm.Enabled = false;
        }

        public void SettingFormOpen()
        {
            set = new SettingForm();
            set.TopLevel = false;
            set.Parent = dockingPannel;
            set.FormBorderStyle = FormBorderStyle.None;
            set.Show();
            BTN_SettingForm.Enabled = false;
        }

        public void OptionFormOpen()
        {
            opt = new OptionForm();
            opt.TopLevel = false;
            opt.Parent = dockingPannel;
            opt.FormBorderStyle = FormBorderStyle.None;
            opt.Show();
            BTN_OptionForm.Enabled = false;
        }

        private void BTN_AutoForm_Click(object sender, EventArgs e)
        {
            CloseEveryForm();
            AutoFormOpen();
            panel4.Height = 637;
        }

        private void BTN_SelfForm_Click(object sender, EventArgs e)
        {
            CloseEveryForm();
            SelfFormOpen();
            panel4.Height = 717;
        }

        private void BTN_LogForm_Click(object sender, EventArgs e)
        {
            CloseEveryForm();
            LogFormOpen();
            panel4.Height = 455;
        }

        private void BTN_SettingForm_Click(object sender, EventArgs e)
        {
            CloseEveryForm();
            SettingFormOpen();
            panel4.Height = 467;
        }

        private void BTN_OptionForm_Click(object sender, EventArgs e)
        {
            CloseEveryForm();
            OptionFormOpen();
            panel4.Height = 458;
        }
    }
}
