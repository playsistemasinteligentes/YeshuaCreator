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
    public string pedidoid { get; set; }
    public string clienteid { get; set; }
    public string clientenome { get; set; }
    public string estado { get; set; }
    public string municipio { get; set; }
    public string regiao { get; set; }
    public string bairro { get; set; }
    public string rotaid { get; set; }
    public DateTime embarquealvo { get; set; }
    public DateTime dataentregade { get; set; }
    public DateTime dataentregaate { get; set; }
    public Decimal peso { get; set; }
    public Decimal volume { get; set; }
    public Decimal saldoaexpedir { get; set; }
    public string status { get; set; }
    public string cargaatualid { get; set; }
    public string versaoplanejamento { get; set; }
    public string alertasresumo { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration