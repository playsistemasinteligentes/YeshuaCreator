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
    public partial record CargaDTO
    {
    public int id { get; set; }
    public string car_id { get; set; }
    public DateTime car_previsao_materia_prima { get; set; }
    public DateTime car_data_inicio_previsto { get; set; }
    public DateTime car_data_inicio_realizado { get; set; }
    public DateTime car_data_fim_previsto { get; set; }
    public DateTime car_data_fim_realizado { get; set; }
    public DateTime car_inicio_janela_embarque { get; set; }
    public DateTime car_fim_janela_embarque { get; set; }
    public DateTime car_embarque_alvo { get; set; }
    public Decimal car_status { get; set; }
    public Decimal car_peso_teorico { get; set; }
    public Decimal car_volume_teorico { get; set; }
    public Decimal car_peso_real { get; set; }
    public Decimal car_volume_real { get; set; }
    public Decimal car_peso_embalagem { get; set; }
    public Decimal car_peso_entrada { get; set; }
    public Decimal car_peso_saida { get; set; }
    public string car_id_doca { get; set; }
    public string vei_placa { get; set; }
    public int tip_id { get; set; }
    public string tra_id { get; set; }
    public Decimal car_grupo_produtivo { get; set; }
    public string rot_id { get; set; }
    public string car_observacao_de_transporte { get; set; }
    public string car_justificativa_de_carregamento { get; set; }
    public string oco_id { get; set; }
    public string car_id_juntada { get; set; }
    public string car_observacao_otimizador { get; set; }
    public string car_id_integracao_balanca { get; set; }
    public string car_pesagem_liberada { get; set; }
    public string car_obs_lieracao { get; set; }
    public string oco_id_lieracao { get; set; }
    public DateTime car_data_entrada_veiculo { get; set; }
    public DateTime car_data_saida_veiculo { get; set; }
    public DateTime car_data_romaneio_consolidado { get; set; }
    public string car_dia_turma_romaneio_consolidado { get; set; }
    public Decimal car_diferenca_pesagem { get; set; }
    public DateTime car_data_agenciamento { get; set; }
    public string turn_id { get; set; }
    public string turm_id { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration