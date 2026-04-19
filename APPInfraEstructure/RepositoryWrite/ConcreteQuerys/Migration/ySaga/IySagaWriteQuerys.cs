using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IySagaQueryWrite 
     {
        public QueryModel InserirySagaQuery(IySagaEntity ySaga);
        public QueryModel UpdateySagaQuery(IySagaEntity ySaga);
        public QueryModel UpdateSagaId(IySagaEntity entity);
        public QueryModel UpdateType(IySagaEntity entity);
        public QueryModel UpdateStatus(IySagaEntity entity);
        public QueryModel UpdateKeyCurrentStep(IySagaEntity entity);
        public QueryModel UpdateCreatedAt(IySagaEntity entity);
        public QueryModel UpdateCompletedAt(IySagaEntity entity);
        public QueryModel UpdateEntityType(IySagaEntity entity);
        public QueryModel UpdateEntityId(IySagaEntity entity);
        public QueryModel UpdateTenantID(IySagaEntity entity);
        public QueryModel UpdateDeleted(IySagaEntity entity);
        public QueryModel UpdateChanged(IySagaEntity entity);
        public QueryModel UpdateUserId(IySagaEntity entity);
        public QueryModel DeleteySagaQuery(IySagaEntity ySaga);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration