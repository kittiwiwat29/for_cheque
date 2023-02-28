using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TMS_Sample
{
	public partial class ConfigureForm : Form
	{
		private StructByStep m_objConfigData = null;

		public ConfigureForm()
		{
			InitializeComponent();

			m_objConfigData = new StructByStep();
		}

		private void ConfigureForm_Load(object sender, EventArgs e)
		{
			LoadResourceString();

			SetControlData();

			UpdateControls();
		}

		public void SetConfigData(StructByStep objConfigData)
		{
			m_objConfigData.Copy(objConfigData);
		}

		public void GetConfigData(ref StructByStep objConfigData)
		{
			if (objConfigData != null)
			{
				objConfigData.Copy(m_objConfigData);
			}
		}

		private void LoadResourceString()
		{
			////////////////
			//// Step 2 ////
			////////////////

			btnOK.Text                  = ConstComStr.STR_CONFIGDLG_BUTTON_OK;
			btnCancel.Text              = ConstComStr.STR_CONFIGDLG_BUTTON_CANCEL;

			stGroupScanning.Text        = ConstComStr.STR_CONFIGDLG_GROUP_SCANNING;
			stGroupScanningMedia.Text   = ConstComStr.STR_CONFIGDLG_GROUP_SCANNINGMEDIA;
			stGroupLightSource.Text     = ConstComStr.STR_CONFIGDLG_GROUP_LIGHTSOURCE;
			stGroupRGBColorDepth.Text   = ConstComStr.STR_CONFIGDLG_GROUP_RGBCOLORDEPTH;
			stGroupIRColorDepth.Text    = ConstComStr.STR_CONFIGDLG_GROUP_IRCOLORDEPTH;

			stResolution.Text           = ConstComStr.STR_CONFIGDLG_STATIC_RESOLUTION;

			btnRadioSMCheckPaper.Text   = ConstComStr.STR_CONFIGDLG_RADIO_SM_CHECKPAPER;
			btnRadioSMCard.Text         = ConstComStr.STR_CONFIGDLG_RADIO_SM_CARD;
			btnRadioICRGB.Text          = ConstComStr.STR_CONFIGDLG_RADIO_IC_RGB;
			btnRadioICIR.Text           = ConstComStr.STR_CONFIGDLG_RADIO_IC_IR;
			btnRadioICRGBIR.Text        = ConstComStr.STR_CONFIGDLG_RADIO_IC_RGBIR;
			btnRadioCDRColor.Text       = ConstComStr.STR_CONFIGDLG_RADIO_RGBCD_COLOR;
			btnRadioCDRGray.Text        = ConstComStr.STR_CONFIGDLG_RADIO_RGBCD_GRAY;
			btnRadioCDRBW.Text          = ConstComStr.STR_CONFIGDLG_RADIO_RGBCD_BW;
			btnRadioCDIGray.Text        = ConstComStr.STR_CONFIGDLG_RADIO_IRCD_GRAY;
			btnRadioCDIBW.Text          = ConstComStr.STR_CONFIGDLG_RADIO_IRCD_BW;
			btnCheckSCSaveFile.Text     = ConstComStr.STR_CONFIGDLG_CHECK_SC_SAVEFILE;

			cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_600600);
			cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_300300);
			cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_240240);
			cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_200200);
			cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_120120);
			cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_100100);

			////////////////
			//// Step 3 ////
			////////////////

			stGroupMICR.Text            = ConstComStr.STR_CONFIGDLG_GROUP_MICR;
			stGroupMICRFont.Text        = ConstComStr.STR_CONFIGDLG_GROUP_MICRFONT;

			btnRadioMFE13B.Text         = ConstComStr.STR_CONFIGDLG_RADIO_MF_E13B;
			btnRadioMFCMC7.Text         = ConstComStr.STR_CONFIGDLG_RADIO_MF_CMC7;

			btnCheckMIClearSpace.Text   = ConstComStr.STR_CONFIGDLG_CHECK_MI_CLEARSPACE;
			btnCheckMISaveFile.Text     = ConstComStr.STR_CONFIGDLG_CHECK_MI_SAVEFILE;
		}

		private void SetControlData()
		{
			////////////////
			//// Step 2 ////
			////////////////

			switch( m_objConfigData.nRadio_ScanningMedia )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_SM_CHECKPAPER:
					btnRadioSMCheckPaper.Checked    = true;
					btnRadioSMCard.Checked          = false;
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_SM_CARD:
					btnRadioSMCheckPaper.Checked    = false;
					btnRadioSMCard.Checked          = true;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			switch( m_objConfigData.nRadio_LightSourceToScan )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGB:
					btnRadioICRGB.Checked           = true;
					btnRadioICIR.Checked            = false;
					btnRadioICRGBIR.Checked         = false;
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_IC_IR:
					btnRadioICRGB.Checked           = false;
					btnRadioICIR.Checked            = true;
					btnRadioICRGBIR.Checked         = false;
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGBIR:
					btnRadioICRGB.Checked           = false;
					btnRadioICIR.Checked            = false;
					btnRadioICRGBIR.Checked         = true;
					break;
				default:
					Debug.Assert(false);
					break;
			}
			switch( m_objConfigData.nRadio_RGBColorDepth )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_COLOR:
					btnRadioCDRColor.Checked        = true;
					btnRadioCDRGray.Checked         = false;
					btnRadioCDRBW.Checked           = false;
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_GRAY:
					btnRadioCDRColor.Checked        = false;
					btnRadioCDRGray.Checked         = true;
					btnRadioCDRBW.Checked           = false;
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_BW:
					btnRadioCDRColor.Checked        = false;
					btnRadioCDRGray.Checked         = false;
					btnRadioCDRBW.Checked           = true;
					break;
				default:
					Debug.Assert(false);
					break;
			}
			switch( m_objConfigData.nRadio_IRColorDepth )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_GRAY:
					btnRadioCDIGray.Checked         = true;
					btnRadioCDIBW.Checked           = false;
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_BW:
					btnRadioCDIGray.Checked         = false;
					btnRadioCDIBW.Checked           = true;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			SetIndexResolutionCombobox(m_objConfigData.nCombo_Resolution);

			udNumberOfDocuments.Minimum = 0;
			udNumberOfDocuments.Maximum = 255;
			udNumberOfDocuments.Value   = Convert.ToDecimal(m_objConfigData.byNumeric_NumberOfDocuments);

			btnCheckSCSaveFile.Checked = m_objConfigData.bCheck_Scan_SaveFile;

			////////////////
			//// Step 3 ////
			////////////////

			switch( m_objConfigData.nRadio_MICRFont )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_MF_E13B:
					btnRadioMFE13B.Checked          = true;
					btnRadioMFCMC7.Checked          = false;
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_MF_CMC7:
					btnRadioMFE13B.Checked          = false;
					btnRadioMFCMC7.Checked          = true;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			btnCheckMIClearSpace.Checked    = m_objConfigData.bCheck_MICR_ClearSpace;
			btnCheckMISaveFile.Checked      = m_objConfigData.bCheck_MICR_SaveFile;
		}

		private void GetControlData()
		{
			////////////////
			//// Step 2 ////
			////////////////

			if( btnRadioSMCheckPaper.Checked == true )
			{
				m_objConfigData.nRadio_ScanningMedia = ConstComVal.VAL_CONFIGDLG_RADIO_SM_CHECKPAPER;
			}
			else if( btnRadioSMCard.Checked == true )
			{
				m_objConfigData.nRadio_ScanningMedia = ConstComVal.VAL_CONFIGDLG_RADIO_SM_CARD;
			}
			else
			{
				Debug.Assert(false);
			}

			if( btnRadioICRGB.Checked == true )
			{
				m_objConfigData.nRadio_LightSourceToScan = ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGB;
			}
			else if( btnRadioICIR.Checked == true )
			{
				m_objConfigData.nRadio_LightSourceToScan = ConstComVal.VAL_CONFIGDLG_RADIO_IC_IR;
			}
			else if( btnRadioICRGBIR.Checked == true )
			{
				m_objConfigData.nRadio_LightSourceToScan = ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGBIR;
			}

			if( btnRadioCDRColor.Checked == true )
			{
				m_objConfigData.nRadio_RGBColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_COLOR;
			}
			else if( btnRadioCDRGray.Checked == true )
			{
				m_objConfigData.nRadio_RGBColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_GRAY;
			}
			else if( btnRadioCDRBW.Checked == true )
			{
				m_objConfigData.nRadio_RGBColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_BW;
			}

			if( btnRadioCDIGray.Checked == true )
			{
				m_objConfigData.nRadio_IRColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_GRAY;
			}
			else if( btnRadioCDIBW.Checked == true )
			{
				m_objConfigData.nRadio_IRColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_BW;
			}

			m_objConfigData.nCombo_Resolution           = GetValueResolutionCombobox();

			m_objConfigData.byNumeric_NumberOfDocuments = Convert.ToByte(udNumberOfDocuments.Value);

			m_objConfigData.bCheck_Scan_SaveFile        = btnCheckSCSaveFile.Checked;

			////////////////
			//// Step 3 ////
			////////////////

			if( btnRadioMFE13B.Checked == true )
			{
				m_objConfigData.nRadio_MICRFont = ConstComVal.VAL_CONFIGDLG_RADIO_MF_E13B;
			}
			else if( btnRadioMFCMC7.Checked == true )
			{
				m_objConfigData.nRadio_MICRFont = ConstComVal.VAL_CONFIGDLG_RADIO_MF_CMC7;
			}
			else
			{
				Debug.Assert(false);
			}

			m_objConfigData.bCheck_MICR_ClearSpace = btnCheckMIClearSpace.Checked;
			m_objConfigData.bCheck_MICR_SaveFile   = btnCheckMISaveFile.Checked;
		}

		private void UpdateControls()
		{
			////////////////
			//// Step 2 ////
			////////////////

			// LightSource
			if (btnRadioSMCard.Checked == true &&
				m_objConfigData.bIsScanningCardIR1PassSupported == false)
			{
				btnRadioICRGBIR.Enabled = false;

				if (btnRadioICRGBIR.Checked == true)
				{
					btnRadioICIR.Checked = true;
					btnRadioICRGBIR.Checked = false;
				}
			}
			else
			{
				btnRadioICRGBIR.Enabled = true;
			}

			// RGB ColorDepth Color
			if (btnRadioICIR.Checked == true)
			{
				btnRadioCDRColor.Enabled = false;
			}
			else
			{
				btnRadioCDRColor.Enabled = true;
			}

			// RGB ColorDepth Gray
			if (btnRadioICIR.Checked == true)
			{
				btnRadioCDRGray.Enabled = false;
			}
			else
			{
				btnRadioCDRGray.Enabled = true;
			}

			// RGB ColorDepth B/W
			if (btnRadioICIR.Checked == true || btnRadioSMCard.Checked == true)
			{
				btnRadioCDRBW.Enabled = false;
			}
			else
			{
				btnRadioCDRBW.Enabled = true;
			}

			// IR ColorDepth Gray
			if (btnRadioICRGB.Checked == true)
			{
				btnRadioCDIGray.Enabled = false;
			}
			else
			{
				btnRadioCDIGray.Enabled = true;
			}

			// IR ColorDepth B/W
			if (btnRadioICRGB.Checked == true || btnRadioSMCard.Checked == true)
			{
				btnRadioCDIBW.Enabled = false;
			}
			else
			{
				btnRadioCDIBW.Enabled = true;
			}

			if (btnRadioCDRBW.Checked == true && btnRadioCDRGray.Enabled.Equals(true) && !btnRadioCDRBW.Enabled.Equals(true))
			{
				btnRadioCDRColor.Checked = false;
				btnRadioCDRGray.Checked  = true;
				btnRadioCDRBW.Checked    = false;
			}
			if (btnRadioCDIBW.Checked == true && btnRadioCDIGray.Enabled.Equals(true) && !btnRadioCDIBW.Enabled.Equals(true))
			{
				btnRadioCDIGray.Checked = true;
				btnRadioCDIBW.Checked   = false;
			}

			// Updating resolution options for scanning unit
			string strResolution = cmbResolution.Text;
			if (btnRadioSMCheckPaper.Checked == true)
			{
				cmbResolution.Items.Clear();
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_300300);
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_240240);
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_200200);
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_120120);
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_100100);
				cmbResolution.SelectedIndex = 2;
			}
			else if (btnRadioSMCard.Checked == true)
			{
				cmbResolution.Items.Clear();
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_600600);
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_300300);
				cmbResolution.Items.Add(ConstComStr.STR_CONFIGDLG_COMBO_RE_200200);
				cmbResolution.SelectedIndex = 1;
			}
			else
			{
				Debug.Assert(false);
			}
			// restore the selection.
			int nIndex = cmbResolution.FindString(strResolution);
			if (nIndex != -1)
			{
				cmbResolution.SelectedIndex = nIndex;
			}

			////////////////
			//// Step 3 ////
			////////////////

			if( btnRadioSMCard.Checked == true )
			{
				btnRadioMFE13B.Enabled          = false;
				btnRadioMFCMC7.Enabled          = false;
				btnCheckMIClearSpace.Enabled    = false;
				btnCheckMISaveFile.Enabled      = false;
			}
			else if( btnRadioSMCheckPaper.Checked == true )
			{
				btnRadioMFE13B.Enabled          = true;
				btnRadioMFCMC7.Enabled          = true;
				btnCheckMIClearSpace.Enabled    = true;
				btnCheckMISaveFile.Enabled      = true;
			}
			else
			{
				Debug.Assert(false);
			}
		}

		////////////////
		//// Step 2 ////
		////////////////

		private void btnOK_Click(object sender, EventArgs e)
		{
			GetControlData();
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void OnChangeRadioScanningMedia(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void OnChangeRadioLightSource(object sender, EventArgs e)
		{
			UpdateControls();
		}

		////////////////
		//// Step 2 ////
		////////////////

		private void SetIndexResolutionCombobox(int nResolution)
		{
			string strResolution = "";
			switch (nResolution)
			{
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_600600: strResolution = ConstComStr.STR_CONFIGDLG_COMBO_RE_600600; break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_300300: strResolution = ConstComStr.STR_CONFIGDLG_COMBO_RE_300300; break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_240240: strResolution = ConstComStr.STR_CONFIGDLG_COMBO_RE_240240; break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_200200: strResolution = ConstComStr.STR_CONFIGDLG_COMBO_RE_200200; break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_120120: strResolution = ConstComStr.STR_CONFIGDLG_COMBO_RE_120120; break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_100100: strResolution = ConstComStr.STR_CONFIGDLG_COMBO_RE_100100; break;
				default:
					Debug.Assert(false);
					return;
			}
			int nIndex = cmbResolution.FindString(strResolution);
			if (nIndex != -1)
			{
				cmbResolution.SelectedIndex = nIndex;
			}
			else
			{
				cmbResolution.SelectedIndex = 0;
			}
		}

		private int GetValueResolutionCombobox()
		{
			switch (cmbResolution.SelectedItem.ToString())
			{
				case ConstComStr.STR_CONFIGDLG_COMBO_RE_600600: return ConstComVal.VAL_CONFIGDLG_COMBO_RE_600600;
				case ConstComStr.STR_CONFIGDLG_COMBO_RE_300300: return ConstComVal.VAL_CONFIGDLG_COMBO_RE_300300;
				case ConstComStr.STR_CONFIGDLG_COMBO_RE_240240: return ConstComVal.VAL_CONFIGDLG_COMBO_RE_240240;
				case ConstComStr.STR_CONFIGDLG_COMBO_RE_200200: return ConstComVal.VAL_CONFIGDLG_COMBO_RE_200200;
				case ConstComStr.STR_CONFIGDLG_COMBO_RE_120120: return ConstComVal.VAL_CONFIGDLG_COMBO_RE_120120;
				case ConstComStr.STR_CONFIGDLG_COMBO_RE_100100: return ConstComVal.VAL_CONFIGDLG_COMBO_RE_100100;
				default:
					Debug.Assert(false);
					return -1;
			}
		}
	}
}
