using Comandos.Pateners.Command;
using Dominio.Entitys.Paciente;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Paciente;
using RepositoryInterfaces.Read.Repository.Paciente;

namespace Command.Receivers.Read
{
    public class PacienteReadReceiver : ReciverBase
    {
        private readonly IPacienteReadRepository _repository;

        public PacienteReadReceiver(IPacienteReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.PacienteReadCommand c) 
             {    
                var PacienteReadRepository = _repository.getPaciente(c);
                return new State(200, "OK", PacienteReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration