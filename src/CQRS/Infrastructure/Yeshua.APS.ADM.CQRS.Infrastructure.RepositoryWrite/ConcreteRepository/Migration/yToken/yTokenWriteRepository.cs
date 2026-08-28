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

namespace Input.Repository.yToken
{
    public partial class yTokenWriteRepository : IyTokenWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyTokenQueryWrite _query; 

        public yTokenWriteRepository(IUnitOfWork unitOfWork,IyTokenQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyTokenEntity yToken)
        {
            var query = _query.InseriryTokenQuery(yToken);
        yToken.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyTokenEntity yToken)
        {
            var query = _query.UpdateyTokenQuery(yToken);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyTokenEntity yToken)
        {
            var query = _query.DeleteyTokenQuery(yToken);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTokenHash(int id, string value)
        {
            var query = _query.UpdateTokenHash(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescription(int id, string value)
        {
            var query = _query.UpdateDescription(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateConnectorKey(int id, string value)
        {
            var query = _query.UpdateConnectorKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateActive(int id, bool value)
        {
            var query = _query.UpdateActive(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidUntil(int id, DateTime value)
        {
            var query = _query.UpdateValidUntil(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreatedAt(int id, DateTime value)
        {
            var query = _query.UpdateCreatedAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLastUsedAt(int id, DateTime value)
        {
            var query = _query.UpdateLastUsedAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration