using Entities.Inherits.Base;

namespace Entities.Inherits.Channels
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
    }

    public class ChannelsDTOs : BaseDTOs
    {
        public List<Channel> ChannelList { get; set; }
        public string Channels { get; set; }
    }
}