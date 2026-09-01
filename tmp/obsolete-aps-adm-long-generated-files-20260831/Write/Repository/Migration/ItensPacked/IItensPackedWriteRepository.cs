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
    public partial interface IItensPackedWriteRepository
    {
        void Insert(IItensPackedEntity itenspacked);
        void Update(IItensPackedEntity itenspacked);
        void Delete(IItensPackedEntity itenspacked);
        void UpdateIPA_ID(int id, int value);
        void UpdateCAR_ID(int id, string value);
        void UpdatePRO_ID(int id, string value);
        void UpdateORD_ID(int id, string value);
        void UpdateIPA_COORDC(int id, Decimal value);
        void UpdateIPA_COORDL(int id, Decimal value);
        void UpdateIPA_COORDA(int id, Decimal value);
        void UpdateIPA_DIMC(int id, Decimal value);
        void UpdateIPA_DIML(int id, Decimal value);
        void UpdateIPA_DIMA(int id, Decimal value);
        void UpdateIPA_QTD_POR_PALETE(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration