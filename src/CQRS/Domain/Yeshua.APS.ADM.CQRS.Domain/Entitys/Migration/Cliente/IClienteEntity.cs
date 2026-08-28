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
                    public interface IClienteEntity
{
    string CLI_ID { get; set; }
    string CLI_NOME { get; set; }
    string CLI_FONE { get; set; }
    string CLI_OBS { get; set; }
    string CLI_ENDERECO_ENTREGA { get; set; }
    string CLI_CPF_CNPJ { get; set; }
    string CLI_BAIRRO_ENTREGA { get; set; }
    string CLI_CEP_ENTREGA { get; set; }
    string CLI_EMAIL { get; set; }
    string CLI_INTEGRACAO { get; set; }
    string MUN_ID_ENTREGA { get; set; }
    Decimal? CLI_TRANSLADO { get; set; }
    string CLI_REGIAO_ENTREGA { get; set; }
    int? CLI_EXIGENTE_NA_IMPRESSAO { get; set; }
    Decimal? CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO { get; set; }
    Decimal? CLI_TEMPO_DESCARREGAMENTO_UNITARIO { get; set; }
    Decimal? CLI_PERCENTUAL_JANELA_EMBARQUE { get; set; }
    string REP_ID { get; set; }
    string CLI_RAZAO_SOCIAL { get; set; }
    string CLI_EMAIL_MONITORAMENTO_TRANSPORTE { get; set; }
    string CLI_CONTATO { get; set; }
    string CLI_SETOR { get; set; }
    string SEG_ID { get; set; }
    string CLI_TIPO { get; set; }
    string CLI_INTEGRACAO_ERP { get; set; }
    Decimal? CLI_LATITUDE_ENTREGA { get; set; }
    Decimal? CLI_LONGITUDE_ENTREGA { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration