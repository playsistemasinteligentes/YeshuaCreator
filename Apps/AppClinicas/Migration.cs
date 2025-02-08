using Dominio.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .AddColumn("Telefone", "Telefone de Contato").Varchar(20).NotNull();

            AddEntity("Agendamentos")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("PacienteId", "Paciente").FK("Paciente", "Id").Int()
                .AddColumn("ProfissionalId", "Profissional").FK("Profissional", "Id").Int()
                .AddColumn("ServicoId", "Serviço").FK("Servico", "Id").Int()
                .AddColumn("DataHora", "Data e Hora do Agendamento").DateTime().NotNull()
                .AddColumn("Status", "Status do Agendamento").Varchar(50).NotNull();

            AddEntity("MovimentacaoFinanceira")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("PacienteId", "Paciente").FK("Paciente", "Id").Int()
                .AddColumn("ServicoId", "Serviço").FK("Servico", "Id").Int()
                .AddColumn("Valor", "Valor da Transação").Decimal(10, 2).NotNull()
                .AddColumn("TipoMovimentacao", "Tipo de Movimentação").Varchar(50).NotNull()
                    .Enumerable(1, "Recebimento")
                    .Enumerable(2, "Pagamento")
                .AddColumn("DataMovimentacao", "Data da Movimentação").DateTime().NotNull()
                .AddColumn("SaldoAtual", "Saldo Atual").Decimal(10, 2).NotNull();


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
                    .AddMenuOption(3, "Emitir relatório financeiro");
        }
    }





}
