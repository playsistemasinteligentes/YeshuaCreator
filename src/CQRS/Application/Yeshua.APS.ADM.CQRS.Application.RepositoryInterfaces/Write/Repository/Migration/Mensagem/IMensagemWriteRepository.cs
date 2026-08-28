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
    public partial interface IMensagemWriteRepository
    {
        void Insert(IMensagemEntity mensagem);
        void Update(IMensagemEntity mensagem);
        void Delete(IMensagemEntity mensagem);
        void UpdateMEN_SEND(string men_id, string value);
        void UpdateMEN_EMISSION(string men_id, DateTime value);
        void UpdateMEN_STATUS(string men_id, string value);
        void UpdateMEN_RECEIVE(string men_id, string value);
        void UpdateMEN_TYPE(string men_id, string value);
        void UpdateMEN_QTD_TRY_SEND(string men_id, Decimal value);
        void UpdateMEN_DATE_TRY_SEND(string men_id, DateTime value);
        void UpdateTenantID(string men_id, int value);
        void UpdateDeleted(string men_id, bool value);
        void UpdateChanged(string men_id, DateTime value);
        void UpdateUserId(string men_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration