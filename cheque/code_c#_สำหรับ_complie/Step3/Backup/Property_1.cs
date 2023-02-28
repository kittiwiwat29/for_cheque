using System;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CProperty_1
	{
		// Step 1
		private MFDevice    m_objmfDevice    = null;
		private MFBase      m_objmfBase      = null;
		private MFScan      m_objmfScanFront = null;
		private MFScan      m_objmfScanBack  = null;
		private MFMicr      m_objmfMicr      = null;
		private MFProcess   m_objmfProcess   = null;

		ScanUnit        m_eScanMedia;
		ImageTypeOption m_eLightSourceToScan;
		ColorDepth      m_eRGBColorDepth;
		ColorDepth      m_eIRColorDepth;
		MfScanDpi       m_eResolution;
		MfMicrFont      m_eFont;
		bool            m_bParsing;
		bool            m_bClearSpace;
		int             m_nTransactionNumber;

		bool m_bBuzzerSuccess;
		bool m_bBuzzerDoubleFeed;
		bool m_bBuzzerError;

		// Step 1
		MfActivateMode      m_eActivation;
		MfEject             m_eConfirmationEject;
		MfProcessContinue   m_eConfirmationCancel;
		MfErrorSelect       m_ePaperMisInsertionDetect;
		MfEject             m_ePaperMisInsertionEject;
		MfCancel            m_ePaperMisInsertionCancel;
		MfErrorSelect       m_eNoiseDetect;
		MfEject             m_eNoiseEject;
		MfCancel            m_eNoiseCancel;
		MfErrorSelect       m_eDoubleFeedDetect;
		MfEject             m_eDoubleFeedEject;
		MfCancel            m_eDoubleFeedCancel;
		MfErrorSelect       m_eBaddataDetect;
		MfEject             m_eBaddataEject;
		MfCancel            m_eBaddataCancel;
		MfErrorSelect       m_eNodataDetect;
		MfEject             m_eNodataEject;
		MfCancel            m_eNodataCancel;
		MfEndorsePrintMode  m_eEndorsePrintMode;
		MfCancel            m_ePrnDataUnreceiveCancel;

		// Step 2
		byte                m_nNumberOfDocuments;

		public CProperty_1()
		{
			m_objmfDevice    = new MFDevice();
			m_objmfBase      = new MFBase();
			m_objmfScanFront = new MFScan();
			m_objmfScanBack  = new MFScan();
			m_objmfMicr      = new MFMicr();
			m_objmfProcess   = new MFProcess();

			m_eScanMedia            = ScanUnit.EPS_BI_SCN_UNIT_CHECKPAPER;
			m_eLightSourceToScan    = ImageTypeOption.EPS_BI_SCN_OPTION_COLOR;
			m_eRGBColorDepth        = ColorDepth.EPS_BI_SCN_24BIT;
			m_eIRColorDepth         = ColorDepth.EPS_BI_SCN_8BIT;
			m_eResolution			= MfScanDpi.MF_SCAN_DPI_200;
			m_eFont                 = MfMicrFont.MF_MICR_FONT_E13B;
			m_bParsing				= false;
			m_bClearSpace			= false;
			m_nTransactionNumber	= 0;

			m_bBuzzerSuccess		= false;
			m_bBuzzerDoubleFeed		= false;
			m_bBuzzerError			= false;

			// Step 1
			m_eActivation               = MfActivateMode.MF_ACTIVATE_MODE_HIGH_SPEED;
			m_eConfirmationEject        = MfEject.MF_EJECT_MAIN_POCKET;
			m_eConfirmationCancel       = MfProcessContinue.MF_PROCESS_CONTINUE_OVERLAP;
			m_ePaperMisInsertionDetect  = MfErrorSelect.MF_ERROR_SELECT_DETECT;
			m_ePaperMisInsertionEject   = MfEject.MF_EJECT_MAIN_POCKET;
			m_ePaperMisInsertionCancel  = MfCancel.MF_CANCEL_DISABLE;
			m_eNoiseDetect              = MfErrorSelect.MF_ERROR_SELECT_DETECT;
			m_eNoiseEject               = MfEject.MF_EJECT_MAIN_POCKET;
			m_eNoiseCancel              = MfCancel.MF_CANCEL_DISABLE;
			m_eDoubleFeedDetect         = MfErrorSelect.MF_ERROR_SELECT_DETECT;
			m_eDoubleFeedEject          = MfEject.MF_EJECT_MAIN_POCKET;
			m_eDoubleFeedCancel         = MfCancel.MF_CANCEL_DISABLE;
			m_eBaddataDetect            = MfErrorSelect.MF_ERROR_SELECT_DETECT;
			m_eBaddataEject             = MfEject.MF_EJECT_MAIN_POCKET;
			m_eBaddataCancel            = MfCancel.MF_CANCEL_DISABLE;
			m_eNodataDetect             = MfErrorSelect.MF_ERROR_SELECT_DETECT;
			m_eNodataEject              = MfEject.MF_EJECT_MAIN_POCKET;
			m_eNodataCancel             = MfCancel.MF_CANCEL_DISABLE;
			m_eEndorsePrintMode         = MfEndorsePrintMode.MF_ENDORSEPRINT_MODE_HIGHSPEED;
			m_ePrnDataUnreceiveCancel   = MfCancel.MF_CANCEL_DISABLE;
			// Step 2
			m_nNumberOfDocuments = 0;
		}

		public void SetMfDevice(MFDevice objmfDevice)
		{
			m_objmfDevice = objmfDevice;
		}

		public MFDevice GetMfDevice()
		{
			return m_objmfDevice;
		}

		public MFBase GetMfBase()
		{
			return m_objmfBase;
		}

		public MFMicr GetMfMicr()
		{
			return m_objmfMicr;
		}

		public MFScan GetMfScanFront()
		{
			return m_objmfScanFront;
		}

		public MFScan GetMfScanBack()
		{
			return m_objmfScanBack;
		}

		public MFProcess GetMfProcess()
		{
			return m_objmfProcess;
		}

		public void SetScanMedia(ScanUnit eScanMedia)
		{
			m_eScanMedia = eScanMedia;
		}

		public ScanUnit GetScanMedia()
		{
			return m_eScanMedia;
		}

		public void SetLightSourceToScan(ImageTypeOption eLightSourceToScan)
		{
			m_eLightSourceToScan = eLightSourceToScan;
		}

		public ImageTypeOption GetLightSourceToScan()
		{
			return m_eLightSourceToScan;
		}

		public void SetRGBColorDepth(ColorDepth eColorDepth)
		{
			m_eRGBColorDepth = eColorDepth;
		}

		public ColorDepth GetRGBColorDepth()
		{
			return m_eRGBColorDepth;
		}

		public void SetIRColorDepth(ColorDepth eColorDepth)
		{
			m_eIRColorDepth = eColorDepth;
		}

		public ColorDepth GetIRColorDepth()
		{
			return m_eIRColorDepth;
		}

		public void SetResolution(MfScanDpi eResolution)
		{
			m_eResolution = eResolution;
		}

		public MfScanDpi GetResolution()
		{
			return m_eResolution;
		}

		public void SetFont(MfMicrFont eFont)
		{
			m_eFont = eFont;
		}

		public MfMicrFont GetFont()
		{
			return m_eFont;
		}

		public void SetParsing(bool bParsing)
		{
			m_bParsing = bParsing;
		}

		public bool GetParsing()
		{
			return m_bParsing;
		}

		public void SetClearSpace(bool bClearSpace)
		{
			m_bClearSpace = bClearSpace;
		}

		public bool GetClearSpace()
		{
			return m_bClearSpace;
		}

		public void SetTransactionNumber(int nTransactionNumber)
		{
			m_nTransactionNumber = nTransactionNumber;
		}

		public int GetTransactionNumber()
		{
			return m_nTransactionNumber;
		}

		public void SetBuzzerSuccess(bool bBuzzerSuccess)
		{
			m_bBuzzerSuccess = bBuzzerSuccess;
		}

		public bool GetBuzzerSuccess()
		{
			return m_bBuzzerSuccess;
		}

		public void SetBuzzerDoubleFeed(bool bBuzzerDoubleFeed)
		{
			m_bBuzzerDoubleFeed = bBuzzerDoubleFeed;
		}

		public bool GetBuzzerDoubleFeed()
		{
			return m_bBuzzerDoubleFeed;
		}

		public void SetBuzzerError(bool bBuzzerError)
		{
			m_bBuzzerError = bBuzzerError;
		}

		public bool GetBuzzerError()
		{
			return m_bBuzzerError;
		}

		public void SetActivation(MfActivateMode eActivation)
		{
			m_eActivation = eActivation;
		}

		public MfActivateMode GetActivation()
		{
			return m_eActivation;
		}

		public void SetConfirmationEject(MfEject eConfirmationEject)
		{
			m_eConfirmationEject = eConfirmationEject;
		}

		public MfEject GetConfirmationEject()
		{
			return m_eConfirmationEject;
		}

		public void SetConfirmationCancel(MfProcessContinue eConfirmationCancel)
		{
			m_eConfirmationCancel = eConfirmationCancel;
		}

		public MfProcessContinue GetConfirmationCancel()
		{
			return m_eConfirmationCancel;
		}

		public void SetPaperMisInsertionDetect(MfErrorSelect ePaperMisInsertionDetect)
		{
			m_ePaperMisInsertionDetect = ePaperMisInsertionDetect;
		}

		public MfErrorSelect GetPaperMisInsertionDetect()
		{
			return m_ePaperMisInsertionDetect;
		}

		public void SetPaperMisInsertionEject(MfEject ePaperMisInsertionEject)
		{
			m_ePaperMisInsertionEject = ePaperMisInsertionEject;
		}

		public MfEject GetPaperMisInsertionEject()
		{
			return m_ePaperMisInsertionEject;
		}

		public void SetPaperMisInsertionCancel(MfCancel ePaperMisInsertionCancel)
		{
			m_ePaperMisInsertionCancel = ePaperMisInsertionCancel;
		}

		public MfCancel GetPaperMisInsertionCancel()
		{
			return m_ePaperMisInsertionCancel;
		}

		public void SetNoiseDetect(MfErrorSelect eNoiseDetect)
		{
			m_eNoiseDetect = eNoiseDetect;
		}

		public MfErrorSelect GetNoiseDetect()
		{
			return m_eNoiseDetect;
		}

		public void SetNoiseEject(MfEject eNoiseEject)
		{
			m_eNoiseEject = eNoiseEject;
		}

		public MfEject GetNoiseEject()
		{
			return m_eNoiseEject;
		}

		public void SetNoiseCancel(MfCancel eNoiseCancel)
		{
			m_eNoiseCancel = eNoiseCancel;
		}

		public MfCancel GetNoiseCancel()
		{
			return m_eNoiseCancel;
		}

		public void SetDoubleFeedDetect(MfErrorSelect eDoubleFeedDetect)
		{
			m_eDoubleFeedDetect = eDoubleFeedDetect;
		}

		public MfErrorSelect GetDoubleFeedDetect()
		{
			return m_eDoubleFeedDetect;
		}

		public void SetDoubleFeedEject(MfEject eDoubleFeedEject)
		{
			m_eDoubleFeedEject = eDoubleFeedEject;
		}

		public MfEject GetDoubleFeedEject()
		{
			return m_eDoubleFeedEject;
		}

		public void SetDoubleFeedCancel(MfCancel eDoubleFeedCancel)
		{
			m_eDoubleFeedCancel = eDoubleFeedCancel;
		}

		public MfCancel GetDoubleFeedCancel()
		{
			return m_eDoubleFeedCancel;
		}

		public void SetBaddataDetect(MfErrorSelect eBaddataDetect)
		{
			m_eBaddataDetect = eBaddataDetect;
		}

		public MfErrorSelect GetBaddataDetect()
		{
			return m_eBaddataDetect;
		}

		public void SetBaddataEject(MfEject eBaddataEject)
		{
			m_eBaddataEject = eBaddataEject;
		}

		public MfEject GetBaddataEject()
		{
			return m_eBaddataEject;
		}

		public void SetBaddataCancel(MfCancel eBaddataCancel)
		{
			m_eBaddataCancel = eBaddataCancel;
		}

		public MfCancel GetBaddataCancel()
		{
			return m_eBaddataCancel;
		}

		public void SetNodataDetect(MfErrorSelect eNodataDetect)
		{
			m_eNodataDetect = eNodataDetect;
		}

		public MfErrorSelect GetNodataDetect()
		{
			return m_eNodataDetect;
		}

		public void SetNodataEject(MfEject eNodataEject)
		{
			m_eNodataEject = eNodataEject;
		}

		public MfEject GetNodataEject()
		{
			return m_eNodataEject;
		}

		public void SetNodataCancel(MfCancel eNodataCancel)
		{
			m_eNodataCancel = eNodataCancel;
		}

		public MfCancel GetNodataCancel()
		{
			return m_eNodataCancel;
		}

		public void SetEndorsePrintMode(MfEndorsePrintMode eEndorsePrintMode)
		{
			m_eEndorsePrintMode = eEndorsePrintMode;
		}

		public MfEndorsePrintMode GetEndorsePrintMode()
		{
			return m_eEndorsePrintMode;
		}

		public void SetPrnDataUnreceiveCancel(MfCancel ePrnDataUnreceiveCancel)
		{
			m_ePrnDataUnreceiveCancel = ePrnDataUnreceiveCancel;
		}

		public MfCancel GetPrnDataUnreceiveCancel()
		{
			return m_ePrnDataUnreceiveCancel;
		}

		// Step 2
		public void SetNumberOfDocuments(byte nNumberOfDocuments)
		{
			m_nNumberOfDocuments = nNumberOfDocuments;
		}

		public byte GetNumberOfDocuments()
		{
			return m_nNumberOfDocuments;
		}
	}
}
