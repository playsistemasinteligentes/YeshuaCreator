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
    public partial record InspecaoVisualDTO
    {
    public int ipv_id { get; set; }
    public string ipv_valor { get; set; }
    public int ipv_id_operador { get; set; }
    public int ipv_id_liberacao { get; set; }
    public string ipv_obs { get; set; }
    public DateTime ipv_data_coleta { get; set; }
    public DateTime ipv_data_aval { get; set; }
    public int tiv_id { get; set; }
    public string turn_id { get; set; }
    public string turm_id { get; set; }
    public string ord_id { get; set; }
    public string rot_pro_id { get; set; }
    public string rot_maq_id { get; set; }
    public int rot_seq_transformacao { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public string ipv_status_liberacao { get; set; }
    public Decimal ipv_valor_medida { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration