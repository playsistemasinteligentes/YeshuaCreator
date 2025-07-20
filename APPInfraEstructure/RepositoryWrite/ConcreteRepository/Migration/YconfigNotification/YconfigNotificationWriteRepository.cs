using Dapper;
using Dominio.Entitys;
using Input.Querys.YconfigNotification;
using IRepository.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.YconfigNotification
{
    public class YconfigNotificationWriteRepository : IYconfigNotificationWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICacheService<object> _cacheService;

        public YconfigNotificationWriteRepository(IUnitOfWork unitOfWork, ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
        }

        public void Insert(IYconfigNotificationEntity YconfigNotification)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = new YconfigNotificationWriteQuery().InserirYconfigNotificationQuery(YconfigNotification);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYconfigNotificationEntity YconfigNotification)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = new YconfigNotificationWriteQuery().UpdateYconfigNotificationQuery(YconfigNotification);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYconfigNotificationEntity YconfigNotification)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = new YconfigNotificationWriteQuery().DeleteYconfigNotificationQuery(YconfigNotification);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailAdress(IYconfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = new YconfigNotificationWriteQuery().UpdateEmailAdress(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailPassword(IYconfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = new YconfigNotificationWriteQuery().UpdateEmailPassword(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IYconfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = new YconfigNotificationWriteQuery().UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration