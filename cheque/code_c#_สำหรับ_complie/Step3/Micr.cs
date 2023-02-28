using System;
using System.Diagnostics;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CMicr
	{
		private CProperty_1 m_objProperty = null;

		public CMicr()
		{
		}

		public ErrorCode Init(CProperty_1 objProperty)
		{
			ErrorCode errResult = ErrorCode.SUCCESS;
			m_objProperty = objProperty;

			return errResult;
		}

		// Set MICR reading conditions
		public ErrorCode SetMicrSetting()
		{
			ErrorCode errResult = ErrorCode.SUCCESS;
			bool bParsing = false;
			RemoveSpace eClearSpaces = RemoveSpace.CLEAR_SPACE_DISABLE;

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfMicr(), FunctionType.MF_GET_MICR_DEFAULT);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			m_objProperty.GetMfMicr().Font = m_objProperty.GetFont();
			if(m_objProperty.GetParsing())
			{
				bParsing = true;
			}
			m_objProperty.GetMfMicr().Parsing = bParsing;

			errResult = m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfMicr(), FunctionType.MF_SET_MICR_PARAM);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			if(m_objProperty.GetClearSpace())
			{
				eClearSpaces = RemoveSpace.CLEAR_SPACE_ENABLE;
			}

			errResult = m_objProperty.GetMfDevice().MICRClearSpaces(eClearSpaces);
			Debug.Assert(errResult == ErrorCode.SUCCESS);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			return errResult;
		}

		// Get MICR data
		public ErrorCode GetMicr(ref CMicrResult objMicrResult)
		{
			if (objMicrResult == null)
			{
				return ErrorCode.ERR_UNKNOWN;
			}

			ErrorCode errResult = m_objProperty.GetMfDevice().GetMicrText(m_objProperty.GetTransactionNumber(), m_objProperty.GetMfMicr());
			Debug.Assert(
					errResult == ErrorCode.SUCCESS ||
					errResult == ErrorCode.ERR_MICR_BADDATA ||
					errResult == ErrorCode.ERR_MICR_NODATA);
			if (errResult != ErrorCode.SUCCESS)
			{
				return errResult;
			}

			objMicrResult.SetTransactionNumber(m_objProperty.GetTransactionNumber());
			objMicrResult.SetResult(m_objProperty.GetMfMicr().Ret);
			objMicrResult.SetStatus(m_objProperty.GetMfMicr().Status);
			objMicrResult.SetDetail(m_objProperty.GetMfMicr().Detail);
			objMicrResult.SetMicrStr(m_objProperty.GetMfMicr().MicrStr);
			objMicrResult.SetAccountNumber(m_objProperty.GetMfMicr().AccountNumber);
			objMicrResult.SetAmount(m_objProperty.GetMfMicr().Amount);
			objMicrResult.SetBankNumber(m_objProperty.GetMfMicr().BankNumber);
			objMicrResult.SetSerialNumber(m_objProperty.GetMfMicr().SerialNumber);
			objMicrResult.SetEPC(m_objProperty.GetMfMicr().EPC);
			objMicrResult.SetTransitNumber(m_objProperty.GetMfMicr().TransitNumber);
			objMicrResult.SetCheckType(m_objProperty.GetMfMicr().CheckType);
			objMicrResult.SetCountryCode(m_objProperty.GetMfMicr().CountryCode);
			objMicrResult.SetOnUSField(m_objProperty.GetMfMicr().OnUSField);
			objMicrResult.SetAuxiliatyOnUSField(m_objProperty.GetMfMicr().AuxillatyOnUSField);

			return errResult;
		}

		// MICR cleaning
		public ErrorCode CleaningMicr()
		{
			return m_objProperty.GetMfDevice().MICRCleaning();
		}

		public ErrorCode ClearMicrSetting()
		{
			return m_objProperty.GetMfDevice().SCNMICRFunctionContinuously(m_objProperty.GetMfMicr(), FunctionType.MF_CLEAR_MICR_PARAM);
		}
	}
}
