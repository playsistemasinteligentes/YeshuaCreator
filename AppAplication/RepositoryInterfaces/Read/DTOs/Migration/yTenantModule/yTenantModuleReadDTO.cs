using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record yTenantModuleDTO
    {
    public int id { get; set; }
    public string moduleid { get; set; }
    public int tenantid { get; set; }
    public DateTime validuntil { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration