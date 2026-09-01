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
    public partial interface IItensOrcamentoWriteRepository
    {
        void Insert(IItensOrcamentoEntity itensorcamento);
        void Update(IItensOrcamentoEntity itensorcamento);
        void Delete(IItensOrcamentoEntity itensorcamento);
        void UpdateITO_ID(int id, int value);
        void UpdateORC_ID(int id, int value);
        void UpdateTIP_ID(int id, int value);
        void UpdatePRO_ID(int id, string value);
        void UpdateITO_OBS(int id, string value);
        void UpdateITO_QUANTIDADE(int id, Decimal value);
        void UpdateITO_CUSTO(int id, Decimal value);
        void UpdateITO_MARGEM(int id, Decimal value);
        void UpdateITO_VALOR_UNITARIO(int id, Decimal value);
        void UpdateITO_VERSSAO_CUSTO(int id, DateTime value);
        void UpdateITO_STATUS(int id, string value);
        void UpdateITO_ERP_CUSTOS_FIXOS(int id, Decimal value);
        void UpdateITO_ERP_CUSTOS_VARIAVEIS(int id, Decimal value);
        void UpdateITO_ERP_DESPESAS_VAR_VENDA(int id, Decimal value);
        void UpdateITO_ERP_IMPOSTOS(int id, Decimal value);
        void UpdateGRP_ID_COMPOSICAO(int id, string value);
        void UpdateITO_LARGURA(int id, Decimal value);
        void UpdateITO_COMPRIMENTO(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration