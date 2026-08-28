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

namespace Input.Repository.T_PREFERENCIAS
{
    public partial class T_PREFERENCIASWriteRepository : IT_PREFERENCIASWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_PREFERENCIASQueryWrite _query; 

        public T_PREFERENCIASWriteRepository(IUnitOfWork unitOfWork,IT_PREFERENCIASQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_PREFERENCIASEntity T_PREFERENCIAS)
        {
            var query = _query.InserirT_PREFERENCIASQuery(T_PREFERENCIAS);
        T_PREFERENCIAS.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_PREFERENCIASEntity T_PREFERENCIAS)
        {
            var query = _query.UpdateT_PREFERENCIASQuery(T_PREFERENCIAS);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_PREFERENCIASEntity T_PREFERENCIAS)
        {
            var query = _query.DeleteT_PREFERENCIASQuery(T_PREFERENCIAS);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRE_ID(int id, int value)
        {
            var query = _query.UpdatePRE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRE_DESCRICAO(int id, string value)
        {
            var query = _query.UpdatePRE_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRE_NAMESPACE(int id, string value)
        {
            var query = _query.UpdatePRE_NAMESPACE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRE_TIPO(int id, string value)
        {
            var query = _query.UpdatePRE_TIPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRE_VALOR(int id, string value)
        {
            var query = _query.UpdatePRE_VALOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int id, int value)
        {
            var query = _query.UpdateUSE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_ID(int id, int value)
        {
            var query = _query.UpdatePER_ID(id, value);
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