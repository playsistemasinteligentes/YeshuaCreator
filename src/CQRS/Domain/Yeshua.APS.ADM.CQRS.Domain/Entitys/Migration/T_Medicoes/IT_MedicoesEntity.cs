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
                    public interface IT_MedicoesEntity
{
    int? Id { get; set; }
    int MED_ID { get; set; }
    int? IND_ID { get; set; }
    int? MET_ID { get; set; }
    int? UNI_ID { get; set; }
    DateTime MED_DATA { get; set; }
    string MED_VALOR { get; set; }
    string MED_AC_ANO { get; set; }
    string MED_DATAMEDICAO { get; set; }
    Decimal? MED_PONDERACAO { get; set; }
    string DIM_ID { get; set; }
    string DIM_DESCRICAO { get; set; }
    string DIM_SUBDIMENSAO_ID { get; set; }
    string DIM_SUB_DESCRICAO { get; set; }
    string PER_ID { get; set; }
    string PER_DESCRICAO { get; set; }
    string FAT_ID { get; set; }
    string FAT_DESCRICAO { get; set; }
    string MED_SQL { get; set; }
    string DOM_EMPRESA { get; set; }
    string DOM_FILIAL { get; set; }
    string MED_VALOR_DISPER { get; set; }
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