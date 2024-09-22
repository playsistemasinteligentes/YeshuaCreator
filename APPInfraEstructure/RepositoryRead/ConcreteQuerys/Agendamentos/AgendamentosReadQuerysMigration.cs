using Dominio.Entitys.Agendamentos;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Agendamentos
{
    public class AgendamentosReadQuery : QueryBase
    {
        public QueryModel SelectAllAgendamentosQuery()
        {
            this.Query = $@" select Id, PacienteId, ProfissionalId, ServicoId, DataHora, Status from Agendamentos ";
            return new QueryModel(this.Query, null);
        }
    }
}
