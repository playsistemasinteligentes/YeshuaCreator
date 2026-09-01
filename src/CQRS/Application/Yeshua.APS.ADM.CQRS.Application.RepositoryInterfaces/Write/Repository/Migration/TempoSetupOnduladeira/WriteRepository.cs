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
    public partial interface ITempoSetupOnduladeiraWriteRepository
    {
        void Insert(ITempoSetupOnduladeiraEntity temposetuponduladeira);
        void Update(ITempoSetupOnduladeiraEntity temposetuponduladeira);
        void Delete(ITempoSetupOnduladeiraEntity temposetuponduladeira);
        void UpdateOND_ID_DE(int tem_id, string value);
        void UpdateOND_ID_PARA(int tem_id, string value);
        void UpdateTEM_RESINA_DE(int tem_id, string value);
        void UpdateTEM_RESINA_PARA(int tem_id, string value);
        void UpdateTEM_TEMPO(int tem_id, int value);
        void UpdateTenantID(int tem_id, int value);
        void UpdateDeleted(int tem_id, bool value);
        void UpdateChanged(int tem_id, DateTime value);
        void UpdateUserId(int tem_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration