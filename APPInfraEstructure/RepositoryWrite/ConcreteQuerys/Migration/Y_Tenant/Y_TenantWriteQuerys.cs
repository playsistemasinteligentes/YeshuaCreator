using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_Tenant
{
    public class Y_TenantWriteQuery : QueryBase
    {
        public QueryModel InserirY_TenantQuery(IY_TenantEntity Y_Tenant)
        {
            this.Query = $@" INSERT INTO Y_Tenant (CnpjCpf, Nome, UserIDAdmin) OUTPUT INSERTED.Id VALUES(@CnpjCpf, @Nome, @UserIDAdmin) ";
            this.Parameters = new
            {
                CnpjCpf = Y_Tenant.CnpjCpf,
                Nome = Y_Tenant.Nome,
                UserIDAdmin = Y_Tenant.UserIDAdmin,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_TenantQuery(IY_TenantEntity Y_Tenant)
        {
            this.Query = $@" UPDATE Y_Tenant SET CnpjCpf = @CnpjCpf, Nome = @Nome, UserIDAdmin = @UserIDAdmin WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = Y_Tenant.CnpjCpf,
                Nome = Y_Tenant.Nome,
                UserIDAdmin = Y_Tenant.UserIDAdmin,
                Id = Y_Tenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCnpjCpf(IY_TenantEntity entity)
        {
            this.Query = $@" UPDATE Y_Tenant SET CnpjCpf = @CnpjCpf WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = entity.CnpjCpf,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IY_TenantEntity entity)
        {
            this.Query = $@" UPDATE Y_Tenant SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserIDAdmin(IY_TenantEntity entity)
        {
            this.Query = $@" UPDATE Y_Tenant SET UserIDAdmin = @UserIDAdmin WHERE Id = @Id ";
            this.Parameters = new
            {
                UserIDAdmin = entity.UserIDAdmin,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_TenantQuery(IY_TenantEntity Y_Tenant)
        {
            this.Query = $@" DELETE FROM Y_Tenant WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Y_Tenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration