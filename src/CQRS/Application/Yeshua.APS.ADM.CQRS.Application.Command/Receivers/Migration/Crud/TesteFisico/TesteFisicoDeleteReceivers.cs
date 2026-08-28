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
    public class DeleteTesteFisicoReceiver : ReciverBase<ICommand, ITesteFisicoEntity>
    {
        private readonly ITesteFisicoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteTesteFisicoReceiver(
            ITesteFisicoWriteRepository repository,
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

        protected override async Task<State<ITesteFisicoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TesteFisicoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteTesteFisico", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteTesteFisicoReceiver), commandName: "Command.Write.TesteFisicoCrudCommand");
                 var testefisico = new TesteFisicoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.TES_ID, c.ITE_ID, c.USR_ID, c.TES_NOME_TECNICO, c.TES_AMOSTRA, c.TES_OP, c.TES_VALOR_NUMERICO, c.TES_VALOR_DATA, c.TES_VALOR_TEXTO, c.TES_EMISSAO, c.ORD_ID, c.PRO_ID, c.MAQ_ID, c.FPR_SEQ_REPETICAO, c.FPR_SEQ_TRANFORMACAO);
                 var domainResult = TesteFisicoDomainBehavior.Apply(testefisico, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(testefisico);
                     return Success("OK", testefisico);
                 }
                 catch (Exception e)
                 {
                    return Error(e, testefisico);
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