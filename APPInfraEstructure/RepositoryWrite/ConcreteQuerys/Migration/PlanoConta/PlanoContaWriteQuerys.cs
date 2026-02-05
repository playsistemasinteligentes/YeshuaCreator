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
        protected readonly ICurrentUser _currentUser;
        public PlanoContaQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirPlanoContaQuery(IPlanoContaEntity PlanoConta)
        {
            this.Query = $@" INSERT INTO PlanoConta (Codigo, Nome, Tipo, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Codigo, @Nome, @Tipo, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Codigo = PlanoConta.Codigo,
                Nome = PlanoConta.Nome,
                Tipo = PlanoConta.Tipo,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
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
                UserId = _currentUser.UserId,
                Id = PlanoConta.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCodigo(IPlanoContaEntity entity)
        {
            this.Query = $@" UPDATE PlanoConta SET Codigo = @Codigo WHERE Id = @Id ";
            this.Parameters = new
            {
                Codigo = entity.Codigo,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IPlanoContaEntity entity)
        {
            this.Query = $@" UPDATE PlanoConta SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipo(IPlanoContaEntity entity)
        {
            this.Query = $@" UPDATE PlanoConta SET Tipo = @Tipo WHERE Id = @Id ";
            this.Parameters = new
            {
                Tipo = entity.Tipo,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IPlanoContaEntity entity)
        {
            this.Query = $@" UPDATE PlanoConta SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IPlanoContaEntity entity)
        {
            this.Query = $@" UPDATE PlanoConta SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IPlanoContaEntity entity)
        {
            this.Query = $@" UPDATE PlanoConta SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IPlanoContaEntity entity)
        {
            this.Query = $@" UPDATE PlanoConta SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
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