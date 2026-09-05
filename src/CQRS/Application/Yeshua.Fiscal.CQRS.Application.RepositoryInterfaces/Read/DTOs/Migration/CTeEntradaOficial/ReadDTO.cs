// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration
// </yeshua>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record CTeEntradaOficialDTO
    {
    public int id { get; set; }
    public string correlationid { get; set; }
    public string sourceapplication { get; set; }
    public string sourcemodule { get; set; }
    public string sourcemessageid { get; set; }
    public string messagetype { get; set; }
    public string messageversion { get; set; }
    public DateTime receivedatutc { get; set; }
    public string payloadhash { get; set; }
    public string payloadstoragekey { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration