using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yPerfilReadFKUserIdReceiver : ReciverBase<IEnumerable<yPerfilUserIdDTO>>
    {
        private readonly IyPerfilReadRepository _repository;

        public yPerfilReadFKUserIdReceiver(IyPerfilReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yPerfilUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yPerfilReadRepository = _repository.getyPerfilReadFKUserId(c);
                return Success("OK", yPerfilReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration