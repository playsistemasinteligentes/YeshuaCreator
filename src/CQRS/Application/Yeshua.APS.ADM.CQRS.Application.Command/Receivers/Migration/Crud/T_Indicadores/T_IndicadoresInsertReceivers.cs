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
    public class InsertT_IndicadoresReceiver : ReciverBase<ICommand, IT_IndicadoresEntity>
    {
        private readonly IT_IndicadoresWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertT_IndicadoresReceiver(
            IT_IndicadoresWriteRepository repository,
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

        protected override async Task<State<IT_IndicadoresEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_IndicadoresCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertT_Indicadores", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertT_IndicadoresReceiver), commandName: "Command.Write.T_IndicadoresCrudCommand");
                 var t_indicadores = new T_IndicadoresFactory(_logger, _domainTrackingPolicy).Create(context, c.IND_ID, c.IND_DESCRICAO, c.NEG_ID, c.DESC_CALCULO, c.IND_TIPOCOMPARADOR, c.IND_GRAFICO, c.IND_CONEXAO, c.IND_DTCRIACAO, c.RESPOSAVELIND, c.RESPOSAVELCARGA, c.PROCEXTRACAO, c.PER_ID, c.DIM_ID, c.DOM_EMPRESA, c.DOM_FILIAL);
                 var domainResult = T_IndicadoresDomainBehavior.Apply(t_indicadores, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(t_indicadores);
                     return Success("OK", t_indicadores);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_indicadores);
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