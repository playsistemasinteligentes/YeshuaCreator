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
    public partial record MDFeSolicitacaoFiscalDTO
    {
    public int id { get; set; }
    public string correlationid { get; set; }
    public string cargaid { get; set; }
    public int ambiente { get; set; }
    public string ufcarregamento { get; set; }
    public string ufdescarregamento { get; set; }
    public string placaveiculo { get; set; }
    public string condutordocumento { get; set; }
    public string documentosoriginariosjson { get; set; }
    public string transportesnapshotjson { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration