using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class SesoesReadFKPacienteIdReceiver : ReciverBase<ICommand, IEnumerable<SesoesPacienteIdDTO>>
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