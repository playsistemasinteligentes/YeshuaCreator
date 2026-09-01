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
    public partial record LaudoTesteFisicoDTO
    {
    public int id { get; set; }
    public int ltf_id { get; set; }
    public DateTime ltf_emissao { get; set; }
    public Decimal ltf_valor { get; set; }
    public string ltf_obs { get; set; }
    public string ltf_status { get; set; }
    public string ord_id { get; set; }
    public string rot_pro_id { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public int use_id { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration