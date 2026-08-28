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

namespace Input.Repository.EstruturaImpressao
{
    public partial class EstruturaImpressaoWriteRepository : IEstruturaImpressaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEstruturaImpressaoQueryWrite _query; 

        public EstruturaImpressaoWriteRepository(IUnitOfWork unitOfWork,IEstruturaImpressaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEstruturaImpressaoEntity EstruturaImpressao)
        {
            var query = _query.InserirEstruturaImpressaoQuery(EstruturaImpressao);
        EstruturaImpressao.EST_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEstruturaImpressaoEntity EstruturaImpressao)
        {
            var query = _query.UpdateEstruturaImpressaoQuery(EstruturaImpressao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEstruturaImpressaoEntity EstruturaImpressao)
        {
            var query = _query.DeleteEstruturaImpressaoQuery(EstruturaImpressao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHTML_ESTRUTURA(int est_id, string value)
        {
            var query = _query.UpdateHTML_ESTRUTURA(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(int est_id, string value)
        {
            var query = _query.UpdateCLI_ID(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_DESCRICAO(int est_id, string value)
        {
            var query = _query.UpdateEST_DESCRICAO(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int est_id, int value)
        {
            var query = _query.UpdateTenantID(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int est_id, bool value)
        {
            var query = _query.UpdateDeleted(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int est_id, DateTime value)
        {
            var query = _query.UpdateChanged(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int est_id, int value)
        {
            var query = _query.UpdateUserId(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration