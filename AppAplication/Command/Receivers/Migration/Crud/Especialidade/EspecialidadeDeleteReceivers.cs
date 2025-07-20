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
    public class DeleteEspecialidadeReceiver : ReciverBase <IEspecialidadeEntity>
    {
        private readonly IEspecialidadeWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteEspecialidadeReceiver(IEspecialidadeWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IEspecialidadeEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.EspecialidadeCrudCommand c) 
             {    
                 var especialidade = new EspecialidadeFactory(_logger).Create(c.Id, c.Descricao);
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