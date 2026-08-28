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

namespace Input.Repository.ItemTestavel
{
    public partial class ItemTestavelWriteRepository : IItemTestavelWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItemTestavelQueryWrite _query; 

        public ItemTestavelWriteRepository(IUnitOfWork unitOfWork,IItemTestavelQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItemTestavelEntity ItemTestavel)
        {
            var query = _query.InserirItemTestavelQuery(ItemTestavel);
        ItemTestavel.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItemTestavelEntity ItemTestavel)
        {
            var query = _query.UpdateItemTestavelQuery(ItemTestavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItemTestavelEntity ItemTestavel)
        {
            var query = _query.DeleteItemTestavelQuery(ItemTestavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_ID(int id, int value)
        {
            var query = _query.UpdateITE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateITE_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_OBS(int id, string value)
        {
            var query = _query.UpdateITE_OBS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_NUMERO_DE_TESTES(int id, int value)
        {
            var query = _query.UpdateITE_NUMERO_DE_TESTES(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_CONDICIONAL_DE_AVALIACAO(int id, string value)
        {
            var query = _query.UpdateITE_CONDICIONAL_DE_AVALIACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_VALOR_DA_CONDICIONAL(int id, Decimal value)
        {
            var query = _query.UpdateITE_VALOR_DA_CONDICIONAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_VALOR_CALCULADO_DA_CONDICIONAL(int id, string value)
        {
            var query = _query.UpdateITE_VALOR_CALCULADO_DA_CONDICIONAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_TIPO_AVALIACAO_FINAL(int id, string value)
        {
            var query = _query.UpdateITE_TIPO_AVALIACAO_FINAL(id, value);
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