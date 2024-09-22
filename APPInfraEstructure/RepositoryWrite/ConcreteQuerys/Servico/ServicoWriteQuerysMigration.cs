using Dominio.Entitys.Servico;
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
            this.Query = $@" INSERT INTO Servico (GrupoServicoId, Nome, Valor) VALUES(@GrupoServicoId, @Nome, @Valor) ";
            this.Parameters = new
            {
                GrupoServicoId = Servico.GrupoServicoId,
                Nome = Servico.Nome,
                Valor = Servico.Valor,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
