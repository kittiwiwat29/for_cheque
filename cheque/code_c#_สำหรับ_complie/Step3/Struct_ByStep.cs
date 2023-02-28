using System;

namespace TMS_Sample
{
	public class StructByStep
	{
		// Step 2
		public int	nRadio_ScanningMedia;
		public int	nRadio_LightSourceToScan;
		public int	nRadio_RGBColorDepth;
		public int	nRadio_IRColorDepth;
		public int	nCombo_Resolution;
		public byte byNumeric_NumberOfDocuments;
		public bool bCheck_Scan_SaveFile;
		public bool bIsScanningCardIR1PassSupported;

		// Step 3
		public int	nRadio_MICRFont;
		public bool bCheck_MICR_ClearSpace;
		public bool bCheck_MICR_SaveFile;

		public StructByStep()
		{
			// Step 2
			nRadio_ScanningMedia      = ConstComVal.VAL_CONFIGDLG_RADIO_SM_CHECKPAPER;
			nRadio_LightSourceToScan  = ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGB;
			nRadio_RGBColorDepth      = ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_COLOR;
			nRadio_IRColorDepth       = ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_GRAY;
			bCheck_Scan_SaveFile      = ConstComVal.VAL_CONFIGDLG_CHECK_SC_SAVEFILE_ON;
			nCombo_Resolution         = ConstComVal.VAL_CONFIGDLG_COMBO_RE_200200;
			bIsScanningCardIR1PassSupported = false;

			// Step 3
			nRadio_MICRFont           = ConstComVal.VAL_CONFIGDLG_RADIO_MF_E13B;
			bCheck_MICR_ClearSpace    = ConstComVal.VAL_CONFIGDLG_CHECK_MI_CLEARSPACE_OFF;
			bCheck_MICR_SaveFile      = ConstComVal.VAL_CONFIGDLG_CHECK_MI_SAVEFILE_OFF;
		}

		public void Copy(StructByStep sData)
		{
			// Step 2
			nRadio_ScanningMedia      = sData.nRadio_ScanningMedia;
			nRadio_LightSourceToScan  = sData.nRadio_LightSourceToScan;
			nRadio_RGBColorDepth      = sData.nRadio_RGBColorDepth;
			nRadio_IRColorDepth       = sData.nRadio_IRColorDepth;
			nCombo_Resolution         = sData.nCombo_Resolution;
			byNumeric_NumberOfDocuments = sData.byNumeric_NumberOfDocuments;
			bCheck_Scan_SaveFile      = sData.bCheck_Scan_SaveFile;
			bIsScanningCardIR1PassSupported = sData.bIsScanningCardIR1PassSupported;

			// Step 3
			nRadio_MICRFont           = sData.nRadio_MICRFont;
			bCheck_MICR_ClearSpace    = sData.bCheck_MICR_ClearSpace;
			bCheck_MICR_SaveFile      = sData.bCheck_MICR_SaveFile;
		}
	}
}
