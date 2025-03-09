using Comandos.Pateners.Command;
using Dominio.Entitys.Sesoes;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadFKReceiver : ReciverBase
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadFKReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var SesoesReadRepository = _repository.getAllSesoes();
            return new State(200, "OK", SesoesReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration