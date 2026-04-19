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
    public partial class ProfissionalWriteRepository : IProfissionalWriteRepository
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
        Profissional.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IProfissionalEntity Profissional)
        {
            var query = _query.UpdateProfissionalQuery(Profissional);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IProfissionalEntity Profissional)
        {
            var query = _query.DeleteProfissionalQuery(Profissional);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(IProfissionalEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEspecialidadeId(IProfissionalEntity entity)
        {
            var query = _query.UpdateEspecialidadeId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTelefone(IProfissionalEntity entity)
        {
            var query = _query.UpdateTelefone(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IProfissionalEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IProfissionalEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IProfissionalEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IProfissionalEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration