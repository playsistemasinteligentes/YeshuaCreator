using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Patterns.Saga
{
    public enum SagaStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3
    }

    public enum SagaStepStatus
    {
        Created = 0, // stap registrado mas ninguem nenhum worker pega ele apenas next step movimenta ele para inProgress 
        Pending = 1, // Worker pega pra executar 
        InProgress = 2, // Worker marca que vai executar  
        WaitingResponse = 3, // espera confirmação ao confirmar chama next step e move para completed 
        Completed = 4,// completo 
        Failed = 5 // retry 

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