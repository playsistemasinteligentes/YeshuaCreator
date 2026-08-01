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
    public class InsertEspecialidadeReceiver : ReciverBase<ICommand, IEspecialidadeEntity>
    {
        private readonly IEspecialidadeWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertEspecialidadeReceiver(
            IEspecialidadeWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IEspecialidadeEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.EspecialidadeCrudCommand c) 
             {    
                 var especialidade = new EspecialidadeFactory(_logger).Create(c.Id, c.Descricao);
                 if (!especialidade.isValidInsert())
                     return ValidationError(especialidade.getErroMensagens(), null);

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