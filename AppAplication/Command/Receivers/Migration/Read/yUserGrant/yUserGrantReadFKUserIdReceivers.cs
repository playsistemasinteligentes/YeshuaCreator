using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yUserGrantReadFKUserIdReceiver : ReciverBase<IEnumerable<yUserGrantUserIdDTO>>
    {
        private readonly IyUserGrantReadRepository _repository;

        public yUserGrantReadFKUserIdReceiver(IyUserGrantReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yUserGrantUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yUserGrantReadRepository = _repository.getyUserGrantReadFKUserId(c);
                return Success("OK", yUserGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration