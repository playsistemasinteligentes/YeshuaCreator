using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Pateners.Command
{
    public class Pagination
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool PageWhithCount { get; set; }

        public Pagination() { }

        public Pagination(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
