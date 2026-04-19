using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Patterns.Saga
{
    public enum SagaStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Failed
    }

    public enum SagaStepStatus
    {
        Created, // stap registrado mas ninguem nenhum worker pega ele apenas next step movimenta ele para inProgress 
        Pending, // Worker pega pra executar 
        InProgress, // Worker marca que vai executar  
        WaitingResponse, // espera confirmação ao confirmar chama next step e move para completed 
        Completed,// completo 
        Failed // retry 

        /*variação doc 
            
            Created ou Inactive  → ainda não começou
            Pending disponivel para worker  
            InProgress → tem código rodando agora
            WaitingResponse → já executou e está esperando
            Completed → terminou
            Failed → deu ruim 
         */
    }
}