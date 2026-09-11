using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Command.Receivers
{
    internal static class FiscalContingenciaState
    {
        public static EntradaFiscalContingenciaDTO LoadEntrada(
            IEntradaFiscalContingenciaReadRepository repository,
            SagaBase saga,
            SagaStepBase step)
        {
            var entradaId = FiscalContingenciaPayload.EntradaId(step.Payload);
            if (entradaId > 0)
            {
                var byId = repository.FirstById(entradaId);
                if (byId != null && byId.id > 0)
                    return byId;
            }

            var cargaId = saga.EntityId ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(cargaId))
            {
                var byCarga = repository.FirstByCargaId(cargaId);
                if (byCarga != null && byCarga.id > 0)
                    return byCarga;
            }

            throw new InvalidOperationException($"Contingencia fiscal {cargaId}: entrada nao encontrada.");
        }

        public static List<NFeProdutoSnapshotDTO> LoadDocumentos(
            INFeProdutoSnapshotReadRepository repository,
            string cargaId)
        {
            if (string.IsNullOrWhiteSpace(cargaId))
                return new List<NFeProdutoSnapshotDTO>();

            return (repository.GetAllByCargaId(cargaId) ?? Array.Empty<NFeProdutoSnapshotDTO>())
                .Where(x => x != null && !x.deleted && x.status != 9)
                .ToList();
        }

        public static string FirstNonEmpty(params string?[] values)
        {
            foreach (var value in values)
            {
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
            }

            return string.Empty;
        }

        public static void ApplyComplemento(
            IEntradaFiscalContingenciaWriteRepository repository,
            EntradaFiscalContingenciaDTO entrada,
            string payload,
            string origem)
        {
            var complemento = FiscalContingenciaPayload.Text(payload, "dadosComplementaresJson", "DadosComplementaresJson");
            if (string.IsNullOrWhiteSpace(complemento) && IsJsonObject(payload))
                complemento = payload;

            if (string.IsNullOrWhiteSpace(complemento))
                return;

            complemento = MergeComplemento(FiscalContingenciaPayload.ComplementoJson(entrada), complemento);

            var id = entrada.id;
            void UpdateString(Action<int, string> update, string value)
            {
                if (!string.IsNullOrWhiteSpace(value))
                    update(id, value);
            }

            UpdateString(repository.UpdateEmitenteFiscalDocumento, FiscalContingenciaPayload.Text(complemento, "emitenteFiscalDocumento", "cnpjEmitente", "emitenteDocumento"));
            UpdateString(repository.UpdateTomadorDocumento, FiscalContingenciaPayload.Text(complemento, "tomadorDocumento", "cnpjTomador"));
            UpdateString(repository.UpdateTransportadorDocumento, FiscalContingenciaPayload.Text(complemento, "transportadorDocumento", "cnpjTransportador"));
            UpdateString(repository.UpdateRemetenteDocumento, FiscalContingenciaPayload.Text(complemento, "remetenteDocumento", "cnpjRemetente"));
            UpdateString(repository.UpdateDestinatarioDocumento, FiscalContingenciaPayload.Text(complemento, "destinatarioDocumento", "cnpjDestinatario"));
            UpdateString(repository.UpdateUFInicio, FiscalContingenciaPayload.Text(complemento, "ufInicio", "UFInicio"));
            UpdateString(repository.UpdateUFFim, FiscalContingenciaPayload.Text(complemento, "ufFim", "UFFim"));
            UpdateString(repository.UpdateMunicipioInicioCodigoIbge, FiscalContingenciaPayload.Text(complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"));
            UpdateString(repository.UpdateMunicipioFimCodigoIbge, FiscalContingenciaPayload.Text(complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"));
            UpdateString(repository.UpdateRNTRC, FiscalContingenciaPayload.Text(complemento, "rntrc", "RNTRC"));
            UpdateString(repository.UpdatePlacaVeiculo, FiscalContingenciaPayload.Text(complemento, "placaVeiculo", "placa"));
            UpdateString(repository.UpdateUFVeiculo, FiscalContingenciaPayload.Text(complemento, "ufVeiculo", "UFVeiculo"));
            UpdateString(repository.UpdateCondutorDocumento, FiscalContingenciaPayload.Text(complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"));
            UpdateString(repository.UpdateCondutorNome, FiscalContingenciaPayload.Text(complemento, "condutorNome", "nomeMotorista", "nomeCondutor"));

            repository.UpdateSnapshotJson(id, JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.dados-complementares-atualizados",
                entrada.id,
                entrada.correlationid,
                entrada.cargaid,
                origem,
                dadosComplementaresJson = complemento,
                preferenciasFiscaisJson = complemento,
                updatedAtUtc = DateTime.UtcNow
            }));
            repository.UpdateAtualizadoEmUtc(id, DateTime.UtcNow);
        }

        private static string MergeComplemento(string atual, string novo)
        {
            var destino = ParseObject(atual);
            var origem = ParseObject(novo);

            foreach (var property in origem)
                destino[property.Key] = property.Value?.DeepClone();

            return destino.ToJsonString();
        }

        private static JsonObject ParseObject(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return new JsonObject();

            try
            {
                return JsonNode.Parse(json) as JsonObject ?? new JsonObject();
            }
            catch (JsonException)
            {
                return new JsonObject();
            }
        }

        private static bool IsJsonObject(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return false;

            try
            {
                using var document = JsonDocument.Parse(json);
                return document.RootElement.ValueKind == JsonValueKind.Object;
            }
            catch (JsonException)
            {
                return false;
            }
        }
    }
}
