using System.Globalization;

namespace StaticWrapperTestExample.Wrappers.Interfaces
{
    public interface IChar
    {
        bool IsControl(string s, int index);
        bool IsDigit(string s, int index);
        bool IsLetter(string s, int index);
        bool IsLetterOrDigit(string s, int index);
        bool IsLower(string s, int index);
        bool IsNumber(char c);
        bool IsNumber(string s, int index);
        bool IsPunctuation(string s, int index);
        bool IsSeparator(char c);
        bool IsSeparator(string s, int index);
        bool IsSurrogate(char c);
        bool IsSurrogate(string s, int index);
        bool IsSymbol(char c);
        bool IsSymbol(string s, int index);
        bool IsUpper(string s, int index);
        bool IsWhiteSpace(string s, int index);
        UnicodeCategory GetUnicodeCategory(char c);
        UnicodeCategory GetUnicodeCategory(string s, int index);
        double GetNumericValue(char c);
        double GetNumericValue(string s, int index);
        bool IsHighSurrogate(char c);
        bool IsHighSurrogate(string s, int index);
        bool IsLowSurrogate(char c);
        bool IsLowSurrogate(string s, int index);
        bool IsSurrogatePair(string s, int index);
        bool IsSurrogatePair(char highSurrogate, char lowSurrogate);
        string ConvertFromUtf32(int utf32);
        int ConvertToUtf32(char highSurrogate, char lowSurrogate);
        int ConvertToUtf32(string s, int index);
        string ToString(char c);
        char Parse(string s);
        bool IsDigit(char c);
        bool IsLetter(char c);
        bool IsWhiteSpace(char c);
        bool IsUpper(char c);
        bool IsLower(char c);
        bool IsPunctuation(char c);
        bool IsLetterOrDigit(char c);
        char ToUpper(char c, CultureInfo culture);
        char ToUpper(char c);
        char ToUpperInvariant(char c);
        char ToLower(char c, CultureInfo culture);
        char ToLower(char c);
        char ToLowerInvariant(char c);
        bool IsControl(char c);
        bool TryParse(string? s, out char result);
    }
}