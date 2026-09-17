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
    public class yPerfilGrantQueryWrite : QueryBase, IyPerfilGrantQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yPerfilGrantQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" INSERT INTO [yPerfilGrant] ([PerfilId], [GrantId], [CanGrant], [CanCreate], [CanRead], [CanUpdate], [CanDelete], [ValidUntil], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@PerfilId, @GrantId, @CanGrant, @CanCreate, @CanRead, @CanUpdate, @CanDelete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PerfilId = yPerfilGrant.PerfilId,
                GrantId = yPerfilGrant.GrantId,
                CanGrant = yPerfilGrant.CanGrant,
                CanCreate = yPerfilGrant.CanCreate,
                CanRead = yPerfilGrant.CanRead,
                CanUpdate = yPerfilGrant.CanUpdate,
                CanDelete = yPerfilGrant.CanDelete,
                ValidUntil = yPerfilGrant.ValidUntil,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [PerfilId] = @PerfilId, [GrantId] = @GrantId, [CanGrant] = @CanGrant, [CanCreate] = @CanCreate, [CanRead] = @CanRead, [CanUpdate] = @CanUpdate, [CanDelete] = @CanDelete, [ValidUntil] = @ValidUntil, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PerfilId = yPerfilGrant.PerfilId,
                GrantId = yPerfilGrant.GrantId,
                CanGrant = yPerfilGrant.CanGrant,
                CanCreate = yPerfilGrant.CanCreate,
                CanRead = yPerfilGrant.CanRead,
                CanUpdate = yPerfilGrant.CanUpdate,
                CanDelete = yPerfilGrant.CanDelete,
                ValidUntil = yPerfilGrant.ValidUntil,
                Changed = yPerfilGrant.Changed,
                UserId = _executionContext.UserId,
                Id = yPerfilGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(int id, int value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [PerfilId] = @PerfilId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PerfilId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrantId(int id, string value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [GrantId] = @GrantId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GrantId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanGrant(int id, bool value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [CanGrant] = @CanGrant WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanGrant = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanCreate(int id, bool value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [CanCreate] = @CanCreate WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanCreate = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanRead(int id, bool value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [CanRead] = @CanRead WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanRead = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanUpdate(int id, bool value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [CanUpdate] = @CanUpdate WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanUpdate = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanDelete(int id, bool value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [CanDelete] = @CanDelete WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CanDelete = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [ValidUntil] = @ValidUntil WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [yPerfilGrant] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" DELETE FROM [yPerfilGrant] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = yPerfilGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration