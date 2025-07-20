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

namespace Input.Repository.YconfigArcteture
{
    public class YconfigArctetureWriteRepository : IYconfigArctetureWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYconfigArctetureQueryWrite _query; 
        private readonly ICacheService<object> _cacheService;

        public YconfigArctetureWriteRepository(IUnitOfWork unitOfWork, IYconfigArctetureQueryWrite query,ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
             _query = query;
        }

        public void Insert(IYconfigArctetureEntity YconfigArcteture)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = _query.InserirYconfigArctetureQuery(YconfigArcteture);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYconfigArctetureEntity YconfigArcteture)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = _query.UpdateYconfigArctetureQuery(YconfigArcteture);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYconfigArctetureEntity YconfigArcteture)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = _query.DeleteYconfigArctetureQuery(YconfigArcteture);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditTrackerActived(IYconfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = _query.UpdateAuditTrackerActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditCRUDActived(IYconfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = _query.UpdateAuditCRUDActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IYconfigArctetureEntity entity)
        {
            _cacheService.RemoveByPrefix("YconfigArcteture");
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration