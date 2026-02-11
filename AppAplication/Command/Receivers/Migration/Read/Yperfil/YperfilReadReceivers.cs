using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yPerfilReadReceiver : ReciverBase<ICommand, DataPagination<yPerfilDTO>>
    {
        private readonly IyPerfilReadRepository _repository;
        private readonly ILogger _logger;

        public yPerfilReadReceiver(IyPerfilReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yPerfilDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yPerfilReadCommand c) 
             {    
                var yPerfilReadRepository = _repository.getyPerfil(c);
                return Success("OK", yPerfilReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration