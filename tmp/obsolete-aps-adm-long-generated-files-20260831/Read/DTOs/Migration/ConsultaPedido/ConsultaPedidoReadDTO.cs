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
    public string pedidoid { get; set; }
    public string clienteid { get; set; }
    public string clientenome { get; set; }
    public string razaosocial { get; set; }
    public string produtoid { get; set; }
    public string produtodescricao { get; set; }
    public string status { get; set; }
    public string estagio { get; set; }
    public DateTime dataentregade { get; set; }
    public DateTime dataentregaate { get; set; }
    public DateTime embarquealvo { get; set; }
    public Decimal quantidade { get; set; }
    public Decimal saldoaproduzir { get; set; }
    public Decimal saldoaexpedir { get; set; }
    public string corfila { get; set; }
    public string pedidocliente { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration