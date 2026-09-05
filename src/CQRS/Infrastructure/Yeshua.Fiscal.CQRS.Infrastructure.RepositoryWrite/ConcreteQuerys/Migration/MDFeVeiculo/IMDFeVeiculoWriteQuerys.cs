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

    public interface IMDFeVeiculoQueryWrite 
     {
        public QueryModel InserirMDFeVeiculoQuery(IMDFeVeiculoEntity MDFeVeiculo);
        public QueryModel UpdateMDFeVeiculoQuery(IMDFeVeiculoEntity MDFeVeiculo);
        QueryModel UpdateMDFeSolicitacaoFiscalId(int id, int value);
        QueryModel UpdatePlaca(int id, string value);
        QueryModel UpdateRenavam(int id, string value);
        QueryModel UpdateTara(int id, Decimal value);
        QueryModel UpdateCapacidadeKg(int id, Decimal value);
        QueryModel UpdateCapacidadeM3(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMDFeVeiculoQuery(IMDFeVeiculoEntity MDFeVeiculo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration