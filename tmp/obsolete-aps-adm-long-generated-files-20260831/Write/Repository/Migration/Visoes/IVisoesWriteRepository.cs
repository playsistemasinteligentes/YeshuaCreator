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
    public partial interface IVisoesWriteRepository
    {
        void Insert(IVisoesEntity visoes);
        void Update(IVisoesEntity visoes);
        void Delete(IVisoesEntity visoes);
        void UpdateVIS_PLANID(int vis_id, int value);
        void UpdateVIS_FORMULA(int vis_id, string value);
        void UpdateCAB_ID(int vis_id, int value);
        void UpdateTenantID(int vis_id, int value);
        void UpdateDeleted(int vis_id, bool value);
        void UpdateChanged(int vis_id, DateTime value);
        void UpdateUserId(int vis_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration