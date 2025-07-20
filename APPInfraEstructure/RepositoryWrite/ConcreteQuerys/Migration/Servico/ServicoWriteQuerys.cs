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
        protected readonly ICurrentUser _correntUser;
        public ServicoQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirServicoQuery(IServicoEntity Servico)
        {
            this.Query = $@" INSERT INTO Servico (GrupoServicoId, Nome, Valor) OUTPUT INSERTED.Id VALUES(@GrupoServicoId, @Nome, @Valor) ";
            this.Parameters = new
            {
                GrupoServicoId = Servico.GrupoServicoId,
                Nome = Servico.Nome,
                Valor = Servico.Valor,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateServicoQuery(IServicoEntity Servico)
        {
            this.Query = $@" UPDATE Servico SET GrupoServicoId = @GrupoServicoId, Nome = @Nome, Valor = @Valor WHERE Id = @Id ";
            this.Parameters = new
            {
                GrupoServicoId = Servico.GrupoServicoId,
                Nome = Servico.Nome,
                Valor = Servico.Valor,
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