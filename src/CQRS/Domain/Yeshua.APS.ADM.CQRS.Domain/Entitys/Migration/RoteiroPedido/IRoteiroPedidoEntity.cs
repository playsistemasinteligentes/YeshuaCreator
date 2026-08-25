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
                    public interface IRoteiroPedidoEntity
{
    string PedidoId { get; set; }
    string MaquinaId { get; set; }
    string ProdutoId { get; set; }
    int SequenciaTransformacao { get; set; }
    string StatusCadastro { get; set; }
    string TipoPlanejamento { get; set; }
    int CalendarioId { get; set; }
    Decimal? HierarquiaSequenciaTransformacao { get; set; }
    int? ProximaSequenciaTransformacao { get; set; }
    Decimal? Performance { get; set; }
    Decimal? TempoSetup { get; set; }
    Decimal? TempoSetupAjuste { get; set; }
    Decimal? PecasPorPulso { get; set; }
    Decimal? PrioridadeInformada { get; set; }
    string Status { get; set; }
    string Operacoes { get; set; }
    string ExcecaoOperacoes { get; set; }
    string LinhaDireta { get; set; }
    int? AvaliaCusto { get; set; }
    Decimal? PercentualInicioPassoAnterior { get; set; }
    Decimal? MaquinaLarguraUtil { get; set; }
    Decimal? GrupoTipo { get; set; }
    Decimal GrupoPerformanceMetroLinear { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration