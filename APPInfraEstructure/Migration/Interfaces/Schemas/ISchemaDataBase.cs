using Dominio;
using Dominio.Migration;
using Shered.DB;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Schemas
{
    public interface ISchemaDataBase : ISchema
    {
        public IUnitOfWork _unitOfWork { set; get; }
        List<MigrationQuery> ApplyMigration(Dominio.Migration.MigrationBase migration);
        MigrationQuery CreateTable(Entity entity);
        MigrationQuery AlterColumn(IEnumerable<Column> columns);

    }
}
