using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Read.RepositoryInterfaces;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class Y_PerfilPermitionsReadFKPermitionsIdReceiver : ReciverBase<IEnumerable<Y_PerfilPermitionsPermitionsIdDTO>>
    {
        private readonly IY_PerfilPermitionsReadRepository _repository;

        public Y_PerfilPermitionsReadFKPermitionsIdReceiver(IY_PerfilPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_PerfilPermitionsPermitionsIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Y_PerfilPermitionsReadRepository = _repository.getY_PerfilPermitionsReadFKPermitionsId(c);
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