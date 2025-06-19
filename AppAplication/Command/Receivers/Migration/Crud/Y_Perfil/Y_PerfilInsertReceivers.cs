using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_PerfilReceiver : ReciverBase <Y_PerfilEntity>
    {
        private readonly IY_PerfilWriteRepository _repository;

        public InsertY_PerfilReceiver(IY_PerfilWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_PerfilEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilCrudCommand c) 
             {    
                 var y_perfil = new Y_PerfilEntity(c.Id, c.Description);
                 if (!y_perfil.isValidInsert())
                     return ValidationError(y_perfil.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_perfil);
                     return Success("OK", y_perfil);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_perfil);
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