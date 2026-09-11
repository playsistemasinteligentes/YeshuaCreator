// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System.Collections.Generic;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class AguardarDadosTransporteHandler
    {
        private readonly ICargaReadRepository _cargaReadRepository;
        private readonly IVeiculoReadRepository _veiculoReadRepository;
        private readonly ITransportadoraReadRepository _transportadoraReadRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public AguardarDadosTransporteHandler(
            ICargaReadRepository cargaReadRepository,
            IVeiculoReadRepository veiculoReadRepository,
            ITransportadoraReadRepository transportadoraReadRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cargaReadRepository = cargaReadRepository;
            _veiculoReadRepository = veiculoReadRepository;
            _transportadoraReadRepository = transportadoraReadRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var pendencias = new List<DadosTransportePendencia>();
            var carga = FindCarga(saga.EntityId);

            if (carga == null)
            {
                pendencias.Add(new DadosTransportePendencia("Carga", "Carga nao encontrada para confirmar dados de transporte."));
                SetWaitingPayload(saga, step, pendencias);
                return;
            }

            ValidateCarga(carga, pendencias);
            ValidateTransportador(carga, pendencias);
            ValidateVeiculoECondutor(carga, pendencias);

            // pendencia: rota fiscal sera detalhada no step PrepararCargaParaModuloFiscal.
            // Neste ciclo, ROT_ID nao bloqueia AguardarDadosTransporte.
            var rotaPendente = string.IsNullOrWhiteSpace(carga.rot_id);

            if (pendencias.Count > 0)
            {
                SetWaitingPayload(saga, step, pendencias);
                return;
            }

            _inboxWriteRepository.Insert(CargaStandardSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "aps.carga.dados-transporte-confirmados",
                new
                {
                    origem = "APSADM",
                    modo = "validacao-cadastral",
                    cargaId = saga.EntityId,
                    transportadoraId = carga.tra_id,
                    placa = carga.vei_placa,
                    rotaId = carga.rot_id,
                    rotaPendente,
                    observacoes = rotaPendente
                        ? new[] { "Rota fiscal sera definida no snapshot do modulo fiscal." }
                        : new string[0]
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: dados de transporte confirmados.");
        }

        private CargaDTO? FindCarga(string? entityId)
        {
            if (string.IsNullOrWhiteSpace(entityId))
                return null;

            if (int.TryParse(entityId, out var id))
            {
                var byId = _cargaReadRepository.FirstById(id);
                if (byId != null)
                    return byId;
            }

            return _cargaReadRepository.FirstByCAR_ID(entityId);
        }

        private static void ValidateCarga(CargaDTO carga, List<DadosTransportePendencia> pendencias)
        {
            if (string.IsNullOrWhiteSpace(carga.car_id))
                pendencias.Add(new DadosTransportePendencia("Carga", "Carga sem CAR_ID."));

            if (string.IsNullOrWhiteSpace(carga.tra_id))
                pendencias.Add(new DadosTransportePendencia("Transportador", "Carga sem TRA_ID."));

            if (string.IsNullOrWhiteSpace(carga.vei_placa))
                pendencias.Add(new DadosTransportePendencia("Veiculo", "Carga sem VEI_PLACA."));

            if (carga.tip_id <= 0)
                pendencias.Add(new DadosTransportePendencia("Veiculo", "Carga sem TIP_ID."));
        }

        private void ValidateTransportador(CargaDTO carga, List<DadosTransportePendencia> pendencias)
        {
            if (string.IsNullOrWhiteSpace(carga.tra_id))
                return;

            var transportadora = _transportadoraReadRepository.FirstByTRA_ID(carga.tra_id);
            if (transportadora == null)
            {
                pendencias.Add(new DadosTransportePendencia("Transportador", $"Transportadora '{carga.tra_id}' nao encontrada."));
                return;
            }

            if (string.IsNullOrWhiteSpace(transportadora.tra_nome))
                pendencias.Add(new DadosTransportePendencia("Transportador", "Transportadora sem razao social/nome."));

            if (string.IsNullOrWhiteSpace(transportadora.tra_cnpj))
                pendencias.Add(new DadosTransportePendencia("Transportador", "Transportadora sem CNPJ."));

            if (string.IsNullOrWhiteSpace(transportadora.tra_inscricao_estadual))
                pendencias.Add(new DadosTransportePendencia("Transportador", "Transportadora sem inscricao estadual."));

            if (string.IsNullOrWhiteSpace(transportadora.tra_rntrc))
                pendencias.Add(new DadosTransportePendencia("Transportador", "Transportadora sem RNTRC."));
        }

        private void ValidateVeiculoECondutor(CargaDTO carga, List<DadosTransportePendencia> pendencias)
        {
            if (string.IsNullOrWhiteSpace(carga.vei_placa))
                return;

            var veiculo = _veiculoReadRepository.FirstByVEI_PLACA(carga.vei_placa);
            if (veiculo == null)
            {
                pendencias.Add(new DadosTransportePendencia("Veiculo", $"Veiculo '{carga.vei_placa}' nao encontrado."));
                return;
            }

            if (string.IsNullOrWhiteSpace(veiculo.vei_uf))
                pendencias.Add(new DadosTransportePendencia("Veiculo", "Veiculo sem UF da placa."));

            if (veiculo.tip_id <= 0)
                pendencias.Add(new DadosTransportePendencia("Veiculo", "Veiculo sem tipo valido."));

            if (string.IsNullOrWhiteSpace(veiculo.vei_nome_motorista))
                pendencias.Add(new DadosTransportePendencia("Condutor", "Veiculo sem nome do motorista/condutor."));

            if (string.IsNullOrWhiteSpace(veiculo.vei_cpf_motorista))
                pendencias.Add(new DadosTransportePendencia("Condutor", "Veiculo sem CPF do motorista/condutor."));
        }

        private static void SetWaitingPayload(SagaBase saga, SagaStepBase step, List<DadosTransportePendencia> pendencias)
        {
            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "aps.carga.dados-transporte-aguardando",
                cargaId = saga.EntityId,
                sagaId = saga.Id,
                sagaType = saga.Type,
                sagaCorrelationId = saga.CorrelationId,
                stepId = step.Id,
                stepKey = step.Key,
                stepCorrelationId = step.CorrelationId,
                pendencias
            }));
        }

        private sealed class DadosTransportePendencia
        {
            public DadosTransportePendencia(string microdominio, string descricao)
            {
                Microdominio = microdominio;
                Descricao = descricao;
            }

            public string Microdominio { get; }
            public string Descricao { get; }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
