using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yUserModuleReadFKModuleIdReceiver : ReciverBase<IEnumerable<yUserModuleModuleIdDTO>>
    {
        private readonly IyUserModuleReadRepository _repository;

        public yUserModuleReadFKModuleIdReceiver(IyUserModuleReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yUserModuleModuleIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yUserModuleReadRepository = _repository.getyUserModuleReadFKModuleId(c);
                return Success("OK", yUserModuleReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration