using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Schemas
{
    public interface IDriveDB
    {
        public IEnumerable<Entity> GetTables();
        public IEnumerable<Column> GetColumns(string name);

    }
}
