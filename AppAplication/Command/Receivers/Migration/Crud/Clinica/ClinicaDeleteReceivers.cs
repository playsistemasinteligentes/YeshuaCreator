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
    public class DeleteClinicaReceiver : ReciverBase<ICommand, IClinicaEntity>
    {
        private readonly IClinicaWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteClinicaReceiver(IClinicaWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IClinicaEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.ClinicaCrudCommand c) 
             {    
                 var clinica = new ClinicaFactory(_logger).Create(c.Id, c.Nome, c.Endereco, c.Telefone);
                 if (!clinica.isValidDelete())
                     return ValidationError(clinica.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(clinica);
                     return Success("OK", clinica);
                 }
                 catch (Exception e)
                 {
                    return Error(e, clinica);
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