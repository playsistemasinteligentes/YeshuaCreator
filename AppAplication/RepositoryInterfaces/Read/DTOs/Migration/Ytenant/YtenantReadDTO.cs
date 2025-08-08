using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record yTenantDTO
    {
    public int id { get; set; }
    public int cnpjcpf { get; set; }
    public string nome { get; set; }
    public int userid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration