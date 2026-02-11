using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yInboxReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<yInboxUserIdDTO>>
    {
        private readonly IyInboxReadRepository _repository;

        public yInboxReadFKUserIdReceiver(IyInboxReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yInboxUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yInboxReadRepository = _repository.getyInboxReadFKUserId(c);
                return Success("OK", yInboxReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration