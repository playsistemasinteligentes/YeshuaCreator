// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// taxonomy: IntencaoWait
// </yeshua>

using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class PrepararEntradaContingenciaHandler
    {
        private const string AcaoInformarNotas = "InformarNotasFiscaisContingencia";
        private const string AcaoEscolherAgrupamento = "EscolherModeloAgrupamentoCTeContingencia";
        private const string AcaoInformarFrete = "InformarFreteERateioContingencia";
        private const string AcaoInformarTransporte = "InformarDadosTransporteContingencia";
        private const string AcaoConfirmarPlano = "ConfirmarPlanoEmissaoFiscalContingencia";

        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ILogger _logger = default!;

        public PrepararEntradaContingenciaHandler(
            IEntradaFiscalContingenciaReadRepository entradaReadRepository,
            IEntradaFiscalContingenciaWriteRepository entradaWriteRepository,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            ILogger logger)
        {
            _entradaReadRepository = entradaReadRepository;
            _entradaWriteRepository = entradaWriteRepository;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var documentos = FiscalContingenciaState.LoadDocumentos(_nfeProdutoSnapshotReadRepository, entrada.cargaid);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.preparacao-aguardando",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                currentAction = AcaoInformarNotas,
                quantidadeDocumentos = documentos.Count,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            var acao = FiscalContingenciaPayload.Text(payload, "userAction", "UserAction");
            if (string.IsNullOrWhiteSpace(acao))
                acao = AcaoInformarNotas;

            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            FiscalContingenciaState.ApplyComplemento(_entradaWriteRepository, entrada, payload, acao);

            entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var documentos = FiscalContingenciaState.LoadDocumentos(_nfeProdutoSnapshotReadRepository, entrada.cargaid);

            if (!string.Equals(acao, AcaoConfirmarPlano, StringComparison.OrdinalIgnoreCase))
            {
                ManterAguardando(
                    step,
                    entrada,
                    documentos,
                    acao,
                    new List<string> { "PreviewDesatualizado" });
                return;
            }

            var planoJson = AtualizarSimulacao(entrada, documentos, acao);
            entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var compilacao = FiscalEmissionPlanCompiler.Compile(entrada, documentos);
            var pendencias = compilacao.Pendencias;
            planoJson = compilacao.PlanJson;

            if (pendencias.Count > 0)
            {
                ManterAguardando(step, entrada, documentos, acao, pendencias, planoJson);
                return;
            }

            _entradaWriteRepository.UpdatePendenciasJson(entrada.id, "[]");
            _entradaWriteRepository.UpdateSnapshotJson(entrada.id, planoJson);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 4);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.preparacao-confirmada",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                quantidadeDocumentos = documentos.Count,
                planoEmissaoJson = planoJson,
                occurredAtUtc = DateTime.UtcNow
            }));

            _logger.Info($"Contingencia fiscal {entrada.cargaid}: preparacao confirmada.");
        }

        private string AtualizarSimulacao(
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            string acao)
        {
            var planoJson = FiscalContingenciaState.RefreshPlan(
                _entradaWriteRepository,
                entrada,
                documentos);

            _logger.Info($"Contingencia fiscal {entrada.cargaid}: preparacao atualizada por {acao}.");
            return planoJson;
        }

        private void ManterAguardando(
            SagaStepBase step,
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            string acao,
            IReadOnlyCollection<string> pendencias,
            string planoJson = "")
        {
            _entradaWriteRepository.UpdatePendenciasJson(entrada.id, JsonSerializer.Serialize(pendencias));
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 2);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.preparacao-atualizada",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                userAction = acao,
                quantidadeDocumentos = documentos.Count,
                pendencias,
                planoEmissaoJson = planoJson,
                currentAction = ProximaAcao(acao, pendencias),
                occurredAtUtc = DateTime.UtcNow
            }));
            step.SetWaiting();
        }

        private static string ProximaAcao(string acao, IReadOnlyCollection<string> pendencias)
        {
            if (pendencias.Contains("DocumentosOriginarios"))
                return AcaoInformarNotas;
            if (pendencias.Contains("TipoAgrupamentoCTe"))
                return AcaoEscolherAgrupamento;
            if (pendencias.Contains("EstrategiaRateioFrete") || pendencias.Contains("ValorFrete"))
                return AcaoInformarFrete;
            if (pendencias.Any(x =>
                    x == "RNTRC" ||
                    x == "PlacaVeiculo" ||
                    x == "UFVeiculo" ||
                    x == "CondutorDocumento" ||
                    x == "CondutorNome" ||
                    x == "UFInicio" ||
                    x == "UFFim" ||
                    x == "MunicipioInicioCodigoIbge" ||
                    x == "MunicipioFimCodigoIbge"))
                return AcaoInformarTransporte;

            return string.Equals(acao, AcaoConfirmarPlano, StringComparison.OrdinalIgnoreCase)
                ? AcaoConfirmarPlano
                : AcaoConfirmarPlano;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
