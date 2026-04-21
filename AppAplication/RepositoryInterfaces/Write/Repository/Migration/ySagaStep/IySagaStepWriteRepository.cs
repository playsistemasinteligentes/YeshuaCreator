using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IySagaStepWriteRepository
    {
        void Insert(IySagaStepEntity ysagastep);
        void Update(IySagaStepEntity ysagastep);
        void Delete(IySagaStepEntity ysagastep);
        public void UpdateSagaId(IySagaStepEntity entity);
        public void UpdateStepKey(IySagaStepEntity entity);
        public void UpdateIndexOrder(IySagaStepEntity entity);
        public void UpdateCorrelationId(IySagaStepEntity entity);
        public void UpdateStatus(IySagaStepEntity entity);
        public void UpdateExecutionCount(IySagaStepEntity entity);
        public void UpdateLastExecutionAt(IySagaStepEntity entity);
        public void UpdateCompletedAt(IySagaStepEntity entity);
        public void UpdateErrorMessage(IySagaStepEntity entity);
        public void UpdatePayload(IySagaStepEntity entity);
        public void UpdateRetryCount(IySagaStepEntity entity);
        public void UpdateTenantID(IySagaStepEntity entity);
        public void UpdateDeleted(IySagaStepEntity entity);
        public void UpdateChanged(IySagaStepEntity entity);
        public void UpdateUserId(IySagaStepEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration