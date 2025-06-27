using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Read.Repository.Y_User;
using Repositorio.Outputs.DTOs.Y_User;

namespace Command.Receivers.Read
{
    public class Y_UserReadFKTenantIDReceiver : ReciverBase<IEnumerable<Y_UserTenantIDDTO>>
    {
        private readonly IY_UserReadRepository _repository;

        public Y_UserReadFKTenantIDReceiver(IY_UserReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_UserTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Y_UserReadRepository = _repository.getY_UserReadFKTenantID(c);
                return Success("OK", Y_UserReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration