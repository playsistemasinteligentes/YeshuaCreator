using Comandos.Pateners.Command;
using Dominio.Entitys.Especialidade;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Especialidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertEspecialidadeReceiver : ReciverBase
    {
        private readonly IEspecialidadeWriteRepository _repository;

        public InsertEspecialidadeReceiver(IEspecialidadeWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.EspecialidadeCrudCommand c) 
             {    
                 var especialidade = new EspecialidadeEntity(c.Id, c.Descricao);
                 if (!especialidade.isValidInsert())
                     return ValidationError(especialidade.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(especialidade);
                     return Success("OK", especialidade);
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