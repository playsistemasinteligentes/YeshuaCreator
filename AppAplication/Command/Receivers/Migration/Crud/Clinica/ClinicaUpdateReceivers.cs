using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Clinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateClinicaReceiver : ReciverBase <IClinicaEntity>
    {
        private readonly IClinicaWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateClinicaReceiver(IClinicaWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IClinicaEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.ClinicaCrudCommand c) 
             {    
                 var clinica = new ClinicaFactory(_logger).Create(c.Id, c.Nome, c.Endereco, c.Telefone);
                 if (!clinica.isValidUpdate())
                     return ValidationError(clinica.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(clinica);
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