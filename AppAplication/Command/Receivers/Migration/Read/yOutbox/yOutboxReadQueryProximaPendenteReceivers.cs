using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yOutboxReadQueryProximaPendenteReceiver : ReciverBase<ICommand, DataPagination<yOutboxStandardDTO>>
    {
        private readonly IyOutboxReadRepository _repository;
        private readonly ILogger _logger;

        public yOutboxReadQueryProximaPendenteReceiver(
            IyOutboxReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yOutboxStandardDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yOutboxProximaPendenteCommand c) 
             {    
                var yOutboxReadRepository = _repository.GetyOutboxProximaPendente(c);
                return Success("OK", yOutboxReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration