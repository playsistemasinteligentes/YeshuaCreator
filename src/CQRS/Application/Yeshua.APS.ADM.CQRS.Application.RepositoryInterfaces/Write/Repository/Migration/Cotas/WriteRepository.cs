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
    public partial interface ICotasWriteRepository
    {
        void Insert(ICotasEntity cotas);
        void Update(ICotasEntity cotas);
        void Delete(ICotasEntity cotas);
        void UpdateCOT_ID(int id, int value);
        void UpdateCOT_DATA_DE(int id, DateTime value);
        void UpdateCOT_DATA_ATE(int id, DateTime value);
        void UpdateCOT_VALOR(int id, Decimal value);
        void UpdateCOT_OCUPADO(int id, Decimal value);
        void UpdateREP_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration