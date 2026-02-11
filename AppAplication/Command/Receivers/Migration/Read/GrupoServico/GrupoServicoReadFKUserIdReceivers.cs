using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class GrupoServicoReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<GrupoServicoUserIdDTO>>
    {
        private readonly IGrupoServicoReadRepository _repository;

        public GrupoServicoReadFKUserIdReceiver(IGrupoServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<GrupoServicoUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var GrupoServicoReadRepository = _repository.getGrupoServicoReadFKUserId(c);
                return Success("OK", GrupoServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration