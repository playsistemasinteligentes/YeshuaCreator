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
        protected readonly IExecutionContext _executionContext;
        public yUserQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryUserQuery(IyUserEntity yUser)
        {
            this.Query = $@" INSERT INTO yUser (Nome, Email, Senha, TenantID, Deleted, Changed) OUTPUT INSERTED.Id VALUES(@Nome, @Email, @Senha, @TenantID, @Deleted, @Changed) ";
            this.Parameters = new
            {
                Nome = yUser.Nome,
                Email = yUser.Email,
                Senha = yUser.Senha,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyUserQuery(IyUserEntity yUser)
        {
            this.Query = $@" UPDATE yUser SET Nome = @Nome, Email = @Email, Senha = @Senha, Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = yUser.Nome,
                Email = yUser.Email,
                Senha = yUser.Senha,
                Changed = yUser.Changed,
                Id = yUser.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE yUser SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmail(int id, string value)
        {
            this.Query = $@" UPDATE yUser SET Email = @Email WHERE Id = @Id ";
            this.Parameters = new
            {
                Email = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSenha(int id, string value)
        {
            this.Query = $@" UPDATE yUser SET Senha = @Senha WHERE Id = @Id ";
            this.Parameters = new
            {
                Senha = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yUser SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yUser SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yUser SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
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