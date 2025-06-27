using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Y_Tenant
{
    public struct Y_TenantDTO
    {
    public int id { get; set; }
    public string nome { get; set; }
    public string proxyserver { get; set; }
    public int useridadmin { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration