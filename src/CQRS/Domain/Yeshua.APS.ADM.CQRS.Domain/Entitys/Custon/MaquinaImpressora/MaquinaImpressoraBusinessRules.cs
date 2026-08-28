using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.MaquinaImpressora
{
    public static class MaquinaImpressoraBusinessRules
    {
        public static void Validate(IMaquinaImpressoraEntity maquinaImpressora, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (maquinaImpressora.MAI_FACAO > 2)
            {
                errors.Add("Facao invalido.");
            }
        }
    }
}
