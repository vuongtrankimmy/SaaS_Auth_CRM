using Entities.Inherits.Base;

namespace Entities.Inherits.Media
{
    public abstract class BaseMediaDTOs : BaseModel
    {
        public bool? isDelete { get; set; } = false;
        public int? height { get; set; }
        public string name { get; set; }
        public int? size { get; set; }
        public int? style { get; set; }
        public int? styleId { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string urlRewrite { get; set; }
        public int? width { get; set; }
    }
}