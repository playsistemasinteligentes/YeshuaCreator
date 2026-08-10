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
        protected readonly IExecutionContext _executionContext;
        public yTenantQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
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
            this.Query = $@" UPDATE yTenant SET CnpjCpf = @CnpjCpf, Nome = @Nome, UserId = @UserId, Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = yTenant.CnpjCpf,
                Nome = yTenant.Nome,
                UserId = _executionContext.UserId,
                Changed = yTenant.Changed,
                Id = yTenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCnpjCpf(int id, string value)
        {
            this.Query = $@" UPDATE yTenant SET CnpjCpf = @CnpjCpf WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE yTenant SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yTenant SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yTenant SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yTenant SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
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