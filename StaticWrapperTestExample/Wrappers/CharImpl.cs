using System.Globalization;
using StaticWrapperTestExample.Wrappers.Interfaces;

namespace StaticWrapperTestExample.Wrappers
{
    public class CharImpl : IChar
    {
        public bool IsControl(string s, int index)
        {
            return char.IsControl(s, index);
        }

        public bool IsDigit(string s, int index)
        {
            return char.IsDigit(s, index);
        }

        public bool IsLetter(string s, int index)
        {
            return char.IsLetter(s, index);
        }

        public bool IsLetterOrDigit(string s, int index)
        {
            return char.IsLetterOrDigit(s, index);
        }

        public bool IsLower(string s, int index)
        {
            return char.IsLower(s, index);
        }

        public bool IsNumber(char c)
        {
            return char.IsNumber(c);
        }

        public bool IsNumber(string s, int index)
        {
            return char.IsNumber(s, index);
        }

        public bool IsPunctuation(string s, int index)
        {
            return char.IsPunctuation(s, index);
        }

        public bool IsSeparator(char c)
        {
            return char.IsSeparator(c);
        }

        public bool IsSeparator(string s, int index)
        {
            return char.IsSeparator(s, index);
        }

        public bool IsSurrogate(char c)
        {
            return char.IsSurrogate(c);
        }

        public bool IsSurrogate(string s, int index)
        {
            return char.IsSurrogate(s, index);
        }

        public bool IsSymbol(char c)
        {
            return char.IsSymbol(c);
        }

        public bool IsSymbol(string s, int index)
        {
            return char.IsSymbol(s, index);
        }

        public bool IsUpper(string s, int index)
        {
            return char.IsUpper(s, index);
        }

        public bool IsWhiteSpace(string s, int index)
        {
            return char.IsWhiteSpace(s, index);
        }

        public UnicodeCategory GetUnicodeCategory(char c)
        {
            return char.GetUnicodeCategory(c);
        }

        public UnicodeCategory GetUnicodeCategory(string s, int index)
        {
            return char.GetUnicodeCategory(s, index);
        }

        public double GetNumericValue(char c)
        {
            return char.GetNumericValue(c);
        }

        public double GetNumericValue(string s, int index)
        {
            return char.GetNumericValue(s, index);
        }

        public bool IsHighSurrogate(char c)
        {
            return char.IsHighSurrogate(c);
        }

        public bool IsHighSurrogate(string s, int index)
        {
            return char.IsHighSurrogate(s, index);
        }

        public bool IsLowSurrogate(char c)
        {
            return char.IsLowSurrogate(c);
        }

        public bool IsLowSurrogate(string s, int index)
        {
            return char.IsLowSurrogate(s, index);
        }

        public bool IsSurrogatePair(string s, int index)
        {
            return char.IsSurrogatePair(s, index);
        }

        public bool IsSurrogatePair(char highSurrogate, char lowSurrogate)
        {
            return char.IsSurrogatePair(highSurrogate, lowSurrogate);
        }

        public string ConvertFromUtf32(int utf32)
        {
            return char.ConvertFromUtf32(utf32);
        }

        public int ConvertToUtf32(char highSurrogate, char lowSurrogate)
        {
            return char.ConvertToUtf32(highSurrogate, lowSurrogate);
        }

        public int ConvertToUtf32(string s, int index)
        {
            return char.ConvertToUtf32(s, index);
        }

        public string ToString(char c)
        {
            return char.ToString(c);
        }

        public char Parse(string s)
        {
            return char.Parse(s);
        }

        public bool TryParse(string? s, out char result)
        {
            return char.TryParse(s, out result);
        }

        public bool IsDigit(char c)
        {
            return char.IsDigit(c);
        }

        public bool IsLetter(char c)
        {
            return char.IsLetter(c);
        }

        public bool IsWhiteSpace(char c)
        {
            return char.IsWhiteSpace(c);
        }

        public bool IsUpper(char c)
        {
            return char.IsUpper(c);
        }

        public bool IsLower(char c)
        {
            return char.IsLower(c);
        }

        public bool IsPunctuation(char c)
        {
            return char.IsPunctuation(c);
        }

        public bool IsLetterOrDigit(char c)
        {
            return char.IsLetterOrDigit(c);
        }

        public char ToUpper(char c, CultureInfo culture)
        {
            return char.ToUpper(c, culture);
        }

        public char ToUpper(char c)
        {
            return char.ToUpper(c);
        }

        public char ToUpperInvariant(char c)
        {
            return char.ToUpperInvariant(c);
        }

        public char ToLower(char c, CultureInfo culture)
        {
            return char.ToLower(c, culture);
        }

        public char ToLower(char c)
        {
            return char.ToLower(c);
        }

        public char ToLowerInvariant(char c)
        {
            return char.ToLowerInvariant(c);
        }

        public bool IsControl(char c)
        {
            return char.IsControl(c);
        }
    }
}