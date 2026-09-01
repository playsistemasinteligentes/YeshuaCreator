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
    public partial record OrderTrackDTO
    {
    public int id { get; set; }
    public int otk_id { get; set; }
    public Decimal otk_sequencia { get; set; }
    public int otk_verssao { get; set; }
    public string ord_id { get; set; }
    public string otk_evento { get; set; }
    public DateTime otk_data_necessidade_de { get; set; }
    public DateTime otk_data_necessidade_ate { get; set; }
    public DateTime otk_data_prevista { get; set; }
    public DateTime otk_data_realizada { get; set; }
    public int fpr_id { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration