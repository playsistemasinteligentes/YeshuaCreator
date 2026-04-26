using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IySagaWriteRepository
    {
        void Insert(IySagaEntity ysaga);
        void Update(IySagaEntity ysaga);
        void Delete(IySagaEntity ysaga);
        public void UpdateCorrelationId(IySagaEntity entity);
        public void UpdateType(IySagaEntity entity);
        public void UpdateStatus(IySagaEntity entity);
        public void UpdateKeyCurrentStep(IySagaEntity entity);
        public void UpdateCreatedAt(IySagaEntity entity);
        public void UpdateCompletedAt(IySagaEntity entity);
        public void UpdateEntityType(IySagaEntity entity);
        public void UpdateEntityId(IySagaEntity entity);
        public void UpdateNextExecutionAt(IySagaEntity entity);
        public void UpdateLockedAt(IySagaEntity entity);
        public void UpdateLockedBy(IySagaEntity entity);
        public void UpdateTenantID(IySagaEntity entity);
        public void UpdateDeleted(IySagaEntity entity);
        public void UpdateChanged(IySagaEntity entity);
        public void UpdateUserId(IySagaEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration