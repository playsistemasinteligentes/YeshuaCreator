using Dominio.Entitys.Y_Company;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_Company
{
    public class Y_CompanyWriteQuery : QueryBase
    {
        public QueryModel InserirY_CompanyQuery(Y_CompanyEntity Y_Company)
        {
            this.Query = $@" INSERT INTO Y_Company (Nome, ProxyServer, UserIDAdmin) OUTPUT INSERTED.Id VALUES(@Nome, @ProxyServer, @UserIDAdmin) ";
            this.Parameters = new
            {
                Nome = Y_Company.Nome,
                ProxyServer = Y_Company.ProxyServer,
                UserIDAdmin = Y_Company.UserIDAdmin,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_CompanyQuery(Y_CompanyEntity Y_Company)
        {
            this.Query = $@" UPDATE Y_Company SET Nome = @Nome, ProxyServer = @ProxyServer, UserIDAdmin = @UserIDAdmin WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Y_Company.Nome,
                ProxyServer = Y_Company.ProxyServer,
                UserIDAdmin = Y_Company.UserIDAdmin,
                Id = Y_Company.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_CompanyQuery(Y_CompanyEntity Y_Company)
        {
            this.Query = $@" DELETE FROM Y_Company WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Y_Company.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration