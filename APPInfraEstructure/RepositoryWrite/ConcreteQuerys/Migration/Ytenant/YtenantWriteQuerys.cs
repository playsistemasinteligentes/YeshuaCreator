using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Ytenant
{
    public class YtenantWriteQuery : QueryBase
    {
        public QueryModel InserirYtenantQuery(IYtenantEntity Ytenant)
        {
            this.Query = $@" INSERT INTO Ytenant (CnpjCpf, Nome, UserIDAdmin) OUTPUT INSERTED.Id VALUES(@CnpjCpf, @Nome, @UserIDAdmin) ";
            this.Parameters = new
            {
                CnpjCpf = Ytenant.CnpjCpf,
                Nome = Ytenant.Nome,
                UserIDAdmin = Ytenant.UserIDAdmin,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYtenantQuery(IYtenantEntity Ytenant)
        {
            this.Query = $@" UPDATE Ytenant SET CnpjCpf = @CnpjCpf, Nome = @Nome, UserIDAdmin = @UserIDAdmin WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = Ytenant.CnpjCpf,
                Nome = Ytenant.Nome,
                UserIDAdmin = Ytenant.UserIDAdmin,
                Id = Ytenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCnpjCpf(IYtenantEntity entity)
        {
            this.Query = $@" UPDATE Ytenant SET CnpjCpf = @CnpjCpf WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = entity.CnpjCpf,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IYtenantEntity entity)
        {
            this.Query = $@" UPDATE Ytenant SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserIDAdmin(IYtenantEntity entity)
        {
            this.Query = $@" UPDATE Ytenant SET UserIDAdmin = @UserIDAdmin WHERE Id = @Id ";
            this.Parameters = new
            {
                UserIDAdmin = entity.UserIDAdmin,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYtenantQuery(IYtenantEntity Ytenant)
        {
            this.Query = $@" DELETE FROM Ytenant WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Ytenant.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration