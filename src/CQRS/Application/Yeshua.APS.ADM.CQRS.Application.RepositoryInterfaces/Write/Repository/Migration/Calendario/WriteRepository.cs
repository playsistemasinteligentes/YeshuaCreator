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
    public partial interface ICalendarioWriteRepository
    {
        void Insert(ICalendarioEntity calendario);
        void Update(ICalendarioEntity calendario);
        void Delete(ICalendarioEntity calendario);
        void UpdateCAL_DESCRICAO(int cal_id, string value);
        void UpdateCAL_DIVIDE_DIA_EM(int cal_id, int value);
        void UpdateTenantID(int cal_id, int value);
        void UpdateDeleted(int cal_id, bool value);
        void UpdateChanged(int cal_id, DateTime value);
        void UpdateUserId(int cal_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration