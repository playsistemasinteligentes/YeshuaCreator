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
    public class InsertRestricoesDeRodagemReceiver : ReciverBase<ICommand, IRestricoesDeRodagemEntity>
    {
        private readonly IRestricoesDeRodagemWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertRestricoesDeRodagemReceiver(
            IRestricoesDeRodagemWriteRepository repository,
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

        protected override async Task<State<IRestricoesDeRodagemEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.RestricoesDeRodagemCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertRestricoesDeRodagem", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertRestricoesDeRodagemReceiver), commandName: "Command.Write.RestricoesDeRodagemCrudCommand");
                 var restricoesderodagem = new RestricoesDeRodagemFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.RES_ID, c.RES_TIPO, c.RES_HORA_INI, c.RES_HORA_FIM, c.RES_VELOCIDADE_HORA_RUSH, c.TVE_ID, c.MAP_ID);
                 var domainResult = RestricoesDeRodagemDomainBehavior.Apply(restricoesderodagem, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(restricoesderodagem);
                     return Success("OK", restricoesderodagem);
                 }
                 catch (Exception e)
                 {
                    return Error(e, restricoesderodagem);
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