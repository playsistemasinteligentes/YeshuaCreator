using Dominio.Patterns.Domain;

namespace Dominio.Entitys.Custon.ItensOrcamento
{
    public static class ItensOrcamentoBusinessRules
    {
        public static void Prepare(IItensOrcamentoEntity itensOrcamento, DomainOperationContext context)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            itensOrcamento.ITO_LARGURA ??= 0;
            itensOrcamento.ITO_COMPRIMENTO ??= 0;
        }
    }
}
