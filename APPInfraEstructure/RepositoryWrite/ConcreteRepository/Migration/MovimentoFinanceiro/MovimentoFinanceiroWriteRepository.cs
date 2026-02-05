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

namespace Input.Repository.MovimentoFinanceiro
{
    public class MovimentoFinanceiroWriteRepository : IMovimentoFinanceiroWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMovimentoFinanceiroQueryWrite _query; 

        public MovimentoFinanceiroWriteRepository(IUnitOfWork unitOfWork,IMovimentoFinanceiroQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            var query = _query.InserirMovimentoFinanceiroQuery(MovimentoFinanceiro);
        MovimentoFinanceiro.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            var query = _query.UpdateMovimentoFinanceiroQuery(MovimentoFinanceiro);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            var query = _query.DeleteMovimentoFinanceiroQuery(MovimentoFinanceiro);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateIdOrigem(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateIdOrigem(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateContaDebitoId(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateContaDebitoId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateContaCreditoId(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateContaCreditoId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValor(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateValor(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataMovimento(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateDataMovimento(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataVencimento(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateDataVencimento(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateStatus(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateStatus(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IMovimentoFinanceiroEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration