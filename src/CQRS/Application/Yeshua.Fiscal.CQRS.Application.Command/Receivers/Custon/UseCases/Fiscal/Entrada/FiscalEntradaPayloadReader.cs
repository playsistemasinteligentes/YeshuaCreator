using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

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
                    items.Add(item.Clone());

                return items;
            }

            if (root.ValueKind == JsonValueKind.Object)
            {
                foreach (var collectionName in new[] { "notas", "notasFiscais", "documentos", "items" })
                {
                    if (TryGetProperty(root, collectionName, out var collection) && collection.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var item in collection.EnumerateArray())
                            items.Add(item.Clone());

                        return items;
                    }
                }

                items.Add(root.Clone());
            }

            return items;
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
    }
}
