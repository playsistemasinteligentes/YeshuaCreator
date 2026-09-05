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
    public class UpdateCertificadoDigitalReceiver : ReciverBase<ICommand, ICertificadoDigitalEntity>
    {
        private readonly ICertificadoDigitalWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateCertificadoDigitalReceiver(
            ICertificadoDigitalWriteRepository repository,
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

        protected override async Task<State<ICertificadoDigitalEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CertificadoDigitalCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateCertificadoDigital", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateCertificadoDigitalReceiver), commandName: "Command.Write.CertificadoDigitalCrudCommand");
                 var certificadodigital = new CertificadoDigitalFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Apelido, c.DocumentoTitular, c.StorageKey, c.Thumbprint, c.ValidoDe, c.ValidoAte, c.Ativo);
                 var domainResult = CertificadoDigitalDomainBehavior.Apply(certificadodigital, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(certificadodigital);
                     return Success("OK", certificadodigital);
                 }
                 catch (Exception e)
                 {
                    return Error(e, certificadodigital);
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