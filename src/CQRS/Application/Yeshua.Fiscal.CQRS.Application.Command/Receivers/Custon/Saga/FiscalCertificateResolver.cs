using IRepository.Read;
using Repositorio.Outputs;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Command.Receivers
{
    internal sealed record FiscalCertificateReference(
        string CertificatePath,
        string Password,
        string DocumentoTitular);

    internal static class FiscalCertificateResolver
    {
        public static FiscalCertificateReference? TryResolve(
            string cargaId,
            IEntradaFiscalContingenciaReadRepository entradaRepository,
            ICertificadoDigitalReadRepository certificadoRepository)
        {
            var entrada = entradaRepository.FirstByCargaId(cargaId);
            if (entrada is null || entrada.id <= 0 || entrada.certificadodigitalid <= 0)
            {
                return null;
            }

            var certificado = certificadoRepository.FirstById(entrada.certificadodigitalid);
            return Resolve(certificado, $"Carga {cargaId}");
        }

        public static FiscalCertificateReference Resolve(CertificadoDigitalDTO? certificado, string context)
        {
            if (certificado is null || certificado.id <= 0 || certificado.ativo != 1)
                throw new InvalidOperationException($"{context}: certificado digital vinculado nao esta ativo.");

            if (certificado.validoate.ToUniversalTime() <= DateTime.UtcNow)
                throw new InvalidOperationException($"{context}: certificado digital vinculado esta vencido.");

            if (string.IsNullOrWhiteSpace(certificado.storagekey) || !File.Exists(certificado.storagekey))
                throw new FileNotFoundException("Certificado digital vinculado nao foi encontrado no storage.", certificado.storagekey);

            if (string.IsNullOrWhiteSpace(certificado.senhastoragekey) || !File.Exists(certificado.senhastoragekey))
                throw new FileNotFoundException("Senha do certificado digital nao foi encontrada no storage.", certificado.senhastoragekey);

            var password = File.ReadAllText(certificado.senhastoragekey);
            string documentoTitular;
            try
            {
                using var pfx = new X509Certificate2(
                    certificado.storagekey,
                    password,
                    X509KeyStorageFlags.EphemeralKeySet);
                documentoTitular = ExtractCnpj(pfx);
            }
            catch (CryptographicException exception)
            {
                throw new InvalidOperationException($"{context}: nao foi possivel abrir o certificado digital vinculado.", exception);
            }

            if (documentoTitular.Length != 14)
                throw new InvalidOperationException($"{context}: nao foi possivel identificar o CNPJ dentro do certificado digital vinculado.");

            return new FiscalCertificateReference(certificado.storagekey, password, documentoTitular);
        }

        public static void ValidateIssuer(FiscalCertificateReference certificate, string issuerDocument, string documentName)
        {
            var certificateBase = CnpjBase(certificate.DocumentoTitular);
            var issuerBase = CnpjBase(issuerDocument);

            if (certificateBase.Length != 8 || issuerBase.Length != 8 ||
                !string.Equals(certificateBase, issuerBase, StringComparison.Ordinal))
            {
                throw new InvalidOperationException(
                    $"{documentName}: CNPJ-base do emitente {OnlyDigits(issuerDocument)} difere do " +
                    $"CNPJ-base do certificado {OnlyDigits(certificate.DocumentoTitular)}.");
            }
        }

        public static string ExtractCnpj(X509Certificate2 certificado)
        {
            var candidatos = new List<string>
            {
                certificado.Subject,
                certificado.GetNameInfo(X509NameType.SimpleName, false)
            };

            candidatos.AddRange(certificado.Extensions
                .Select(extension => extension.Format(false))
                .Where(value => !string.IsNullOrWhiteSpace(value)));

            foreach (var candidato in candidatos)
            {
                var match = Regex.Match(
                    candidato,
                    @"(?:OID\.)?2\.16\.76\.1\.3\.3\s*=\s*(\d{14})",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                if (match.Success)
                    return match.Groups[1].Value;

                match = Regex.Match(candidato, @"(?<!\d)(\d{14})(?!\d)", RegexOptions.CultureInvariant);
                if (match.Success)
                    return match.Groups[1].Value;
            }

            return string.Empty;
        }

        private static string CnpjBase(string value)
        {
            var digits = OnlyDigits(value);
            return digits.Length == 14 ? digits[..8] : string.Empty;
        }

        private static string OnlyDigits(string value)
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
