// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IFeedbackQueryWrite 
     {
        public QueryModel InserirFeedbackQuery(IFeedbackEntity Feedback);
        public QueryModel UpdateFeedbackQuery(IFeedbackEntity Feedback);
        QueryModel UpdateDataInicial(int id, DateTime value);
        QueryModel UpdateDatafinal(int id, DateTime value);
        QueryModel UpdateMaquinaId(int id, string value);
        QueryModel UpdateOcorrenciaId(int id, string value);
        QueryModel UpdateTurnoId(int id, string value);
        QueryModel UpdateTurmaId(int id, string value);
        QueryModel UpdateUsuarioId(int id, int value);
        QueryModel UpdateOrderId(int id, string value);
        QueryModel UpdateProdutoId(int id, string value);
        QueryModel UpdateObservacoes(int id, string value);
        QueryModel UpdateGrupo(int id, Decimal value);
        QueryModel UpdateDiaTurma(int id, string value);
        QueryModel UpdateSequenciaTransformacao(int id, int value);
        QueryModel UpdateSequenciaRepeticao(int id, int value);
        QueryModel UpdateQuantidadePulsos(int id, Decimal value);
        QueryModel UpdateQuantidadePecasPorPulso(int id, Decimal value);
        QueryModel UpdateFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(int id, Decimal value);
        QueryModel UpdateBOL_ID(int id, string value);
        QueryModel UpdateCOR_SEQUENCIA(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteFeedbackQuery(IFeedbackEntity Feedback);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration