using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helpers.Helper.UnicodeToAnsi
{
    public static class UnicodeToAnsiHelper
    {
        private static string ConvertToEnglish(string str)
        {
            str = str.Replace("À", "A");
            str = str.Replace("Á", "A");
            str = str.Replace("Ả", "A");
            str = str.Replace("Ã", "A");
            str = str.Replace("Ạ", "A");

            str = str.Replace("Ă", "A");
            str = str.Replace("Ắ", "A");
            str = str.Replace("Ẳ", "A");
            str = str.Replace("Ẵ", "A");
            str = str.Replace("Ặ", "A");
            str = str.Replace("Ằ", "A");

            str = str.Replace("Â", "A");
            str = str.Replace("Ấ", "A");
            str = str.Replace("Ầ", "A");
            str = str.Replace("Ẩ", "A");
            str = str.Replace("Ẫ", "A");
            str = str.Replace("Ậ", "A");

            str = str.Replace("Đ", "D");
            str = str.Replace("È", "E");
            str = str.Replace("É", "E");
            str = str.Replace("Ẻ", "E");
            str = str.Replace("Ẽ", "E");
            str = str.Replace("Ẹ", "E");

            str = str.Replace("Ê", "E");
            str = str.Replace("Ề", "E");
            str = str.Replace("Ế", "E");
            str = str.Replace("Ể", "E");
            str = str.Replace("Ễ", "E");
            str = str.Replace("Ệ", "E");

            str = str.Replace("Ì", "I");
            str = str.Replace("Í", "I");
            str = str.Replace("Ỉ", "I");
            str = str.Replace("Ĩ", "I");
            str = str.Replace("Ị", "I");

            str = str.Replace("Ò", "O");
            str = str.Replace("Ó", "O");
            str = str.Replace("Ỏ", "O");
            str = str.Replace("Õ", "O");
            str = str.Replace("Ọ", "O");

            str = str.Replace("Ô", "O");
            str = str.Replace("Ồ", "O");
            str = str.Replace("Ố", "O");
            str = str.Replace("Ổ", "O");
            str = str.Replace("Ỗ", "O");
            str = str.Replace("Ộ", "O");

            str = str.Replace("Ơ", "O");
            str = str.Replace("Ờ", "O");
            str = str.Replace("Ớ", "O");
            str = str.Replace("Ở", "O");
            str = str.Replace("Ỡ", "O");
            str = str.Replace("Ợ", "O");

            str = str.Replace("Ù", "U");
            str = str.Replace("Ú", "U");
            str = str.Replace("Ủ", "U");
            str = str.Replace("Ũ", "U");
            str = str.Replace("Ụ", "U");

            str = str.Replace("Ư", "U");
            str = str.Replace("Ừ", "U");
            str = str.Replace("Ứ", "U");
            str = str.Replace("Ử", "U");
            str = str.Replace("Ữ", "U");
            str = str.Replace("Ự", "U");

            str = str.Replace("Ỳ", "Y");
            str = str.Replace("Ý", "Y");
            str = str.Replace("Ỷ", "Y");
            str = str.Replace("Ỹ", "Y");
            str = str.Replace("Ỵ", "Y");

            // LOWER CASE
            str = str.Replace("à", "a");
            str = str.Replace("á", "a");
            str = str.Replace("ả", "a");
            str = str.Replace("ã", "a");
            str = str.Replace("ạ", "a");

            str = str.Replace("â", "a");
            str = str.Replace("ấ", "a");
            str = str.Replace("ầ", "a");
            str = str.Replace("ẩ", "a");
            str = str.Replace("ẫ", "a");
            str = str.Replace("ậ", "a");

            str = str.Replace("ă", "a");
            str = str.Replace("ắ", "a");
            str = str.Replace("ằ", "a");
            str = str.Replace("ẳ", "a");
            str = str.Replace("ẵ", "a");
            str = str.Replace("ặ", "a");

            str = str.Replace("đ", "d");

            str = str.Replace("è", "e");
            str = str.Replace("é", "e");
            str = str.Replace("ẻ", "e");
            str = str.Replace("ẽ", "e");
            str = str.Replace("ẹ", "e");

            str = str.Replace("ê", "e");
            str = str.Replace("ề", "e");
            str = str.Replace("ế", "e");
            str = str.Replace("ể", "e");
            str = str.Replace("ễ", "e");
            str = str.Replace("ệ", "e");
            str = str.Replace("ẽ", "e");

            str = str.Replace("ì", "i");
            str = str.Replace("í", "i");
            str = str.Replace("ỉ", "i");
            str = str.Replace("ĩ", "i");
            str = str.Replace("ị", "i");
            str = str.Replace("ị", "i");

            str = str.Replace("ò", "o");
            str = str.Replace("ó", "o");
            str = str.Replace("ỏ", "o");
            str = str.Replace("õ", "o");
            str = str.Replace("ọ", "o");

            str = str.Replace("ô", "o");
            str = str.Replace("ồ", "o");
            str = str.Replace("ố", "o");
            str = str.Replace("ổ", "o");
            str = str.Replace("ỗ", "o");
            str = str.Replace("ộ", "o");

            str = str.Replace("ơ", "o");
            str = str.Replace("ờ", "o");
            str = str.Replace("ớ", "o");
            str = str.Replace("ở", "o");
            str = str.Replace("ỡ", "o");
            str = str.Replace("ợ", "o");

            str = str.Replace("ù", "u");
            str = str.Replace("ú", "u");
            str = str.Replace("ủ", "u");
            str = str.Replace("ũ", "u");
            str = str.Replace("ụ", "u");

            str = str.Replace("ư", "u");
            str = str.Replace("ừ", "u");
            str = str.Replace("ứ", "u");
            str = str.Replace("ử", "u");
            str = str.Replace("ữ", "u");
            str = str.Replace("ự", "u");

            str = str.Replace("ỳ", "y");
            str = str.Replace("ý", "y");
            str = str.Replace("ỷ", "y");
            str = str.Replace("ỹ", "y");
            str = str.Replace("ỵ", "y");
            return str;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a str to an alias. </summary>
        ///
        /// <remarks>   Vuong Tran, 11/12/2018. </remarks>
        ///
        /// <param name="str">  The string. </param>
        ///
        /// <returns>   The given data converted to an alias. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string ConvertToAlias(string str)
        {
            str = ConvertToEnglish(str);
            str = str.Replace(" ", "");
            str = str.Replace("-", "");
            str = str.Replace("+", "");
            str = str.Replace("/", "");
            str = str.Replace("\\", "");
            str = str.Replace("+", "");
            str = str.Replace("&", "");
            str = str.Replace("$", "");
            str = str.Replace("!", "");
            str = str.Replace("#", "");
            str = str.Replace("@", "");
            str = str.Replace("%", "");
            str = str.Replace("^", "");
            str = str.Replace("*", "");
            str = str.Replace(":", "");
            str = str.Replace(",", "");
            str = str.Replace("?", "");
            str = str.Replace("<", "");
            str = str.Replace(">", "");
            str = str.Replace("_", "");
            str = str.Replace("®", " ");
            str = str.Replace("™", " ");
            return str;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this object to a search google. </summary>
        ///
        /// <remarks>   Vuong Tran, 11/12/2018. </remarks>
        ///
        /// <param name="str">          The string. </param>
        /// <param name="replace">      The replace. </param>
        /// <param name="isEnglish">    True if is english, false if not. </param>
        ///
        /// <returns>   The given data converted to a search google. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ToAnsi(this string str, string replace = "", bool isEnglish = true)
        {
            str = str.Normalize();
            if (isEnglish)
                str = ConvertToEnglish(str);
            str = ReplaceWordChars(str);
            str = str.Replace("-", " ");
            str = str.Replace("+", " ");
            str = str.Replace("/", " ");
            str = str.Replace("\\", " ");
            str = str.Replace("+", " ");
            str = str.Replace("&", " ");
            str = str.Replace("$", " ");
            str = str.Replace("!", " ");
            str = str.Replace("#", " ");
            str = str.Replace("@", " ");
            str = str.Replace("%", " ");
            str = str.Replace("^", " ");
            str = str.Replace("*", " ");
            str = str.Replace(":", " ");
            str = str.Replace(",", " ");
            str = str.Replace("?", " ");
            str = str.Replace("<", " ");
            str = str.Replace(">", " ");
            str = str.Replace(".", " ");
            str = str.Replace("\'", " ");
            str = str.Replace(";", " ");
            str = str.Replace("®", " ");
            str = str.Replace("™", " ");
            str = str.Replace("�", " ");
            str = str.Replace(((char)34).ToString(), " ");
            str = str.Replace(((char)39).ToString(), " ");
            string fn = Regex.Replace(str, @"[(\n)(\s+)(\b)(\t)'!@#$%^&*()<>?/|{}~`:;-]", " ");
            str = Regex.Replace(fn, @"\s+", " ").Trim();

            str = str.Replace(" ", replace);
            str = Regex.Replace(str, @"[^0-9a-zA-Z_-]", replace);
            return str.ToLower();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Replace word characters. </summary>
        ///
        /// <remarks>   Vuong Tran, 11/12/2018. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string ReplaceWordChars(string text)
        {
            var s = text;
            // smart single quotes and apostrophe
            s = Regex.Replace(s, "[\u2018|\u2019|\u201A]", " ");
            // smart double quotes
            s = Regex.Replace(s, "[\u201C|\u201D|\u201E]", " ");
            // ellipsis
            s = Regex.Replace(s, "\u2026", " ");
            // dashes
            s = Regex.Replace(s, "[\u2013|\u2014]", "");
            // circumflex
            s = Regex.Replace(s, "\u02C6", " ");
            // open angle bracket
            s = Regex.Replace(s, "\u2039", " ");
            // close angle bracket
            s = Regex.Replace(s, "\u203A", " ");
            // spaces
            s = Regex.Replace(s, "[\u02DC|\u00A0]", " ");
            return s;
        }
    }
}
