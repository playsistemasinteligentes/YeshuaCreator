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

namespace Input.Repository.RespInspVisual
{
    public partial class RespInspVisualWriteRepository : IRespInspVisualWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRespInspVisualQueryWrite _query; 

        public RespInspVisualWriteRepository(IUnitOfWork unitOfWork,IRespInspVisualQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRespInspVisualEntity RespInspVisual)
        {
            var query = _query.InserirRespInspVisualQuery(RespInspVisual);
        RespInspVisual.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRespInspVisualEntity RespInspVisual)
        {
            var query = _query.UpdateRespInspVisualQuery(RespInspVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRespInspVisualEntity RespInspVisual)
        {
            var query = _query.DeleteRespInspVisualQuery(RespInspVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRIV_ID(int id, int value)
        {
            var query = _query.UpdateRIV_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_ID(int id, int value)
        {
            var query = _query.UpdateIPV_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITI_ID(int id, int value)
        {
            var query = _query.UpdateITI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRIV_STATUS(int id, string value)
        {
            var query = _query.UpdateRIV_STATUS(id, value);
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