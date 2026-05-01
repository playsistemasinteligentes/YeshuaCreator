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
            this.Query = $@" UPDATE Servico SET GrupoServicoId = @GrupoServicoId, Nome = @Nome, Valor = @Valor, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                GrupoServicoId = Servico.GrupoServicoId,
                Nome = Servico.Nome,
                Valor = Servico.Valor,
                Changed = Servico.Changed,
                UserId = _currentUser.UserId,
                Id = Servico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoServicoId(int id, int value)
        {
            this.Query = $@" UPDATE Servico SET GrupoServicoId = @GrupoServicoId WHERE Id = @Id ";
            this.Parameters = new
            {
                GrupoServicoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE Servico SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValor(int id, Decimal value)
        {
            this.Query = $@" UPDATE Servico SET Valor = @Valor WHERE Id = @Id ";
            this.Parameters = new
            {
                Valor = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Servico SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Servico SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Servico SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Servico SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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