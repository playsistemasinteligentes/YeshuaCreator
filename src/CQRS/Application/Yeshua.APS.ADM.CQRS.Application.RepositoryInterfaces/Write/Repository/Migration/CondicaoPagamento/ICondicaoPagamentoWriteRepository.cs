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
    public partial interface ICondicaoPagamentoWriteRepository
    {
        void Insert(ICondicaoPagamentoEntity condicaopagamento);
        void Update(ICondicaoPagamentoEntity condicaopagamento);
        void Delete(ICondicaoPagamentoEntity condicaopagamento);
        void UpdateCON_ID(int id, string value);
        void UpdateCON_DESCRICAO(int id, string value);
        void UpdateCON_PARCELAS(int id, int value);
        void UpdateCON_VALOR_ACRECIMO(int id, Decimal value);
        void UpdateCON_INTEGRACAO_ERP(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration