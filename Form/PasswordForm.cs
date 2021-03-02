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

namespace Pressure_Sensor_EOL
{
    public partial class PasswordForm : Form
    {
        private MainForm mainform;
        private Password pw;
        private IniFiles ini;
        private string password;
        private bool isCorrect;
        public PasswordForm(MainForm mainform_)
        {
            InitializeComponent();
            mainform = mainform_;
            ini = new IniFiles(@"C:\Users\abc\Data\Option.ini");
            pw = new Password();
            pw.Save(ini.ReadString("password","password",""));
        }

        public bool IsCorrect
        {
            get { return isCorrect; }
        }
        private void Check()
        {
            password = pw.Load();
            if(password == textPassword.Text)
            {
                isCorrect = true;
                //this.Close();
                mainform.CloseForm();
                mainform.modelformOpen();
            }
            else
            {
                isCorrect = false;
                MessageBox.Show("비밀번호를 확인해주세요.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            Close.BackColor = Color.Red;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Close.BackColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            /*if(e.KeyCode == Keys.F11)  // F11 누르면 통과
            {
                isCorrect = true;
                this.Close();
            }*/
            if(e.KeyCode == Keys.Enter)
            {
                Check();
            }
        }
    }
}
