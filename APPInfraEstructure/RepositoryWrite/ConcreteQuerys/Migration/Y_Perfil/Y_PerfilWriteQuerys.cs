using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_Perfil
{
    public class Y_PerfilWriteQuery : QueryBase
    {
        public QueryModel InserirY_PerfilQuery(IY_PerfilEntity Y_Perfil)
        {
            this.Query = $@" INSERT INTO Y_Perfil (Description) OUTPUT INSERTED.Id VALUES(@Description) ";
            this.Parameters = new
            {
                Description = Y_Perfil.Description,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_PerfilQuery(IY_PerfilEntity Y_Perfil)
        {
            this.Query = $@" UPDATE Y_Perfil SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = Y_Perfil.Description,
                Id = Y_Perfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IY_PerfilEntity entity)
        {
            this.Query = $@" UPDATE Y_Perfil SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_PerfilQuery(IY_PerfilEntity Y_Perfil)
        {
            this.Query = $@" DELETE FROM Y_Perfil WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Y_Perfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration