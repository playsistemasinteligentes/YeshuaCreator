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
        public void UpdateNome(int id, string value)
        {
            var query = _query.UpdateNome(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEspecialidadeId(int id, int value)
        {
            var query = _query.UpdateEspecialidadeId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTelefone(int id, string value)
        {
            var query = _query.UpdateTelefone(id, value);
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