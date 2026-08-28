using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Maquina
{
    public static class MaquinaBusinessRules
    {
        public static void Validate(IMaquinaEntity maquina, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (context.Operation == DomainOperation.Registro
                && !string.IsNullOrWhiteSpace(maquina.Id)
                && maquina.Id.Length < 3)
            {
                errors.Add("O codigo da maquina precisa ter mais que 3 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(maquina.MAQ_ACOMPANHA_LOTE_PILOTO)
                && !HasValidTimeSegments(maquina.MAQ_ACOMPANHA_LOTE_PILOTO))
            {
                errors.Add("O campo acompanha lote piloto deve ser uma dupla de horarios HH:MM separados por '|'.");
            }
        }

        private static bool HasValidTimeSegments(string value)
        {
            var start = 0;
            for (var index = 0; index <= value.Length; index++)
            {
                if (index == value.Length || value[index] == '|')
                {
                    if (!IsValidTime(value, start, index - start))
                    {
                        return false;
                    }

                    start = index + 1;
                }
            }

            return true;
        }

        private static bool IsValidTime(string value, int start, int length)
        {
            if (length != 4 && length != 5)
            {
                return false;
            }

            var separatorIndex = length == 4 ? start + 1 : start + 2;
            if (value[separatorIndex] != ':')
            {
                return false;
            }

            var hour = 0;
            for (var index = start; index < separatorIndex; index++)
            {
                var digit = value[index] - '0';
                if (digit < 0 || digit > 9)
                {
                    return false;
                }

                hour = (hour * 10) + digit;
            }

            if (hour > 23)
            {
                return false;
            }

            var minuteTens = value[separatorIndex + 1] - '0';
            var minuteUnits = value[separatorIndex + 2] - '0';
            return minuteTens >= 0
                && minuteTens <= 5
                && minuteUnits >= 0
                && minuteUnits <= 9;
        }
    }
}
