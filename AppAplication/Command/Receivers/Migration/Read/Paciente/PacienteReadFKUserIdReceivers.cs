using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class PacienteReadFKUserIdReceiver : ReciverBase<IEnumerable<PacienteUserIdDTO>>
    {
        private readonly IPacienteReadRepository _repository;

        public PacienteReadFKUserIdReceiver(IPacienteReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<PacienteUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var PacienteReadRepository = _repository.getPacienteReadFKUserId(c);
                return Success("OK", PacienteReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration