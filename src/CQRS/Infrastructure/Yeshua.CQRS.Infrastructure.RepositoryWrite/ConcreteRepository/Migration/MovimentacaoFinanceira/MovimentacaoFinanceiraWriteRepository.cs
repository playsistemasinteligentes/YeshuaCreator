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

namespace Input.Repository.MovimentacaoFinanceira
{
    public partial class MovimentacaoFinanceiraWriteRepository : IMovimentacaoFinanceiraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMovimentacaoFinanceiraQueryWrite _query; 

        public MovimentacaoFinanceiraWriteRepository(IUnitOfWork unitOfWork,IMovimentacaoFinanceiraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = _query.InserirMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
        MovimentacaoFinanceira.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = _query.UpdateMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = _query.DeleteMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePacienteId(int id, int value)
        {
            var query = _query.UpdatePacienteId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateServicoId(int id, int value)
        {
            var query = _query.UpdateServicoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValor(int id, Decimal value)
        {
            var query = _query.UpdateValor(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoMovimentacao(int id, int value)
        {
            var query = _query.UpdateTipoMovimentacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataMovimentacao(int id, DateTime value)
        {
            var query = _query.UpdateDataMovimentacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSaldoAtual(int id, Decimal value)
        {
            var query = _query.UpdateSaldoAtual(id, value);
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