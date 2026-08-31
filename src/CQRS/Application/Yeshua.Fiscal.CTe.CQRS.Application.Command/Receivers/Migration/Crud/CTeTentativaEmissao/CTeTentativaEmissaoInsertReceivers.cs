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
    public class InsertCTeTentativaEmissaoReceiver : ReciverBase<ICommand, ICTeTentativaEmissaoEntity>
    {
        private readonly ICTeTentativaEmissaoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertCTeTentativaEmissaoReceiver(
            ICTeTentativaEmissaoWriteRepository repository,
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

        protected override async Task<State<ICTeTentativaEmissaoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CTeTentativaEmissaoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertCTeTentativaEmissao", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertCTeTentativaEmissaoReceiver), commandName: "Command.Write.CTeTentativaEmissaoCrudCommand");
                 var ctetentativaemissao = new CTeTentativaEmissaoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CTeSolicitacaoFiscalId, c.ChaveAcesso, c.Numero, c.Serie, c.Tentativa, c.XmlAssinadoStorageKey, c.XmlProcStorageKey, c.XmlHash, c.CodigoRetorno, c.MensagemRetorno, c.ProtocoloAutorizacao, c.EnviadoEmUtc, c.AutorizadoEmUtc, c.Status);
                 var domainResult = CTeTentativaEmissaoDomainBehavior.Apply(ctetentativaemissao, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(ctetentativaemissao);
                     return Success("OK", ctetentativaemissao);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ctetentativaemissao);
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