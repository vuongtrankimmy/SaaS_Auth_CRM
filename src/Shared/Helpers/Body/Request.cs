using Helpers.Helper.Convert;
using Helpers.Sort;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;

namespace Shared.Helpers.Body
{
    /// <summary>
    /// The request.
    /// </summary>
    public static class Request
    {
        static Queue<string> queue = new Queue<string>();
        /// <summary>
        /// Gets the raw body async.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="encrypto">If true, encrypto.</param>
        /// <param name="sort">If true, sort.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>A Task.</returns>
        public static async Task<T> GetRawBodyAsync<T>(
            this HttpRequest context, bool encrypto = false, bool sort = true,
            Encoding? encoding = null) where T : new()
        {
            var body = context.Body;
            if (!body.CanSeek)
            {
                // We only do this if the stream isn't *already* seekable,
                // as EnableBuffering will create a new stream instance
                // each time it's called
                //context.Request.EnableBuffering();
            }
            var reader = new StreamReader(body, encoding ?? Encoding.UTF8);
            var rawData = await reader.ReadToEndAsync().ConfigureAwait(false);
            //body.Position = 0;
            var t = new T();
            try
            {
                if (rawData == "" || rawData.ToLower() == "null") return t;
                if (encrypto)
                {
                    var enBody = rawData.Replace("\"", "");
                    //body = EncryptionHelper.DecryptByAES(enBody);
                }
                if (rawData != "")
                {
                    //if (queue!=null&& queue.Count > 0)
                    //{
                    //    if (queue.Contains(body))
                    //    {
                    //        Thread.Sleep(5000);
                    //        return t;
                    //    }
                    //}
                    //queue.Enqueue(body);

                    if (rawData.Contains('+'))
                    {
                        var specialChar = HttpUtility.UrlEncode("+");
                        rawData = rawData.Replace("+", specialChar);
                    }
                    var decode = HttpUtility.UrlDecode(rawData);//lỗi html - kiểm tra cách cho phép html lưu xuống
                    if (sort)
                    {
                        var jObj =decode.ToDeserialize<JObject>();
                        await SortExtension.Sort(jObj);
                        t = (jObj?.ToString() ?? "").ToDeserialize<T>();
                    }
                    else
                    {
                        t = (decode ?? "").ToDeserialize<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "-" + ex.StackTrace);
            }
            finally
            {
                //if (queue.Count > 0)
                //    queue.Dequeue();
            }
            return t;
        }
    }
}
