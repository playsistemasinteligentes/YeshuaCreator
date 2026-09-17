// <yeshua>
// artifact: CUSTOM_OWNED_BY_DEV
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// </yeshua>

using IRepository.Read;
using Repositorio.Outputs;
using System.IO.Compression;
using System.Text;
using System.Xml.Linq;

namespace Command.Receivers.UseCase
{
    internal static class DocumentoFiscalUtilitarios
    {
        private const int ProdutoFiscalCTe = 57;
        private const int ProdutoFiscalMDFe = 58;

        public static DocumentoFiscalArquivo CarregarCTe(
            string chaveAcesso,
            ICTeTentativaEmissaoReadRepository tentativaRepository,
            IDocumentoFiscalReadRepository documentoRepository)
        {
            ValidarChave(chaveAcesso);
            var tentativa = tentativaRepository.FirstByChaveAcesso(chaveAcesso);
            ValidarTentativaCTe(tentativa, chaveAcesso);

            return CarregarXmlProcessado(
                chaveAcesso,
                ProdutoFiscalCTe,
                "CTe",
                "cteProc",
                "protCTe",
                "4.00",
                tentativa.xmlprocstoragekey,
                tentativa.xmlassinadostoragekey,
                documentoRepository);
        }

        public static DocumentoFiscalArquivo CarregarMDFe(
            string chaveAcesso,
            IMDFeTentativaEmissaoReadRepository tentativaRepository,
            IDocumentoFiscalReadRepository documentoRepository)
        {
            ValidarChave(chaveAcesso);
            var tentativa = tentativaRepository.FirstByChaveAcesso(chaveAcesso);
            ValidarTentativaMDFe(tentativa, chaveAcesso);

            return CarregarXmlProcessado(
                chaveAcesso,
                ProdutoFiscalMDFe,
                "MDFe",
                "mdfeProc",
                "protMDFe",
                "3.00",
                tentativa.xmlprocstoragekey,
                tentativa.xmlassinadostoragekey,
                documentoRepository);
        }

        public static DocumentoFiscalPdf GerarDactes(
            IReadOnlyCollection<string> chavesAcesso,
            ICTeTentativaEmissaoReadRepository tentativaRepository,
            IDocumentoFiscalReadRepository documentoRepository)
        {
            var chaves = NormalizarChaves(chavesAcesso);
            var documentos = chaves
                .Select(chave => CarregarCTe(chave, tentativaRepository, documentoRepository))
                .ToList();

            return GerarPdfs(documentos, "DACTE");
        }

        public static DocumentoFiscalPdf GerarDamdfe(
            IReadOnlyCollection<string> chavesAcesso,
            IMDFeTentativaEmissaoReadRepository tentativaRepository,
            IDocumentoFiscalReadRepository documentoRepository)
        {
            var chaves = NormalizarChaves(chavesAcesso);
            var documentos = chaves
                .Select(chave => CarregarMDFe(chave, tentativaRepository, documentoRepository))
                .ToList();

            return GerarPdfs(documentos, "DAMDFE");
        }

        private static DocumentoFiscalArquivo CarregarXmlProcessado(
            string chaveAcesso,
            int produtoFiscal,
            string elementoDocumento,
            string elementoProcessado,
            string elementoProtocolo,
            string versao,
            string? xmlProcessadoStorageKey,
            string? xmlAssinadoStorageKey,
            IDocumentoFiscalReadRepository documentoRepository)
        {
            var fontes = new List<string>();
            AdicionarFonte(fontes, xmlProcessadoStorageKey);
            AdicionarFonte(fontes, xmlAssinadoStorageKey);

            var registros = documentoRepository
                .GetAllByChaveAcesso(chaveAcesso)
                .Where(item => item.produtofiscal == produtoFiscal)
                .OrderByDescending(item => item.id);

            foreach (var registro in registros)
                AdicionarFonte(fontes, registro.xmlstoragekey);

            XElement? documento = null;
            XElement? protocolo = null;

            foreach (var fonte in fontes)
            {
                var xml = File.ReadAllText(fonte, Encoding.UTF8);
                var raiz = ParseXml(xml);
                var processado = LocalizarElemento(raiz, elementoProcessado);
                if (processado != null)
                {
                    var xmlFinal = NormalizarXml(processado);
                    return new DocumentoFiscalArquivo(chaveAcesso, xmlFinal);
                }

                documento ??= LocalizarElemento(raiz, elementoDocumento);
                protocolo ??= LocalizarElemento(raiz, elementoProtocolo);
            }

            if (documento == null)
                throw new InvalidOperationException($"XML assinado do {elementoDocumento} {chaveAcesso} nao foi encontrado no storage.");

            if (protocolo == null)
                throw new InvalidOperationException($"Protocolo de autorizacao do {elementoDocumento} {chaveAcesso} nao foi encontrado no storage.");

            var namespaceFiscal = documento.Name.Namespace;
            var processadoMontado = new XElement(
                namespaceFiscal + elementoProcessado,
                new XAttribute("versao", versao),
                new XElement(documento),
                new XElement(protocolo));

            return new DocumentoFiscalArquivo(chaveAcesso, NormalizarXml(processadoMontado));
        }

        private static DocumentoFiscalPdf GerarPdfs(
            IReadOnlyCollection<DocumentoFiscalArquivo> documentos,
            string prefixo)
        {
            var arquivos = documentos
                .Select(documento => (
                    documento.ChaveAcesso,
                    Conteudo: FiscalAuxiliaryPdfRenderer.Render(documento.Xml, prefixo)))
                .ToList();

            if (arquivos.Count == 1)
            {
                return new DocumentoFiscalPdf(
                    prefixo + "-" + arquivos[0].ChaveAcesso + ".pdf",
                    "application/pdf",
                    arquivos[0].Conteudo,
                    1);
            }

            using var zipStream = new MemoryStream();
            using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true))
            {
                foreach (var arquivo in arquivos)
                {
                    var entry = zip.CreateEntry(
                        prefixo + "-" + arquivo.ChaveAcesso + ".pdf",
                        CompressionLevel.Fastest);
                    using var entryStream = entry.Open();
                    entryStream.Write(arquivo.Conteudo);
                }
            }

            return new DocumentoFiscalPdf(
                prefixo + "S-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".zip",
                "application/zip",
                zipStream.ToArray(),
                arquivos.Count);
        }

        private static XDocument ParseXml(string xml)
        {
            var document = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
            if (LocalizarElemento(document, "CTe") != null || LocalizarElemento(document, "MDFe") != null)
                return document;

            foreach (var text in document.DescendantNodes().OfType<XText>())
            {
                var value = text.Value.Trim();
                if (!value.StartsWith("<", StringComparison.Ordinal))
                    continue;

                try
                {
                    var embedded = XDocument.Parse(value, LoadOptions.PreserveWhitespace);
                    if (LocalizarElemento(embedded, "CTe") != null || LocalizarElemento(embedded, "MDFe") != null)
                        return embedded;
                }
                catch
                {
                    // O texto nao contem outro documento XML completo.
                }
            }

            return document;
        }

        private static XElement? LocalizarElemento(XContainer container, string localName)
        {
            if (container is XDocument document &&
                string.Equals(document.Root?.Name.LocalName, localName, StringComparison.Ordinal))
            {
                return document.Root;
            }

            if (container is XElement element &&
                string.Equals(element.Name.LocalName, localName, StringComparison.Ordinal))
            {
                return element;
            }

            return container
                .Descendants()
                .FirstOrDefault(item => string.Equals(item.Name.LocalName, localName, StringComparison.Ordinal));
        }

        private static string NormalizarXml(XElement element)
        {
            var document = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement(element));
            return document.ToString(SaveOptions.DisableFormatting);
        }

        private static IReadOnlyList<string> NormalizarChaves(IReadOnlyCollection<string> chavesAcesso)
        {
            if (chavesAcesso == null || chavesAcesso.Count == 0)
                throw new ArgumentException("Informe ao menos uma chave de acesso.", nameof(chavesAcesso));

            var chaves = chavesAcesso
                .Where(chave => !string.IsNullOrWhiteSpace(chave))
                .Select(chave => chave.Trim())
                .Distinct(StringComparer.Ordinal)
                .ToList();

            if (chaves.Count == 0)
                throw new ArgumentException("Informe ao menos uma chave de acesso.", nameof(chavesAcesso));

            foreach (var chave in chaves)
                ValidarChave(chave);

            return chaves;
        }

        private static void ValidarChave(string chaveAcesso)
        {
            if (string.IsNullOrWhiteSpace(chaveAcesso) ||
                chaveAcesso.Length != 44 ||
                chaveAcesso.Any(character => character < '0' || character > '9'))
            {
                throw new ArgumentException("A chave de acesso deve conter 44 digitos.", nameof(chaveAcesso));
            }
        }

        private static void ValidarTentativaCTe(CTeTentativaEmissaoDTO? tentativa, string chaveAcesso)
        {
            if (tentativa == null || tentativa.id <= 0)
                throw new InvalidOperationException($"CT-e {chaveAcesso} nao encontrado.");
            if (tentativa.status != 3 || string.IsNullOrWhiteSpace(tentativa.protocoloautorizacao))
                throw new InvalidOperationException($"CT-e {chaveAcesso} nao esta autorizado.");
        }

        private static void ValidarTentativaMDFe(MDFeTentativaEmissaoDTO? tentativa, string chaveAcesso)
        {
            if (tentativa == null || tentativa.id <= 0)
                throw new InvalidOperationException($"MDF-e {chaveAcesso} nao encontrado.");
            if (tentativa.status != 3 || string.IsNullOrWhiteSpace(tentativa.protocoloautorizacao))
                throw new InvalidOperationException($"MDF-e {chaveAcesso} nao esta autorizado.");
        }

        private static void AdicionarFonte(ICollection<string> fontes, string? path)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path) && !fontes.Contains(path, StringComparer.OrdinalIgnoreCase))
                fontes.Add(path);
        }
    }

    internal sealed record DocumentoFiscalArquivo(string ChaveAcesso, string Xml);

    internal sealed record DocumentoFiscalPdf(
        string NomeArquivo,
        string ContentType,
        byte[] Conteudo,
        int Quantidade);
}
