using System;
using System.Diagnostics;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class COption
	{
		private CProperty_1 m_objProperty = null;

		public COption()
		{
		}

		public ErrorCode Init(CProperty_1 objProperty)
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			m_objProperty = objProperty;

			return errResult;
		}

		// Set MF_PROCESS01 structure
		public ErrorCode SetProcessSetting()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfProcess(), FunctionType.MF_GET_PROCESS_DEFAULT);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			m_objProperty.GetMfProcess().ActivationMode	= m_objProperty.GetActivation();

			// Mis-Insertion error
			m_objProperty.GetMfProcess().PaperMisInsertionErrorSelect = m_objProperty.GetPaperMisInsertionDetect();
			if (m_objProperty.GetPaperMisInsertionDetect() == MfErrorSelect.MF_ERROR_SELECT_DETECT)
			{
				m_objProperty.GetMfProcess().PaperMisInsertionCancel		= m_objProperty.GetPaperMisInsertionCancel();
				m_objProperty.GetMfProcess().PaperMisInsertionErrorEject	= m_objProperty.GetPaperMisInsertionEject();
			}

			// Noise error
			m_objProperty.GetMfProcess().NoiseErrorSelect = m_objProperty.GetNoiseDetect();
			if (m_objProperty.GetNoiseDetect() == MfErrorSelect.MF_ERROR_SELECT_DETECT)
			{
				m_objProperty.GetMfProcess().NoiseCancel		= m_objProperty.GetNoiseCancel();
				m_objProperty.GetMfProcess().NoiseErrorEject	= m_objProperty.GetNoiseEject();
			}

			// Double feed error
			m_objProperty.GetMfProcess().DoubleFeedErrorSelect = m_objProperty.GetDoubleFeedDetect();
			if (m_objProperty.GetDoubleFeedDetect() == MfErrorSelect.MF_ERROR_SELECT_DETECT)
			{
				m_objProperty.GetMfProcess().DoubleFeedCancel		= m_objProperty.GetDoubleFeedCancel();
				m_objProperty.GetMfProcess().DoubleFeedErrorEject	= m_objProperty.GetDoubleFeedEject();
			}

			// Bad data in MICR error
			m_objProperty.GetMfProcess().BaddataErrorSelect = m_objProperty.GetBaddataDetect();
			if (m_objProperty.GetBaddataDetect() == MfErrorSelect.MF_ERROR_SELECT_DETECT)
			{
				m_objProperty.GetMfProcess().BaddataCancel		= m_objProperty.GetBaddataCancel();
				m_objProperty.GetMfProcess().BaddataErrorEject	= m_objProperty.GetBaddataEject();
				m_objProperty.GetMfProcess().BaddataCount		= 0;
			}

			// No data in MICR magnetic waveform error
			m_objProperty.GetMfProcess().NodataErrorSelect = m_objProperty.GetNodataDetect();
			if (m_objProperty.GetNodataDetect() == MfErrorSelect.MF_ERROR_SELECT_DETECT)
			{
				m_objProperty.GetMfProcess().NodataCancel			= m_objProperty.GetNodataCancel();
				m_objProperty.GetMfProcess().NodataErrorEject		= m_objProperty.GetNodataEject();
			}

			// Set endorsement printing mode
			m_objProperty.GetMfProcess().EndorsePrintMode = m_objProperty.GetEndorsePrintMode();

			// Print data unreceived error
			m_objProperty.GetMfProcess().PrnDataUnreceiveCancel = m_objProperty.GetPrnDataUnreceiveCancel();

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfProcess(), FunctionType.MF_SET_PROCESS_PARAM);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			return errResult;
		}

		// Perform scanning using confirmation mode
		public ErrorCode ConfirmationFunction()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;

			errResult = m_objProperty.GetMfDevice().SetBehaviorToScnResult(
					m_objProperty.GetConfirmationEject(),
					MfStamp.MF_STAMP_DISABLE,
					m_objProperty.GetConfirmationCancel());
			Debug.Assert(errResult == ErrorCode.SUCCESS);

			return errResult;
		}
	}
}
