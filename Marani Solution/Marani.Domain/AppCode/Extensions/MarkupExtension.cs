using System.Text.RegularExpressions;

namespace Marani.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        static public string ToPlainText(this string text)
        {
            text = Regex.Replace(text, "<[^>]*>", "");
            return text;

        }

        static public string ToEllipse(this string text, int len)
        {
            if (!string.IsNullOrWhiteSpace(text) && text.Length>len)
            {
                text=text.Substring(0, len);    
            }
        return text;
        }

    }
}
