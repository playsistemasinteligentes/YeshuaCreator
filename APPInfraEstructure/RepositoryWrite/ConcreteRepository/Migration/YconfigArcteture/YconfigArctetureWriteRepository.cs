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

namespace Input.Repository.yConfigArcteture
{
    public class yConfigArctetureWriteRepository : IyConfigArctetureWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyConfigArctetureQueryWrite _query; 
        private readonly ICacheService<object> _cacheService;

        public yConfigArctetureWriteRepository(IUnitOfWork unitOfWork, IyConfigArctetureQueryWrite query,ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
             _query = query;
        }

        public void Insert(IyConfigArctetureEntity yConfigArcteture)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.InseriryConfigArctetureQuery(yConfigArcteture);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IyConfigArctetureEntity yConfigArcteture)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateyConfigArctetureQuery(yConfigArcteture);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IyConfigArctetureEntity yConfigArcteture)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.DeleteyConfigArctetureQuery(yConfigArcteture);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditTrackerActived(IyConfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateAuditTrackerActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditCRUDActived(IyConfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateAuditCRUDActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IyConfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IyConfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IyConfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IyConfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration