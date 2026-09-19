using System;

namespace Command.Receivers
{
    internal static class CteUfPolicy
    {
        public static int ResolveCode(string? uf)
        {
            return (uf ?? string.Empty).Trim().ToUpperInvariant() switch
            {
                "RO" => 11, "AC" => 12, "AM" => 13, "RR" => 14, "PA" => 15, "AP" => 16, "TO" => 17,
                "MA" => 21, "PI" => 22, "CE" => 23, "RN" => 24, "PB" => 25, "PE" => 26, "AL" => 27, "SE" => 28, "BA" => 29,
                "MG" => 31, "ES" => 32, "RJ" => 33, "SP" => 35,
                "PR" => 41, "SC" => 42, "RS" => 43,
                "MS" => 50, "MT" => 51, "GO" => 52, "DF" => 53,
                _ => 0
            };
        }

        public static bool MunicipioPertenceAoEstado(string? codigoMunicipioIbge, string? uf)
        {
            var codigoUf = ResolveCode(uf);
            var municipio = codigoMunicipioIbge?.Trim() ?? string.Empty;
            return codigoUf > 0 &&
                   municipio.Length == 7 &&
                   municipio.StartsWith(codigoUf.ToString("D2"), StringComparison.Ordinal);
        }
    }
}
