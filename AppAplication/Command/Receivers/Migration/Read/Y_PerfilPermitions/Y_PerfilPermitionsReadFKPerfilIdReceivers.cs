using Comandos.Pateners.Command;
using Dominio.Entitys.Y_PerfilPermitions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using RepositoryInterfaces.Read.Repository.Y_PerfilPermitions;

namespace Command.Receivers.Read
{
    public class Y_PerfilPermitionsReadFKPerfilIdReceiver : ReciverBase
    {
        private readonly IY_PerfilPermitionsReadRepository _repository;

        public Y_PerfilPermitionsReadFKPerfilIdReceiver(IY_PerfilPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var Y_PerfilPermitionsReadRepository = _repository.getY_PerfilPermitionsReadFKPerfilId(c);
                return Success("OK", Y_PerfilPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration