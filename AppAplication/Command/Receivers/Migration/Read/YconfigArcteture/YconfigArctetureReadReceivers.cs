using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yConfigArctetureReadReceiver : ReciverBase<ICommand, DataPagination<yConfigArctetureDTO>>
    {
        private readonly IyConfigArctetureReadRepository _repository;
        private readonly ILogger _logger;

        public yConfigArctetureReadReceiver(IyConfigArctetureReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yConfigArctetureDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yConfigArctetureReadCommand c) 
             {    
                var yConfigArctetureReadRepository = _repository.getyConfigArcteture(c);
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