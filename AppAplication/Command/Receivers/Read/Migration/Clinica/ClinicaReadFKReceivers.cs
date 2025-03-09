using Comandos.Pateners.Command;
using Dominio.Entitys.Clinica;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;

namespace Command.Receivers.Read
{
    public class ClinicaReadFKReceiver : ReciverBase
    {
        private readonly IClinicaReadRepository _repository;

        public ClinicaReadFKReceiver(IClinicaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var ClinicaReadRepository = _repository.getAllClinica();
            return new State(200, "OK", ClinicaReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration