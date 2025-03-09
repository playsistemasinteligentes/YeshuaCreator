using Comandos.Pateners.Command;
using Dominio.Entitys.Paciente;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeletePacienteReceiver : ReciverBase
    {
        private readonly IPacienteWriteRepository _repository;

        public DeletePacienteReceiver(IPacienteWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Command.Commands.PacienteCrudCommand)comand;

            var paciente = new PacienteEntity(c.Id, c.Nome, c.Telefone, c.DataNascimento, c.Genero, c.Escolaridade, c.Profissao, c.Endereco, c.NomeResponsavel, c.TelefoneResponsavel, c.PrincipaisQueixas, c.ObservacaoAdicional);
            if (!paciente.isValidDelete())
                return new State(300, paciente.getErroMensagens(), comand);

            try
            {
                _repository.Delete(paciente);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, e, comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration