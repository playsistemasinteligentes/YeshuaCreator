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

namespace Input.Repository.yConfigNotification
{
    public class yConfigNotificationWriteRepository : IyConfigNotificationWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyConfigNotificationQueryWrite _query; 
        private readonly ICacheService<object> _cacheService;

        public yConfigNotificationWriteRepository(IUnitOfWork unitOfWork, IyConfigNotificationQueryWrite query,ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
             _query = query;
        }

        public void Insert(IyConfigNotificationEntity yConfigNotification)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.InseriryConfigNotificationQuery(yConfigNotification);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IyConfigNotificationEntity yConfigNotification)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateyConfigNotificationQuery(yConfigNotification);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IyConfigNotificationEntity yConfigNotification)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.DeleteyConfigNotificationQuery(yConfigNotification);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailSmtpClient(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailSmtpClient(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailPort(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailPort(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailUserName(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailUserName(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailPassword(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailPassword(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration