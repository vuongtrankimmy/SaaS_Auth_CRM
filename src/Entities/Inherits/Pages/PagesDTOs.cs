namespace Entities.Inherits.Pages
{
    public class PagesDTOs : PagingBase
    {
        public PagingItem end { get; set; }
        public PagingItem next { get; set; }
        public List<PagingItem> pagingItemList { get; set; }
        public PagingItem preview { get; set; }
        public PagingItem start { get; set; }
        public int totalItemIndex { get; set; }
        public bool visible { get; set; } = false;
    }

    public class PagingBase
    {
        public string keyword { get; set; }
    }

    public class PagingItem : PagingBase
    {
        public bool active { get; set; } = false;
        public string activeCss { get; set; } = "";
        public string disabledCss { get; set; } = "";
        public bool enable { get; set; } = true;
        public string pagingName { get; set; }
        public int pagingNo { get; set; }
    }
}