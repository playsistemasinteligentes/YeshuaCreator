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
                    public interface IClpMedicoesHEntity
{
    int ID { get; set; }
    string MAQUINA_ID { get; set; }
    DateTime DATA_INI { get; set; }
    DateTime DATA_FIM { get; set; }
    DateTime? CLP_EMISSAO { get; set; }
    Decimal QTD { get; set; }
    Decimal? GRUPO { get; set; }
    int? STATUS { get; set; }
    string URN_ID { get; set; }
    string URM_ID { get; set; }
    int ID_LOTE_CLP { get; set; }
    string OCO_ID { get; set; }
    int? FASE { get; set; }
    string CLP_ORIGEM { get; set; }
    int? CLP_LOTE { get; set; }
    int? COMPACTA { get; set; }
    string BOL_ID { get; set; }
    int? COR_SEQUENCIA { get; set; }
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