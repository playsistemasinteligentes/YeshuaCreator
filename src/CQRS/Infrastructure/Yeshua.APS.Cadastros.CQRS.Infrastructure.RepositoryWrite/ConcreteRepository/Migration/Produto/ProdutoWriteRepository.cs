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

namespace Input.Repository.Produto
{
    public partial class ProdutoWriteRepository : IProdutoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IProdutoQueryWrite _query; 

        public ProdutoWriteRepository(IUnitOfWork unitOfWork,IProdutoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IProdutoEntity Produto)
        {
            var query = _query.InserirProdutoQuery(Produto);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IProdutoEntity Produto)
        {
            var query = _query.UpdateProdutoQuery(Produto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IProdutoEntity Produto)
        {
            var query = _query.DeleteProdutoQuery(Produto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_DESCRICAO(string pro_id, string value)
        {
            var query = _query.UpdatePRO_DESCRICAO(pro_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_STATUS(string pro_id, string value)
        {
            var query = _query.UpdatePRO_STATUS(pro_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string pro_id, int value)
        {
            var query = _query.UpdateTenantID(pro_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string pro_id, bool value)
        {
            var query = _query.UpdateDeleted(pro_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string pro_id, DateTime value)
        {
            var query = _query.UpdateChanged(pro_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string pro_id, int value)
        {
            var query = _query.UpdateUserId(pro_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration