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
using System;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class InferirEntradaFiscalPelosXmlsHandler
    {
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository;
        private readonly ILogger _logger;

        public InferirEntradaFiscalPelosXmlsHandler(
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
            if (documentos.Count == 0)
                throw new InvalidOperationException($"Contingencia fiscal {entrada.cargaid}: nenhum documento originario encontrado para inferencia.");

            var first = documentos[0];
            var complemento = FiscalContingenciaPayload.Text(step.Payload, "dadosComplementaresJson", "DadosComplementaresJson");
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
            AtualizarTextoSeNecessario(id, entrada.rntrc, FiscalContingenciaPayload.Text(complemento, "rntrc", "RNTRC"), _entradaWriteRepository.UpdateRNTRC);
            AtualizarTextoSeNecessario(id, entrada.placaveiculo, FiscalContingenciaPayload.Text(complemento, "placaVeiculo", "placa"), _entradaWriteRepository.UpdatePlacaVeiculo);
            AtualizarTextoSeNecessario(id, entrada.ufveiculo, FiscalContingenciaPayload.Text(complemento, "ufVeiculo", "UFVeiculo"), _entradaWriteRepository.UpdateUFVeiculo);
            AtualizarTextoSeNecessario(id, entrada.condutordocumento, FiscalContingenciaPayload.Text(complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"), _entradaWriteRepository.UpdateCondutorDocumento);
            AtualizarTextoSeNecessario(id, entrada.condutornome, FiscalContingenciaPayload.Text(complemento, "condutorNome", "nomeMotorista", "nomeCondutor"), _entradaWriteRepository.UpdateCondutorNome);

            _entradaWriteRepository.UpdateQuantidadeDocumentos(id, documentos.Count);
            _entradaWriteRepository.UpdateValorCarga(id, documentos.Sum(x => x.valordocumento));
            _entradaWriteRepository.UpdatePesoBruto(id, documentos.Sum(x => x.pesobruto));
            _entradaWriteRepository.UpdateVolume(id, documentos.Sum(x => x.volume));
            entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            _entradaWriteRepository.UpdateSnapshotJson(id, FiscalContingenciaPayload.SummaryJson(entrada, documentos));
            _entradaWriteRepository.UpdateAtualizadoEmUtc(id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(id, 2);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.entrada-inferida",
                entradaFiscalContingenciaId = id,
                cargaId = entrada.cargaid,
                quantidadeDocumentos = documentos.Count,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: entrada fiscal inferida pelos XMLs.");
        }

        private static void AtualizarTextoSeNecessario(int id, string atual, string novo, Action<int, string> update)
        {
            if (string.IsNullOrWhiteSpace(atual) && !string.IsNullOrWhiteSpace(novo))
                update(id, novo);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
