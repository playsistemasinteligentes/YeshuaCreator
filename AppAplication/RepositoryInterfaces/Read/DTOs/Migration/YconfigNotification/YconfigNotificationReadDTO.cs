using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record yConfigNotificationDTO
    {
    public int id { get; set; }
    public int tenantid { get; set; }
    public string emailsmtpclient { get; set; }
    public int emailport { get; set; }
    public string emailusername { get; set; }
    public string emailpassword { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration