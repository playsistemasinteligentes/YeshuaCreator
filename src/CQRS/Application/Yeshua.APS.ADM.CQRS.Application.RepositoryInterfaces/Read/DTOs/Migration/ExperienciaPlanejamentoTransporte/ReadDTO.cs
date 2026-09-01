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
    public string referencia { get; set; }
    public string pedidoid { get; set; }
    public string clienteid { get; set; }
    public string municipio { get; set; }
    public string regiao { get; set; }
    public string rotaid { get; set; }
    public Decimal peso { get; set; }
    public Decimal volume { get; set; }
    public string observacao { get; set; }
    public DateTime criadoem { get; set; }
    public string criadopor { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration