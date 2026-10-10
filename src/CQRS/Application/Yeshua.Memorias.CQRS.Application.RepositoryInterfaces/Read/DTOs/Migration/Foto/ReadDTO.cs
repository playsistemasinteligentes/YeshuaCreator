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
    public partial record FotoDTO
    {
    public int id { get; set; }
    public string storagekey { get; set; } = string.Empty;
    public string nomeoriginal { get; set; } = string.Empty;
    public string contenttype { get; set; } = string.Empty;
    public string hasharquivo { get; set; } = string.Empty;
    public DateTime capturadaemutc { get; set; }
    public int largura { get; set; }
    public int altura { get; set; }
    public int status { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration