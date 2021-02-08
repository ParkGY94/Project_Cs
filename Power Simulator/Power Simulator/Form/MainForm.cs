using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Power_Simulator
{
    public enum PRESENT
    {
        TEST = 0,
        SELF = 1,
        PROFILE = 2,
        LOG = 3,
        OPTION = 4,
    }

    public interface IStateInterface
    {
        void SetPresent(PRESENT set);
        PRESENT GetPresent();
    }
    public partial class MainForm : Form, IStateInterface
    {
        public void SetPresent(PRESENT set)
        {
            STATE = set;
        }
        
        public PRESENT GetPresent()
        {
            return STATE;
        }
        private PRESENT STATE;

        public const int DEBUG_MODE = 1;
        private TestForm testform;
        private ProfileForm profileform;
        private LogForm logform;
        private SelfForm selfform;
        private OptionForm optionform;

        Profile profile = new Profile();
        INIFILE ini;

        ODA oda;
        SorensenXG sorensen;
        TDKLamdaGENH lamda;

        string strPath;

        public string[] strReadPower = new string[3];

        bool bConnectAll;
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            if (DEBUG_MODE != 0)
            {
                BTN_Profile.PerformClick();
                return;
            }
            //strPath = @"C:\Users\abc\Desktop\Power Simulator\Power Simulator\sys";
            if (Directory.Exists(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\sys"))
            {
                ini = new INIFILE(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\sys\option.ini");
            }
            DeviceConnect();
            TestformOpen();
        }

        public void CloseForm()
        {
            if(testform != null)
            {
                testform.Close();
                testform.Dispose();
                testform = null;
            }
            if (selfform != null)
            {
                selfform.Close();
                selfform.Dispose();
                selfform = null;
            }
            if (profileform != null)
            {
                profileform.Close();
                profileform.Dispose();
                profileform = null;
            }
            if(logform != null)
            {
                logform.Close();
                logform.Dispose();
                logform = null;
            }
            if (optionform != null)
            {
                optionform.Close();
                optionform.Dispose();
                optionform = null;
            }
        }

        public void TestformOpen()
        {
            testform = new TestForm(this);
            testform.TopLevel = false;
            testform.Parent = DockingPanel;
            testform.FormBorderStyle = FormBorderStyle.None;
            testform.StartPosition = FormStartPosition.CenterParent;
            STATE = PRESENT.TEST;
            try
            {
                testform.Show();
            }
            catch
            {

            }
        }

        public void ProfileformOpen()
        {
            profileform = new ProfileForm();
            profileform.TopLevel = false;
            profileform.Parent = DockingPanel;
            profileform.FormBorderStyle = FormBorderStyle.None;
            profileform.StartPosition = FormStartPosition.CenterParent;
            STATE = PRESENT.PROFILE;
            try
            {
                profileform.Show();
            }
            catch
            {

            }
        }

        public void LogformOpen()
        {
            logform = new LogForm();
            logform.TopLevel = false;
            logform.Parent = DockingPanel;
            logform.FormBorderStyle = FormBorderStyle.None;
            logform.StartPosition = FormStartPosition.CenterParent;
            STATE = PRESENT.LOG;
            try
            {
                logform.Show();
            }
            catch
            {

            }
        }

        public void SelfformOpen()
        {
            selfform = new SelfForm(this);
            selfform.TopLevel = false;
            selfform.Parent = DockingPanel;
            selfform.FormBorderStyle = FormBorderStyle.None;
            selfform.StartPosition = FormStartPosition.CenterParent;
            STATE = PRESENT.SELF;
            try
            {
                selfform.Show();
            }
            catch
            {

            }
        }

        public void OptionformOpen()
        {
            optionform = new OptionForm();
            //optionform.TopLevel = false;
            //optionform.Parent = DockingPanel;
            //optionform.FormBorderStyle = FormBorderStyle.None;
            //optionform.StartPosition = FormStartPosition.CenterParent;
            STATE = PRESENT.OPTION;
            try
            {
                optionform.Show();
            }
            catch
            {

            }
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            CloseForm();
            TestformOpen();
        }

        private void BTN_Self_Click(object sender, EventArgs e)
        {
            CloseForm();
            SelfformOpen();
        }

        private void BTN_Profile_Click(object sender, EventArgs e)
        {
            CloseForm();
            ProfileformOpen();
        }

        private void BTN_Option_Click(object sender, EventArgs e)
        {
            CloseForm();
            OptionformOpen();
        }
        
        
        private void DeviceConnect()
        {
            oda = new ODA(ODA_, ini.Read("POWER1", "PortName", ""), Convert.ToInt32(ini.Read("POWER1", "BaudRate", "9600")));
            oda.Open();
            oda.IDN();
            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (EndTime >= NowTime)
            {
                Application.DoEvents();
                if (oda.Connect) break;
                NowTime = DateTime.Now;
            }

            sorensen = new SorensenXG(Sorensen_, ini.Read("POWER2", "PortName", ""), Convert.ToInt32(ini.Read("POWER2", "BaudRate", "9600")));
            sorensen.Open();
            sorensen.ADR();
            sorensen.IDN();
            NowTime = DateTime.Now;
            EndTime = NowTime.Add(WaitTime);
            while (EndTime >= NowTime)
            {
                Application.DoEvents();
                if (sorensen.Connect) break;
                NowTime = DateTime.Now;
            }

            lamda = new TDKLamdaGENH(Lamda_, ini.Read("POWER3", "PortName", ""), Convert.ToInt32(ini.Read("POWER3", "BaudRate", "9600")));
            lamda.Open();
            lamda.ADR();
            lamda.IDN();
            NowTime = DateTime.Now;
            EndTime = NowTime.Add(WaitTime);
            while (EndTime >= NowTime)
            {
                Application.DoEvents();
                if (lamda.Connect) break;
                NowTime = DateTime.Now;
            }
        }
        private void ODA_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            oda.Connect = true;
            
            string strBuffer;
            strBuffer = ODA_.ReadLine();
            strReadPower[0] += strBuffer;

            if (strReadPower[0].IndexOf('\n') >= 0)
            {
                this.Invoke(new Action(delegate ()
                {
                    if (STATE == PRESENT.SELF)
                    {
                    }
                    else if (STATE == PRESENT.TEST)
                    {
                    }
                }));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oda.VoltOutCheck();
        }

        private void Sorensen__DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            sorensen.Connect = true;

            string strBuffer;
            string Data = "";
            strBuffer = Sorensen_.ReadExisting();
            
            Data += strBuffer; 

            if (Data.IndexOf('\r') >= 0)
            {
                /*while (Data.IndexOf(">") >= 0)
                {
                    Data = Data.Replace(">", "0");
                }
                while (Data.IndexOf("<") >= 0)
                {
                    Data = Data.Replace("<", "0");
                }*/
                //strReadPower[1] = Data.Replace("?", "");
                strReadPower[1] = Data;
                this.Invoke(new Action(delegate ()
                {
                    if (STATE == PRESENT.SELF)
                    {
                    }
                    else if (STATE == PRESENT.TEST)
                    {
                    }
                }));
            }
        }

        private void Lamda__DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            lamda.Connect = true;
            
            string strBuffer;
            strBuffer = Lamda_.ReadExisting();
            strReadPower[2] += strBuffer;

            if (strReadPower[2].IndexOf('\r') >= 0)
            {
                try
                {
                    this.Invoke(new Action(delegate ()
                    {
                        if (STATE == PRESENT.SELF)
                        {
                        }
                        else if (STATE == PRESENT.TEST)
                        {
                        }
                    }));
                }
                catch
                {

                }
            }
        }

        private void BTN_Log_Click(object sender, EventArgs e)
        {
            CloseForm();
            LogformOpen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
