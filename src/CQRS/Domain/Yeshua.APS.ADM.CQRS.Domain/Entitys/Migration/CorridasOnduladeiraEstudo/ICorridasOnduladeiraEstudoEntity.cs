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
                    public interface ICorridasOnduladeiraEstudoEntity
{
    int? Id { get; set; }
    string BOL_ID { get; set; }
    string BOL_ID_ORIGEM { get; set; }
    Decimal? PRO_LARGURA_PECA { get; set; }
    Decimal? PRO_LARGURA_PECA_PROGRAMADO { get; set; }
    Decimal? PRO_COMPRIMENTO_PECA { get; set; }
    Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO { get; set; }
    Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO { get; set; }
    string PRO_VINCOS_RECALCULADOS { get; set; }
    string COR_SOLVER { get; set; }
    Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
    Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
    Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
    Decimal? COR_CUSTO_RESINA_PROGRAMADOS { get; set; }
    Decimal? COR_TOLERANCIA_MENOS { get; set; }
    Decimal? COR_TOLERANCIA_MAIS { get; set; }
    int? COR_PILHAS_POR_PALETE { get; set; }
    Decimal? COR_M_LINEAR_REALIZADO { get; set; }
    string PRO_ID_PALETE { get; set; }
    string COR_STATUS_PALETE { get; set; }
    Decimal? COR_GRUPO_PRODUTIVO { get; set; }
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