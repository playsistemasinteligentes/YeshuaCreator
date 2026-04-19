using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class ySagaStepReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<ySagaStepTenantIDDTO>>
    {
        private readonly IySagaStepReadRepository _repository;

        public ySagaStepReadFKTenantIDReceiver(IySagaStepReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ySagaStepTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ySagaStepReadRepository = _repository.getySagaStepReadFKTenantID(c);
                return Success("OK", ySagaStepReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration