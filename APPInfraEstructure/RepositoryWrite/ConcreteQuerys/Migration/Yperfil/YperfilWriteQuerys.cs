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
    public class yPerfilQueryWrite : QueryBase, IyPerfilQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public yPerfilQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InseriryPerfilQuery(IyPerfilEntity yPerfil)
        {
            this.Query = $@" INSERT INTO yPerfil (Description, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Description, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Description = yPerfil.Description,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyPerfilQuery(IyPerfilEntity yPerfil)
        {
            this.Query = $@" UPDATE yPerfil SET Description = @Description, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = yPerfil.Description,
                TenantID = yPerfil.TenantID,
                Deleted = yPerfil.Deleted,
                Changed = yPerfil.Changed,
                UserId = yPerfil.UserId,
                Id = yPerfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IyPerfilEntity entity)
        {
            this.Query = $@" UPDATE yPerfil SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyPerfilEntity entity)
        {
            this.Query = $@" UPDATE yPerfil SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyPerfilEntity entity)
        {
            this.Query = $@" UPDATE yPerfil SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyPerfilEntity entity)
        {
            this.Query = $@" UPDATE yPerfil SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyPerfilEntity entity)
        {
            this.Query = $@" UPDATE yPerfil SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyPerfilQuery(IyPerfilEntity yPerfil)
        {
            this.Query = $@" DELETE FROM yPerfil WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yPerfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration