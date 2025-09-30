using Entities.Inherits.Helpers.Template.Otp;
using Helpers.Helper.ReplaceTokenize;

namespace Shared.Helpers.Template.Otp
{
    public static class OtpTemplate
    {
        public static async Task<string> OtpTemplateAsync(this string body, TemplateHelper_OtpDTOs doc)
        {
            var otp = doc?.otp??"";
            var expiryTime = doc?.expiryTime ?? "";
            var url = doc?.url ?? "";
            FastReplacer fr = new("{", "}");
            fr.Append(body);
            fr.Replace("{otp}", otp);
            fr.Replace("{otp.expiryTime}", expiryTime);
            fr.Replace("{url}", url);
            var bodyPlainText = fr.ToString();
            return bodyPlainText;
        }
    }
}
