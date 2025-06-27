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
        public QueryModel InserirY_TenantQuery(Y_TenantEntity Y_Tenant)
        {
            this.Query = $@" INSERT INTO Y_Tenant (Nome, ProxyServer, UserIDAdmin) OUTPUT INSERTED.Id VALUES(@Nome, @ProxyServer, @UserIDAdmin) ";
            this.Parameters = new
            {
                Nome = Y_Tenant.Nome,
                ProxyServer = Y_Tenant.ProxyServer,
                UserIDAdmin = Y_Tenant.UserIDAdmin,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_TenantQuery(Y_TenantEntity Y_Tenant)
        {
            this.Query = $@" UPDATE Y_Tenant SET Nome = @Nome, ProxyServer = @ProxyServer, UserIDAdmin = @UserIDAdmin WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Y_Tenant.Nome,
                ProxyServer = Y_Tenant.ProxyServer,
                UserIDAdmin = Y_Tenant.UserIDAdmin,
                Id = Y_Tenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_TenantQuery(Y_TenantEntity Y_Tenant)
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