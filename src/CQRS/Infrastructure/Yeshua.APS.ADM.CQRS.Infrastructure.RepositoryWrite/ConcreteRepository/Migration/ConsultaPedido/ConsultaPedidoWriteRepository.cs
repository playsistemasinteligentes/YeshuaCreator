// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.ConsultaPedido
{
    public partial class ConsultaPedidoWriteRepository : IConsultaPedidoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IConsultaPedidoQueryWrite _query; 

        public ConsultaPedidoWriteRepository(IUnitOfWork unitOfWork,IConsultaPedidoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IConsultaPedidoEntity ConsultaPedido)
        {
            var query = _query.InserirConsultaPedidoQuery(ConsultaPedido);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IConsultaPedidoEntity ConsultaPedido)
        {
            var query = _query.UpdateConsultaPedidoQuery(ConsultaPedido);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IConsultaPedidoEntity ConsultaPedido)
        {
            var query = _query.DeleteConsultaPedidoQuery(ConsultaPedido);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateClienteId(string pedidoid, string value)
        {
            var query = _query.UpdateClienteId(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateClienteNome(string pedidoid, string value)
        {
            var query = _query.UpdateClienteNome(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRazaoSocial(string pedidoid, string value)
        {
            var query = _query.UpdateRazaoSocial(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoId(string pedidoid, string value)
        {
            var query = _query.UpdateProdutoId(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoDescricao(string pedidoid, string value)
        {
            var query = _query.UpdateProdutoDescricao(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string pedidoid, string value)
        {
            var query = _query.UpdateStatus(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEstagio(string pedidoid, string value)
        {
            var query = _query.UpdateEstagio(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataEntregaDe(string pedidoid, DateTime value)
        {
            var query = _query.UpdateDataEntregaDe(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataEntregaAte(string pedidoid, DateTime value)
        {
            var query = _query.UpdateDataEntregaAte(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmbarqueAlvo(string pedidoid, DateTime value)
        {
            var query = _query.UpdateEmbarqueAlvo(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidade(string pedidoid, Decimal value)
        {
            var query = _query.UpdateQuantidade(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSaldoAProduzir(string pedidoid, Decimal value)
        {
            var query = _query.UpdateSaldoAProduzir(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSaldoAExpedir(string pedidoid, Decimal value)
        {
            var query = _query.UpdateSaldoAExpedir(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorFila(string pedidoid, string value)
        {
            var query = _query.UpdateCorFila(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePedidoCliente(string pedidoid, string value)
        {
            var query = _query.UpdatePedidoCliente(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration