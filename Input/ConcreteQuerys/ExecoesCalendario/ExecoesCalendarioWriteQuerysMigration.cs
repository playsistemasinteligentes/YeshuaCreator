using Dominio.Entitys.ExecoesCalendario;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.ExecoesCalendario
{
    public class ExecoesCalendarioWriteQuery : QueryBase
    {
        public QueryModel InserirExecoesCalendarioQuery(ExecoesCalendarioEntity ExecoesCalendario)
        {
            this.Query = $@" INSERT INTO ExecoesCalendario (De, Ate) VALUES(@De, @Ate) ";
            this.Parameters = new
            {
                De = ExecoesCalendario.De,
                Ate = ExecoesCalendario.Ate,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
