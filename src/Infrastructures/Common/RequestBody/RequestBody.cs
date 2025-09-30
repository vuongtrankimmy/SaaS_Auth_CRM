using Helpers.Helper.Convert;
using Helpers.Helper.Encryption;
using Helpers.Sort;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;

namespace Infrastructures.Common.RequestBody
{
    public static class RequestBody
    {  /// <summary>
       /// Gets the raw body async.
       /// </summary>
       /// <param name="request">The request.</param>
       /// <param name="encrypto">If true, encrypto.</param>
       /// <param name="sort">If true, sort.</param>
       /// <param name="encoding">The encoding.</param>
       /// <returns>A Task.</returns>
        public static async Task<T> GetRawBodyAsync<T>(
            this HttpRequest request, bool encrypto = false, bool sort = true,
            Encoding encoding = null) where T : new()
        {

            if (!request.Body.CanSeek)
            {
                // We only do this if the stream isn't *already* seekable,
                // as EnableBuffering will create a new stream instance
                // each time it's called               
                request.EnableBuffering();
            }
            //request.Body.Seek(0, SeekOrigin.Begin);


            //var contentType = request.ContentType;
            //if (string.IsNullOrEmpty(contentType) || contentType == "text/plain")
            //{
            //    using (var ser = new StreamReader(request.Body))
            //    {
            //        var content = await ser.ReadToEndAsync();
            //    }
            //}

            request.Body.Position = 0;
            var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8);
            var body = await reader.ReadToEndAsync().ConfigureAwait(false);
            request.Body.Position = 0;
            var t = new T();
            try
            {
                if (body == "" || body.ToLower() == "null") return t;
                if (encrypto)
                {
                    var enBody = body.Replace("\"", "");
                    body = enBody.ToDecryptByAES();
                }
                if (body != "")
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

                    if (body.Contains('+'))
                    {
                        var specialChar = HttpUtility.UrlEncode("+");
                        body = body.Replace("+", specialChar);
                    }
                    var decode = HttpUtility.UrlDecode(body);//lỗi html - kiểm tra cách cho phép html lưu xuống
                    if (sort)
                    {
                        var jObj = decode.ToDeserialize<JObject>();
                        await SortExtension.Sort(jObj);
                        t = (jObj?.ToString() ?? "").ToDeserialize<T>();
                    }
                    else
                    {
                        t = (decode ?? "").ToDeserialize<T>();
                    }
                }
            }
            catch (System.Exception ex)
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
