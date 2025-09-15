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
    public class yGrantQueryWrite : QueryBase, IyGrantQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public yGrantQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryGrantQuery(IyGrantEntity yGrant)
        {
            this.Query = $@" INSERT INTO yGrant (Id, Description, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @Description, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = yGrant.Id,
                Description = yGrant.Description,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyGrantQuery(IyGrantEntity yGrant)
        {
            this.Query = $@" UPDATE yGrant SET Description = @Description, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = yGrant.Description,
                Changed = yGrant.Changed,
                UserId = _currentUser.UserId,
                Id = yGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IyGrantEntity entity)
        {
            this.Query = $@" UPDATE yGrant SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyGrantEntity entity)
        {
            this.Query = $@" UPDATE yGrant SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyGrantEntity entity)
        {
            this.Query = $@" UPDATE yGrant SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyGrantEntity entity)
        {
            this.Query = $@" UPDATE yGrant SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyGrantEntity entity)
        {
            this.Query = $@" UPDATE yGrant SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyGrantQuery(IyGrantEntity yGrant)
        {
            this.Query = $@" DELETE FROM yGrant WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yGrant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration