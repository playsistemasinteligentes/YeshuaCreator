using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Especialidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertEspecialidadeReceiver : ReciverBase <IEspecialidadeEntity>
    {
        private readonly IEspecialidadeWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertEspecialidadeReceiver(IEspecialidadeWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IEspecialidadeEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.EspecialidadeCrudCommand c) 
             {    
                 var especialidade = new EspecialidadeFactory(_logger).Create(c.Id, c.Descricao);
                 if (!especialidade.isValidInsert())
                     return ValidationError(especialidade.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(especialidade);
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