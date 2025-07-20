using Dapper;
using Dominio.Entitys;
using Input.Querys.YconfigArcteture;
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

namespace Input.Repository.YconfigArcteture
{
    public class YconfigArctetureWriteRepository : IYconfigArctetureWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICacheService<object> _cacheService;

        public YconfigArctetureWriteRepository(IUnitOfWork unitOfWork, ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
        }

        public void Insert(IYconfigArctetureEntity YconfigArcteture)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = new YconfigArctetureWriteQuery().InserirYconfigArctetureQuery(YconfigArcteture);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYconfigArctetureEntity YconfigArcteture)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = new YconfigArctetureWriteQuery().UpdateYconfigArctetureQuery(YconfigArcteture);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYconfigArctetureEntity YconfigArcteture)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = new YconfigArctetureWriteQuery().DeleteYconfigArctetureQuery(YconfigArcteture);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditTrackerActived(IYconfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = new YconfigArctetureWriteQuery().UpdateAuditTrackerActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditCRUDActived(IYconfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = new YconfigArctetureWriteQuery().UpdateAuditCRUDActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IYconfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = new YconfigArctetureWriteQuery().UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration