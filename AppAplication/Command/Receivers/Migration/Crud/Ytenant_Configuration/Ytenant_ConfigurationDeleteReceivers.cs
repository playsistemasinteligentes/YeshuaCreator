using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Ytenant_Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteYtenant_ConfigurationReceiver : ReciverBase <IYtenant_ConfigurationEntity>
    {
        private readonly IYtenant_ConfigurationWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteYtenant_ConfigurationReceiver(IYtenant_ConfigurationWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYtenant_ConfigurationEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Ytenant_ConfigurationCrudCommand c) 
             {    
                 var ytenant_configuration = new Ytenant_ConfigurationFactory(_logger).Create(c.Id, c.AuditTrackerActived, c.AuditCRUDActived, c.TenantID);
                 if (!ytenant_configuration.isValidDelete())
                     return ValidationError(ytenant_configuration.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(ytenant_configuration);
                     return Success("OK", ytenant_configuration);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ytenant_configuration);
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