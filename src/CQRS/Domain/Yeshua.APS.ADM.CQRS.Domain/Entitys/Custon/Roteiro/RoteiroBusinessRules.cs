using Dominio.Patterns.Domain;
using System;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Roteiro
{
    public static class RoteiroBusinessRules
    {
        public static void Prepare(IRoteiroEntity roteiro, DomainOperationContext context)
        {
            if (string.IsNullOrWhiteSpace(roteiro.MaquinaId) || roteiro.MaquinaId == "0")
            {
                roteiro.MaquinaId = "PLAYSIS";
            }
        }

        public static void Validate(IRoteiroEntity roteiro, DomainOperationContext context, List<string> errors)
        {
            var isRemoval = context.Operation == DomainOperation.Remocao;
            var hasMachine = !string.IsNullOrWhiteSpace(roteiro.MaquinaId)
                && !string.Equals(roteiro.MaquinaId, "PLAYSIS", StringComparison.OrdinalIgnoreCase);
            var hasGroup = !string.IsNullOrWhiteSpace(roteiro.GrupoMaquinaId);

            if (hasMachine && hasGroup)
            {
                errors.Add("O grupo e a maquina nao podem ser preenchidos ao mesmo tempo.");
            }

            if (!isRemoval
                && string.Equals(roteiro.MaquinaId, "PLAYSIS", StringComparison.OrdinalIgnoreCase)
                && !hasGroup)
            {
                errors.Add("Combinacao nao permitida.");
            }

            if (!string.Equals(roteiro.Acao, "E", StringComparison.OrdinalIgnoreCase)
                && (!roteiro.PecasPorPulso.HasValue || roteiro.PecasPorPulso.Value <= 0))
            {
                errors.Add("Pecas por pulso deve ser maior que zero quando a acao nao for exclusao.");
            }

            if (!isRemoval && roteiro.Performance <= 0)
            {
                errors.Add("Performance deve ter valor maior que zero.");
            }

            if (roteiro.Performance == 0)
            {
                errors.Add("Performance nao pode ser zero.");
            }

            if ((!roteiro.TempoSetupAjuste.HasValue || roteiro.TempoSetupAjuste.Value == 0)
                && !string.Equals(roteiro.GrupoMaquinaId, "OND", StringComparison.OrdinalIgnoreCase))
            {
                errors.Add("Tempo setup ajuste nao pode ser zero.");
            }
        }
    }
}
