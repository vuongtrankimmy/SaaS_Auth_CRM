namespace Entities.Inherits.Filters
{
    public class FilterDTOs
    {
        public string search { get; set; }
        public List<FilterGroup> filterGroup { get; set; }
        public List<Sort> sort { get; set; }
    }

    public class FilterGroup
    {
        /// <summary>
        /// 1: and &, 2: or |
        /// </summary>
        public int? conditional { get; set; } = 1;
        public List<Filter> filterList { get; set; }
    }

    public class Filter
    {
        public string searchKey { get; set; }
        /// <summary>
        /// Điều kiện Filter
        /// <see cref=""/>
        /// 1: equals, 2: doesn't equal, 3: contains, 4: doesn't contain, 5: starts with
        /// 6: doesn't start with, 7: ends with, 8: does not end with
        /// 9: is null, 10: isn't null, 11: exists, 12: doesn't exist
        /// 13: in, 14: not in, 15: array contains all
        /// 16: >, 17: >=, 18: <, 19: <=, 20: <=...<=
        /// 21: <...<=, 22: <=...<, 23: >, 24: >=,
        /// 25: <, 26: <=, 27: <=...<=, 28: <...<=,
        /// 29: <=...<, 30: <...<,
        /// 31: has type, 32: doesn't have type,
        /// 33: text index search.
        /// </see>
        /// </summary>
        public int? searchQueryType { get; set; }
        /// <summary>
        /// 1: string, 2: int, 3: decimal, 4: iso date,
        /// 5: string array, 6: int array, 7: object, 8: date array
        /// </summary>
        public int? valueType { get; set; }
        public string value { get; set; }
        public int conditional { get; set; }
    }

    public class Sort
    {
        public string sortKey { get; set; }
        public int? sortMode { get; set; }
    }

    public class FilterArray
    {
        public string value { get; set; }
    }
}
