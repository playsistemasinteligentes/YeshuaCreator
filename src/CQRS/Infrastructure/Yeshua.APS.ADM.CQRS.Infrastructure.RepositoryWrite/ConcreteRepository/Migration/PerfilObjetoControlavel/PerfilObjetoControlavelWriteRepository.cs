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

namespace Input.Repository.PerfilObjetoControlavel
{
    public partial class PerfilObjetoControlavelWriteRepository : IPerfilObjetoControlavelWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPerfilObjetoControlavelQueryWrite _query; 

        public PerfilObjetoControlavelWriteRepository(IUnitOfWork unitOfWork,IPerfilObjetoControlavelQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPerfilObjetoControlavelEntity PerfilObjetoControlavel)
        {
            var query = _query.InserirPerfilObjetoControlavelQuery(PerfilObjetoControlavel);
        PerfilObjetoControlavel.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPerfilObjetoControlavelEntity PerfilObjetoControlavel)
        {
            var query = _query.UpdatePerfilObjetoControlavelQuery(PerfilObjetoControlavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPerfilObjetoControlavelEntity PerfilObjetoControlavel)
        {
            var query = _query.DeletePerfilObjetoControlavelQuery(PerfilObjetoControlavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_ID(int id, int value)
        {
            var query = _query.UpdatePER_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBJ_ID(int id, string value)
        {
            var query = _query.UpdateOBJ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePEO_ACAO(int id, string value)
        {
            var query = _query.UpdatePEO_ACAO(id, value);
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