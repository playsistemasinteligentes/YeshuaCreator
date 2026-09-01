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
    public partial record OpcaoPlanejamentoTransporteDTO
    {
    public string opcaoid { get; set; }
    public string grupodecisaoid { get; set; }
    public Decimal peso { get; set; }
    public Decimal volume { get; set; }
    public Decimal custoestimado { get; set; }
    public Decimal aderenciacubagem { get; set; }
    public Decimal aderenciajanelaentrega { get; set; }
    public string riscoresumo { get; set; }
    public string pedidosresumo { get; set; }
    public string opcoesconflitantesresumo { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration