using Clinica.Atendimentos;
using Clinica.Modelos;
namespace Command.Receivers.UseCase;
public static class AtendimentoRules
{
    public static void Validate(RegistroAtendimentoInfo s,int version,string action,RegistroInput? r=null)
    {
        if(s.Versao!=version)throw new AtendimentoException("O atendimento mudou em outra tela. Atualize antes de continuar.",409);
        var modelo=ModelosConsulta.Efetivo(s.ModeloConsulta);
        if(!ModelosConsulta.Suporta(modelo,ModelosConsulta.VersaoEfetiva(s.VersaoModeloConsulta)))
            throw new AtendimentoException("O modelo desta consulta não está disponível nesta versão. Atualize o aplicativo antes de continuar.",409);
        // Consultas legadas realizadas podem ser revisadas sem inventar horários reais.
        bool started=s.AtendimentoIniciadoEm.Length>0 || s.StatusAgendamento==2,ended=s.AtendimentoEncerradoEm.Length>0 || s.StatusAgendamento==2,final=s.RegistroFinalizadoEm.Length>0 || s.StatusProntuario==3;
        if(action=="corrigir")
        {
            if(!final || r is null || !r.Revisado || string.IsNullOrWhiteSpace(r.Motivo))throw new AtendimentoException("A correção exige registro concluído, motivo e revisão explícita.");
        }
        else if(final)throw new AtendimentoException("O registro já está concluído. Use a correção com motivo.",409);
        if(action is "iniciar" or "cancelar" or "falta")
        { if(started || s.StatusAgendamento is not (0 or 1))throw new AtendimentoException("Essa ação exige um agendamento ainda não iniciado."); }
        if(action=="encerrar" && (!started || ended))throw new AtendimentoException("O atendimento precisa estar em andamento.");
        if(action is "salvar" or "finalizar" or "corrigir")
        {
            if(action!="corrigir" && (!started || s.StatusAgendamento is 3 or 4))throw new AtendimentoException("Inicie o atendimento antes de registrar.");
            if(r is null)throw new AtendimentoException("Registro ausente.");
            if(modelo==ModelosConsulta.RegistroSimplificado &&
                (r.QueixaPrincipal.Length>0 || r.RegistroDocumental.Length>0 || r.ObjetivosCurtoPrazo.Length>0 || r.ObjetivosLongoPrazo.Length>0 ||
                 r.ExerciciosTarefasSugeridas.Length>0 || r.EncaminhamentoOutrosProfissionais.Length>0 || r.FrequenciaSugeridaSessooes.Length>0))
                throw new AtendimentoException("O registro simplificado utiliza somente registro da sessão e próximos passos.");
            if(r.Prontuario.Length>8000 || r.RegistroDocumental.Length>8000 || r.QueixaPrincipal.Length>1000 || r.ObjetivosCurtoPrazo.Length>1000 || r.ObjetivosLongoPrazo.Length>1000 || r.ExerciciosTarefasSugeridas.Length>1000 || r.EncaminhamentoOutrosProfissionais.Length>1000 || r.FrequenciaSugeridaSessooes.Length>1000 || r.InformacoesRelevantesFuturasConsultas.Length>1000 || r.Motivo.Length>1000)
                throw new AtendimentoException("Um dos campos ultrapassa o tamanho permitido.");
            if(action is "finalizar" or "corrigir")
            { if((!ended && action!="corrigir") || !r.Revisado || string.IsNullOrWhiteSpace(r.Prontuario) ||
                    (modelo==ModelosConsulta.PsicologiaCompleta && string.IsNullOrWhiteSpace(r.RegistroDocumental)))
                    throw new AtendimentoException(modelo==ModelosConsulta.RegistroSimplificado
                        ?"Encerre o atendimento, preencha o registro da sessão e confirme a revisão para finalizar."
                        :"Encerre o atendimento, revise e preencha prontuário e registro documental para finalizar."); }
        }
    }
}
