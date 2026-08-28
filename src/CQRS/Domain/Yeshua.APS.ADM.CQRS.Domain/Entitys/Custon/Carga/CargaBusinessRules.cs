using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Carga
{
    public static class CargaBusinessRules
    {
        public static void Prepare(ICargaEntity carga, DomainOperationContext context)
        {
            if (!string.IsNullOrWhiteSpace(carga.OCO_ID_LIERACAO)
                && !string.IsNullOrWhiteSpace(carga.CAR_OBS_LIERACAO))
            {
                carga.CAR_PESAGEM_LIBERADA = "S";
            }
        }

        public static void Validate(ICargaEntity carga, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (!carga.CAR_STATUS.HasValue || carga.CAR_STATUS.Value == 0)
            {
                errors.Add("Voce deve atribuir um Status para a carga.");
                return;
            }

            if (carga.CAR_STATUS.Value > 1 && (!carga.TIP_ID.HasValue || carga.TIP_ID.Value <= 0))
            {
                errors.Add("Voce deve informar o Tipo de Veiculo para esta carga.");
            }
        }
    }
}
