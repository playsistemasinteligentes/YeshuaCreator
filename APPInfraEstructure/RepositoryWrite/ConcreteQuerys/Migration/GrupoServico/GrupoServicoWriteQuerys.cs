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
    public class GrupoServicoQueryWrite : QueryBase, IGrupoServicoQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public GrupoServicoQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirGrupoServicoQuery(IGrupoServicoEntity GrupoServico)
        {
            this.Query = $@" INSERT INTO GrupoServico (Descricao, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Descricao, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Descricao = GrupoServico.Descricao,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoServicoQuery(IGrupoServicoEntity GrupoServico)
        {
            this.Query = $@" UPDATE GrupoServico SET Descricao = @Descricao, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = GrupoServico.Descricao,
                Changed = GrupoServico.Changed,
                UserId = _currentUser.UserId,
                Id = GrupoServico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(IGrupoServicoEntity entity)
        {
            this.Query = $@" UPDATE GrupoServico SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = entity.Descricao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IGrupoServicoEntity entity)
        {
            this.Query = $@" UPDATE GrupoServico SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IGrupoServicoEntity entity)
        {
            this.Query = $@" UPDATE GrupoServico SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IGrupoServicoEntity entity)
        {
            this.Query = $@" UPDATE GrupoServico SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IGrupoServicoEntity entity)
        {
            this.Query = $@" UPDATE GrupoServico SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoServicoQuery(IGrupoServicoEntity GrupoServico)
        {
            this.Query = $@" DELETE FROM GrupoServico WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = GrupoServico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration