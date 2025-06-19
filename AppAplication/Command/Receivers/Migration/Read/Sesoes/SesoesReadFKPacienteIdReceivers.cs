using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;
using Repositorio.Outputs.DTOs.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadFKPacienteIdReceiver : ReciverBase<IEnumerable<SesoesPacienteIdDTO>>
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadFKPacienteIdReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<SesoesPacienteIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoesReadFKPacienteId(c);
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