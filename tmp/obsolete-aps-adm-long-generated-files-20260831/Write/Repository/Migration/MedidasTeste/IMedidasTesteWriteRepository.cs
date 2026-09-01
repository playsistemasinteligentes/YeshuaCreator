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
    public partial interface IMedidasTesteWriteRepository
    {
        void Insert(IMedidasTesteEntity medidasteste);
        void Update(IMedidasTesteEntity medidasteste);
        void Delete(IMedidasTesteEntity medidasteste);
        void UpdateMDT_ID(int id, int value);
        void UpdateMDT_DESC(int id, string value);
        void UpdateMDT_VALOR_ESPERADO(int id, Decimal value);
        void UpdateMDT_ENCONTRADO(int id, Decimal value);
        void UpdateUNI_ID(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration