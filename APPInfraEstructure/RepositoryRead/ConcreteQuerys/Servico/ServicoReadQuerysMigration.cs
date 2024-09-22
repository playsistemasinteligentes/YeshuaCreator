using Dominio.Entitys.Servico;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Servico
{
    public class ServicoReadQuery : QueryBase
    {
        public QueryModel SelectAllServicoQuery()
        {
            this.Query = $@" select Id, GrupoServicoId, Nome, Valor from Servico ";
            return new QueryModel(this.Query, null);
        }
    }
}
