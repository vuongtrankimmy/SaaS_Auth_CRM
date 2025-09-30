namespace Shared.Helpers.Helper.RecursiveTree
{
    public static class RecursiveTreeHelper
    {
        //public static async Task<List<navigation_treeModel>> ToMenusBindTree(this List<navigationModel> navigations, navigationModel parentNode)
        //{
        //    var treeList = new List<navigation_treeModel>();
        //    if (navigations != null)
        //    {
        //        var navigationList = navigations.Where(x => parentNode == null ? x.parentID == 0 : x.navigationID == parentNode.navigationID);
        //        foreach (var navigation in navigationList)
        //        {
        //            var hasSub = navigations.Where(x => x.parentID.Equals(navigation.navigationID)).Any() ? "has-sub" : "";
        //            var toggle = hasSub != "" ? "nk-menu-toggle" : "";
        //            var tree = new navigation_treeModel  
        //            {
        //                ID = navigation.navigationID,
        //                name = navigation.name,
        //                handle = navigation.handle,
        //                isAllow = navigation.isAllow,
        //                parentID = navigation.parentId?? 0,
        //                has_sub = hasSub,
        //                toggle = toggle,
        //                iconUrl = navigation.url,
        //            };
        //            switch (parentNode)
        //            {
        //                case null:
        //                    treeList.Add(tree);
        //                    break;
        //                default:
        //                    parentNode.sub.Add(tree);
        //                    break;
        //            }
        //            await navigations.ToMenusBindTree(tree);
        //        }
        //    }
        //    return treeList;
        //}

        //public static async Task<List<navigation_treeModel>> ToBindTree(this List<navigationModel> navigations, navigation_treeModel parentNode)
        //{
        //    var treeList = new List<navigation_treeModel>();
        //    if (navigations != null)
        //    {
        //        var navigationList = navigations.Where(x => parentNode == null ? x.parentID == 0 : x.parentID == (parentNode?.ID ?? 0));
        //        foreach (var navigation in navigationList)
        //        {
        //            var hasSub = navigations.Where(x => x.parentID.Equals(navigation.navigationID)).Any() ? "has-sub" : "";
        //            var toggle = hasSub != "" ? "nk-menu-toggle" : "";
        //            var isAllow = navigation?.isAllow?? false;
        //            var tree = new navigation_treeModel
        //            {
        //                navigationId = navigation?.navigationId,
        //                title = navigation?.name ?? "",
        //                handle = navigation?.handle ?? "",
        //                isAllow = isAllow,
        //                parentId = navigation?.parentId ?? 0,
        //                hasSub = hasSub,
        //                toggle = toggle,
        //                iconUrl = navigation?.iconUrl ?? ""
        //            };
        //            switch (parentNode)
        //            {
        //                case null:
        //                    treeList.Add(tree);
        //                    break;
        //                default:
        //                    parentNode?.sub?.Add(tree);
        //                    break;
        //            }
        //            await navigations.ToBindTree(tree);
        //        }
        //    }
        //    return treeList;
        //}
    }
}
