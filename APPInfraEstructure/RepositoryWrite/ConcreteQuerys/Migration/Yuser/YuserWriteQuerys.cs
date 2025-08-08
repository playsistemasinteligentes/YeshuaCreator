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
    public class yUserQueryWrite : QueryBase, IyUserQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public yUserQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InseriryUserQuery(IyUserEntity yUser)
        {
            this.Query = $@" INSERT INTO yUser (Nome, Email, Senha, TenantID, Deleted, Changed) OUTPUT INSERTED.Id VALUES(@Nome, @Email, @Senha, @TenantID, @Deleted, @Changed) ";
            this.Parameters = new
            {
                Nome = yUser.Nome,
                Email = yUser.Email,
                Senha = yUser.Senha,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyUserQuery(IyUserEntity yUser)
        {
            this.Query = $@" UPDATE yUser SET Nome = @Nome, Email = @Email, Senha = @Senha, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = yUser.Nome,
                Email = yUser.Email,
                Senha = yUser.Senha,
                TenantID = yUser.TenantID,
                Deleted = yUser.Deleted,
                Changed = yUser.Changed,
                Id = yUser.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IyUserEntity entity)
        {
            this.Query = $@" UPDATE yUser SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmail(IyUserEntity entity)
        {
            this.Query = $@" UPDATE yUser SET Email = @Email WHERE Id = @Id ";
            this.Parameters = new
            {
                Email = entity.Email,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSenha(IyUserEntity entity)
        {
            this.Query = $@" UPDATE yUser SET Senha = @Senha WHERE Id = @Id ";
            this.Parameters = new
            {
                Senha = entity.Senha,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyUserEntity entity)
        {
            this.Query = $@" UPDATE yUser SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyUserEntity entity)
        {
            this.Query = $@" UPDATE yUser SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyUserEntity entity)
        {
            this.Query = $@" UPDATE yUser SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyUserQuery(IyUserEntity yUser)
        {
            this.Query = $@" DELETE FROM yUser WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yUser.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration