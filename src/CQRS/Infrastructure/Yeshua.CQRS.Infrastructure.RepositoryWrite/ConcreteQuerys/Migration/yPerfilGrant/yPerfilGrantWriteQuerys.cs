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
            this.Query = $@" INSERT INTO yPerfilGrant (PerfilId, GrantId, Grant, Create, Read, Update, Delete, ValidUntil, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PerfilId, @GrantId, @Grant, @Create, @Read, @Update, @Delete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
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
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" UPDATE yPerfilGrant SET PerfilId = @PerfilId, GrantId = @GrantId, Grant = @Grant, Create = @Create, Read = @Read, Update = @Update, Delete = @Delete, ValidUntil = @ValidUntil, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
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
                Changed = yPerfilGrant.Changed,
                UserId = _executionContext.UserId,
                Id = yPerfilGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(int id, int value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET PerfilId = @PerfilId WHERE Id = @Id ";
            this.Parameters = new
            {
                PerfilId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrantId(int id, string value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET GrantId = @GrantId WHERE Id = @Id ";
            this.Parameters = new
            {
                GrantId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrant(int id, bool value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Grant = @Grant WHERE Id = @Id ";
            this.Parameters = new
            {
                Grant = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreate(int id, bool value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Create = @Create WHERE Id = @Id ";
            this.Parameters = new
            {
                Create = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRead(int id, bool value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Read = @Read WHERE Id = @Id ";
            this.Parameters = new
            {
                Read = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUpdate(int id, bool value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Update = @Update WHERE Id = @Id ";
            this.Parameters = new
            {
                Update = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDelete(int id, bool value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Delete = @Delete WHERE Id = @Id ";
            this.Parameters = new
            {
                Delete = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET ValidUntil = @ValidUntil WHERE Id = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yPerfilGrant SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant)
        {
            this.Query = $@" DELETE FROM yPerfilGrant WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yPerfilGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration