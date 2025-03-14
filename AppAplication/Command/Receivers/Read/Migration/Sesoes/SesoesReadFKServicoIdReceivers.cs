using Comandos.Pateners.Command;
using Dominio.Entitys.Sesoes;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadFKServicoIdReceiver : ReciverBase
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadFKServicoIdReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var SesoesReadRepository = _repository.getSesoesReadFKServicoId(comand);
            return new State(200, "OK", SesoesReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration