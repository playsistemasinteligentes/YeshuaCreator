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

namespace Input.Repository.Profissional
{
    public class ProfissionalWriteRepository : IProfissionalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IProfissionalQueryWrite _query; 

        public ProfissionalWriteRepository(IUnitOfWork unitOfWork,IProfissionalQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IProfissionalEntity Profissional)
        {
            var query = _query.InserirProfissionalQuery(Profissional);
        Profissional.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IProfissionalEntity Profissional)
        {
            var query = _query.UpdateProfissionalQuery(Profissional);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IProfissionalEntity Profissional)
        {
            var query = _query.DeleteProfissionalQuery(Profissional);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IProfissionalEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEspecialidadeId(IProfissionalEntity entity)
        {
            var query = _query.UpdateEspecialidadeId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTelefone(IProfissionalEntity entity)
        {
            var query = _query.UpdateTelefone(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IProfissionalEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IProfissionalEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IProfissionalEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IProfissionalEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration