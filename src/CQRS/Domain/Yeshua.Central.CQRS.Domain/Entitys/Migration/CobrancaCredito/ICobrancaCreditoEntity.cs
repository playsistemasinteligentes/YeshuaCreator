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
                    public interface ICobrancaCreditoEntity
{
    string? Id { get; set; }
    Decimal Creditos { get; set; }
    Decimal Valor { get; set; }
    int Status { get; set; }
    DateTime CriadaEmUtc { get; set; }
    DateTime VenceEmUtc { get; set; }
    string Moeda { get; set; }
    string Provedor { get; set; }
    DateTime? PagaEmUtc { get; set; }
    int? TenantID { get; set; }
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