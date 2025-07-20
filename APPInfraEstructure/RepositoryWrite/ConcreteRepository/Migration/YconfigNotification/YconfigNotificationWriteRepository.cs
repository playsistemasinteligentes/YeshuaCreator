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

namespace Input.Repository.YconfigNotification
{
    public class YconfigNotificationWriteRepository : IYconfigNotificationWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYconfigNotificationQueryWrite _query; 
        private readonly ICacheService<object> _cacheService;

        public YconfigNotificationWriteRepository(IUnitOfWork unitOfWork, IYconfigNotificationQueryWrite query,ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
             _query = query;
        }

        public void Insert(IYconfigNotificationEntity YconfigNotification)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = _query.InserirYconfigNotificationQuery(YconfigNotification);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYconfigNotificationEntity YconfigNotification)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = _query.UpdateYconfigNotificationQuery(YconfigNotification);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYconfigNotificationEntity YconfigNotification)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = _query.DeleteYconfigNotificationQuery(YconfigNotification);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailAdress(IYconfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = _query.UpdateEmailAdress(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmailPassword(IYconfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = _query.UpdateEmailPassword(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IYconfigNotificationEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigNotification");
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration