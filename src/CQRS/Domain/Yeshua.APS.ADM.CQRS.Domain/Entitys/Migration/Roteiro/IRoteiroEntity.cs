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
                    public interface IRoteiroEntity
{
    string MaquinaId { get; set; }
    string ProdutoId { get; set; }
    int SequenciaTransformacao { get; set; }
    string GrupoMaquinaId { get; set; }
    Decimal? PecasPorPulso { get; set; }
    Decimal? PrioridadeInformada { get; set; }
    string Acao { get; set; }
    Decimal Performance { get; set; }
    Decimal? TempoSetup { get; set; }
    Decimal? TempoSetupAjuste { get; set; }
    int? ProximaSequenciaTransformacao { get; set; }
    string Status { get; set; }
    Decimal? HierarquiaSequenciaTransformacao { get; set; }
    int? AvaliaCusto { get; set; }
    string Operacoes { get; set; }
    string ExcecaoOperacoes { get; set; }
    Decimal? PercentualInicioPassoAnterior { get; set; }
    string LinhaDireta { get; set; }
    int? TemplateDeTestesId { get; set; }
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