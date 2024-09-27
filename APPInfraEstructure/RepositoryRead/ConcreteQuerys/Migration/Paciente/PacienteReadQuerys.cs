using Dominio.Entitys.Paciente;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Paciente
{
    public class PacienteReadQuery : QueryBase
    {
        public QueryModel SelectAllPacienteQuery()
        {
            this.Query = $@" select Id, Nome, Telefone from Paciente ";
            return new QueryModel(this.Query, null);
        }
    }
}
