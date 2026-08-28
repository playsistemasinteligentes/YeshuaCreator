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

namespace Input.Repository.ObjetoControlavel
{
    public partial class ObjetoControlavelWriteRepository : IObjetoControlavelWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IObjetoControlavelQueryWrite _query; 

        public ObjetoControlavelWriteRepository(IUnitOfWork unitOfWork,IObjetoControlavelQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IObjetoControlavelEntity ObjetoControlavel)
        {
            var query = _query.InserirObjetoControlavelQuery(ObjetoControlavel);
        ObjetoControlavel.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IObjetoControlavelEntity ObjetoControlavel)
        {
            var query = _query.UpdateObjetoControlavelQuery(ObjetoControlavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IObjetoControlavelEntity ObjetoControlavel)
        {
            var query = _query.DeleteObjetoControlavelQuery(ObjetoControlavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBJ_ID(int id, string value)
        {
            var query = _query.UpdateOBJ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBJ_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateOBJ_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBJ_TIPO(int id, string value)
        {
            var query = _query.UpdateOBJ_TIPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBJ_GRUPO(int id, string value)
        {
            var query = _query.UpdateOBJ_GRUPO(id, value);
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