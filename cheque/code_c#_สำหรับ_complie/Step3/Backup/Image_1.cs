using System;
using System.Diagnostics;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CImage_1
	{
		private CProperty_1 m_objProperty = null;

		public CImage_1()
		{
		}

		public ErrorCode Init(CProperty_1 objProperty)
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			m_objProperty = objProperty;

			return errResult;
		}

		// Specify image data format
		public ErrorCode SetImageSetting(ScanSide eFace, ImageType eLightSource, com.epson.bank.driver.ColorDepth eColorDepth, Format eFormat)
		{
			ErrorCode errResult = ErrorCode.SUCCESS;
			Color eColor = Color.EPS_BI_SCN_COLOR;
			ExOption eExOption = ExOption.EPS_BI_SCN_MANUAL;

			errResult = m_objProperty.GetMfDevice().SCNSelectScanFace(eFace);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSelectScanImage(eLightSource);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			if (eColorDepth == ColorDepth.EPS_BI_SCN_24BIT)
			{
				eColor      = Color.EPS_BI_SCN_COLOR;
				eExOption   = ExOption.EPS_BI_SCN_MANUAL;
			}
			else
			{
				eColor      = Color.EPS_BI_SCN_MONOCHROME;
				eExOption   = ExOption.EPS_BI_SCN_SHARP;
			}

			errResult = m_objProperty.GetMfDevice().SCNSetImageQuality(eColorDepth, 0, eColor, eExOption);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSetImageFormat(eFormat);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			return errResult;
		}

		// Get check image
		public ErrorCode GetScanImage(ref CImageResult objImageResult)
		{
			ErrorCode errResult = ErrorCode.SUCCESS;
			MFScan mfScan = null;

			errResult = SetImageSetting(objImageResult.GetFace(), objImageResult.GetLightSource(), objImageResult.GetColorDepth(), objImageResult.GetFormat());
			if(errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			if (objImageResult.GetFace() == ScanSide.MF_SCAN_FACE_FRONT)
			{
				mfScan = m_objProperty.GetMfScanFront();
			}
			else
			{
				mfScan = m_objProperty.GetMfScanBack();
			}

			mfScan.Resolution = objImageResult.GetResolution();
			errResult = m_objProperty.GetMfDevice().GetScanImage(m_objProperty.GetTransactionNumber(), mfScan);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			objImageResult.SetTransactionNumber(m_objProperty.GetTransactionNumber());
			objImageResult.SetImageSize((int)mfScan.Data.Length);
			objImageResult.SetBitmapImage(mfScan.Image); // bitmap, width, height
			objImageResult.SetImageData(mfScan.Data);

			return errResult;
		}

		// Get cashier's check image
		public ErrorCode GetCashersCheckImage(ref CImageResult objImageResult)
		{
			ErrorCode errResult = ErrorCode.SUCCESS;
			MFScan mfScan = null;

			errResult = m_objProperty.GetMfDevice().SCNSelectScanFace(objImageResult.GetFace());
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSelectScanImage(ImageType.MF_SCAN_IMAGE_VISIBLE);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSetImageFormat(Format.EPS_BI_SCN_BITMAP);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSetImageQuality(ColorDepth.EPS_BI_SCN_24BIT, 0, Color.EPS_BI_SCN_COLOR, ExOption.EPS_BI_SCN_MANUAL);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			if (objImageResult.GetFace() == ScanSide.MF_SCAN_FACE_FRONT)
			{
				mfScan = m_objProperty.GetMfScanFront();
			}
			else
			{
				mfScan = m_objProperty.GetMfScanBack();
			}

			errResult = m_objProperty.GetMfDevice().GetScanImage(m_objProperty.GetTransactionNumber(), mfScan);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			objImageResult.SetTransactionNumber(m_objProperty.GetTransactionNumber());
			objImageResult.SetImageSize((int)mfScan.Data.Length);
			objImageResult.SetBitmapImage(mfScan.Image); // bitmap, width, height
			objImageResult.SetImageData(mfScan.Data);

			return errResult;
		}
	}
}
