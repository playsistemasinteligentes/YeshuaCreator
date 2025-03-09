using Comandos.Pateners.Command;
using Dominio.Entitys.GrupoServico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.GrupoServico;
using RepositoryInterfaces.Read.Repository.GrupoServico;

namespace Command.Receivers.Read
{
    public class GrupoServicoReadReceiver : ReciverBase
    {
        private readonly IGrupoServicoReadRepository _repository;

        public GrupoServicoReadReceiver(IGrupoServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var GrupoServicoReadRepository = _repository.getAllGrupoServico();
            return new State(200, "OK", GrupoServicoReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration