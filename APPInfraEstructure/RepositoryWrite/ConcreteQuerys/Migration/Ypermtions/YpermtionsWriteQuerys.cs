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
    public class YpermtionsQueryWrite : QueryBase, IYpermtionsQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YpermtionsQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYpermtionsQuery(IYpermtionsEntity Ypermtions)
        {
            this.Query = $@" INSERT INTO Ypermtions (Id, Description, TenantID, Deleted, UserId) OUTPUT INSERTED.ID VALUES(@Id, @Description, @TenantID, @Deleted, @UserId) ";
            this.Parameters = new
            {
                Id = Ypermtions.Id,
                Description = Ypermtions.Description,
                TenantID = _correntUser.TenantID,
                Deleted = "",
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYpermtionsQuery(IYpermtionsEntity Ypermtions)
        {
            this.Query = $@" UPDATE Ypermtions SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = Ypermtions.Description,
                Id = Ypermtions.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescription(IYpermtionsEntity entity)
        {
            this.Query = $@" UPDATE Ypermtions SET Description = @Description WHERE Id = @Id ";
            this.Parameters = new
            {
                Description = entity.Description,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYpermtionsQuery(IYpermtionsEntity Ypermtions)
        {
            this.Query = $@" DELETE FROM Ypermtions WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Ypermtions.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration