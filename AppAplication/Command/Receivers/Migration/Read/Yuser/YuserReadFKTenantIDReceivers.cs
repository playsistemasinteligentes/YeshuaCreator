using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YuserReadFKTenantIDReceiver : ReciverBase<IEnumerable<YuserTenantIDDTO>>
    {
        private readonly IYuserReadRepository _repository;

        public YuserReadFKTenantIDReceiver(IYuserReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YuserTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YuserReadRepository = _repository.getYuserReadFKTenantID(c);
                return Success("OK", YuserReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration