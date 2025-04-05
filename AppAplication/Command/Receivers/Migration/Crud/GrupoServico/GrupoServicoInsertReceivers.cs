using Comandos.Pateners.Command;
using Dominio.Entitys.GrupoServico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.GrupoServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertGrupoServicoReceiver : ReciverBase
    {
        private readonly IGrupoServicoWriteRepository _repository;

        public InsertGrupoServicoReceiver(IGrupoServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.GrupoServicoCrudCommand c) 
             {    
                 var gruposervico = new GrupoServicoEntity(c.Id, c.Descricao);
                 if (!gruposervico.isValidInsert())
                     return ValidationError(gruposervico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(gruposervico);
                     return Success("OK", gruposervico);
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