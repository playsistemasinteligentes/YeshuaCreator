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
                    public interface IMovimentoCreditoEntity
{
    string? Id { get; set; }
    string Tipo { get; set; }
    string Referencia { get; set; }
    Decimal Quantidade { get; set; }
    Decimal SaldoApos { get; set; }
    DateTime CriadoEmUtc { get; set; }
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