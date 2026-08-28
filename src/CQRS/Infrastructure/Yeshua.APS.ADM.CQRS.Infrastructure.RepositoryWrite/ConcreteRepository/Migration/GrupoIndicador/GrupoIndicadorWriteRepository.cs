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

namespace Input.Repository.GrupoIndicador
{
    public partial class GrupoIndicadorWriteRepository : IGrupoIndicadorWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IGrupoIndicadorQueryWrite _query; 

        public GrupoIndicadorWriteRepository(IUnitOfWork unitOfWork,IGrupoIndicadorQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IGrupoIndicadorEntity GrupoIndicador)
        {
            var query = _query.InserirGrupoIndicadorQuery(GrupoIndicador);
        GrupoIndicador.GRU_IND_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IGrupoIndicadorEntity GrupoIndicador)
        {
            var query = _query.UpdateGrupoIndicadorQuery(GrupoIndicador);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IGrupoIndicadorEntity GrupoIndicador)
        {
            var query = _query.DeleteGrupoIndicadorQuery(GrupoIndicador);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRU_ID(int gru_ind_id, int value)
        {
            var query = _query.UpdateGRU_ID(gru_ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_ID(int gru_ind_id, int value)
        {
            var query = _query.UpdateIND_ID(gru_ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int gru_ind_id, int value)
        {
            var query = _query.UpdateTenantID(gru_ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int gru_ind_id, bool value)
        {
            var query = _query.UpdateDeleted(gru_ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int gru_ind_id, DateTime value)
        {
            var query = _query.UpdateChanged(gru_ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int gru_ind_id, int value)
        {
            var query = _query.UpdateUserId(gru_ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration