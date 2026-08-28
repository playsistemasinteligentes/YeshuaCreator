using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Boletim
{
    public static class BoletimBusinessRules
    {
        public static void Validate(IBoletimEntity boletim, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (!boletim.BOL_REFILE_OBRIGATORIO.HasValue || boletim.BOL_REFILE_OBRIGATORIO.Value <= 0)
            {
                errors.Add("Refile deve ser maior que zero.");
            }

            if (!boletim.BOL_FORMATO.HasValue || boletim.BOL_FORMATO.Value <= 0)
            {
                errors.Add("Formato deve ser maior que zero.");
            }
        }
    }
}
