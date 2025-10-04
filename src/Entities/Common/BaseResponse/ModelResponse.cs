namespace Entities.Common.BaseResponse
{
    public class ModelResponse
    {
        /// <summary>
        /// 0:success, 1:fail
        /// </summary>
        public int code { get; set; } = 0;
        public string error { get; set; } = "0";
        public object? data { get; set; }
    }

    public class IsValidResponse
    {
        public bool IsExist { get; set; } = false;
    }
}
