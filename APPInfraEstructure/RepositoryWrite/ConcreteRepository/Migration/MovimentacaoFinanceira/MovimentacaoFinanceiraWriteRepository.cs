using Dapper;
using Dominio.Entitys;
using Input.Querys.MovimentacaoFinanceira;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
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

        public void Insert(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().InserirMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
        MovimentacaoFinanceira.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().UpdateMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().DeleteMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration