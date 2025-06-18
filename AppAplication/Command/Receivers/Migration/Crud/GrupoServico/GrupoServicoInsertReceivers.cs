using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.GrupoServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertGrupoServicoReceiver : ReciverBase <GrupoServicoEntity>
    {
        private readonly IGrupoServicoWriteRepository _repository;

        public InsertGrupoServicoReceiver(IGrupoServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<GrupoServicoEntity> Action(ICommand comand)
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