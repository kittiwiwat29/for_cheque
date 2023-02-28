using System;
using com.epson.bank.driver;

namespace TMS_Sample
{
  class CMicrResult
  {
	int         m_nTransactionNumber;
	ErrorCode   m_errRet;
	byte        m_byStatus;
	byte        m_byDetail;
	string      m_szMicrStr;
	string      m_szAccountNumber;
	string      m_szAmount;
	string      m_szBankNumber;
	string      m_szSerialNumber;
	string      m_szEPC;
	string      m_szTransitNumber;
	string      m_szOnUSField;
	string      m_szAuxiliatyOnUSField;
	Check       m_eCheckType;
	Country     m_eCountryCode;

	public CMicrResult()
	{
		m_nTransactionNumber    = 0;
		m_errRet                = 0;
		m_byStatus              = 0;
		m_byDetail              = 0;
		m_szMicrStr             = null;
		m_szAccountNumber       = null;
		m_szAmount              = null;
		m_szBankNumber          = null;
		m_szSerialNumber        = null;
		m_szEPC                 = null;
		m_szTransitNumber       = null;
		m_szOnUSField           = null;
		m_szAuxiliatyOnUSField  = null;
	}

	public void SetTransactionNumber(int nTransactionNumber)
	{
		m_nTransactionNumber = nTransactionNumber;
	}

	public int GetTransactionNumber()
	{
		return m_nTransactionNumber;
	}

	public void SetResult(ErrorCode errRet)
	{
		m_errRet = errRet;
	}

	public ErrorCode GetResult()
	{
		return m_errRet;
	}

	public void SetStatus(byte byStatus)
	{
		m_byStatus = byStatus;
	}

	public byte GetStatus()
	{
		return m_byStatus;
	}

	public void SetDetail(byte byDetail)
	{
		m_byDetail = byDetail;
	}

	public byte GetDetail()
	{
		return m_byDetail;
	}

	public void SetMicrStr(string szMicrStr)
	{
		m_szMicrStr = szMicrStr.TrimEnd('\0');
	}

	public string GetMicrStr()
	{
		return m_szMicrStr;
	}

	public void SetAccountNumber(string szAccountNumber)
	{
		m_szAccountNumber = szAccountNumber.TrimEnd('\0');
	}

	 public string GetAccountNumber()
	{
		return m_szAccountNumber;
	}

	public void SetAmount(string szAmount)
	{
		m_szAmount = szAmount.TrimEnd('\0');
	}

	public string GetAmount()
	{
		return m_szAmount;
	}

	public void SetBankNumber(string szBankNumber)
	{
		m_szBankNumber = szBankNumber.TrimEnd('\0');
	}

	public string GetBankNumber()
	{
		return m_szBankNumber.TrimEnd('\0');
	}

	public void SetSerialNumber(string szSerialNumber)
	{
		m_szSerialNumber = szSerialNumber;
	}

	public string GetSerialNumber()
	{
		return m_szSerialNumber.TrimEnd('\0');
	}

	public void SetEPC(string szEPC)
	{
		m_szEPC = szEPC.TrimEnd('\0');
	}

	public string GetEPC()
	{
		return m_szEPC;
	}

	public void SetTransitNumber(string szTransitNumber)
	{
		m_szTransitNumber = szTransitNumber.TrimEnd('\0');
	}

	public string GetTransitNumber()
	{
		return m_szTransitNumber;
	}

	public void SetCheckType(Check eCheckType)
	{
		m_eCheckType = eCheckType;
	}

	public Check GetCheckType()
	{
		return m_eCheckType;
	}

	public void SetCountryCode(Country eCountryCode)
	{
		m_eCountryCode = eCountryCode;
	}

	public Country GetCountryCode()
	{
		return m_eCountryCode;
	}

	public void SetOnUSField(string szOnUSField)
	{
		m_szOnUSField = szOnUSField.TrimEnd('\0');
	}

	public string GetOnUSField()
	{
		return m_szOnUSField;
	}

	public void SetAuxiliatyOnUSField(string szAuxiliatyOnUSField)
	{
		m_szAuxiliatyOnUSField = szAuxiliatyOnUSField.TrimEnd('\0');
	}

	public string GetAuxiliatyOnUSField()
	{
		return m_szAuxiliatyOnUSField;
	}
  }
}
