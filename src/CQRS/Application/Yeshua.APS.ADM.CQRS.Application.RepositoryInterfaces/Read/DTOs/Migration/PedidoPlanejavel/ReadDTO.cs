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
    public partial record PedidoPlanejavelDTO
    {
    public string pedidoid { get; set; } = string.Empty;
    public string clienteid { get; set; } = string.Empty;
    public string clientenome { get; set; } = string.Empty;
    public string estado { get; set; } = string.Empty;
    public string municipio { get; set; } = string.Empty;
    public string regiao { get; set; } = string.Empty;
    public string bairro { get; set; } = string.Empty;
    public string rotaid { get; set; } = string.Empty;
    public DateTime embarquealvo { get; set; }
    public DateTime dataentregade { get; set; }
    public DateTime dataentregaate { get; set; }
    public Decimal peso { get; set; }
    public Decimal volume { get; set; }
    public Decimal saldoaexpedir { get; set; }
    public string status { get; set; } = string.Empty;
    public string cargaatualid { get; set; } = string.Empty;
    public string versaoplanejamento { get; set; } = string.Empty;
    public string alertasresumo { get; set; } = string.Empty;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration