using Comandos.Pateners.Command;
using Dominio.Entitys.Clinica;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Clinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertClinicaReceiver : ReciverBase
    {
        private readonly IClinicaWriteRepository _repository;

        public InsertClinicaReceiver(IClinicaWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.ClinicaCrudCommand c) 
             {    
                 var clinica = new ClinicaEntity(c.Id, c.Nome, c.Endereco, c.Telefone);
                 if (!clinica.isValidInsert())
                     return ValidationError(clinica.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(clinica);
                     return Success("OK", clinica);
                 }
                 catch (Exception e)
                 {
                     return Error(e, comand);
                 }
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration