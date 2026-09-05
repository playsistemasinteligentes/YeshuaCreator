// <yeshua>
// artifact: CUSTOM_OWNED_BY_DEV
// createdBy: IA_DEV
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// </yeshua>

using Command.UseCase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Command.Receivers.UseCase
{
    internal sealed record PlanejamentoTransporteContexto(DateTime EmbarqueDe, DateTime EmbarqueAte, int LimitePedidos, string PlantaId);

    internal sealed record PlanejamentoTransporteLens(string Id, string Descricao, string[] Niveis);

    internal static class PlanejamentoTransporteLensCatalog
    {
        private static readonly PlanejamentoTransporteLens[] Lenses =
        {
            new PlanejamentoTransporteLens("estado-municipio", "Estado > municipio > pedido", new[] { "Estado", "Municipio" }),
            new PlanejamentoTransporteLens("estado-municipio-regiao-bairro", "Estado > municipio > regiao > bairro > pedido", new[] { "Estado", "Municipio", "Regiao", "Bairro" }),
            new PlanejamentoTransporteLens("rota-municipio", "Rota > municipio > pedido", new[] { "RotaId", "Municipio" })
        };

        public static List<PlanejamentoLenteResumo> List()
        {
            return Lenses
                .Select(lens => new PlanejamentoLenteResumo
                {
                    LenteId = lens.Id,
                    Descricao = lens.Descricao,
                    Niveis = string.Join(">", lens.Niveis.Concat(new[] { "Pedido" })),
                    ExpansaoRemota = true
                })
                .ToList();
        }

        public static PlanejamentoTransporteLens Get(string id)
        {
            return Lenses.FirstOrDefault(lens => string.Equals(lens.Id, id, StringComparison.OrdinalIgnoreCase))
                ?? Lenses[0];
        }

        public static string CreateContextId(DateTime embarqueDe, DateTime embarqueAte, int limitePedidos, string plantaId)
        {
            var planta = Uri.EscapeDataString(plantaId ?? string.Empty);
            return $"pt|{embarqueDe:yyyyMMdd}|{embarqueAte:yyyyMMdd}|{limitePedidos}|{planta}";
        }

        public static PlanejamentoTransporteContexto ParseContext(string contextoId)
        {
            var parts = (contextoId ?? string.Empty).Split('|');
            if (parts.Length >= 4
                && DateTime.TryParseExact(parts[1], "yyyyMMdd", null, DateTimeStyles.None, out var de)
                && DateTime.TryParseExact(parts[2], "yyyyMMdd", null, DateTimeStyles.None, out var ate)
                && int.TryParse(parts[3], out var limite))
            {
                var planta = parts.Length >= 5 ? Uri.UnescapeDataString(parts[4]) : string.Empty;
                return new PlanejamentoTransporteContexto(de, ate, NormalizeLimit(limite), planta);
            }

            return new PlanejamentoTransporteContexto(DateTime.Today, DateTime.Today.AddDays(1), 500, string.Empty);
        }

        public static Dictionary<string, string> ParseNodeId(string noId)
        {
            var filters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(noId))
                return filters;

            foreach (var part in noId.Split('|', StringSplitOptions.RemoveEmptyEntries))
            {
                var separator = part.IndexOf('=');
                if (separator <= 0)
                    continue;

                var field = Uri.UnescapeDataString(part[..separator]);
                var value = Uri.UnescapeDataString(part[(separator + 1)..]);
                if (!string.IsNullOrWhiteSpace(field))
                    filters[field] = value;
            }

            return filters;
        }

        public static string BuildNodeId(IReadOnlyDictionary<string, string> filters, string field, string value)
        {
            var next = new Dictionary<string, string>(filters, StringComparer.OrdinalIgnoreCase)
            {
                [field] = value ?? string.Empty
            };

            return string.Join("|", next.Select(item =>
                $"{Uri.EscapeDataString(item.Key)}={Uri.EscapeDataString(item.Value ?? string.Empty)}"));
        }

        public static int NormalizeLimit(int limitePedidos)
        {
            if (limitePedidos < 50)
                return 50;

            if (limitePedidos > 5000)
                return 5000;

            return limitePedidos;
        }

        public static PedidoPlanejamentoEnvelope ToEnvelope(Repositorio.Outputs.PedidoPlanejavelDTO pedido)
        {
            return new PedidoPlanejamentoEnvelope
            {
                PedidoId = pedido.pedidoid,
                ClienteNome = pedido.clientenome,
                Estado = pedido.estado,
                Municipio = pedido.municipio,
                Regiao = pedido.regiao,
                Bairro = pedido.bairro,
                RotaId = pedido.rotaid,
                Peso = pedido.peso,
                Volume = pedido.volume,
                EmbarqueAlvo = pedido.embarquealvo,
                VersaoPlanejamento = pedido.versaoplanejamento,
                AlertasResumo = pedido.alertasresumo
            };
        }
    }
}
