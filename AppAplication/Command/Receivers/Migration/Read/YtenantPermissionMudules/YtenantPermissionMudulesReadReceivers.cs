using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YtenantPermissionMudulesReadReceiver : ReciverBase<DataPagination<YtenantPermissionMudulesDTO>>
    {
        private readonly IYtenantPermissionMudulesReadRepository _repository;
        private readonly ILogger _logger;

        public YtenantPermissionMudulesReadReceiver(IYtenantPermissionMudulesReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YtenantPermissionMudulesDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YtenantPermissionMudulesReadCommand c) 
             {    
                var YtenantPermissionMudulesReadRepository = _repository.getYtenantPermissionMudules(c);
                return Success("OK", YtenantPermissionMudulesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration