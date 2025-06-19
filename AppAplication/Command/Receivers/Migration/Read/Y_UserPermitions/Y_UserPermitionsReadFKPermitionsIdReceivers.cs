using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using RepositoryInterfaces.Read.Repository.Y_UserPermitions;
using Repositorio.Outputs.DTOs.Y_UserPermitions;

namespace Command.Receivers.Read
{
    public class Y_UserPermitionsReadFKPermitionsIdReceiver : ReciverBase<IEnumerable<Y_UserPermitionsPermitionsIdDTO>>
    {
        private readonly IY_UserPermitionsReadRepository _repository;

        public Y_UserPermitionsReadFKPermitionsIdReceiver(IY_UserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_UserPermitionsPermitionsIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Y_UserPermitionsReadRepository = _repository.getY_UserPermitionsReadFKPermitionsId(c);
                return Success("OK", Y_UserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration