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
    public class DeleteMDFeTentativaEmissaoReceiver : ReciverBase<ICommand, IMDFeTentativaEmissaoEntity>
    {
        private readonly IMDFeTentativaEmissaoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteMDFeTentativaEmissaoReceiver(
            IMDFeTentativaEmissaoWriteRepository repository,
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

        protected override Task<State<IMDFeTentativaEmissaoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MDFeTentativaEmissaoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteMDFeTentativaEmissao", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteMDFeTentativaEmissaoReceiver), commandName: "Command.Write.MDFeTentativaEmissaoCrudCommand");
                 var mdfetentativaemissao = new MDFeTentativaEmissaoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MDFeSolicitacaoFiscalId, c.ChaveAcesso, c.Numero, c.Serie, c.Tentativa, c.XmlAssinadoStorageKey, c.XmlProcStorageKey, c.XmlHash, c.CodigoRetorno, c.MensagemRetorno, c.ProtocoloAutorizacao, c.EnviadoEmUtc, c.AutorizadoEmUtc, c.Status);
                 var domainResult = MDFeTentativaEmissaoDomainBehavior.Apply(mdfetentativaemissao, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(mdfetentativaemissao);
                     return Task.FromResult(Success("OK", mdfetentativaemissao));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, mdfetentativaemissao));
                 }
            }
            else 
            {
                 return Task.FromResult(Error("ErroConversao"));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration