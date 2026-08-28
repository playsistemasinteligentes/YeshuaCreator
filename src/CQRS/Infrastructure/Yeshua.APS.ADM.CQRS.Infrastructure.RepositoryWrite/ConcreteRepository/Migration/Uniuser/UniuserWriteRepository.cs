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

namespace Input.Repository.Uniuser
{
    public partial class UniuserWriteRepository : IUniuserWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IUniuserQueryWrite _query; 

        public UniuserWriteRepository(IUnitOfWork unitOfWork,IUniuserQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IUniuserEntity Uniuser)
        {
            var query = _query.InserirUniuserQuery(Uniuser);
        Uniuser.USERGRU_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IUniuserEntity Uniuser)
        {
            var query = _query.UpdateUniuserQuery(Uniuser);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IUniuserEntity Uniuser)
        {
            var query = _query.DeleteUniuserQuery(Uniuser);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ID(int usergru_id, int value)
        {
            var query = _query.UpdateUNI_ID(usergru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int usergru_id, int value)
        {
            var query = _query.UpdateUSE_ID(usergru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int usergru_id, int value)
        {
            var query = _query.UpdateTenantID(usergru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int usergru_id, bool value)
        {
            var query = _query.UpdateDeleted(usergru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int usergru_id, DateTime value)
        {
            var query = _query.UpdateChanged(usergru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int usergru_id, int value)
        {
            var query = _query.UpdateUserId(usergru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration