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
    public class YtenantQueryWrite : QueryBase, IYtenantQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YtenantQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYtenantQuery(IYtenantEntity Ytenant)
        {
            this.Query = $@" INSERT INTO Ytenant (CnpjCpf, Nome, UserId, Deleted, Changed) OUTPUT INSERTED.Id VALUES(@CnpjCpf, @Nome, @UserId, @Deleted, @Changed) ";
            this.Parameters = new
            {
                CnpjCpf = Ytenant.CnpjCpf,
                Nome = Ytenant.Nome,
                UserId = Ytenant.UserId,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYtenantQuery(IYtenantEntity Ytenant)
        {
            this.Query = $@" UPDATE Ytenant SET CnpjCpf = @CnpjCpf, Nome = @Nome, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CnpjCpf = Ytenant.CnpjCpf,
                Nome = Ytenant.Nome,
                UserId = Ytenant.UserId,
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
        public QueryModel UpdateUserId(IYtenantEntity entity)
        {
            this.Query = $@" UPDATE Ytenant SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration