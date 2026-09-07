using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Write;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Command.Receivers
{
    internal static class SefazFiscalDocumentStore
    {
        private const int ProdutoFiscalCTe = 57;
        private const int ProdutoFiscalMDFe = 58;
        private const int StatusAutorizado = 1;
        private const int StatusRejeitado = 2;

        public static void PersistirCTe(
            IDocumentoFiscalWriteRepository repository,
            ILogger logger,
            SagaBase saga,
            SagaStepBase step,
            CteRecepcaoSincV4Result result)
        {
            try
            {
                PersistirDocumento(
                    repository,
                    logger,
                    step.CorrelationId,
                    $"Fiscal {saga.EntityId}",
                    produtoFiscal: ProdutoFiscalCTe,
                    chave: result.Chave,
                    protocolo: result.Protocolo,
                    codigoRetorno: result.CodigoRetorno,
                    mensagemRetorno: result.Motivo,
                    autorizado: result.Autorizado,
                    xml: string.IsNullOrWhiteSpace(result.SoapResponse) ? result.XmlCte : result.SoapResponse,
                    sufixo: "autorizacao");
            }
            catch (Exception ex)
            {
                logger.CommandFailed("Fiscal.CTe.PersistirDocumentoFiscal", step.CorrelationId, ex, 0);
            }
        }

        public static void PersistirMDFe(
            IDocumentoFiscalWriteRepository repository,
            ILogger logger,
            SagaBase saga,
            SagaStepBase step,
            MdfeRecepcaoSincResult result)
        {
            try
            {
                PersistirDocumento(
                    repository,
                    logger,
                    step.CorrelationId,
                    $"Fiscal {saga.EntityId}",
                    produtoFiscal: ProdutoFiscalMDFe,
                    chave: result.Chave,
                    protocolo: result.Protocolo,
                    codigoRetorno: result.CodigoRetorno,
                    mensagemRetorno: result.Motivo,
                    autorizado: result.Autorizado,
                    xml: string.IsNullOrWhiteSpace(result.SoapResponse) ? result.XmlMDFe : result.SoapResponse,
                    sufixo: "autorizacao");
            }
            catch (Exception ex)
            {
                logger.CommandFailed("Fiscal.MDFe.PersistirDocumentoFiscal", step.CorrelationId, ex, 0);
            }
        }

        public static void PersistirConsulta(
            IDocumentoFiscalWriteRepository repository,
            ILogger logger,
            string correlationId,
            SefazConsultaDocumentoResult result)
        {
            try
            {
                var produtoFiscal = string.Equals(result.TipoDocumento, "CTe", StringComparison.OrdinalIgnoreCase)
                    ? ProdutoFiscalCTe
                    : ProdutoFiscalMDFe;

                var storage = !string.IsNullOrWhiteSpace(result.XmlStorageKey) &&
                              !string.IsNullOrWhiteSpace(result.XmlHash)
                    ? new SefazXmlStorageResult(result.XmlStorageKey, result.XmlHash)
                    : null;

                PersistirDocumento(
                    repository,
                    logger,
                    correlationId,
                    $"Fiscal {result.TipoDocumento}",
                    produtoFiscal,
                    result.Chave,
                    result.Protocolo,
                    result.CodigoRetorno,
                    result.Motivo,
                    result.Autorizado,
                    result.SoapResponse,
                    "consulta",
                    storage);
            }
            catch (Exception ex)
            {
                logger.CommandFailed($"Fiscal.{result.TipoDocumento}.PersistirConsultaDocumentoFiscal", correlationId, ex, 0);
            }
        }

        public static SefazXmlStorageResult SalvarXmlResposta(
            string tipoDocumento,
            string servico,
            string chave,
            string xml)
        {
            var raiz = Environment.GetEnvironmentVariable("YESHUA_SEFAZ_STORAGE_ROOT");
            if (string.IsNullOrWhiteSpace(raiz))
            {
                raiz = Environment.GetEnvironmentVariable("STORAGE_ROOT");
            }

            if (string.IsNullOrWhiteSpace(raiz))
            {
                raiz = Path.Combine(AppContext.BaseDirectory, "storage");
            }

            var diretorio = Path.Combine(raiz, "sefaz", tipoDocumento.ToLowerInvariant(), servico.ToLowerInvariant());
            Directory.CreateDirectory(diretorio);

            var safeKey = OnlySafeFileName(string.IsNullOrWhiteSpace(chave) ? "sem-chave" : chave);
            var fileName = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "-" + safeKey + ".xml";
            var path = Path.Combine(diretorio, fileName);

            File.WriteAllText(path, xml, Encoding.UTF8);

            return new SefazXmlStorageResult(path, Hash(xml));
        }

        private static void PersistirDocumento(
            IDocumentoFiscalWriteRepository repository,
            ILogger logger,
            string correlationId,
            string contexto,
            int produtoFiscal,
            string chave,
            string? protocolo,
            int codigoRetorno,
            string mensagemRetorno,
            bool autorizado,
            string xml,
            string sufixo,
            SefazXmlStorageResult? storageOverride = null)
        {
            if (string.IsNullOrWhiteSpace(chave) || chave.Length != 44)
            {
                logger.Info($"{contexto}: documento SEFAZ sem chave valida para persistencia.");
                return;
            }

            var tipo = produtoFiscal == ProdutoFiscalCTe ? "cte" : "mdfe";
            var storage = storageOverride ?? SalvarXmlResposta(tipo, sufixo, chave, xml);
            var chaveInfo = SefazChaveAcessoInfo.Parse(chave);
            var factory = new DocumentoFiscalFactory(logger);
            var entity = factory.Create(
                id: null,
                correlationid: correlationId,
                produtofiscal: produtoFiscal,
                chaveacesso: chave,
                serie: chaveInfo.Serie,
                numero: chaveInfo.Numero,
                ambiente: 2,
                ufemitente: chaveInfo.CodigoUf,
                emitentedocumento: chaveInfo.CnpjEmitente,
                destinatariodocumento: string.Empty,
                xmlstoragekey: storage.Path,
                xmlhash: storage.Sha256,
                protocoloautorizacao: protocolo ?? string.Empty,
                codigoretorno: codigoRetorno.ToString(),
                mensagemretorno: mensagemRetorno,
                status: autorizado ? StatusAutorizado : StatusRejeitado);

            repository.Insert(entity);
        }

        private static string Hash(string value)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
            var builder = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        private static string OnlySafeFileName(string value)
        {
            var invalid = Path.GetInvalidFileNameChars();
            var builder = new StringBuilder(value.Length);
            foreach (var character in value)
            {
                builder.Append(Array.IndexOf(invalid, character) >= 0 ? '_' : character);
            }

            return builder.ToString();
        }
    }

    internal sealed record SefazXmlStorageResult(string Path, string Sha256);

    internal sealed record SefazChaveAcessoInfo(string CodigoUf, string CnpjEmitente, int? Serie, int? Numero)
    {
        public static SefazChaveAcessoInfo Parse(string chave)
        {
            if (string.IsNullOrWhiteSpace(chave) || chave.Length != 44)
                return new SefazChaveAcessoInfo(string.Empty, string.Empty, null, null);

            return new SefazChaveAcessoInfo(
                chave.Substring(0, 2),
                chave.Substring(6, 14),
                int.TryParse(chave.Substring(22, 3), out var serie) ? serie : null,
                int.TryParse(chave.Substring(25, 9), out var numero) ? numero : null);
        }
    }
}
