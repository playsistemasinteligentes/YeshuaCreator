using Comandos.Pateners.Command;
using Dominio.Entitys.Profissional;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using RepositoryInterfaces.Read.Repository.Profissional;

namespace Command.Receivers.Read
{
    public class ProfissionalReadReceiver : ReciverBase
    {
        private readonly IProfissionalReadRepository _repository;

        public ProfissionalReadReceiver(IProfissionalReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var ProfissionalReadRepository = _repository.getAllProfissional();
            return new State(200, "OK", ProfissionalReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration