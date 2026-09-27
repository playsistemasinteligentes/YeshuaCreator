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

namespace Input.Repository.Logs
{
    public partial class LogsWriteRepository : ILogsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ILogsQueryWrite _query; 

        public LogsWriteRepository(IUnitOfWork unitOfWork,ILogsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ILogsEntity Logs)
        {
            var query = _query.InserirLogsQuery(Logs);
        Logs.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ILogsEntity Logs)
        {
            var query = _query.UpdateLogsQuery(Logs);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ILogsEntity Logs)
        {
            var query = _query.DeleteLogsQuery(Logs);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOG_CHAVE(int id, string value)
        {
            var query = _query.UpdateLOG_CHAVE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOG_CONTEXTO(int id, string value)
        {
            var query = _query.UpdateLOG_CONTEXTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOG_CONTEUDO(int id, string value)
        {
            var query = _query.UpdateLOG_CONTEUDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOG_ID(int id, int value)
        {
            var query = _query.UpdateLOG_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOG_EMISSAO(int id, DateTime value)
        {
            var query = _query.UpdateLOG_EMISSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperationalEntityId(int id, string value)
        {
            var query = _query.UpdateOperationalEntityId(id, value);
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