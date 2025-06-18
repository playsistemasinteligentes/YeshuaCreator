using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
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
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
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