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
    public class LogsQueryWrite : QueryBase, ILogsQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public LogsQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirLogsQuery(ILogsEntity Logs)
        {
            this.Query = $@" INSERT INTO [Logs] ([LOG_CHAVE], [LOG_CONTEXTO], [LOG_CONTEUDO], [LOG_ID], [LOG_EMISSAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@LOG_CHAVE, @LOG_CONTEXTO, @LOG_CONTEUDO, @LOG_ID, @LOG_EMISSAO, @OperationalEntityId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                LOG_CHAVE = Logs.LOG_CHAVE,
                LOG_CONTEXTO = Logs.LOG_CONTEXTO,
                LOG_CONTEUDO = Logs.LOG_CONTEUDO,
                LOG_ID = Logs.LOG_ID,
                LOG_EMISSAO = Logs.LOG_EMISSAO,
                OperationalEntityId = Logs.OperationalEntityId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLogsQuery(ILogsEntity Logs)
        {
            this.Query = $@" UPDATE [Logs] SET [LOG_CHAVE] = @LOG_CHAVE, [LOG_CONTEXTO] = @LOG_CONTEXTO, [LOG_CONTEUDO] = @LOG_CONTEUDO, [LOG_ID] = @LOG_ID, [LOG_EMISSAO] = @LOG_EMISSAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOG_CHAVE = Logs.LOG_CHAVE,
                LOG_CONTEXTO = Logs.LOG_CONTEXTO,
                LOG_CONTEUDO = Logs.LOG_CONTEUDO,
                LOG_ID = Logs.LOG_ID,
                LOG_EMISSAO = Logs.LOG_EMISSAO,
                Changed = Logs.Changed,
                UserId = _executionContext.UserId,
                Id = Logs.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOG_CHAVE(int id, string value)
        {
            this.Query = $@" UPDATE [Logs] SET [LOG_CHAVE] = @LOG_CHAVE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOG_CHAVE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOG_CONTEXTO(int id, string value)
        {
            this.Query = $@" UPDATE [Logs] SET [LOG_CONTEXTO] = @LOG_CONTEXTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOG_CONTEXTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOG_CONTEUDO(int id, string value)
        {
            this.Query = $@" UPDATE [Logs] SET [LOG_CONTEUDO] = @LOG_CONTEUDO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOG_CONTEUDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOG_ID(int id, int value)
        {
            this.Query = $@" UPDATE [Logs] SET [LOG_ID] = @LOG_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOG_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOG_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Logs] SET [LOG_EMISSAO] = @LOG_EMISSAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOG_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [Logs] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Logs] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Logs] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Logs] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Logs] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteLogsQuery(ILogsEntity Logs)
        {
            this.Query = $@" DELETE FROM [Logs] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Logs.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration