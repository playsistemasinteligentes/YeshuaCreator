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
        protected readonly ICurrentUser _currentUser;
        public yPerfilQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryPerfilQuery(IyPerfilEntity yPerfil)
        {
            this.Query = $@" INSERT INTO yPerfil (Description, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Description, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Description = yPerfil.Description,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyPerfilQuery(IyPerfilEntity yPerfil)
        {
            this.Query = $@" UPDATE yPerfil SET Description = @Description, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = yPerfil.Description,
                Changed = yPerfil.Changed,
                UserId = _currentUser.UserId,
                Id = yPerfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(int id, string value)
        {
            this.Query = $@" UPDATE yPerfil SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yPerfil SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yPerfil SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yPerfil SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yPerfil SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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