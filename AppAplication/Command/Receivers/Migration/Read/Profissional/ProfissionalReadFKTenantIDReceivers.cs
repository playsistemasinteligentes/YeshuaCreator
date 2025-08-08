using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class ProfissionalReadFKTenantIDReceiver : ReciverBase<IEnumerable<ProfissionalTenantIDDTO>>
    {
        private readonly IProfissionalReadRepository _repository;

        public ProfissionalReadFKTenantIDReceiver(IProfissionalReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ProfissionalTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissionalReadFKTenantID(c);
                return Success("OK", ProfissionalReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration