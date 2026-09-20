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
    public partial record CargaPlanejavelDTO
    {
    public string cargaid { get; set; } = string.Empty;
    public string status { get; set; } = string.Empty;
    public string transportadoraid { get; set; } = string.Empty;
    public string veiculoid { get; set; } = string.Empty;
    public int tipoveiculoid { get; set; }
    public Decimal pesoteorico { get; set; }
    public Decimal volumeteorico { get; set; }
    public DateTime iniciojanelaembarque { get; set; }
    public DateTime fimjanelaembarque { get; set; }
    public DateTime embarquealvo { get; set; }
    public int quantidadepedidos { get; set; }
    public string alertasresumo { get; set; } = string.Empty;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration