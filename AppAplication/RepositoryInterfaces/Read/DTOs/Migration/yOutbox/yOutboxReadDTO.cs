using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record yOutboxDTO
    {
    public int id { get; set; }
    public string messageid { get; set; }
    public string type { get; set; }
    public string entitytype { get; set; }
    public string entityid { get; set; }
    public string correlationid { get; set; }
    public string payload { get; set; }
    public int status { get; set; }
    public int transporttype { get; set; }
    public string transportdata { get; set; }
    public DateTime createdat { get; set; }
    public DateTime sentat { get; set; }
    public int retrycount { get; set; }
    public string lasterror { get; set; }
    public DateTime processingat { get; set; }
    public DateTime nextattemptat { get; set; }
    public int sagaid { get; set; }
    public int sagastepid { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration