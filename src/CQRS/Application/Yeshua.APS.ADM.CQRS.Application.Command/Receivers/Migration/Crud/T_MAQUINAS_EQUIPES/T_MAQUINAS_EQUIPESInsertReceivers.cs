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
    public class InsertT_MAQUINAS_EQUIPESReceiver : ReciverBase<ICommand, IT_MAQUINAS_EQUIPESEntity>
    {
        private readonly IT_MAQUINAS_EQUIPESWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertT_MAQUINAS_EQUIPESReceiver(
            IT_MAQUINAS_EQUIPESWriteRepository repository,
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

        protected override async Task<State<IT_MAQUINAS_EQUIPESEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_MAQUINAS_EQUIPESCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertT_MAQUINAS_EQUIPES", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertT_MAQUINAS_EQUIPESReceiver), commandName: "Command.Write.T_MAQUINAS_EQUIPESCrudCommand");
                 var t_maquinas_equipes = new T_MAQUINAS_EQUIPESFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MAQ_ID, c.EQU_ID, c.CAL_ID, c.CLI_ID);
                 var domainResult = T_MAQUINAS_EQUIPESDomainBehavior.Apply(t_maquinas_equipes, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(t_maquinas_equipes);
                     return Success("OK", t_maquinas_equipes);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_maquinas_equipes);
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