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
    public class InsertTipoTesteReceiver : ReciverBase<ICommand, ITipoTesteEntity>
    {
        private readonly ITipoTesteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertTipoTesteReceiver(
            ITipoTesteWriteRepository repository,
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

        protected override async Task<State<ITipoTesteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TipoTesteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertTipoTeste", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertTipoTesteReceiver), commandName: "Command.Write.TipoTesteCrudCommand");
                 var tipoteste = new TipoTesteFactory(_logger, _domainTrackingPolicy).Create(context, c.TT_ESPECIFICACAO, c.TT_ORIGEM_ESPECIFICACAO, c.TT_IMPRIME_NO_LAUDO, c.TT_ID, c.TT_NOME, c.TT_DESC, c.TT_TOL_MAIS, c.TT_TOL_MENOS, c.TT_NORMA, c.TT_INICIO_PROCESSO, c.TA_ID, c.UNI_ID, c.TT_N_AMOSTRAS_P_TESTE, c.TT_MAX_DEF_CRITICO, c.TT_MAX_DEF_GRAVE);
                 var domainResult = TipoTesteDomainBehavior.Apply(tipoteste, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(tipoteste);
                     return Success("OK", tipoteste);
                 }
                 catch (Exception e)
                 {
                    return Error(e, tipoteste);
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