using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record SesoesStandardDTO
    {
    public Nullable<int> id { get; set; }
    public DateTime datainicio { get; set; }
    public string nome { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration