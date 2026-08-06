using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateMDFeEncerramentoReceiver : ReciverBase<ICommand, IMDFeEncerramentoEntity>
    {
        private readonly IMDFeEncerramentoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateMDFeEncerramentoReceiver(
            IMDFeEncerramentoWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IMDFeEncerramentoEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.MDFeEncerramentoCrudCommand c) 
             {    
                 var mdfeencerramento = new MDFeEncerramentoFactory(_logger).Create(c.Id, c.MDFeId, c.ChaveAcesso, c.UfCarregamento, c.UfDescarregamento, c.PlacaVeiculo, c.SolicitadoEm, c.AutorizadoEm, c.Protocolo, c.CodigoRetorno, c.MensagemRetorno);
                 if (!mdfeencerramento.isValidUpdate())
                     return ValidationError(mdfeencerramento.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(mdfeencerramento);
                     return Success("OK", mdfeencerramento);
                 }
                 catch (Exception e)
                 {
                    return Error(e, mdfeencerramento);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration