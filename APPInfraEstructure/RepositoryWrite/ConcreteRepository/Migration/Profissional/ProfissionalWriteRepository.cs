using Dapper;
using Dominio.Entitys;
using Input.Querys.Profissional;
using Repositorio.Inputs.Repositorio.Profissional;
using RepositoryInterfaces.Services;
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

        public void Insert(IProfissionalEntity Profissional)
        {
            var query = new ProfissionalWriteQuery().InserirProfissionalQuery(Profissional);
        Profissional.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IProfissionalEntity Profissional)
        {
            var query = new ProfissionalWriteQuery().UpdateProfissionalQuery(Profissional);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IProfissionalEntity Profissional)
        {
            var query = new ProfissionalWriteQuery().DeleteProfissionalQuery(Profissional);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IProfissionalEntity entity)
        {
            var query = new ProfissionalWriteQuery().UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEspecialidadeId(IProfissionalEntity entity)
        {
            var query = new ProfissionalWriteQuery().UpdateEspecialidadeId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTelefone(IProfissionalEntity entity)
        {
            var query = new ProfissionalWriteQuery().UpdateTelefone(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration