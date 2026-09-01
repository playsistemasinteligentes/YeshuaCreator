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
    public partial interface ITemplateTipoInspecaoVisualWriteRepository
    {
        void Insert(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual);
        void Update(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual);
        void Delete(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual);
        void UpdateTIV_ID(int tti_id, int value);
        void UpdateTEM_ID(int tti_id, int value);
        void UpdateTenantID(int tti_id, int value);
        void UpdateDeleted(int tti_id, bool value);
        void UpdateChanged(int tti_id, DateTime value);
        void UpdateUserId(int tti_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration