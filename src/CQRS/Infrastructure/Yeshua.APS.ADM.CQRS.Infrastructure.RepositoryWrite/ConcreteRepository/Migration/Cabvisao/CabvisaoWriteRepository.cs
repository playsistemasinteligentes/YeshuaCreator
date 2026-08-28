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

namespace Input.Repository.Cabvisao
{
    public partial class CabvisaoWriteRepository : ICabvisaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICabvisaoQueryWrite _query; 

        public CabvisaoWriteRepository(IUnitOfWork unitOfWork,ICabvisaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICabvisaoEntity Cabvisao)
        {
            var query = _query.InserirCabvisaoQuery(Cabvisao);
        Cabvisao.CAB_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICabvisaoEntity Cabvisao)
        {
            var query = _query.UpdateCabvisaoQuery(Cabvisao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICabvisaoEntity Cabvisao)
        {
            var query = _query.DeleteCabvisaoQuery(Cabvisao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAB_DESC(int cab_id, string value)
        {
            var query = _query.UpdateCAB_DESC(cab_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAB_STATUS(int cab_id, int value)
        {
            var query = _query.UpdateCAB_STATUS(cab_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int cab_id, int value)
        {
            var query = _query.UpdateUSE_ID(cab_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int cab_id, int value)
        {
            var query = _query.UpdateTenantID(cab_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int cab_id, bool value)
        {
            var query = _query.UpdateDeleted(cab_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int cab_id, DateTime value)
        {
            var query = _query.UpdateChanged(cab_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int cab_id, int value)
        {
            var query = _query.UpdateUserId(cab_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration