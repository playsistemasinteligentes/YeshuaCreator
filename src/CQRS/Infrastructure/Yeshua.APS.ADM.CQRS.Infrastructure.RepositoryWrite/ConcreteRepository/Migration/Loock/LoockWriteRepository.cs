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

namespace Input.Repository.Loock
{
    public partial class LoockWriteRepository : ILoockWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ILoockQueryWrite _query; 

        public LoockWriteRepository(IUnitOfWork unitOfWork,ILoockQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ILoockEntity Loock)
        {
            var query = _query.InserirLoockQuery(Loock);
        Loock.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ILoockEntity Loock)
        {
            var query = _query.UpdateLoockQuery(Loock);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ILoockEntity Loock)
        {
            var query = _query.DeleteLoockQuery(Loock);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOO_ID(int id, string value)
        {
            var query = _query.UpdateLOO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOO_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateLOO_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOO_CONTEUDO(int id, string value)
        {
            var query = _query.UpdateLOO_CONTEUDO(id, value);
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