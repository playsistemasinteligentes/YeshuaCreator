using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_PerfilPermitions
{
    public class Y_PerfilPermitionsWriteQuery : QueryBase
    {
        public QueryModel InserirY_PerfilPermitionsQuery(IY_PerfilPermitionsEntity Y_PerfilPermitions)
        {
            this.Query = $@" INSERT INTO Y_PerfilPermitions (PerfilId, PermitionsId) OUTPUT INSERTED.ID VALUES(@PerfilId, @PermitionsId) ";
            this.Parameters = new
            {
                PerfilId = Y_PerfilPermitions.PerfilId,
                PermitionsId = Y_PerfilPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_PerfilPermitionsQuery(IY_PerfilPermitionsEntity Y_PerfilPermitions)
        {
            this.Query = $@" UPDATE Y_PerfilPermitions SET PerfilId = @PerfilId, PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                PerfilId = Y_PerfilPermitions.PerfilId,
                PermitionsId = Y_PerfilPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_PerfilPermitionsQuery(IY_PerfilPermitionsEntity Y_PerfilPermitions)
        {
            this.Query = $@" DELETE FROM Y_PerfilPermitions WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration