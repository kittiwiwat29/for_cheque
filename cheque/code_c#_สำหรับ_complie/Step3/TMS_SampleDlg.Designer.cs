namespace TMS_Sample
{
	partial class TMS_SampleForm
	{
		private System.ComponentModel.IContainer components = null;

		#region Windows Form

		private void InitializeComponent()
		{
            this.btnScan = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.edtMicrText = new System.Windows.Forms.TextBox();
            this.stMicrText = new System.Windows.Forms.Label();
            this.stImage2Front = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbDrivers = new System.Windows.Forms.ComboBox();
            this.DTPdateScans = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stImage2Back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.stImage2Front)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stImage2Back)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(287, 487);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(90, 25);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(526, 485);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 25);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // edtMicrText
            // 
            this.edtMicrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtMicrText.Location = new System.Drawing.Point(156, 177);
            this.edtMicrText.Name = "edtMicrText";
            this.edtMicrText.ReadOnly = true;
            this.edtMicrText.Size = new System.Drawing.Size(338, 27);
            this.edtMicrText.TabIndex = 1;
            // 
            // stMicrText
            // 
            this.stMicrText.AutoSize = true;
            this.stMicrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stMicrText.Location = new System.Drawing.Point(35, 181);
            this.stMicrText.Name = "stMicrText";
            this.stMicrText.Size = new System.Drawing.Size(62, 25);
            this.stMicrText.TabIndex = 0;
            this.stMicrText.Text = "MICR";
            // 
            // stImage2Front
            // 
            this.stImage2Front.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.stImage2Front.Location = new System.Drawing.Point(156, 213);
            this.stImage2Front.Name = "stImage2Front";
            this.stImage2Front.Size = new System.Drawing.Size(338, 126);
            this.stImage2Front.TabIndex = 11;
            this.stImage2Front.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "ระบบ scan cheque บริษัท ซันจูปิเตอร์ จำกัด";
            // 
            // CbDrivers
            // 
            this.CbDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbDrivers.FormattingEnabled = true;
            this.CbDrivers.Location = new System.Drawing.Point(156, 79);
            this.CbDrivers.Name = "CbDrivers";
            this.CbDrivers.Size = new System.Drawing.Size(338, 33);
            this.CbDrivers.TabIndex = 14;
            // 
            // DTPdateScans
            // 
            this.DTPdateScans.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPdateScans.Location = new System.Drawing.Point(156, 134);
            this.DTPdateScans.Name = "DTPdateScans";
            this.DTPdateScans.Size = new System.Drawing.Size(338, 30);
            this.DTPdateScans.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "วันที่";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "คนส่งเอกสาร";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "หน้าเช็ค";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "หลังเช็ค";
            // 
            // stImage2Back
            // 
            this.stImage2Back.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.stImage2Back.Location = new System.Drawing.Point(156, 353);
            this.stImage2Back.Name = "stImage2Back";
            this.stImage2Back.Size = new System.Drawing.Size(338, 126);
            this.stImage2Back.TabIndex = 12;
            this.stImage2Back.TabStop = false;
            // 
            // TMS_SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 522);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DTPdateScans);
            this.Controls.Add(this.CbDrivers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stMicrText);
            this.Controls.Add(this.edtMicrText);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.stImage2Front);
            this.Controls.Add(this.stImage2Back);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TMS_SampleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TM-S Sample Program";
            this.Load += new System.EventHandler(this.TMS_SampleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stImage2Front)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stImage2Back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.TextBox edtMicrText;
		private System.Windows.Forms.Label stMicrText;
		private System.Windows.Forms.PictureBox stImage2Front;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbDrivers;
        private System.Windows.Forms.DateTimePicker DTPdateScans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox stImage2Back;
    }
}

