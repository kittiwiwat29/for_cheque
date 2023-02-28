using System;
using System.Diagnostics;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CScan
	{
		private CProperty_1 m_objProperty = null;

		public CScan()
		{
		}

		public ErrorCode Init(CProperty_1 objProperty)
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			m_objProperty = objProperty;


			return errResult;
		}

		// Start scanning
		public ErrorCode ScanFunction()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(FunctionType.MF_EXEC);
			Debug.Assert(errResult == ErrorCode.SUCCESS);

			return errResult;
		}

		// Set MF_BASE01 structure
		public ErrorCode SetBaseSetting()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			errResult = m_objProperty.GetMfDevice().SCNSelectScanUnit(m_objProperty.GetScanMedia());
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Step 2
			errResult = m_objProperty.GetMfDevice().SetNumberOfDocuments(m_objProperty.GetNumberOfDocuments());
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// Step 1
			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfBase(), FunctionType.MF_GET_BASE_DEFAULT);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			m_objProperty.GetMfBase().ErrorEject = MfEjectType.MF_EXIT_ERROR_DISCHARGE;

			// Set buzzer settings
			if( m_objProperty.GetBuzzerSuccess() == true )
			{
				m_objProperty.GetMfBase().BuzzerCount[MfBuzzerType.MF_BUZZER_TYPE_SUCCESS] = MfBuzzerCount.MF_BUZZER_COUNT_ONE;
				m_objProperty.GetMfBase().BuzzerHz[MfBuzzerType.MF_BUZZER_TYPE_SUCCESS] = MfBuzzerHz.MF_BUZZER_HZ_4000;
			}
			else
			{
				m_objProperty.GetMfBase().BuzzerCount[MfBuzzerType.MF_BUZZER_TYPE_SUCCESS] = MfBuzzerCount.MF_BUZZER_DISABLE;
			}

			if( m_objProperty.GetBuzzerError() == true )
			{
				m_objProperty.GetMfBase().BuzzerCount[MfBuzzerType.MF_BUZZER_TYPE_ERROR] = MfBuzzerCount.MF_BUZZER_COUNT_TWO;
				m_objProperty.GetMfBase().BuzzerHz[MfBuzzerType.MF_BUZZER_TYPE_ERROR] = MfBuzzerHz.MF_BUZZER_HZ_880;
			}
			else
			{
				m_objProperty.GetMfBase().BuzzerCount[MfBuzzerType.MF_BUZZER_TYPE_ERROR] = MfBuzzerCount.MF_BUZZER_DISABLE;
			}

			if( m_objProperty.GetBuzzerDoubleFeed() == true )
			{
				m_objProperty.GetMfBase().BuzzerCount[MfBuzzerType.MF_BUZZER_TYPE_WFEED] = MfBuzzerCount.MF_BUZZER_COUNT_MAX;
				m_objProperty.GetMfBase().BuzzerHz[MfBuzzerType.MF_BUZZER_TYPE_WFEED] = MfBuzzerHz.MF_BUZZER_HZ_440;
			}
			else
			{
				m_objProperty.GetMfBase().BuzzerCount[MfBuzzerType.MF_BUZZER_TYPE_WFEED] = MfBuzzerCount.MF_BUZZER_DISABLE;
			}

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfBase(), FunctionType.MF_SET_BASE_PARAM);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			return errResult;
		}

		// Set scanning conditions
		public ErrorCode SetScanSetting()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			// For front side image
			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfScanFront(), FunctionType.MF_GET_SCAN_FRONT_DEFAULT);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			m_objProperty.GetMfScanFront().Resolution = m_objProperty.GetResolution();

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfScanFront(), FunctionType.MF_SET_SCAN_FRONT_PARAM);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSelectScanFace(ScanSide.MF_SCAN_FACE_FRONT);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSetImageTypeOption(m_objProperty.GetLightSourceToScan());
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			// For back side image
			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfScanBack(), FunctionType.MF_GET_SCAN_BACK_DEFAULT);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			m_objProperty.GetMfScanBack().Resolution = m_objProperty.GetResolution();

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfScanBack(), FunctionType.MF_SET_SCAN_BACK_PARAM);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSelectScanFace(ScanSide.MF_SCAN_FACE_BACK);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			errResult = m_objProperty.GetMfDevice().SCNSetImageTypeOption(m_objProperty.GetLightSourceToScan());
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			return errResult;
		}

		// Scanning cancellation
		public ErrorCode CancelScan()
		{
			return m_objProperty.GetMfDevice().SCNMICRCancelFunction(MfEjectType.MF_EJECT_DISCHARGE);
		}
	}
}
