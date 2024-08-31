using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Migration
{
    public class MigrationQuery : QueryBase
    {
        public MigrationQuery(string query, object parameters)
        {
            Query = query;
            Parameters = parameters;
        }
    }
}
