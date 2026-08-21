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

namespace Input.Repository.PlanoConta
{
    public partial class PlanoContaWriteRepository : IPlanoContaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPlanoContaQueryWrite _query; 

        public PlanoContaWriteRepository(IUnitOfWork unitOfWork,IPlanoContaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPlanoContaEntity PlanoConta)
        {
            var query = _query.InserirPlanoContaQuery(PlanoConta);
        PlanoConta.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPlanoContaEntity PlanoConta)
        {
            var query = _query.UpdatePlanoContaQuery(PlanoConta);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPlanoContaEntity PlanoConta)
        {
            var query = _query.DeletePlanoContaQuery(PlanoConta);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCodigo(int id, string value)
        {
            var query = _query.UpdateCodigo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(int id, string value)
        {
            var query = _query.UpdateNome(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipo(int id, int value)
        {
            var query = _query.UpdateTipo(id, value);
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