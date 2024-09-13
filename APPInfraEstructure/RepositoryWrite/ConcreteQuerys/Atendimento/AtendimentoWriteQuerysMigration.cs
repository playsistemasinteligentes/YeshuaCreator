using Dominio.Entitys.Atendimento;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Atendimento
{
    public class AtendimentoWriteQuery : QueryBase
    {
        public QueryModel InserirAtendimentoQuery(AtendimentoEntity Atendimento)
        {
            this.Query = $@" INSERT INTO Atendimento (Status, UltimaInteracao) VALUES(@Status, @UltimaInteracao) ";
            this.Parameters = new
            {
                Status = Atendimento.Status,
                UltimaInteracao = Atendimento.UltimaInteracao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
