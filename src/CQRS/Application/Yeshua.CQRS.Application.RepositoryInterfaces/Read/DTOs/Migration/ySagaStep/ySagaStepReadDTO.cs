using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record ySagaStepDTO
    {
    public int id { get; set; }
    public int sagaid { get; set; }
    public string stepkey { get; set; }
    public int indexorder { get; set; }
    public string correlationid { get; set; }
    public int status { get; set; }
    public int executioncount { get; set; }
    public DateTime lastexecutionat { get; set; }
    public DateTime completedat { get; set; }
    public string errormessage { get; set; }
    public string payload { get; set; }
    public int retrycount { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration