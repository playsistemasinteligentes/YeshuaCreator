using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yPerfilGrantReadFKPerfilIdReceiver : ReciverBase<IEnumerable<yPerfilGrantPerfilIdDTO>>
    {
        private readonly IyPerfilGrantReadRepository _repository;

        public yPerfilGrantReadFKPerfilIdReceiver(IyPerfilGrantReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yPerfilGrantPerfilIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yPerfilGrantReadRepository = _repository.getyPerfilGrantReadFKPerfilId(c);
                return Success("OK", yPerfilGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration