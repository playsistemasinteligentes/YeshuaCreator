using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Command.Receivers.UseCase
{
    internal sealed record FiscalDocumentosOriginariosPersistRequest(
        string CorrelationId,
        string CargaId,
        string SourceApplication,
        string SourceModule,
        string SourceMessageId);

    internal sealed class FiscalDocumentosOriginariosPersistResult
    {
        public int Quantidade { get; set; }
        public decimal ValorCarga { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal Volume { get; set; }
        public string EmitenteDocumento { get; set; } = string.Empty;
        public string DestinatarioDocumento { get; set; } = string.Empty;
        public string UFOrigem { get; set; } = string.Empty;
        public string UFDestino { get; set; } = string.Empty;
        public string MunicipioOrigemCodigoIbge { get; set; } = string.Empty;
        public string MunicipioDestinoCodigoIbge { get; set; } = string.Empty;
    }

    internal static class FiscalDocumentosOriginariosPersister
    {
        public static FiscalDocumentosOriginariosPersistResult Persist(
            ILogger logger,
            IDomainTrackingPolicy domainTrackingPolicy,
            IDocumentoFiscalOriginarioWriteRepository documentoWriteRepository,
            INFeProdutoSnapshotWriteRepository nfeWriteRepository,
            FiscalDocumentosOriginariosPersistRequest request,
            IEnumerable<JsonElement> documentos)
        {
            var result = new FiscalDocumentosOriginariosPersistResult();
            var documentoFactory = new DocumentoFiscalOriginarioFactory(logger, domainTrackingPolicy);
            var nfeFactory = new NFeProdutoSnapshotFactory(logger, domainTrackingPolicy);

            foreach (var documento in documentos)
            {
                var chave = FiscalEntradaPayloadReader.Text(documento, "chaveAcesso", "chave", "chNFe");
                if (string.IsNullOrWhiteSpace(chave))
                    throw new InvalidOperationException("Documento originario sem chave de acesso.");

                var valor = FiscalEntradaPayloadReader.Decimal(documento, "valorDocumento", "valor", "vNF") ?? 0m;
                var peso = FiscalEntradaPayloadReader.Decimal(documento, "pesoBruto", "peso", "pesoTotal") ?? 0m;
                var volume = FiscalEntradaPayloadReader.Decimal(documento, "volume", "volumes", "qVol") ?? 0m;
                var emitente = FiscalEntradaPayloadReader.Text(documento, "emitenteDocumento", "cnpjEmitente", "emitente");
                var destinatario = FiscalEntradaPayloadReader.Text(documento, "destinatarioDocumento", "cnpjDestinatario", "destinatario");
                var ufOrigem = FiscalEntradaPayloadReader.Text(documento, "ufOrigem", "UFOrigem");
                var ufDestino = FiscalEntradaPayloadReader.Text(documento, "ufDestino", "UFDestino");
                var municipioOrigem = FiscalEntradaPayloadReader.Text(documento, "municipioOrigemCodigoIbge", "cMunOrig", "codigoMunicipioOrigem");
                var municipioDestino = FiscalEntradaPayloadReader.Text(documento, "municipioDestinoCodigoIbge", "cMunDest", "codigoMunicipioDestino");
                var sourceMessageId = string.IsNullOrWhiteSpace(request.SourceMessageId)
                    ? Guid.NewGuid().ToString()
                    : request.SourceMessageId;

                var originario = documentoFactory.Create(
                    null,
                    null,
                    request.CorrelationId,
                    request.SourceApplication,
                    request.SourceModule,
                    sourceMessageId,
                    FiscalEntradaPayloadReader.Text(documento, "tipoDocumento", "tipo", "modelo") is var tipo && !string.IsNullOrWhiteSpace(tipo) ? tipo : "NFe",
                    chave,
                    FiscalEntradaPayloadReader.Text(documento, "numero", "nNF"),
                    FiscalEntradaPayloadReader.Text(documento, "serie", "serieDocumento"),
                    emitente,
                    destinatario,
                    valor,
                    peso,
                    volume,
                    documento.GetRawText(),
                    1);

                documentoWriteRepository.Insert(originario);

                var snapshot = nfeFactory.Create(
                    null,
                    originario.Id,
                    request.CorrelationId,
                    request.CargaId,
                    FiscalEntradaPayloadReader.Text(documento, "pedidoId", "pedido", "pedidoOrigem"),
                    chave,
                    emitente,
                    destinatario,
                    ufOrigem,
                    ufDestino,
                    municipioOrigem,
                    municipioDestino,
                    valor,
                    peso,
                    volume,
                    FiscalEntradaPayloadReader.Text(documento, "xmlStorageKey", "xmlKey", "storageKey"),
                    documento.GetRawText(),
                    1);

                nfeWriteRepository.Insert(snapshot);

                result.Quantidade++;
                result.ValorCarga += valor;
                result.PesoBruto += peso;
                result.Volume += volume;
                result.EmitenteDocumento = First(result.EmitenteDocumento, emitente);
                result.DestinatarioDocumento = First(result.DestinatarioDocumento, destinatario);
                result.UFOrigem = First(result.UFOrigem, ufOrigem);
                result.UFDestino = First(result.UFDestino, ufDestino);
                result.MunicipioOrigemCodigoIbge = First(result.MunicipioOrigemCodigoIbge, municipioOrigem);
                result.MunicipioDestinoCodigoIbge = First(result.MunicipioDestinoCodigoIbge, municipioDestino);
            }

            return result;
        }

        private static string First(string current, string candidate)
        {
            return string.IsNullOrWhiteSpace(current) ? candidate ?? string.Empty : current;
        }
    }
}
