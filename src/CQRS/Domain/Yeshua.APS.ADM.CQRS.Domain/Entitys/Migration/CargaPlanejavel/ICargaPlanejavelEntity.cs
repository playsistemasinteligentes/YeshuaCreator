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
                    public interface ICargaPlanejavelEntity
{
    string CargaId { get; set; }
    string Status { get; set; }
    string TransportadoraId { get; set; }
    string VeiculoId { get; set; }
    int? TipoVeiculoId { get; set; }
    Decimal? PesoTeorico { get; set; }
    Decimal? VolumeTeorico { get; set; }
    DateTime? InicioJanelaEmbarque { get; set; }
    DateTime? FimJanelaEmbarque { get; set; }
    DateTime? EmbarqueAlvo { get; set; }
    int? QuantidadePedidos { get; set; }
    string AlertasResumo { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration