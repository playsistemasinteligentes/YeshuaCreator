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

namespace Input.Repository.EstruturaCusto
{
    public partial class EstruturaCustoWriteRepository : IEstruturaCustoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEstruturaCustoQueryWrite _query; 

        public EstruturaCustoWriteRepository(IUnitOfWork unitOfWork,IEstruturaCustoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEstruturaCustoEntity EstruturaCusto)
        {
            var query = _query.InserirEstruturaCustoQuery(EstruturaCusto);
        EstruturaCusto.EST_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEstruturaCustoEntity EstruturaCusto)
        {
            var query = _query.UpdateEstruturaCustoQuery(EstruturaCusto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEstruturaCustoEntity EstruturaCusto)
        {
            var query = _query.DeleteEstruturaCustoQuery(EstruturaCusto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_ID(int est_id, int value)
        {
            var query = _query.UpdateITO_ID(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int est_id, string value)
        {
            var query = _query.UpdateORD_ID(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int est_id, string value)
        {
            var query = _query.UpdatePRO_ID(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_PRODUTO(int est_id, string value)
        {
            var query = _query.UpdatePRO_ID_PRODUTO(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_COMPONENTE(int est_id, string value)
        {
            var query = _query.UpdatePRO_ID_COMPONENTE(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TIPO_CUSTO(int est_id, string value)
        {
            var query = _query.UpdatePRO_TIPO_CUSTO(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_GRUPO_CONTABIL(int est_id, string value)
        {
            var query = _query.UpdatePRO_GRUPO_CONTABIL(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_ORDEM(int est_id, int value)
        {
            var query = _query.UpdateEST_ORDEM(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_GRUPO(int est_id, string value)
        {
            var query = _query.UpdateEST_GRUPO(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_QUANT(int est_id, Decimal value)
        {
            var query = _query.UpdateEST_QUANT(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_VALOR_TOTAL(int est_id, Decimal value)
        {
            var query = _query.UpdateEST_VALOR_TOTAL(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_DATA_BASE(int est_id, string value)
        {
            var query = _query.UpdateEST_DATA_BASE(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_BASE_PRODUCAO(int est_id, Decimal value)
        {
            var query = _query.UpdateEST_BASE_PRODUCAO(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_NIVEL(int est_id, Decimal value)
        {
            var query = _query.UpdateEST_NIVEL(est_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int est_id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(est_id, value);
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