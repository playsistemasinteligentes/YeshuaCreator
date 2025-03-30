using Dominio.Migration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AppClinicas
{

    namespace Migrations
    {

        [Migration(000001)]
        public class M000001 : MigrationBase
        {
            public override void Up()
            {
                AddEntity("Clinica")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("Nome", "Nome da Clínica").Varchar(150).NotNull()
                .AddColumn("Endereco", "Endereço da Clínica").Varchar(250).NotNull()
                .AddColumn("Telefone", "Telefone de Contato").Varchar(20).NotNull();
            }
        }
    }



    [Migration(000002)]
    public class M000002 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("Especialidade")
                    .AddColumn("Id", "ID").Int().Incremento().Key()
                    .AddColumn("Descricao", "Descrição da Especialidade").Varchar(100).NotNull();

            AddEntity("Profissional")
                 .AddColumn("Id", "ID").Int().Incremento().Key()
                 .AddColumn("Nome", "Nome do Profissional").Varchar(150).NotNull()
                 .AddColumn("EspecialidadeId", "Especialidade do Profissional").FK("Especialidade", "Id").Int()
                 .AddColumn("Telefone", "Telefone do Profissional").Varchar(20).NotNull();

            AddEntity("DisponibilidadeAgenda")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("ProfissionalId", "Profissional").FK("Profissional", "Id").Int()
                .AddColumn("DataHora", "Horário Disponível").DateTime().NotNull();

            // recursos 

            AddEntity("GrupoServico")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("Descricao", "Descrição do Grupo de Serviços").Varchar(150).NotNull();

            AddEntity("Servico")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("GrupoServicoId", "Grupo de Serviço").FK("GrupoServico", "Id").Int()
                .AddColumn("Nome", "Nome do Serviço").Varchar(150).NotNull()
                .AddColumn("Valor", "Valor do Serviço").Decimal(10, 2).NotNull();

            AddEntity("Paciente")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("Nome", "Nome do Paciente").Varchar(150).NotNull()
                .AddColumn("Telefone", "Telefone de Contato").Varchar(20).NotNull()
                .AddColumn("DataNascimento", "Data Nascimento").DateTime()

                .AddColumn("Genero", "Gênero").Int()
                    .Enumerable(1, "Mascolino")
                    .Enumerable(2, "Feminino")
                    .Enumerable(3, "Outros")
                .AddColumn("Escolaridade", "Escolaridade").Varchar(60)
                .AddColumn("Profissao", "Profissão").Varchar(60)
                .AddColumn("Endereco", "Endereço").Varchar(250)
                .AddColumn("NomeResponsavel", "Nome Responsavel").Varchar(250)
                .AddColumn("TelefoneResponsavel", "Telefone Responsavel").Varchar(15)
                .AddColumn("PrincipaisQueixas", "PrincipaisQueixas").Varchar(4000)
                .AddColumn("ObservacaoAdicional", "ObservacaoAdicional").Varchar(2000);

            AddEntity("MovimentacaoFinanceira")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("PacienteId", "Paciente").FK("Paciente", "Id").Int()
                .AddColumn("ServicoId", "Serviço").FK("Servico", "Id").Int()
                .AddColumn("Valor", "Valor da Transação").Decimal(10, 2).NotNull()
                .AddColumn("TipoMovimentacao", "Tipo de Movimentação").Int().NotNull()
                    .Enumerable(1, "Recebimento")
                    .Enumerable(2, "Pagamento")
                .AddColumn("DataMovimentacao", "Data da Movimentação").DateTime().NotNull()
                .AddColumn("SaldoAtual", "Saldo Atual").Decimal(10, 2).NotNull();


            AddEntity("Sesoes")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("PacienteId", "Paciente").FK("Paciente", "Id").Int()
                .AddColumn("ProfissionalId", "Profissional").FK("Profissional", "Id").Int()
                .AddColumn("ServicoId", "Serviço").FK("Servico", "Id").Int()
                .AddColumn("DataInicio", "Data Inicio").DateTime().NotNull()
                .AddColumn("DataFim", "Data Fim").DateTime().NotNull()
                .AddColumn("Status", "Status do Agendamento").Int()
                .Enumerable(0, "Em Aberto")
                .Enumerable(1, "Compareceu")
                .Enumerable(2, "Não Compareceu")
                .Enumerable(3, "Remarcado pelo proficional")
                .Enumerable(4, "Remarcado pelo paciente")
                .AddColumn("MovimentacaoFinanceiraId", "Financeiro").FK("MovimentacaoFinanceira", "Id").Int()

                .AddColumn("SinteseProntuario", "Sintese Prontuario").Varchar(8000)
                // prontuario CRP
                // RegistroDocumental CRP
                // Anaminese 
                //3. Queixa Principal e Evolução
                .AddColumn("QueixaPrincipal", "Queixa Principal").Varchar(500)
                .AddColumn("MotivoConsultaAtual", "Motivo da consulta atual").Varchar(500)
                .AddColumn("SintomasRelatados", "Sintomas relatados").Varchar(500)
                .AddColumn("MudancasDesdeUltimaSessaao", "Mudanças desde a última sessão").Int()
                .Enumerable(1, "Menteve")
                .Enumerable(2, "Melhora")
                .Enumerable(3, "Piora")
                .Enumerable(4, "Eventos novos")
                //4. Observações Clínicas
                .AddColumn("ComportamentoObservado", "Comportamento observado durante a sessão").Varchar(500)
                .AddColumn("EstadoEmocionalGeral", "Estado emocional geral", "(exemplo: ansioso, deprimido, irritado, estável)").Varchar(500)
                .AddColumn("DiscursoPensamentos", "Discurso e pensamentos", "(lógicos, acelerados, confusos, obsessivos)").Varchar(500)
                //5. Estratégias e Intervenções na Sessão
                .AddColumn("TecnicasUtilizadas", "Técnicas utilizadas").Varchar(500)
                .AddColumn("QuestionamentosReflexoesAbordadas", "Questionamentos e reflexões abordadas").Varchar(500)
                .AddColumn("ExerciciosTarefasSugeridas", "Exercícios ou tarefas de casa sugeridas").Varchar(500)

                //6. Diagnóstico ou Hipótese Diagnóstica (se aplicável)
                .AddColumn("DiagnoosticoHipoteseDiagnoostica", "Diagnóstico ou Hipótese Diagnóstica").Varchar(500).UserEncryptedField()
                //7. Plano Terapêutico e Encaminhamentos
                .AddColumn("ObjetivosCurtoPrazo", "Objetivos a curto prazo").Varchar(500)
                .AddColumn("ObjetivosLongoPrazo", "Objetivos a longo prazo").Varchar(500)
                .AddColumn("FrequenciaSugeridaSessooes", "Frequência sugerida das sessões").Varchar(500)
                .AddColumn("EncaminhamentoOutrosProfissionais", "Encaminhamento para outros profissionais").Varchar(500)
                //8. Anotações Extras
                .AddColumn("InformacoesRelevantesFuturasConsultas", "Informações relevantes que podem ser úteis em futuras consultas").Varchar(500)
                .AddColumn("FeedbackPacienteSobreProcessoTerapeeutico", "Feedback do paciente sobre o processo terapêutico").Varchar(500);

            // Agente para interação de agendamento de pacientes via WhatsApp
            AddHub("ClinicaPaciente")
                .AddAgents("Agente de Agendamento de Paciente")
                    .AddMenu("Menu de Agendamento")
                    .AddMenuOption(1, "Consultar agendamentos existentes")
                    .AddMenuOption(2, "Cancelar agendamento")
                    .AddSubMenu("Agendar novo atendimento")
                    .AddSubMenuOption(1, "Lista de dadas")
                    .AddSubMenuOption(2, "Sugerir uma data")

                .AddAgents("Agente Financeiro de Paciente")
                    .AddAgentMetod("Interagir com paciente para controle financeiro via WhatsApp", "")
                    .AddMenu("Menu Financeiro")
                    .AddMenuOption(1, "Verificar saldo")
                    .AddMenuOption(2, "Histórico de transações")
                    .AddMenuOption(3, "Realizar pagamento de serviço")
                .AddAgents("Agente de Agendamento para Administrador")
                    .AddAgentMetod("Interagir com administrador para controle de agendamentos", "")
                    .AddMenu("Menu Administrativo de Agendamentos")
                    .AddMenuOption(1, "Verificar agendamentos do dia")
                    .AddMenuOption(2, "Agendar atendimento para paciente")
                    .AddMenuOption(3, "Cancelar agendamento de paciente")

                .AddAgents("Agente Financeiro para Administrador")
                    .AddAgentMetod("Interagir com administrador para controle financeiro", "")
                    .AddMenu("Menu Administrativo Financeiro")
                    .AddMenuOption(1, "Verificar saldo total da clínica")
                    .AddMenuOption(2, "Verificar transações financeiras")
                    .AddMenuOption(3, "Emitir relatório financeiro")
                .AddAgents("createConta");




        }
    }
}
