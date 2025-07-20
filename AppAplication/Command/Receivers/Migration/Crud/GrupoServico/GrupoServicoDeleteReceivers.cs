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
    public class DeleteGrupoServicoReceiver : ReciverBase <IGrupoServicoEntity>
    {
        private readonly IGrupoServicoWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteGrupoServicoReceiver(IGrupoServicoWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IGrupoServicoEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.GrupoServicoCrudCommand c) 
             {    
                 var gruposervico = new GrupoServicoFactory(_logger).Create(c.Id, c.Descricao);
                 if (!gruposervico.isValidDelete())
                     return ValidationError(gruposervico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(gruposervico);
                     return Success("OK", gruposervico);
                 }
                 catch (Exception e)
                 {
                    return Error(e, gruposervico);
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