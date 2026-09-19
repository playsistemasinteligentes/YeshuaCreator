// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Command.Receivers
{
    // Fiscal F01: compila uma unica representacao da emissao antes de qualquer saga fiscal.
    internal static class FiscalEmissionPlanCompiler
    {
        public const string RulesVersion = "FiscalEmissionPlan.v1";

        public static FiscalEmissionPlanCompilation Compile(
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            string? certificadoDocumentoTitular = null,
            bool certificadoFoiVerificado = false)
        {
            ArgumentNullException.ThrowIfNull(entrada);
            ArgumentNullException.ThrowIfNull(documentos);

            var pendencias = FiscalContingenciaPayload.BuildPendencias(
                entrada,
                documentos,
                certificadoDocumentoTitular,
                certificadoFoiVerificado);
            var planoJson = FiscalContingenciaPayload.BuildPlanoEmissaoJson(
                entrada,
                documentos,
                pendencias,
                RulesVersion);

            return new FiscalEmissionPlanCompilation(
                planoJson,
                Hash(planoJson),
                pendencias);
        }

        public static FiscalEmissionPlanValidation ValidatePersistedPlan(string planoJson)
        {
            if (string.IsNullOrWhiteSpace(planoJson))
                return FiscalEmissionPlanValidation.Invalid("PlanoEmissaoAusente");

            try
            {
                using var document = JsonDocument.Parse(planoJson);
                var root = document.RootElement;
                if (root.ValueKind != JsonValueKind.Object ||
                    !PropertyText(root, "type").Equals("fiscal.contingencia.plano-emissao", StringComparison.OrdinalIgnoreCase))
                {
                    return FiscalEmissionPlanValidation.Invalid("PlanoEmissaoInvalido");
                }

                if (!PropertyText(root, "rulesVersion").Equals(RulesVersion, StringComparison.Ordinal))
                    return FiscalEmissionPlanValidation.Invalid("VersaoDoPlanoFiscalIncompativel");

                if (!root.TryGetProperty("pendencias", out var pendencias) ||
                    pendencias.ValueKind != JsonValueKind.Array)
                {
                    return FiscalEmissionPlanValidation.Invalid("PendenciasDoPlanoFiscalAusentes");
                }

                var erros = pendencias
                    .EnumerateArray()
                    .Where(item => item.ValueKind == JsonValueKind.String)
                    .Select(item => item.GetString())
                    .Where(item => !string.IsNullOrWhiteSpace(item))
                    .Select(item => item!)
                    .ToArray();

                return erros.Length == 0
                    ? FiscalEmissionPlanValidation.Valid()
                    : new FiscalEmissionPlanValidation(false, erros);
            }
            catch (JsonException)
            {
                return FiscalEmissionPlanValidation.Invalid("PlanoEmissaoJsonInvalido");
            }
        }

        private static string Hash(string value)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }

        private static string PropertyText(JsonElement root, string name)
        {
            foreach (var property in root.EnumerateObject())
            {
                if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase) &&
                    property.Value.ValueKind == JsonValueKind.String)
                {
                    return property.Value.GetString() ?? string.Empty;
                }
            }

            return string.Empty;
        }
    }

    internal sealed record FiscalEmissionPlanCompilation(
        string PlanJson,
        string PlanHash,
        IReadOnlyList<string> Pendencias)
    {
        public bool IsValid => Pendencias.Count == 0;
    }

    internal sealed record FiscalEmissionPlanValidation(bool IsValid, IReadOnlyList<string> Errors)
    {
        public static FiscalEmissionPlanValidation Valid() => new(true, Array.Empty<string>());
        public static FiscalEmissionPlanValidation Invalid(params string[] errors) => new(false, errors);
    }
}
