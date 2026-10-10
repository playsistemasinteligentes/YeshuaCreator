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

namespace Input.Repository.yTenantApplication
{
    public partial class yTenantApplicationWriteRepository : IyTenantApplicationWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyTenantApplicationQueryWrite _query; 

        public yTenantApplicationWriteRepository(IUnitOfWork unitOfWork,IyTenantApplicationQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyTenantApplicationEntity yTenantApplication)
        {
            var query = _query.InseriryTenantApplicationQuery(yTenantApplication);
        yTenantApplication.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyTenantApplicationEntity yTenantApplication)
        {
            var query = _query.UpdateyTenantApplicationQuery(yTenantApplication);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyTenantApplicationEntity yTenantApplication)
        {
            var query = _query.DeleteyTenantApplicationQuery(yTenantApplication);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateApplicationKey(int id, string value)
        {
            var query = _query.UpdateApplicationKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidUntil(int id, DateTime value)
        {
            var query = _query.UpdateValidUntil(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperationalEntityId(int id, string value)
        {
            var query = _query.UpdateOperationalEntityId(id, value);
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
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration