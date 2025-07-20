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
    public class YperfilQueryWrite : QueryBase, IYperfilQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YperfilQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYperfilQuery(IYperfilEntity Yperfil)
        {
            this.Query = $@" INSERT INTO Yperfil (Description) OUTPUT INSERTED.Id VALUES(@Description) ";
            this.Parameters = new
            {
                Description = Yperfil.Description,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYperfilQuery(IYperfilEntity Yperfil)
        {
            this.Query = $@" UPDATE Yperfil SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = Yperfil.Description,
                Id = Yperfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IYperfilEntity entity)
        {
            this.Query = $@" UPDATE Yperfil SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYperfilQuery(IYperfilEntity Yperfil)
        {
            this.Query = $@" DELETE FROM Yperfil WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Yperfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration