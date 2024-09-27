using Dominio.Entitys.Especialidade;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Especialidade
{
    public class EspecialidadeReadQuery : QueryBase
    {
        public QueryModel SelectAllEspecialidadeQuery()
        {
            this.Query = $@" select Id, Descricao from Especialidade ";
            return new QueryModel(this.Query, null);
        }
    }
}
