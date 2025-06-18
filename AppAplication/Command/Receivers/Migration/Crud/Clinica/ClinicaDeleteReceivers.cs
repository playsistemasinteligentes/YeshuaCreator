using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Clinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteClinicaReceiver : ReciverBase <ClinicaEntity>
    {
        private readonly IClinicaWriteRepository _repository;

        public DeleteClinicaReceiver(IClinicaWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<ClinicaEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.ClinicaCrudCommand c) 
             {    
                 var clinica = new ClinicaEntity(c.Id, c.Nome, c.Endereco, c.Telefone);
                 if (!clinica.isValidDelete())
                     return ValidationError(clinica.getErroMensagens(), comand);

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