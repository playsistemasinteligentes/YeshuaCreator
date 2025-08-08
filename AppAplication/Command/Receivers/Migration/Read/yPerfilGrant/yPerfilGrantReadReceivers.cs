using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yPerfilGrantReadReceiver : ReciverBase<DataPagination<yPerfilGrantDTO>>
    {
        private readonly IyPerfilGrantReadRepository _repository;
        private readonly ILogger _logger;

        public yPerfilGrantReadReceiver(IyPerfilGrantReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yPerfilGrantDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yPerfilGrantReadCommand c) 
             {    
                var yPerfilGrantReadRepository = _repository.getyPerfilGrant(c);
                return Success("OK", yPerfilGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration