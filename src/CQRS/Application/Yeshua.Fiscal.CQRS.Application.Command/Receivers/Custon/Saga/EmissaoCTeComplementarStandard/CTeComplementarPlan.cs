// <yeshua>
// artifact: CUSTOM_OWNED_BY_DEV
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// </yeshua>

using Dominio.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    internal sealed record CTeComplementarPlan(
        string SourceApplication,
        string SourceModule,
        string SourceMessageId,
        string PayloadHash,
        string PayloadStorageKey,
        string CargaId,
        int Ambiente,
        string EmitenteDocumento,
        string TomadorDocumento,
        string RemetenteDocumento,
        string DestinatarioDocumento,
        string UfEmitente,
        string UfInicio,
        string UfFim,
        string MunicipioInicioCodigoIbge,
        string MunicipioFimCodigoIbge,
        string Cfop,
        int TipoServico,
        int Modal,
        int Globalizado,
        IReadOnlyList<string> ChavesCTeOriginais,
        decimal ValorPrestacaoComplementar,
        string CstIcms,
        decimal ValorBaseCalculoIcms,
        decimal AliquotaIcms,
        decimal ValorIcms,
        string PlanoJson)
    {
        public static CTeComplementarPlan From(SagaBase saga, SagaStepBase step)
        {
            using var envelope = JsonDocument.Parse(step.Payload ?? "{}");
            var envelopeRoot = envelope.RootElement;
            var storageKey = Text(envelopeRoot, "payloadStorageKey", "PayloadStorageKey");
            var payloadHash = Text(envelopeRoot, "payloadHash", "PayloadHash");
            if (string.IsNullOrWhiteSpace(storageKey))
                throw new InvalidOperationException($"Carga {saga.EntityId}: plano do CT-e complementar nao foi informado.");

            var planJson = FiscalPayloadStore.Read(storageKey, payloadHash);
            var validation = FiscalEmissionPlanCompiler.ValidatePersistedPlan(planJson);
            if (!validation.IsValid)
            {
                throw new InvalidOperationException(
                    $"Carga {saga.EntityId}: plano do CT-e complementar invalido: {string.Join(", ", validation.Errors)}.");
            }

            using var plan = JsonDocument.Parse(planJson);
            var root = plan.RootElement;
            var tipoCTe = Integer(root, "tipoCTe", "TipoCTe");
            if (tipoCTe != 1)
                throw new InvalidOperationException($"Carga {saga.EntityId}: o plano informado nao e de CT-e complementar.");

            return new CTeComplementarPlan(
                Text(envelopeRoot, "sourceApplication", "SourceApplication", fallback: "ContingenciaFiscal"),
                Text(envelopeRoot, "sourceModule", "SourceModule", fallback: "Fiscal"),
                Text(envelopeRoot, "sourceMessageId", "SourceMessageId", fallback: Guid.NewGuid().ToString()),
                payloadHash,
                storageKey,
                Text(root, "cargaid", "cargaId", fallback: saga.EntityId ?? string.Empty),
                Integer(root, "ambiente", "Ambiente", fallback: 2),
                Digits(TextDeep(root, "emitenteFiscalDocumento", "emitenteDocumento", "cnpjEmitente")),
                Digits(TextDeep(root, "tomadorDocumento", "cnpjTomador")),
                Digits(TextDeep(root, "remetenteDocumento", "cnpjRemetente")),
                Digits(TextDeep(root, "destinatarioDocumento", "cnpjDestinatario")),
                TextDeep(root, "emitenteUf", "ufEmitente"),
                Text(root, new[] { "ufinicio", "ufInicio", "UFInicio" }, string.Empty),
                Text(root, new[] { "uffim", "ufFim", "UFFim" }, string.Empty),
                Text(root, "municipioiniciocodigoibge", "municipioInicioCodigoIbge"),
                Text(root, "municipiofimcodigoibge", "municipioFimCodigoIbge"),
                TextDeep(root, "cfop", "CFOP"),
                Integer(root, "tipoServico", "TipoServico"),
                Integer(root, "modal", "Modal", fallback: 1),
                Integer(root, "globalizado", "Globalizado"),
                StringList(root, "chavesCTeOriginal", "chavesCTeOriginais", "chavesCTeComplementado"),
                Number(root, "valorPrestacaoComplementar", "valorServicoComplementar"),
                Text(root, new[] { "cstIcms", "cstICMS", "CST" }, string.Empty),
                Number(root, "valorBaseCalculoIcms", "baseCalculoIcms"),
                Number(root, "aliquotaIcms", "aliquotaICMS"),
                Number(root, "valorIcms", "valorICMS"),
                planJson);
        }

        public string ParticipantName(string role)
            => TextDeep(ParsePlan(), role + "Nome", "nome" + role, role + "RazaoSocial");

        public string ParticipantStateRegistration(string role)
            => TextDeep(ParsePlan(), role + "InscricaoEstadual", "inscricaoEstadual" + role, role + "IE");

        public string ParticipantUf(string role)
            => TextDeep(ParsePlan(), role + "Uf", "uf" + role);

        public string ParticipantMunicipality(string role)
            => TextDeep(ParsePlan(), role + "MunicipioCodigoIbge", "municipioCodigoIbge" + role);

        public string ParticipantAddressJson(string role)
        {
            using var plan = JsonDocument.Parse(PlanoJson);
            var root = plan.RootElement;
            return JsonSerializer.Serialize(new
            {
                logradouro = TextDeep(root, role + "Logradouro", "logradouro" + role),
                numero = TextDeep(root, role + "Numero", "numero" + role),
                bairro = TextDeep(root, role + "Bairro", "bairro" + role),
                municipioCodigoIbge = TextDeep(root, role + "MunicipioCodigoIbge", "municipioCodigoIbge" + role),
                municipioNome = TextDeep(root, role + "MunicipioNome", "municipioNome" + role),
                uf = TextDeep(root, role + "Uf", "uf" + role),
                cep = TextDeep(root, role + "Cep", "cep" + role)
            });
        }

        private JsonElement ParsePlan()
        {
            using var document = JsonDocument.Parse(PlanoJson);
            return document.RootElement.Clone();
        }

        private static string TextDeep(JsonElement root, params string[] names)
        {
            var value = Text(root, names);
            if (!string.IsNullOrWhiteSpace(value))
                return value;

            foreach (var nestedName in new[] { "parametrosFiscaisEfetivos", "preferenciasFiscaisJson", "dadosComplementaresJson" })
            {
                if (!TryProperty(root, nestedName, out var nested))
                    continue;

                if (nested.ValueKind == JsonValueKind.Object)
                {
                    value = Text(nested, names);
                    if (!string.IsNullOrWhiteSpace(value))
                        return value;
                }
                else if (nested.ValueKind == JsonValueKind.String)
                {
                    var json = nested.GetString();
                    if (string.IsNullOrWhiteSpace(json))
                        continue;

                    try
                    {
                        using var document = JsonDocument.Parse(json);
                        value = Text(document.RootElement, names);
                        if (!string.IsNullOrWhiteSpace(value))
                            return value;
                    }
                    catch (JsonException)
                    {
                    }
                }
            }

            return string.Empty;
        }

        private static string Text(JsonElement root, params string[] names)
            => Text(root, names, string.Empty);

        private static string Text(JsonElement root, string first, string second, string fallback)
            => Text(root, new[] { first, second }, fallback);

        private static string Text(JsonElement root, string[] names, string fallback)
        {
            foreach (var name in names)
            {
                if (!TryProperty(root, name, out var value) || value.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
                    continue;

                return value.ValueKind == JsonValueKind.String
                    ? value.GetString() ?? fallback
                    : value.ToString();
            }

            return fallback;
        }

        private static int Integer(JsonElement root, string first, string second, int fallback = 0)
            => int.TryParse(Text(root, first, second, string.Empty), NumberStyles.Integer, CultureInfo.InvariantCulture, out var value)
                ? value
                : fallback;

        private static decimal Number(JsonElement root, string first, string second)
            => decimal.TryParse(Text(root, first, second, string.Empty), NumberStyles.Any, CultureInfo.InvariantCulture, out var value)
                ? value
                : 0m;

        private static IReadOnlyList<string> StringList(JsonElement root, params string[] names)
        {
            foreach (var name in names)
            {
                if (!TryProperty(root, name, out var value))
                    continue;

                if (value.ValueKind == JsonValueKind.Array)
                {
                    return value.EnumerateArray()
                        .Select(x => Digits(x.ValueKind == JsonValueKind.String ? x.GetString() ?? string.Empty : x.ToString()))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct(StringComparer.Ordinal)
                        .ToArray();
                }
            }

            return Array.Empty<string>();
        }

        private static bool TryProperty(JsonElement root, string name, out JsonElement value)
        {
            if (root.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in root.EnumerateObject())
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

        internal static string Digits(string value)
        {
            var buffer = new char[value?.Length ?? 0];
            var count = 0;
            foreach (var character in value ?? string.Empty)
            {
                if (character is >= '0' and <= '9')
                    buffer[count++] = character;
            }

            return new string(buffer, 0, count);
        }
    }
}
