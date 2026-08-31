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
                    public interface IOpcaoPlanejamentoTransporteEntity
{
    string OpcaoId { get; set; }
    string GrupoDecisaoId { get; set; }
    Decimal? Peso { get; set; }
    Decimal? Volume { get; set; }
    Decimal? CustoEstimado { get; set; }
    Decimal? AderenciaCubagem { get; set; }
    Decimal? AderenciaJanelaEntrega { get; set; }
    string RiscoResumo { get; set; }
    string PedidosResumo { get; set; }
    string OpcoesConflitantesResumo { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration