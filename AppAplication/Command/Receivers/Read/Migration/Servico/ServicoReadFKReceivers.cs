using Comandos.Pateners.Command;
using Dominio.Entitys.Servico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using RepositoryInterfaces.Read.Repository.Servico;

namespace Command.Receivers.Read
{
    public class ServicoReadFKReceiver : ReciverBase
    {
        private readonly IServicoReadRepository _repository;

        public ServicoReadFKReceiver(IServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var ServicoReadRepository = _repository.getAllServico();
            return new State(200, "OK", ServicoReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration