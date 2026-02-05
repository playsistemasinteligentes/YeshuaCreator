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
    public class DeletePlanoContaReceiver : ReciverBase <IPlanoContaEntity>
    {
        private readonly IPlanoContaWriteRepository _repository;
        private readonly ILogger _logger;

        public DeletePlanoContaReceiver(IPlanoContaWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IPlanoContaEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.PlanoContaCrudCommand c) 
             {    
                 var planoconta = new PlanoContaFactory(_logger).Create(c.Id, c.Codigo, c.Nome, c.Tipo, c.ContaPaiId);
                 if (!planoconta.isValidDelete())
                     return ValidationError(planoconta.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(planoconta);
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