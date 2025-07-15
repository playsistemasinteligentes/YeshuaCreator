using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_Permtions
{
    public class Y_PermtionsWriteQuery : QueryBase
    {
        public QueryModel InserirY_PermtionsQuery(IY_PermtionsEntity Y_Permtions)
        {
            this.Query = $@" INSERT INTO Y_Permtions (Id, Description) OUTPUT INSERTED.ID VALUES(@Id, @Description) ";
            this.Parameters = new
            {
                Id = Y_Permtions.Id,
                Description = Y_Permtions.Description,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_PermtionsQuery(IY_PermtionsEntity Y_Permtions)
        {
            this.Query = $@" UPDATE Y_Permtions SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = Y_Permtions.Description,
                Id = Y_Permtions.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IY_PermtionsEntity entity)
        {
            this.Query = $@" UPDATE Y_Permtions SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_PermtionsQuery(IY_PermtionsEntity Y_Permtions)
        {
            this.Query = $@" DELETE FROM Y_Permtions WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Y_Permtions.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration