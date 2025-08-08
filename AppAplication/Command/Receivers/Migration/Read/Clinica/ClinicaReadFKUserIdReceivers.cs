using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class ClinicaReadFKUserIdReceiver : ReciverBase<IEnumerable<ClinicaUserIdDTO>>
    {
        private readonly IClinicaReadRepository _repository;

        public ClinicaReadFKUserIdReceiver(IClinicaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ClinicaUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ClinicaReadRepository = _repository.getClinicaReadFKUserId(c);
                return Success("OK", ClinicaReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration