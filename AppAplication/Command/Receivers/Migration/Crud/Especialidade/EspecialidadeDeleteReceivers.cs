using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Especialidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteEspecialidadeReceiver : ReciverBase <EspecialidadeEntity>
    {
        private readonly IEspecialidadeWriteRepository _repository;

        public DeleteEspecialidadeReceiver(IEspecialidadeWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<EspecialidadeEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.EspecialidadeCrudCommand c) 
             {    
                 var especialidade = new EspecialidadeEntity(c.Id, c.Descricao);
                 if (!especialidade.isValidDelete())
                     return ValidationError(especialidade.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(especialidade);
                     return Success("OK", especialidade);
                 }
                 catch (Exception e)
                 {
                    return Error(e, especialidade);
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