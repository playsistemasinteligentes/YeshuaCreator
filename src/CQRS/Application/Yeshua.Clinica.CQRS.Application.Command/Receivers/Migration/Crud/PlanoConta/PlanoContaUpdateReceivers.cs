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
    public class UpdatePlanoContaReceiver : ReciverBase<ICommand, IPlanoContaEntity>
    {
        private readonly IPlanoContaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdatePlanoContaReceiver(
            IPlanoContaWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IPlanoContaEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.PlanoContaCrudCommand c) 
             {    
                 var planoconta = new PlanoContaFactory(_logger).Create(c.Id, c.Codigo, c.Nome, c.Tipo);
                 if (!planoconta.isValidUpdate())
                     return ValidationError(planoconta.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(planoconta);
                     return Success("OK", planoconta);
                 }
                 catch (Exception e)
                 {
                    return Error(e, planoconta);
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