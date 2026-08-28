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

    public interface IClpMedicoesQueryWrite 
     {
        public QueryModel InserirClpMedicoesQuery(IClpMedicoesEntity ClpMedicoes);
        public QueryModel UpdateClpMedicoesQuery(IClpMedicoesEntity ClpMedicoes);
        QueryModel UpdateId2(int id, int value);
        QueryModel UpdateMaquinaId(int id, string value);
        QueryModel UpdateDataInicio(int id, DateTime value);
        QueryModel UpdateDataFim(int id, DateTime value);
        QueryModel UpdateEmissao(int id, DateTime value);
        QueryModel UpdateQuantidade(int id, Decimal value);
        QueryModel UpdateGrupo(int id, Decimal value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTurnoId(int id, string value);
        QueryModel UpdateTurmaId(int id, string value);
        QueryModel UpdateIdLoteClp(int id, int value);
        QueryModel UpdateOcorrenciaId(int id, string value);
        QueryModel UpdateFase(int id, int value);
        QueryModel UpdateClpOrigem(int id, string value);
        QueryModel UpdateCLP_LOTE(int id, int value);
        QueryModel UpdateCOMPACTA(int id, int value);
        QueryModel UpdateBOL_ID(int id, string value);
        QueryModel UpdateCOR_SEQUENCIA(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteClpMedicoesQuery(IClpMedicoesEntity ClpMedicoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration