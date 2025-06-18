using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using RepositoryInterfaces.Read.Repository.Y_UserPermitions;
using Repositorio.Outputs.DTOs.Y_UserPermitions;

namespace Command.Receivers.Read
{
    public class Y_UserPermitionsReadFKUserIdReceiver : ReciverBase<IEnumerable<Y_UserPermitionsUserIdDTO>>
    {
        private readonly IY_UserPermitionsReadRepository _repository;

        public Y_UserPermitionsReadFKUserIdReceiver(IY_UserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_UserPermitionsUserIdDTO>> Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var Y_UserPermitionsReadRepository = _repository.getY_UserPermitionsReadFKUserId(c);
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