using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    //Interface: IBusinessRule<T>
    //Usada para representar regras contextuais de negócio.
    public interface IBusinessRule<T>
    {
        bool IsBroken(T entity);
        string Message { get; }
    }
    // Local: Domain.Rules
    //📍Responsabilidade: Regras que o domínio reconhece, mas que não são invariantes.
}
