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
    public partial record CertificadoDigitalDTO
    {
    public int id { get; set; }
    public string apelido { get; set; } = string.Empty;
    public string documentotitular { get; set; } = string.Empty;
    public string storagekey { get; set; } = string.Empty;
    public string thumbprint { get; set; } = string.Empty;
    public DateTime validode { get; set; }
    public DateTime validoate { get; set; }
    public int ativo { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration