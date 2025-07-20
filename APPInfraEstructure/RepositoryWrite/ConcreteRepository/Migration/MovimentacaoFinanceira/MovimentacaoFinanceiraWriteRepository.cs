using Dapper;
using Dominio.Entitys;
using Input.Querys.MovimentacaoFinanceira;
using IRepository.Write;
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

        public MovimentacaoFinanceiraWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().InserirMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
        MovimentacaoFinanceira.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdateMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().DeleteMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePacienteId(IMovimentacaoFinanceiraEntity entity)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdatePacienteId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateServicoId(IMovimentacaoFinanceiraEntity entity)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdateServicoId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValor(IMovimentacaoFinanceiraEntity entity)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdateValor(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTipoMovimentacao(IMovimentacaoFinanceiraEntity entity)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdateTipoMovimentacao(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataMovimentacao(IMovimentacaoFinanceiraEntity entity)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdateDataMovimentacao(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateSaldoAtual(IMovimentacaoFinanceiraEntity entity)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdateSaldoAtual(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration