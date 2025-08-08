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
    public class yTenantQueryWrite : QueryBase, IyTenantQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public yTenantQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InseriryTenantQuery(IyTenantEntity yTenant)
        {
            this.Query = $@" INSERT INTO yTenant (CnpjCpf, Nome, UserId, Deleted, Changed) OUTPUT INSERTED.Id VALUES(@CnpjCpf, @Nome, @UserId, @Deleted, @Changed) ";
            this.Parameters = new
            {
                CnpjCpf = yTenant.CnpjCpf,
                Nome = yTenant.Nome,
                UserId = yTenant.UserId,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyTenantQuery(IyTenantEntity yTenant)
        {
            this.Query = $@" UPDATE yTenant SET CnpjCpf = @CnpjCpf, Nome = @Nome, UserId = @UserId, Deleted = @Deleted, Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = yTenant.CnpjCpf,
                Nome = yTenant.Nome,
                UserId = yTenant.UserId,
                Deleted = yTenant.Deleted,
                Changed = yTenant.Changed,
                Id = yTenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCnpjCpf(IyTenantEntity entity)
        {
            this.Query = $@" UPDATE yTenant SET CnpjCpf = @CnpjCpf WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = entity.CnpjCpf,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IyTenantEntity entity)
        {
            this.Query = $@" UPDATE yTenant SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyTenantEntity entity)
        {
            this.Query = $@" UPDATE yTenant SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyTenantEntity entity)
        {
            this.Query = $@" UPDATE yTenant SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyTenantEntity entity)
        {
            this.Query = $@" UPDATE yTenant SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyTenantQuery(IyTenantEntity yTenant)
        {
            this.Query = $@" DELETE FROM yTenant WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yTenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration