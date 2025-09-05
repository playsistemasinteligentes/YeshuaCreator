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
    public class ServicoQueryWrite : QueryBase, IServicoQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public ServicoQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirServicoQuery(IServicoEntity Servico)
        {
            this.Query = $@" INSERT INTO Servico (GrupoServicoId, Nome, Valor, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@GrupoServicoId, @Nome, @Valor, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GrupoServicoId = Servico.GrupoServicoId,
                Nome = Servico.Nome,
                Valor = Servico.Valor,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateServicoQuery(IServicoEntity Servico)
        {
            this.Query = $@" UPDATE Servico SET GrupoServicoId = @GrupoServicoId, Nome = @Nome, Valor = @Valor, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                GrupoServicoId = Servico.GrupoServicoId,
                Nome = Servico.Nome,
                Valor = Servico.Valor,
                TenantID = Servico.TenantID,
                Deleted = Servico.Deleted,
                Changed = Servico.Changed,
                UserId = Servico.UserId,
                Id = Servico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoServicoId(IServicoEntity entity)
        {
            this.Query = $@" UPDATE Servico SET GrupoServicoId = @GrupoServicoId WHERE Id = @Id ";
            this.Parameters = new
            {
                GrupoServicoId = entity.GrupoServicoId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IServicoEntity entity)
        {
            this.Query = $@" UPDATE Servico SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValor(IServicoEntity entity)
        {
            this.Query = $@" UPDATE Servico SET Valor = @Valor WHERE Id = @Id ";
            this.Parameters = new
            {
                Valor = entity.Valor,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IServicoEntity entity)
        {
            this.Query = $@" UPDATE Servico SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IServicoEntity entity)
        {
            this.Query = $@" UPDATE Servico SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IServicoEntity entity)
        {
            this.Query = $@" UPDATE Servico SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IServicoEntity entity)
        {
            this.Query = $@" UPDATE Servico SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteServicoQuery(IServicoEntity Servico)
        {
            this.Query = $@" DELETE FROM Servico WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Servico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration