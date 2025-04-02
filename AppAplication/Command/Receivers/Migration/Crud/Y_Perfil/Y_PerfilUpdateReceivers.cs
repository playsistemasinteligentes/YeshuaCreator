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
    public class UpdateY_PerfilReceiver : ReciverBase
    {
        private readonly IY_PerfilWriteRepository _repository;

        public UpdateY_PerfilReceiver(IY_PerfilWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilCrudCommand c) 
             {    
                 var y_perfil = new Y_PerfilEntity(c.Id, c.Description);
                 if (!y_perfil.isValidUpdate())
                     return new State(300, y_perfil.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(y_perfil);
                     return new State(200, "OK", y_perfil);
                 }
                 catch (Exception e)
                 {
                     return new State(500, e, comand);
                 }
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration