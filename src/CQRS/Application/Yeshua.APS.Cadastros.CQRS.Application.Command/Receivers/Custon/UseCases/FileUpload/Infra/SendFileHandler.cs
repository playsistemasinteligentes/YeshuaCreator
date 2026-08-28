using System.Threading.Tasks;
using System.Threading;
// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Aplication.Interfaces.Services;

namespace Command.Receivers.UseCase
{
    public partial class SendFileHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        public SendFileHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IyFileUploadReadRepository repReadyFileUpload, IyFileUploadWriteRepository repWriteyFileUpload)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
        }
protected partial async Task<State<SendFileOutputCommand>> CustomActionHookAsync(State<SendFileOutputCommand> state, SendFileInputCommand comand, CancellationToken cancellationToken)
{
            return state;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
