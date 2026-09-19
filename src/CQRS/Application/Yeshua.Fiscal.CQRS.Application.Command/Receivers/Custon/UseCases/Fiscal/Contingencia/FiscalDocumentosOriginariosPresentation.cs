// <yeshua>
// artifact: CUSTOM_OWNED_BY_DEV
// createdBy: IA_DEV
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// taxonomy: Fiscal.Contingencia.DocumentosOriginarios
// </yeshua>

using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers.UseCase
{
    // The browser renders only this projection. XML interpretation remains on the server.
    internal static class FiscalDocumentosOriginariosPresentation
    {
        public static FiscalDocumentosOriginariosView FromInputItems(IEnumerable<JsonElement> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            return Build(items.Select(FromInputItem));
        }

        public static FiscalDocumentosOriginariosView FromSnapshots(IEnumerable<NFeProdutoSnapshotDTO> snapshots)
        {
            ArgumentNullException.ThrowIfNull(snapshots);

            return Build(snapshots.Select(FromSnapshot));
        }

        public static string Serialize(FiscalDocumentosOriginariosView presentation)
        {
            ArgumentNullException.ThrowIfNull(presentation);
            return JsonSerializer.Serialize(presentation);
        }

        private static FiscalDocumentosOriginariosView Build(IEnumerable<FiscalDocumentoOriginarioView> documents)
        {
            var normalized = documents
                .Where(document => !string.IsNullOrWhiteSpace(document.ChaveAcesso))
                .GroupBy(document => document.ChaveAcesso, StringComparer.OrdinalIgnoreCase)
                .Select(group => group.First())
                .OrderBy(document => document.ChaveAcesso, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            var first = normalized.FirstOrDefault();
            return new FiscalDocumentosOriginariosView(
                normalized,
                new FiscalDocumentosOriginariosSuggestions(
                    first?.Emitente ?? FiscalParticipanteView.Empty,
                    first?.Destinatario ?? FiscalParticipanteView.Empty,
                    first?.UFOrigem ?? string.Empty,
                    first?.MunicipioOrigemCodigoIbge ?? string.Empty,
                    first?.UFDestino ?? string.Empty,
                    first?.MunicipioDestinoCodigoIbge ?? string.Empty));
        }

        private static FiscalDocumentoOriginarioView FromInputItem(JsonElement item)
        {
            var emitente = ReadParticipant(item, "emitenteSnapshot", "emitenteDocumento", "ufOrigem", "municipioOrigemCodigoIbge");
            var destinatario = ReadParticipant(item, "destinatarioSnapshot", "destinatarioDocumento", "ufDestino", "municipioDestinoCodigoIbge");

            return new FiscalDocumentoOriginarioView(
                FiscalEntradaPayloadReader.Text(item, "chaveAcesso", "chNFe"),
                FiscalEntradaPayloadReader.Text(item, "numero", "nNF"),
                FiscalEntradaPayloadReader.Text(item, "serie"),
                emitente,
                destinatario,
                First(FiscalEntradaPayloadReader.Text(item, "ufOrigem"), emitente.UF),
                First(FiscalEntradaPayloadReader.Text(item, "municipioOrigemCodigoIbge"), emitente.MunicipioCodigoIbge),
                First(FiscalEntradaPayloadReader.Text(item, "ufDestino"), destinatario.UF),
                First(FiscalEntradaPayloadReader.Text(item, "municipioDestinoCodigoIbge"), destinatario.MunicipioCodigoIbge),
                FiscalEntradaPayloadReader.Decimal(item, "valorDocumento", "vNF") ?? 0m,
                FiscalEntradaPayloadReader.Decimal(item, "pesoBruto", "pesoB") ?? 0m,
                FiscalEntradaPayloadReader.Decimal(item, "volume", "qVol") ?? 0m,
                FiscalEntradaPayloadReader.Text(item, "nomeArquivo"));
        }

        private static FiscalDocumentoOriginarioView FromSnapshot(NFeProdutoSnapshotDTO snapshot)
        {
            var emitente = ReadParticipant(
                snapshot.snapshotjson,
                "emitenteSnapshot",
                snapshot.emitentedocumento,
                snapshot.uforigem,
                snapshot.municipioorigemcodigoibge);
            var destinatario = ReadParticipant(
                snapshot.snapshotjson,
                "destinatarioSnapshot",
                snapshot.destinatariodocumento,
                snapshot.ufdestino,
                snapshot.municipiodestinocodigoibge);

            return new FiscalDocumentoOriginarioView(
                snapshot.chaveacesso,
                NumberFromKey(snapshot.chaveacesso),
                SerieFromKey(snapshot.chaveacesso),
                emitente,
                destinatario,
                First(snapshot.uforigem, emitente.UF),
                First(snapshot.municipioorigemcodigoibge, emitente.MunicipioCodigoIbge),
                First(snapshot.ufdestino, destinatario.UF),
                First(snapshot.municipiodestinocodigoibge, destinatario.MunicipioCodigoIbge),
                snapshot.valordocumento,
                snapshot.pesobruto,
                snapshot.volume,
                string.Empty);
        }

        private static FiscalParticipanteView ReadParticipant(
            JsonElement item,
            string propertyName,
            string documentProperty,
            string ufProperty,
            string municipioProperty)
        {
            if (TryGetProperty(item, propertyName, out var participant) && participant.ValueKind == JsonValueKind.Object)
            {
                return ReadParticipant(
                    participant,
                    FiscalEntradaPayloadReader.Text(item, documentProperty),
                    FiscalEntradaPayloadReader.Text(item, ufProperty),
                    FiscalEntradaPayloadReader.Text(item, municipioProperty));
            }

            return new FiscalParticipanteView(
                FiscalEntradaPayloadReader.Text(item, documentProperty),
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                FiscalEntradaPayloadReader.Text(item, municipioProperty),
                string.Empty,
                FiscalEntradaPayloadReader.Text(item, ufProperty),
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty);
        }

        private static FiscalParticipanteView ReadParticipant(
            string snapshotJson,
            string propertyName,
            string documentFallback,
            string ufFallback,
            string municipioFallback)
        {
            if (!string.IsNullOrWhiteSpace(snapshotJson))
            {
                try
                {
                    using var document = JsonDocument.Parse(snapshotJson);
                    if (TryGetProperty(document.RootElement, propertyName, out var participant) &&
                        participant.ValueKind == JsonValueKind.Object)
                    {
                        return ReadParticipant(participant, documentFallback, ufFallback, municipioFallback);
                    }
                }
                catch (JsonException)
                {
                }
            }

            return new FiscalParticipanteView(
                documentFallback,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                municipioFallback,
                string.Empty,
                ufFallback,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty);
        }

        private static FiscalParticipanteView ReadParticipant(
            JsonElement participant,
            string documentFallback,
            string ufFallback,
            string municipioFallback)
        {
            return new FiscalParticipanteView(
                First(Text(participant, "documento", "cnpj", "cpf"), documentFallback),
                Text(participant, "nome", "razaoSocial", "xNome"),
                Text(participant, "inscricaoEstadual", "ie", "IE"),
                Text(participant, "logradouro", "xLgr"),
                Text(participant, "numero", "nro"),
                Text(participant, "complemento", "xCpl"),
                Text(participant, "bairro", "xBairro"),
                First(Text(participant, "municipioCodigoIbge", "cMun"), municipioFallback),
                Text(participant, "municipioNome", "xMun"),
                First(Text(participant, "uf", "UF"), ufFallback),
                Text(participant, "cep", "CEP"),
                Text(participant, "paisCodigo", "cPais"),
                Text(participant, "paisNome", "xPais"),
                Text(participant, "telefone", "fone"));
        }

        private static string Text(JsonElement item, params string[] names)
        {
            foreach (var name in names)
            {
                if (!TryGetProperty(item, name, out var value))
                    continue;

                return value.ValueKind == JsonValueKind.String
                    ? value.GetString() ?? string.Empty
                    : value.ToString();
            }

            return string.Empty;
        }

        private static bool TryGetProperty(JsonElement item, string name, out JsonElement value)
        {
            if (item.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in item.EnumerateObject())
                {
                    if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                    {
                        value = property.Value;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        private static string NumberFromKey(string chaveAcesso)
        {
            return chaveAcesso?.Length >= 34
                ? chaveAcesso.Substring(25, 9).TrimStart('0')
                : string.Empty;
        }

        private static string SerieFromKey(string chaveAcesso)
        {
            return chaveAcesso?.Length >= 25
                ? chaveAcesso.Substring(22, 3).TrimStart('0')
                : string.Empty;
        }

        private static string First(string first, string fallback) =>
            string.IsNullOrWhiteSpace(first) ? fallback ?? string.Empty : first;
    }

    internal sealed record FiscalDocumentosOriginariosView(
        IReadOnlyList<FiscalDocumentoOriginarioView> Documentos,
        FiscalDocumentosOriginariosSuggestions Sugestoes);

    internal sealed record FiscalDocumentosOriginariosSuggestions(
        FiscalParticipanteView Remetente,
        FiscalParticipanteView Destinatario,
        string UFInicio,
        string MunicipioInicioCodigoIbge,
        string UFFim,
        string MunicipioFimCodigoIbge);

    internal sealed record FiscalDocumentoOriginarioView(
        string ChaveAcesso,
        string Numero,
        string Serie,
        FiscalParticipanteView Emitente,
        FiscalParticipanteView Destinatario,
        string UFOrigem,
        string MunicipioOrigemCodigoIbge,
        string UFDestino,
        string MunicipioDestinoCodigoIbge,
        decimal ValorDocumento,
        decimal PesoBruto,
        decimal Volume,
        string NomeArquivo);

    internal sealed record FiscalParticipanteView(
        string Documento,
        string Nome,
        string InscricaoEstadual,
        string Logradouro,
        string Numero,
        string Complemento,
        string Bairro,
        string MunicipioCodigoIbge,
        string MunicipioNome,
        string UF,
        string Cep,
        string PaisCodigo,
        string PaisNome,
        string Telefone)
    {
        public static FiscalParticipanteView Empty { get; } = new(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty);
    }
}
