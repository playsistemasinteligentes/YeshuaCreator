using Dominio.Entitys.Atendimento;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Atendimento
{
    public class AtendimentoReadQuery : QueryBase
    {
        public QueryModel SelectAllAtendimentoQuery()
        {
            this.Query = $@" select Id, Status, UltimaInteracao from Atendimento ";
            return new QueryModel(this.Query, null);
        }
    }
}
