// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Domain;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteBoletimReceiver : ReciverBase<ICommand, IBoletimEntity>
    {
        private readonly IBoletimWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteBoletimReceiver(
            IBoletimWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Dominio.Interfaces.IDomainTrackingPolicy domainTrackingPolicy,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _domainTrackingPolicy = domainTrackingPolicy;
            _executionContext = context;
        }

        protected override async Task<State<IBoletimEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.BoletimCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteBoletim", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteBoletimReceiver), commandName: "Command.Write.BoletimCrudCommand");
                 var boletim = new BoletimFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.BOL_ID, c.BOL_ID_ORIGEM, c.BOL_SOLVER, c.BOL_INTEGRACAO, c.BOL_SEQUENCIA, c.GRP_PAP_GRAMATURA_PROGRAMADO, c.GRP_ID_PROGRAMADO, c.GRP_PAPEL1_PROGRAMADO, c.GRP_PAPEL2_PROGRAMADO, c.GRP_PAPEL3_PROGRAMADO, c.GRP_PAPEL4_PROGRAMADO, c.GRP_PAPEL5_PROGRAMADO, c.BOL_STATUS_INTERFACE, c.BOL_TIPO, c.BOL_FORMATO, c.BOL_GRAMATURA_PAPEIS_PROGRAMADOS, c.BOL_GRAMATURA_PAPEIS_REALIZADO, c.BOL_CUSTO_PAPEIS_PROGRAMADOS, c.BOL_CUSTO_PAPEIS_REALIZADO, c.BOL_GRAMATURA_RESINA_PROGRAMADOS, c.BOL_CUSTO_RESINA_PROGRAMADOS, c.BOL_REFILE_OBRIGATORIO, c.BOL_OBS);
                 var domainResult = BoletimDomainBehavior.Apply(boletim, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(boletim);
                     return Success("OK", boletim);
                 }
                 catch (Exception e)
                 {
                    return Error(e, boletim);
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