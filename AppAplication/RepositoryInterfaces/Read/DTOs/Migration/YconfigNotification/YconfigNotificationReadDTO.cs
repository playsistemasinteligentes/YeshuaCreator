using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record YconfigNotificationDTO
    {
    public int id { get; set; }
    public string emailadress { get; set; }
    public string emailpassword { get; set; }
    public int tenantid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration