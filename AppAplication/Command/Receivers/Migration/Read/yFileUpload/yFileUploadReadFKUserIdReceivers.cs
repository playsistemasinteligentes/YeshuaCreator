using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yFileUploadReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<yFileUploadUserIdDTO>>
    {
        private readonly IyFileUploadReadRepository _repository;

        public yFileUploadReadFKUserIdReceiver(IyFileUploadReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yFileUploadUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yFileUploadReadRepository = _repository.getyFileUploadReadFKUserId(c);
                return Success("OK", yFileUploadReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration