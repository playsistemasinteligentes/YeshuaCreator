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
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoesReadFKServicoId(c);
                return new State(200, "OK", SesoesReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration