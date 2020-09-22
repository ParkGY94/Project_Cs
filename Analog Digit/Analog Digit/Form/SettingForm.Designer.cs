namespace Analog_Digit
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.path = new System.Windows.Forms.Label();
            this.filepath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_FileOpen = new System.Windows.Forms.Button();
            this.BTN_FileSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.VolMin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.VolMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ResMin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ResMax = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.path);
            this.panel1.Controls.Add(this.filepath);
            this.panel1.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(134, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 40);
            this.panel1.TabIndex = 4;
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.path.Location = new System.Drawing.Point(9, 2);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(0, 38);
            this.path.TabIndex = 3;
            // 
            // filepath
            // 
            this.filepath.AutoSize = true;
            this.filepath.Location = new System.Drawing.Point(3, 1);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(0, 38);
            this.filepath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(139, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Path";
            // 
            // BTN_FileOpen
            // 
            this.BTN_FileOpen.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.BTN_FileOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_FileOpen.Location = new System.Drawing.Point(15, 380);
            this.BTN_FileOpen.Name = "BTN_FileOpen";
            this.BTN_FileOpen.Size = new System.Drawing.Size(101, 68);
            this.BTN_FileOpen.TabIndex = 5;
            this.BTN_FileOpen.Text = "열기";
            this.BTN_FileOpen.UseVisualStyleBackColor = true;
            this.BTN_FileOpen.Click += new System.EventHandler(this.BTN_FileOpen_Click);
            // 
            // BTN_FileSave
            // 
            this.BTN_FileSave.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.BTN_FileSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_FileSave.Location = new System.Drawing.Point(382, 282);
            this.BTN_FileSave.Name = "BTN_FileSave";
            this.BTN_FileSave.Size = new System.Drawing.Size(101, 62);
            this.BTN_FileSave.TabIndex = 6;
            this.BTN_FileSave.Text = "저장";
            this.BTN_FileSave.UseVisualStyleBackColor = true;
            this.BTN_FileSave.Click += new System.EventHandler(this.BTN_FileSave_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(560, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 46);
            this.label11.TabIndex = 8;
            this.label11.Text = "V";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(335, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 28);
            this.label12.TabIndex = 7;
            this.label12.Text = "Min";
            // 
            // VolMin
            // 
            this.VolMin.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VolMin.Location = new System.Drawing.Point(398, 62);
            this.VolMin.Name = "VolMin";
            this.VolMin.Size = new System.Drawing.Size(156, 52);
            this.VolMin.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(260, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 46);
            this.label10.TabIndex = 5;
            this.label10.Text = "V";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(28, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 28);
            this.label9.TabIndex = 4;
            this.label9.Text = "Max";
            // 
            // VolMax
            // 
            this.VolMax.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VolMax.Location = new System.Drawing.Point(98, 62);
            this.VolMax.Name = "VolMax";
            this.VolMax.Size = new System.Drawing.Size(156, 52);
            this.VolMax.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(23, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Voltage Max/Min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(560, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 46);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ω";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(335, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 28);
            this.label7.TabIndex = 7;
            this.label7.Text = "Min";
            // 
            // ResMin
            // 
            this.ResMin.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ResMin.Location = new System.Drawing.Point(398, 196);
            this.ResMin.Name = "ResMin";
            this.ResMin.Size = new System.Drawing.Size(156, 52);
            this.ResMin.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(260, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 46);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ω";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(28, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 28);
            this.label14.TabIndex = 4;
            this.label14.Text = "Max";
            // 
            // ResMax
            // 
            this.ResMax.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ResMax.Location = new System.Drawing.Point(98, 196);
            this.ResMax.Name = "ResMax";
            this.ResMax.Size = new System.Drawing.Size(156, 52);
            this.ResMax.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(23, 151);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(193, 25);
            this.label16.TabIndex = 2;
            this.label16.Text = "Resistance Max/Min";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(845, 587);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ResMin);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.VolMin);
            this.Controls.Add(this.ResMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BTN_FileSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BTN_FileOpen);
            this.Controls.Add(this.VolMax);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Name = "SettingForm";
            this.Text = "Spec";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_FileOpen;
        private System.Windows.Forms.Button BTN_FileSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox VolMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox VolMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ResMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ResMax;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label path;
    }
}