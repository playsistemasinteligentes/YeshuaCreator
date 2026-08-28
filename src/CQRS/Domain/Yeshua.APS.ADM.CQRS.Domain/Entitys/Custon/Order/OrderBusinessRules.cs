using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Order
{
    public static class OrderBusinessRules
    {
        public static void Validate(IOrderEntity order, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(order.PRO_ID))
            {
                errors.Add($"Informe um PRO_ID para o pedido {order.ORD_ID}.");
            }

            if (string.IsNullOrWhiteSpace(order.CLI_ID))
            {
                errors.Add("Por favor, informe o cliente deste pedido.");
            }
        }
    }
}
