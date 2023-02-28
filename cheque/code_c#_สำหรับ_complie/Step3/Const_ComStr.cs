using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS_Sample
{
	public static class ConstComStr
	{
		// Mutex
		public const string STR_NAME_MUTEX                      = "Mutex EPSON TM-S Sample Program Step3";

		// Resource String

		// Main Dialog
		// Step 1
		public const string STR_SAMPLEDLG_TITLE					= "TM-S Sample Program";
		public const string STR_SAMPLEDLG_BUTTON_SCAN			= "Scan";
		public const string STR_SAMPLEDLG_BUTTON_SCANCANCEL		= "Cancel";
		public const string STR_SAMPLEDLG_BUTTON_EXIT			= "Exit";

		// Step 2
		public const string STR_SAMPLEDLG_BUTTON_CONFIG			= "Configuration";

		// Step 3
		public const string STR_SAMPLEDLG_STATIC_MICRTEXT		= "MICR";
		public const string STR_SAMPLEDLG_BUTTON_MICRCLEANING	= "MICR Cleaning";

		// Config Dialog
		// Step 2
		public const string STR_CONFIGDLG_BUTTON_OK				= "OK";
		public const string STR_CONFIGDLG_BUTTON_CANCEL			= "Cancel";

		public const string STR_CONFIGDLG_GROUP_SCANNING		= "Scan";
		public const string STR_CONFIGDLG_GROUP_SCANNINGMEDIA	= "Media";
		public const string STR_CONFIGDLG_GROUP_LIGHTSOURCE		= "Scan Type";
		public const string STR_CONFIGDLG_GROUP_RGBCOLORDEPTH	= "RGB Image Type";
		public const string STR_CONFIGDLG_GROUP_IRCOLORDEPTH	= "IR Image Type";
		public const string STR_CONFIGDLG_STATIC_RESOLUTION		= "Resolution";
		public const string STR_CONFIGDLG_RADIO_SM_CHECKPAPER	= "Check";
		public const string STR_CONFIGDLG_RADIO_SM_CARD			= "Card";
		public const string STR_CONFIGDLG_RADIO_IC_RGB			= "RGB";
		public const string STR_CONFIGDLG_RADIO_IC_IR			= "IR";
		public const string STR_CONFIGDLG_RADIO_IC_RGBIR		= "RGB+IR";
		public const string STR_CONFIGDLG_RADIO_RGBCD_COLOR		= "Color";
		public const string STR_CONFIGDLG_RADIO_RGBCD_GRAY		= "Grayscale";
		public const string STR_CONFIGDLG_RADIO_RGBCD_BW		= "B / W";
		public const string STR_CONFIGDLG_RADIO_IRCD_GRAY		= "Grayscale";
		public const string STR_CONFIGDLG_RADIO_IRCD_BW			= "B / W";
		public const string STR_CONFIGDLG_CHECK_SC_SAVEFILE		= "Save to harddisk";

		public const string STR_CONFIGDLG_COMBO_RE_600600		= "600dpi x 600dpi";
		public const string STR_CONFIGDLG_COMBO_RE_300300		= "300dpi x 300dpi";
		public const string STR_CONFIGDLG_COMBO_RE_240240		= "240dpi x 240dpi";
		public const string STR_CONFIGDLG_COMBO_RE_200200		= "200dpi x 200dpi";
		public const string STR_CONFIGDLG_COMBO_RE_120120		= "120dpi x 120dpi";
		public const string STR_CONFIGDLG_COMBO_RE_100100		= "100dpi x 100dpi";

		// Step 3
		public const string STR_CONFIGDLG_GROUP_MICR			= "MICR";
		public const string STR_CONFIGDLG_GROUP_MICRFONT		= "MICR Font";
		public const string STR_CONFIGDLG_RADIO_MF_E13B			= "E13B";
		public const string STR_CONFIGDLG_RADIO_MF_CMC7			= "CMC7";
		public const string STR_CONFIGDLG_CHECK_MI_CLEARSPACE	= "Clear Spaces";
		public const string STR_CONFIGDLG_CHECK_MI_SAVEFILE		= "Save to harddisk";

		// Message String
		public const string MSG_00_000      = "Cannot communicate with the scanner.\r\nMake sure the scanner is connected and is powered on.";
		public const string MSG_00_001      = "Failed to open ini file. \r\nPlease put it in the same folder the executable file is located.";
		public const string MSG_00_002      = "Failed to open bmp file. \r\nPlease put it in the same folder the executable file is located.";
		public const string MSG_01_000      = "No roll paper.\r\ninstall roll paper, close the cover and then click OK.";
		public const string MSG_01_001      = "Cover is open.\r\nClose the cover and then click OK.";
		public const string MSG_01_002      = "Ink is low.\r\nReplace the ink cartridge.";
		public const string MSG_02_000      = "Paper jam occurred.\r\nRemove jammed paper and then click OK.";
		public const string MSG_03_000      = "Undefined parameter.";
		public const string MSG_03_001      = "The port is already used by the other application.\r\n Close the application.";
		public const string MSG_03_002      = "Device is powered off or is not connected..\r\n Check the device status.";
		public const string MSG_03_003      = "The installed USB driver is not supported.\r\nInstall the correct driver.";
		public const string MSG_03_004      = "Insufficient memory.\r\n Close other applications or add more memory.";
		public const string MSG_03_005      = "The handle parameter is incorrect.\r\n Ensure the handle parameter is the return value of BiOpenMonPrinter.";
		public const string MSG_03_006      = "API is not finished correctly.\r\n Check the device status.";
		public const string MSG_03_007      = "Accessing device is not possible.\r\n The device is used by another application.\r\nClose other applications and try again.";
		public const string MSG_03_008      = "Incorrect parameter.";
		public const string MSG_03_009      = "This API is not available.\r\n Ensure BiESCNEnable is called.";
		public const string MSG_03_010      = "The device is offline.\r\n Check the device status and try again.";
		public const string MSG_03_011      = "The device is not EPSON product.";
		public const string MSG_03_012_00   = "The callback is not registered.";
		public const string MSG_03_012_01   = "The scanner is not in operation.\r\n Call it while the scanner is scanning.";
		public const string MSG_03_013      = "Insufficient memory.";
		public const string MSG_03_014      = "Incorrect registry information.. \r\nReinstall the driver.";
		public const string MSG_03_015      = "Paper insertion timeout.\r\nInsert the paper and try again.";
		public const string MSG_03_016      = "Another API is running.\r\n Retry after it completed.";
		public const string MSG_03_017      = "Cannot execute because MICR reading is in progress.\r\nTry again when it is completed.";
		public const string MSG_03_018      = "Cannot execute because scanning is in progress.\r\nTry again when it is completed.";
		public const string MSG_03_019      = "The device is being reset.\r\n Try again after the reset is completed.";
		public const string MSG_03_020      = "Reading operation is canceled.";
		public const string MSG_03_021      = "MICR reading failed.";
		public const string MSG_03_022      = "Image scanning failed.";
		public const string MSG_03_023      = "Too many lines to print. \r\n Reduce the lines.";
		public const string MSG_03_024      = "Double feed is detected.";
		public const string MSG_03_025      = "Paper jam occurred.\r\n Operation is canceled.";
		public const string MSG_03_026      = "Cover open.\r\n Operation is canceled.";
		public const string MSG_03_027      = "No MICR data.";
		public const string MSG_03_028      = "MICR data is incorrect.";
		public const string MSG_03_029      = "External noise error.";
		public const string MSG_03_030      = "Image compressing error.\r\nProcessing is canceled.";
		public const string MSG_03_031      = "Paper exists on the feed path. \r\nRemove the paper.";
		public const string MSG_03_032      = "Paper insertion error.";
		public const string MSG_03_033      = "Cannot execute because continuous scanning is in progress.\r\n Try again when it is completed.";
		public const string MSG_03_034      = "Cannot execute because one by one scanning is in progress.\r\nTry again when it is completed.";
		public const string MSG_03_035      = "Cannot execute because card scanning is in progress.\r\n Try again when it is completed.";
		public const string MSG_03_036      = "Cannot execute because another application is printing on roll paper.\r\n Try again after printing is completed.";
		public const string MSG_03_037      = "Cannot execute because another application is printing on cut sheet paper.\r\n Try again after printing is completed.";
		public const string MSG_03_038      = "Failed to start a thread.";
		public const string MSG_03_039      = "Failed to open a file.\r\nCheck file path or authority.";
		public const string MSG_03_040      = "Specified file format is incorrect.\r\nSet correct file format.";
		public const string MSG_03_041      = "Cannot print in specified size.\r\nSet printing area correctly.";
		public const string MSG_03_042      = "Data not found.";
		public const string MSG_03_043      = "Scanning is not started.\r\n Try again.";
		public const string MSG_03_044      = "Failed to detect barcode.";
		public const string MSG_03_045      = "Failed to parse the MICR strings.";
		public const string MSG_03_046      = "It did not pass in IQA test.";
		public const string	MSG_03_047      = "Printing data length exceeds the paper size.";
		public const string MSG_03_048      = "Printing data is not received.";
		public const string MSG_03_049      = "Image file read error.";
		public const string MSG_03_050      = "Ink is low.\nReplace the ink cartridge.";
		public const string MSG_04_000      = "Already launched the application.";
		public const string MSG_05_000      = "Cannot create a folder.";
		public const string MSG_05_001      = "Cannot create a file.";
		public const string MSG_06_000      = "Failed to load a module.\r\nPlease make sure the driver is installed.";

		public const string CAPTION_00_000  = "SUCCESS";
		public const string CAPTION_01_000  = "Roll Paper Empty";
		public const string CAPTION_01_001  = "Cover Open";
		public const string CAPTION_01_002  = "Replace ink cartridge";
		public const string CAPTION_02_000  = "Paper Jam Error";
		public const string CAPTION_03_000  = "ERR_TYPE (-10)";
		public const string CAPTION_03_001  = "ERR_OPENED (-20)";
		public const string CAPTION_03_002  = "ERR_NO_PRINTER (-30)";
		public const string CAPTION_03_003  = "ERR_NO_TARGET(-40)";
		public const string CAPTION_03_004  = "ERR_NO_MEMORY (-50)";
		public const string CAPTION_03_005  = "ERR_HANDLE (-60)";
		public const string CAPTION_03_006  = "ERR_TIMEOUT (-70)";
		public const string CAPTION_03_007  = "ERR_ACCESS (-80)";
		public const string CAPTION_03_008  = "ERR_PARAM (-90)";
		public const string CAPTION_03_009  = "ERR_NOT_SUPPORT (-100)";
		public const string CAPTION_03_010  = "ERR_OFFLINE (-110)";
		public const string CAPTION_03_011  = "ERR_NOT_EPSON (-120)";
		public const string CAPTION_03_012  = "ERR_WITHOUT_CB (-130)";
		public const string CAPTION_03_013  = "ERR_BUFFER_OVER_FLOW (-140)";
		public const string CAPTION_03_014  = "ERR_REGISTRY (-150)";
		public const string CAPTION_03_015  = "ERR_PAPERINSERT_TIMEOUT (-300)";
		public const string CAPTION_03_016  = "ERR_EXEC_FUNCTION (-310) ";
		public const string CAPTION_03_017  = "ERR_EXEC_MICR (-320)";
		public const string CAPTION_03_018  = "ERR_EXEC_SCAN (-330)";
		public const string CAPTION_03_019  = "ERR_RESET(-400)";
		public const string CAPTION_03_020  = "ERR_ABORT (-430)";
		public const string CAPTION_03_021  = "ERR_MICR (-440)";
		public const string CAPTION_03_022  = "ERR_SCAN (-450)";
		public const string CAPTION_03_023  = "ERR_LINE_OVERFLOW (-460)";
		public const string CAPTION_03_024  = "ERR_PAPER_PILED(-1010)";
		public const string CAPTION_03_025  = "ERR_PAPER_JAM(-1020)";
		public const string CAPTION_03_026  = "ERR_COVER_OPEN(-1030)";
		public const string CAPTION_03_027  = "ERR_MICR_NODATA(-1040)";
		public const string CAPTION_03_028  = "ERR_MICR_BADDATA(-1050)";
		public const string CAPTION_03_029  = "ERR_MICR_NOISE(-1070)";
		public const string CAPTION_03_030  = "ERR_SCN_COMPRESS(-1080)";
		public const string CAPTION_03_031  = "ERR_PAPER_EXIST(-1090)";
		public const string CAPTION_03_032  = "ERR_PAPER_INSERT(-1100)";
		public const string CAPTION_03_033  = "ERR_EXEC_SCAN_CHECK_CONTINUOUS (-2000)";
		public const string CAPTION_03_034  = "ERR_EXEC_SCAN_CHECK_ONEBYONE (-2010)";
		public const string CAPTION_03_035  = "ERR_EXEC_SCAN_IDCARD (-2020)";
		public const string CAPTION_03_036  = "ERR_EXEC_PRINT_ROLLPAPER (-2030)";
		public const string CAPTION_03_037  = "ERR_EXEC_PRINT_VALIDATION (-2040)";
		public const string CAPTION_03_038  = "ERR_THREAD (-420)";
		public const string CAPTION_03_039  = "ERR_IMAGE_FILEOPEN(-230)";
		public const string CAPTION_03_040  = "ERR_IMAGE_UNKNOWNFORMAT(-240)";
		public const string CAPTION_03_041  = "ERR_SIZE(-1000)";
		public const string CAPTION_03_042  = "ERR_NOT_FOUND (-220)";
		public const string CAPTION_03_043  = "ERR_NOT_EXEC (-470)";
		public const string CAPTION_03_044  = "ERR_BARCODE_NODATA(-1130)";
		public const string CAPTION_03_045  = "ERR_MICR_PARSE(-1060)";
		public const string CAPTION_03_046  = "ERR_SCN_IQA(-1120)";
		public const string CAPTION_03_047  = "ERR_PRINT_DATA_LENGTH_EXCEED(-1180)";
		public const string CAPTION_03_048  = "ERR_PRINT_DATA_UNRECEIVE(-1190)";
		public const string CAPTION_03_049  = "ERR_IMAGE_FILEREAD(-290)";
		public const string CAPTION_03_051  = "ERR_INK_STATUS(-1200)";
		public const string CAPTION_04_000  = "Duplicate Running";
		public const string CAPTION_05_000  = "Fail to Create Folder";
		public const string CAPTION_05_001  = "Fail to Create File";
		public const string CAPTION_06_000  = "Fail to Load Module";
	}
}
