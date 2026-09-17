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
using Repositorio.Outputs;
using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace Command.Receivers.UseCase
{
    public partial class BaixarPacoteContingenciaFiscalHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeRepository = default!;
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioRepository = default!;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoRepository = default!;
        private readonly ICTeTentativaEmissaoReadRepository _cteTentativaRepository = default!;
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoRepository = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _mdfeTentativaRepository = default!;
        private readonly IDocumentoFiscalReadRepository _documentoFiscalRepository = default!;

        public BaixarPacoteContingenciaFiscalHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia,
            IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia,
            INFeProdutoSnapshotReadRepository nfeRepository,
            ICTeRomaneioConsolidadoReadRepository cteRomaneioRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoRepository,
            ICTeTentativaEmissaoReadRepository cteTentativaRepository,
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoRepository,
            IMDFeTentativaEmissaoReadRepository mdfeTentativaRepository,
            IDocumentoFiscalReadRepository documentoFiscalRepository)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadEntradaFiscalContingencia = repReadEntradaFiscalContingencia;
            _repWriteEntradaFiscalContingencia = repWriteEntradaFiscalContingencia;
            _nfeRepository = nfeRepository;
            _cteRomaneioRepository = cteRomaneioRepository;
            _cteSolicitacaoRepository = cteSolicitacaoRepository;
            _cteTentativaRepository = cteTentativaRepository;
            _mdfeSolicitacaoRepository = mdfeSolicitacaoRepository;
            _mdfeTentativaRepository = mdfeTentativaRepository;
            _documentoFiscalRepository = documentoFiscalRepository;
        }
protected partial Task<State<BaixarPacoteContingenciaFiscalOutputCommand>> CustomActionHookAsync(State<BaixarPacoteContingenciaFiscalOutputCommand> state, BaixarPacoteContingenciaFiscalInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        if (comand.EntradaFiscalContingenciaId <= 0)
            return Task.FromResult(ValidationError("Informe o protocolo da contingencia fiscal."));

        var entrada = _repReadEntradaFiscalContingencia.FirstById(comand.EntradaFiscalContingenciaId);
        if (entrada == null || entrada.id <= 0)
            return Task.FromResult(ValidationError("Contingencia fiscal nao encontrada."));
        if (entrada.status != 6)
            return Task.FromResult(ValidationError("A emissao fiscal ainda nao foi concluida."));

        var notas = (_nfeRepository.GetAllByCargaId(entrada.cargaid) ?? Array.Empty<NFeProdutoSnapshotDTO>())
            .Where(item => !string.IsNullOrWhiteSpace(item.xmlstoragekey))
            .OrderBy(item => item.id)
            .ToArray();
        var ctes = CarregarCTesAutorizados(entrada.cargaid);
        var mdfes = CarregarMDFesAutorizados(entrada.cargaid);
        if (ctes.Length == 0 || mdfes.Length == 0)
            return Task.FromResult(ValidationError("CT-e e MDF-e autorizados ainda nao estao disponiveis."));

        using var stream = new MemoryStream();
        var quantidade = 0;
        using (var zip = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true))
        {
            foreach (var nota in notas)
            {
                if (!File.Exists(nota.xmlstoragekey))
                    continue;

                AdicionarArquivo(zip, $"NFe/XML/{nota.chaveacesso}-nfe.xml", File.ReadAllBytes(nota.xmlstoragekey));
                quantidade++;
            }

            foreach (var cte in ctes)
            {
                var xml = DocumentoFiscalUtilitarios.CarregarCTe(cte.chaveacesso, _cteTentativaRepository, _documentoFiscalRepository);
                AdicionarArquivo(zip, $"CTe/XML/{cte.chaveacesso}-procCTe.xml", Encoding.UTF8.GetBytes(xml.Xml));
                quantidade++;

                var dacte = DocumentoFiscalUtilitarios.GerarDactes(new[] { cte.chaveacesso }, _cteTentativaRepository, _documentoFiscalRepository);
                AdicionarArquivo(zip, $"CTe/DACTE/{dacte.NomeArquivo}", dacte.Conteudo);
                quantidade++;
            }

            foreach (var mdfe in mdfes)
            {
                var xml = DocumentoFiscalUtilitarios.CarregarMDFe(mdfe.chaveacesso, _mdfeTentativaRepository, _documentoFiscalRepository);
                AdicionarArquivo(zip, $"MDFe/XML/{mdfe.chaveacesso}-procMDFe.xml", Encoding.UTF8.GetBytes(xml.Xml));
                quantidade++;

                var damdfe = DocumentoFiscalUtilitarios.GerarDamdfe(new[] { mdfe.chaveacesso }, _mdfeTentativaRepository, _documentoFiscalRepository);
                AdicionarArquivo(zip, $"MDFe/DAMDFE/{damdfe.NomeArquivo}", damdfe.Conteudo);
                quantidade++;
            }

            var manifesto = JsonSerializer.SerializeToUtf8Bytes(new
            {
                protocolo = entrada.id,
                cargaId = entrada.cargaid,
                geradoEmUtc = DateTime.UtcNow,
                notasFiscais = notas.Select(item => item.chaveacesso),
                ctes = ctes.Select(item => new { item.chaveacesso, item.protocoloautorizacao }),
                mdfes = mdfes.Select(item => new { item.chaveacesso, item.protocoloautorizacao })
            }, new JsonSerializerOptions { WriteIndented = true });
            AdicionarArquivo(zip, "manifesto.json", manifesto);
            quantidade++;
        }

        var output = new BaixarPacoteContingenciaFiscalOutputCommand
        {
            NomeArquivo = $"contingencia-{entrada.id}-{entrada.cargaid}.zip",
            ContentType = "application/zip",
            ArquivoBase64 = Convert.ToBase64String(stream.ToArray()),
            QuantidadeArquivos = quantidade
        };

        return Task.FromResult(Success("Pacote fiscal gerado.", output));
    }
    catch (Exception exception) when (exception is ArgumentException or InvalidOperationException or IOException)
    {
        return Task.FromResult(ValidationError(exception.Message));
    }
}

        private CTeTentativaEmissaoDTO[] CarregarCTesAutorizados(string cargaId)
        {
            var romaneio = _cteRomaneioRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                return Array.Empty<CTeTentativaEmissaoDTO>();

            return (_cteSolicitacaoRepository.GetAllByRomaneioConsolidadoId(romaneio.id) ?? Array.Empty<CTeSolicitacaoFiscalDTO>())
                .Select(solicitacao => (_cteTentativaRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id) ?? Array.Empty<CTeTentativaEmissaoDTO>())
                    .Where(item => item.status == 3)
                    .OrderByDescending(item => item.id)
                    .FirstOrDefault())
                .Where(item => item != null)
                .Cast<CTeTentativaEmissaoDTO>()
                .ToArray();
        }

        private MDFeTentativaEmissaoDTO[] CarregarMDFesAutorizados(string cargaId)
        {
            return (_mdfeSolicitacaoRepository.GetAllByCargaId(cargaId) ?? Array.Empty<MDFeSolicitacaoFiscalDTO>())
                .Select(solicitacao => (_mdfeTentativaRepository.GetAllByMDFeSolicitacaoFiscalId(solicitacao.id) ?? Array.Empty<MDFeTentativaEmissaoDTO>())
                    .Where(item => item.status == 3)
                    .OrderByDescending(item => item.id)
                    .FirstOrDefault())
                .Where(item => item != null)
                .Cast<MDFeTentativaEmissaoDTO>()
                .ToArray();
        }

        private static void AdicionarArquivo(ZipArchive zip, string nome, byte[] conteudo)
        {
            var entry = zip.CreateEntry(nome, CompressionLevel.Fastest);
            using var entryStream = entry.Open();
            entryStream.Write(conteudo);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
