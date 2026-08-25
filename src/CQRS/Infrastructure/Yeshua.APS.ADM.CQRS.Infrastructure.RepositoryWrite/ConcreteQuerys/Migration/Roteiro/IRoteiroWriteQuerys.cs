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

    public interface IRoteiroQueryWrite 
     {
        public QueryModel InserirRoteiroQuery(IRoteiroEntity Roteiro);
        public QueryModel UpdateRoteiroQuery(IRoteiroEntity Roteiro);
        QueryModel UpdateMaquinaId(int id, string value);
        QueryModel UpdateProdutoId(int id, string value);
        QueryModel UpdateSequenciaTransformacao(int id, int value);
        QueryModel UpdateGrupoMaquinaId(int id, string value);
        QueryModel UpdatePecasPorPulso(int id, Decimal value);
        QueryModel UpdatePrioridadeInformada(int id, Decimal value);
        QueryModel UpdateAcao(int id, string value);
        QueryModel UpdatePerformance(int id, Decimal value);
        QueryModel UpdateTempoSetup(int id, Decimal value);
        QueryModel UpdateTempoSetupAjuste(int id, Decimal value);
        QueryModel UpdateProximaSequenciaTransformacao(int id, int value);
        QueryModel UpdateStatus(int id, string value);
        QueryModel UpdateHierarquiaSequenciaTransformacao(int id, Decimal value);
        QueryModel UpdateAvaliaCusto(int id, int value);
        QueryModel UpdateOperacoes(int id, string value);
        QueryModel UpdateExcecaoOperacoes(int id, string value);
        QueryModel UpdatePercentualInicioPassoAnterior(int id, Decimal value);
        QueryModel UpdateLinhaDireta(int id, string value);
        QueryModel UpdateTemplateDeTestesId(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteRoteiroQuery(IRoteiroEntity Roteiro);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration