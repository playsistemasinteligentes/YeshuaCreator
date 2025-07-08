using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio.Interfaces
{
    public interface IUseCaseRule<T>
    {
        bool CanExecute(T input);
        string Message { get; }
    }
    //📦 Local: Application.Policies ou Application.Rules
    //📍Responsabilidade: Lógica dependente do contexto da aplicação(workflow, segurança, etc.).
}
