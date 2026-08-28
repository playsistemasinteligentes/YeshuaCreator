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

namespace Input.Repository.UsuarioObjetoControlavel
{
    public partial class UsuarioObjetoControlavelWriteRepository : IUsuarioObjetoControlavelWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IUsuarioObjetoControlavelQueryWrite _query; 

        public UsuarioObjetoControlavelWriteRepository(IUnitOfWork unitOfWork,IUsuarioObjetoControlavelQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IUsuarioObjetoControlavelEntity UsuarioObjetoControlavel)
        {
            var query = _query.InserirUsuarioObjetoControlavelQuery(UsuarioObjetoControlavel);
        UsuarioObjetoControlavel.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IUsuarioObjetoControlavelEntity UsuarioObjetoControlavel)
        {
            var query = _query.UpdateUsuarioObjetoControlavelQuery(UsuarioObjetoControlavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IUsuarioObjetoControlavelEntity UsuarioObjetoControlavel)
        {
            var query = _query.DeleteUsuarioObjetoControlavelQuery(UsuarioObjetoControlavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int id, int value)
        {
            var query = _query.UpdateUSE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBJ_ID(int id, string value)
        {
            var query = _query.UpdateOBJ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSU_OBJETO_ACAO(int id, string value)
        {
            var query = _query.UpdateUSU_OBJETO_ACAO(id, value);
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