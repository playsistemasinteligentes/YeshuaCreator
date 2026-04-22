using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record yTenantDTO
    {
    public int id { get; set; }
    public string cnpjcpf { get; set; }
    public string nome { get; set; }
    public int userid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration