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

namespace Input.Repository.Especialidade
{
    public partial class EspecialidadeWriteRepository : IEspecialidadeWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEspecialidadeQueryWrite _query; 

        public EspecialidadeWriteRepository(IUnitOfWork unitOfWork,IEspecialidadeQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEspecialidadeEntity Especialidade)
        {
            var query = _query.InserirEspecialidadeQuery(Especialidade);
        Especialidade.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEspecialidadeEntity Especialidade)
        {
            var query = _query.UpdateEspecialidadeQuery(Especialidade);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEspecialidadeEntity Especialidade)
        {
            var query = _query.DeleteEspecialidadeQuery(Especialidade);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescricao(IEspecialidadeEntity entity)
        {
            var query = _query.UpdateDescricao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IEspecialidadeEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IEspecialidadeEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IEspecialidadeEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IEspecialidadeEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration