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
    public class UpdateServicoReceiver : ReciverBase<ICommand, IServicoEntity>
    {
        private readonly IServicoWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateServicoReceiver(
            IServicoWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IServicoEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.ServicoCrudCommand c) 
             {    
                 var servico = new ServicoFactory(_logger).Create(c.Id, c.GrupoServicoId, c.Nome, c.Valor);
                 if (!servico.isValidUpdate())
                     return ValidationError(servico.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(servico);
                     return Success("OK", servico);
                 }
                 catch (Exception e)
                 {
                    return Error(e, servico);
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