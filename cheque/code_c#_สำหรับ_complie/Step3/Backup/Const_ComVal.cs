using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS_Sample
{
	public static class ConstComVal
	{
		// DialogMessage

		public enum DialogResult
		{
			OK = 0,
			Cancel = 1
		}

		// Main

		// Step 1
		public const int VAL_MAINDLG_ERR_PAPER_JAM    = 4;

		public const int ERR_LOAD_MODULE  = -1;

		// Config

		// Step 2
		public const int  VAL_CONFIGDLG_RADIO_SM_CHECKPAPER     = 0;
		public const int  VAL_CONFIGDLG_RADIO_SM_CARD           = 1;
		public const int  VAL_CONFIGDLG_RADIO_IC_RGB            = 0;
		public const int  VAL_CONFIGDLG_RADIO_IC_IR             = 1;
		public const int  VAL_CONFIGDLG_RADIO_IC_RGBIR          = 2;
		public const int  VAL_CONFIGDLG_RADIO_RGBCD_COLOR       = 0;
		public const int  VAL_CONFIGDLG_RADIO_RGBCD_GRAY        = 1;
		public const int  VAL_CONFIGDLG_RADIO_RGBCD_BW          = 2;
		public const int  VAL_CONFIGDLG_RADIO_IRCD_GRAY         = 0;
		public const int  VAL_CONFIGDLG_RADIO_IRCD_BW           = 1;
		public const bool VAL_CONFIGDLG_CHECK_SC_SAVEFILE_OFF   = false;
		public const bool VAL_CONFIGDLG_CHECK_SC_SAVEFILE_ON    = true;
		public const int  VAL_CONFIGDLG_COMBO_RE_600600         = 0;
		public const int  VAL_CONFIGDLG_COMBO_RE_300300         = 1;
		public const int  VAL_CONFIGDLG_COMBO_RE_240240	        = 2;
		public const int  VAL_CONFIGDLG_COMBO_RE_200200	        = 3;
		public const int  VAL_CONFIGDLG_COMBO_RE_120120	        = 4;
		public const int  VAL_CONFIGDLG_COMBO_RE_100100         = 5;

		// Step 3
		public const int  VAL_CONFIGDLG_RADIO_MF_E13B               = 0;
		public const int  VAL_CONFIGDLG_RADIO_MF_CMC7               = 1;
		public const bool VAL_CONFIGDLG_CHECK_MI_CLEARSPACE_OFF     = false;
		public const bool VAL_CONFIGDLG_CHECK_MI_CLEARSPACE_ON      = true;
		public const bool VAL_CONFIGDLG_CHECK_MI_SAVEFILE_OFF       = false;
		public const bool VAL_CONFIGDLG_CHECK_MI_SAVEFILE_ON        = true;
	}
}
