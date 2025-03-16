using Comandos.Pateners.Command;
using Dominio.Entitys.Servico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using RepositoryInterfaces.Read.Repository.Servico;

namespace Command.Receivers.Read
{
    public class ServicoReadFKGrupoServicoIdReceiver : ReciverBase
    {
        private readonly IServicoReadRepository _repository;

        public ServicoReadFKGrupoServicoIdReceiver(IServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var ServicoReadRepository = _repository.getServicoReadFKGrupoServicoId(c);
                return new State(200, "OK", ServicoReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration