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
    public partial record RoteiroDTO
    {
    public string maq_id { get; set; }
    public string pro_id { get; set; }
    public int rot_seq_tranformacao { get; set; }
    public string gma_id { get; set; }
    public Decimal rot_pecas_por_pulso { get; set; }
    public Decimal rot_prioridade_informada { get; set; }
    public string rot_acao { get; set; }
    public Decimal rot_performance { get; set; }
    public Decimal rot_tempo_setup { get; set; }
    public Decimal rot_tempo_setup_ajuste { get; set; }
    public int rot_va_para_seq_transformacao { get; set; }
    public string rot_status { get; set; }
    public Decimal rot_hierarquia_seq_transformacao { get; set; }
    public int rot_avalia_custo { get; set; }
    public string rot_operacoes { get; set; }
    public string rot_excecao_operacoes { get; set; }
    public Decimal rot_percentual_inicio_passo_anterior { get; set; }
    public string rot_linha_direta { get; set; }
    public int tem_id { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration