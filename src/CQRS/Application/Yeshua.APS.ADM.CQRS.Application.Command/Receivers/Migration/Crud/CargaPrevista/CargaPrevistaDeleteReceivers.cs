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
    public class DeleteCargaPrevistaReceiver : ReciverBase<ICommand, ICargaPrevistaEntity>
    {
        private readonly ICargaPrevistaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteCargaPrevistaReceiver(
            ICargaPrevistaWriteRepository repository,
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

        protected override async Task<State<ICargaPrevistaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CargaPrevistaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteCargaPrevista", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteCargaPrevistaReceiver), commandName: "Command.Write.CargaPrevistaCrudCommand");
                 var cargaprevista = new CargaPrevistaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CAR_ID, c.ORD_ID, c.ITC_QTD_PLANEJADA, c.CAR_PREVISAO_MATERIA_PRIMA, c.CAR_DATA_INICIO_PREVISTO, c.CAR_DATA_INICIO_REALIZADO, c.CAR_DATA_FIM_PREVISTO, c.CAR_DATA_FIM_REALIZADO, c.CAR_INICIO_JANELA_EMBARQUE, c.CAR_FIM_JANELA_EMBARQUE, c.CAR_EMBARQUE_ALVO, c.CAR_STATUS, c.CAR_PESO_TEORICO, c.CAR_VOLUME_TEORICO, c.CAR_PESO_REAL, c.CAR_VOLUME_REAL, c.CAR_PESO_EMBALAGEM, c.CAR_PESO_ENTRADA, c.CAR_PESO_SAIDA, c.CAR_ID_DOCA, c.VEI_PLACA, c.TIP_ID, c.TRA_ID, c.CAR_GRUPO_PRODUTIVO, c.ROT_ID, c.CAR_OBSERVACAO_DE_TRANSPORTE, c.CAR_JUSTIFICATIVA_DE_CARREGAMENTO, c.OCO_ID, c.CAR_ID_JUNTADA, c.CAR_OBSERVACAO_OTIMIZADOR);
                 var domainResult = CargaPrevistaDomainBehavior.Apply(cargaprevista, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(cargaprevista);
                     return Success("OK", cargaprevista);
                 }
                 catch (Exception e)
                 {
                    return Error(e, cargaprevista);
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