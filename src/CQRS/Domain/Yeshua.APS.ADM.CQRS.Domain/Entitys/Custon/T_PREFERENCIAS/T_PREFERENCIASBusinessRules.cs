using Dominio.Patterns.Domain;
using System;

namespace Dominio.Entitys.Custon.T_PREFERENCIAS
{
    public static class T_PREFERENCIASBusinessRules
    {
        public static void Prepare(IT_PREFERENCIASEntity preferencias, DomainOperationContext context)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (context.UserId.HasValue && preferencias.USE_ID == null)
            {
                preferencias.USE_ID = context.UserId.Value;
            }

            if (string.Equals(preferencias.PRE_TIPO, "BUFFER", StringComparison.OrdinalIgnoreCase))
            {
                preferencias.PRE_DESCRICAO = "ULTIMA PESQUISA REALIZADA.";
            }
        }
    }
}
