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
        public void UpdateTenantID(int id, int value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailSmtpClient(int id, string value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailSmtpClient(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailPort(int id, int value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailPort(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailUserName(int id, string value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailUserName(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmailPassword(int id, string value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateEmailPassword(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            _cacheService.RemoveByPrefix("yConfigNotification");
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration