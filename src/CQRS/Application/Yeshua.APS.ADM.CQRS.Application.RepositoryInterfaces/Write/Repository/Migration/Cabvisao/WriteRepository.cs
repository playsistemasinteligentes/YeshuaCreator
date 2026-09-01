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
    public partial interface ICabvisaoWriteRepository
    {
        void Insert(ICabvisaoEntity cabvisao);
        void Update(ICabvisaoEntity cabvisao);
        void Delete(ICabvisaoEntity cabvisao);
        void UpdateCAB_DESC(int cab_id, string value);
        void UpdateCAB_STATUS(int cab_id, int value);
        void UpdateUSE_ID(int cab_id, int value);
        void UpdateTenantID(int cab_id, int value);
        void UpdateDeleted(int cab_id, bool value);
        void UpdateChanged(int cab_id, DateTime value);
        void UpdateUserId(int cab_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration