using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    //1. Strategy com regra de negócio(ex: cálculo de desconto, validação específica) // Domínio
    public interface IDescontoStrategy
    {
        //decimal CalcularDesconto(Pedido pedido);
    }

    // 2. Strategy de aplicação(ex: escolha de método de pagamento, envio de notificação) // Aplicação
    public interface IMetodoPagamentoStrategy
    {
        //Task<bool> ProcessarPagamento(PagamentoRequest request);
    }
    //Então, para resumir:
    //Coloque as Strategies que representam regras de negócio no domínio.
    //Coloque as Strategies que orquestram processos, comunicação ou coordenação no aplicativo.
}
