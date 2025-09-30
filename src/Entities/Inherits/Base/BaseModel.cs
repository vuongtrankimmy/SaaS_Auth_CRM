using System.Reflection;

namespace Entities.Inherits.Base
{
    public abstract class baseFieldModel
    {
        public string create_date { get; set; } = DateTimeOffset.Now.ToString("o");
        public string update_date { get; set; } = string.Empty;
        public string account_id { get; set; }
        //public string location_id { get; set; }
        //public string device_id { get; set; }
        public int? order_no { get; set; } = 0;
        /// <summary>
        /// -1:Only SignUp 0: InActive, 1: Active, 2: Deleted, 3: Bane
        /// </summary>
        public int statusID { get; set; } = 1;
        public bool? visible { get; set; } = true;
        public string Version { get; set; } = Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString() ?? "";
    }

    public abstract class BaseModel : baseFieldModel
    {
        public string _id { get; set; }
        public string hashIds { get; set; }
        public long? _key { get; set; }
    }
}