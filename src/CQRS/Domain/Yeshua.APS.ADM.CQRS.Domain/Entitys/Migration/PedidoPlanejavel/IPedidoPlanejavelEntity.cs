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
                    public interface IPedidoPlanejavelEntity
{
    string PedidoId { get; set; }
    string ClienteId { get; set; }
    string ClienteNome { get; set; }
    string Estado { get; set; }
    string Municipio { get; set; }
    string Regiao { get; set; }
    string Bairro { get; set; }
    string RotaId { get; set; }
    DateTime? EmbarqueAlvo { get; set; }
    DateTime? DataEntregaDe { get; set; }
    DateTime? DataEntregaAte { get; set; }
    Decimal? Peso { get; set; }
    Decimal? Volume { get; set; }
    Decimal? SaldoAExpedir { get; set; }
    string Status { get; set; }
    string CargaAtualId { get; set; }
    string VersaoPlanejamento { get; set; }
    string AlertasResumo { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration