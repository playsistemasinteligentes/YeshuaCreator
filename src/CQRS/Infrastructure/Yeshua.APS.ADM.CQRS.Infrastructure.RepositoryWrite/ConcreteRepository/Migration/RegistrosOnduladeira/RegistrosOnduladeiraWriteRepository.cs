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

namespace Input.Repository.RegistrosOnduladeira
{
    public partial class RegistrosOnduladeiraWriteRepository : IRegistrosOnduladeiraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRegistrosOnduladeiraQueryWrite _query; 

        public RegistrosOnduladeiraWriteRepository(IUnitOfWork unitOfWork,IRegistrosOnduladeiraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRegistrosOnduladeiraEntity RegistrosOnduladeira)
        {
            var query = _query.InserirRegistrosOnduladeiraQuery(RegistrosOnduladeira);
        RegistrosOnduladeira.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRegistrosOnduladeiraEntity RegistrosOnduladeira)
        {
            var query = _query.UpdateRegistrosOnduladeiraQuery(RegistrosOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRegistrosOnduladeiraEntity RegistrosOnduladeira)
        {
            var query = _query.DeleteRegistrosOnduladeiraQuery(RegistrosOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREG_ID(int id, int value)
        {
            var query = _query.UpdateREG_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREG_RESPOSTA(int id, string value)
        {
            var query = _query.UpdateREG_RESPOSTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREG_STATUS(int id, string value)
        {
            var query = _query.UpdateREG_STATUS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREG_DATA_INICIO(int id, DateTime value)
        {
            var query = _query.UpdateREG_DATA_INICIO(id, value);
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