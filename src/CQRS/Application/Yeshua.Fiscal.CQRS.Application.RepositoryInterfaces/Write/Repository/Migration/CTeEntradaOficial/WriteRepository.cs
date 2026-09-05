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
    public partial interface ICTeEntradaOficialWriteRepository
    {
        void Insert(ICTeEntradaOficialEntity cteentradaoficial);
        void Update(ICTeEntradaOficialEntity cteentradaoficial);
        void Delete(ICTeEntradaOficialEntity cteentradaoficial);
        void UpdateCorrelationId(int id, string value);
        void UpdateSourceApplication(int id, string value);
        void UpdateSourceModule(int id, string value);
        void UpdateSourceMessageId(int id, string value);
        void UpdateMessageType(int id, string value);
        void UpdateMessageVersion(int id, string value);
        void UpdateReceivedAtUtc(int id, DateTime value);
        void UpdatePayloadHash(int id, string value);
        void UpdatePayloadStorageKey(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration