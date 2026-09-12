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
    public partial record NFeProdutoSnapshotDTO
    {
    public int id { get; set; }
    public int documentofiscaloriginarioid { get; set; }
    public string correlationid { get; set; } = string.Empty;
    public string cargaid { get; set; } = string.Empty;
    public string pedidoid { get; set; } = string.Empty;
    public string chaveacesso { get; set; } = string.Empty;
    public string emitentedocumento { get; set; } = string.Empty;
    public string destinatariodocumento { get; set; } = string.Empty;
    public string uforigem { get; set; } = string.Empty;
    public string ufdestino { get; set; } = string.Empty;
    public string municipioorigemcodigoibge { get; set; } = string.Empty;
    public string municipiodestinocodigoibge { get; set; } = string.Empty;
    public Decimal valordocumento { get; set; }
    public Decimal pesobruto { get; set; }
    public Decimal volume { get; set; }
    public string xmlstoragekey { get; set; } = string.Empty;
    public string snapshotjson { get; set; } = string.Empty;
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration