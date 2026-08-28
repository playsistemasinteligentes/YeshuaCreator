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
    public class InsertClpMedicoesHReceiver : ReciverBase<ICommand, IClpMedicoesHEntity>
    {
        private readonly IClpMedicoesHWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertClpMedicoesHReceiver(
            IClpMedicoesHWriteRepository repository,
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

        protected override async Task<State<IClpMedicoesHEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ClpMedicoesHCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertClpMedicoesH", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertClpMedicoesHReceiver), commandName: "Command.Write.ClpMedicoesHCrudCommand");
                 var clpmedicoesh = new ClpMedicoesHFactory(_logger, _domainTrackingPolicy).Create(context, c.ID, c.MAQUINA_ID, c.DATA_INI, c.DATA_FIM, c.CLP_EMISSAO, c.QTD, c.GRUPO, c.STATUS, c.URN_ID, c.URM_ID, c.ID_LOTE_CLP, c.OCO_ID, c.FASE, c.CLP_ORIGEM, c.CLP_LOTE, c.COMPACTA, c.BOL_ID, c.COR_SEQUENCIA);
                 var domainResult = ClpMedicoesHDomainBehavior.Apply(clpmedicoesh, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(clpmedicoesh);
                     return Success("OK", clpmedicoesh);
                 }
                 catch (Exception e)
                 {
                    return Error(e, clpmedicoesh);
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