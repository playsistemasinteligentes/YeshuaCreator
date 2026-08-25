using Dominio.Patterns.Domain;
using System;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Roteiro
{
    public static class RoteiroBusinessRules
    {
        public static void Prepare(IRoteiroEntity roteiro, DomainOperationContext context)
        {
            if (string.IsNullOrWhiteSpace(roteiro.MAQ_ID) || roteiro.MAQ_ID == "0")
            {
                roteiro.MAQ_ID = "PLAYSIS";
            }
        }

        public static void Validate(IRoteiroEntity roteiro, DomainOperationContext context, List<string> errors)
        {
            var isRemoval = context.Operation == DomainOperation.Remocao;
            var hasMachine = !string.IsNullOrWhiteSpace(roteiro.MAQ_ID)
                && !string.Equals(roteiro.MAQ_ID, "PLAYSIS", StringComparison.OrdinalIgnoreCase);
            var hasGroup = !string.IsNullOrWhiteSpace(roteiro.GMA_ID);

            if (hasMachine && hasGroup)
            {
                errors.Add("O grupo e a maquina nao podem ser preenchidos ao mesmo tempo.");
            }

            if (!isRemoval
                && string.Equals(roteiro.MAQ_ID, "PLAYSIS", StringComparison.OrdinalIgnoreCase)
                && !hasGroup)
            {
                errors.Add("Combinacao nao permitida.");
            }

            if (!string.Equals(roteiro.ROT_ACAO, "E", StringComparison.OrdinalIgnoreCase)
                && (!roteiro.ROT_PECAS_POR_PULSO.HasValue || roteiro.ROT_PECAS_POR_PULSO.Value <= 0))
            {
                errors.Add("Pecas por pulso deve ser maior que zero quando a acao nao for exclusao.");
            }

            if (!isRemoval && roteiro.ROT_PERFORMANCE <= 0)
            {
                errors.Add("Performance deve ter valor maior que zero.");
            }

            if (roteiro.ROT_PERFORMANCE == 0)
            {
                errors.Add("Performance nao pode ser zero.");
            }

            if ((!roteiro.ROT_TEMPO_SETUP_AJUSTE.HasValue || roteiro.ROT_TEMPO_SETUP_AJUSTE.Value == 0)
                && !string.Equals(roteiro.GMA_ID, "OND", StringComparison.OrdinalIgnoreCase))
            {
                errors.Add("Tempo setup ajuste nao pode ser zero.");
            }
        }
    }
}
