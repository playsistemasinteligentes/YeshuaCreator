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
    public class InsertDisponibilidadeAgendaReceiver : ReciverBase<ICommand, IDisponibilidadeAgendaEntity>
    {
        private readonly IDisponibilidadeAgendaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertDisponibilidadeAgendaReceiver(
            IDisponibilidadeAgendaWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IDisponibilidadeAgendaEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.DisponibilidadeAgendaCrudCommand c) 
             {    
                 var disponibilidadeagenda = new DisponibilidadeAgendaFactory(_logger).Create(c.Id, c.ProfissionalId, c.DataHora);
                 if (!disponibilidadeagenda.isValidInsert())
                     return ValidationError(disponibilidadeagenda.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(disponibilidadeagenda);
                     return Success("OK", disponibilidadeagenda);
                 }
                 catch (Exception e)
                 {
                    return Error(e, disponibilidadeagenda);
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