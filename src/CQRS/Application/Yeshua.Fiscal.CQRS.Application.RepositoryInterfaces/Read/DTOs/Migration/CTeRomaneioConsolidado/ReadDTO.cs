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
    public partial record CTeRomaneioConsolidadoDTO
    {
    public int id { get; set; }
    public int entradaoficialid { get; set; }
    public string correlationid { get; set; } = string.Empty;
    public string romaneioid { get; set; } = string.Empty;
    public string cargaid { get; set; } = string.Empty;
    public DateTime consolidadoemutc { get; set; }
    public string ufinicio { get; set; } = string.Empty;
    public string uffim { get; set; } = string.Empty;
    public string municipioiniciocodigoibge { get; set; } = string.Empty;
    public string municipiofimcodigoibge { get; set; } = string.Empty;
    public string emitentedocumento { get; set; } = string.Empty;
    public string tomadordocumento { get; set; } = string.Empty;
    public string rotasnapshotjson { get; set; } = string.Empty;
    public string cargasnapshotjson { get; set; } = string.Empty;
    public string preferenciasfiscaisjson { get; set; } = string.Empty;
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration