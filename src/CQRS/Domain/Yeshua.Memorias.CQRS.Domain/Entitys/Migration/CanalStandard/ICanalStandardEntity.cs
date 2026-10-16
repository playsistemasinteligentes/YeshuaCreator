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
                    public interface ICanalStandardEntity
{
    int? Id { get; set; }
    string CanalId { get; set; }
    string ConexaoYouTubeId { get; set; }
    int CredencialTenantId { get; set; }
    bool Ativo { get; set; }
    long TotalReservas { get; set; }
    DateTime? UltimaReservaEmUtc { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    string OperationalEntityId { get; }

                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();


                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration