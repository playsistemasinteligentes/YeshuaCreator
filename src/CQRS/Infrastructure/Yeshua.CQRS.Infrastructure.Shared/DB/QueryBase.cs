using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.DB
{
    public abstract class QueryBase
    {
        public string Query { get; set; } = string.Empty;
        public object Parameters { get; set; } = new object();
    }
}
