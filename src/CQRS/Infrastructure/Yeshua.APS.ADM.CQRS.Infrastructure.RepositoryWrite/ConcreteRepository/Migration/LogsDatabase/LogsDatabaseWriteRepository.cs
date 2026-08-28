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

namespace Input.Repository.LogsDatabase
{
    public partial class LogsDatabaseWriteRepository : ILogsDatabaseWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ILogsDatabaseQueryWrite _query; 

        public LogsDatabaseWriteRepository(IUnitOfWork unitOfWork,ILogsDatabaseQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ILogsDatabaseEntity LogsDatabase)
        {
            var query = _query.InserirLogsDatabaseQuery(LogsDatabase);
        LogsDatabase.LOGS_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ILogsDatabaseEntity LogsDatabase)
        {
            var query = _query.UpdateLogsDatabaseQuery(LogsDatabase);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ILogsDatabaseEntity LogsDatabase)
        {
            var query = _query.DeleteLogsDatabaseQuery(LogsDatabase);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_TABLE(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_TABLE(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_KEY(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_KEY(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_KEY1(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_KEY1(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_KEY2(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_KEY2(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_KEY3(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_KEY3(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_KEY4(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_KEY4(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_COLUMN(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_COLUMN(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_BEFORE(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_BEFORE(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_AFTER(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_AFTER(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_ACTION(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_ACTION(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_DATE(int logs_id, DateTime value)
        {
            var query = _query.UpdateLOGS_DATE(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int logs_id, int value)
        {
            var query = _query.UpdateUSE_ID(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOGS_ORIGEM(int logs_id, string value)
        {
            var query = _query.UpdateLOGS_ORIGEM(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int logs_id, int value)
        {
            var query = _query.UpdateTenantID(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int logs_id, bool value)
        {
            var query = _query.UpdateDeleted(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int logs_id, DateTime value)
        {
            var query = _query.UpdateChanged(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int logs_id, int value)
        {
            var query = _query.UpdateUserId(logs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration