using System;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CScanParam
	{
		ImageTypeOption m_eLightSourceToScan;
		ColorDepth      m_eRGBColorDepth;
		ColorDepth      m_eIRColorDepth;
		MfScanDpi       m_eResolution;
		ScanUnit        m_eScanMedia;
		byte            m_nNumberOfDocuments;

		public CScanParam()
		{
			m_eLightSourceToScan = 0;
			m_eRGBColorDepth     = 0;
			m_eIRColorDepth      = 0;
			m_eResolution        = 0;
			m_eScanMedia         = 0;
			m_nNumberOfDocuments = 0;
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

		public void SetScanMedia(ScanUnit eScanMedia)
		{
			m_eScanMedia = eScanMedia;
		}

		public ScanUnit GetScanMedia()
		{
			return m_eScanMedia;
		}

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
