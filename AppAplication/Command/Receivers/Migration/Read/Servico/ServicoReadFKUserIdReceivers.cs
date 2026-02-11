using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class ServicoReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<ServicoUserIdDTO>>
    {
        private readonly IServicoReadRepository _repository;

        public ServicoReadFKUserIdReceiver(IServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ServicoUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ServicoReadRepository = _repository.getServicoReadFKUserId(c);
                return Success("OK", ServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration