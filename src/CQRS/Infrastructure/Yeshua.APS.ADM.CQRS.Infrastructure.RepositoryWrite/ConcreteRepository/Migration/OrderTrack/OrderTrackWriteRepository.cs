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

namespace Input.Repository.OrderTrack
{
    public partial class OrderTrackWriteRepository : IOrderTrackWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IOrderTrackQueryWrite _query; 

        public OrderTrackWriteRepository(IUnitOfWork unitOfWork,IOrderTrackQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IOrderTrackEntity OrderTrack)
        {
            var query = _query.InserirOrderTrackQuery(OrderTrack);
        OrderTrack.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IOrderTrackEntity OrderTrack)
        {
            var query = _query.UpdateOrderTrackQuery(OrderTrack);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IOrderTrackEntity OrderTrack)
        {
            var query = _query.DeleteOrderTrackQuery(OrderTrack);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_ID(int id, int value)
        {
            var query = _query.UpdateOTK_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_SEQUENCIA(int id, Decimal value)
        {
            var query = _query.UpdateOTK_SEQUENCIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_VERSSAO(int id, int value)
        {
            var query = _query.UpdateOTK_VERSSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_EVENTO(int id, string value)
        {
            var query = _query.UpdateOTK_EVENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_DATA_NECESSIDADE_DE(int id, DateTime value)
        {
            var query = _query.UpdateOTK_DATA_NECESSIDADE_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_DATA_NECESSIDADE_ATE(int id, DateTime value)
        {
            var query = _query.UpdateOTK_DATA_NECESSIDADE_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_DATA_PREVISTA(int id, DateTime value)
        {
            var query = _query.UpdateOTK_DATA_PREVISTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_DATA_REALIZADA(int id, DateTime value)
        {
            var query = _query.UpdateOTK_DATA_REALIZADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_ID(int id, int value)
        {
            var query = _query.UpdateFPR_ID(id, value);
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