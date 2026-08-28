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

namespace Input.Repository.IndicadoresDepartamentos
{
    public partial class IndicadoresDepartamentosWriteRepository : IIndicadoresDepartamentosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IIndicadoresDepartamentosQueryWrite _query; 

        public IndicadoresDepartamentosWriteRepository(IUnitOfWork unitOfWork,IIndicadoresDepartamentosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IIndicadoresDepartamentosEntity IndicadoresDepartamentos)
        {
            var query = _query.InserirIndicadoresDepartamentosQuery(IndicadoresDepartamentos);
        IndicadoresDepartamentos.INDDEP_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IIndicadoresDepartamentosEntity IndicadoresDepartamentos)
        {
            var query = _query.UpdateIndicadoresDepartamentosQuery(IndicadoresDepartamentos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IIndicadoresDepartamentosEntity IndicadoresDepartamentos)
        {
            var query = _query.DeleteIndicadoresDepartamentosQuery(IndicadoresDepartamentos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDEP_ID(int inddep_id, int value)
        {
            var query = _query.UpdateDEP_ID(inddep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_ID(int inddep_id, int value)
        {
            var query = _query.UpdateIND_ID(inddep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int inddep_id, int value)
        {
            var query = _query.UpdateTenantID(inddep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int inddep_id, bool value)
        {
            var query = _query.UpdateDeleted(inddep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int inddep_id, DateTime value)
        {
            var query = _query.UpdateChanged(inddep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int inddep_id, int value)
        {
            var query = _query.UpdateUserId(inddep_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration