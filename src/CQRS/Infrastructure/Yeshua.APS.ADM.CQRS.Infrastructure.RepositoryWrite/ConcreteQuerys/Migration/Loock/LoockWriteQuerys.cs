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
    public class LoockQueryWrite : QueryBase, ILoockQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public LoockQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirLoockQuery(ILoockEntity Loock)
        {
            this.Query = $@" INSERT INTO [Loock] ([LOO_ID], [LOO_DESCRICAO], [LOO_CONTEUDO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@LOO_ID, @LOO_DESCRICAO, @LOO_CONTEUDO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                LOO_ID = Loock.LOO_ID,
                LOO_DESCRICAO = Loock.LOO_DESCRICAO,
                LOO_CONTEUDO = Loock.LOO_CONTEUDO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLoockQuery(ILoockEntity Loock)
        {
            this.Query = $@" UPDATE [Loock] SET [LOO_ID] = @LOO_ID, [LOO_DESCRICAO] = @LOO_DESCRICAO, [LOO_CONTEUDO] = @LOO_CONTEUDO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOO_ID = Loock.LOO_ID,
                LOO_DESCRICAO = Loock.LOO_DESCRICAO,
                LOO_CONTEUDO = Loock.LOO_CONTEUDO,
                Changed = Loock.Changed,
                UserId = _executionContext.UserId,
                Id = Loock.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [Loock] SET [LOO_ID] = @LOO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOO_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [Loock] SET [LOO_DESCRICAO] = @LOO_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOO_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOO_CONTEUDO(int id, string value)
        {
            this.Query = $@" UPDATE [Loock] SET [LOO_CONTEUDO] = @LOO_CONTEUDO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOO_CONTEUDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Loock] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Loock] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Loock] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Loock] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteLoockQuery(ILoockEntity Loock)
        {
            this.Query = $@" DELETE FROM [Loock] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Loock.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration