using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Ocorrencia
{
    public static class OcorrenciaBusinessRules
    {
        public static void Validate(IOcorrenciaEntity ocorrencia, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (ocorrencia.TIP_ID == 0)
            {
                errors.Add("Voce deve informar o codigo do tipo de ocorrencia.");
            }
        }
    }
}
