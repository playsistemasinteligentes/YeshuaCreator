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

    public interface ICTeSaidaMDFeQueryWrite 
     {
        public QueryModel InserirCTeSaidaMDFeQuery(ICTeSaidaMDFeEntity CTeSaidaMDFe);
        public QueryModel UpdateCTeSaidaMDFeQuery(ICTeSaidaMDFeEntity CTeSaidaMDFe);
        QueryModel UpdateCTeTentativaEmissaoId(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateChaveAcessoCTe(int id, string value);
        QueryModel UpdateSnapshotHash(int id, string value);
        QueryModel UpdateOutboxMessageId(int id, string value);
        QueryModel UpdatePublicadoEmUtc(int id, DateTime value);
        QueryModel UpdateUltimoErro(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCTeSaidaMDFeQuery(ICTeSaidaMDFeEntity CTeSaidaMDFe);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration