using Dapper;
using Dominio.Entitys.Profissional;
using Input.Querys.Profissional;
using Repositorio.Inputs.Repositorio.Profissional;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Profissional
{
    public class ProfissionalWriteRepository : IProfissionalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ProfissionalWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(ProfissionalEntity Profissional)
        {
            var query = new ProfissionalWriteQuery().InserirProfissionalQuery(Profissional);
        Profissional.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ProfissionalEntity Profissional)
        {
            var query = new ProfissionalWriteQuery().UpdateProfissionalQuery(Profissional);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(ProfissionalEntity Profissional)
        {
            var query = new ProfissionalWriteQuery().DeleteProfissionalQuery(Profissional);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration