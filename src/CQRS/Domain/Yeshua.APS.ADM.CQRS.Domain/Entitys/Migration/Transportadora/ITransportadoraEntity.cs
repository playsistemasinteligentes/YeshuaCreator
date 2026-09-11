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
                    public interface ITransportadoraEntity
{
    int? Id { get; set; }
    string TRA_ID { get; set; }
    string TRA_NOME { get; set; }
    string TRA_CNPJ { get; set; }
    string TRA_INSCRICAO_ESTADUAL { get; set; }
    string TRA_RNTRC { get; set; }
    string TRA_EMAIL { get; set; }
    string TRA_RESPONSAVEL { get; set; }
    string TRA_FONE { get; set; }
    string TRA_ID_INTEGRACAO { get; set; }
    string TRA_ID_INTEGRACAO_ERP { get; set; }
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