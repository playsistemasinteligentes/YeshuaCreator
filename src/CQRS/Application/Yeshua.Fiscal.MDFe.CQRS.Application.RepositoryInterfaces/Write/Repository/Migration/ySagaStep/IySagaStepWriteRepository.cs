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
        void UpdateSagaId(int id, int value);
        void UpdateStepKey(int id, string value);
        void UpdateIndexOrder(int id, int value);
        void UpdateCorrelationId(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateExecutionCount(int id, int value);
        void UpdateLastExecutionAt(int id, DateTime value);
        void UpdateCompletedAt(int id, DateTime value);
        void UpdateErrorMessage(int id, string value);
        void UpdatePayload(int id, string value);
        void UpdateRetryCount(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration