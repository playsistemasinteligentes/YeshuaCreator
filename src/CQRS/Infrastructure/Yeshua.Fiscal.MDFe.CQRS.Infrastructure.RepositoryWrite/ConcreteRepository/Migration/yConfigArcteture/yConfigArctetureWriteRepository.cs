// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

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
    public partial class yConfigArctetureWriteRepository : IyConfigArctetureWriteRepository
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
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IyConfigArctetureEntity yConfigArcteture)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateyConfigArctetureQuery(yConfigArcteture);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyConfigArctetureEntity yConfigArcteture)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.DeleteyConfigArctetureQuery(yConfigArcteture);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAuditTrackerActived(int id, int value)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateAuditTrackerActived(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAuditCRUDActived(int id, int value)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateAuditCRUDActived(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            _cacheService.RemoveByPrefix("yConfigArcteture");
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration