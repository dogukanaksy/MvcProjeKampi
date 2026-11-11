using System.Text.RegularExpressions;
using System.Web;

namespace MvcProjeKampi.Helpers
{
    public static class MessageText
    {
        private static readonly Regex LineBreakTags = new Regex(
            @"<(?:br\b[^<>]*|/(?:p|div|li|h[1-6])\s*)>",
            RegexOptions.IgnoreCase);

        private static readonly Regex HtmlTags = new Regex(
            @"</?[a-zA-Z][a-zA-Z0-9:-]*(?=[\s/>])(?:[^<>""']|""[^""]*""|'[^']*')*>");

        public static string ToPlainText(string content)
        {
            if (string.IsNullOrEmpty(content) || !HtmlTags.IsMatch(content))
            {
                return content ?? string.Empty;
            }

            var text = LineBreakTags.Replace(content, " ");
            text = HtmlTags.Replace(text, string.Empty);
            return HttpUtility.HtmlDecode(text).Trim();
        }
    }
}
