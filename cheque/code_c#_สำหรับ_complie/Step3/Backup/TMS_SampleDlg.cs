using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using com.epson.bank.driver;

namespace TMS_Sample
{
	public partial class TMS_SampleForm : Form
	{
		private CApp            m_objDriverControl  = null;
		private StructByStep    m_objConfigData     = null;

		private delegate DialogResult ShowMessageType(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
		private delegate void ShowErrorMessageType(ErrorCode errResult);
		// Step 2
		private delegate void DisplayImageDataType();
		// Step 3
		private delegate void DisplayMicrTextType(ErrorCode errResult, CMicrResult objMicrResult);

		// Deligates to invoke
		ShowMessageType      ShowMessage      = null;
		ShowErrorMessageType ShowErrorMessage = null;
		// Step 2
		DisplayImageDataType DisplayImageData = null;
		// Step 3
		DisplayMicrTextType  DisplayMicrText  = null;

		// Step 1
		private bool m_bScanCancelError = false;

		// Step 2
		private Bitmap m_Image2Front    = null;
		private Bitmap m_Image2Back     = null;
		private Bitmap m_Image4RGBFront = null;
		private Bitmap m_Image4RGBBack  = null;
		private Bitmap m_Image4IrFront  = null;
		private Bitmap m_Image4IrBack   = null;

		public TMS_SampleForm()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
				// end process
				ErrorCode errRet = ErrorCode.SUCCESS;

				try
				{
					if (m_objDriverControl != null)
					{
						errRet = TerminateDriver();
						if (errRet != ErrorCode.SUCCESS)
						{
							ShowErrorMessage(errRet);
						}
					}
				}
				catch
				{
					base.Dispose(disposing);
				}
			}
			base.Dispose(disposing);
		}

		// Windows 64-bit has problem with FormLoad and unhandled exception, be carefull.
		// http://social.msdn.microsoft.com/Forums/vstudio/en-US/69a0b831-7782-4bd9-b910-25c85f18bceb/visual-studio-doesnt-break-on-unhandled-exception-with-windows-64bit?forum=vsdebug
		private void TMS_SampleForm_Load(object sender, EventArgs e)
		{
			// Create driver and data instance
			try
			{
				// Setting up deligates to invoke
				ShowMessage      = new ShowMessageType(ShowMessageImpl);
				ShowErrorMessage = new ShowErrorMessageType(ShowErrorMessageImpl);
				// Step 2
				DisplayImageData = new DisplayImageDataType(DisplayImageDataImpl);
				// Step 3
				DisplayMicrText  = new DisplayMicrTextType(DisplayMicrTextImpl);

				// Create driver and data instance
				m_objDriverControl = new CApp();
				m_objConfigData    = new StructByStep();

				if (InitializeDriver() != true)
				{
					this.Close();
					return;
				}

				// Initialize data
				InitializeConfigData();

				// Initialize controls
				LoadResourceString();
				UpdateControls();
			}
			catch (Exception ex)
			{
				ShowMessage(ex.Message, ConstComStr.CAPTION_06_000, MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}
		}

		/////////////////////////////////////////////////////////////////
		// Procedure of DriveControl Callback
		/////////////////////////////////////////////////////////////////

		////////////////
		//// Step 1 ////
		////////////////

		private void CallbackProcProcessError(ErrorCode errResult)
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			ASB eStatus = new ASB();
			// Display message box correspondent to error
			switch( errResult )
			{
				case ErrorCode.ERR_COVER_OPEN:
					do
					{
						ShowMessage(ConstComStr.MSG_01_001, ConstComStr.CAPTION_01_001, MessageBoxButtons.OK, MessageBoxIcon.Error);
						m_objDriverControl.GetDeviceStatus(ref eStatus);
					} while ((eStatus & ASB.ASB_COVER_OPEN) == ASB.ASB_COVER_OPEN);
					m_objDriverControl.CancelError();
					break;

				case ErrorCode.ERR_PAPER_JAM:
					if (m_objConfigData.nRadio_ScanningMedia == ConstComVal.VAL_CONFIGDLG_RADIO_SM_CHECKPAPER)
					{
						do
						{
							ShowMessage(ConstComStr.MSG_02_000, ConstComStr.CAPTION_02_000, MessageBoxButtons.OK, MessageBoxIcon.Error);
							m_objDriverControl.GetDeviceStatus(ref eStatus);
						} while (((eStatus & ASB.ASB_EJECT_SENSOR_NO_PAPER) != ASB.ASB_EJECT_SENSOR_NO_PAPER)
										|| ((eStatus & ASB.ASB_SLIP_PAPER_SIZE) != ASB.ASB_SLIP_PAPER_SIZE)
										|| ((eStatus & ASB.ASB_PAPER_INTERMEDIATE) != ASB.ASB_PAPER_INTERMEDIATE));
						m_objDriverControl.CancelError();
					}
					else
					{
						ShowMessage(ConstComStr.MSG_02_000, ConstComStr.CAPTION_02_000, MessageBoxButtons.OK, MessageBoxIcon.Error);
						m_objDriverControl.CancelError();
					}
					break;

				case ErrorCode.ERR_ACCESS:
					ShowErrorMessage(errResult);
					m_objDriverControl.CancelError();
					break;

				case ErrorCode.ERR_MICR_BADDATA:
				case ErrorCode.ERR_MICR_NODATA:
				case ErrorCode.ERR_PRINT_DATA_UNRECEIVE:
					break;

				default:
					ShowErrorMessage(errResult);
					m_objDriverControl.CancelError();
					break;
			}
		}

		////////////////
		//// Step 2 ////
		////////////////

		private void DisplayImageDataImpl()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(DisplayImageData, new object[] { });
				return;
			}
			DrawImage(stImage2Front,    m_Image2Front);
			DrawImage(stImage2Back,     m_Image2Back);
			DrawImage(stImage4RGBFront, m_Image4RGBFront);
			DrawImage(stImage4RGBBack,  m_Image4RGBBack);
			DrawImage(stImage4IRFront,  m_Image4IrFront);
			DrawImage(stImage4IRBack,   m_Image4IrBack);
			this.Refresh();
		}

		private void CallbackProcImage()
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			// Save image if necessary
			bool bSave = (m_objConfigData.bCheck_Scan_SaveFile == ConstComVal.VAL_CONFIGDLG_CHECK_SC_SAVEFILE_ON);

			CScanParam objScanParam = new CScanParam();
			m_objDriverControl.GetScanParam(ref objScanParam);

			// Configure display data for each scanning side and light source
			if (m_objConfigData.nRadio_LightSourceToScan == ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGB)
			{
				// Configure 2 plane data for RGB image
				UpdateImageData(ScanSide.MF_SCAN_FACE_FRONT, ImageType.MF_SCAN_IMAGE_VISIBLE, objScanParam.GetResolution(), objScanParam.GetRGBColorDepth(), ref m_Image2Front, bSave);
				UpdateImageData(ScanSide.MF_SCAN_FACE_BACK,  ImageType.MF_SCAN_IMAGE_VISIBLE, objScanParam.GetResolution(), objScanParam.GetRGBColorDepth(), ref m_Image2Back,  bSave);
			}
			else if (m_objConfigData.nRadio_LightSourceToScan == ConstComVal.VAL_CONFIGDLG_RADIO_IC_IR)
			{
				// Configure 2 plane data for IR image
				UpdateImageData(ScanSide.MF_SCAN_FACE_FRONT, ImageType.MF_SCAN_IMAGE_INFRARED, objScanParam.GetResolution(), objScanParam.GetIRColorDepth(), ref m_Image2Front, bSave);
				UpdateImageData(ScanSide.MF_SCAN_FACE_BACK,  ImageType.MF_SCAN_IMAGE_INFRARED, objScanParam.GetResolution(), objScanParam.GetIRColorDepth(), ref m_Image2Back,  bSave);
			}
			else if (m_objConfigData.nRadio_LightSourceToScan == ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGBIR)
			{
				// Configure 4 plane image
				UpdateImageData(ScanSide.MF_SCAN_FACE_FRONT, ImageType.MF_SCAN_IMAGE_VISIBLE,  objScanParam.GetResolution(), objScanParam.GetRGBColorDepth(), ref m_Image4RGBFront, bSave);
				UpdateImageData(ScanSide.MF_SCAN_FACE_BACK,  ImageType.MF_SCAN_IMAGE_VISIBLE,  objScanParam.GetResolution(), objScanParam.GetRGBColorDepth(), ref m_Image4RGBBack,  bSave);
				UpdateImageData(ScanSide.MF_SCAN_FACE_FRONT, ImageType.MF_SCAN_IMAGE_INFRARED, objScanParam.GetResolution(), objScanParam.GetIRColorDepth(),  ref m_Image4IrFront,  bSave);
				UpdateImageData(ScanSide.MF_SCAN_FACE_BACK,  ImageType.MF_SCAN_IMAGE_INFRARED, objScanParam.GetResolution(), objScanParam.GetIRColorDepth(),  ref m_Image4IrBack,   bSave);
			}
			else
			{
				Debug.Assert(false);
			}

			DisplayImageData();
		}

		////////////////
		//// Step 3 ////
		////////////////

		private void CallbackProcMicr()
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			// Obtain MICR data
			CMicrResult cMicrResult = new CMicrResult();
			ErrorCode errResult = m_objDriverControl.GetMicr(ref cMicrResult);
			DisplayMicrText(errResult, cMicrResult); // Deligate to DisplayMicrTextImpl

			// Save MICR data if necessary
			if (m_objConfigData.bCheck_MICR_SaveFile == ConstComVal.VAL_CONFIGDLG_CHECK_MI_SAVEFILE_ON)
			{
				SaveMicrText(errResult, cMicrResult);
			}
		}

		private void DisplayMicrTextImpl(ErrorCode errResult, CMicrResult cMicrResult)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(DisplayMicrText, new object[] { errResult, cMicrResult });
				return;
			}

			if (errResult == ErrorCode.SUCCESS)
			{
				edtMicrText.Text = cMicrResult.GetMicrStr();
			}
			else
			{
				edtMicrText.Text = GetErrorString(errResult);
			}
		}

		/////////////////////////////////////////////////////////////////
		// CTMS_SampleDlg message handlers
		/////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////////////
		// Button Event
		/////////////////////////////////////////////////////////////////

		////////////////
		//// Step 1 ////
		////////////////

		private void btnScan_Click(object sender, EventArgs e)
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			////////////////////////////////////////
			// Reset controls before to start scaning

			// Step 2
			ClearImage();

			// Step 3
			edtMicrText.Text = "";

			////////////////////////////////////////
			// Start scanning image

			// Step 2
			if (m_objConfigData.nRadio_ScanningMedia == ConstComVal.VAL_CONFIGDLG_RADIO_SM_CHECKPAPER)
			{
				// Step 1
				ErrorCode errRet = m_objDriverControl.ScanCheck();
				if (errRet != ErrorCode.SUCCESS)
				{
					ShowErrorMessage(errRet);
					m_objDriverControl.CancelError();
					return;
				}
			}
			else if (m_objConfigData.nRadio_ScanningMedia == ConstComVal.VAL_CONFIGDLG_RADIO_SM_CARD)
			{
				ErrorCode errRet = m_objDriverControl.ScanCard();
				if (errRet != ErrorCode.SUCCESS)
				{
					ShowErrorMessage(errRet);
					m_objDriverControl.CancelError();
					return;
				}
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				Close();
				return;
			}

			ErrorCode errRet = m_objDriverControl.ExitDevice();
			if (errRet != ErrorCode.SUCCESS)
			{
				ShowErrorMessage(errRet);
			}
			Close();
		}

		private void btnScanCancel_Click(object sender, EventArgs e)
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			ErrorCode errRet = m_objDriverControl.CancelScan();
			if (errRet != ErrorCode.SUCCESS)
			{
				m_bScanCancelError = true;
				ShowErrorMessage(errRet);
				m_objDriverControl.CancelError();
			}
		}

		////////////////
		//// Step 2 ////
		////////////////

		private void btnConfig_Click(object sender, EventArgs e)
		{
			ConfigureForm cConfigureDlg = new ConfigureForm();

			cConfigureDlg.SetConfigData(m_objConfigData);

			if (cConfigureDlg.ShowDialog(this) == DialogResult.OK)
			{
				cConfigureDlg.GetConfigData(ref m_objConfigData);

				////////////////
				//// Step 2 ////
				////////////////

				CScanParam objScanParam = new CScanParam();
				ConvertConfigDataToScanParam(m_objConfigData, ref objScanParam);
				if (m_objDriverControl != null)
				{
					m_objDriverControl.SetScanParam(objScanParam);
				}

				////////////////
				//// Step 3 ////
				////////////////

				CMicrParam cMicrParam = new CMicrParam();
				ConvertConfigDataToMicrParam(m_objConfigData, ref cMicrParam);
				if (m_objDriverControl != null)
				{
					m_objDriverControl.SetMicrParam(cMicrParam);
				}

				UpdateControls();
			}
		}

		////////////////
		//// Step 3 ////
		////////////////

		private void btnMicrCleaning_Click(object sender, EventArgs e)
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			ErrorCode errRet = m_objDriverControl.CleaningMicr();
			if (errRet != ErrorCode.SUCCESS)
			{
				ShowErrorMessage(errRet);
				m_objDriverControl.CancelError();
			}
		}

		/////////////////////////////////////////////////////////////////
		// Member functions
		/////////////////////////////////////////////////////////////////

		private bool InitializeDriver()
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return false;
			}

			ErrorCode errResult = ErrorCode.SUCCESS;
			DialogResult drRet = 0;
			string strResult = null;

			// Open device and register callback functions
			errResult = m_objDriverControl.InitDevice();
			while (errResult != ErrorCode.SUCCESS)
			{
				if (errResult == ErrorCode.ERR_UNKNOWN)
				{
					drRet = ShowMessage(ConstComStr.MSG_06_000, ConstComStr.CAPTION_06_000, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				}
				else
				{
					strResult = GetErrorString(errResult);
					drRet = ShowMessage(ConstComStr.MSG_00_000, strResult, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				}

				if (drRet == DialogResult.OK)
				{
					errResult = m_objDriverControl.InitDevice();
				}
				else
				{
					return false;
				}
			}

			// Specify callback function from DriverControl
			// Step 1
			m_objDriverControl.SetProcessErrorCallback(new CApp.CallbackProcProcessError(CallbackProcProcessError));
			// Step 2
			m_objDriverControl.SetImageCallback(new CApp.CallbackProcImage(CallbackProcImage));
			// Step 3
			m_objDriverControl.SetMicrCallback(new CApp.CallbackProcMicr(CallbackProcMicr));

			// Obtain connected device option
			// Step 2
			m_objConfigData.bIsScanningCardIR1PassSupported = m_objDriverControl.IsScanningCardIR1PassSupported();

			return true;
		}

		private ErrorCode TerminateDriver()
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return ErrorCode.ERR_NO_MEMORY;
			}

			ErrorCode errRet = m_objDriverControl.ExitDevice();
			if (errRet != ErrorCode.SUCCESS)
			{
				return errRet;
			}

			return errRet;
		}

		private DialogResult ShowMessageImpl(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			if (this.InvokeRequired)
			{
				return (DialogResult)this.Invoke(ShowMessage, new object[] { text, caption, buttons, icon });
			}
			return MessageBox.Show(text, caption, buttons, icon);
		}

		private void ShowErrorMessageImpl(ErrorCode errResult)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(ShowErrorMessage, new object[] { errResult });
				return;
			}

			switch (errResult)
			{
				case ErrorCode.ERR_TYPE:
					MessageBox.Show(ConstComStr.MSG_03_000, ConstComStr.CAPTION_03_000, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_OPENED:
					MessageBox.Show(ConstComStr.MSG_03_001, ConstComStr.CAPTION_03_001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_NO_PRINTER:
					MessageBox.Show(ConstComStr.MSG_03_002, ConstComStr.CAPTION_03_002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_NO_TARGET:
					MessageBox.Show(ConstComStr.MSG_03_003, ConstComStr.CAPTION_03_003, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_NO_MEMORY:
					MessageBox.Show(ConstComStr.MSG_03_004, ConstComStr.CAPTION_03_004, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_HANDLE:
					MessageBox.Show(ConstComStr.MSG_03_005, ConstComStr.CAPTION_03_005, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_TIMEOUT:
					MessageBox.Show(ConstComStr.MSG_03_006, ConstComStr.CAPTION_03_006, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_ACCESS:
					MessageBox.Show(ConstComStr.MSG_03_007, ConstComStr.CAPTION_03_007, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PARAM:
					MessageBox.Show(ConstComStr.MSG_03_008, ConstComStr.CAPTION_03_008, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_NOT_SUPPORT:
					MessageBox.Show(ConstComStr.MSG_03_009, ConstComStr.CAPTION_03_009, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_OFFLINE:
					MessageBox.Show(ConstComStr.MSG_03_010, ConstComStr.CAPTION_03_010, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_NOT_EPSON:
					MessageBox.Show(ConstComStr.MSG_03_011, ConstComStr.CAPTION_03_011, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_WITHOUT_CB:
					if (m_bScanCancelError == true)
					{
						MessageBox.Show(ConstComStr.MSG_03_012_01, ConstComStr.CAPTION_03_012, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						m_bScanCancelError = false;
					}
					else
					{
						MessageBox.Show(ConstComStr.MSG_03_012_00, ConstComStr.CAPTION_03_012, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					break;
				case ErrorCode.ERR_BUFFER_OVER_FLOW:
					MessageBox.Show(ConstComStr.MSG_03_013, ConstComStr.CAPTION_03_013, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_REGISTRY:
					MessageBox.Show(ConstComStr.MSG_03_014, ConstComStr.CAPTION_03_014, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PAPERINSERT_TIMEOUT:
					MessageBox.Show(ConstComStr.MSG_03_015, ConstComStr.CAPTION_03_015, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_FUNCTION:
					MessageBox.Show(ConstComStr.MSG_03_016, ConstComStr.CAPTION_03_016, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_MICR:
					MessageBox.Show(ConstComStr.MSG_03_017, ConstComStr.CAPTION_03_017, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_SCAN:
					MessageBox.Show(ConstComStr.MSG_03_018, ConstComStr.CAPTION_03_018, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_RESET:
					MessageBox.Show(ConstComStr.MSG_03_019, ConstComStr.CAPTION_03_019, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_ABORT:
					MessageBox.Show(ConstComStr.MSG_03_020, ConstComStr.CAPTION_03_020, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_MICR:
					MessageBox.Show(ConstComStr.MSG_03_021, ConstComStr.CAPTION_03_021, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_SCAN:
					MessageBox.Show(ConstComStr.MSG_03_022, ConstComStr.CAPTION_03_022, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_LINE_OVERFLOW:
					MessageBox.Show(ConstComStr.MSG_03_023, ConstComStr.CAPTION_03_023, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PAPER_PILED:
					MessageBox.Show(ConstComStr.MSG_03_024, ConstComStr.CAPTION_03_024, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PAPER_JAM:
					MessageBox.Show(ConstComStr.MSG_03_025, ConstComStr.CAPTION_03_025, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_COVER_OPEN:
					MessageBox.Show(ConstComStr.MSG_03_026, ConstComStr.CAPTION_03_026, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_MICR_NODATA:
					MessageBox.Show(ConstComStr.MSG_03_027, ConstComStr.CAPTION_03_027, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_MICR_BADDATA:
					MessageBox.Show(ConstComStr.MSG_03_028, ConstComStr.CAPTION_03_028, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_MICR_NOISE:
					MessageBox.Show(ConstComStr.MSG_03_029, ConstComStr.CAPTION_03_029, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_SCN_COMPRESS:
					MessageBox.Show(ConstComStr.MSG_03_030, ConstComStr.CAPTION_03_030, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PAPER_EXIST:
					MessageBox.Show(ConstComStr.MSG_03_031, ConstComStr.CAPTION_03_031, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PAPER_INSERT:
					MessageBox.Show(ConstComStr.MSG_03_032, ConstComStr.CAPTION_03_032, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_SCAN_CHECK_CONTINUOUS:
					MessageBox.Show(ConstComStr.MSG_03_033, ConstComStr.CAPTION_03_033, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_SCAN_CHECK_ONEBYONE:
					MessageBox.Show(ConstComStr.MSG_03_034, ConstComStr.CAPTION_03_034, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_SCAN_IDCARD:
					MessageBox.Show(ConstComStr.MSG_03_035, ConstComStr.CAPTION_03_035, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_PRINT_ROLLPAPER:
					MessageBox.Show(ConstComStr.MSG_03_036, ConstComStr.CAPTION_03_036, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_EXEC_PRINT_VALIDATION:
					MessageBox.Show(ConstComStr.MSG_03_037, ConstComStr.CAPTION_03_037, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_THREAD:
					MessageBox.Show(ConstComStr.MSG_03_038, ConstComStr.CAPTION_03_038, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_IMAGE_FILEOPEN:
					MessageBox.Show(ConstComStr.MSG_03_039, ConstComStr.CAPTION_03_039, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_IMAGE_UNKNOWNFORMAT:
					MessageBox.Show(ConstComStr.MSG_03_040, ConstComStr.CAPTION_03_040, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_SIZE:
					MessageBox.Show(ConstComStr.MSG_03_041, ConstComStr.CAPTION_03_041, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_NOT_FOUND:
					MessageBox.Show(ConstComStr.MSG_03_042, ConstComStr.CAPTION_03_042, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_NOT_EXEC:
					MessageBox.Show(ConstComStr.MSG_03_043, ConstComStr.CAPTION_03_043, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_BARCODE_NODATA:
					MessageBox.Show(ConstComStr.MSG_03_044, ConstComStr.CAPTION_03_044, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_MICR_PARSE:
					MessageBox.Show(ConstComStr.MSG_03_045, ConstComStr.CAPTION_03_045, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_SCN_IQA:
					MessageBox.Show(ConstComStr.MSG_03_046, ConstComStr.CAPTION_03_046, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PRINT_DATA_LENGTH_EXCEED:
					MessageBox.Show(ConstComStr.MSG_03_047, ConstComStr.CAPTION_03_047, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_PRINT_DATA_UNRECEIVE:
					MessageBox.Show(ConstComStr.MSG_03_048, ConstComStr.CAPTION_03_048, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_INK_STATUS:
					MessageBox.Show(ConstComStr.MSG_03_050, ConstComStr.CAPTION_03_051, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case ErrorCode.ERR_IMAGE_FILEREAD:
					MessageBox.Show(ConstComStr.MSG_03_049, ConstComStr.CAPTION_03_049, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				default:
					MessageBox.Show(errResult.ToString(), "ERR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
			}
		}

		private string GetErrorString(ErrorCode errResultCode)
		{
			switch( errResultCode )
			{
				case ErrorCode.SUCCESS:
					return ConstComStr.CAPTION_00_000;
				case ErrorCode.ERR_TYPE:
					return ConstComStr.CAPTION_03_000;
				case ErrorCode.ERR_OPENED:
					return ConstComStr.CAPTION_03_001;
				case ErrorCode.ERR_NO_PRINTER:
					return ConstComStr.CAPTION_03_002;
				case ErrorCode.ERR_NO_TARGET:
					return ConstComStr.CAPTION_03_003;
				case ErrorCode.ERR_NO_MEMORY:
					return ConstComStr.CAPTION_03_004;
				case ErrorCode.ERR_HANDLE:
					return ConstComStr.CAPTION_03_005;
				case ErrorCode.ERR_TIMEOUT:
					return ConstComStr.CAPTION_03_006;
				case ErrorCode.ERR_ACCESS:
					return ConstComStr.CAPTION_03_007;
				case ErrorCode.ERR_PARAM:
					return ConstComStr.CAPTION_03_008;
				case ErrorCode.ERR_NOT_SUPPORT:
					return ConstComStr.CAPTION_03_009;
				case ErrorCode.ERR_OFFLINE:
					return ConstComStr.CAPTION_03_010;
				case ErrorCode.ERR_NOT_EPSON:
					return ConstComStr.CAPTION_03_011;
				case ErrorCode.ERR_WITHOUT_CB:
					return ConstComStr.CAPTION_03_012;
				case ErrorCode.ERR_BUFFER_OVER_FLOW:
					return ConstComStr.CAPTION_03_013;
				case ErrorCode.ERR_REGISTRY:
					return ConstComStr.CAPTION_03_014;
				case ErrorCode.ERR_PAPERINSERT_TIMEOUT:
					return ConstComStr.CAPTION_03_015;
				case ErrorCode.ERR_EXEC_FUNCTION:
					return ConstComStr.CAPTION_03_016;
				case ErrorCode.ERR_EXEC_MICR:
					return ConstComStr.CAPTION_03_017;
				case ErrorCode.ERR_EXEC_SCAN:
					return ConstComStr.CAPTION_03_018;
				case ErrorCode.ERR_RESET:
					return ConstComStr.CAPTION_03_019;
				case ErrorCode.ERR_ABORT:
					return ConstComStr.CAPTION_03_020;
				case ErrorCode.ERR_MICR:
					return ConstComStr.CAPTION_03_021;
				case ErrorCode.ERR_SCAN:
					return ConstComStr.CAPTION_03_022;
				case ErrorCode.ERR_LINE_OVERFLOW:
					return ConstComStr.CAPTION_03_023;
				case ErrorCode.ERR_PAPER_PILED:
					return ConstComStr.CAPTION_03_024;
				case ErrorCode.ERR_PAPER_JAM:
					return ConstComStr.CAPTION_03_025;
				case ErrorCode.ERR_COVER_OPEN:
					return ConstComStr.CAPTION_03_026;
				case ErrorCode.ERR_MICR_NODATA:
					return ConstComStr.CAPTION_03_027;
				case ErrorCode.ERR_MICR_BADDATA:
					return ConstComStr.CAPTION_03_028;
				case ErrorCode.ERR_MICR_NOISE:
					return ConstComStr.CAPTION_03_029;
				case ErrorCode.ERR_SCN_COMPRESS:
					return ConstComStr.CAPTION_03_030;
				case ErrorCode.ERR_PAPER_EXIST:
					return ConstComStr.CAPTION_03_031;
				case ErrorCode.ERR_PAPER_INSERT:
					return ConstComStr.CAPTION_03_032;
				case ErrorCode.ERR_EXEC_SCAN_CHECK_CONTINUOUS:
					return ConstComStr.CAPTION_03_033;
				case ErrorCode.ERR_EXEC_SCAN_CHECK_ONEBYONE:
					return ConstComStr.CAPTION_03_034;
				case ErrorCode.ERR_EXEC_SCAN_IDCARD:
					return ConstComStr.CAPTION_03_035;
				case ErrorCode.ERR_EXEC_PRINT_ROLLPAPER:
					return ConstComStr.CAPTION_03_036;
				case ErrorCode.ERR_EXEC_PRINT_VALIDATION:
					return ConstComStr.CAPTION_03_037;
				case ErrorCode.ERR_THREAD:
					return ConstComStr.CAPTION_03_038;
				case ErrorCode.ERR_IMAGE_FILEOPEN:
					return ConstComStr.CAPTION_03_039;
				case ErrorCode.ERR_IMAGE_UNKNOWNFORMAT:
					return ConstComStr.CAPTION_03_040;
				case ErrorCode.ERR_SIZE:
					return ConstComStr.CAPTION_03_041;
				case ErrorCode.ERR_NOT_FOUND:
					return ConstComStr.CAPTION_03_042;
				case ErrorCode.ERR_NOT_EXEC:
					return ConstComStr.CAPTION_03_043;
				case ErrorCode.ERR_BARCODE_NODATA:
					return ConstComStr.CAPTION_03_044;
				case ErrorCode.ERR_MICR_PARSE:
					return ConstComStr.CAPTION_03_045;
				case ErrorCode.ERR_SCN_IQA:
					return ConstComStr.CAPTION_03_046;
				case ErrorCode.ERR_PRINT_DATA_LENGTH_EXCEED:
					return ConstComStr.CAPTION_03_047;
				case ErrorCode.ERR_PRINT_DATA_UNRECEIVE:
					return ConstComStr.CAPTION_03_048;
				case ErrorCode.ERR_INK_STATUS:
					return ConstComStr.CAPTION_03_051;
				case ErrorCode.ERR_IMAGE_FILEREAD:
					return ConstComStr.CAPTION_03_049;
				default:
					return errResultCode.ToString();
			}
		}

		// Step 2
		private void InitializeConfigData()
		{
			if (m_objConfigData == null)
			{
				return;
			}

			////////////////
			//// Step 2 ////
			////////////////

			CScanParam objScanParam = new CScanParam();
			m_objDriverControl.GetScanParam(ref objScanParam);
			ConvertScanParamToConfigData(objScanParam, ref m_objConfigData);

			////////////////
			//// Step 3 ////
			////////////////

			CMicrParam cMicrParam = new CMicrParam();
			m_objDriverControl.GetMicrParam(ref cMicrParam);
			ConvertMicrParamToConfigData(cMicrParam, ref m_objConfigData);
		}

		private void LoadResourceString()
		{
			////////////////
			//// Step 1 ////
			////////////////

			// Title
			this.Text               = ConstComStr.STR_SAMPLEDLG_TITLE;

			// Scan Button
			btnScan.Text            = ConstComStr.STR_SAMPLEDLG_BUTTON_SCAN;

			// ScanCancel Button
			btnScanCancel.Text      = ConstComStr.STR_SAMPLEDLG_BUTTON_SCANCANCEL;

			// Exit Button
			btnExit.Text            = ConstComStr.STR_SAMPLEDLG_BUTTON_EXIT;

			////////////////
			//// Step 2 ////
			////////////////

			// Config Button
			btnConfig.Text          = ConstComStr.STR_SAMPLEDLG_BUTTON_CONFIG;

			////////////////
			//// Step 3 ////
			////////////////

			// MICR Text Static
			stMicrText.Text         = ConstComStr.STR_SAMPLEDLG_STATIC_MICRTEXT;

			// Micr Cleaning Button
			btnMicrCleaning.Text    = ConstComStr.STR_SAMPLEDLG_BUTTON_MICRCLEANING;
		}

		private void UpdateControls()
		{
			////////////////
			//// Step 2 ////
			////////////////

			if (m_objConfigData.nRadio_LightSourceToScan == ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGBIR)
			{
				stImage2Front.Visible       = false;
				stImage2Back.Visible        = false;
				stImage4RGBFront.Visible    = true;
				stImage4RGBBack.Visible     = true;
				stImage4IRBack.Visible      = true;
				stImage4IRFront.Visible     = true;
			}
			else
			{
				stImage2Front.Visible       = true;
				stImage2Back.Visible        = true;
				stImage4RGBFront.Visible    = false;
				stImage4RGBBack.Visible     = false;
				stImage4IRBack.Visible      = false;
				stImage4IRFront.Visible     = false;
			}
		}

		// Step 2
		private void ConvertConfigDataToScanParam(StructByStep objConfigData, ref CScanParam objScanParam)
		{
			if (objScanParam == null || objConfigData == null)
			{
				Debug.Assert(false);
				return;
			}

			switch( objConfigData.nRadio_ScanningMedia )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_SM_CHECKPAPER:
					objScanParam.SetScanMedia(ScanUnit.EPS_BI_SCN_UNIT_CHECKPAPER);
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_SM_CARD:
					objScanParam.SetScanMedia(ScanUnit.EPS_BI_SCN_UNIT_CARD);
					break;
				default:
					break;
			}

			switch( objConfigData.nRadio_LightSourceToScan )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGB:
					if (objConfigData.nRadio_RGBColorDepth == ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_COLOR)
					{
						objScanParam.SetLightSourceToScan(ImageTypeOption.EPS_BI_SCN_OPTION_COLOR);
					}
					else
					{
						objScanParam.SetLightSourceToScan(ImageTypeOption.EPS_BI_SCN_OPTION_GRAYSCALE);
					}
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_IC_IR:
					objScanParam.SetLightSourceToScan(ImageTypeOption.EPS_BI_SCN_OPTION_IR);
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGBIR:
					if (objConfigData.nRadio_RGBColorDepth == ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_COLOR)
					{
						objScanParam.SetLightSourceToScan(ImageTypeOption.EPS_BI_SCN_OPTION_COLOR_IR);
					}
					else
					{
						objScanParam.SetLightSourceToScan(ImageTypeOption.EPS_BI_SCN_OPTION_GRAYSCALE_IR);
					}
					break;
				default:
					break;
			}

			switch( objConfigData.nRadio_RGBColorDepth )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_COLOR:
					objScanParam.SetRGBColorDepth(com.epson.bank.driver.ColorDepth.EPS_BI_SCN_24BIT);
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_GRAY:
					objScanParam.SetRGBColorDepth(com.epson.bank.driver.ColorDepth.EPS_BI_SCN_8BIT);
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_BW:
					objScanParam.SetRGBColorDepth(com.epson.bank.driver.ColorDepth.EPS_BI_SCN_1BIT);
					break;
				default:
					break;
			}

			switch( objConfigData.nRadio_IRColorDepth )
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_GRAY:
					objScanParam.SetIRColorDepth(com.epson.bank.driver.ColorDepth.EPS_BI_SCN_8BIT);
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_BW:
					objScanParam.SetIRColorDepth(com.epson.bank.driver.ColorDepth.EPS_BI_SCN_1BIT);
					break;
				default:
					break;
			}

			switch( objConfigData.nCombo_Resolution )
			{
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_600600:
					objScanParam.SetResolution(MfScanDpi.MF_SCAN_DPI_600);
					break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_300300:
					objScanParam.SetResolution(MfScanDpi.MF_SCAN_DPI_300);
					break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_240240:
					objScanParam.SetResolution(MfScanDpi.MF_SCAN_DPI_240);
					break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_200200:
					objScanParam.SetResolution(MfScanDpi.MF_SCAN_DPI_200);
					break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_120120:
					objScanParam.SetResolution(MfScanDpi.MF_SCAN_DPI_120);
					break;
				case ConstComVal.VAL_CONFIGDLG_COMBO_RE_100100:
					objScanParam.SetResolution(MfScanDpi.MF_SCAN_DPI_100);
					break;
				default:
					Debug.Assert(false);
					break;
			}

			objScanParam.SetNumberOfDocuments(objConfigData.byNumeric_NumberOfDocuments);
		}

		// Step 3
		private void ConvertConfigDataToMicrParam(StructByStep objConfigData, ref CMicrParam objMicrParam)
		{
			if (objMicrParam == null || objConfigData == null)
			{
				Debug.Assert(false);
				return;
			}

			switch (objConfigData.nRadio_MICRFont)
			{
				case ConstComVal.VAL_CONFIGDLG_RADIO_MF_E13B:
					objMicrParam.SetFont(MfMicrFont.MF_MICR_FONT_E13B);
					break;
				case ConstComVal.VAL_CONFIGDLG_RADIO_MF_CMC7:
					objMicrParam.SetFont(MfMicrFont.MF_MICR_FONT_CMC7);
					break;
				default:
					Debug.Assert(false);
					break;
			}

			switch (objConfigData.bCheck_MICR_ClearSpace)
			{
				case ConstComVal.VAL_CONFIGDLG_CHECK_MI_CLEARSPACE_ON:
					objMicrParam.SetClearSpace(true);
					break;
				case ConstComVal.VAL_CONFIGDLG_CHECK_MI_CLEARSPACE_OFF:
					objMicrParam.SetClearSpace(false);
					break;
				default:
					Debug.Assert(false);
					break;
			}

			switch (objConfigData.bCheck_MICR_SaveFile)
			{
				case ConstComVal.VAL_CONFIGDLG_CHECK_MI_SAVEFILE_ON:
					objMicrParam.SetParsing(true);
					break;
				case ConstComVal.VAL_CONFIGDLG_CHECK_MI_SAVEFILE_OFF:
					objMicrParam.SetParsing(false);
					break;
				default:
					Debug.Assert(false);
					break;
			}
		}

		// Step 2
		private void ConvertScanParamToConfigData(CScanParam objScanParam, ref StructByStep objConfigData)
		{
			if (objScanParam == null || objConfigData == null)
			{
				Debug.Assert(false);
				return;
			}

			switch( objScanParam.GetScanMedia() )
			{
				case ScanUnit.EPS_BI_SCN_UNIT_CHECKPAPER:
					objConfigData.nRadio_ScanningMedia = ConstComVal.VAL_CONFIGDLG_RADIO_SM_CHECKPAPER;
					break;
				case ScanUnit.EPS_BI_SCN_UNIT_CARD:
					objConfigData.nRadio_ScanningMedia = ConstComVal.VAL_CONFIGDLG_RADIO_SM_CARD;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			switch( objScanParam.GetLightSourceToScan() )
			{
				case ImageTypeOption.EPS_BI_SCN_OPTION_COLOR:
				case ImageTypeOption.EPS_BI_SCN_OPTION_GRAYSCALE:
				case ImageTypeOption.EPS_BI_SCN_OPTION_DROPOUT_RED:
				case ImageTypeOption.EPS_BI_SCN_OPTION_DROPOUT_GREEN:
				case ImageTypeOption.EPS_BI_SCN_OPTION_DROPOUT_BLUE:
					objConfigData.nRadio_LightSourceToScan = ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGB;
					break;
				case ImageTypeOption.EPS_BI_SCN_OPTION_IR:
					objConfigData.nRadio_LightSourceToScan = ConstComVal.VAL_CONFIGDLG_RADIO_IC_IR;
					break;
				case ImageTypeOption.EPS_BI_SCN_OPTION_COLOR_IR:
				case ImageTypeOption.EPS_BI_SCN_OPTION_GRAYSCALE_IR:
				case ImageTypeOption.EPS_BI_SCN_OPTION_DROPOUT_RED_IR:
				case ImageTypeOption.EPS_BI_SCN_OPTION_DROPOUT_GREEN_IR:
				case ImageTypeOption.EPS_BI_SCN_OPTION_DROPOUT_BLUE_IR:
					objConfigData.nRadio_LightSourceToScan = ConstComVal.VAL_CONFIGDLG_RADIO_IC_RGBIR;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			switch( objScanParam.GetRGBColorDepth() )
			{
				case com.epson.bank.driver.ColorDepth.EPS_BI_SCN_24BIT:
					objConfigData.nRadio_RGBColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_COLOR;
					break;
				case com.epson.bank.driver.ColorDepth.EPS_BI_SCN_8BIT:
					objConfigData.nRadio_RGBColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_GRAY;
					break;
				case com.epson.bank.driver.ColorDepth.EPS_BI_SCN_1BIT:
					objConfigData.nRadio_RGBColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_RGBCD_BW;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			switch( objScanParam.GetIRColorDepth() )
			{
				case com.epson.bank.driver.ColorDepth.EPS_BI_SCN_8BIT:
					objConfigData.nRadio_IRColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_GRAY;
					break;
				case com.epson.bank.driver.ColorDepth.EPS_BI_SCN_1BIT:
					objConfigData.nRadio_IRColorDepth = ConstComVal.VAL_CONFIGDLG_RADIO_IRCD_BW;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			switch( objScanParam.GetResolution() )
			{
				case MfScanDpi.MF_SCAN_DPI_600:
					objConfigData.nCombo_Resolution = ConstComVal.VAL_CONFIGDLG_COMBO_RE_600600;
					break;
				case MfScanDpi.MF_SCAN_DPI_300:
					objConfigData.nCombo_Resolution = ConstComVal.VAL_CONFIGDLG_COMBO_RE_300300;
					break;
				case MfScanDpi.MF_SCAN_DPI_240:
					objConfigData.nCombo_Resolution = ConstComVal.VAL_CONFIGDLG_COMBO_RE_240240;
					break;
				case MfScanDpi.MF_SCAN_DPI_200:
					objConfigData.nCombo_Resolution = ConstComVal.VAL_CONFIGDLG_COMBO_RE_200200;
					break;
				case MfScanDpi.MF_SCAN_DPI_120:
					objConfigData.nCombo_Resolution = ConstComVal.VAL_CONFIGDLG_COMBO_RE_120120;
					break;
				case MfScanDpi.MF_SCAN_DPI_100:
					objConfigData.nCombo_Resolution = ConstComVal.VAL_CONFIGDLG_COMBO_RE_100100;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			objConfigData.byNumeric_NumberOfDocuments = objScanParam.GetNumberOfDocuments();
		}

		// Step 3
		private void ConvertMicrParamToConfigData(CMicrParam objMicrParam, ref StructByStep objConfigData)
		{
			if (objMicrParam == null || objConfigData == null)
			{
				Debug.Assert(false);
				return;
			}

			switch (objMicrParam.GetFont())
			{
				case MfMicrFont.MF_MICR_FONT_E13B:
					objConfigData.nRadio_MICRFont = ConstComVal.VAL_CONFIGDLG_RADIO_MF_E13B;
					break;
				case MfMicrFont.MF_MICR_FONT_CMC7:
					objConfigData.nRadio_MICRFont = ConstComVal.VAL_CONFIGDLG_RADIO_MF_CMC7;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			if (objMicrParam.GetClearSpace() == true)
			{
				objConfigData.bCheck_MICR_ClearSpace = ConstComVal.VAL_CONFIGDLG_CHECK_MI_CLEARSPACE_ON;
			}
			else
			{
				objConfigData.bCheck_MICR_ClearSpace = ConstComVal.VAL_CONFIGDLG_CHECK_MI_CLEARSPACE_OFF;
			}
		}

		// Step 2
		private string PrepareFolder()
		{
			string strPath = Path.Combine(Directory.GetCurrentDirectory(), "ScanResult");
			Directory.CreateDirectory(strPath);
			return strPath;
		}

		private void UpdateImageData(ScanSide eFace, ImageType eLightSource, MfScanDpi eResolution, com.epson.bank.driver.ColorDepth eColorDepth, ref Bitmap Image, bool bSave)
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			CImageResult cImageResult = new CImageResult();

			// Obtain image data
			cImageResult.SetFace(eFace);
			cImageResult.SetLightSource(eLightSource);
			cImageResult.SetResolution(eResolution);
			cImageResult.SetColorDepth(eColorDepth);

			// Show image on the window
			{
				cImageResult.SetFormat(Format.EPS_BI_SCN_BITMAP);
				ErrorCode errResult = m_objDriverControl.GetScanImage(ref cImageResult);
				if (errResult != ErrorCode.SUCCESS)
				{
					ShowErrorMessage(errResult);
					return;
				}

				Image = new Bitmap(cImageResult.GetBitmapImage());
			}
			// Save image
			if (bSave)
			{
				// Specify image data format
				string strExt;
				if (eColorDepth == com.epson.bank.driver.ColorDepth.EPS_BI_SCN_1BIT)
				{
					cImageResult.SetFormat(Format.EPS_BI_SCN_TIFF);
					strExt = "tif";
				}
				else
				{
					cImageResult.SetFormat(Format.EPS_BI_SCN_JPEGNORMAL);
					strExt = "jpg";
				}

				// Obtain image data
				ErrorCode errResult = m_objDriverControl.GetScanImage(ref cImageResult);
				if (errResult != ErrorCode.SUCCESS)
				{
					ShowErrorMessage(errResult);
					return;
				}

				try
				{
					if (cImageResult.GetImageData() != null)
					{
						Stream cImage = cImageResult.GetImageData();
						int nImageSize = cImageResult.GetImageSize();
						int nTransactionNumber = cImageResult.GetTransactionNumber();

						// Prepare folder to store data
						string strPath = PrepareFolder(); // may throw

						// Compose file name
						strPath = Path.Combine(
								strPath,
								nTransactionNumber.ToString("000") + ("_Image_")
									 + (cImageResult.GetLightSource() == ImageType.MF_SCAN_IMAGE_INFRARED ? "IR_" : "")
									 + (cImageResult.GetFace() == ScanSide.MF_SCAN_FACE_BACK ? "Back" : "Front") + (".")
									 + strExt);

						// Save in file
						using (FileStream fs = new FileStream(strPath, FileMode.Create))
						{
							byte[] byBuffer = new byte[cImageResult.GetImageSize()];

							cImageResult.GetImageData().Read(byBuffer, 0, byBuffer.Length);
							fs.Write(byBuffer, 0, byBuffer.Length);
							cImageResult.GetImageData().Close();
						}
					}
				}
				catch
				{
					ShowMessage(ConstComStr.MSG_05_000, ConstComStr.CAPTION_05_000, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void ClearImage()
		{
			if (stImage2Front.Image != null)
			{
				stImage2Front.Image.Dispose();
				stImage2Front.Image = null;
				m_Image2Front       = null;
			}
			if (stImage2Back.Image != null)
			{
				stImage2Back.Image.Dispose();
				stImage2Back.Image = null;
				m_Image2Back       = null;
			}
			if (stImage4RGBFront.Image != null)
			{
				stImage4RGBFront.Image.Dispose();
				stImage4RGBFront.Image = null;
				m_Image4RGBFront       = null;
			}
			if (stImage4RGBBack.Image != null)
			{
				stImage4RGBBack.Image.Dispose();
				stImage4RGBBack.Image = null;
				m_Image4RGBBack       = null;
			}
			if (stImage4IRBack.Image != null)
			{
				stImage4IRBack.Image.Dispose();
				stImage4IRBack.Image = null;
				m_Image4IrBack       = null;
			}
			if (stImage4IRFront.Image != null)
			{
				stImage4IRFront.Image.Dispose();
				stImage4IRFront.Image = null;
				m_Image4IrFront       = null;
			}
		}

		private void DrawImage(PictureBox stImage, Bitmap biImage)
		{
			if (stImage.Image != null)
			{
				stImage.Image.Dispose();
			}
			if (biImage == null)
			{
				return;
			}

			int nWidth = 0;
			int nHeight = 0;

			if ((biImage.Width * stImage.Height) < (stImage.Width * biImage.Height))
			{
				nWidth = stImage.Height * biImage.Width / biImage.Height;
				stImage.Image = new Bitmap(biImage, nWidth, stImage.Height);
			}
			else
			{
				nHeight = stImage.Width * biImage.Height / biImage.Width;
				stImage.Image = new Bitmap(biImage, stImage.Width, nHeight);
			}
		}

		// Step 3
		private void SaveMicrText(ErrorCode errResult, CMicrResult cMicrResult)
		{
			Debug.Assert(m_objDriverControl != null);
			if (m_objDriverControl == null)
			{
				return;
			}

			// Obtain MICR data
			int nTransactionNumber = cMicrResult.GetTransactionNumber();

			if (errResult != ErrorCode.SUCCESS)
			{
				ShowErrorMessage(errResult);
				return;
			}

			try
			{
				// Prepare folder to store data
				string strPath = PrepareFolder(); // may throw

				// Compose file name
				strPath = Path.Combine(
						strPath,
						nTransactionNumber.ToString("000") + ".Micr.txt");

				using (StreamWriter swFile = new StreamWriter(strPath))
				{
					// Transaction number
					swFile.WriteLine("# General Transaction Information:");
					swFile.WriteLine("TransactionNumber = " + nTransactionNumber.ToString());

					// MICR reading status
					swFile.WriteLine("");
					swFile.WriteLine("# Magnetic Character Results:");
					swFile.WriteLine("Status = " + cMicrResult.GetStatus().ToString());

					// Detail MICR reading status
					swFile.WriteLine("Detail = " + cMicrResult.GetDetail().ToString());

					// Return value from MICR recognition
					swFile.WriteLine("MicrResult = " + GetErrorString(cMicrResult.GetResult()));

					// Obtained MICR strings
					swFile.WriteLine("MicrString = " + (cMicrResult.GetMicrStr() != null ? cMicrResult.GetMicrStr() : ""));

					//MicrAccountNumber
					swFile.WriteLine("MicrAccountNumber = " + (cMicrResult.GetAccountNumber() != null ? cMicrResult.GetAccountNumber() : ""));

					//MicrAmount
					swFile.WriteLine("MicrAmount        = " + (cMicrResult.GetAmount() != null ? cMicrResult.GetAmount() : ""));

					//MicrBankNumber
					swFile.WriteLine("MicrBankNumber    = " + (cMicrResult.GetBankNumber() != null ? cMicrResult.GetBankNumber() : ""));

					//MicrSerialNumber
					swFile.WriteLine("MicrSerialNumber  = " + (cMicrResult.GetSerialNumber() != null ? cMicrResult.GetSerialNumber() : ""));

					//MicrEPC
					swFile.WriteLine("MicrEPC           = " + (cMicrResult.GetEPC() != null ? cMicrResult.GetEPC() : ""));

					// MicrTransitNumber
					swFile.WriteLine("MicrTransitNumber = " + (cMicrResult.GetTransitNumber() != null ? cMicrResult.GetTransitNumber() : ""));

					// MicrCheckType
					swFile.WriteLine("MicrCheckType     = " + cMicrResult.GetCheckType().ToString());

					// MicrCountryCode
					swFile.WriteLine("MicrCountryCode     = " + cMicrResult.GetCountryCode().ToString());

					// MicrOnUSField
					swFile.WriteLine("MicrOnUSField = " + (cMicrResult.GetOnUSField() != null ? cMicrResult.GetOnUSField() : ""));

					// MicrAuxiliatyOnUSField
					swFile.WriteLine("MicrAuxiliatyOnUSField = " + (cMicrResult.GetAuxiliatyOnUSField() != null ? cMicrResult.GetAuxiliatyOnUSField() : ""));
				}
			}
			catch
			{
				ShowMessage(ConstComStr.MSG_05_001, ConstComStr.CAPTION_05_001, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}
}
