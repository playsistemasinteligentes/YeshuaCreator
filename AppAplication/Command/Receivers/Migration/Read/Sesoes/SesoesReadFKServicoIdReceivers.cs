using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;
using Repositorio.Outputs.DTOs.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadFKServicoIdReceiver : ReciverBase<IEnumerable<SesoesServicoIdDTO>>
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadFKServicoIdReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<SesoesServicoIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoesReadFKServicoId(c);
                return Success("OK", SesoesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration