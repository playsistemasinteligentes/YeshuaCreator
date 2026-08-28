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

namespace Input.Repository.ResultMedida
{
    public partial class ResultMedidaWriteRepository : IResultMedidaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IResultMedidaQueryWrite _query; 

        public ResultMedidaWriteRepository(IUnitOfWork unitOfWork,IResultMedidaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IResultMedidaEntity ResultMedida)
        {
            var query = _query.InserirResultMedidaQuery(ResultMedida);
        ResultMedida.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IResultMedidaEntity ResultMedida)
        {
            var query = _query.UpdateResultMedidaQuery(ResultMedida);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IResultMedidaEntity ResultMedida)
        {
            var query = _query.DeleteResultMedidaQuery(ResultMedida);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRSM_ID(int id, int value)
        {
            var query = _query.UpdateRSM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRL_ID(int id, int value)
        {
            var query = _query.UpdateRL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDT_ID(int id, int value)
        {
            var query = _query.UpdateMDT_ID(id, value);
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