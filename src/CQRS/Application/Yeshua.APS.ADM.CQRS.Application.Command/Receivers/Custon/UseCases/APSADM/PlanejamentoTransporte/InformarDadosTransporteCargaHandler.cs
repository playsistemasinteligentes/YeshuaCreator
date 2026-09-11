// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class InformarDadosTransporteCargaHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly ICargaReadRepository _repReadCarga;
        private readonly ICargaWriteRepository _repWriteCarga;
        private readonly ITransportadoraReadRepository _repReadTransportadora;
        private readonly ITransportadoraWriteRepository _repWriteTransportadora;
        private readonly IVeiculoReadRepository _repReadVeiculo;
        private readonly IVeiculoWriteRepository _repWriteVeiculo;
        public InformarDadosTransporteCargaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,Command.Interfaces.ISagaStepInvoker sagaStepInvoker,ICargaReadRepository repReadCarga, ICargaWriteRepository repWriteCarga,ITransportadoraReadRepository repReadTransportadora, ITransportadoraWriteRepository repWriteTransportadora,IVeiculoReadRepository repReadVeiculo, IVeiculoWriteRepository repWriteVeiculo)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
           _sagaStepInvoker = sagaStepInvoker;
            _repReadCarga = repReadCarga;
            _repWriteCarga = repWriteCarga;
            _repReadTransportadora = repReadTransportadora;
            _repWriteTransportadora = repWriteTransportadora;
            _repReadVeiculo = repReadVeiculo;
            _repWriteVeiculo = repWriteVeiculo;
        }
protected partial Task<State<InformarDadosTransporteCargaOutputCommand>> CustomActionHookAsync(State<InformarDadosTransporteCargaOutputCommand> state, InformarDadosTransporteCargaInputCommand comand, CancellationToken cancellationToken)
{
    var pendencias = new List<string>();

    if (string.IsNullOrWhiteSpace(comand.CargaId))
        pendencias.Add("CargaId deve ser informado.");

    if (string.IsNullOrWhiteSpace(comand.TransportadoraId))
        pendencias.Add("TransportadoraId deve ser informado.");

    if (string.IsNullOrWhiteSpace(comand.VeiculoPlaca))
        pendencias.Add("VeiculoPlaca deve ser informado.");

    if (comand.TipoVeiculoId <= 0)
        pendencias.Add("TipoVeiculoId deve ser informado.");

    if (pendencias.Count > 0)
    {
        return Task.FromResult(Success("Dados de transporte incompletos.", new InformarDadosTransporteCargaOutputCommand
        {
            Sucesso = false,
            Mensagem = string.Join(" ", pendencias),
            CargaId = comand.CargaId,
            ProximoStep = "aguardarDadosTransporte"
        }));
    }

    // pendencia: persistir dados informados na carga/cadastros e acordar a saga CargaStandard.
    return Task.FromResult(Success("Dados de transporte recebidos.", new InformarDadosTransporteCargaOutputCommand
    {
        Sucesso = true,
        Mensagem = "Dados de transporte recebidos para processamento.",
        CargaId = comand.CargaId,
        ProximoStep = "aguardarDadosTransporte"
    }));
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
