// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IConsultaPedidoQueryWrite 
     {
        public QueryModel InserirConsultaPedidoQuery(IConsultaPedidoEntity ConsultaPedido);
        public QueryModel UpdateConsultaPedidoQuery(IConsultaPedidoEntity ConsultaPedido);
        QueryModel UpdateClienteId(string pedidoid, string value);
        QueryModel UpdateClienteNome(string pedidoid, string value);
        QueryModel UpdateRazaoSocial(string pedidoid, string value);
        QueryModel UpdateProdutoId(string pedidoid, string value);
        QueryModel UpdateProdutoDescricao(string pedidoid, string value);
        QueryModel UpdateStatus(string pedidoid, string value);
        QueryModel UpdateEstagio(string pedidoid, string value);
        QueryModel UpdateDataEntregaDe(string pedidoid, DateTime value);
        QueryModel UpdateDataEntregaAte(string pedidoid, DateTime value);
        QueryModel UpdateEmbarqueAlvo(string pedidoid, DateTime value);
        QueryModel UpdateQuantidade(string pedidoid, Decimal value);
        QueryModel UpdateSaldoAProduzir(string pedidoid, Decimal value);
        QueryModel UpdateSaldoAExpedir(string pedidoid, Decimal value);
        QueryModel UpdateCorFila(string pedidoid, string value);
        QueryModel UpdatePedidoCliente(string pedidoid, string value);
        public QueryModel DeleteConsultaPedidoQuery(IConsultaPedidoEntity ConsultaPedido);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration