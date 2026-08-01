using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yFileUploadReadReceiver : ReciverBase<ICommand, DataPagination<yFileUploadDTO>>
    {
        private readonly IyFileUploadReadRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public yFileUploadReadReceiver(
            IyFileUploadReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<DataPagination<yFileUploadDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yFileUploadReadCommand c) 
             {    
                var yFileUploadReadRepository = _repository.getyFileUpload(c);
                return Success("OK", yFileUploadReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration