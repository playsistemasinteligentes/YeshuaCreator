using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class EspecialidadeReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<EspecialidadeTenantIDDTO>>
    {
        private readonly IEspecialidadeReadRepository _repository;

        public EspecialidadeReadFKTenantIDReceiver(IEspecialidadeReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<EspecialidadeTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var EspecialidadeReadRepository = _repository.getEspecialidadeReadFKTenantID(c);
                return Success("OK", EspecialidadeReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration