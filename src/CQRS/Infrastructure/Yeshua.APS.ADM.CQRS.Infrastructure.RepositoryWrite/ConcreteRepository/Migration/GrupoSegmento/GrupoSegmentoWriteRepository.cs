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

namespace Input.Repository.GrupoSegmento
{
    public partial class GrupoSegmentoWriteRepository : IGrupoSegmentoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IGrupoSegmentoQueryWrite _query; 

        public GrupoSegmentoWriteRepository(IUnitOfWork unitOfWork,IGrupoSegmentoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IGrupoSegmentoEntity GrupoSegmento)
        {
            var query = _query.InserirGrupoSegmentoQuery(GrupoSegmento);
        GrupoSegmento.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IGrupoSegmentoEntity GrupoSegmento)
        {
            var query = _query.UpdateGrupoSegmentoQuery(GrupoSegmento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IGrupoSegmentoEntity GrupoSegmento)
        {
            var query = _query.DeleteGrupoSegmentoQuery(GrupoSegmento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRS_ID(int id, string value)
        {
            var query = _query.UpdateGRS_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRS_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateGRS_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRS_INTEGRACAO_ERP(int id, string value)
        {
            var query = _query.UpdateGRS_INTEGRACAO_ERP(id, value);
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