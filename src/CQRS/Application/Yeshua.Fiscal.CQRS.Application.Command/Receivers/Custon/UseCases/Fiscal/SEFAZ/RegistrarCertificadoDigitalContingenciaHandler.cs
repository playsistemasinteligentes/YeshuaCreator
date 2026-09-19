// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Dominio.Entitys;
using Repositorio.Outputs;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Command.Receivers.UseCase
{
    public partial class RegistrarCertificadoDigitalContingenciaHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICertificadoDigitalReadRepository _repReadCertificadoDigital = default!;
        private readonly ICertificadoDigitalWriteRepository _repWriteCertificadoDigital = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia = default!;
        public RegistrarCertificadoDigitalContingenciaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICertificadoDigitalReadRepository repReadCertificadoDigital, ICertificadoDigitalWriteRepository repWriteCertificadoDigital,IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia, IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCertificadoDigital = repReadCertificadoDigital;
            _repWriteCertificadoDigital = repWriteCertificadoDigital;
            _repReadEntradaFiscalContingencia = repReadEntradaFiscalContingencia;
            _repWriteEntradaFiscalContingencia = repWriteEntradaFiscalContingencia;
        }
protected partial async Task<State<RegistrarCertificadoDigitalContingenciaOutputCommand>> CustomActionHookAsync(State<RegistrarCertificadoDigitalContingenciaOutputCommand> state, RegistrarCertificadoDigitalContingenciaInputCommand comand, CancellationToken cancellationToken)
{
    if (comand.EntradaFiscalContingenciaId <= 0)
        return ValidationError("Informe o protocolo da contingencia fiscal.");

    var entrada = _repReadEntradaFiscalContingencia.FirstById(comand.EntradaFiscalContingenciaId);
    if (entrada is null || entrada.id <= 0)
        return ValidationError("Contingencia fiscal nao encontrada.");

    var documentoTitular = SomenteDigitos(comand.DocumentoTitular);
    if (documentoTitular.Length != 14)
        return ValidationError("Informe o CNPJ do titular do certificado.");

    var existentes = _repReadCertificadoDigital
        .GetAllByDocumentoTitular(documentoTitular)
        .Where(x => x.tenantid == _executionContext.TenantID && !x.deleted)
        .ToList();

    if (string.IsNullOrWhiteSpace(comand.ArquivoPfxBase64))
    {
        var reutilizavel = existentes
            .Where(x => x.ativo == 1 && x.validoate.ToUniversalTime() > DateTime.UtcNow)
            .OrderByDescending(x => x.validoate)
            .FirstOrDefault();

        if (reutilizavel is null)
            return ValidationError("Nenhum certificado ativo e valido foi encontrado para o titular informado.");

        _repWriteEntradaFiscalContingencia.UpdateCertificadoDigitalId(entrada.id, reutilizavel.id);
        return Success("Certificado reutilizado.", CriarSaida(reutilizavel, true, "Certificado reutilizado e vinculado a contingencia."));
    }

    byte[] pfx;
    try
    {
        pfx = Convert.FromBase64String(LimparPrefixoBase64(comand.ArquivoPfxBase64));
    }
    catch (FormatException)
    {
        return ValidationError("O arquivo PFX informado nao esta em Base64 valido.");
    }

    X509Certificate2 certificado;
    try
    {
        certificado = new X509Certificate2(
            pfx,
            comand.Senha,
            X509KeyStorageFlags.EphemeralKeySet | X509KeyStorageFlags.Exportable);
    }
    catch (Exception exception) when (exception is CryptographicException or ArgumentException)
    {
        return ValidationError("Nao foi possivel abrir o certificado PFX. Verifique o arquivo e a senha.");
    }

    using (certificado)
    {
        if (!certificado.HasPrivateKey)
            return ValidationError("O certificado nao possui chave privada.");

        var agora = DateTime.Now;
        if (agora < certificado.NotBefore || agora > certificado.NotAfter)
            return ValidationError($"O certificado nao esta valido na data atual. Validade: {certificado.NotBefore:dd/MM/yyyy} a {certificado.NotAfter:dd/MM/yyyy}.");

        var documentoCertificado = Command.Receivers.FiscalCertificateResolver.ExtractCnpj(certificado);
        if (documentoCertificado.Length != 14)
            return ValidationError("Nao foi possivel identificar o CNPJ do titular dentro do certificado PFX.");

        if (!MesmaBaseCnpj(documentoCertificado, documentoTitular))
            return ValidationError(
                $"O CNPJ-base do titular informado ({documentoTitular}) nao corresponde ao certificado ({documentoCertificado}).");

        documentoTitular = documentoCertificado;

        var thumbprint = certificado.Thumbprint?.Replace(" ", string.Empty, StringComparison.Ordinal) ?? string.Empty;
        var storage = await Command.Receivers.FiscalPayloadStore.SaveCertificateAsync(
            _executionContext.TenantID,
            documentoTitular,
            thumbprint,
            pfx,
            comand.Senha,
            cancellationToken).ConfigureAwait(false);

        // Para o mesmo titular dentro do tenant, um novo PFX representa
        // substituicao/renovacao do certificado e deve preservar a referencia.
        var existente = existentes
            .OrderByDescending(x => string.Equals(x.thumbprint, thumbprint, StringComparison.OrdinalIgnoreCase))
            .ThenByDescending(x => x.ativo)
            .ThenByDescending(x => x.validoate)
            .FirstOrDefault();

        _unitOfWork.BeginTran();
        try
        {
            int certificadoId;
            var reutilizado = existente is not null;
            if (existente is not null)
            {
                certificadoId = existente.id;
                _repWriteCertificadoDigital.UpdateApelido(certificadoId, Apelido(comand.Apelido, documentoTitular));
                _repWriteCertificadoDigital.UpdateDocumentoTitular(certificadoId, documentoTitular);
                _repWriteCertificadoDigital.UpdateStorageKey(certificadoId, storage.CertificatePath);
                _repWriteCertificadoDigital.UpdateThumbprint(certificadoId, thumbprint);
                _repWriteCertificadoDigital.UpdateSenhaStorageKey(certificadoId, storage.PasswordPath);
                _repWriteCertificadoDigital.UpdateValidoDe(certificadoId, certificado.NotBefore);
                _repWriteCertificadoDigital.UpdateValidoAte(certificadoId, certificado.NotAfter);
                _repWriteCertificadoDigital.UpdateAtivo(certificadoId, 1);
            }
            else
            {
                var entity = new CertificadoDigitalFactory(_logger, _domainTrackingPolicy).Create(
                    null,
                    Apelido(comand.Apelido, documentoTitular),
                    documentoTitular,
                    storage.CertificatePath,
                    thumbprint,
                    certificado.NotBefore,
                    certificado.NotAfter,
                    1,
                    storage.PasswordPath);
                _repWriteCertificadoDigital.Insert(entity);
                certificadoId = entity.Id.GetValueOrDefault();
            }

            if (certificadoId <= 0)
                throw new InvalidOperationException("O certificado foi persistido sem retornar um identificador valido.");

            _repWriteEntradaFiscalContingencia.UpdateCertificadoDigitalId(entrada.id, certificadoId);
            _unitOfWork.Commit();

            return Success("Certificado registrado.", new RegistrarCertificadoDigitalContingenciaOutputCommand
            {
                CertificadoDigitalId = certificadoId,
                DocumentoTitular = documentoTitular,
                Thumbprint = thumbprint,
                ValidoDe = certificado.NotBefore,
                ValidoAte = certificado.NotAfter,
                Reutilizado = reutilizado,
                Mensagem = reutilizado
                    ? "Certificado atualizado e vinculado a contingencia."
                    : "Certificado cadastrado e vinculado a contingencia."
            });
        }
        catch
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}

private static RegistrarCertificadoDigitalContingenciaOutputCommand CriarSaida(
    CertificadoDigitalDTO certificado,
    bool reutilizado,
    string mensagem) => new()
{
    CertificadoDigitalId = certificado.id,
    DocumentoTitular = certificado.documentotitular,
    Thumbprint = certificado.thumbprint,
    ValidoDe = certificado.validode,
    ValidoAte = certificado.validoate,
    Reutilizado = reutilizado,
    Mensagem = mensagem
};

private static string Apelido(string apelido, string documentoTitular) =>
    string.IsNullOrWhiteSpace(apelido) ? $"Certificado {documentoTitular}" : apelido.Trim();

private static string LimparPrefixoBase64(string value)
{
    var separator = value.IndexOf(',');
    return value.StartsWith("data:", StringComparison.OrdinalIgnoreCase) && separator >= 0
        ? value[(separator + 1)..]
        : value;
}

private static string SomenteDigitos(string value) =>
    new(value.Where(char.IsDigit).ToArray());

private static bool MesmaBaseCnpj(string primeiro, string segundo) =>
    primeiro.Length == 14 &&
    segundo.Length == 14 &&
    string.Equals(primeiro[..8], segundo[..8], StringComparison.Ordinal);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
