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
    public class InsertMDFeReceiver : ReciverBase<ICommand, IMDFeEntity>
    {
        private readonly IMDFeWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertMDFeReceiver(
            IMDFeWriteRepository repository,
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

        protected override async Task<State<IMDFeEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MDFeCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertMDFe", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertMDFeReceiver), commandName: "Command.Write.MDFeCrudCommand");
                 var mdfe = new MDFeFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ChaveAcesso, c.Serie, c.Numero, c.UfCarregamento, c.UfDescarregamento, c.PlacaVeiculo, c.EmitidoEm, c.AutorizadoEm, c.IniciadoEm, c.EncerradoEm, c.CanceladoEm, c.Situacao);
                 var domainResult = MDFeDomainBehavior.Apply(mdfe, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(mdfe);
                     return Success("OK", mdfe);
                 }
                 catch (Exception e)
                 {
                    return Error(e, mdfe);
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