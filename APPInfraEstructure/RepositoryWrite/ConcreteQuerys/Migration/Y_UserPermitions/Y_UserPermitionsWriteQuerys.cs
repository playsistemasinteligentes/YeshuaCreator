using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_UserPermitions
{
    public class Y_UserPermitionsWriteQuery : QueryBase
    {
        public QueryModel InserirY_UserPermitionsQuery(IY_UserPermitionsEntity Y_UserPermitions)
        {
            this.Query = $@" INSERT INTO Y_UserPermitions (UserId, PermitionsId) OUTPUT INSERTED.ID VALUES(@UserId, @PermitionsId) ";
            this.Parameters = new
            {
                UserId = Y_UserPermitions.UserId,
                PermitionsId = Y_UserPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_UserPermitionsQuery(IY_UserPermitionsEntity Y_UserPermitions)
        {
            this.Query = $@" UPDATE Y_UserPermitions SET UserId = @UserId, PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                UserId = Y_UserPermitions.UserId,
                PermitionsId = Y_UserPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IY_UserPermitionsEntity entity)
        {
            this.Query = $@" UPDATE Y_UserPermitions SET UserId = @UserId WHERE  ";
            this.Parameters = new
            {
                UserId = entity.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePermitionsId(IY_UserPermitionsEntity entity)
        {
            this.Query = $@" UPDATE Y_UserPermitions SET PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                PermitionsId = entity.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_UserPermitionsQuery(IY_UserPermitionsEntity Y_UserPermitions)
        {
            this.Query = $@" DELETE FROM Y_UserPermitions WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration