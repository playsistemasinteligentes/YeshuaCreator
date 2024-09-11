using Dominio.Entitys.ExecoesCalendario;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.ExecoesCalendario
{
    public class ExecoesCalendarioReadQuery : QueryBase
    {
        public QueryModel SelectAllExecoesCalendarioQuery()
        {
            this.Query = $@" select Id, De, Ate from ExecoesCalendario ";
            return new QueryModel(this.Query, null);
        }
    }
}
