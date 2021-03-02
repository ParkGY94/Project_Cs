using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pressure_Sensor_EOL
{
    public partial class MainForm : Form
    {
        TestForm testform;
        PasswordForm passwordform;
        LogForm logform;
        OptionForm optionform;
        SelfForm selfform;
        SpecForm specform;
        public int count;
        public bool IsSpec;
        public bool IsMaster;
        public List<string> list;
        
        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;
            count = 0;
            IsSpec = false;
            IsMaster = true;
            list = new List<string>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            testformOpen();
        }
        public void CloseForm()
        {
            if(testform != null)
            {
                testform.Close();
                testform.Dispose();
                testform = null;
            }
            if(passwordform != null)
            {
                passwordform.Close();
                passwordform.Dispose();
                passwordform = null;
            }
            if(logform != null)
            {
                logform.Close();
                logform.Dispose();
                logform = null;
            }
            if(optionform != null)
            {
                optionform.Close();
                optionform.Dispose();
                optionform = null;
            }
            if (selfform != null)
            {
                selfform.Close();
                selfform.Dispose();
                selfform = null;
            }
            if (specform != null)
            {
                specform.Close();
                specform.Dispose();
                specform = null;
            }
        }
        public void testformOpen()
        {
            count++;
            testform = new TestForm(this);
            testform.TopLevel = false;
            testform.Parent = dockingPannel;
            testform.FormBorderStyle = FormBorderStyle.None;
            testform.StartPosition = FormStartPosition.CenterParent;
            try
            {
                testform.Show();
            }
            catch
            {

            }
        }
        public void passwordformOpen()
        {
            passwordform = new PasswordForm(this);
            passwordform.TopLevel = false;
            passwordform.Parent = dockingPannel;
            passwordform.FormBorderStyle = FormBorderStyle.None;
            passwordform.StartPosition = FormStartPosition.CenterParent;
            passwordform.Show();
        }
        public void logformOpen()
        {
            //db = new Database("192.168.10.11", "dy", "root", "1996");
            logform = new LogForm(this);
            logform.TopLevel = false;
            logform.Parent = dockingPannel;
            logform.FormBorderStyle = FormBorderStyle.None;
            logform.StartPosition = FormStartPosition.CenterParent;
            logform.Show();
        }
        public void modelformOpen()
        {
            optionform = new OptionForm(this);
            optionform.TopLevel = false;
            optionform.Parent = dockingPannel;
            optionform.FormBorderStyle = FormBorderStyle.None;
            optionform.StartPosition = FormStartPosition.CenterParent;
            optionform.Show();
        }

        public void selfformOpen()
        {
            selfform = new SelfForm();
            selfform.TopLevel = false;
            selfform.Parent = dockingPannel;
            selfform.FormBorderStyle = FormBorderStyle.None;
            selfform.StartPosition = FormStartPosition.CenterParent;
            selfform.Show();
        }

        public void specformOpen()
        {
            specform = new SpecForm();
            specform.TopLevel = false;
            specform.Parent = dockingPannel;
            specform.FormBorderStyle = FormBorderStyle.None;
            specform.StartPosition = FormStartPosition.CenterParent;
            specform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseForm();
            testformOpen();
        }

        private void BTN_Manual_Click(object sender, EventArgs e)
        {
            CloseForm();
            selfformOpen();
        }

        private void BTN_Option_Click(object sender, EventArgs e)
        {
            CloseForm();
            passwordformOpen();
        }

        private void BTN_Spec_Click(object sender, EventArgs e)
        {
            CloseForm();
            specformOpen();
        }

        private void BTN_Log_Click(object sender, EventArgs e)
        {
            CloseForm();
            logformOpen();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                testform.WarningPannel.Visible = false;
                testform.WarningPannel.SendToBack();
            }
        }
    }
}
