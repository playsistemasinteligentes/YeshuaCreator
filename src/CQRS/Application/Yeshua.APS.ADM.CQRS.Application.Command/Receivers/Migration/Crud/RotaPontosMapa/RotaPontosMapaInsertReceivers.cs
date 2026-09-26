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
    public class InsertRotaPontosMapaReceiver : ReciverBase<ICommand, IRotaPontosMapaEntity>
    {
        private readonly IRotaPontosMapaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertRotaPontosMapaReceiver(
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

        protected override Task<State<IRotaPontosMapaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.RotaPontosMapaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertRotaPontosMapa", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertRotaPontosMapaReceiver), commandName: "Command.Write.RotaPontosMapaCrudCommand");
                 var rotapontosmapa = new RotaPontosMapaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ROT_ID, c.PON_ID_DESTINO, c.PON_ID_ORIGEM, c.ROT_CUSTO_TOTAL, c.PON_ID_ROTEIRO, c.ROT_ORDEM_ROTEIRO, c.ROT_TIPO, c.ROT_DISTANCIA);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", rotapontosmapa.OperationalEntityId);
                 var domainResult = RotaPontosMapaDomainBehavior.Apply(rotapontosmapa, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(rotapontosmapa);
                     return Task.FromResult(Success("OK", rotapontosmapa));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, rotapontosmapa));
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