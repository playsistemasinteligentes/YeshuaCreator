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
    public partial interface ITipoAvaliacaoWriteRepository
    {
        void Insert(ITipoAvaliacaoEntity tipoavaliacao);
        void Update(ITipoAvaliacaoEntity tipoavaliacao);
        void Delete(ITipoAvaliacaoEntity tipoavaliacao);
        void UpdateTA_DESC(int ta_id, string value);
        void UpdateTenantID(int ta_id, int value);
        void UpdateDeleted(int ta_id, bool value);
        void UpdateChanged(int ta_id, DateTime value);
        void UpdateUserId(int ta_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration