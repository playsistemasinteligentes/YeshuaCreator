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
    public class InsertCargaReceiver : ReciverBase<ICommand, ICargaEntity>
    {
        private readonly ICargaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertCargaReceiver(
            ICargaWriteRepository repository,
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

        protected override async Task<State<ICargaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CargaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertCarga", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertCargaReceiver), commandName: "Command.Write.CargaCrudCommand");
                 var carga = new CargaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CAR_ID, c.CAR_PREVISAO_MATERIA_PRIMA, c.CAR_DATA_INICIO_PREVISTO, c.CAR_DATA_INICIO_REALIZADO, c.CAR_DATA_FIM_PREVISTO, c.CAR_DATA_FIM_REALIZADO, c.CAR_INICIO_JANELA_EMBARQUE, c.CAR_FIM_JANELA_EMBARQUE, c.CAR_EMBARQUE_ALVO, c.CAR_STATUS, c.CAR_PESO_TEORICO, c.CAR_VOLUME_TEORICO, c.CAR_PESO_REAL, c.CAR_VOLUME_REAL, c.CAR_PESO_EMBALAGEM, c.CAR_PESO_ENTRADA, c.CAR_PESO_SAIDA, c.CAR_ID_DOCA, c.VEI_PLACA, c.TIP_ID, c.TRA_ID, c.CAR_GRUPO_PRODUTIVO, c.ROT_ID, c.CAR_OBSERVACAO_DE_TRANSPORTE, c.CAR_JUSTIFICATIVA_DE_CARREGAMENTO, c.OCO_ID, c.CAR_ID_JUNTADA, c.CAR_OBSERVACAO_OTIMIZADOR, c.CAR_ID_INTEGRACAO_BALANCA, c.CAR_PESAGEM_LIBERADA, c.CAR_OBS_LIERACAO, c.OCO_ID_LIERACAO, c.CAR_DATA_ENTRADA_VEICULO, c.CAR_DATA_SAIDA_VEICULO, c.CAR_DATA_ROMANEIO_CONSOLIDADO, c.CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, c.CAR_DIFERENCA_PESAGEM, c.CAR_DATA_AGENCIAMENTO, c.TURN_ID, c.TURM_ID);
                 var domainResult = CargaDomainBehavior.Apply(carga, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(carga);
                     return Success("OK", carga);
                 }
                 catch (Exception e)
                 {
                    return Error(e, carga);
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