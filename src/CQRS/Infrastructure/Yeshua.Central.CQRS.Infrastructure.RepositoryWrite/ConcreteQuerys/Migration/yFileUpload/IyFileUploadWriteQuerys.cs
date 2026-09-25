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

    public interface IyFileUploadQueryWrite 
     {
        public QueryModel InseriryFileUploadQuery(IyFileUploadEntity yFileUpload);
        public QueryModel UpdateyFileUploadQuery(IyFileUploadEntity yFileUpload);
        QueryModel UpdateType(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateFilePath(int id, string value);
        QueryModel UpdateFileSize(int id, long value);
        QueryModel UpdateEntityType(int id, string value);
        QueryModel UpdateEntityId(int id, string value);
        QueryModel UpdateCreatedAt(int id, DateTime value);
        QueryModel UpdateCompletedAt(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteyFileUploadQuery(IyFileUploadEntity yFileUpload);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration