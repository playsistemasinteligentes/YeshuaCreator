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

namespace Input.Repository.Recursos
{
    public partial class RecursosWriteRepository : IRecursosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRecursosQueryWrite _query; 

        public RecursosWriteRepository(IUnitOfWork unitOfWork,IRecursosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRecursosEntity Recursos)
        {
            var query = _query.InserirRecursosQuery(Recursos);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IRecursosEntity Recursos)
        {
            var query = _query.UpdateRecursosQuery(Recursos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRecursosEntity Recursos)
        {
            var query = _query.DeleteRecursosQuery(Recursos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREC_DESCRICAO(string rec_id, string value)
        {
            var query = _query.UpdateREC_DESCRICAO(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAL_ID(string rec_id, int value)
        {
            var query = _query.UpdateCAL_ID(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREC_CONTROL_IP(string rec_id, string value)
        {
            var query = _query.UpdateREC_CONTROL_IP(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRE_ID(string rec_id, string value)
        {
            var query = _query.UpdateGRE_ID(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string rec_id, int value)
        {
            var query = _query.UpdateTenantID(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string rec_id, bool value)
        {
            var query = _query.UpdateDeleted(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string rec_id, DateTime value)
        {
            var query = _query.UpdateChanged(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string rec_id, int value)
        {
            var query = _query.UpdateUserId(rec_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration