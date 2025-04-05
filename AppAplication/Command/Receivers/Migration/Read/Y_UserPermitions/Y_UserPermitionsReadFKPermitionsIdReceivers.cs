using Comandos.Pateners.Command;
using Dominio.Entitys.Y_UserPermitions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using RepositoryInterfaces.Read.Repository.Y_UserPermitions;

namespace Command.Receivers.Read
{
    public class Y_UserPermitionsReadFKPermitionsIdReceiver : ReciverBase
    {
        private readonly IY_UserPermitionsReadRepository _repository;

        public Y_UserPermitionsReadFKPermitionsIdReceiver(IY_UserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var Y_UserPermitionsReadRepository = _repository.getY_UserPermitionsReadFKPermitionsId(c);
                return Success("OK", Y_UserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration