using CSharpVitamins;
using HashidsNet;
using Helpers.Helper.Globals;
using Newtonsoft.Json;
using PhoneNumbers;
using Shared.Helpers.Encrypts.MD5Helper;
using Shared.Helpers.Helper.RandomString;
using Shared.Utilities.Format;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Helpers.Helper.Convert
{
    public static class ConvertHelper
    {
        public static string Now() => DateTimeOffset.Now.ToString(FormatEnum.TimeZone);
        public static DateTimeOffset ToNow() => DateTimeOffset.Now;
        public static string ToNow(this DateTimeOffset dateTime) => dateTime.ToString(FormatEnum.TimeZone);

        public static DateTimeOffset ToDateNow(this DateTime dateTime) => DateTimeOffset.Parse(dateTime.ToString(FormatEnum.TimeZone));
        public static string ConvertToFormat(this string dateTime,string format="o") => DateTimeOffset.Parse(dateTime).ToString(format);
        public static string ToSerialize(this object obj) => JsonConvert.SerializeObject(obj);

        public static T ToDeserialize<T>(this string str) => JsonConvert.DeserializeObject<T>(str);

        public static string ToLower(this string str) => string.Join("", str.Split(' ')).Trim().ToLower();

        public static string ToCapitalize(this string str) => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str.ToLower());

        public static string DecimalToCurrency(this decimal money, string format = "#,###") => money.ToString(format) ?? "0";

        public static string IntToCurrency(this int value, string format = "#,###") => value.ToString(format) ?? "0";

        public static DateTime TicksToDateTime(this long value)
        { return new DateTime(value); }

        public static string ToCode(this string value, int numberFormat, string prefix = "", string hyphen = "")
        {
            if (value != null && value != "")
            {
                var maxCharacter = value.Length > numberFormat ? numberFormat + (value.Length - numberFormat) : numberFormat;
                var valueFormat = value.PadLeft(maxCharacter, '0');
                return string.Concat(prefix, hyphen, valueFormat);
            }
            return default;
        }

        public static string? ToAcronym(this string str, int length = 1)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            var name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str.ToLower());
            var regGroup = Regex.Match(name, "(?:([A-Z]+)(?:[^A-Z]*))*").Groups[1].Captures.Cast<Capture>().Select(p => p.Value)?.ToList();
            if (regGroup != null && (regGroup.Count == 1 || (regGroup.Count > 0 && length == 1)))
            {
                return regGroup[0];
            }
            if (regGroup != null && regGroup.Count > 1)
            {
                var first = regGroup.Count > length ? string.Join(string.Empty, regGroup?.Take(length - 1)) ?? "" : regGroup?.FirstOrDefault();
                var last = regGroup?.LastOrDefault() ?? "";
                var joinList = new List<string> { first, last } ?? null;
                return joinList != null && joinList.Any() ? string.Join(string.Empty, joinList) : regGroup?.FirstOrDefault();
            }
            return str.Substring(0, 1);
        }

        public static bool IsDigit(this string str) => int.TryParse(str, out _);

        public static bool EmailValidate(this string email)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

        public static PhoneNumber ToParsePhone(this string phone, string regionCode = "VN")
        {
            var number = new PhoneNumber();
            try
            {
                if (phone != "")
                {
                    var phoneNumberUtil = PhoneNumberUtil.GetInstance();

                    number = phoneNumberUtil.Parse(phone, regionCode);
                }
            }
            catch (Exception e)
            {
            }
            return number;
        }

        public static string ToHashId(this long key)
        {
            if (key > 0)
            {
                var hashids = new Hashids("", 0, "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789");
                return hashids.EncodeLong(key);
            }
            return "";
        }

        public static string ToFullDateTimeFormat(this string dateValue, string format = "dd/MM/yyyy HH:mm", string textInfo = "vi-VN")
        {
            if (string.IsNullOrEmpty(dateValue)) return "";
            var toDate = dateValue?.ConvertToDateTime();
            var culture = new CultureInfo(textInfo);
            var dateOfWeek = culture.DateTimeFormat.GetDayName(toDate.Value.DayOfWeek);
            return dateOfWeek + ", " + toDate.Value.ToString(format);
        }

        public static DateTime ConvertToDateTime(this string dateValue)
        {
            var dd = DateTime.Now;
            if (string.IsNullOrEmpty(dateValue)) return dd;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            try
            {
                dd = DateTime.Parse(dateValue);
            }
            catch (Exception e)
            {
                dd = DateTime.Parse("0001-01-01");
            }
            if (dd.Year == 1)
            {
                string[] formats =
                {
                "dd/MM/yyyy"
                , "dd/M/yyyy"
                , "d/M/yyyy"
                , "d/MM/yyyy"
                , "dd/MM/yy"
                , "dd/M/yy"
                , "d/M/yy"
                , "d/MM/yy"
                , "MM/dd/yyyy"
                , "dd-MM-yyyy"
                , "MM-dd-yyyy"
                , "yyyy-MM-dd"
                , "yyyy-dd-MM"
                , "yyyy/MM/dd"
                , "yyyy/dd/MM"
                , "dd/MM/yyyy HH:mm"
                , "dd/M/yyyy HH:mm"
                , "d/M/yyyy HH:mm"
                , "d/MM/yyyy HH:mm"
                , "dd/MM/yy HH:mm"
                , "dd/M/yy HH:mm"
                , "d/M/yy HH:mm"
                , "d/MM/yy HH:mm"
                , "M/dd/yyyy HH:mm"
                , "MM/dd/yyyy HH:mm"
                , "MM/dd/yyyy HH:mm"
                , "dd-MM-yyyy HH:mm"
                , "MM-dd-yyyy HH:mm"
                , "yyyy-MM-dd HH:mm"
                , "yyyy-dd-MM HH:mm"
                , "yyyy/MM/dd HH:mm"
                , "yyyy/dd/MM HH:mm"

                , "dd/MM/yyyy HH:mm:ss"
                , "dd/MM/yyyy HH:mm:ss tt"
                , "dd/M/yyyy HH:mm:ss"
                , "d/M/yyyy HH:mm:ss"
                , "d/MM/yyyy HH:mm:ss"
                , "dd/MM/yy HH:mm:ss"
                , "dd/M/yy HH:mm:ss"
                , "d/M/yy HH:mm:ss"
                , "d/MM/yy HH:mm:ss"
                , "MM/dd/yyyy HH:mm:ss"
                , "dd-MM-yyyy HH:mm:ss"
                , "MM-dd-yyyy HH:mm:ss"
                , "yyyy-MM-dd HH:mm:ss"
                , "yyyy-dd-MM HH:mm:ss"
                , "yyyy/MM/dd HH:mm:ss"
                , "yyyy/dd/MM HH:mm:ss"
                , "yyyy-MM-dd HH:mm:ss.fffffff"
                , "yyyy-MM-ddTHH:mm:ss.szzz"
                , "yyMMddHHmmssff"
                , "yyMMddHHmmss"
                ,"yyyyMMddHHmmssff"
                ,"yyyyMMddHHmmss"
                , "yyyy-MM-dd HH:mm:ss.fff"
                , "yyyy-MM-ddTHH:mm:ss.szzz"
                , "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'"
                , "yyyy-MM-dd'T'HH:mm:ss.fffffff"
                , "yyyy-MM-dd HH:mm:ss.fffffff"
                , "yyyy-MM-dd'T'HH:mm:ss'Z'"
                , "yyyy-MM-dd'T'HH:mm:ss'.fffZ'"
            };
                DateTime.TryParseExact(dateValue, formats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dd);
            }
            return dd;
        }

        public static string OTPs(int length = 6)
        {
            var rd = new Random().Next(100, 999999);
            return rd.ToString().PadLeft(length, '0');
        }

        public static DateTimeOffset OTPsTimeCounter(this string dateExpire, int total_sent = 0, int total_expire = 0)
        {
            if (dateExpire == "") return DateTimeOffset.Now;
            var random = new Random();
            var counter = total_sent > 0 && total_sent < 5 ? total_sent : random.Next(1, 4);
            var countAllow = Math.Pow(2, counter) + total_expire;
            var now = DateTime.Parse(dateExpire);
            var otpsTimeCounter = now.AddSeconds(countAllow);
            return otpsTimeCounter;
        }

        public static double TotalTwoDate(this DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return Math.Round(fromDate.Subtract(toDate).TotalMilliseconds, 0);
        }


        #region DICTIONARY TO CLASS

        public static T ToClass<T>(this Dictionary<string, object> dictionary) where T : class
        {
            return dictionary?.ToSerialize()?.ToDeserialize<T>();
        }

        public static T ToClass<T>(this List<Dictionary<string, object>> dictionaryList) where T : class
        {
            return dictionaryList.ToSerialize()?.ToDeserialize<T>();
        }

        public static T ToClass<T>(this List<dynamic> objList) where T : class
        {
            return objList.ToSerialize()?.ToDeserialize<T>();
        }

        public static T ToClone<T>(this T doc) where T : class
        {
            return doc?.ToSerialize()?.ToDeserialize<T>();
        }

        #endregion DICTIONARY TO CLASS
        #region MD5 Managed

        public static string ToMD5Hash(this string password)
        {
            var encrypt = GetMd5Hash(password);
            var encryptSalt = GenerateHash(encrypt);
            return encryptSalt;
        }

        private static string GetMd5Hash(string input)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            Md5Managed md5 = new Md5Managed();
            byte[] hash = md5.ComputeHash(bs);

            var sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        private static string GenerateHash(string input)
        {
            string salt = "admin@carParking.vn";
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return System.Convert.ToBase64String(hash);
        }

        public static string ToJsonTemplate<T>(this string html, T doc)
        {
            if (string.IsNullOrEmpty(html)) return html;
            var template = Mustachio.Parser.Parse(html);
            var model = doc != null ? doc?.ToClone<dynamic>() : html;
            return template(model);
        }

        #endregion MD5 Managed
        #region Is BASE 64

        /// <summary>
        /// IsBase64=>Kiểm tra dữ liệu dạng base 64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBase64(this string str)
        {
            str = str.Trim();
            var base64Data = Regex.Match(str, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            if (string.IsNullOrEmpty(base64Data)) return false;
            return (base64Data.Length % 4 == 0) && Regex.IsMatch(base64Data, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        #endregion Is BASE 64
        #region Convert Base64 to Bytes

        /// <summary>
        /// Data Images to Base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] DataImageToBase64(this string str)
        {
            var base64Data = Regex.Match(str, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binary = System.Convert.FromBase64String(base64Data);
            return binary;
        }

        #endregion Convert Base64 to Bytes

        /// <summary>
        /// Save Image From Byte
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SaveImageFromByte(this byte[] data, string path, string name)
        {
            var folderSave = string.Empty;
            if (data.Length > 0)
            {
                MemoryStream ms = new MemoryStream(data, 0, data.Length);
                ms.Write(data, 0, data.Length);
                using Image image = Image.FromStream(ms, true);
                if (image != null)
                {
                    //var folderPath = GlobalsHelper.imageNewsURL + path;
                    //if (!File.Exists(folderPath))
                    //{
                    //    var directory = new DirectoryInfo(folderPath).Parent;
                    //    if (directory != null && !directory.Exists) Directory.CreateDirectory(directory.FullName);

                    var folderBase = GlobalsHelper.folderBase;
                    var dateFolder = DateTime.Now.ToString("yyyy/MM/dd") + "/" + DateTime.Now.ToString("HH") + "/";
                    var folderPath = path + dateFolder + name;
                    folderSave = folderBase + folderPath;
                    if (!File.Exists(folderSave))
                    {
                        var directory = new DirectoryInfo(folderSave).Parent;
                        if (directory != null && !directory.Exists) Directory.CreateDirectory(directory.FullName);
                        var tmpImg = new Bitmap(image);
                        tmpImg.Save(folderSave, ImageFormat.Jpeg);
                    }
                    //image.Save(folderPath,System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            return folderSave.Replace("\\", "/");
        }

        /// <summary>
        /// Saves Image from URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SaveImageFromURL(this string url, string path, string name)
        {
            var folderPath = string.Empty;
            System.Drawing.Image image = null;
            var extension = ".jpg";
            if (string.IsNullOrEmpty(url)) return string.Empty;
            if (url.IsBase64())
            {
                using MemoryStream ms = new(url.DataImageToBase64());
                image = Image.FromStream(ms);
            }
            else
            {
                using (WebClient client = new())
                {
                    var uri = new Uri(url);
                    extension = Path.GetExtension(uri.AbsolutePath)?.ToLower();
                    if (!string.IsNullOrEmpty(extension) && (extension.Equals(".jpg")
                        || extension.Equals(".jpeg")
                        || extension.Equals(".tiff")
                        || extension.Equals(".png")
                        || extension.Equals(".bmp"))
                        )
                    {
                        byte[] imageData = client.DownloadData(url);
                        MemoryStream imgStream = new(imageData);
                        image = Image.FromStream(imgStream);

                        //WebRequest request = WebRequest.Create(url);
                        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        //var statusCode = response.StatusCode;
                        //if (statusCode != HttpStatusCode.OK)
                        //{
                        //    return "";
                        //}
                        //try
                        //{
                        //    image = Image.FromStream(response.GetResponseStream());
                        //}
                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine(ex.Message + "------" + ex.StackTrace);
                        //}
                        //client.DownloadStringCompleted += (sender, args) =>
                        //{
                        //    if (!args.Cancelled && args.Error == null)
                        //    {
                        //        string result = args.Result; // do something fun...
                        //    }
                        //};
                        //client.DownloadStringAsync(new Uri(url));
                    }
                }
                if (image == null) { return ""; }
                int wSize = image.Width;
                int hSize = image.Height;
                if (wSize > 200 && hSize > 200)
                {
                    var folderBase = GlobalsHelper.folderBase;
                    var dateFolder = DateTime.Now.ToString("yyyy/MM/dd") + "/" + DateTime.Now.ToString("HH") + "/";
                    folderPath = GlobalsHelper.imageNewsURL + path + dateFolder + name + extension;
                    var folderSave = folderBase + folderPath;
                    if (!File.Exists(folderSave))
                    {
                        var directory = new DirectoryInfo(folderSave).Parent;
                        if (directory != null && !directory.Exists) Directory.CreateDirectory(directory.FullName);
                        image.Save(folderSave);
                    }
                }
            }
            return folderPath.Replace("\\", "/");
        }

        /// <summary>
        ///Get Month Between two days
        ///https://stackoverflow.com/questions/11930565/list-the-months-between-two-dates
        ///var startDate = DateTime.ParseExact("01/01/2011", "MM/dd/yyyy");
        ///var endDate = DateTime.ParseExact("11/30/2011", "MM/dd/yyyy");
        ///var months = MonthsBetween(startDate, endDate);
        ///The results should be something like
        ///{
        ///    {  "January", 2011  },
        ///    {  "February", 2011  },
        ///    { "March", 2011  },
        ///    { "April", 2011  },
        ///    { "May", 2011  },
        ///    { "June", 2011  },
        ///    { "July", 2011  },
        ///    { "August", 2011  },
        ///    { "September", 2011  },
        ///    { "October", 2011  },
        ///    { "November", 2011  },
        ///}
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>
        /// </returns>
        public static IEnumerable<(int Month, int Year, string MonthText)> MonthsBetween(
        DateTime startDate,
        DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return (
                    iterator.Month,
                    iterator.Year,
                    dateTimeFormat.GetMonthName(iterator.Month)
                );

                iterator = iterator.AddMonths(1);
            }
        }

        /// <summary>
        ///
        ///
        /// https://stackoverflow.com/questions/51628907/get-week-range-between-two-dates-in-c-sharp
        /// foreach( var t in Split(new DateTime(2018,8,1), new DateTime(2018,8,17),6)){
        ///Console.WriteLine(t.Item1.ToString() + " " + t.Item2.ToString());
        ///}
        ///I have the output
        ///8/1/2018 12:00:00 AM 8/7/2018 12:00:00 AM
        ///8/8/2018 12:00:00 AM 8/14/2018 12:00:00 AM
        ///8/15/2018 12:00:00 AM 8/21/2018 12:00:00 AM
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="chunk"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<DateTime, DateTime>> WeeklyBetween(DateTime start, DateTime end, int chunk = 6)
        {
            DateTime chunkEnd;
            while ((chunkEnd = start.AddDays(chunk)) < end)
            {
                yield return Tuple.Create(start, chunkEnd);
                start = chunkEnd.AddDays(1);
            }
            yield return Tuple.Create(start, start.AddDays(chunk));
        }

        /// <summary>
        ///
        ///
        /// var date1 = new DateTime(2022, 3, 1, 8, 30, 0);
        /// var date2 = new DateTime(2022, 3, 5, 11, 30, 0);
        /// What I actually need is a result set like so;
        ///{(1.03.2022 08:30:00, 2.03.2022 00:00:00)}
        ///{(2.03.2022 00:00:00, 3.03.2022 00:00:00)}
        ///{(3.03.2022 00:00:00, 4.03.2022 00:00:00)}
        ///{(4.03.2022 00:00:00, 5.03.2022 00:00:00)}
        ///{(5.03.2022 00:00:00, 5.03.2022 11:30:00)}
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="dayChunkSize"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<DateTime, DateTime>> DateBetween(DateTime start, DateTime end, int dayChunkSize = 1)
        {
            DateTime chunkEnd;
            while ((chunkEnd = start.AddDays(dayChunkSize)) < end)
            {
                yield return Tuple.Create(start, chunkEnd.Date);
                start = chunkEnd.Date;
            }
            yield return Tuple.Create(start, end);
        }

        private static List<Tuple<DateTime>> StartEndBetweenDateList(DateTime StartDate, DateTime EndDate)
        {
            List<Tuple<DateTime>> EventsDatesRangeList = new List<Tuple<DateTime>>();
            Console.WriteLine("");
            int TotalMonths = EndDate.Month - StartDate.Month +
                            (EndDate.Year - StartDate.Year) * 12;

            int CurrentYear = StartDate.Year;
            int MonthsToSubtract = 0;

            for (int i = 0; i <= TotalMonths; i++)
            {
                int CurrentMonth = StartDate.Month + i;

                if (StartDate.Month + i > 12)
                {
                    if ((StartDate.Month + i) % 12 == 1)
                    {
                        CurrentYear++;
                        Console.WriteLine(CurrentYear.ToString());
                        MonthsToSubtract = StartDate.Month + i - 1;
                    }

                    CurrentMonth = StartDate.Month + i - MonthsToSubtract;
                }

                DateTime FirstDay = new DateTime(CurrentYear, CurrentMonth, 1);
                if (i == 0)
                {
                    FirstDay = StartDate;
                }
                DateTime LastDay = new DateTime(CurrentYear, CurrentMonth, DateTime.DaysInMonth(CurrentYear, FirstDay.Month));
                if (i == TotalMonths)
                {
                    LastDay = EndDate;
                }
                Console.WriteLine(FirstDay.ToString("d-MMMM") + " to " + LastDay.ToString("d-MMMM"));
                EventsDatesRangeList.Add(new Tuple<DateTime>(FirstDay));
                EventsDatesRangeList.Add(new Tuple<DateTime>(LastDay));
            }
            return EventsDatesRangeList;
        }

        public static string ShortGuid()
        {
            Guid guid = Guid.NewGuid();
            ShortGuid id = guid;//CSharpVitamins
            return id;
        }

        public static string Otp(string format = "nnnn")
        {
            var _generator = new RandomStringGenerator(true, false, true, false);
            var otp = _generator.Generate("nnnn");
            return otp;
        }

        public static bool VietNamTaxCode(this string taxCode)
        {
            var flag = false;
            if (taxCode.Length < 10) return flag;
            var strTaxCode = taxCode.Substring(0, 10);
            if (!strTaxCode.IsDigit()) return flag;
            int[] checkArr = { 31, 29, 23, 19, 17, 13, 7, 5, 3 };
            int checkNumber = 0;
            try
            {
                for (int i = 0; i < strTaxCode.Length - 1; i++)
                    checkNumber += Int32.Parse(strTaxCode.Substring(i, 1)) * checkArr[i];
                flag = double.Parse(strTaxCode.Substring(9, 1)) == (10 - checkNumber % 11);
            }
            catch (Exception e) { }
            return flag;
        }

        //public static account_infoModel ConvertCIDToFormat(this string cid)
        //{
        //    if (string.IsNullOrEmpty(cid)) return null;
        //    var cidFormat = cid.Split(["|"], StringSplitOptions.TrimEntries);
        //    if (cidFormat.Length < 6) return null;
        //    var account_info = new account_infoModel
        //    {
        //        CID = cidFormat[0],
        //        CMND = cidFormat[1],
        //        full_name = cidFormat[2],
        //        date_of_birth = cidFormat[3],
        //        gender = cidFormat[4],
        //        full_address = cidFormat[5],
        //        cid_date = cidFormat[6],
        //    };
        //    return account_info;
        //}
    }

    public static class Extensions
    {
        /// <summary>
        ///     Converts a time to the time in a particular time zone.
        /// </summary>
        /// <param name="dateTimeOffset">The date and time to convert.</param>
        /// <param name="destinationTimeZone">The time zone to convert  to.</param>
        /// <returns>The date and time in the destination time zone.</returns>
        public static DateTimeOffset ToConvertTime(this DateTimeOffset dateTimeOffset)
        {
            //2022.01.22
            //https://csharp-extension.com/en/method/1002275/datetimeoffset-converttime
            //https://dotnetfiddle.net/zcc9CF
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            return TimeZoneInfo.ConvertTime(dateTimeOffset, tst);
        }
    }

    /// <summary>
    /// Kết quả của tổng số theo Năm, Tháng, Ngày, Giờ, Phút, Giây, Mili Giây
    ///DateTime compareTo = DateTime.Parse("8/13/2010 8:33:21 AM");
    ///DateTime now = DateTime.Parse("2/9/2012 10:10:11 AM");
    ///var dateSpan = DateTimeSpan.CompareDates(compareTo, now);
    ///Console.WriteLine("Years: " + dateSpan.Years);
    ///Console.WriteLine("Months: " + dateSpan.Months);
    ///Console.WriteLine("Days: " + dateSpan.Days);
    ///Console.WriteLine("Hours: " + dateSpan.Hours);
    ///Console.WriteLine("Minutes: " + dateSpan.Minutes);
    ///Console.WriteLine("Seconds: " + dateSpan.Seconds);
    ///Console.WriteLine("Milliseconds: " + dateSpan.Milliseconds);
    ///Outputs:
    ///Years: 1
    ///Months: 5
    ///Days: 27
    ///Hours: 1
    ///Minutes: 36
    ///Seconds: 50
    ///Milliseconds: 0
    /// </summary>
    public struct DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
    {
        public int Years { get; } = years;
        public int Months { get; } = months;
        public int Days { get; } = days;
        public int Hours { get; } = hours;
        public int Minutes { get; } = minutes;
        public int Seconds { get; } = seconds;
        public int Milliseconds { get; } = milliseconds;

        private enum Phase
        { Years, Months, Days, Done }

        public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
        {
            if (date2 < date1)
            {
                (date2, date1) = (date1, date2);
            }

            DateTime current = date1;
            int years = 0;
            int months = 0;
            int days = 0;

            Phase phase = Phase.Years;
            DateTimeSpan span = new DateTimeSpan();
            int officialDay = current.Day;

            while (phase != Phase.Done)
            {
                switch (phase)
                {
                    case Phase.Years:
                        if (current.AddYears(years + 1) > date2)
                        {
                            phase = Phase.Months;
                            current = current.AddYears(years);
                        }
                        else
                        {
                            years++;
                        }
                        break;

                    case Phase.Months:
                        if (current.AddMonths(months + 1) > date2)
                        {
                            phase = Phase.Days;
                            current = current.AddMonths(months);
                            if (current.Day < officialDay && officialDay <= DateTime.DaysInMonth(current.Year, current.Month))
                                current = current.AddDays(officialDay - current.Day);
                        }
                        else
                        {
                            months++;
                        }
                        break;

                    case Phase.Days:
                        if (current.AddDays(days + 1) > date2)
                        {
                            current = current.AddDays(days);
                            var timespan = date2 - current;
                            span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                            phase = Phase.Done;
                        }
                        else
                        {
                            days++;
                        }
                        break;
                }
            }

            return span;
        }
    }

    public class SemiNumericComparer : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            var s1n = IsNumeric(x, out int s1r);
            var s2n = IsNumeric(y, out int s2r);

            if (s1n && s2n) return s1r - s2r;
            else if (s1n) return -1;
            else if (s2n) return 1;

            var num1 = Regex.Match(x, @"\d+$");
            var num2 = Regex.Match(y, @"\d+$");

            var onlyString1 = x.Remove(num1.Index, num1.Length);
            var onlyString2 = y.Remove(num2.Index, num2.Length);

            if (onlyString1 != onlyString2) return string.Compare(x, y, true);
            if (num1.Success && num2.Success) return System.Convert.ToInt32(num1.Value) - System.Convert.ToInt32(num2.Value);
            else if (num1.Success) return 1;
            else if (num2.Success) return -1;

            return string.Compare(x, y, true);
        }

        public bool IsNumeric(string value, out int result)
        {
            return int.TryParse(value, out result);
        }
    }
    public class JsonService
    {
        public async Task<T> DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<string> SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}