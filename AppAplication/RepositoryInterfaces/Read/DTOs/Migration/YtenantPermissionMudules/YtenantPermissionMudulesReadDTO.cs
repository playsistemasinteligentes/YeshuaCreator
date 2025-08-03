using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record YtenantPermissionMudulesDTO
    {
    public int id { get; set; }
    public string permissionmodulesid { get; set; }
    public int tenantid { get; set; }
    public DateTime validuntil { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration