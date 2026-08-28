using System.Threading;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteyPerfilGrantReceiver : ReciverBase<ICommand, IyPerfilGrantEntity>
    {
        private readonly IyPerfilGrantWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteyPerfilGrantReceiver(
            IyPerfilGrantWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IyPerfilGrantEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.yPerfilGrantCrudCommand c) 
             {    
                 var yperfilgrant = new yPerfilGrantFactory(_logger).Create(c.Id, c.PerfilId, c.GrantId, c.CanGrant, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete, c.ValidUntil);
                 if (!yperfilgrant.isValidDelete())
                     return ValidationError(yperfilgrant.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(yperfilgrant);
                     return Success("OK", yperfilgrant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yperfilgrant);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration