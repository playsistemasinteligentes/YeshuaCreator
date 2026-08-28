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
                    public interface IBoletimEntity
{
    int? Id { get; set; }
    string BOL_ID { get; set; }
    string BOL_ID_ORIGEM { get; set; }
    string BOL_SOLVER { get; set; }
    string BOL_INTEGRACAO { get; set; }
    Decimal? BOL_SEQUENCIA { get; set; }
    Decimal GRP_PAP_GRAMATURA_PROGRAMADO { get; set; }
    string GRP_ID_PROGRAMADO { get; set; }
    string GRP_PAPEL1_PROGRAMADO { get; set; }
    string GRP_PAPEL2_PROGRAMADO { get; set; }
    string GRP_PAPEL3_PROGRAMADO { get; set; }
    string GRP_PAPEL4_PROGRAMADO { get; set; }
    string GRP_PAPEL5_PROGRAMADO { get; set; }
    string BOL_STATUS_INTERFACE { get; set; }
    string BOL_TIPO { get; set; }
    int? BOL_FORMATO { get; set; }
    Decimal? BOL_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
    Decimal? BOL_GRAMATURA_PAPEIS_REALIZADO { get; set; }
    Decimal? BOL_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
    Decimal? BOL_CUSTO_PAPEIS_REALIZADO { get; set; }
    Decimal? BOL_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
    Decimal? BOL_CUSTO_RESINA_PROGRAMADOS { get; set; }
    int? BOL_REFILE_OBRIGATORIO { get; set; }
    string BOL_OBS { get; set; }
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