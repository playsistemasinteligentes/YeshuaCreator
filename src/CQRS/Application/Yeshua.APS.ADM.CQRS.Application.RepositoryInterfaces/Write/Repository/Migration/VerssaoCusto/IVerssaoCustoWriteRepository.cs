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
    public partial interface IVerssaoCustoWriteRepository
    {
        void Insert(IVerssaoCustoEntity verssaocusto);
        void Update(IVerssaoCustoEntity verssaocusto);
        void Delete(IVerssaoCustoEntity verssaocusto);
        void UpdateVER_ID(int id, int value);
        void UpdateVER_STATUS(int id, string value);
        void UpdateVER_DATA_VERSSAO_CUSTO(int id, DateTime value);
        void UpdateVER_OBS(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration