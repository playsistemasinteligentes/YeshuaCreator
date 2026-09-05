// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ClienteEntity : IClienteEntity
{
    public string CLI_ID { get; set; }
    public string CLI_NOME { get; set; }
    public string CLI_FONE { get; set; }
    public string CLI_OBS { get; set; }
    public string CLI_ENDERECO_ENTREGA { get; set; }
    public string CLI_CPF_CNPJ { get; set; }
    public string CLI_BAIRRO_ENTREGA { get; set; }
    public string CLI_CEP_ENTREGA { get; set; }
    public string CLI_EMAIL { get; set; }
    public string CLI_INTEGRACAO { get; set; }
    public string MUN_ID_ENTREGA { get; set; }
    public Decimal? CLI_TRANSLADO { get; set; }
    public string CLI_REGIAO_ENTREGA { get; set; }
    public int? CLI_EXIGENTE_NA_IMPRESSAO { get; set; }
    public Decimal? CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO { get; set; }
    public Decimal? CLI_TEMPO_DESCARREGAMENTO_UNITARIO { get; set; }
    public Decimal? CLI_PERCENTUAL_JANELA_EMBARQUE { get; set; }
    public string REP_ID { get; set; }
    public string CLI_RAZAO_SOCIAL { get; set; }
    public string CLI_EMAIL_MONITORAMENTO_TRANSPORTE { get; set; }
    public string CLI_CONTATO { get; set; }
    public string CLI_SETOR { get; set; }
    public string SEG_ID { get; set; }
    public string CLI_TIPO { get; set; }
    public string CLI_INTEGRACAO_ERP { get; set; }
    public Decimal? CLI_LATITUDE_ENTREGA { get; set; }
    public Decimal? CLI_LONGITUDE_ENTREGA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ClienteEntity(string cli_id, string cli_nome, string cli_fone, string cli_obs, string cli_endereco_entrega, string cli_cpf_cnpj, string cli_bairro_entrega, string cli_cep_entrega, string cli_email, string cli_integracao, string mun_id_entrega, Decimal? cli_translado, string cli_regiao_entrega, int? cli_exigente_na_impressao, Decimal? cli_tempo_medio_espera_de_descarregamento, Decimal? cli_tempo_descarregamento_unitario, Decimal? cli_percentual_janela_embarque, string rep_id, string cli_razao_social, string cli_email_monitoramento_transporte, string cli_contato, string cli_setor, string seg_id, string cli_tipo, string cli_integracao_erp, Decimal? cli_latitude_entrega, Decimal? cli_longitude_entrega ){
 CLI_ID = cli_id; 
 CLI_NOME = cli_nome; 
 CLI_FONE = cli_fone; 
 CLI_OBS = cli_obs; 
 CLI_ENDERECO_ENTREGA = cli_endereco_entrega; 
 CLI_CPF_CNPJ = cli_cpf_cnpj; 
 CLI_BAIRRO_ENTREGA = cli_bairro_entrega; 
 CLI_CEP_ENTREGA = cli_cep_entrega; 
 CLI_EMAIL = cli_email; 
 CLI_INTEGRACAO = cli_integracao; 
 MUN_ID_ENTREGA = mun_id_entrega; 
 CLI_TRANSLADO = cli_translado; 
 CLI_REGIAO_ENTREGA = cli_regiao_entrega; 
 CLI_EXIGENTE_NA_IMPRESSAO = cli_exigente_na_impressao; 
 CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO = cli_tempo_medio_espera_de_descarregamento; 
 CLI_TEMPO_DESCARREGAMENTO_UNITARIO = cli_tempo_descarregamento_unitario; 
 CLI_PERCENTUAL_JANELA_EMBARQUE = cli_percentual_janela_embarque; 
 REP_ID = rep_id; 
 CLI_RAZAO_SOCIAL = cli_razao_social; 
 CLI_EMAIL_MONITORAMENTO_TRANSPORTE = cli_email_monitoramento_transporte; 
 CLI_CONTATO = cli_contato; 
 CLI_SETOR = cli_setor; 
 SEG_ID = seg_id; 
 CLI_TIPO = cli_tipo; 
 CLI_INTEGRACAO_ERP = cli_integracao_erp; 
 CLI_LATITUDE_ENTREGA = cli_latitude_entrega; 
 CLI_LONGITUDE_ENTREGA = cli_longitude_entrega; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CLI_ID))
   this._erroMensagem.Add("CLI ID deve ser informado.");
   if(string.IsNullOrEmpty(CLI_NOME))
   this._erroMensagem.Add("CLI NOME deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration