using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace Command.Receivers.UseCase
{
    internal static class FiscalEntradaPayloadReader
    {
        public static List<JsonElement> ReadItems(string? json)
        {
            var items = new List<JsonElement>();
            if (string.IsNullOrWhiteSpace(json))
                return items;

            using var document = JsonDocument.Parse(json);
            var root = document.RootElement;

            if (root.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in root.EnumerateArray())
                    items.Add(NormalizeItem(item));

                return items;
            }

            if (root.ValueKind == JsonValueKind.Object)
            {
                foreach (var collectionName in new[] { "notas", "notasFiscais", "documentos", "items" })
                {
                    if (TryGetProperty(root, collectionName, out var collection) && collection.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var item in collection.EnumerateArray())
                            items.Add(NormalizeItem(item));

                        return items;
                    }
                }

                items.Add(NormalizeItem(root));
            }

            return items;
        }

        public static string RawXml(JsonElement item)
        {
            if (item.ValueKind == JsonValueKind.String)
            {
                var text = item.GetString() ?? string.Empty;
                return LooksLikeXml(text) ? text : string.Empty;
            }

            return Text(item, "xml", "xmlNFe", "conteudoXml", "conteudo");
        }

        public static string SnapshotJson(JsonElement item)
        {
            if (item.ValueKind != JsonValueKind.Object)
                return item.GetRawText();

            var node = JsonNode.Parse(item.GetRawText()) as JsonObject;
            if (node == null)
                return item.GetRawText();

            RemoveProperty(node, "xml");
            RemoveProperty(node, "xmlNFe");
            RemoveProperty(node, "conteudoXml");
            RemoveProperty(node, "conteudo");
            return node.ToJsonString();
        }

        public static string Text(JsonElement item, params string[] names)
        {
            foreach (var name in names)
            {
                if (TryGetProperty(item, name, out var value))
                {
                    if (value.ValueKind == JsonValueKind.String)
                        return value.GetString() ?? string.Empty;

                    if (value.ValueKind == JsonValueKind.Number ||
                        value.ValueKind == JsonValueKind.True ||
                        value.ValueKind == JsonValueKind.False)
                        return value.ToString();
                }
            }

            return string.Empty;
        }

        public static decimal? Decimal(JsonElement item, params string[] names)
        {
            foreach (var name in names)
            {
                if (!TryGetProperty(item, name, out var value))
                    continue;

                if (value.ValueKind == JsonValueKind.Number && value.TryGetDecimal(out var decimalValue))
                    return decimalValue;

                if (value.ValueKind == JsonValueKind.String &&
                    decimal.TryParse(value.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimalValue))
                    return decimalValue;
            }

            return null;
        }

        private static JsonElement NormalizeItem(JsonElement item)
        {
            if (item.ValueKind == JsonValueKind.String)
            {
                var text = item.GetString() ?? string.Empty;
                if (!LooksLikeXml(text))
                    return item.Clone();

                return BuildXmlItem(text, new JsonObject());
            }

            if (item.ValueKind != JsonValueKind.Object)
                return item.Clone();

            var rawXml = RawXml(item);
            if (string.IsNullOrWhiteSpace(rawXml))
                return item.Clone();

            var node = JsonNode.Parse(item.GetRawText()) as JsonObject ?? new JsonObject();
            return BuildXmlItem(rawXml, node);
        }

        private static JsonElement BuildXmlItem(string rawXml, JsonObject node)
        {
            var nfe = TryReadNFe(rawXml);
            SetIfMissing(node, "tipoDocumento", "NFe");
            SetIfMissing(node, "xml", rawXml);

            if (nfe != null)
            {
                SetIfMissing(node, "chaveAcesso", nfe.ChaveAcesso);
                SetIfMissing(node, "numero", nfe.Numero);
                SetIfMissing(node, "serie", nfe.Serie);
                SetIfMissing(node, "emitenteDocumento", nfe.EmitenteDocumento);
                SetIfMissing(node, "destinatarioDocumento", nfe.DestinatarioDocumento);
                SetIfMissing(node, "ufOrigem", nfe.UFOrigem);
                SetIfMissing(node, "ufDestino", nfe.UFDestino);
                SetIfMissing(node, "municipioOrigemCodigoIbge", nfe.MunicipioOrigemCodigoIbge);
                SetIfMissing(node, "municipioDestinoCodigoIbge", nfe.MunicipioDestinoCodigoIbge);
                SetDecimalIfMissing(node, "valorDocumento", nfe.ValorDocumento);
                SetDecimalIfMissing(node, "pesoBruto", nfe.PesoBruto);
                SetDecimalIfMissing(node, "volume", nfe.Volume);
                SetIfMissing(node, "modelo", nfe.Modelo);
            }

            using var normalized = JsonDocument.Parse(node.ToJsonString());
            return normalized.RootElement.Clone();
        }

        private static NFeXmlData? TryReadNFe(string xml)
        {
            try
            {
                var document = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
                var infNFe = document.Descendants().FirstOrDefault(x => SameName(x, "infNFe"));
                if (infNFe == null)
                    return null;

                var ide = Child(infNFe, "ide");
                var emit = Child(infNFe, "emit");
                var dest = Child(infNFe, "dest");
                var enderEmit = Child(emit, "enderEmit");
                var enderDest = Child(dest, "enderDest");
                var total = Child(Child(infNFe, "total"), "ICMSTot");

                var chave = CleanChave(infNFe.Attribute("Id")?.Value);
                if (string.IsNullOrWhiteSpace(chave))
                    chave = document.Descendants().FirstOrDefault(x => SameName(x, "chNFe"))?.Value?.Trim() ?? string.Empty;

                var pesos = document.Descendants()
                    .Where(x => SameName(x, "vol"))
                    .Select(x => ParseDecimal(ChildValue(x, "pesoB")))
                    .Where(x => x.HasValue)
                    .Select(x => x!.Value)
                    .ToList();

                var volumes = document.Descendants()
                    .Where(x => SameName(x, "vol"))
                    .Select(x => ParseDecimal(ChildValue(x, "qVol")))
                    .Where(x => x.HasValue)
                    .Select(x => x!.Value)
                    .ToList();

                return new NFeXmlData(
                    chave,
                    ChildValue(ide, "nNF"),
                    ChildValue(ide, "serie"),
                    First(ChildValue(emit, "CNPJ"), ChildValue(emit, "CPF")),
                    First(ChildValue(dest, "CNPJ"), ChildValue(dest, "CPF")),
                    ChildValue(enderEmit, "UF"),
                    ChildValue(enderDest, "UF"),
                    ChildValue(enderEmit, "cMun"),
                    ChildValue(enderDest, "cMun"),
                    ParseDecimal(ChildValue(total, "vNF")),
                    pesos.Count == 0 ? null : pesos.Sum(),
                    volumes.Count == 0 ? null : volumes.Sum(),
                    ChildValue(ide, "mod"));
            }
            catch
            {
                return null;
            }
        }

        private static string ChildValue(XElement? element, string name)
        {
            return Child(element, name)?.Value?.Trim() ?? string.Empty;
        }

        private static XElement? Child(XElement? element, string name)
        {
            return element?.Elements().FirstOrDefault(x => SameName(x, name));
        }

        private static bool SameName(XElement element, string name)
        {
            return string.Equals(element.Name.LocalName, name, StringComparison.OrdinalIgnoreCase);
        }

        private static string CleanChave(string? value)
        {
            var text = (value ?? string.Empty).Trim();
            if (text.StartsWith("NFe", StringComparison.OrdinalIgnoreCase))
                text = text.Substring(3);

            return text;
        }

        private static decimal? ParseDecimal(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var text = value.Trim();
            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            if (decimal.TryParse(text.Replace(".", string.Empty).Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return result;

            return null;
        }

        private static bool LooksLikeXml(string value)
        {
            return value.TrimStart().StartsWith("<", StringComparison.Ordinal);
        }

        private static void SetIfMissing(JsonObject node, string name, string? value)
        {
            if (string.IsNullOrWhiteSpace(value) || HasValue(node, name))
                return;

            node[name] = value;
        }

        private static void SetDecimalIfMissing(JsonObject node, string name, decimal? value)
        {
            if (!value.HasValue || HasValue(node, name))
                return;

            node[name] = value.Value;
        }

        private static bool HasValue(JsonObject node, string name)
        {
            var property = node.FirstOrDefault(x => string.Equals(x.Key, name, StringComparison.OrdinalIgnoreCase));
            return !string.IsNullOrWhiteSpace(property.Key) &&
                   property.Value != null &&
                   !string.IsNullOrWhiteSpace(property.Value.ToString());
        }

        private static void RemoveProperty(JsonObject node, string name)
        {
            var property = node.FirstOrDefault(x => string.Equals(x.Key, name, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(property.Key))
                node.Remove(property.Key);
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

        private static string First(string current, string fallback)
        {
            return string.IsNullOrWhiteSpace(current) ? fallback : current;
        }

        private sealed record NFeXmlData(
            string ChaveAcesso,
            string Numero,
            string Serie,
            string EmitenteDocumento,
            string DestinatarioDocumento,
            string UFOrigem,
            string UFDestino,
            string MunicipioOrigemCodigoIbge,
            string MunicipioDestinoCodigoIbge,
            decimal? ValorDocumento,
            decimal? PesoBruto,
            decimal? Volume,
            string Modelo);
    }
}
