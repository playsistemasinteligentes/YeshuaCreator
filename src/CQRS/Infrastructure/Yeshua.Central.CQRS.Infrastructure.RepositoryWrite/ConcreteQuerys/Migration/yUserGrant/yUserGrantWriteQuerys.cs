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
    public class yUserGrantQueryWrite : QueryBase, IyUserGrantQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yUserGrantQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryUserGrantQuery(IyUserGrantEntity yUserGrant)
        {
            this.Query = $@" INSERT INTO [yUserGrant] ([PerfilId], [GrantId], [CanGrant], [CanCreate], [CanRead], [CanUpdate], [CanDelete], [ValidUntil], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@PerfilId, @GrantId, @CanGrant, @CanCreate, @CanRead, @CanUpdate, @CanDelete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PerfilId = yUserGrant.PerfilId,
                GrantId = yUserGrant.GrantId,
                CanGrant = yUserGrant.CanGrant,
                CanCreate = yUserGrant.CanCreate,
                CanRead = yUserGrant.CanRead,
                CanUpdate = yUserGrant.CanUpdate,
                CanDelete = yUserGrant.CanDelete,
                ValidUntil = yUserGrant.ValidUntil,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyUserGrantQuery(IyUserGrantEntity yUserGrant)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [PerfilId] = @PerfilId, [GrantId] = @GrantId, [CanGrant] = @CanGrant, [CanCreate] = @CanCreate, [CanRead] = @CanRead, [CanUpdate] = @CanUpdate, [CanDelete] = @CanDelete, [ValidUntil] = @ValidUntil, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PerfilId = yUserGrant.PerfilId,
                GrantId = yUserGrant.GrantId,
                CanGrant = yUserGrant.CanGrant,
                CanCreate = yUserGrant.CanCreate,
                CanRead = yUserGrant.CanRead,
                CanUpdate = yUserGrant.CanUpdate,
                CanDelete = yUserGrant.CanDelete,
                ValidUntil = yUserGrant.ValidUntil,
                Changed = yUserGrant.Changed,
                UserId = _executionContext.UserId,
                Id = yUserGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(int id, int value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [PerfilId] = @PerfilId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PerfilId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrantId(int id, string value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [GrantId] = @GrantId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GrantId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanGrant(int id, bool value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [CanGrant] = @CanGrant WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanGrant = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanCreate(int id, bool value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [CanCreate] = @CanCreate WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanCreate = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanRead(int id, bool value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [CanRead] = @CanRead WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanRead = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanUpdate(int id, bool value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [CanUpdate] = @CanUpdate WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanUpdate = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanDelete(int id, bool value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [CanDelete] = @CanDelete WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanDelete = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [ValidUntil] = @ValidUntil WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [yUserGrant] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyUserGrantQuery(IyUserGrantEntity yUserGrant)
        {
            this.Query = $@" DELETE FROM [yUserGrant] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = yUserGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration