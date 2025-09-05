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
    public class yModuleQueryWrite : QueryBase, IyModuleQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public yModuleQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryModuleQuery(IyModuleEntity yModule)
        {
            this.Query = $@" INSERT INTO yModule (Id, Description) OUTPUT INSERTED.ID VALUES(@Id, @Description) ";
            this.Parameters = new
            {
                Id = yModule.Id,
                Description = yModule.Description,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyModuleQuery(IyModuleEntity yModule)
        {
            this.Query = $@" UPDATE yModule SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = yModule.Description,
                Id = yModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IyModuleEntity entity)
        {
            this.Query = $@" UPDATE yModule SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyModuleQuery(IyModuleEntity yModule)
        {
            this.Query = $@" DELETE FROM yModule WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration