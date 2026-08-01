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
        public void UpdateDescription(string id, string value)
        {
            var query = _query.UpdateDescription(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration