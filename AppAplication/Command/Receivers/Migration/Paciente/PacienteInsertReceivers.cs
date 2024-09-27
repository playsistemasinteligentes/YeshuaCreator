using Comandos.Pateners.Command;
using Dominio.Entitys.Paciente;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.Paciente
{
    public class InsertPacienteReceiver : ReciverBase
    {
        private readonly IPacienteWriteRepository _repository;

        public InsertPacienteReceiver(IPacienteWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.PacienteCommand)comand;

            var paciente = new PacienteEntity(c.Id, c.Nome, c.Telefone);
            if (!paciente.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Insert(paciente);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
