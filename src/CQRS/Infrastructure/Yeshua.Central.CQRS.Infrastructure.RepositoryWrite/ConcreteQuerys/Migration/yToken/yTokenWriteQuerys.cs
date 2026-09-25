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
    public class yTokenQueryWrite : QueryBase, IyTokenQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yTokenQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryTokenQuery(IyTokenEntity yToken)
        {
            this.Query = $@" INSERT INTO [yToken] ([TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed]) OUTPUT INSERTED.[Id] VALUES(@TokenHash, @Description, @ConnectorKey, @Active, @ValidUntil, @CreatedAt, @LastUsedAt, @TenantID, @UserId, @Deleted, @Changed) ";
            this.Parameters = new
            {
                TokenHash = yToken.TokenHash,
                Description = yToken.Description,
                ConnectorKey = yToken.ConnectorKey,
                Active = 1,
                ValidUntil = yToken.ValidUntil,
                CreatedAt = DateTime.Now,
                LastUsedAt = yToken.LastUsedAt,
                TenantID = _executionContext.TenantID,
                UserId = _executionContext.UserId,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyTokenQuery(IyTokenEntity yToken)
        {
            this.Query = $@" UPDATE [yToken] SET [TokenHash] = @TokenHash, [Description] = @Description, [ConnectorKey] = @ConnectorKey, [Active] = @Active, [ValidUntil] = @ValidUntil, [CreatedAt] = @CreatedAt, [LastUsedAt] = @LastUsedAt, [UserId] = @UserId, [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TokenHash = yToken.TokenHash,
                Description = yToken.Description,
                ConnectorKey = yToken.ConnectorKey,
                Active = yToken.Active,
                ValidUntil = yToken.ValidUntil,
                CreatedAt = yToken.CreatedAt,
                LastUsedAt = yToken.LastUsedAt,
                UserId = _executionContext.UserId,
                Changed = yToken.Changed,
                Id = yToken.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTokenHash(int id, string value)
        {
            this.Query = $@" UPDATE [yToken] SET [TokenHash] = @TokenHash WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TokenHash = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(int id, string value)
        {
            this.Query = $@" UPDATE [yToken] SET [Description] = @Description WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Description = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConnectorKey(int id, string value)
        {
            this.Query = $@" UPDATE [yToken] SET [ConnectorKey] = @ConnectorKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ConnectorKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateActive(int id, bool value)
        {
            this.Query = $@" UPDATE [yToken] SET [Active] = @Active WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Active = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yToken] SET [ValidUntil] = @ValidUntil WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yToken] SET [CreatedAt] = @CreatedAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CreatedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLastUsedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yToken] SET [LastUsedAt] = @LastUsedAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LastUsedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [yToken] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [yToken] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [yToken] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yToken] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyTokenQuery(IyTokenEntity yToken)
        {
            this.Query = $@" DELETE FROM [yToken] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = yToken.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration