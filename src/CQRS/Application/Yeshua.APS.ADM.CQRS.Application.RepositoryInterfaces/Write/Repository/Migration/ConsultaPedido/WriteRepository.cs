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
    public partial interface IConsultaPedidoWriteRepository
    {
        void Insert(IConsultaPedidoEntity consultapedido);
        void Update(IConsultaPedidoEntity consultapedido);
        void Delete(IConsultaPedidoEntity consultapedido);
        void UpdateClienteId(string pedidoid, string value);
        void UpdateClienteNome(string pedidoid, string value);
        void UpdateRazaoSocial(string pedidoid, string value);
        void UpdateProdutoId(string pedidoid, string value);
        void UpdateProdutoDescricao(string pedidoid, string value);
        void UpdateStatus(string pedidoid, string value);
        void UpdateEstagio(string pedidoid, string value);
        void UpdateDataEntregaDe(string pedidoid, DateTime value);
        void UpdateDataEntregaAte(string pedidoid, DateTime value);
        void UpdateEmbarqueAlvo(string pedidoid, DateTime value);
        void UpdateQuantidade(string pedidoid, Decimal value);
        void UpdateSaldoAProduzir(string pedidoid, Decimal value);
        void UpdateSaldoAExpedir(string pedidoid, Decimal value);
        void UpdateCorFila(string pedidoid, string value);
        void UpdatePedidoCliente(string pedidoid, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration