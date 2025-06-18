using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Servico
{
    public class ServicoWriteQuery : QueryBase
    {
        public QueryModel InserirServicoQuery(ServicoEntity Servico)
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
        public QueryModel UpdateServicoQuery(ServicoEntity Servico)
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
        public QueryModel DeleteServicoQuery(ServicoEntity Servico)
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration