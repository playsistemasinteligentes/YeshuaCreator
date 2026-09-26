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
    public partial record RotaPontosMapaDTO
    {
    public int id { get; set; }
    public string rot_id { get; set; } = string.Empty;
    public string pon_id_destino { get; set; } = string.Empty;
    public string pon_id_origem { get; set; } = string.Empty;
    public Decimal rot_custo_total { get; set; }
    public string pon_id_roteiro { get; set; } = string.Empty;
    public int rot_ordem_roteiro { get; set; }
    public string rot_tipo { get; set; } = string.Empty;
    public Decimal rot_distancia { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration