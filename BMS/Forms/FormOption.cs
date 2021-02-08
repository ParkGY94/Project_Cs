using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class FormOption : System.Windows.Forms.Form
    {
        Factory factory;

        public FormOption(Factory factory)
        {
            this.factory = factory;
            InitializeComponent();

            LoadOption();
        }

        private void btnLogPath_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                lbLogPath.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
               // lbLogPath.Text = @"C:\User\Desktop\Log";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string optionPath = Application.StartupPath + @"\system";
            if (!Directory.Exists(optionPath))
            {
                Directory.CreateDirectory(optionPath);
            }
            optionPath += @"\option.ini";

            factory.option.logSaveInterval = (double)numSaveInterval.Value;
            factory.option.logEndCount = (int)numEndCount.Value;
            factory.option.logSavePath = lbLogPath.Text;

            if(factory.option.Save(optionPath))
            {
                MessageBox.Show("저장 완료.", "환경설정", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("저장 실패.", "환경설정", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOption()
        {
            string optionPath = Application.StartupPath + @"\system\option.ini";
            factory.option.Load(optionPath);

            numSaveInterval.Value = (Decimal)factory.option.logSaveInterval;
            numEndCount.Value = (Decimal)factory.option.logEndCount;
            lbLogPath.Text = factory.option.logSavePath;
        }

    }//class ends
}//namespace end
