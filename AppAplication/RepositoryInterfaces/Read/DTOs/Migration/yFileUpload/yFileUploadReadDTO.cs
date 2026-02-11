using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record yFileUploadDTO
    {
    public int id { get; set; }
    public string idempotencykey { get; set; }
    public string type { get; set; }
    public int status { get; set; }
    public string filepath { get; set; }
    public int filesize { get; set; }
    public string contenttype { get; set; }
    public DateTime createdat { get; set; }
    public DateTime completedat { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration