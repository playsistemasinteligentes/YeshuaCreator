using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Patterns.Repository
{
    public class DataPagination<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? TotalItems { get; set; }



        public int? TotalPages =>
            TotalItems.HasValue && PageSize > 0
                ? (int)Math.Ceiling((double)TotalItems.Value / PageSize)
                : null;

        public DataPagination() { }

        public DataPagination(IEnumerable<T> items, int page, int pageSize, int? totalItems = null)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
    }
}
