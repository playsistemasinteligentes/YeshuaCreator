using System.Threading;
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
    public class InsertMDFeReceiver : ReciverBase<ICommand, IMDFeEntity>
    {
        private readonly IMDFeWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertMDFeReceiver(
            IMDFeWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IMDFeEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MDFeCrudCommand c) 
             {    
                 var mdfe = new MDFeFactory(_logger).Create(c.Id, c.ChaveAcesso, c.Serie, c.Numero, c.UfCarregamento, c.UfDescarregamento, c.PlacaVeiculo, c.EmitidoEm, c.AutorizadoEm, c.IniciadoEm, c.EncerradoEm, c.CanceladoEm, c.Situacao);
                 if (!mdfe.isValidInsert())
                     return ValidationError(mdfe.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(mdfe);
                     return Success("OK", mdfe);
                 }
                 catch (Exception e)
                 {
                    return Error(e, mdfe);
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