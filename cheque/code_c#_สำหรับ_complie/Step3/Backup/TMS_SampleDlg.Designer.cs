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
			this.btnScanCancel = new System.Windows.Forms.Button();
			this.btnConfig = new System.Windows.Forms.Button();
			this.btnMicrCleaning = new System.Windows.Forms.Button();
			this.stImage4RGBFront = new System.Windows.Forms.PictureBox();
			this.stImage4IRBack = new System.Windows.Forms.PictureBox();
			this.stImage4RGBBack = new System.Windows.Forms.PictureBox();
			this.stImage4IRFront = new System.Windows.Forms.PictureBox();
			this.stImage2Front = new System.Windows.Forms.PictureBox();
			this.stImage2Back = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.stImage4RGBFront)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage4IRBack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage4RGBBack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage4IRFront)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage2Front)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage2Back)).BeginInit();
			this.SuspendLayout();
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(105, 450);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(90, 25);
			this.btnScan.TabIndex = 3;
			this.btnScan.Text = "Scan";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(500, 450);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(90, 25);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// edtMicrText
			// 
			this.edtMicrText.Location = new System.Drawing.Point(80, 12);
			this.edtMicrText.Name = "edtMicrText";
			this.edtMicrText.ReadOnly = true;
			this.edtMicrText.Size = new System.Drawing.Size(510, 20);
			this.edtMicrText.TabIndex = 1;
			// 
			// stMicrText
			// 
			this.stMicrText.AutoSize = true;
			this.stMicrText.Location = new System.Drawing.Point(10, 15);
			this.stMicrText.Name = "stMicrText";
			this.stMicrText.Size = new System.Drawing.Size(34, 13);
			this.stMicrText.TabIndex = 0;
			this.stMicrText.Text = "MICR";
			// 
			// btnScanCancel
			// 
			this.btnScanCancel.Location = new System.Drawing.Point(200, 450);
			this.btnScanCancel.Name = "btnScanCancel";
			this.btnScanCancel.Size = new System.Drawing.Size(90, 25);
			this.btnScanCancel.TabIndex = 4;
			this.btnScanCancel.Text = "ScanCancel";
			this.btnScanCancel.UseVisualStyleBackColor = true;
			this.btnScanCancel.Click += new System.EventHandler(this.btnScanCancel_Click);
			// 
			// btnConfig
			// 
			this.btnConfig.Location = new System.Drawing.Point(10, 450);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(90, 25);
			this.btnConfig.TabIndex = 2;
			this.btnConfig.Text = "Config";
			this.btnConfig.UseVisualStyleBackColor = true;
			this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
			// 
			// btnMicrCleaning
			// 
			this.btnMicrCleaning.Location = new System.Drawing.Point(295, 450);
			this.btnMicrCleaning.Name = "btnMicrCleaning";
			this.btnMicrCleaning.Size = new System.Drawing.Size(90, 25);
			this.btnMicrCleaning.TabIndex = 5;
			this.btnMicrCleaning.Text = "MICR Cleaning";
			this.btnMicrCleaning.UseVisualStyleBackColor = true;
			this.btnMicrCleaning.Click += new System.EventHandler(this.btnMicrCleaning_Click);
			// 
			// stImage4RGBFront
			// 
			this.stImage4RGBFront.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.stImage4RGBFront.Location = new System.Drawing.Point(8, 120);
			this.stImage4RGBFront.Name = "stImage4RGBFront";
			this.stImage4RGBFront.Size = new System.Drawing.Size(290, 120);
			this.stImage4RGBFront.TabIndex = 7;
			this.stImage4RGBFront.TabStop = false;
			// 
			// stImage4IRBack
			// 
			this.stImage4IRBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.stImage4IRBack.Location = new System.Drawing.Point(302, 245);
			this.stImage4IRBack.Name = "stImage4IRBack";
			this.stImage4IRBack.Size = new System.Drawing.Size(290, 120);
			this.stImage4IRBack.TabIndex = 8;
			this.stImage4IRBack.TabStop = false;
			// 
			// stImage4RGBBack
			// 
			this.stImage4RGBBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.stImage4RGBBack.Location = new System.Drawing.Point(8, 245);
			this.stImage4RGBBack.Name = "stImage4RGBBack";
			this.stImage4RGBBack.Size = new System.Drawing.Size(290, 120);
			this.stImage4RGBBack.TabIndex = 9;
			this.stImage4RGBBack.TabStop = false;
			// 
			// stImage4IRFront
			// 
			this.stImage4IRFront.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.stImage4IRFront.Location = new System.Drawing.Point(302, 120);
			this.stImage4IRFront.Name = "stImage4IRFront";
			this.stImage4IRFront.Size = new System.Drawing.Size(290, 120);
			this.stImage4IRFront.TabIndex = 10;
			this.stImage4IRFront.TabStop = false;
			// 
			// stImage2Front
			// 
			this.stImage2Front.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.stImage2Front.Location = new System.Drawing.Point(10, 40);
			this.stImage2Front.Name = "stImage2Front";
			this.stImage2Front.Size = new System.Drawing.Size(580, 200);
			this.stImage2Front.TabIndex = 11;
			this.stImage2Front.TabStop = false;
			// 
			// stImage2Back
			// 
			this.stImage2Back.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.stImage2Back.Location = new System.Drawing.Point(10, 245);
			this.stImage2Back.Name = "stImage2Back";
			this.stImage2Back.Size = new System.Drawing.Size(580, 200);
			this.stImage2Back.TabIndex = 12;
			this.stImage2Back.TabStop = false;
			// 
			// TMS_SampleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 482);
			this.Controls.Add(this.stImage4IRFront);
			this.Controls.Add(this.stImage4RGBBack);
			this.Controls.Add(this.stImage4IRBack);
			this.Controls.Add(this.stImage4RGBFront);
			this.Controls.Add(this.btnMicrCleaning);
			this.Controls.Add(this.btnConfig);
			this.Controls.Add(this.btnScanCancel);
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
			this.Text = "TM-S Sample Program";
			this.Load += new System.EventHandler(this.TMS_SampleForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.stImage4RGBFront)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage4IRBack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage4RGBBack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stImage4IRFront)).EndInit();
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
		private System.Windows.Forms.Button btnScanCancel;
		private System.Windows.Forms.Button btnConfig;
		private System.Windows.Forms.Button btnMicrCleaning;
		private System.Windows.Forms.PictureBox stImage4RGBFront;
		private System.Windows.Forms.PictureBox stImage4IRBack;
		private System.Windows.Forms.PictureBox stImage4RGBBack;
		private System.Windows.Forms.PictureBox stImage4IRFront;
		private System.Windows.Forms.PictureBox stImage2Front;
		private System.Windows.Forms.PictureBox stImage2Back;
	}
}

