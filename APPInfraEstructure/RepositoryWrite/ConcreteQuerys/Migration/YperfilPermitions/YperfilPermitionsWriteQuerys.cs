using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.YperfilPermitions
{
    public class YperfilPermitionsWriteQuery : QueryBase
    {
        public QueryModel InserirYperfilPermitionsQuery(IYperfilPermitionsEntity YperfilPermitions)
        {
            this.Query = $@" INSERT INTO YperfilPermitions (PerfilId, PermitionsId) OUTPUT INSERTED.ID VALUES(@PerfilId, @PermitionsId) ";
            this.Parameters = new
            {
                PerfilId = YperfilPermitions.PerfilId,
                PermitionsId = YperfilPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYperfilPermitionsQuery(IYperfilPermitionsEntity YperfilPermitions)
        {
            this.Query = $@" UPDATE YperfilPermitions SET PerfilId = @PerfilId, PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                PerfilId = YperfilPermitions.PerfilId,
                PermitionsId = YperfilPermitions.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(IYperfilPermitionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermitions SET PerfilId = @PerfilId WHERE  ";
            this.Parameters = new
            {
                PerfilId = entity.PerfilId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePermitionsId(IYperfilPermitionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermitions SET PermitionsId = @PermitionsId WHERE  ";
            this.Parameters = new
            {
                PermitionsId = entity.PermitionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYperfilPermitionsQuery(IYperfilPermitionsEntity YperfilPermitions)
        {
            this.Query = $@" DELETE FROM YperfilPermitions WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration