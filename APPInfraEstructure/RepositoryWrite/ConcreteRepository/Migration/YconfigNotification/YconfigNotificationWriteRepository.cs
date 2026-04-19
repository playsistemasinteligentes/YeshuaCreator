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
    public partial class yConfigNotificationWriteRepository : IyConfigNotificationWriteRepository
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
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IyConfigNotificationEntity yConfigNotification)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateyConfigNotificationQuery(yConfigNotification);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyConfigNotificationEntity yConfigNotification)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.DeleteyConfigNotificationQuery(yConfigNotification);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailSmtpClient(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailSmtpClient(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailPort(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailPort(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailUserName(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailUserName(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailPassword(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailPassword(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyConfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration