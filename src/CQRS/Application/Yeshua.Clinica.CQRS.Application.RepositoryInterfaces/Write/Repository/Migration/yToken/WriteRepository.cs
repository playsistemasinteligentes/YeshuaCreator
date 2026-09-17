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
    public partial interface IyTokenWriteRepository
    {
        void Insert(IyTokenEntity ytoken);
        void Update(IyTokenEntity ytoken);
        void Delete(IyTokenEntity ytoken);
        void UpdateTokenHash(int id, string value);
        void UpdateDescription(int id, string value);
        void UpdateConnectorKey(int id, string value);
        void UpdateActive(int id, bool value);
        void UpdateValidUntil(int id, DateTime value);
        void UpdateCreatedAt(int id, DateTime value);
        void UpdateLastUsedAt(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateUserId(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration