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
    public partial record CenarioPlanejamentoTransporteDTO
    {
    public string cenarioid { get; set; }
    public string descricao { get; set; }
    public string objetivo { get; set; }
    public int quantidadecargas { get; set; }
    public int quantidadepedidosnaoatendidos { get; set; }
    public Decimal custototal { get; set; }
    public Decimal aderenciacubagem { get; set; }
    public Decimal atrasoprevisto { get; set; }
    public string alertasresumo { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration