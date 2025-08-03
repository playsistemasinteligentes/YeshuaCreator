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
    public class YpermissionActionsQueryWrite : QueryBase, IYpermissionActionsQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YpermissionActionsQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYpermissionActionsQuery(IYpermissionActionsEntity YpermissionActions)
        {
            this.Query = $@" INSERT INTO YpermissionActions (Id, Description, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @Description, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = YpermissionActions.Id,
                Description = YpermissionActions.Description,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYpermissionActionsQuery(IYpermissionActionsEntity YpermissionActions)
        {
            this.Query = $@" UPDATE YpermissionActions SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = YpermissionActions.Description,
                Id = YpermissionActions.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IYpermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YpermissionActions SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYpermissionActionsQuery(IYpermissionActionsEntity YpermissionActions)
        {
            this.Query = $@" DELETE FROM YpermissionActions WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = YpermissionActions.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration