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

namespace Input.Repository.ParametrosDeCusto
{
    public partial class ParametrosDeCustoWriteRepository : IParametrosDeCustoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IParametrosDeCustoQueryWrite _query; 

        public ParametrosDeCustoWriteRepository(IUnitOfWork unitOfWork,IParametrosDeCustoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IParametrosDeCustoEntity ParametrosDeCusto)
        {
            var query = _query.InserirParametrosDeCustoQuery(ParametrosDeCusto);
        ParametrosDeCusto.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IParametrosDeCustoEntity ParametrosDeCusto)
        {
            var query = _query.UpdateParametrosDeCustoQuery(ParametrosDeCusto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IParametrosDeCustoEntity ParametrosDeCusto)
        {
            var query = _query.DeleteParametrosDeCustoQuery(ParametrosDeCusto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAR_ID(int id, int value)
        {
            var query = _query.UpdatePAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int id, string value)
        {
            var query = _query.UpdatePRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCUS_ID(int id, string value)
        {
            var query = _query.UpdateCUS_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAR_VALOR(int id, string value)
        {
            var query = _query.UpdatePAR_VALOR(id, value);
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