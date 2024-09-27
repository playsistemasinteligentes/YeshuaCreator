using Comandos.Pateners.Command;
using Dominio.Entitys.Agendamentos;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.Agendamentos
{
    public class InsertAgendamentosReceiver : ReciverBase
    {
        private readonly IAgendamentosWriteRepository _repository;

        public InsertAgendamentosReceiver(IAgendamentosWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.AgendamentosCommand)comand;

            var agendamentos = new AgendamentosEntity(c.Id, c.PacienteId, c.ProfissionalId, c.ServicoId, c.DataHora, c.Status);
            if (!agendamentos.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Insert(agendamentos);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
