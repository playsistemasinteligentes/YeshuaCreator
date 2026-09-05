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

    public interface IMDFeCondutorQueryWrite 
     {
        public QueryModel InserirMDFeCondutorQuery(IMDFeCondutorEntity MDFeCondutor);
        public QueryModel UpdateMDFeCondutorQuery(IMDFeCondutorEntity MDFeCondutor);
        QueryModel UpdateMDFeSolicitacaoFiscalId(int id, int value);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateDocumento(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMDFeCondutorQuery(IMDFeCondutorEntity MDFeCondutor);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration