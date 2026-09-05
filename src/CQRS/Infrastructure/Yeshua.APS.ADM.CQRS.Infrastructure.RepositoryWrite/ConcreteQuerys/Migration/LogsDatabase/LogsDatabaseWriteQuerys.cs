// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class LogsDatabaseQueryWrite : QueryBase, ILogsDatabaseQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public LogsDatabaseQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirLogsDatabaseQuery(ILogsDatabaseEntity LogsDatabase)
        {
            this.Query = $@" INSERT INTO [LogsDatabase] ([LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[LOGS_ID] VALUES(@LOGS_TABLE, @LOGS_KEY, @LOGS_KEY1, @LOGS_KEY2, @LOGS_KEY3, @LOGS_KEY4, @LOGS_COLUMN, @LOGS_BEFORE, @LOGS_AFTER, @LOGS_ACTION, @LOGS_DATE, @USE_ID, @LOGS_ORIGEM, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                LOGS_TABLE = LogsDatabase.LOGS_TABLE,
                LOGS_KEY = LogsDatabase.LOGS_KEY,
                LOGS_KEY1 = LogsDatabase.LOGS_KEY1,
                LOGS_KEY2 = LogsDatabase.LOGS_KEY2,
                LOGS_KEY3 = LogsDatabase.LOGS_KEY3,
                LOGS_KEY4 = LogsDatabase.LOGS_KEY4,
                LOGS_COLUMN = LogsDatabase.LOGS_COLUMN,
                LOGS_BEFORE = LogsDatabase.LOGS_BEFORE,
                LOGS_AFTER = LogsDatabase.LOGS_AFTER,
                LOGS_ACTION = LogsDatabase.LOGS_ACTION,
                LOGS_DATE = LogsDatabase.LOGS_DATE,
                USE_ID = LogsDatabase.USE_ID,
                LOGS_ORIGEM = LogsDatabase.LOGS_ORIGEM,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLogsDatabaseQuery(ILogsDatabaseEntity LogsDatabase)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_TABLE] = @LOGS_TABLE, [LOGS_KEY] = @LOGS_KEY, [LOGS_KEY1] = @LOGS_KEY1, [LOGS_KEY2] = @LOGS_KEY2, [LOGS_KEY3] = @LOGS_KEY3, [LOGS_KEY4] = @LOGS_KEY4, [LOGS_COLUMN] = @LOGS_COLUMN, [LOGS_BEFORE] = @LOGS_BEFORE, [LOGS_AFTER] = @LOGS_AFTER, [LOGS_ACTION] = @LOGS_ACTION, [LOGS_DATE] = @LOGS_DATE, [USE_ID] = @USE_ID, [LOGS_ORIGEM] = @LOGS_ORIGEM, [Changed] = @Changed, [UserId] = @UserId WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_TABLE = LogsDatabase.LOGS_TABLE,
                LOGS_KEY = LogsDatabase.LOGS_KEY,
                LOGS_KEY1 = LogsDatabase.LOGS_KEY1,
                LOGS_KEY2 = LogsDatabase.LOGS_KEY2,
                LOGS_KEY3 = LogsDatabase.LOGS_KEY3,
                LOGS_KEY4 = LogsDatabase.LOGS_KEY4,
                LOGS_COLUMN = LogsDatabase.LOGS_COLUMN,
                LOGS_BEFORE = LogsDatabase.LOGS_BEFORE,
                LOGS_AFTER = LogsDatabase.LOGS_AFTER,
                LOGS_ACTION = LogsDatabase.LOGS_ACTION,
                LOGS_DATE = LogsDatabase.LOGS_DATE,
                USE_ID = LogsDatabase.USE_ID,
                LOGS_ORIGEM = LogsDatabase.LOGS_ORIGEM,
                Changed = LogsDatabase.Changed,
                UserId = _executionContext.UserId,
                LOGS_ID = LogsDatabase.LOGS_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_TABLE(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_TABLE] = @LOGS_TABLE WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_TABLE = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_KEY(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_KEY] = @LOGS_KEY WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_KEY = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_KEY1(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_KEY1] = @LOGS_KEY1 WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_KEY1 = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_KEY2(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_KEY2] = @LOGS_KEY2 WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_KEY2 = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_KEY3(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_KEY3] = @LOGS_KEY3 WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_KEY3 = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_KEY4(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_KEY4] = @LOGS_KEY4 WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_KEY4 = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_COLUMN(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_COLUMN] = @LOGS_COLUMN WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_COLUMN = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_BEFORE(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_BEFORE] = @LOGS_BEFORE WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_BEFORE = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_AFTER(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_AFTER] = @LOGS_AFTER WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_AFTER = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_ACTION(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_ACTION] = @LOGS_ACTION WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_ACTION = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_DATE(int logs_id, DateTime value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_DATE] = @LOGS_DATE WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_DATE = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int logs_id, int value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [USE_ID] = @USE_ID WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                USE_ID = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOGS_ORIGEM(int logs_id, string value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [LOGS_ORIGEM] = @LOGS_ORIGEM WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_ORIGEM = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int logs_id, int value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [TenantID] = @TenantID WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                TenantID = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int logs_id, bool value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [Deleted] = @Deleted WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                Deleted = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int logs_id, DateTime value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [Changed] = @Changed WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                Changed = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int logs_id, int value)
        {
            this.Query = $@" UPDATE [LogsDatabase] SET [UserId] = @UserId WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                UserId = value,
                LOGS_ID = logs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteLogsDatabaseQuery(ILogsDatabaseEntity LogsDatabase)
        {
            this.Query = $@" DELETE FROM [LogsDatabase] WHERE [LOGS_ID] = @LOGS_ID ";
            this.Parameters = new
            {
                LOGS_ID = LogsDatabase.LOGS_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration