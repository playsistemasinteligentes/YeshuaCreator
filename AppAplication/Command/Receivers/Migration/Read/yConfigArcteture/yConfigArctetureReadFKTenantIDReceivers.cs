using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yConfigArctetureReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<yConfigArctetureTenantIDDTO>>
    {
        private readonly IyConfigArctetureReadRepository _repository;

        public yConfigArctetureReadFKTenantIDReceiver(IyConfigArctetureReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yConfigArctetureTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yConfigArctetureReadRepository = _repository.getyConfigArctetureReadFKTenantID(c);
                return Success("OK", yConfigArctetureReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration