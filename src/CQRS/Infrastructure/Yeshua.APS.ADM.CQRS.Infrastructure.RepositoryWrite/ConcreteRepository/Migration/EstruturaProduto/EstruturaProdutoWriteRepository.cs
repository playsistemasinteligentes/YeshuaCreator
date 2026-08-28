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

namespace Input.Repository.EstruturaProduto
{
    public partial class EstruturaProdutoWriteRepository : IEstruturaProdutoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEstruturaProdutoQueryWrite _query; 

        public EstruturaProdutoWriteRepository(IUnitOfWork unitOfWork,IEstruturaProdutoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEstruturaProdutoEntity EstruturaProduto)
        {
            var query = _query.InserirEstruturaProdutoQuery(EstruturaProduto);
        EstruturaProduto.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEstruturaProdutoEntity EstruturaProduto)
        {
            var query = _query.UpdateEstruturaProdutoQuery(EstruturaProduto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEstruturaProdutoEntity EstruturaProduto)
        {
            var query = _query.DeleteEstruturaProdutoQuery(EstruturaProduto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_DATA_VALIDADE(int id, DateTime value)
        {
            var query = _query.UpdateEST_DATA_VALIDADE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_PRODUTO(int id, string value)
        {
            var query = _query.UpdatePRO_ID_PRODUTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_COMPONENTE(int id, string value)
        {
            var query = _query.UpdatePRO_ID_COMPONENTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_QUANT(int id, Decimal value)
        {
            var query = _query.UpdateEST_QUANT(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_DATA_INCLUSAO(int id, DateTime value)
        {
            var query = _query.UpdateEST_DATA_INCLUSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_BASE_PRODUCAO(int id, Decimal value)
        {
            var query = _query.UpdateEST_BASE_PRODUCAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_TIPO_REQUISICAO(int id, string value)
        {
            var query = _query.UpdateEST_TIPO_REQUISICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_CODIGO_DE_EXCECAO(int id, string value)
        {
            var query = _query.UpdateEST_CODIGO_DE_EXCECAO(id, value);
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