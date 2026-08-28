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

namespace Input.Repository.GrupoRecurso
{
    public partial class GrupoRecursoWriteRepository : IGrupoRecursoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IGrupoRecursoQueryWrite _query; 

        public GrupoRecursoWriteRepository(IUnitOfWork unitOfWork,IGrupoRecursoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IGrupoRecursoEntity GrupoRecurso)
        {
            var query = _query.InserirGrupoRecursoQuery(GrupoRecurso);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IGrupoRecursoEntity GrupoRecurso)
        {
            var query = _query.UpdateGrupoRecursoQuery(GrupoRecurso);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IGrupoRecursoEntity GrupoRecurso)
        {
            var query = _query.DeleteGrupoRecursoQuery(GrupoRecurso);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRE_DESCRICAO(string gre_id, string value)
        {
            var query = _query.UpdateGRE_DESCRICAO(gre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string gre_id, int value)
        {
            var query = _query.UpdateTenantID(gre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string gre_id, bool value)
        {
            var query = _query.UpdateDeleted(gre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string gre_id, DateTime value)
        {
            var query = _query.UpdateChanged(gre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string gre_id, int value)
        {
            var query = _query.UpdateUserId(gre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration