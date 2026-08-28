using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.FilaProducao
{
    public static class FilaProducaoBusinessRules
    {
        public static void Validate(IFilaProducaoEntity filaProducao, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation != DomainOperation.Remocao || string.IsNullOrEmpty(filaProducao.FPR_STATUS))
            {
                return;
            }

            if (filaProducao.FPR_STATUS[0] == 'F')
            {
                errors.Add("OPs firmes nao podem ser deletadas.");
            }

            if (filaProducao.FPR_STATUS[0] == 'E')
            {
                errors.Add("OPs encerradas nao podem ser deletadas.");
            }
        }
    }
}
