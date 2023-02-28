using System;
using System.Drawing;
using System.IO;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CImageResult
	{
		int       m_nTransactionNumber;
		Bitmap    m_cImage;
		Stream    m_cData;
		int       m_nImageSize;
		ImageType m_eLightSource;
		MfScanDpi m_eResolution;
		com.epson.bank.driver.ColorDepth m_eColorDepth;
		ScanSide  m_eFace;
		Format    m_eFormat;

		public CImageResult()
		{
			m_nTransactionNumber = 0;
			m_cData              = null;
			m_cImage             = null;
			m_nImageSize         = 0;
			m_eLightSource       = 0;
			m_eResolution        = MfScanDpi.MF_SCAN_DPI_200;
			m_eColorDepth        = com.epson.bank.driver.ColorDepth.EPS_BI_SCN_8BIT;
			m_eFace              = 0;
			m_eFormat            = 0;
		}

		~CImageResult()
		{
			FreeImage();
		}

		public void SetTransactionNumber(int nTransactionNumber)
		{
			m_nTransactionNumber = nTransactionNumber;
		}

		public int GetTransactionNumber()
		{
			return m_nTransactionNumber;
		}

		public void SetBitmapImage(Bitmap cImage)
		{
			m_cImage = cImage;
		}

		public Bitmap GetBitmapImage()
		{
			return m_cImage;
		}

		public void SetImageData(Stream cData)
		{
			m_cData = cData;
		}

		public Stream GetImageData()
		{
			return m_cData;
		}

		public void SetImageSize(int nImageSize)
		{
			m_nImageSize = nImageSize;
		}

		public int GetImageSize()
		{
			return m_nImageSize;
		}

		public void SetLightSource(ImageType eLightSource)
		{
			m_eLightSource = eLightSource;
		}

		public ImageType GetLightSource()
		{
			return m_eLightSource;
		}

		public void SetResolution(MfScanDpi eResolution)
		{
			m_eResolution = eResolution;
		}

		public MfScanDpi GetResolution()
		{
			return m_eResolution;
		}

		public void SetColorDepth(com.epson.bank.driver.ColorDepth eColorDepth)
		{
			m_eColorDepth = eColorDepth;
		}

		public com.epson.bank.driver.ColorDepth GetColorDepth()
		{
			return m_eColorDepth;
		}

		public void SetFace(ScanSide eFace)
		{
			m_eFace = eFace;
		}

		public ScanSide GetFace()
		{
			return m_eFace;
		}

		public void SetFormat(Format eFormat)
		{
			m_eFormat = eFormat;
		}

		public Format GetFormat()
		{
			return m_eFormat;
		}

		public void FreeImage()
		{
			if (m_cData != null && m_cImage != null)
			{
				m_cData.Dispose();
				m_cImage.Dispose();
				m_nImageSize = 0;
				m_nTransactionNumber = 0;
			}
		}
	}
}
