using Dapper;
using Dominio.Entitys.Servico;
using Input.Querys.Servico;
using Repositorio.Inputs.Repositorio.Servico;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Servico
{
    public class ServicoWriteRepository : IServicoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ServicoWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(ServicoEntity Servico)
        {
            var query = new ServicoWriteQuery().InserirServicoQuery(Servico);
        Servico.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ServicoEntity Servico)
        {
            var query = new ServicoWriteQuery().UpdateServicoQuery(Servico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(ServicoEntity Servico)
        {
            var query = new ServicoWriteQuery().DeleteServicoQuery(Servico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration