using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Y_Tenant_Configuration
{
    public struct Y_Tenant_ConfigurationDTO
    {
    public int id { get; set; }
    public int audittrackeractived { get; set; }
    public int auditcrudactived { get; set; }
    public int tenantid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration