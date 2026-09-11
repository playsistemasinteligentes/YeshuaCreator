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
                    public interface IVeiculoEntity
{
    int? Id { get; set; }
    string VEI_PLACA { get; set; }
    string VEI_UF { get; set; }
    int TIP_ID { get; set; }
    Decimal? VEI_CAPACIDADE_M3 { get; set; }
    Decimal? VEI_CAPACIDADE_LARGURA { get; set; }
    Decimal? VEI_CAPACIDADE_COMPRIMENTO { get; set; }
    Decimal? VEI_CAPACIDADE_ALTURA { get; set; }
    string VEI_MODELO { get; set; }
    string VEI_NOME_MOTORISTA { get; set; }
    string VEI_DADOS_CONTATO { get; set; }
    string VEI_CPF_MOTORISTA { get; set; }
    string TCA_ID { get; set; }
    DateTime? VEI_EMISSAO { get; set; }
    DateTime? VEI_VENCIMENTO { get; set; }
    string VEI_STATUS { get; set; }
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