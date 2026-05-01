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
            this.Query = $@" INSERT INTO yUserGrant (PerfilId, GrantId, Grant, Create, Read, Update, Delete, ValidUntil, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PerfilId, @GrantId, @Grant, @Create, @Read, @Update, @Delete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
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
            this.Query = $@" UPDATE yUserGrant SET PerfilId = @PerfilId, GrantId = @GrantId, Grant = @Grant, Create = @Create, Read = @Read, Update = @Update, Delete = @Delete, ValidUntil = @ValidUntil, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
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
                Changed = yUserGrant.Changed,
                UserId = _currentUser.UserId,
                Id = yUserGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(int id, int value)
        {
            this.Query = $@" UPDATE yUserGrant SET PerfilId = @PerfilId WHERE Id = @Id ";
            this.Parameters = new
            {
                PerfilId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrantId(int id, string value)
        {
            this.Query = $@" UPDATE yUserGrant SET GrantId = @GrantId WHERE Id = @Id ";
            this.Parameters = new
            {
                GrantId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrant(int id, bool value)
        {
            this.Query = $@" UPDATE yUserGrant SET Grant = @Grant WHERE Id = @Id ";
            this.Parameters = new
            {
                Grant = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreate(int id, bool value)
        {
            this.Query = $@" UPDATE yUserGrant SET Create = @Create WHERE Id = @Id ";
            this.Parameters = new
            {
                Create = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRead(int id, bool value)
        {
            this.Query = $@" UPDATE yUserGrant SET Read = @Read WHERE Id = @Id ";
            this.Parameters = new
            {
                Read = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUpdate(int id, bool value)
        {
            this.Query = $@" UPDATE yUserGrant SET Update = @Update WHERE Id = @Id ";
            this.Parameters = new
            {
                Update = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDelete(int id, bool value)
        {
            this.Query = $@" UPDATE yUserGrant SET Delete = @Delete WHERE Id = @Id ";
            this.Parameters = new
            {
                Delete = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE yUserGrant SET ValidUntil = @ValidUntil WHERE Id = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yUserGrant SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yUserGrant SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yUserGrant SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yUserGrant SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyUserGrantQuery(IyUserGrantEntity yUserGrant)
        {
            this.Query = $@" DELETE FROM yUserGrant WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yUserGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration