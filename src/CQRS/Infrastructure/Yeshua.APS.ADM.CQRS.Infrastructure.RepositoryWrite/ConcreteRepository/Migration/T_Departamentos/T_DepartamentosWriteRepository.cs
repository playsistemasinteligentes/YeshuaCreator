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

namespace Input.Repository.T_Departamentos
{
    public partial class T_DepartamentosWriteRepository : IT_DepartamentosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_DepartamentosQueryWrite _query; 

        public T_DepartamentosWriteRepository(IUnitOfWork unitOfWork,IT_DepartamentosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_DepartamentosEntity T_Departamentos)
        {
            var query = _query.InserirT_DepartamentosQuery(T_Departamentos);
        T_Departamentos.DEP_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_DepartamentosEntity T_Departamentos)
        {
            var query = _query.UpdateT_DepartamentosQuery(T_Departamentos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_DepartamentosEntity T_Departamentos)
        {
            var query = _query.DeleteT_DepartamentosQuery(T_Departamentos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDEP_NOME(int dep_id, string value)
        {
            var query = _query.UpdateDEP_NOME(dep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int dep_id, int value)
        {
            var query = _query.UpdateTenantID(dep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int dep_id, bool value)
        {
            var query = _query.UpdateDeleted(dep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int dep_id, DateTime value)
        {
            var query = _query.UpdateChanged(dep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int dep_id, int value)
        {
            var query = _query.UpdateUserId(dep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration