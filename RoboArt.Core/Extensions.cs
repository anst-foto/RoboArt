using System.Text.RegularExpressions;

namespace RoboArt.Core;

public static class StringExtensions
{
    public static bool IsOnlyCyrillic(this string value)
    {
        const string pattern = @"^[А-Яа-яЁё]+$";
        const RegexOptions options = RegexOptions.Singleline;
        return Regex.IsMatch(value, pattern, options);
    }
}