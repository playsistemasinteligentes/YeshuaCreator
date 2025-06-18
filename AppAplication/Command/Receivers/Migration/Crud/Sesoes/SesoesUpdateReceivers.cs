using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Sesoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateSesoesReceiver : ReciverBase <SesoesEntity>
    {
        private readonly ISesoesWriteRepository _repository;

        public UpdateSesoesReceiver(ISesoesWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<SesoesEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.SesoesCrudCommand c) 
             {    
                 var sesoes = new SesoesEntity(c.Id, c.PacienteId, c.ProfissionalId, c.ServicoId, c.DataInicio, c.DataFim, c.Status, c.MovimentacaoFinanceiraId, c.SinteseProntuario, c.QueixaPrincipal, c.MotivoConsultaAtual, c.SintomasRelatados, c.MudancasDesdeUltimaSessaao, c.ComportamentoObservado, c.EstadoEmocionalGeral, c.DiscursoPensamentos, c.TecnicasUtilizadas, c.QuestionamentosReflexoesAbordadas, c.ExerciciosTarefasSugeridas, c.DiagnoosticoHipoteseDiagnoostica, c.ObjetivosCurtoPrazo, c.ObjetivosLongoPrazo, c.FrequenciaSugeridaSessooes, c.EncaminhamentoOutrosProfissionais, c.InformacoesRelevantesFuturasConsultas, c.FeedbackPacienteSobreProcessoTerapeeutico);
                 if (!sesoes.isValidUpdate())
                     return ValidationError(sesoes.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(sesoes);
                     return Success("OK", sesoes);
                 }
                 catch (Exception e)
                 {
                    return Error(e, sesoes);
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