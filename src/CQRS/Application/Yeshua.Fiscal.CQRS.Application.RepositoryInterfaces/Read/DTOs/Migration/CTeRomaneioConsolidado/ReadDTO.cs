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
    public string correlationid { get; set; }
    public string romaneioid { get; set; }
    public string cargaid { get; set; }
    public DateTime consolidadoemutc { get; set; }
    public string ufinicio { get; set; }
    public string uffim { get; set; }
    public string municipioiniciocodigoibge { get; set; }
    public string municipiofimcodigoibge { get; set; }
    public string emitentedocumento { get; set; }
    public string tomadordocumento { get; set; }
    public string rotasnapshotjson { get; set; }
    public string cargasnapshotjson { get; set; }
    public string preferenciasfiscaisjson { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration