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
                    public interface IExperienciaPlanejamentoTransporteEntity
{
    int? Id { get; set; }
    int Tipo { get; set; }
    string Referencia { get; set; }
    string PedidoId { get; set; }
    string ClienteId { get; set; }
    string Municipio { get; set; }
    string Regiao { get; set; }
    string RotaId { get; set; }
    Decimal? Peso { get; set; }
    Decimal? Volume { get; set; }
    string Observacao { get; set; }
    DateTime CriadoEm { get; set; }
    string CriadoPor { get; set; }
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