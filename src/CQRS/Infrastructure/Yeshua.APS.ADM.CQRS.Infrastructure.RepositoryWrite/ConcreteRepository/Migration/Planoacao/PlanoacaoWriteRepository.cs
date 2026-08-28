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

namespace Input.Repository.Planoacao
{
    public partial class PlanoacaoWriteRepository : IPlanoacaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPlanoacaoQueryWrite _query; 

        public PlanoacaoWriteRepository(IUnitOfWork unitOfWork,IPlanoacaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPlanoacaoEntity Planoacao)
        {
            var query = _query.InserirPlanoacaoQuery(Planoacao);
        Planoacao.PLA_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPlanoacaoEntity Planoacao)
        {
            var query = _query.UpdatePlanoacaoQuery(Planoacao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPlanoacaoEntity Planoacao)
        {
            var query = _query.DeletePlanoacaoQuery(Planoacao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_DESCRICAO(int pla_id, string value)
        {
            var query = _query.UpdatePLA_DESCRICAO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_ID(int pla_id, int value)
        {
            var query = _query.UpdateMET_ID(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_STATUS(int pla_id, string value)
        {
            var query = _query.UpdatePLA_STATUS(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_DATA(int pla_id, DateTime value)
        {
            var query = _query.UpdatePLA_DATA(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_METAPERIODO(int pla_id, string value)
        {
            var query = _query.UpdatePLA_METAPERIODO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_VLRPERIODO(int pla_id, string value)
        {
            var query = _query.UpdatePLA_VLRPERIODO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_METACULADO(int pla_id, string value)
        {
            var query = _query.UpdatePLA_METACULADO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_VLRACUMULADO(int pla_id, string value)
        {
            var query = _query.UpdatePLA_VLRACUMULADO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_REFERENCIA(int pla_id, string value)
        {
            var query = _query.UpdatePLA_REFERENCIA(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int pla_id, int value)
        {
            var query = _query.UpdateUSE_ID(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int pla_id, int value)
        {
            var query = _query.UpdateTenantID(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int pla_id, bool value)
        {
            var query = _query.UpdateDeleted(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int pla_id, DateTime value)
        {
            var query = _query.UpdateChanged(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int pla_id, int value)
        {
            var query = _query.UpdateUserId(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration