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

namespace Input.Repository.yUserGrant
{
    public class yUserGrantWriteRepository : IyUserGrantWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyUserGrantQueryWrite _query; 

        public yUserGrantWriteRepository(IUnitOfWork unitOfWork,IyUserGrantQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyUserGrantEntity yUserGrant)
        {
            var query = _query.InseriryUserGrantQuery(yUserGrant);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IyUserGrantEntity yUserGrant)
        {
            var query = _query.UpdateyUserGrantQuery(yUserGrant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyUserGrantEntity yUserGrant)
        {
            var query = _query.DeleteyUserGrantQuery(yUserGrant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePerfilId(IyUserGrantEntity entity)
        {
            var query = _query.UpdatePerfilId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrantId(IyUserGrantEntity entity)
        {
            var query = _query.UpdateGrantId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrant(IyUserGrantEntity entity)
        {
            var query = _query.UpdateGrant(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreate(IyUserGrantEntity entity)
        {
            var query = _query.UpdateCreate(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRead(IyUserGrantEntity entity)
        {
            var query = _query.UpdateRead(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUpdate(IyUserGrantEntity entity)
        {
            var query = _query.UpdateUpdate(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDelete(IyUserGrantEntity entity)
        {
            var query = _query.UpdateDelete(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidUntil(IyUserGrantEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyUserGrantEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyUserGrantEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyUserGrantEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyUserGrantEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration