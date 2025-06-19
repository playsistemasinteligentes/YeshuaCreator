using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using RepositoryInterfaces.Read.Repository.Y_PerfilPermitions;
using Repositorio.Outputs.DTOs.Y_PerfilPermitions;

namespace Command.Receivers.Read
{
    public class Y_PerfilPermitionsReadFKPerfilIdReceiver : ReciverBase<IEnumerable<Y_PerfilPermitionsPerfilIdDTO>>
    {
        private readonly IY_PerfilPermitionsReadRepository _repository;

        public Y_PerfilPermitionsReadFKPerfilIdReceiver(IY_PerfilPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_PerfilPermitionsPerfilIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Y_PerfilPermitionsReadRepository = _repository.getY_PerfilPermitionsReadFKPerfilId(c);
                return Success("OK", Y_PerfilPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration