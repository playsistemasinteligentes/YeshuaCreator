using Dominio.Entitys.Y_UserPermitions;
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
        public QueryModel InserirY_UserPermitionsQuery(Y_UserPermitionsEntity Y_UserPermitions)
        {
            this.Query = $@" INSERT INTO Y_UserPermitions (UserId, PermitionsId) VALUES(@UserId, @PermitionsId) ";
            this.Parameters = new
            {
                UserId = Y_UserPermitions.UserId,
                PermitionsId = Y_UserPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_UserPermitionsQuery(Y_UserPermitionsEntity Y_UserPermitions)
        {
            this.Query = $@" UPDATE Y_UserPermitions SET UserId = @UserId, PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                UserId = Y_UserPermitions.UserId,
                PermitionsId = Y_UserPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_UserPermitionsQuery(Y_UserPermitionsEntity Y_UserPermitions)
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