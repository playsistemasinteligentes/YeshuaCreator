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

namespace Input.Repository.yGrant
{
    public partial class yGrantWriteRepository : IyGrantWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyGrantQueryWrite _query; 

        public yGrantWriteRepository(IUnitOfWork unitOfWork,IyGrantQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyGrantEntity yGrant)
        {
            var query = _query.InseriryGrantQuery(yGrant);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IyGrantEntity yGrant)
        {
            var query = _query.UpdateyGrantQuery(yGrant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyGrantEntity yGrant)
        {
            var query = _query.DeleteyGrantQuery(yGrant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescription(IyGrantEntity entity)
        {
            var query = _query.UpdateDescription(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyGrantEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyGrantEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyGrantEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyGrantEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration