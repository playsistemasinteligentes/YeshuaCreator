using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YtenantReadFKUserIDAdminReceiver : ReciverBase<IEnumerable<YtenantUserIDAdminDTO>>
    {
        private readonly IYtenantReadRepository _repository;

        public YtenantReadFKUserIDAdminReceiver(IYtenantReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YtenantUserIDAdminDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YtenantReadRepository = _repository.getYtenantReadFKUserIDAdmin(c);
                return Success("OK", YtenantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration