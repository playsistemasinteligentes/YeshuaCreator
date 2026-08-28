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

namespace Input.Repository.T_USER_GRUPO
{
    public partial class T_USER_GRUPOWriteRepository : IT_USER_GRUPOWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_USER_GRUPOQueryWrite _query; 

        public T_USER_GRUPOWriteRepository(IUnitOfWork unitOfWork,IT_USER_GRUPOQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_USER_GRUPOEntity T_USER_GRUPO)
        {
            var query = _query.InserirT_USER_GRUPOQuery(T_USER_GRUPO);
        T_USER_GRUPO.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_USER_GRUPOEntity T_USER_GRUPO)
        {
            var query = _query.UpdateT_USER_GRUPOQuery(T_USER_GRUPO);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_USER_GRUPOEntity T_USER_GRUPO)
        {
            var query = _query.DeleteT_USER_GRUPOQuery(T_USER_GRUPO);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRU_ID(int id, int value)
        {
            var query = _query.UpdateGRU_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateID_USUARIO(int id, int value)
        {
            var query = _query.UpdateID_USUARIO(id, value);
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