using Entities.Inherits.Pages;

namespace Helpers.Helper.Paging
{
    public class PagingHelper
    {
        public static PagesDTOs Get(string keyword = "", int pageIndex = 1, int pageSize = 10, decimal totalItem = 1)
        {
            var totalPage = int.Parse(Math.Ceiling(totalItem / pageSize).ToString());
            var pageNumberMax = 4;
            var iStart = pageIndex - pageNumberMax < 1 ? 1 : pageIndex - pageNumberMax;
            var iEnd = iStart + (pageNumberMax + 1) > totalPage ? totalPage : iStart + (pageNumberMax + 1);

            var pagingItemList = new List<PagingItem>();

            var activeStart = pageIndex > 1;
            var enableStart = pageIndex > 1;
            var disableCssStart = enableStart ? "" : "disabled";
            var pagingStart = new PagingItem
            {
                pagingNo = 1,
                pagingName = "Start",
                active = activeStart,
                enable = enableStart,
                disabledCss = disableCssStart,
                keyword = keyword
            };


            var activeEnd = pageIndex < totalPage;
            var enableEnd = pageIndex < totalPage;
            var disableCssEnd = enableEnd ? "" : "disabled";
            var pagingend = new PagingItem
            {
                pagingNo = totalPage,
                pagingName = "End",
                active = activeEnd,
                enable = enableEnd,
                disabledCss = disableCssEnd,
                keyword = keyword
            };

            int pagingNoPreview = pageIndex <= 1 ? 1 : pageIndex - 1;
            var activePreview = pageIndex > 1;
            var enablePreview = pageIndex > 1;
            var disableCssPreview = enablePreview ? "" : "disabled";
            var pagingPreview = new PagingItem
            {
                pagingNo = pagingNoPreview,
                pagingName = "Preview",
                active = activePreview,
                enable = enablePreview,
                disabledCss = disableCssPreview,
                keyword = keyword
            };

            var pagingNoNext = pageIndex >= totalPage ? totalPage : pageIndex + 1;
            var activeNext = pageIndex < totalPage;
            bool enableNext = pageIndex < totalPage;
            var disableCssNext = enableNext ? "" : "disabled";
            var pagingNext = new PagingItem
            {
                pagingNo = pagingNoNext,
                pagingName = "Next",
                active = activeNext,
                enable = enableNext,
                disabledCss = disableCssNext,
                keyword = keyword
            };

            for (int i = iStart; i <= iEnd; i++)
            {
                var active = i == pageIndex;
                var cssActive = active ? "active" : "";
                var disableCss = active ? "disabled" : "";
                var paingItem = new PagingItem
                {
                    pagingNo = i,
                    pagingName = i.ToString(),
                    active = active,
                    activeCss = cssActive,
                    disabledCss = disableCss,
                    keyword = keyword
                };
                pagingItemList.Add(paingItem);
            }
            var visible = pagingItemList.Count > 1;
            var totalItemIndex = pageIndex < totalPage ? pageIndex * pageSize : ((pageIndex - 1) * pageSize) + (int.Parse(totalItem.ToString()) - ((pageIndex - 1) * pageSize));
            if (visible)
            {
                var paging = new PagesDTOs
                {
                    start = pagingStart,
                    end = pagingend,
                    preview = pagingPreview,
                    next = pagingNext,
                    keyword = keyword,
                    totalItemIndex = totalItemIndex,
                    pagingItemList = pagingItemList,
                    visible = visible
                };
                return paging;
            }
            return default;
        }
    }

}
