using Entities.Inherits.Google.Map;
using System.Net;
using System.Text.RegularExpressions;

namespace Helpers.Helper.Google.Map
{
    public static class GoogleMapHelper
    {
        private static string urlGoogleApi = "https://www.google.com/search?tbm=map&authuser=0&hl=en";

        public static CoordinateModel GoogleApi(this string fullAddress)
        {
            CoordinateModel coordinate = null;
            try
            {
                if (!string.IsNullOrEmpty(urlGoogleApi))
                {
                    string url = urlGoogleApi + "&q=" + fullAddress + "&oq=" + fullAddress;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 10000;
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader sreader = new StreamReader(dataStream);
                    string responsereader = sreader.ReadToEnd();
                    response.Close();
                    if (responsereader == "") return coordinate;
                    var regexObj = @"(?<lat>[-+]?([0-9]+\.[0-9]+)).*(?<long>[-+]?([0-9]+\.[0-9]+))";
                    var matchResult = Regex.Match(responsereader, regexObj, RegexOptions.IgnorePatternWhitespace);
                    if (matchResult.Success)
                    {
                        var captures = matchResult?.Captures;
                        var capture = captures?.FirstOrDefault()?.Value;
                        if (!string.IsNullOrEmpty(capture))
                        {
                            var regexFloatObj = @"[-+]?[0-9]*\.?[0-9]*";
                            var matchFloatResultList = Regex.Matches(capture, regexFloatObj)?.Where(x => !string.IsNullOrEmpty(x.Value)
                            && x.Value.Contains(".") && float.TryParse(x.Value, out float xK) && xK < 200)?.TakeLast(2)?.ToList();
                            //var textPattern = Regex.Matches(responsereader, regexFloatObj)?.Where(x => !string.IsNullOrEmpty(x.Value)&&x.Value.Contains(".")
                            //&&float.TryParse(x.Value,out float xK)&& xK<200);
                            if (matchFloatResultList != null && matchFloatResultList.Any() && matchFloatResultList.Count.Equals(2))
                            {
                                var longitudeText = matchFloatResultList[0].Value;
                                var latitudeText = matchFloatResultList[1].Value;
                                if (!string.IsNullOrEmpty(longitudeText) && !string.IsNullOrEmpty(latitudeText))
                                {
                                    var longitude = float.Parse(longitudeText);
                                    var latitude = float.Parse(latitudeText);
                                    if (longitude > 0 && latitude > 0)
                                    {
                                        coordinate = new CoordinateModel
                                        {
                                            Latitude = latitude,
                                            Longitude = longitude,
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("message:" + e.Message + "\nstack:" + e.StackTrace);
            }
            return coordinate;
        }
    }
}