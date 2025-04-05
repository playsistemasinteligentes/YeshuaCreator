using Comandos.Pateners.Command;
using Dominio.Entitys.Y_PerfilPermitions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_PerfilPermitionsReceiver : ReciverBase
    {
        private readonly IY_PerfilPermitionsWriteRepository _repository;

        public InsertY_PerfilPermitionsReceiver(IY_PerfilPermitionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilPermitionsCrudCommand c) 
             {    
                 var y_perfilpermitions = new Y_PerfilPermitionsEntity(c.PerfilId, c.PermitionsId);
                 if (!y_perfilpermitions.isValidInsert())
                     return ValidationError(y_perfilpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_perfilpermitions);
                     return Success("OK", y_perfilpermitions);
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