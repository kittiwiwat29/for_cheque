using System;
using System.Diagnostics;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CApp
	{
		public const byte EXEC_SCAN_CHECK   = 0;
		public const byte EXEC_SCAN_CARD    = 1;

		// Step 1
		public delegate void CallbackProcProcessError(ErrorCode errResult);
		// Step 2
		public delegate void CallbackProcImage();
		// Step 3
		public delegate void CallbackProcMicr();
		// Step 1
		private CallbackProcProcessError m_cbFuncProcessErrorCB = null;

		private CProperty_1 m_objProperty   = null;
		private bool        m_bOpenDevice;
		private CScan       m_objScan       = null;
		private CMicr       m_objMicr       = null;
		private COption     m_objOption     = null;

		// Step 2
		private CImage_1    m_objImage      = null;

		// Step 2
		private CallbackProcImage m_cbFuncImageCB  = null;

		// Step 3
		private byte              m_byExecType;
		private CallbackProcMicr  m_cbFuncMicrCB   = null;

		public CApp()
		{
			// Step 1
			m_objProperty   = new CProperty_1();
			m_objScan       = new CScan();
			m_objMicr       = new CMicr();
			m_objOption     = new COption();
			// Step 2
			m_objImage      = new CImage_1();

			// Step 3
			m_byExecType    = EXEC_SCAN_CHECK;
		}

		// Initialize
		public ErrorCode InitDevice()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			m_bOpenDevice = false;

			try
			{
				// Connect to the device
				m_objProperty.SetMfDevice(new MFDevice());
				errResult = m_objProperty.GetMfDevice().OpenMonPrinter(OpenType.TYPE_PRINTER, "TM-S9000U,TM-S2000U");
				Debug.Assert(errResult == ErrorCode.SUCCESS);
				if (errResult != ErrorCode.SUCCESS)
				{
					return errResult;
				}
				m_bOpenDevice = true;

				m_objScan.Init(m_objProperty);
				m_objMicr.Init(m_objProperty);
				m_objOption.Init(m_objProperty);
				// Step 2
				m_objImage.Init(m_objProperty);

				// Step 1
				// Register callback functions for notification of the reading status
				m_objProperty.GetMfDevice().SCNMICRStatusCallback += new MFDevice.SCNMICRStatusCallbackHandler(ScanStatus);
				errResult = m_objProperty.GetMfDevice().SCNMICRSetStatusBack();
				Debug.Assert(errResult == ErrorCode.SUCCESS);
				if (errResult != ErrorCode.SUCCESS)
				{
					return errResult;
				}
			}
			catch
			{
				return ErrorCode.ERR_UNKNOWN;
			}

			return errResult;
		}

		// Post process
		public ErrorCode ExitDevice()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			if (m_bOpenDevice == true)
			{
				// Cancel the reading status callback
				errResult = m_objProperty.GetMfDevice().SCNMICRCancelStatusBack();
				Debug.Assert(errResult == ErrorCode.SUCCESS);
				if (errResult != ErrorCode.SUCCESS)
				{
					return errResult;
				}
				m_objProperty.GetMfDevice().SCNMICRStatusCallback -= new MFDevice.SCNMICRStatusCallbackHandler(ScanStatus);

				// Disconnect from device
				errResult = m_objProperty.GetMfDevice().CloseMonPrinter();
				Debug.Assert(errResult == ErrorCode.SUCCESS);
				if (errResult != ErrorCode.SUCCESS)
				{
					return errResult;
				}
				m_bOpenDevice = false;
			}

			return errResult;
		}

		// Step 1
		// Register callback function for notification of error during image acquisition
		public void SetProcessErrorCallback(CallbackProcProcessError cbProcessErrorCB)
		{
			m_cbFuncProcessErrorCB = cbProcessErrorCB;
		}

		// Step 2
		// Register callback function for notification of the image data
		public void SetImageCallback(CallbackProcImage cbImageCB)
		{
			m_cbFuncImageCB = cbImageCB;
		}

		// Step 3
		// Register callback function for notification of the MICR data
		public void SetMicrCallback(CallbackProcMicr cbMicrCB)
		{
			m_cbFuncMicrCB = cbMicrCB;
		}

		// Set MICR settings
		public void SetMicrParam(CMicrParam objMicrParam)
		{
			if (objMicrParam != null)
			{
				m_objProperty.SetFont(objMicrParam.GetFont());
				m_objProperty.SetParsing(objMicrParam.GetParsing());
				m_objProperty.SetClearSpace(objMicrParam.GetClearSpace());
			}
		}

		// Get MICR settings
		public void GetMicrParam(ref CMicrParam objMicrParam)
		{
			if (objMicrParam != null)
			{
				objMicrParam.SetFont(m_objProperty.GetFont());
				objMicrParam.SetParsing(m_objProperty.GetParsing());
				objMicrParam.SetClearSpace(m_objProperty.GetClearSpace());
			}
		}

		// Set scanning parameters
		public void SetScanParam(CScanParam objScanParam)
		{
			if (objScanParam != null)
			{
				m_objProperty.SetScanMedia(objScanParam.GetScanMedia());
				m_objProperty.SetLightSourceToScan(objScanParam.GetLightSourceToScan());
				m_objProperty.SetRGBColorDepth(objScanParam.GetRGBColorDepth());
				m_objProperty.SetIRColorDepth(objScanParam.GetIRColorDepth());
				m_objProperty.SetResolution(objScanParam.GetResolution());
				m_objProperty.SetNumberOfDocuments(objScanParam.GetNumberOfDocuments());
			}
		}

		// Get scanning parameters
		public void GetScanParam(ref CScanParam objScanParam)
		{
			if (objScanParam != null)
			{
				objScanParam.SetScanMedia(m_objProperty.GetScanMedia());
				objScanParam.SetLightSourceToScan(m_objProperty.GetLightSourceToScan());
				objScanParam.SetRGBColorDepth(m_objProperty.GetRGBColorDepth());
				objScanParam.SetIRColorDepth(m_objProperty.GetIRColorDepth());
				objScanParam.SetResolution(m_objProperty.GetResolution());
				objScanParam.SetNumberOfDocuments(m_objProperty.GetNumberOfDocuments());
			}
		}

		// Step 1
		// Check scanning process
		public ErrorCode ScanCheck()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			// Step 3
			m_byExecType = EXEC_SCAN_CHECK;

			// Step 1
			// Set MF_BASE01 structure
			errResult = m_objScan.SetBaseSetting();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Set check scanning conditions
			errResult = m_objScan.SetScanSetting();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Set MICR reading conditions
			errResult = m_objMicr.SetMicrSetting();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Set MF_PROCESS01 structure
			errResult = m_objOption.SetProcessSetting();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Start check scanning
			errResult = m_objScan.ScanFunction();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			return errResult;
		}

		// Step 2
		// Card scanning process
		public ErrorCode ScanCard()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			// Step 3
			m_byExecType = EXEC_SCAN_CARD;

			// Step 2
			// Clear MF_MICR strucuture
			errResult = m_objMicr.ClearMicrSetting();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Set MF_BASE01 strucuture
			errResult = m_objScan.SetBaseSetting();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Set card scanning conditions
			errResult = m_objScan.SetScanSetting();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Start card scanning
			errResult = m_objScan.ScanFunction();
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			return errResult;
		}

		// Check if scanning card with IR in 1 pass is supported.
		public bool IsScanningCardIR1PassSupported()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;
			byte[] DeviceInfo = null;

			errResult = m_objProperty.GetMfDevice().GetPrnCapability(112, out DeviceInfo);
			if (errResult == ErrorCode.SUCCESS && DeviceInfo.Length >= 1)
			{
				if ((DeviceInfo[0] & 0x20) == 0x20)
				{
					return true;
				}
			}
			return false;
		}

		// Get MICR data
		public ErrorCode GetMicr(ref CMicrResult objMicrResult)
		{
			return m_objMicr.GetMicr(ref objMicrResult);
		}

		// Get image data
		public ErrorCode GetScanImage(ref CImageResult objImageResult)
		{
			return m_objImage.GetScanImage(ref objImageResult);
		}

		// Error recovery
		public ErrorCode CancelError()
		{
			return m_objProperty.GetMfDevice().CancelError();
		}

		// Get device status
		public void GetDeviceStatus(ref ASB eStatus)
		{
			eStatus = m_objProperty.GetMfDevice().Status;
		}

		// Get ink status
		public void GetInkStatus(ref InkASB eStatus)
		{
			eStatus = m_objProperty.GetMfDevice().InkStatus;
		}

		// Cancel scanning
		public ErrorCode CancelScan()
		{
			return m_objScan.CancelScan();
		}

		// Step 3
		// MICR head cleaning
		public ErrorCode CleaningMicr()
		{
			return m_objMicr.CleaningMicr();
		}

		// Callback function for notifying scanning status
		private void ScanStatus(int nTransactionNumber, MainStatus eMainStatus, ErrorCode eSubStatus, string strPortName)
		{
			if (eSubStatus != ErrorCode.SUCCESS)
			{
				m_cbFuncProcessErrorCB(eSubStatus);
			}

			// Step 2
			if (eMainStatus == MainStatus.MF_DATARECEIVE_DONE)
			{
				m_objProperty.SetTransactionNumber(nTransactionNumber);

				// Step 2
				// Notify callback for image data
				m_cbFuncImageCB();

				// Step 3
				if (m_byExecType == EXEC_SCAN_CHECK)
				{
					// Step 3
					// Notify callback for MICR data
					m_cbFuncMicrCB();
				}
			}
		}
	}
}
