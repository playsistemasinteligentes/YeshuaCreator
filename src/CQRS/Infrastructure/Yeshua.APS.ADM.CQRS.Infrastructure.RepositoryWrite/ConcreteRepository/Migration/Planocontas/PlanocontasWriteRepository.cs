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

namespace Input.Repository.Planocontas
{
    public partial class PlanocontasWriteRepository : IPlanocontasWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPlanocontasQueryWrite _query; 

        public PlanocontasWriteRepository(IUnitOfWork unitOfWork,IPlanocontasQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPlanocontasEntity Planocontas)
        {
            var query = _query.InserirPlanocontasQuery(Planocontas);
        Planocontas.PLA_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPlanocontasEntity Planocontas)
        {
            var query = _query.UpdatePlanocontasQuery(Planocontas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPlanocontasEntity Planocontas)
        {
            var query = _query.DeletePlanocontasQuery(Planocontas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_CODIGO(int pla_id, string value)
        {
            var query = _query.UpdatePLA_CODIGO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_DESCRICAO(int pla_id, string value)
        {
            var query = _query.UpdatePLA_DESCRICAO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_TIPO(int pla_id, int value)
        {
            var query = _query.UpdatePLA_TIPO(pla_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLA_NATUREZA(int pla_id, string value)
        {
            var query = _query.UpdatePLA_NATUREZA(pla_id, value);
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