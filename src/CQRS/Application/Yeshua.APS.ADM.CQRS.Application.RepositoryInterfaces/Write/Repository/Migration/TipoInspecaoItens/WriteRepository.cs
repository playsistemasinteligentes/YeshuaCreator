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
    public partial interface ITipoInspecaoItensWriteRepository
    {
        void Insert(ITipoInspecaoItensEntity tipoinspecaoitens);
        void Update(ITipoInspecaoItensEntity tipoinspecaoitens);
        void Delete(ITipoInspecaoItensEntity tipoinspecaoitens);
        void UpdateTII_ID(int id, int value);
        void UpdateTIV_ID(int id, int value);
        void UpdateITI_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration