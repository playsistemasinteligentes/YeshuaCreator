using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.GrupoMaquina
{
    public static class GrupoMaquinaBusinessRules
    {
        public static void Validate(IGrupoMaquinaEntity grupoMaquina, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation != DomainOperation.Registro)
            {
                return;
            }

            if (!string.IsNullOrEmpty(grupoMaquina.Id) && grupoMaquina.Id.Length < 3)
            {
                errors.Add("O codigo do Grupo de Maquina precisa ter mais que 3 caracteres.");
            }
        }
    }
}
