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
        protected readonly ICurrentUser _correntUser;
        public yPerfilGrantQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InseriryPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" INSERT INTO yPerfilGrant (PerfilId, GrantId, Grant, Create, Read, Update, Delete, ValidUntil, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@PerfilId, @GrantId, @Grant, @Create, @Read, @Update, @Delete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PerfilId = yPerfilGrant.PerfilId,
                GrantId = yPerfilGrant.GrantId,
                Grant = yPerfilGrant.Grant,
                Create = yPerfilGrant.Create,
                Read = yPerfilGrant.Read,
                Update = yPerfilGrant.Update,
                Delete = yPerfilGrant.Delete,
                ValidUntil = yPerfilGrant.ValidUntil,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" UPDATE yPerfilGrant SET PerfilId = @PerfilId, GrantId = @GrantId, Grant = @Grant, Create = @Create, Read = @Read, Update = @Update, Delete = @Delete, ValidUntil = @ValidUntil, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE  ";
            this.Parameters = new
            {
                PerfilId = yPerfilGrant.PerfilId,
                GrantId = yPerfilGrant.GrantId,
                Grant = yPerfilGrant.Grant,
                Create = yPerfilGrant.Create,
                Read = yPerfilGrant.Read,
                Update = yPerfilGrant.Update,
                Delete = yPerfilGrant.Delete,
                ValidUntil = yPerfilGrant.ValidUntil,
                TenantID = yPerfilGrant.TenantID,
                Deleted = yPerfilGrant.Deleted,
                Changed = yPerfilGrant.Changed,
                UserId = yPerfilGrant.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET PerfilId = @PerfilId WHERE  ";
            this.Parameters = new
            {
                PerfilId = entity.PerfilId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrantId(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET GrantId = @GrantId WHERE  ";
            this.Parameters = new
            {
                GrantId = entity.GrantId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrant(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Grant = @Grant WHERE  ";
            this.Parameters = new
            {
                Grant = entity.Grant,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreate(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Create = @Create WHERE  ";
            this.Parameters = new
            {
                Create = entity.Create,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRead(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Read = @Read WHERE  ";
            this.Parameters = new
            {
                Read = entity.Read,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUpdate(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Update = @Update WHERE  ";
            this.Parameters = new
            {
                Update = entity.Update,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDelete(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Delete = @Delete WHERE  ";
            this.Parameters = new
            {
                Delete = entity.Delete,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET ValidUntil = @ValidUntil WHERE  ";
            this.Parameters = new
            {
                ValidUntil = entity.ValidUntil,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET TenantID = @TenantID WHERE  ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Deleted = @Deleted WHERE  ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Changed = @Changed WHERE  ";
            this.Parameters = new
            {
                Changed = entity.Changed,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyPerfilGrantEntity entity)
        {
            this.Query = $@" UPDATE yPerfilGrant SET UserId = @UserId WHERE  ";
            this.Parameters = new
            {
                UserId = entity.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" DELETE FROM yPerfilGrant WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration