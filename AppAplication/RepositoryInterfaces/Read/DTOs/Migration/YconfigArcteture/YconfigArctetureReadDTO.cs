using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record YconfigArctetureDTO
    {
    public int id { get; set; }
    public int audittrackeractived { get; set; }
    public int auditcrudactived { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration