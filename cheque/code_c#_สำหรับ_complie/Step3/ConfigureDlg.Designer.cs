namespace TMS_Sample
{
	partial class ConfigureForm
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
			this.stGroupScanning = new System.Windows.Forms.GroupBox();
			this.udNumberOfDocuments = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCheckSCSaveFile = new System.Windows.Forms.CheckBox();
			this.stGroupIRColorDepth = new System.Windows.Forms.GroupBox();
			this.btnRadioCDIBW = new System.Windows.Forms.RadioButton();
			this.btnRadioCDIGray = new System.Windows.Forms.RadioButton();
			this.cmbResolution = new System.Windows.Forms.ComboBox();
			this.stGroupLightSource = new System.Windows.Forms.GroupBox();
			this.btnRadioICRGBIR = new System.Windows.Forms.RadioButton();
			this.btnRadioICRGB = new System.Windows.Forms.RadioButton();
			this.btnRadioICIR = new System.Windows.Forms.RadioButton();
			this.stResolution = new System.Windows.Forms.Label();
			this.stGroupRGBColorDepth = new System.Windows.Forms.GroupBox();
			this.btnRadioCDRBW = new System.Windows.Forms.RadioButton();
			this.btnRadioCDRGray = new System.Windows.Forms.RadioButton();
			this.btnRadioCDRColor = new System.Windows.Forms.RadioButton();
			this.stGroupScanningMedia = new System.Windows.Forms.GroupBox();
			this.btnRadioSMCard = new System.Windows.Forms.RadioButton();
			this.btnRadioSMCheckPaper = new System.Windows.Forms.RadioButton();
			this.stGroupMICR = new System.Windows.Forms.GroupBox();
			this.btnCheckMISaveFile = new System.Windows.Forms.CheckBox();
			this.btnCheckMIClearSpace = new System.Windows.Forms.CheckBox();
			this.stGroupMICRFont = new System.Windows.Forms.GroupBox();
			this.btnRadioMFCMC7 = new System.Windows.Forms.RadioButton();
			this.btnRadioMFE13B = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.stGroupScanning.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udNumberOfDocuments)).BeginInit();
			this.stGroupIRColorDepth.SuspendLayout();
			this.stGroupLightSource.SuspendLayout();
			this.stGroupRGBColorDepth.SuspendLayout();
			this.stGroupScanningMedia.SuspendLayout();
			this.stGroupMICR.SuspendLayout();
			this.stGroupMICRFont.SuspendLayout();
			this.SuspendLayout();
			// 
			// stGroupScanning
			// 
			this.stGroupScanning.Controls.Add(this.udNumberOfDocuments);
			this.stGroupScanning.Controls.Add(this.label1);
			this.stGroupScanning.Controls.Add(this.btnCheckSCSaveFile);
			this.stGroupScanning.Controls.Add(this.stGroupIRColorDepth);
			this.stGroupScanning.Controls.Add(this.cmbResolution);
			this.stGroupScanning.Controls.Add(this.stGroupLightSource);
			this.stGroupScanning.Controls.Add(this.stResolution);
			this.stGroupScanning.Controls.Add(this.stGroupRGBColorDepth);
			this.stGroupScanning.Controls.Add(this.stGroupScanningMedia);
			this.stGroupScanning.Location = new System.Drawing.Point(10, 10);
			this.stGroupScanning.Name = "stGroupScanning";
			this.stGroupScanning.Size = new System.Drawing.Size(250, 300);
			this.stGroupScanning.TabIndex = 0;
			this.stGroupScanning.TabStop = false;
			this.stGroupScanning.Text = "Scanning";
			// 
			// udNumberOfDocuments
			// 
			this.udNumberOfDocuments.Location = new System.Drawing.Point(155, 250);
			this.udNumberOfDocuments.Name = "udNumberOfDocuments";
			this.udNumberOfDocuments.Size = new System.Drawing.Size(75, 20);
			this.udNumberOfDocuments.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 252);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Number of Documents";
			// 
			// btnCheckSCSaveFile
			// 
			this.btnCheckSCSaveFile.AutoSize = true;
			this.btnCheckSCSaveFile.Location = new System.Drawing.Point(15, 275);
			this.btnCheckSCSaveFile.Name = "btnCheckSCSaveFile";
			this.btnCheckSCSaveFile.Size = new System.Drawing.Size(106, 17);
			this.btnCheckSCSaveFile.TabIndex = 6;
			this.btnCheckSCSaveFile.Text = "Save to harddisk";
			this.btnCheckSCSaveFile.UseVisualStyleBackColor = true;
			// 
			// stGroupIRColorDepth
			// 
			this.stGroupIRColorDepth.Controls.Add(this.btnRadioCDIBW);
			this.stGroupIRColorDepth.Controls.Add(this.btnRadioCDIGray);
			this.stGroupIRColorDepth.Location = new System.Drawing.Point(10, 200);
			this.stGroupIRColorDepth.Name = "stGroupIRColorDepth";
			this.stGroupIRColorDepth.Size = new System.Drawing.Size(230, 45);
			this.stGroupIRColorDepth.TabIndex = 5;
			this.stGroupIRColorDepth.TabStop = false;
			this.stGroupIRColorDepth.Text = "IR ColorDepth";
			// 
			// btnRadioCDIBW
			// 
			this.btnRadioCDIBW.AutoSize = true;
			this.btnRadioCDIBW.Location = new System.Drawing.Point(150, 20);
			this.btnRadioCDIBW.Name = "btnRadioCDIBW";
			this.btnRadioCDIBW.Size = new System.Drawing.Size(54, 17);
			this.btnRadioCDIBW.TabIndex = 1;
			this.btnRadioCDIBW.TabStop = true;
			this.btnRadioCDIBW.Text = "B / W";
			this.btnRadioCDIBW.UseVisualStyleBackColor = true;
			// 
			// btnRadioCDIGray
			// 
			this.btnRadioCDIGray.AutoSize = true;
			this.btnRadioCDIGray.Location = new System.Drawing.Point(80, 20);
			this.btnRadioCDIGray.Name = "btnRadioCDIGray";
			this.btnRadioCDIGray.Size = new System.Drawing.Size(47, 17);
			this.btnRadioCDIGray.TabIndex = 0;
			this.btnRadioCDIGray.TabStop = true;
			this.btnRadioCDIGray.Text = "Gray";
			this.btnRadioCDIGray.UseVisualStyleBackColor = true;
			// 
			// cmbResolution
			// 
			this.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbResolution.FormattingEnabled = true;
			this.cmbResolution.Location = new System.Drawing.Point(90, 70);
			this.cmbResolution.Name = "cmbResolution";
			this.cmbResolution.Size = new System.Drawing.Size(150, 21);
			this.cmbResolution.TabIndex = 2;
			// 
			// stGroupLightSource
			// 
			this.stGroupLightSource.Controls.Add(this.btnRadioICRGBIR);
			this.stGroupLightSource.Controls.Add(this.btnRadioICRGB);
			this.stGroupLightSource.Controls.Add(this.btnRadioICIR);
			this.stGroupLightSource.Location = new System.Drawing.Point(10, 100);
			this.stGroupLightSource.Name = "stGroupLightSource";
			this.stGroupLightSource.Size = new System.Drawing.Size(230, 45);
			this.stGroupLightSource.TabIndex = 3;
			this.stGroupLightSource.TabStop = false;
			this.stGroupLightSource.Text = "Image Channel";
			// 
			// btnRadioICRGBIR
			// 
			this.btnRadioICRGBIR.AutoSize = true;
			this.btnRadioICRGBIR.Location = new System.Drawing.Point(150, 20);
			this.btnRadioICRGBIR.Name = "btnRadioICRGBIR";
			this.btnRadioICRGBIR.Size = new System.Drawing.Size(65, 17);
			this.btnRadioICRGBIR.TabIndex = 2;
			this.btnRadioICRGBIR.TabStop = true;
			this.btnRadioICRGBIR.Text = "RGB+IR";
			this.btnRadioICRGBIR.UseVisualStyleBackColor = true;
			this.btnRadioICRGBIR.Click += new System.EventHandler(this.OnChangeRadioLightSource);
			// 
			// btnRadioICRGB
			// 
			this.btnRadioICRGB.AutoSize = true;
			this.btnRadioICRGB.Location = new System.Drawing.Point(10, 20);
			this.btnRadioICRGB.Name = "btnRadioICRGB";
			this.btnRadioICRGB.Size = new System.Drawing.Size(48, 17);
			this.btnRadioICRGB.TabIndex = 0;
			this.btnRadioICRGB.TabStop = true;
			this.btnRadioICRGB.Text = "RGB";
			this.btnRadioICRGB.UseVisualStyleBackColor = true;
			this.btnRadioICRGB.Click += new System.EventHandler(this.OnChangeRadioLightSource);
			// 
			// btnRadioICIR
			// 
			this.btnRadioICIR.AutoSize = true;
			this.btnRadioICIR.Location = new System.Drawing.Point(80, 20);
			this.btnRadioICIR.Name = "btnRadioICIR";
			this.btnRadioICIR.Size = new System.Drawing.Size(36, 17);
			this.btnRadioICIR.TabIndex = 1;
			this.btnRadioICIR.TabStop = true;
			this.btnRadioICIR.Text = "IR";
			this.btnRadioICIR.UseVisualStyleBackColor = true;
			this.btnRadioICIR.Click += new System.EventHandler(this.OnChangeRadioLightSource);
			// 
			// stResolution
			// 
			this.stResolution.AutoSize = true;
			this.stResolution.Location = new System.Drawing.Point(15, 75);
			this.stResolution.Name = "stResolution";
			this.stResolution.Size = new System.Drawing.Size(57, 13);
			this.stResolution.TabIndex = 1;
			this.stResolution.Text = "Resolution";
			// 
			// stGroupRGBColorDepth
			// 
			this.stGroupRGBColorDepth.Controls.Add(this.btnRadioCDRBW);
			this.stGroupRGBColorDepth.Controls.Add(this.btnRadioCDRGray);
			this.stGroupRGBColorDepth.Controls.Add(this.btnRadioCDRColor);
			this.stGroupRGBColorDepth.Location = new System.Drawing.Point(10, 150);
			this.stGroupRGBColorDepth.Name = "stGroupRGBColorDepth";
			this.stGroupRGBColorDepth.Size = new System.Drawing.Size(230, 45);
			this.stGroupRGBColorDepth.TabIndex = 4;
			this.stGroupRGBColorDepth.TabStop = false;
			this.stGroupRGBColorDepth.Text = "RGB ColorDepth";
			// 
			// btnRadioCDRBW
			// 
			this.btnRadioCDRBW.AutoSize = true;
			this.btnRadioCDRBW.Location = new System.Drawing.Point(150, 20);
			this.btnRadioCDRBW.Name = "btnRadioCDRBW";
			this.btnRadioCDRBW.Size = new System.Drawing.Size(54, 17);
			this.btnRadioCDRBW.TabIndex = 2;
			this.btnRadioCDRBW.TabStop = true;
			this.btnRadioCDRBW.Text = "B / W";
			this.btnRadioCDRBW.UseVisualStyleBackColor = true;
			// 
			// btnRadioCDRGray
			// 
			this.btnRadioCDRGray.AutoSize = true;
			this.btnRadioCDRGray.Location = new System.Drawing.Point(80, 20);
			this.btnRadioCDRGray.Name = "btnRadioCDRGray";
			this.btnRadioCDRGray.Size = new System.Drawing.Size(47, 17);
			this.btnRadioCDRGray.TabIndex = 1;
			this.btnRadioCDRGray.TabStop = true;
			this.btnRadioCDRGray.Text = "Gray";
			this.btnRadioCDRGray.UseVisualStyleBackColor = true;
			// 
			// btnRadioCDRColor
			// 
			this.btnRadioCDRColor.AutoSize = true;
			this.btnRadioCDRColor.Location = new System.Drawing.Point(10, 20);
			this.btnRadioCDRColor.Name = "btnRadioCDRColor";
			this.btnRadioCDRColor.Size = new System.Drawing.Size(49, 17);
			this.btnRadioCDRColor.TabIndex = 0;
			this.btnRadioCDRColor.TabStop = true;
			this.btnRadioCDRColor.Text = "Color";
			this.btnRadioCDRColor.UseVisualStyleBackColor = true;
			// 
			// stGroupScanningMedia
			// 
			this.stGroupScanningMedia.Controls.Add(this.btnRadioSMCard);
			this.stGroupScanningMedia.Controls.Add(this.btnRadioSMCheckPaper);
			this.stGroupScanningMedia.Location = new System.Drawing.Point(10, 20);
			this.stGroupScanningMedia.Name = "stGroupScanningMedia";
			this.stGroupScanningMedia.Size = new System.Drawing.Size(230, 45);
			this.stGroupScanningMedia.TabIndex = 0;
			this.stGroupScanningMedia.TabStop = false;
			this.stGroupScanningMedia.Text = "Scanning Media";
			// 
			// btnRadioSMCard
			// 
			this.btnRadioSMCard.AutoSize = true;
			this.btnRadioSMCard.Location = new System.Drawing.Point(125, 20);
			this.btnRadioSMCard.Name = "btnRadioSMCard";
			this.btnRadioSMCard.Size = new System.Drawing.Size(47, 17);
			this.btnRadioSMCard.TabIndex = 1;
			this.btnRadioSMCard.TabStop = true;
			this.btnRadioSMCard.Text = "Card";
			this.btnRadioSMCard.UseVisualStyleBackColor = true;
			this.btnRadioSMCard.Click += new System.EventHandler(this.OnChangeRadioScanningMedia);
			// 
			// btnRadioSMCheckPaper
			// 
			this.btnRadioSMCheckPaper.AutoSize = true;
			this.btnRadioSMCheckPaper.Location = new System.Drawing.Point(10, 20);
			this.btnRadioSMCheckPaper.Name = "btnRadioSMCheckPaper";
			this.btnRadioSMCheckPaper.Size = new System.Drawing.Size(84, 17);
			this.btnRadioSMCheckPaper.TabIndex = 0;
			this.btnRadioSMCheckPaper.TabStop = true;
			this.btnRadioSMCheckPaper.Text = "CheckPaper";
			this.btnRadioSMCheckPaper.UseVisualStyleBackColor = true;
			this.btnRadioSMCheckPaper.Click += new System.EventHandler(this.OnChangeRadioScanningMedia);
			// 
			// stGroupMICR
			// 
			this.stGroupMICR.Controls.Add(this.btnCheckMISaveFile);
			this.stGroupMICR.Controls.Add(this.btnCheckMIClearSpace);
			this.stGroupMICR.Controls.Add(this.stGroupMICRFont);
			this.stGroupMICR.Location = new System.Drawing.Point(270, 10);
			this.stGroupMICR.Name = "stGroupMICR";
			this.stGroupMICR.Size = new System.Drawing.Size(250, 124);
			this.stGroupMICR.TabIndex = 1;
			this.stGroupMICR.TabStop = false;
			this.stGroupMICR.Text = "MICR";
			// 
			// btnCheckMISaveFile
			// 
			this.btnCheckMISaveFile.AutoSize = true;
			this.btnCheckMISaveFile.Location = new System.Drawing.Point(15, 100);
			this.btnCheckMISaveFile.Name = "btnCheckMISaveFile";
			this.btnCheckMISaveFile.Size = new System.Drawing.Size(106, 17);
			this.btnCheckMISaveFile.TabIndex = 2;
			this.btnCheckMISaveFile.Text = "Save to harddisk";
			this.btnCheckMISaveFile.UseVisualStyleBackColor = true;
			// 
			// btnCheckMIClearSpace
			// 
			this.btnCheckMIClearSpace.AutoSize = true;
			this.btnCheckMIClearSpace.Location = new System.Drawing.Point(15, 75);
			this.btnCheckMIClearSpace.Name = "btnCheckMIClearSpace";
			this.btnCheckMIClearSpace.Size = new System.Drawing.Size(84, 17);
			this.btnCheckMIClearSpace.TabIndex = 1;
			this.btnCheckMIClearSpace.Text = "Clear Space";
			this.btnCheckMIClearSpace.UseVisualStyleBackColor = true;
			// 
			// stGroupMICRFont
			// 
			this.stGroupMICRFont.Controls.Add(this.btnRadioMFCMC7);
			this.stGroupMICRFont.Controls.Add(this.btnRadioMFE13B);
			this.stGroupMICRFont.Location = new System.Drawing.Point(10, 20);
			this.stGroupMICRFont.Name = "stGroupMICRFont";
			this.stGroupMICRFont.Size = new System.Drawing.Size(230, 45);
			this.stGroupMICRFont.TabIndex = 0;
			this.stGroupMICRFont.TabStop = false;
			this.stGroupMICRFont.Text = "MICR Font";
			// 
			// btnRadioMFCMC7
			// 
			this.btnRadioMFCMC7.AutoSize = true;
			this.btnRadioMFCMC7.Location = new System.Drawing.Point(125, 20);
			this.btnRadioMFCMC7.Name = "btnRadioMFCMC7";
			this.btnRadioMFCMC7.Size = new System.Drawing.Size(54, 17);
			this.btnRadioMFCMC7.TabIndex = 1;
			this.btnRadioMFCMC7.TabStop = true;
			this.btnRadioMFCMC7.Text = "CMC7";
			this.btnRadioMFCMC7.UseVisualStyleBackColor = true;
			// 
			// btnRadioMFE13B
			// 
			this.btnRadioMFE13B.AutoSize = true;
			this.btnRadioMFE13B.Location = new System.Drawing.Point(10, 20);
			this.btnRadioMFE13B.Name = "btnRadioMFE13B";
			this.btnRadioMFE13B.Size = new System.Drawing.Size(51, 17);
			this.btnRadioMFE13B.TabIndex = 0;
			this.btnRadioMFE13B.TabStop = true;
			this.btnRadioMFE13B.Text = "E13B";
			this.btnRadioMFE13B.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(364, 360);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(73, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(443, 360);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(73, 25);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ConfigureForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(530, 394);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.stGroupMICR);
			this.Controls.Add(this.stGroupScanning);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigureForm";
			this.Text = "Configure";
			this.Load += new System.EventHandler(this.ConfigureForm_Load);
			this.stGroupScanning.ResumeLayout(false);
			this.stGroupScanning.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udNumberOfDocuments)).EndInit();
			this.stGroupIRColorDepth.ResumeLayout(false);
			this.stGroupIRColorDepth.PerformLayout();
			this.stGroupLightSource.ResumeLayout(false);
			this.stGroupLightSource.PerformLayout();
			this.stGroupRGBColorDepth.ResumeLayout(false);
			this.stGroupRGBColorDepth.PerformLayout();
			this.stGroupScanningMedia.ResumeLayout(false);
			this.stGroupScanningMedia.PerformLayout();
			this.stGroupMICR.ResumeLayout(false);
			this.stGroupMICR.PerformLayout();
			this.stGroupMICRFont.ResumeLayout(false);
			this.stGroupMICRFont.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox stGroupScanning;
		private System.Windows.Forms.GroupBox stGroupScanningMedia;
		private System.Windows.Forms.GroupBox stGroupLightSource;
		private System.Windows.Forms.GroupBox stGroupRGBColorDepth;
		private System.Windows.Forms.GroupBox stGroupIRColorDepth;
		private System.Windows.Forms.Label stResolution;
		private System.Windows.Forms.RadioButton btnRadioSMCard;
		private System.Windows.Forms.RadioButton btnRadioSMCheckPaper;
		private System.Windows.Forms.ComboBox cmbResolution;
		private System.Windows.Forms.RadioButton btnRadioICRGBIR;
		private System.Windows.Forms.RadioButton btnRadioICRGB;
		private System.Windows.Forms.RadioButton btnRadioICIR;
		private System.Windows.Forms.RadioButton btnRadioCDRColor;
		private System.Windows.Forms.CheckBox btnCheckSCSaveFile;
		private System.Windows.Forms.RadioButton btnRadioCDIBW;
		private System.Windows.Forms.RadioButton btnRadioCDIGray;
		private System.Windows.Forms.RadioButton btnRadioCDRBW;
		private System.Windows.Forms.RadioButton btnRadioCDRGray;
		private System.Windows.Forms.GroupBox stGroupMICR;
		private System.Windows.Forms.GroupBox stGroupMICRFont;
		private System.Windows.Forms.CheckBox btnCheckMISaveFile;
		private System.Windows.Forms.CheckBox btnCheckMIClearSpace;
		private System.Windows.Forms.RadioButton btnRadioMFCMC7;
		private System.Windows.Forms.RadioButton btnRadioMFE13B;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.NumericUpDown udNumberOfDocuments;
		private System.Windows.Forms.Label label1;
	}
}
