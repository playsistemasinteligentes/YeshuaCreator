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

namespace Input.Repository.ItemInspecao
{
    public partial class ItemInspecaoWriteRepository : IItemInspecaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItemInspecaoQueryWrite _query; 

        public ItemInspecaoWriteRepository(IUnitOfWork unitOfWork,IItemInspecaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItemInspecaoEntity ItemInspecao)
        {
            var query = _query.InserirItemInspecaoQuery(ItemInspecao);
        ItemInspecao.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItemInspecaoEntity ItemInspecao)
        {
            var query = _query.UpdateItemInspecaoQuery(ItemInspecao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItemInspecaoEntity ItemInspecao)
        {
            var query = _query.DeleteItemInspecaoQuery(ItemInspecao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITI_ID(int id, int value)
        {
            var query = _query.UpdateITI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITI_DESC(int id, string value)
        {
            var query = _query.UpdateITI_DESC(id, value);
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