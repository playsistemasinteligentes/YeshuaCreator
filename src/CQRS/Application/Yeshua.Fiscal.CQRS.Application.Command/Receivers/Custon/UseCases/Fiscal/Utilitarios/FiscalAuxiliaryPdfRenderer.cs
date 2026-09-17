// <yeshua>
// artifact: CUSTOM_OWNED_BY_DEV
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// </yeshua>

using System.Globalization;
using System.Text;
using System.Xml.Linq;
using ZXing;
using ZXing.Common;

namespace Command.Receivers.UseCase
{
    internal static class FiscalAuxiliaryPdfRenderer
    {
        private const float PageWidth = 595;
        private const float PageHeight = 842;

        public static byte[] Render(string xml, string documentType)
        {
            var document = XDocument.Parse(xml);
            var isCte = string.Equals(documentType, "DACTE", StringComparison.Ordinal);
            var root = Find(document, isCte ? "infCte" : "infMDFe")
                ?? throw new InvalidOperationException($"XML nao contem dados para gerar {documentType}.");

            var protocol = Find(document, isCte ? "infProt" : "infProt");
            var key = Attribute(root, "Id").Replace(isCte ? "CTe" : "MDFe", string.Empty, StringComparison.Ordinal);
            if (key.Length != 44)
                throw new InvalidOperationException($"XML nao contem chave valida para gerar {documentType}.");

            var content = new StringBuilder(8192);
            DrawFrame(content);
            DrawHeader(content, documentType, isCte, root, protocol, key);

            if (isCte)
                DrawCte(content, root);
            else
                DrawMdfe(content, document, root);

            DrawFooter(content, documentType, key);
            return BuildPdf(content.ToString());
        }

        private static void DrawFrame(StringBuilder content)
        {
            Rectangle(content, 24, 24, PageWidth - 48, PageHeight - 48, 0.8f);
        }

        private static void DrawHeader(
            StringBuilder content,
            string documentType,
            bool isCte,
            XElement root,
            XElement? protocol,
            string key)
        {
            Text(content, 40, 800, 17, documentType, bold: true);
            Text(content, 40, 782, 8,
                isCte
                    ? "DOCUMENTO AUXILIAR DO CONHECIMENTO DE TRANSPORTE ELETRONICO"
                    : "DOCUMENTO AUXILIAR DO MANIFESTO ELETRONICO DE DOCUMENTOS FISCAIS");

            var environment = Value(root, "tpAmb") == "1" ? "PRODUCAO" : "HOMOLOGACAO";
            Text(content, 420, 800, 8, "AMBIENTE", bold: true);
            Text(content, 420, 786, 10, environment, bold: true);

            Line(content, 34, 768, 561, 768, 0.7f);
            Text(content, 40, 752, 7, "CHAVE DE ACESSO", bold: true);
            Text(content, 40, 737, 11, FormatKey(key), bold: true);
            DrawCode128(content, key, 310, 722, 240, 34);

            var protocolNumber = protocol == null ? string.Empty : Value(protocol, "nProt");
            var receivedAt = protocol == null ? string.Empty : Value(protocol, "dhRecbto");
            Text(content, 40, 710, 7, "PROTOCOLO DE AUTORIZACAO", bold: true);
            Text(content, 40, 695, 10, EmptyAsDash(protocolNumber));
            Text(content, 310, 710, 7, "DATA/HORA DA AUTORIZACAO", bold: true);
            Text(content, 310, 695, 10, EmptyAsDash(receivedAt));
            Line(content, 34, 681, 561, 681, 0.7f);
        }

        private static void DrawCte(StringBuilder content, XElement root)
        {
            var ide = Child(root, "ide");
            var emit = Child(root, "emit");
            var enderEmit = emit == null ? null : Child(emit, "enderEmit");
            var rem = Child(root, "rem");
            var dest = Child(root, "dest");
            var toma = Find(root, "toma3") ?? Find(root, "toma4");
            var values = Find(root, "vPrest");
            var carga = Find(root, "infCarga");

            Section(content, "IDENTIFICACAO DO CT-e", 662, new[]
            {
                Pair("MODELO", Value(ide, "mod")),
                Pair("SERIE", Value(ide, "serie")),
                Pair("NUMERO", Value(ide, "nCT")),
                Pair("EMISSAO", Value(ide, "dhEmi")),
                Pair("TIPO CT-e", Value(ide, "tpCTe")),
                Pair("TIPO SERVICO", Value(ide, "tpServ"))
            });

            Section(content, "EMITENTE", 598, new[]
            {
                Pair("RAZAO SOCIAL", Value(emit, "xNome")),
                Pair("CNPJ/CPF", FirstValue(emit, "CNPJ", "CPF")),
                Pair("INSCRICAO ESTADUAL", Value(emit, "IE")),
                Pair("ENDERECO", JoinAddress(enderEmit))
            });

            Section(content, "PERCURSO E PARTICIPANTES", 520, new[]
            {
                Pair("INICIO", Join(Value(ide, "xMunIni"), Value(ide, "UFIni"))),
                Pair("FIM", Join(Value(ide, "xMunFim"), Value(ide, "UFFim"))),
                Pair("REMETENTE", Party(rem)),
                Pair("DESTINATARIO", Party(dest)),
                Pair("TOMADOR", toma == null ? "-" : Value(toma, "toma"))
            });

            Section(content, "VALORES E CARGA", 442, new[]
            {
                Pair("VALOR DO SERVICO", Money(Value(values, "vTPrest"))),
                Pair("VALOR A RECEBER", Money(Value(values, "vRec"))),
                Pair("VALOR DA CARGA", Money(Value(carga, "vCarga"))),
                Pair("PRODUTO PREDOMINANTE", Value(carga, "proPred")),
                Pair("OUTRAS CARACTERISTICAS", Value(carga, "xOutCat"))
            });

            var documents = Find(root, "infDoc")?
                .Descendants()
                .Where(item => item.Name.LocalName is "chave" or "chNFe" or "chCTe")
                .Select(item => item.Value.Trim())
                .Where(item => item.Length > 0)
                .Distinct(StringComparer.Ordinal)
                .Take(8)
                .ToList() ?? new List<string>();
            DrawDocumentKeys(content, "DOCUMENTOS ORIGINARIOS", 364, documents);
        }

        private static void DrawMdfe(StringBuilder content, XDocument document, XElement root)
        {
            var ide = Child(root, "ide");
            var emit = Child(root, "emit");
            var enderEmit = emit == null ? null : Child(emit, "enderEmit");
            var vehicle = Find(root, "veicTracao");
            var driver = Find(vehicle, "condutor");

            Section(content, "IDENTIFICACAO DO MDF-e", 662, new[]
            {
                Pair("MODELO", Value(ide, "mod")),
                Pair("SERIE", Value(ide, "serie")),
                Pair("NUMERO", Value(ide, "nMDF")),
                Pair("EMISSAO", Value(ide, "dhEmi")),
                Pair("MODAL", Value(ide, "modal")),
                Pair("TIPO EMITENTE", Value(ide, "tpEmit"))
            });

            Section(content, "EMITENTE", 598, new[]
            {
                Pair("RAZAO SOCIAL", Value(emit, "xNome")),
                Pair("CNPJ", Value(emit, "CNPJ")),
                Pair("INSCRICAO ESTADUAL", Value(emit, "IE")),
                Pair("ENDERECO", JoinAddress(enderEmit))
            });

            var routeStates = root
                .Descendants()
                .Where(item => item.Name.LocalName == "UFPer")
                .Select(item => item.Value.Trim())
                .Where(item => item.Length > 0)
                .Distinct(StringComparer.Ordinal)
                .ToList();

            Section(content, "PERCURSO E TRANSPORTE", 520, new[]
            {
                Pair("UF CARREGAMENTO", Value(ide, "UFIni")),
                Pair("UF DESCARREGAMENTO", Value(ide, "UFFim")),
                Pair("PERCURSO", routeStates.Count == 0 ? "-" : string.Join(" / ", routeStates)),
                Pair("PLACA", Value(vehicle, "placa")),
                Pair("RNTRC", Value(root, "RNTRC")),
                Pair("CONDUTOR", Join(Value(driver, "xNome"), Value(driver, "CPF")))
            });

            var keys = root.Descendants()
                .Where(item => item.Name.LocalName is "chCTe" or "chNFe")
                .Select(item => item.Value.Trim())
                .Where(item => item.Length > 0)
                .Distinct(StringComparer.Ordinal)
                .Take(10)
                .ToList();
            DrawDocumentKeys(content, "DOCUMENTOS VINCULADOS", 424, keys);

            var qr = Find(document, "qrCodMDFe")?.Value.Trim();
            if (!string.IsNullOrWhiteSpace(qr))
            {
                Text(content, 40, 230, 7, "CONSULTA QR CODE", bold: true);
                DrawQr(content, qr, 40, 90, 125);
            }
        }

        private static void DrawDocumentKeys(
            StringBuilder content,
            string title,
            float top,
            IReadOnlyCollection<string> keys)
        {
            Text(content, 40, top, 8, title, bold: true);
            Line(content, 40, top - 5, 550, top - 5, 0.4f);

            var y = top - 20;
            if (keys.Count == 0)
            {
                Text(content, 40, y, 8, "Nenhum documento informado.");
                return;
            }

            foreach (var key in keys)
            {
                Text(content, 44, y, 8, FormatKey(key));
                y -= 14;
            }
        }

        private static void Section(
            StringBuilder content,
            string title,
            float top,
            IReadOnlyList<(string Label, string Value)> values)
        {
            Text(content, 40, top, 8, title, bold: true);
            Line(content, 40, top - 5, 550, top - 5, 0.4f);
            var columns = 2;
            var width = 255f;
            for (var index = 0; index < values.Count; index++)
            {
                var column = index % columns;
                var row = index / columns;
                var x = 40 + column * width;
                var y = top - 20 - row * 25;
                Text(content, x, y, 6.5f, values[index].Label, bold: true);
                Text(content, x, y - 11, 8.5f, Truncate(EmptyAsDash(values[index].Value), 58));
            }
        }

        private static void DrawFooter(StringBuilder content, string documentType, string key)
        {
            Line(content, 34, 55, 561, 55, 0.5f);
            Text(content, 40, 40, 7, $"{documentType} gerado a partir do XML autorizado. Chave: {key}");
        }

        private static byte[] BuildPdf(string pageContent)
        {
            var streamBytes = Encoding.ASCII.GetBytes(pageContent);
            var objects = new[]
            {
                "<< /Type /Catalog /Pages 2 0 R >>",
                "<< /Type /Pages /Kids [3 0 R] /Count 1 >>",
                "<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Resources << /Font << /F1 4 0 R /F2 5 0 R >> >> /Contents 6 0 R >>",
                "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>",
                "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold /Encoding /WinAnsiEncoding >>",
                $"<< /Length {streamBytes.Length} >>\nstream\n{pageContent}endstream"
            };

            using var output = new MemoryStream();
            WriteAscii(output, "%PDF-1.4\n%Yeshua\n");
            var offsets = new List<long> { 0 };
            for (var index = 0; index < objects.Length; index++)
            {
                offsets.Add(output.Position);
                WriteAscii(output, $"{index + 1} 0 obj\n{objects[index]}\nendobj\n");
            }

            var xref = output.Position;
            WriteAscii(output, $"xref\n0 {objects.Length + 1}\n");
            WriteAscii(output, "0000000000 65535 f \n");
            for (var index = 1; index < offsets.Count; index++)
                WriteAscii(output, offsets[index].ToString("0000000000", CultureInfo.InvariantCulture) + " 00000 n \n");

            WriteAscii(output, $"trailer\n<< /Size {objects.Length + 1} /Root 1 0 R >>\nstartxref\n{xref}\n%%EOF");
            return output.ToArray();
        }

        private static void DrawCode128(
            StringBuilder content,
            string value,
            float x,
            float y,
            float width,
            float height)
        {
            var matrix = new MultiFormatWriter().encode(
                value,
                BarcodeFormat.CODE_128,
                480,
                1,
                new Dictionary<EncodeHintType, object> { [EncodeHintType.MARGIN] = 0 });
            DrawLinearMatrix(content, matrix, x, y, width, height);
        }

        private static void DrawQr(
            StringBuilder content,
            string value,
            float x,
            float y,
            float size)
        {
            var matrix = new MultiFormatWriter().encode(
                value,
                BarcodeFormat.QR_CODE,
                100,
                100,
                new Dictionary<EncodeHintType, object> { [EncodeHintType.MARGIN] = 0 });
            var module = size / matrix.Width;
            content.Append("0 0 0 rg\n");
            for (var row = 0; row < matrix.Height; row++)
            {
                for (var column = 0; column < matrix.Width; column++)
                {
                    if (matrix[column, row])
                        RectangleFill(content, x + column * module, y + (matrix.Height - row - 1) * module, module, module);
                }
            }
        }

        private static void DrawLinearMatrix(
            StringBuilder content,
            BitMatrix matrix,
            float x,
            float y,
            float width,
            float height)
        {
            var module = width / matrix.Width;
            content.Append("0 0 0 rg\n");
            var column = 0;
            while (column < matrix.Width)
            {
                if (!matrix[column, 0])
                {
                    column++;
                    continue;
                }

                var start = column;
                while (column < matrix.Width && matrix[column, 0])
                    column++;
                RectangleFill(content, x + start * module, y, (column - start) * module, height);
            }
        }

        private static void Text(
            StringBuilder content,
            float x,
            float y,
            float size,
            string? value,
            bool bold = false)
        {
            content.Append("BT /")
                .Append(bold ? "F2" : "F1")
                .Append(' ')
                .Append(Number(size))
                .Append(" Tf 1 0 0 1 ")
                .Append(Number(x))
                .Append(' ')
                .Append(Number(y))
                .Append(" Tm (")
                .Append(Escape(value ?? string.Empty))
                .Append(") Tj ET\n");
        }

        private static void Line(
            StringBuilder content,
            float x1,
            float y1,
            float x2,
            float y2,
            float width)
        {
            content.Append(Number(width)).Append(" w ")
                .Append(Number(x1)).Append(' ').Append(Number(y1)).Append(" m ")
                .Append(Number(x2)).Append(' ').Append(Number(y2)).Append(" l S\n");
        }

        private static void Rectangle(
            StringBuilder content,
            float x,
            float y,
            float width,
            float height,
            float lineWidth)
        {
            content.Append(Number(lineWidth)).Append(" w ")
                .Append(Number(x)).Append(' ').Append(Number(y)).Append(' ')
                .Append(Number(width)).Append(' ').Append(Number(height)).Append(" re S\n");
        }

        private static void RectangleFill(
            StringBuilder content,
            float x,
            float y,
            float width,
            float height)
        {
            content.Append(Number(x)).Append(' ').Append(Number(y)).Append(' ')
                .Append(Number(width)).Append(' ').Append(Number(height)).Append(" re f\n");
        }

        private static XElement? Find(XContainer? parent, string localName) =>
            parent?.Descendants().FirstOrDefault(item => item.Name.LocalName == localName);

        private static XElement? Child(XElement? parent, string localName) =>
            parent?.Elements().FirstOrDefault(item => item.Name.LocalName == localName);

        private static string Value(XElement? parent, string localName) =>
            Find(parent, localName)?.Value.Trim() ?? string.Empty;

        private static string FirstValue(XElement? parent, params string[] localNames)
        {
            foreach (var localName in localNames)
            {
                var value = Value(parent, localName);
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
            }
            return string.Empty;
        }

        private static string Attribute(XElement element, string localName) =>
            element.Attributes().FirstOrDefault(item => item.Name.LocalName == localName)?.Value.Trim() ?? string.Empty;

        private static string Party(XElement? party) =>
            Join(Value(party, "xNome"), FirstValue(party, "CNPJ", "CPF"));

        private static string JoinAddress(XElement? address) => Join(
            Value(address, "xLgr"),
            Value(address, "nro"),
            Value(address, "xBairro"),
            Value(address, "xMun"),
            Value(address, "UF"));

        private static string Join(params string[] values) =>
            string.Join(" - ", values.Where(value => !string.IsNullOrWhiteSpace(value)));

        private static string Money(string value) =>
            decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result)
                ? result.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))
                : EmptyAsDash(value);

        private static string EmptyAsDash(string? value) =>
            string.IsNullOrWhiteSpace(value) ? "-" : value.Trim();

        private static string FormatKey(string value)
        {
            if (value.Length != 44)
                return value;
            return string.Join(" ", Enumerable.Range(0, 11).Select(index => value.Substring(index * 4, 4)));
        }

        private static string Truncate(string value, int maximum) =>
            value.Length <= maximum ? value : value[..(maximum - 3)] + "...";

        private static (string Label, string Value) Pair(string label, string value) => (label, value);

        private static string Number(float value) => value.ToString("0.###", CultureInfo.InvariantCulture);

        private static string Escape(string value)
        {
            var normalized = value.Normalize(NormalizationForm.FormD);
            var ascii = new StringBuilder(normalized.Length);
            foreach (var character in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(character) == UnicodeCategory.NonSpacingMark)
                    continue;
                ascii.Append(character is >= ' ' and <= '~' ? character : '?');
            }

            return ascii.ToString()
                .Replace("\\", "\\\\", StringComparison.Ordinal)
                .Replace("(", "\\(", StringComparison.Ordinal)
                .Replace(")", "\\)", StringComparison.Ordinal);
        }

        private static void WriteAscii(Stream stream, string value)
        {
            var bytes = Encoding.ASCII.GetBytes(value);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
