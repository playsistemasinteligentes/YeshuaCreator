using System;

namespace Command.Receivers
{
    internal static class CteCfopPolicy
    {
        public static string Resolve(string? ufEmitente, string? ufInicio, string? ufFim)
        {
            var emitente = NormalizeUf(ufEmitente, nameof(ufEmitente));
            var inicio = NormalizeUf(ufInicio, nameof(ufInicio));
            var fim = NormalizeUf(ufFim, nameof(ufFim));
            var prestacaoInterestadual = !string.Equals(inicio, fim, StringComparison.Ordinal);

            if (!string.Equals(emitente, inicio, StringComparison.Ordinal))
                return prestacaoInterestadual ? "6932" : "5932";

            return prestacaoInterestadual ? "6353" : "5353";
        }

        private static string NormalizeUf(string? value, string field)
        {
            var uf = value?.Trim().ToUpperInvariant() ?? string.Empty;
            if (uf.Length != 2)
                throw new InvalidOperationException($"Nao foi possivel determinar o CFOP: {field} invalida.");

            return uf;
        }
    }
}
