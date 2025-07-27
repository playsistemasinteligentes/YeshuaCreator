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
    public class YuserQueryWrite : QueryBase, IYuserQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YuserQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYuserQuery(IYuserEntity Yuser)
        {
            this.Query = $@" INSERT INTO Yuser (Nome, Email, Senha, TenantID, Deleted, Changed) OUTPUT INSERTED.Id VALUES(@Nome, @Email, @Senha, @TenantID, @Deleted, @Changed) ";
            this.Parameters = new
            {
                Nome = Yuser.Nome,
                Email = Yuser.Email,
                Senha = Yuser.Senha,
                TenantID = Yuser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYuserQuery(IYuserEntity Yuser)
        {
            this.Query = $@" UPDATE Yuser SET Nome = @Nome, Email = @Email, Senha = @Senha, TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Yuser.Nome,
                Email = Yuser.Email,
                Senha = Yuser.Senha,
                TenantID = Yuser.TenantID,
                Id = Yuser.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IYuserEntity entity)
        {
            this.Query = $@" UPDATE Yuser SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmail(IYuserEntity entity)
        {
            this.Query = $@" UPDATE Yuser SET Email = @Email WHERE Id = @Id ";
            this.Parameters = new
            {
                Email = entity.Email,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSenha(IYuserEntity entity)
        {
            this.Query = $@" UPDATE Yuser SET Senha = @Senha WHERE Id = @Id ";
            this.Parameters = new
            {
                Senha = entity.Senha,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IYuserEntity entity)
        {
            this.Query = $@" UPDATE Yuser SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYuserQuery(IYuserEntity Yuser)
        {
            this.Query = $@" DELETE FROM Yuser WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Yuser.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration