using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yPerfilGrantReadFKGrantIdReceiver : ReciverBase<ICommand, IEnumerable<yPerfilGrantGrantIdDTO>>
    {
        private readonly IyPerfilGrantReadRepository _repository;

        public yPerfilGrantReadFKGrantIdReceiver(IyPerfilGrantReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yPerfilGrantGrantIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yPerfilGrantReadRepository = _repository.getyPerfilGrantReadFKGrantId(c);
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