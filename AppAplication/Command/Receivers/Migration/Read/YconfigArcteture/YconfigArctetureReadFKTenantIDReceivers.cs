using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YconfigArctetureReadFKTenantIDReceiver : ReciverBase<IEnumerable<YconfigArctetureTenantIDDTO>>
    {
        private readonly IYconfigArctetureReadRepository _repository;

        public YconfigArctetureReadFKTenantIDReceiver(IYconfigArctetureReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YconfigArctetureTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YconfigArctetureReadRepository = _repository.getYconfigArctetureReadFKTenantID(c);
                return Success("OK", YconfigArctetureReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration