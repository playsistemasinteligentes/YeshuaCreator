// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

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
        void UpdateCorrelationId(int id, string value);
        void UpdateType(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateKeyCurrentStep(int id, string value);
        void UpdateCreatedAt(int id, DateTime value);
        void UpdateCompletedAt(int id, DateTime value);
        void UpdateEntityType(int id, string value);
        void UpdateEntityId(int id, string value);
        void UpdateNextExecutionAt(int id, DateTime value);
        void UpdateLockedAt(int id, DateTime value);
        void UpdateLockedBy(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration