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
    public class MovimentacaoFinanceiraWriteRepository : IMovimentacaoFinanceiraWriteRepository
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
        public void UpdatePacienteId(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdatePacienteId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateServicoId(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateServicoId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValor(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateValor(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoMovimentacao(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateTipoMovimentacao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataMovimentacao(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateDataMovimentacao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSaldoAtual(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateSaldoAtual(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IMovimentacaoFinanceiraEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration