using Dominio.Entitys.Profissional;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Profissional
{
    public class ProfissionalReadQuery : QueryBase
    {
        public QueryModel SelectAllProfissionalQuery()
        {
            this.Query = $@" select Id, Nome, EspecialidadeId, Telefone from Profissional ";
            return new QueryModel(this.Query, null);
        }
    }
}
