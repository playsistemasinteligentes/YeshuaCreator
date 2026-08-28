using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.EstruturaProduto
{
    public static class EstruturaProdutoBusinessRules
    {
        public static void Validate(IEstruturaProdutoEntity estruturaProduto, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (estruturaProduto.EST_QUANT == 0)
            {
                errors.Add($"Quantidade EST_QUANT deve ser diferente de zero. ({estruturaProduto.PRO_ID_PRODUTO} - {estruturaProduto.PRO_ID_COMPONENTE})");
            }

            if (estruturaProduto.EST_BASE_PRODUCAO <= 0)
            {
                errors.Add($"Quantidade EST_BASE_PRODUCAO deve ser maior que zero. ({estruturaProduto.PRO_ID_PRODUTO} - {estruturaProduto.PRO_ID_COMPONENTE})");
            }
        }
    }
}
