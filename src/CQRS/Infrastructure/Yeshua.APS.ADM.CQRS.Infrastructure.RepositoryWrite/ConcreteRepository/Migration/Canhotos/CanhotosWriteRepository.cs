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

namespace Input.Repository.Canhotos
{
    public partial class CanhotosWriteRepository : ICanhotosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICanhotosQueryWrite _query; 

        public CanhotosWriteRepository(IUnitOfWork unitOfWork,ICanhotosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICanhotosEntity Canhotos)
        {
            var query = _query.InserirCanhotosQuery(Canhotos);
        Canhotos.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICanhotosEntity Canhotos)
        {
            var query = _query.UpdateCanhotosQuery(Canhotos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICanhotosEntity Canhotos)
        {
            var query = _query.DeleteCanhotosQuery(Canhotos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID(int id, string value)
        {
            var query = _query.UpdateCAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNOT_ID(int id, string value)
        {
            var query = _query.UpdateNOT_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAN_DATA_ENTREGA(int id, DateTime value)
        {
            var query = _query.UpdateCAN_DATA_ENTREGA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAN_IMG(int id, string value)
        {
            var query = _query.UpdateCAN_IMG(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAN_LAT_ENTREGA(int id, Decimal value)
        {
            var query = _query.UpdateCAN_LAT_ENTREGA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAN_LONG_ENTREGA(int id, Decimal value)
        {
            var query = _query.UpdateCAN_LONG_ENTREGA(id, value);
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