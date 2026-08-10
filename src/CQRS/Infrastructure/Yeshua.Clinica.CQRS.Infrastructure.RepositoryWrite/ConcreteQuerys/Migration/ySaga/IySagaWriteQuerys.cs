using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IySagaQueryWrite 
     {
        public QueryModel InserirySagaQuery(IySagaEntity ySaga);
        public QueryModel UpdateySagaQuery(IySagaEntity ySaga);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateType(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateKeyCurrentStep(int id, string value);
        QueryModel UpdateCreatedAt(int id, DateTime value);
        QueryModel UpdateCompletedAt(int id, DateTime value);
        QueryModel UpdateEntityType(int id, string value);
        QueryModel UpdateEntityId(int id, string value);
        QueryModel UpdateNextExecutionAt(int id, DateTime value);
        QueryModel UpdateLockedAt(int id, DateTime value);
        QueryModel UpdateLockedBy(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteySagaQuery(IySagaEntity ySaga);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration