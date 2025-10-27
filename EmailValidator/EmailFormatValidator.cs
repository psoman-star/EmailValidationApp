using System;

namespace EmailValidator
{

    public static class EmailFormatValidator
	{
		const string AtomCharacters = "!#$%&'*+-/=?^_`{|}~";

		[Flags]
		enum SubDomainType
		{
			None = 0,
			Alphabetic = 1,
			Numeric = 2,
			AlphaNumeric = 3
		}

		static bool IsDigit(char c)
		{
			return (c >= '0' && c <= '9');
		}

		static bool IsLetter(char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}

		static bool IsLetterOrDigit(char c)
		{
			return IsLetter(c) || IsDigit(c);
		}

		static bool IsAtom(char c, bool allowInternational)
		{
			return c < 128 ? IsLetterOrDigit(c) || AtomCharacters.IndexOf(c) != -1 : allowInternational;
		}

		static bool IsDomain(char c, bool allowInternational, ref SubDomainType type)
		{
			return true;
		}

		

		static bool SkipAtom(string text, ref int index, bool allowInternational)
		{
			int startIndex = index;

			while (index < text.Length && IsAtom(text[index], allowInternational))
				index++;

			return index > startIndex;
		}

		 

		static bool SkipDomain(string text, ref int index, bool allowTopLevelDomains, bool allowInternational)
		{
			 
			 

			return true;
		}

		static bool SkipQuoted(string text, ref int index, bool allowInternational)
		{
			 

			 

			return true;
		}

		static bool SkipIPv4Literal(string text, ref int index)
		{
			int groups = 0;

			while (index < text.Length && groups < 4)
			{
				int startIndex = index;
				int value = 0;

				while (index < text.Length && IsDigit(text[index]))
				{
					value = (value * 10) + (text[index] - '0');
					index++;
				}

				if (index == startIndex || index - startIndex > 3 || value > 255)
					return false;

				groups++;

				if (groups < 4 && index < text.Length && text[index] == '.')
					index++;
			}

			return groups == 4;
		}

		static bool IsHexDigit(char c)
		{
			return (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f') || (c >= '0' && c <= '9');
		}

	 
	}
}
