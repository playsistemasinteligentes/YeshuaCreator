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
    public class YpserPermitionsQueryWrite : QueryBase, IYpserPermitionsQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YpserPermitionsQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYpserPermitionsQuery(IYpserPermitionsEntity YpserPermitions)
        {
            this.Query = $@" INSERT INTO YpserPermitions (PermitionsId, TenantID, Deleted, UserId) OUTPUT INSERTED.ID VALUES(@PermitionsId, @TenantID, @Deleted, @UserId) ";
            this.Parameters = new
            {
                PermitionsId = YpserPermitions.PermitionsId,
                TenantID = _correntUser.TenantID,
                Deleted = "",
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYpserPermitionsQuery(IYpserPermitionsEntity YpserPermitions)
        {
            this.Query = $@" UPDATE YpserPermitions SET PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                PermitionsId = YpserPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePermitionsId(IYpserPermitionsEntity entity)
        {
            this.Query = $@" UPDATE YpserPermitions SET PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                PermitionsId = entity.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYpserPermitionsQuery(IYpserPermitionsEntity YpserPermitions)
        {
            this.Query = $@" DELETE FROM YpserPermitions WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration