using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.TempoSetupOnduladeira
{
    public static class TempoSetupOnduladeiraBusinessRules
    {
        public static void Prepare(ITempoSetupOnduladeiraEntity tempoSetupOnduladeira, DomainOperationContext context)
        {
            if (string.IsNullOrWhiteSpace(tempoSetupOnduladeira.OND_ID_DE))
            {
                tempoSetupOnduladeira.OND_ID_DE = null;
            }

            if (string.IsNullOrWhiteSpace(tempoSetupOnduladeira.OND_ID_PARA))
            {
                tempoSetupOnduladeira.OND_ID_PARA = null;
            }
        }

        public static void Validate(ITempoSetupOnduladeiraEntity tempoSetupOnduladeira, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            var hasOndaDe = !string.IsNullOrWhiteSpace(tempoSetupOnduladeira.OND_ID_DE);
            var hasOndaPara = !string.IsNullOrWhiteSpace(tempoSetupOnduladeira.OND_ID_PARA);

            if (hasOndaDe != hasOndaPara)
            {
                errors.Add("Nao e permitido que apenas um campo de onda seja preenchido.");
            }
        }
    }
}
