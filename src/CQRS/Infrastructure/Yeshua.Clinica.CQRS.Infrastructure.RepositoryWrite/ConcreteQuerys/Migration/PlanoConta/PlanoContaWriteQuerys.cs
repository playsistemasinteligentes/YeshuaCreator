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
    public class PlanoContaQueryWrite : QueryBase, IPlanoContaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PlanoContaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPlanoContaQuery(IPlanoContaEntity PlanoConta)
        {
            this.Query = $@" INSERT INTO PlanoConta (Codigo, Nome, Tipo, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Codigo, @Nome, @Tipo, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Codigo = PlanoConta.Codigo,
                Nome = PlanoConta.Nome,
                Tipo = PlanoConta.Tipo,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlanoContaQuery(IPlanoContaEntity PlanoConta)
        {
            this.Query = $@" UPDATE PlanoConta SET Codigo = @Codigo, Nome = @Nome, Tipo = @Tipo, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Codigo = PlanoConta.Codigo,
                Nome = PlanoConta.Nome,
                Tipo = PlanoConta.Tipo,
                Changed = PlanoConta.Changed,
                UserId = _executionContext.UserId,
                Id = PlanoConta.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCodigo(int id, string value)
        {
            this.Query = $@" UPDATE PlanoConta SET Codigo = @Codigo WHERE Id = @Id ";
            this.Parameters = new
            {
                Codigo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE PlanoConta SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipo(int id, int value)
        {
            this.Query = $@" UPDATE PlanoConta SET Tipo = @Tipo WHERE Id = @Id ";
            this.Parameters = new
            {
                Tipo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE PlanoConta SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE PlanoConta SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE PlanoConta SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE PlanoConta SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePlanoContaQuery(IPlanoContaEntity PlanoConta)
        {
            this.Query = $@" DELETE FROM PlanoConta WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = PlanoConta.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration