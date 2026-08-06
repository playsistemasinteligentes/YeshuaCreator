using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entitys.Custon.Sesoes
{
    public interface ISessaoRule
    {
        void Apply(SesoesEntity sessao);
    }

    public class EmConciliacaoDeHorariosRule : ISessaoRule
    {
        public void Apply(SesoesEntity sessao)
        {
            // Define status como EmConciliacaoDeHorarios
            sessao.StatusAgendamento = 0;

            // Opcional: zera datas se necessário
            if (sessao.DataInicio != null && sessao.DataFim != null)
            {
                //sessao.DataInicio = null;
                //sessao.DataFim = null;
            }

            // Aqui você pode adicionar ações extras, ex: log ou notificação
        }
    }

    public class ConfirmadaRule : ISessaoRule
    {
        public void Apply(SesoesEntity sessao)
        {
            sessao.StatusAgendamento = 1;

            // Garantir que as datas estejam preenchidas
            if (sessao.DataInicio == null)
                throw new InvalidOperationException("Não é possível confirmar sem Data Início.");

            if (sessao.DataFim == null)
                throw new InvalidOperationException("Não é possível confirmar sem Data Fim.");

            // Notificação de confirmação poderia ser chamada aqui
        }
    }

    public class RealizadaRule : ISessaoRule
    {
        public void Apply(SesoesEntity sessao)
        {
            sessao.StatusAgendamento = 2;

            // Exemplo: marcar como finalizada
            // Poderia disparar geração de relatório ou registro financeiro
        }
    }

    public class CanceladaRule : ISessaoRule
    {
        public void Apply(SesoesEntity sessao)
        {
            sessao.StatusAgendamento = 3;

            // Exemplo: limpar datas ou enviar notificação
            // sessao.DataInicio = null;
            //sessao.DataFim = null;

            // Notificação de cancelamento
        }
    }
}
