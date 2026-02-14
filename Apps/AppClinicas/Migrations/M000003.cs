using Dominio.Migration;
using MyApp.Domain.Entities;
using MyApp.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Migration.Dominio.Migration.S000002;

namespace AppClinicas
{


    [Migration(000003)]
    public class M000003 : MigrationBase
    {
        public override void Up()
        {
            AddModule("FIN", "Financeiro");

            // Plano de Contas (hierárquico)
            AddEntity("PlanoConta").AddModule("FIN")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("Codigo", "Código da Conta").Varchar(20).NotNull() // ex: 1.1.1, 4.1.2
                .AddColumn("Nome", "Nome da Conta").Varchar(150).NotNull()
                .AddColumn("Tipo", "Tipo da Conta").Int().NotNull()
                    .Enumerable(1, "Ativo")
                    .Enumerable(2, "Passivo")
                    .Enumerable(3, "Receita")
                    .Enumerable(4, "Despesa");
            //.AddColumn("ContaPaiId", "Conta Pai").FK("PlanoConta", "Id").Int(); pendencia

            // Movimentações financeiras
            AddEntity("MovimentoFinanceiro").AddModule("FIN")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("IdOrigem", "Identificador de Origem").Varchar(100).NotNull()
                .AddColumn("ContaDebitoId", "Conta Débito").FK("PlanoConta", "Id").Int().NotNull()
                //.AddColumn("ContaCreditoId", "Conta Crédito").FK("PlanoConta", "Id").Int().NotNull() pendencia estoura nomes duplicados
                .AddColumn("Valor", "Valor do Movimento").Decimal(10, 2).NotNull()
                .AddColumn("DataMovimento", "Data do Movimento").DateTime().NotNull()
                .AddColumn("DataVencimento", "Data de Vencimento").DateTime()
                .AddColumn("Status", "Status do Movimento").Int().NotNull()
                    .Enumerable(1, "Pendente")   // Título ainda não liquidado
                    .Enumerable(2, "Liquidado")  // Já compensado
                    .Enumerable(3, "Estornado"); // Estornado

            // Query para fluxo de caixa (consolidado por data)
            //AddQuery<MovimentoFinanceiro>("FluxoCaixa", q => q
            //    .Where("Pendentes", s => s.Status == 1)
            //    .Where("Liquidado", s => s.Status == 2)
            //    .Select(s => new { s.Id, s.IdOrigem, s.DataMovimento, s.DataVencimento, s.Valor, s.Status })
            //);

            //// Query para saldos por conta
            //AddQuery<MovimentoFinanceiro>("SaldoPorConta", q => q
            //    .GroupBy(s => s.ContaDebitoId, g => new { Conta = g.ContaDebitoId, TotalDebitos = g.Sum(x => x.Valor) })
            //    .GroupBy(s => s.ContaCreditoId, g => new { Conta = g.ContaCreditoId, TotalCreditos = g.Sum(x => x.Valor) })
            //);




        }
    }


}
