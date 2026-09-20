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
    public partial record ConsultaPedidoDTO
    {
    public string pedidoid { get; set; } = string.Empty;
    public string clienteid { get; set; } = string.Empty;
    public string clientenome { get; set; } = string.Empty;
    public string razaosocial { get; set; } = string.Empty;
    public string produtoid { get; set; } = string.Empty;
    public string produtodescricao { get; set; } = string.Empty;
    public string status { get; set; } = string.Empty;
    public string estagio { get; set; } = string.Empty;
    public DateTime dataentregade { get; set; }
    public DateTime dataentregaate { get; set; }
    public DateTime embarquealvo { get; set; }
    public Decimal quantidade { get; set; }
    public Decimal saldoaproduzir { get; set; }
    public Decimal saldoaexpedir { get; set; }
    public string corfila { get; set; } = string.Empty;
    public string pedidocliente { get; set; } = string.Empty;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration