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
                    public interface IyTokenEntity
{
    int? Id { get; set; }
    string TokenHash { get; set; }
    string? Description { get; set; }
    string ConnectorKey { get; set; }
    bool Active { get; set; }
    DateTime? ValidUntil { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? LastUsedAt { get; set; }
    int? TenantID { get; set; }
    int? UserId { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration