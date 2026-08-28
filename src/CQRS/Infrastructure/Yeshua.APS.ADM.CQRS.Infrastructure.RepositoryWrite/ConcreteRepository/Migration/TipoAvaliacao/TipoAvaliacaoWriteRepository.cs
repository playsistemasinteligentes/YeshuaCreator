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

namespace Input.Repository.TipoAvaliacao
{
    public partial class TipoAvaliacaoWriteRepository : ITipoAvaliacaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoAvaliacaoQueryWrite _query; 

        public TipoAvaliacaoWriteRepository(IUnitOfWork unitOfWork,ITipoAvaliacaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoAvaliacaoEntity TipoAvaliacao)
        {
            var query = _query.InserirTipoAvaliacaoQuery(TipoAvaliacao);
        TipoAvaliacao.TA_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITipoAvaliacaoEntity TipoAvaliacao)
        {
            var query = _query.UpdateTipoAvaliacaoQuery(TipoAvaliacao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoAvaliacaoEntity TipoAvaliacao)
        {
            var query = _query.DeleteTipoAvaliacaoQuery(TipoAvaliacao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTA_DESC(int ta_id, string value)
        {
            var query = _query.UpdateTA_DESC(ta_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int ta_id, int value)
        {
            var query = _query.UpdateTenantID(ta_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int ta_id, bool value)
        {
            var query = _query.UpdateDeleted(ta_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int ta_id, DateTime value)
        {
            var query = _query.UpdateChanged(ta_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int ta_id, int value)
        {
            var query = _query.UpdateUserId(ta_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration