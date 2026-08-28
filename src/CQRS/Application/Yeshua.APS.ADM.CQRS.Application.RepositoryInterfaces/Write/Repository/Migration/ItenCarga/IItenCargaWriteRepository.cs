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
    public partial interface IItenCargaWriteRepository
    {
        void Insert(IItenCargaEntity itencarga);
        void Update(IItenCargaEntity itencarga);
        void Delete(IItenCargaEntity itencarga);
        void UpdateCAR_ID(int id, string value);
        void UpdateORD_ID(int id, string value);
        void UpdateITC_ENTREGA_PLANEJADA(int id, DateTime value);
        void UpdateITC_ENTREGA_REALIZADA(int id, DateTime value);
        void UpdateITC_ORDEM_ENTREGA(int id, int value);
        void UpdateITC_QTD_PLANEJADA(int id, Decimal value);
        void UpdateITC_QTD_REALIZADA(int id, Decimal value);
        void UpdateORD_HASH_KEY(int id, string value);
        void UpdateNOT_ID(int id, string value);
        void UpdateNOT_EMISSAO(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration