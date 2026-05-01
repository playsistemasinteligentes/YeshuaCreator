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
    public partial class MovimentoFinanceiroWriteRepository : IMovimentoFinanceiroWriteRepository
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
        MovimentoFinanceiro.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            var query = _query.UpdateMovimentoFinanceiroQuery(MovimentoFinanceiro);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            var query = _query.DeleteMovimentoFinanceiroQuery(MovimentoFinanceiro);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIdOrigem(int id, string value)
        {
            var query = _query.UpdateIdOrigem(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateContaDebitoId(int id, int value)
        {
            var query = _query.UpdateContaDebitoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValor(int id, Decimal value)
        {
            var query = _query.UpdateValor(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataMovimento(int id, DateTime value)
        {
            var query = _query.UpdateDataMovimento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataVencimento(int id, DateTime value)
        {
            var query = _query.UpdateDataVencimento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration