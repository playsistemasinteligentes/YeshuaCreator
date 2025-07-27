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
    public class YuserPermitionsQueryWrite : QueryBase, IYuserPermitionsQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YuserPermitionsQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYuserPermitionsQuery(IYuserPermitionsEntity YuserPermitions)
        {
            this.Query = $@" INSERT INTO YuserPermitions (PermitionsId, UserId, TenantID, Deleted, Changed) OUTPUT INSERTED.ID VALUES(@PermitionsId, @UserId, @TenantID, @Deleted, @Changed) ";
            this.Parameters = new
            {
                PermitionsId = YuserPermitions.PermitionsId,
                UserId = YuserPermitions.UserId,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYuserPermitionsQuery(IYuserPermitionsEntity YuserPermitions)
        {
            this.Query = $@" UPDATE YuserPermitions SET PermitionsId = @PermitionsId, UserId = @UserId WHERE  ";
            this.Parameters = new
            {
                PermitionsId = YuserPermitions.PermitionsId,
                UserId = YuserPermitions.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePermitionsId(IYuserPermitionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermitions SET PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                PermitionsId = entity.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IYuserPermitionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermitions SET UserId = @UserId WHERE  ";
            this.Parameters = new
            {
                UserId = entity.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYuserPermitionsQuery(IYuserPermitionsEntity YuserPermitions)
        {
            this.Query = $@" DELETE FROM YuserPermitions WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration