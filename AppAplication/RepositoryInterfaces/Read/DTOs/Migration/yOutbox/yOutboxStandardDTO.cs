using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record yOutboxStandardDTO
    {
    public Nullable<int> id { get; set; }//01
    public string type { get; set; }//01
    public string payload { get; set; }//01
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration