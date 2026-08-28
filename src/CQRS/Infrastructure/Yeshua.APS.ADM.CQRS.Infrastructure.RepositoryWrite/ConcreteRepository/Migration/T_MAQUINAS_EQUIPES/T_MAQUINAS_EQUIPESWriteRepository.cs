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

namespace Input.Repository.T_MAQUINAS_EQUIPES
{
    public partial class T_MAQUINAS_EQUIPESWriteRepository : IT_MAQUINAS_EQUIPESWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_MAQUINAS_EQUIPESQueryWrite _query; 

        public T_MAQUINAS_EQUIPESWriteRepository(IUnitOfWork unitOfWork,IT_MAQUINAS_EQUIPESQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES)
        {
            var query = _query.InserirT_MAQUINAS_EQUIPESQuery(T_MAQUINAS_EQUIPES);
        T_MAQUINAS_EQUIPES.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES)
        {
            var query = _query.UpdateT_MAQUINAS_EQUIPESQuery(T_MAQUINAS_EQUIPES);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES)
        {
            var query = _query.DeleteT_MAQUINAS_EQUIPESQuery(T_MAQUINAS_EQUIPES);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int id, string value)
        {
            var query = _query.UpdateMAQ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEQU_ID(int id, string value)
        {
            var query = _query.UpdateEQU_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAL_ID(int id, int value)
        {
            var query = _query.UpdateCAL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(int id, string value)
        {
            var query = _query.UpdateCLI_ID(id, value);
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