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
using System.Linq;
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

            if (documentos.Count > 0)
            {
                InferirDadosDosDocumentos(entrada, documentos);
                entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
                AtualizarSimulacao(entrada, documentos, AcaoInformarNotas);
            }

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

            if (string.Equals(acao, AcaoInformarNotas, StringComparison.OrdinalIgnoreCase))
            {
                if (documentos.Count == 0)
                {
                    ManterAguardando(step, entrada, documentos, acao, new List<string> { "DocumentosOriginarios" });
                    return;
                }

                InferirDadosDosDocumentos(entrada, documentos);
                entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            }

            var planoJson = AtualizarSimulacao(entrada, documentos, acao);
            entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var pendencias = FiscalContingenciaPayload.Pendencias(entrada, documentos);

            if (!string.Equals(acao, AcaoConfirmarPlano, StringComparison.OrdinalIgnoreCase))
            {
                ManterAguardando(step, entrada, documentos, acao, pendencias, planoJson);
                return;
            }

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
            var pendencias = FiscalContingenciaPayload.Pendencias(entrada, documentos);
            var planoJson = FiscalContingenciaPayload.PlanoEmissaoJson(entrada, documentos);

            _entradaWriteRepository.UpdateQuantidadeDocumentos(entrada.id, documentos.Count);
            _entradaWriteRepository.UpdateValorCarga(entrada.id, documentos.Sum(x => x.valordocumento));
            _entradaWriteRepository.UpdatePesoBruto(entrada.id, documentos.Sum(x => x.pesobruto));
            _entradaWriteRepository.UpdateVolume(entrada.id, documentos.Sum(x => x.volume));
            _entradaWriteRepository.UpdatePendenciasJson(entrada.id, JsonSerializer.Serialize(pendencias));
            _entradaWriteRepository.UpdateSnapshotJson(entrada.id, planoJson);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 2);

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

        private void InferirDadosDosDocumentos(EntradaFiscalContingenciaDTO entrada, IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos)
        {
            if (documentos.Count == 0)
                return;

            var first = documentos.First();
            var complemento = FiscalContingenciaPayload.ComplementoJson(entrada);
            var id = entrada.id;

            AtualizarTextoSeNecessario(id, entrada.emitentefiscaldocumento, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "emitenteFiscalDocumento", "cnpjEmitente", "emitenteDocumento"),
                first.emitentedocumento), _entradaWriteRepository.UpdateEmitenteFiscalDocumento);
            AtualizarTextoSeNecessario(id, entrada.tomadordocumento, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "tomadorDocumento", "cnpjTomador"),
                first.destinatariodocumento), _entradaWriteRepository.UpdateTomadorDocumento);
            AtualizarTextoSeNecessario(id, entrada.transportadordocumento, FiscalContingenciaPayload.Text(complemento, "transportadorDocumento", "cnpjTransportador"), _entradaWriteRepository.UpdateTransportadorDocumento);
            AtualizarTextoSeNecessario(id, entrada.remetentedocumento, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "remetenteDocumento", "cnpjRemetente"),
                first.emitentedocumento), _entradaWriteRepository.UpdateRemetenteDocumento);
            AtualizarTextoSeNecessario(id, entrada.destinatariodocumento, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "destinatarioDocumento", "cnpjDestinatario"),
                first.destinatariodocumento), _entradaWriteRepository.UpdateDestinatarioDocumento);
            AtualizarTextoSeNecessario(id, entrada.ufinicio, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "ufInicio", "UFInicio"),
                first.uforigem), _entradaWriteRepository.UpdateUFInicio);
            AtualizarTextoSeNecessario(id, entrada.uffim, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "ufFim", "UFFim"),
                first.ufdestino), _entradaWriteRepository.UpdateUFFim);
            AtualizarTextoSeNecessario(id, entrada.municipioiniciocodigoibge, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"),
                first.municipioorigemcodigoibge), _entradaWriteRepository.UpdateMunicipioInicioCodigoIbge);
            AtualizarTextoSeNecessario(id, entrada.municipiofimcodigoibge, FiscalContingenciaState.FirstNonEmpty(
                FiscalContingenciaPayload.Text(complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"),
                first.municipiodestinocodigoibge), _entradaWriteRepository.UpdateMunicipioFimCodigoIbge);
        }

        private static void AtualizarTextoSeNecessario(int id, string atual, string novo, Action<int, string> update)
        {
            if (string.IsNullOrWhiteSpace(atual) && !string.IsNullOrWhiteSpace(novo))
                update(id, novo);
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
