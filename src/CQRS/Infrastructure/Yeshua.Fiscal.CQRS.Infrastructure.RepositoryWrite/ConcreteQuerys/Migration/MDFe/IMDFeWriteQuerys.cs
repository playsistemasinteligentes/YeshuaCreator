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

    public interface IMDFeQueryWrite 
     {
        public QueryModel InserirMDFeQuery(IMDFeEntity MDFe);
        public QueryModel UpdateMDFeQuery(IMDFeEntity MDFe);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateSerie(int id, int value);
        QueryModel UpdateNumero(int id, int value);
        QueryModel UpdateUfCarregamento(int id, string value);
        QueryModel UpdateUfDescarregamento(int id, string value);
        QueryModel UpdatePlacaVeiculo(int id, string value);
        QueryModel UpdateEmitidoEm(int id, DateTime value);
        QueryModel UpdateAutorizadoEm(int id, DateTime value);
        QueryModel UpdateIniciadoEm(int id, DateTime value);
        QueryModel UpdateEncerradoEm(int id, DateTime value);
        QueryModel UpdateCanceladoEm(int id, DateTime value);
        QueryModel UpdateSituacao(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMDFeQuery(IMDFeEntity MDFe);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration