using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Operacoes
{
    public static class OperacoesBusinessRules
    {
        public static void Validate(IOperacoesEntity operacoes, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation != DomainOperation.Registro)
            {
                return;
            }

            if (!string.IsNullOrEmpty(operacoes.OPE_ID) && operacoes.OPE_ID.Length < 3)
            {
                errors.Add("O codigo da operacao precisa ter mais que 3 caracteres.");
            }
        }
    }
}
