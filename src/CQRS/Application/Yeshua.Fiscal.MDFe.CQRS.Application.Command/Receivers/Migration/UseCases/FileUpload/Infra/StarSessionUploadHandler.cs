using System.Threading;
// Escopo: 
using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using Command.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class StarSessionUploadHandler : ReciverBase< StarSessionUploadInputCommand, StarSessionUploadOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public StarSessionUploadHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<StarSessionUploadOutputCommand>> ActionAsync(StarSessionUploadInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<StarSessionUploadOutputCommand> retorno = Success("OK", null);
                 return await CustomActionHookAsync(retorno, comand, cancellationToken);
            }
            catch (ReceiverException<StarSessionUploadOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
protected partial Task<State<StarSessionUploadOutputCommand>> CustomActionHookAsync(State<StarSessionUploadOutputCommand> state, StarSessionUploadInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers