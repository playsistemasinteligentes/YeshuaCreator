using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Schemas
{
    public interface ISchemaCodeGeneration : ISchema
    {
        string _solutionDirectory { get; set; }
        void CodeGenaration(Dominio.Migration.MigrationBase migration);

    }
}
