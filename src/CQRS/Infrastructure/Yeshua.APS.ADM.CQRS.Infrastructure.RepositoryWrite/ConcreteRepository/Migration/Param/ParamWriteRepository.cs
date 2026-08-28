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

namespace Input.Repository.Param
{
    public partial class ParamWriteRepository : IParamWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IParamQueryWrite _query; 

        public ParamWriteRepository(IUnitOfWork unitOfWork,IParamQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IParamEntity Param)
        {
            var query = _query.InserirParamQuery(Param);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IParamEntity Param)
        {
            var query = _query.UpdateParamQuery(Param);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IParamEntity Param)
        {
            var query = _query.DeleteParamQuery(Param);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAR_DESCRICAO(string par_id, string value)
        {
            var query = _query.UpdatePAR_DESCRICAO(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAR_VALOR_S(string par_id, string value)
        {
            var query = _query.UpdatePAR_VALOR_S(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAR_VALOR_N(string par_id, Decimal value)
        {
            var query = _query.UpdatePAR_VALOR_N(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAR_VALOR_D(string par_id, DateTime value)
        {
            var query = _query.UpdatePAR_VALOR_D(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string par_id, int value)
        {
            var query = _query.UpdateTenantID(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string par_id, bool value)
        {
            var query = _query.UpdateDeleted(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string par_id, DateTime value)
        {
            var query = _query.UpdateChanged(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string par_id, int value)
        {
            var query = _query.UpdateUserId(par_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration