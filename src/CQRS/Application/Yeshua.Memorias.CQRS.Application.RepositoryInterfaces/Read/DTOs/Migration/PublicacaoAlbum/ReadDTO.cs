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
    public partial record PublicacaoAlbumDTO
    {
    public int id { get; set; }
    public int albumid { get; set; }
    public string correlationid { get; set; } = string.Empty;
    public string manifeststoragekey { get; set; } = string.Empty;
    public string videostoragekey { get; set; } = string.Empty;
    public string youtubevideoid { get; set; } = string.Empty;
    public string youtubeurl { get; set; } = string.Empty;
    public string mensagem { get; set; } = string.Empty;
    public DateTime solicitadaemutc { get; set; }
    public DateTime publicadaemutc { get; set; }
    public int status { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration