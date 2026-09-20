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
    public partial record ExperienciaPlanejamentoTransporteDTO
    {
    public int id { get; set; }
    public int tipo { get; set; }
    public string referencia { get; set; } = string.Empty;
    public string pedidoid { get; set; } = string.Empty;
    public string clienteid { get; set; } = string.Empty;
    public string municipio { get; set; } = string.Empty;
    public string regiao { get; set; } = string.Empty;
    public string rotaid { get; set; } = string.Empty;
    public Decimal peso { get; set; }
    public Decimal volume { get; set; }
    public string observacao { get; set; } = string.Empty;
    public DateTime criadoem { get; set; }
    public string criadopor { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration