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

namespace Input.Repository.yPerfilGrant
{
    public partial class yPerfilGrantWriteRepository : IyPerfilGrantWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyPerfilGrantQueryWrite _query; 

        public yPerfilGrantWriteRepository(IUnitOfWork unitOfWork,IyPerfilGrantQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyPerfilGrantEntity yPerfilGrant)
        {
            var query = _query.InseriryPerfilGrantQuery(yPerfilGrant);
        yPerfilGrant.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyPerfilGrantEntity yPerfilGrant)
        {
            var query = _query.UpdateyPerfilGrantQuery(yPerfilGrant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyPerfilGrantEntity yPerfilGrant)
        {
            var query = _query.DeleteyPerfilGrantQuery(yPerfilGrant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePerfilId(int id, int value)
        {
            var query = _query.UpdatePerfilId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrantId(int id, string value)
        {
            var query = _query.UpdateGrantId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCanGrant(int id, bool value)
        {
            var query = _query.UpdateCanGrant(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCanCreate(int id, bool value)
        {
            var query = _query.UpdateCanCreate(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCanRead(int id, bool value)
        {
            var query = _query.UpdateCanRead(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCanUpdate(int id, bool value)
        {
            var query = _query.UpdateCanUpdate(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCanDelete(int id, bool value)
        {
            var query = _query.UpdateCanDelete(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidUntil(int id, DateTime value)
        {
            var query = _query.UpdateValidUntil(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
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