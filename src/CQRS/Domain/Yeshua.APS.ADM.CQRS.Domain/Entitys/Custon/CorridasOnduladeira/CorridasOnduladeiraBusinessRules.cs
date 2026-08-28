using Dominio.Patterns.Domain;
using System;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.CorridasOnduladeira
{
    public static class CorridasOnduladeiraBusinessRules
    {
        public static void Validate(ICorridasOnduladeiraEntity corrida, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (!corrida.COR_SEQUENCIA.HasValue || corrida.COR_SEQUENCIA.Value == 0)
            {
                errors.Add("COR_SEQUENCIA nao pode ser nula ou zero.");
            }

            if (!corrida.COR_FORMATO_BOBINA.HasValue || corrida.COR_FORMATO_BOBINA.Value <= 0)
            {
                errors.Add("COR_FORMATO_BOBINA nao pode ser nulo ou menor que zero.");
            }

            if (!corrida.COR_PECAS_LARGURA.HasValue || corrida.COR_PECAS_LARGURA.Value <= 0)
            {
                errors.Add("COR_PECAS_LARGURA nao pode ser nula ou menor que zero.");
            }

            if (!corrida.COR_QTD_PLANEJADO.HasValue || corrida.COR_QTD_PLANEJADO.Value <= 0)
            {
                errors.Add("COR_QTD_PLANEJADO nao pode ser nula ou menor que zero.");
            }

            if (string.IsNullOrWhiteSpace(corrida.BOL_ID))
            {
                errors.Add("BOL_ID nao pode ser nulo ou vazio.");
            }

            if (context.Operation == DomainOperation.Alteracao
                && string.Equals(corrida.COR_STATUS, "FF", StringComparison.OrdinalIgnoreCase)
                && (string.Equals(corrida.COR_SOLVER, "SEMCONJUGACAO", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(corrida.COR_SOLVER, "RESTRICAO_CADASTRO", StringComparison.OrdinalIgnoreCase)))
            {
                errors.Add("Esta corrida nao pode se tornar firme, pois nao esta conjugada.");
            }
        }
    }
}
