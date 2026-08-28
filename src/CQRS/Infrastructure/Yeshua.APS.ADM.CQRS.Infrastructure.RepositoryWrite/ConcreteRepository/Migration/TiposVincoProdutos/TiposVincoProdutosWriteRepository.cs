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

namespace Input.Repository.TiposVincoProdutos
{
    public partial class TiposVincoProdutosWriteRepository : ITiposVincoProdutosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITiposVincoProdutosQueryWrite _query; 

        public TiposVincoProdutosWriteRepository(IUnitOfWork unitOfWork,ITiposVincoProdutosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITiposVincoProdutosEntity TiposVincoProdutos)
        {
            var query = _query.InserirTiposVincoProdutosQuery(TiposVincoProdutos);
        TiposVincoProdutos.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITiposVincoProdutosEntity TiposVincoProdutos)
        {
            var query = _query.UpdateTiposVincoProdutosQuery(TiposVincoProdutos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITiposVincoProdutosEntity TiposVincoProdutos)
        {
            var query = _query.DeleteTiposVincoProdutosQuery(TiposVincoProdutos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateId2(int id, int value)
        {
            var query = _query.UpdateId2(id, value);
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