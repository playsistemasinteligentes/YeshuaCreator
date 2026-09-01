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
    public partial interface ITemplateTipoTesteWriteRepository
    {
        void Insert(ITemplateTipoTesteEntity templatetipoteste);
        void Update(ITemplateTipoTesteEntity templatetipoteste);
        void Delete(ITemplateTipoTesteEntity templatetipoteste);
        void UpdateTT_ID(int ttt_id, int value);
        void UpdateTEM_ID(int ttt_id, int value);
        void UpdateTenantID(int ttt_id, int value);
        void UpdateDeleted(int ttt_id, bool value);
        void UpdateChanged(int ttt_id, DateTime value);
        void UpdateUserId(int ttt_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration