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
        protected readonly ICurrentUser _currentUser;
        public yUserGrantQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryUserGrantQuery(IyUserGrantEntity yUserGrant)
        {
            this.Query = $@" INSERT INTO yUserGrant (PerfilId, GrantId, Grant, Create, Read, Update, Delete, ValidUntil, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@PerfilId, @GrantId, @Grant, @Create, @Read, @Update, @Delete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PerfilId = yUserGrant.PerfilId,
                GrantId = yUserGrant.GrantId,
                Grant = yUserGrant.Grant,
                Create = yUserGrant.Create,
                Read = yUserGrant.Read,
                Update = yUserGrant.Update,
                Delete = yUserGrant.Delete,
                ValidUntil = yUserGrant.ValidUntil,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyUserGrantQuery(IyUserGrantEntity yUserGrant)
        {
            this.Query = $@" UPDATE yUserGrant SET PerfilId = @PerfilId, GrantId = @GrantId, Grant = @Grant, Create = @Create, Read = @Read, Update = @Update, Delete = @Delete, ValidUntil = @ValidUntil, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE  ";
            this.Parameters = new
            {
                PerfilId = yUserGrant.PerfilId,
                GrantId = yUserGrant.GrantId,
                Grant = yUserGrant.Grant,
                Create = yUserGrant.Create,
                Read = yUserGrant.Read,
                Update = yUserGrant.Update,
                Delete = yUserGrant.Delete,
                ValidUntil = yUserGrant.ValidUntil,
                TenantID = yUserGrant.TenantID,
                Deleted = yUserGrant.Deleted,
                Changed = yUserGrant.Changed,
                UserId = yUserGrant.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET PerfilId = @PerfilId WHERE  ";
            this.Parameters = new
            {
                PerfilId = entity.PerfilId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrantId(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET GrantId = @GrantId WHERE  ";
            this.Parameters = new
            {
                GrantId = entity.GrantId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrant(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET Grant = @Grant WHERE  ";
            this.Parameters = new
            {
                Grant = entity.Grant,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreate(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET Create = @Create WHERE  ";
            this.Parameters = new
            {
                Create = entity.Create,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRead(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET Read = @Read WHERE  ";
            this.Parameters = new
            {
                Read = entity.Read,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUpdate(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET Update = @Update WHERE  ";
            this.Parameters = new
            {
                Update = entity.Update,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDelete(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET Delete = @Delete WHERE  ";
            this.Parameters = new
            {
                Delete = entity.Delete,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET ValidUntil = @ValidUntil WHERE  ";
            this.Parameters = new
            {
                ValidUntil = entity.ValidUntil,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET TenantID = @TenantID WHERE  ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET Deleted = @Deleted WHERE  ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET Changed = @Changed WHERE  ";
            this.Parameters = new
            {
                Changed = entity.Changed,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyUserGrantEntity entity)
        {
            this.Query = $@" UPDATE yUserGrant SET UserId = @UserId WHERE  ";
            this.Parameters = new
            {
                UserId = entity.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyUserGrantQuery(IyUserGrantEntity yUserGrant)
        {
            this.Query = $@" DELETE FROM yUserGrant WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration