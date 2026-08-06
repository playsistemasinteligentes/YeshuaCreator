using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class MDFeEncerramentoReadQueryGeralReceiver : ReciverBase<ICommand, DataPagination<MDFeEncerramentoAutorizadosParaEncerramentoDTO>>
    {
        private readonly IMDFeEncerramentoReadRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public MDFeEncerramentoReadQueryGeralReceiver(
            IMDFeEncerramentoReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<DataPagination<MDFeEncerramentoAutorizadosParaEncerramentoDTO>> Action(ICommand comand)
        {
                 return Error("ErroConversao", default);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration