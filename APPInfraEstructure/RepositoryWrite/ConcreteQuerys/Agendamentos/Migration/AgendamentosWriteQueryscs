using Dominio.Entitys.Agendamentos;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Agendamentos
{
    public class AgendamentosWriteQuery : QueryBase
    {
        public QueryModel InserirAgendamentosQuery(AgendamentosEntity Agendamentos)
        {
            this.Query = $@" INSERT INTO Agendamentos (PacienteId, ProfissionalId, ServicoId, DataHora, Status) VALUES(@PacienteId, @ProfissionalId, @ServicoId, @DataHora, @Status) ";
            this.Parameters = new
            {
                PacienteId = Agendamentos.PacienteId,
                ProfissionalId = Agendamentos.ProfissionalId,
                ServicoId = Agendamentos.ServicoId,
                DataHora = Agendamentos.DataHora,
                Status = Agendamentos.Status,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
