using Comandos.Pateners.Command;
using Dominio.Entitys.Paciente;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Paciente;
using RepositoryInterfaces.Read.Repository.Paciente;

namespace Command.Receivers.Read
{
    public class PacienteReadFKReceiver : ReciverBase
    {
        private readonly IPacienteReadRepository _repository;

        public PacienteReadFKReceiver(IPacienteReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var PacienteReadRepository = _repository.getAllPaciente();
            return new State(200, "OK", PacienteReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration