using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Servico;
using RepositoryInterfaces.Read.Repository.Servico;
using Repositorio.Outputs.DTOs.Servico;

namespace Command.Receivers.Read
{
    public class ServicoReadFKGrupoServicoIdReceiver : ReciverBase<IEnumerable<ServicoGrupoServicoIdDTO>>
    {
        private readonly IServicoReadRepository _repository;

        public ServicoReadFKGrupoServicoIdReceiver(IServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ServicoGrupoServicoIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ServicoReadRepository = _repository.getServicoReadFKGrupoServicoId(c);
                return Success("OK", ServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration