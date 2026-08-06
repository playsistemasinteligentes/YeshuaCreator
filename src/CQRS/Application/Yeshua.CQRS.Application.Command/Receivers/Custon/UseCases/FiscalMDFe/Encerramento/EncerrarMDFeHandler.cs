using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Reflection;

namespace Command.Receivers.UseCase
{
    public partial class EncerrarMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMDFeReadRepository _repReadMDFe;
        private readonly IMDFeWriteRepository _repWriteMDFe;
        private readonly IMDFeEncerramentoWriteRepository _repWriteMDFeEncerramento;

        public EncerrarMDFeHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext context,
            IMDFeReadRepository repReadMDFe,
            IMDFeWriteRepository repWriteMDFe,
            IMDFeEncerramentoWriteRepository repWriteMDFeEncerramento)
            : base(logger, context)
        {
            _unitOfWork = unitOfWork;
            _repReadMDFe = repReadMDFe;
            _repWriteMDFe = repWriteMDFe;
            _repWriteMDFeEncerramento = repWriteMDFeEncerramento;
            _logger = logger;
            _executionContext = context;
        }

        partial void CustomActionHook(ref State<EncerrarMDFeOutputCommand> state, EncerrarMDFeInputCommand comand)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comand.ChaveAcesso))
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(ValidationError("Chave de acesso e obrigatoria.", default));

                if (string.IsNullOrWhiteSpace(comand.UfCarregamento))
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(ValidationError("UF de carregamento e obrigatoria.", default));

                if (string.IsNullOrWhiteSpace(comand.UfDescarregamento))
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(ValidationError("UF de descarregamento e obrigatoria.", default));

                if (string.IsNullOrWhiteSpace(comand.PlacaVeiculo))
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(ValidationError("Placa do veiculo e obrigatoria.", default));

                var mdfe = _repReadMDFe.FirstByChaveAcesso(comand.ChaveAcesso);
                if (mdfe is null || mdfe.id <= 0)
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(Error("MDF-e nao encontrado.", default));

                if (HasMeaningfulDate(mdfe.canceladoem))
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(Error("MDF-e ja esta cancelado.", default));

                if (HasMeaningfulDate(mdfe.encerradoem) || mdfe.situacao == 3)
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(Error("MDF-e ja esta encerrado.", default));

                if (mdfe.situacao != 2)
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(Error("MDF-e precisa estar em transporte para encerrar.", default));

                var now = DateTime.UtcNow;
                var protocolo = BuildMockProtocol(mdfe.chaveacesso, now);
                var retornoCodigo = "100";
                var retornoMensagem = "Encerramento registrado em modo local.";

                var encerramento = CreateEncerramentoEntity(
                    mdfe.id,
                    mdfe.chaveacesso,
                    NormalizeUf(comand.UfCarregamento),
                    NormalizeUf(comand.UfDescarregamento),
                    NormalizePlaca(comand.PlacaVeiculo),
                    now,
                    now,
                    protocolo,
                    retornoCodigo,
                    retornoMensagem);

                if (!encerramento.isValidInsert())
                    throw new ReceiverException<EncerrarMDFeOutputCommand>(
                        ValidationError(string.Join("; ", encerramento.getErroMensagens()), default));

                _unitOfWork.BeginTran();

                _repWriteMDFeEncerramento.Insert(encerramento);
                _repWriteMDFe.UpdateEncerradoEm(mdfe.id, now);
                _repWriteMDFe.UpdateSituacao(mdfe.id, 3);
                _repWriteMDFe.UpdateChanged(mdfe.id, now);

                if (_executionContext.UserId > 0)
                    _repWriteMDFe.UpdateUserId(mdfe.id, _executionContext.UserId);

                _unitOfWork.Commit();

                state = Success("Encerramento do MDF-e concluido.", new EncerrarMDFeOutputCommand
                {
                    ChaveAcesso = mdfe.chaveacesso,
                    Encerrado = true,
                    Protocolo = protocolo,
                    Mensagem = retornoMensagem,
                    EncerradoEm = now
                });
            }
            catch (ReceiverException<EncerrarMDFeOutputCommand>)
            {
                _unitOfWork.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ReceiverException<EncerrarMDFeOutputCommand>(Error(ex, default));
            }
        }

        private static string NormalizeUf(string value)
        {
            return value.Trim().ToUpperInvariant();
        }

        private static string NormalizePlaca(string value)
        {
            return new string(value
                .Trim()
                .ToUpperInvariant()
                .Where(char.IsLetterOrDigit)
                .ToArray());
        }

        private static string BuildMockProtocol(string chaveAcesso, DateTime momento)
        {
            var suffix = momento.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            var lastDigits = chaveAcesso.Length <= 8 ? chaveAcesso : chaveAcesso[^8..];
            return $"MDFE-ENC-{suffix}-{lastDigits}";
        }

        private static bool HasMeaningfulDate(DateTime value)
        {
            return value > new DateTime(1800, 1, 1);
        }

        private static MDFeEncerramentoEntity CreateEncerramentoEntity(
            int mdfeId,
            string chaveAcesso,
            string ufCarregamento,
            string ufDescarregamento,
            string placaVeiculo,
            DateTime solicitadoEm,
            DateTime? autorizadoEm,
            string protocolo,
            string codigoRetorno,
            string mensagemRetorno)
        {
            return (MDFeEncerramentoEntity)Activator.CreateInstance(
                typeof(MDFeEncerramentoEntity),
                BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                args: new object?[]
                {
                    null,
                    mdfeId,
                    chaveAcesso,
                    ufCarregamento,
                    ufDescarregamento,
                    placaVeiculo,
                    solicitadoEm,
                    autorizadoEm,
                    protocolo,
                    codigoRetorno,
                    mensagemRetorno
                },
                culture: null)!;
        }
    }
}
