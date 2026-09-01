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
    public partial interface IUniuserWriteRepository
    {
        void Insert(IUniuserEntity uniuser);
        void Update(IUniuserEntity uniuser);
        void Delete(IUniuserEntity uniuser);
        void UpdateUNI_ID(int usergru_id, int value);
        void UpdateUSE_ID(int usergru_id, int value);
        void UpdateTenantID(int usergru_id, int value);
        void UpdateDeleted(int usergru_id, bool value);
        void UpdateChanged(int usergru_id, DateTime value);
        void UpdateUserId(int usergru_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration