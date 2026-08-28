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
    public partial interface ICanhotosWriteRepository
    {
        void Insert(ICanhotosEntity canhotos);
        void Update(ICanhotosEntity canhotos);
        void Delete(ICanhotosEntity canhotos);
        void UpdateCAR_ID(int id, string value);
        void UpdateORD_ID(int id, string value);
        void UpdateNOT_ID(int id, string value);
        void UpdateCAN_DATA_ENTREGA(int id, DateTime value);
        void UpdateCAN_IMG(int id, string value);
        void UpdateCAN_LAT_ENTREGA(int id, Decimal value);
        void UpdateCAN_LONG_ENTREGA(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration