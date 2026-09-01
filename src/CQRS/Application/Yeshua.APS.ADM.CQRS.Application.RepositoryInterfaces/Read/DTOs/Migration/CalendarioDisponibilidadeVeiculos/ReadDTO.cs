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
    public partial record CalendarioDisponibilidadeVeiculosDTO
    {
    public int id { get; set; }
    public int cdv_id { get; set; }
    public DateTime cdv_data_de { get; set; }
    public DateTime cdv_data_ate { get; set; }
    public int cdv_segunda { get; set; }
    public int cdv_terca { get; set; }
    public int cdv_quarta { get; set; }
    public int cdv_quinta { get; set; }
    public int cdv_sexta { get; set; }
    public int cdv_sabado { get; set; }
    public int cdv_domingo { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration