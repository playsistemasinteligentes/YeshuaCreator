// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using Repositorio.Outputs;
using System;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class AutorizarMDFeNaSefazHandler
    {
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly IyInboxReadRepository _inboxReadRepository;
        private readonly IDocumentoFiscalWriteRepository _documentoFiscalWriteRepository;
        private readonly ILogger _logger;

        public AutorizarMDFeNaSefazHandler(
            IyInboxWriteRepository inboxWriteRepository,
            IyInboxReadRepository inboxReadRepository,
            IDocumentoFiscalWriteRepository documentoFiscalWriteRepository,
            ILogger logger)
        {
            _inboxWriteRepository = inboxWriteRepository;
            _inboxReadRepository = inboxReadRepository;
            _documentoFiscalWriteRepository = documentoFiscalWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cte = TryGetCteAutorizadoDaSaga(saga);

            try
            {
                var result = MdfeRecepcaoSincHomologacaoClient.Autorizar(cte?.Chave ?? string.Empty);
                var respostaEstruturada = result.CodigoRetorno > 0 && !string.IsNullOrWhiteSpace(result.Motivo);

                if (!respostaEstruturada)
                {
                    var exception = new InvalidOperationException(
                        $"SEFAZ MDF-e nao retornou resposta fiscal estruturada. HTTP={result.HttpStatusCode}; chave={result.Chave}");

                    _logger.CommandFailed(
                        "Fiscal.MDFe.AutorizarMDFeNaSefaz.SemRespostaFiscalEstruturada",
                        step.CorrelationId,
                        exception,
                        0);
                }

                if (respostaEstruturada && !result.Autorizado)
                {
                    var rejection = new InvalidOperationException(
                        $"SEFAZ MDF-e rejeitou em homologacao. cStat={result.CodigoRetorno}; xMotivo={result.Motivo}; chave={result.Chave}");

                    _logger.CommandFailed(
                        "Fiscal.MDFe.AutorizarMDFeNaSefaz.RejeicaoFiscal",
                        step.CorrelationId,
                        rejection,
                        0);
                }

                SefazFiscalDocumentStore.PersistirMDFe(
                    _documentoFiscalWriteRepository,
                    _logger,
                    saga,
                    step,
                    result);

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.mdfe.resposta-sefaz-homologacao",
                    new
                    {
                        origem = "Fiscal",
                        modo = "sefaz-homologacao",
                        autorizado = result.Autorizado,
                        erroTecnico = false,
                        respostaFiscalEstruturada = respostaEstruturada,
                        cStat = result.CodigoRetorno,
                        xMotivo = result.Motivo,
                        chave = result.Chave,
                        chaveCTe = cte?.Chave ?? string.Empty,
                        protocolo = result.Protocolo,
                        httpStatusCode = result.HttpStatusCode,
                        entityId = saga.EntityId
                    }));
            }
            catch (Exception ex)
            {
                _logger.CommandFailed(
                    "Fiscal.MDFe.AutorizarMDFeNaSefaz.ErroTecnico",
                    step.CorrelationId,
                    ex,
                    0);

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.mdfe.resposta-sefaz-homologacao",
                    new
                    {
                        origem = "Fiscal",
                        modo = "sefaz-homologacao",
                        autorizado = false,
                        erroTecnico = true,
                        respostaFiscalEstruturada = false,
                        cStat = 0,
                        xMotivo = ex.InnerException == null
                            ? ex.Message
                            : ex.Message + " | inner: " + ex.InnerException.Message,
                        chave = string.Empty,
                        chaveCTe = cte?.Chave ?? string.Empty,
                        protocolo = string.Empty,
                        httpStatusCode = 0,
                        exceptionType = ex.GetType().FullName,
                        entityId = saga.EntityId
                    }));
            }
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: resposta MDF-e SEFAZ homologacao registrada.");
        }

        private CteAutorizado? TryGetCteAutorizadoDaSaga(SagaBase saga)
        {
            var command = new global::Command.Read.yInboxReadCommand
            {
                Type = "fiscal.cte.resposta-sefaz-homologacao",
                SagaId = saga.Id == 0 ? null : saga.Id,
                Paginacao = new Pagination(1, 50)
            };

            var registros = _inboxReadRepository.getyInbox(command, true).Items
                .OrderByDescending(item => item.createdat);

            foreach (var registro in registros)
            {
                var cte = TryReadCteAutorizado(registro);
                if (cte is not null)
                    return cte;
            }

            return null;
        }

        private static CteAutorizado? TryReadCteAutorizado(yInboxDTO registro)
        {
            if (string.IsNullOrWhiteSpace(registro.payload))
                return null;

            try
            {
                using var doc = JsonDocument.Parse(registro.payload);
                if (!doc.RootElement.TryGetProperty("data", out var data))
                    return null;

                if (!ReadBoolean(data, "autorizado") || ReadBoolean(data, "erroTecnico"))
                    return null;

                var chave = ReadString(data, "chave");
                if (string.IsNullOrWhiteSpace(chave) || chave.Length != 44)
                    return null;

                return new CteAutorizado(chave, ReadString(data, "protocolo"));
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private static bool ReadBoolean(JsonElement data, string propertyName)
        {
            return data.TryGetProperty(propertyName, out var value) &&
                value.ValueKind == JsonValueKind.True;
        }

        private static string ReadString(JsonElement data, string propertyName)
        {
            return data.TryGetProperty(propertyName, out var value) && value.ValueKind == JsonValueKind.String
                ? value.GetString() ?? string.Empty
                : string.Empty;
        }

        private sealed record CteAutorizado(string Chave, string Protocolo);
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
