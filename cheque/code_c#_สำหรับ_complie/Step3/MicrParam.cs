using System;
using com.epson.bank.driver;

namespace TMS_Sample
{
	class CMicrParam
	{
		MfMicrFont  m_eFont;
		bool        m_bParsing;
		bool        m_bClearSpace;

		public CMicrParam()
		{
			m_eFont         = 0;
			m_bParsing      = false;
			m_bClearSpace   = false;
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
	}
}
