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
    public class UpdateRotaPontosMapaReceiver : ReciverBase<ICommand, IRotaPontosMapaEntity>
    {
        private readonly IRotaPontosMapaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateRotaPontosMapaReceiver(
            IRotaPontosMapaWriteRepository repository,
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

        protected override async Task<State<IRotaPontosMapaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.RotaPontosMapaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateRotaPontosMapa", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateRotaPontosMapaReceiver), commandName: "Command.Write.RotaPontosMapaCrudCommand");
                 var rotapontosmapa = new RotaPontosMapaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ROT_ID, c.PON_ID_DESTINO, c.PON_ID_ORIGEM, c.ROT_CUSTO_TOTAL, c.PON_ID_ROTEIRO, c.ROT_ORDEM_ROTEIRO, c.ROT_TIPO, c.ROT_DISTANCIA);
                 var domainResult = RotaPontosMapaDomainBehavior.Apply(rotapontosmapa, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(rotapontosmapa);
                     return Success("OK", rotapontosmapa);
                 }
                 catch (Exception e)
                 {
                    return Error(e, rotapontosmapa);
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