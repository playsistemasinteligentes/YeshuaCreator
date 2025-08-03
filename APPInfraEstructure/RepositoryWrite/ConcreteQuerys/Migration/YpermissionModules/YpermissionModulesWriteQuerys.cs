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
    public class YpermissionModulesQueryWrite : QueryBase, IYpermissionModulesQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YpermissionModulesQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYpermissionModulesQuery(IYpermissionModulesEntity YpermissionModules)
        {
            this.Query = $@" INSERT INTO YpermissionModules (Id, Description, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @Description, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = YpermissionModules.Id,
                Description = YpermissionModules.Description,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYpermissionModulesQuery(IYpermissionModulesEntity YpermissionModules)
        {
            this.Query = $@" UPDATE YpermissionModules SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = YpermissionModules.Description,
                Id = YpermissionModules.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IYpermissionModulesEntity entity)
        {
            this.Query = $@" UPDATE YpermissionModules SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYpermissionModulesQuery(IYpermissionModulesEntity YpermissionModules)
        {
            this.Query = $@" DELETE FROM YpermissionModules WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = YpermissionModules.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration