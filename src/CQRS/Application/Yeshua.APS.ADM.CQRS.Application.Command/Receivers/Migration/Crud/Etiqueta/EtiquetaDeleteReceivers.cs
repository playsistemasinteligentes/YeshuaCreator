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
    public class DeleteEtiquetaReceiver : ReciverBase<ICommand, IEtiquetaEntity>
    {
        private readonly IEtiquetaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteEtiquetaReceiver(
            IEtiquetaWriteRepository repository,
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

        protected override async Task<State<IEtiquetaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.EtiquetaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteEtiqueta", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteEtiquetaReceiver), commandName: "Command.Write.EtiquetaCrudCommand");
                 var etiqueta = new EtiquetaFactory(_logger, _domainTrackingPolicy).Create(context, c.ETI_ID, c.ETI_EMISSAO, c.ETI_CODIGO_BARRAS, c.ETI_SEQUENCIA, c.ETI_NUMERO_COPIAS, c.ETI_STATUS, c.ETI_DATA_FABRICACAO, c.ETI_COD_BARRAS_ORIGINAL, c.ETI_OP_ORIGINAL, c.MAQ_ID, c.IMP_ID, c.USE_ID, c.ORD_ID, c.ROT_PRO_ID, c.ROT_SEQ_TRANFORMACAO, c.FPR_SEQ_REPETICAO, c.ETI_QUANTIDADE_PALETE, c.ETI_LOTE, c.ETI_SUB_LOTE, c.ETI_IMPRIMIR_DE, c.ETI_IMPRIMIR_ATE, c.BOL_ID, c.COR_SEQUENCIA);
                 var domainResult = EtiquetaDomainBehavior.Apply(etiqueta, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(etiqueta);
                     return Success("OK", etiqueta);
                 }
                 catch (Exception e)
                 {
                    return Error(e, etiqueta);
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