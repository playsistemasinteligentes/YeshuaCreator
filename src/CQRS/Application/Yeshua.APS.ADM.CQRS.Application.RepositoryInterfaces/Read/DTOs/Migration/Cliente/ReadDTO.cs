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
    public partial record ClienteDTO
    {
    public string cli_id { get; set; }
    public string cli_nome { get; set; }
    public string cli_fone { get; set; }
    public string cli_obs { get; set; }
    public string cli_endereco_entrega { get; set; }
    public string cli_cpf_cnpj { get; set; }
    public string cli_bairro_entrega { get; set; }
    public string cli_cep_entrega { get; set; }
    public string cli_email { get; set; }
    public string cli_integracao { get; set; }
    public string mun_id_entrega { get; set; }
    public Decimal cli_translado { get; set; }
    public string cli_regiao_entrega { get; set; }
    public int cli_exigente_na_impressao { get; set; }
    public Decimal cli_tempo_medio_espera_de_descarregamento { get; set; }
    public Decimal cli_tempo_descarregamento_unitario { get; set; }
    public Decimal cli_percentual_janela_embarque { get; set; }
    public string rep_id { get; set; }
    public string cli_razao_social { get; set; }
    public string cli_email_monitoramento_transporte { get; set; }
    public string cli_contato { get; set; }
    public string cli_setor { get; set; }
    public string seg_id { get; set; }
    public string cli_tipo { get; set; }
    public string cli_integracao_erp { get; set; }
    public Decimal cli_latitude_entrega { get; set; }
    public Decimal cli_longitude_entrega { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration