using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Perfil;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteY_PerfilReceiver : ReciverBase
    {
        private readonly IY_PerfilWriteRepository _repository;

        public DeleteY_PerfilReceiver(IY_PerfilWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilCrudCommand c) 
             {    
                 var y_perfil = new Y_PerfilEntity(c.Id, c.Description);
                 if (!y_perfil.isValidDelete())
                     return ValidationError(y_perfil.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(y_perfil);
                     return Success("OK", y_perfil);
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