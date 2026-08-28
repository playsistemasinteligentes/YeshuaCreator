using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Produto
{
    public static class ProdutoBusinessRules
    {
        public static void Prepare(IProdutoEntity produto, DomainOperationContext context)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (produto.PRO_OUT == null)
            {
                produto.PRO_OUT = 0;
            }

            if (string.IsNullOrWhiteSpace(produto.TMP_TIPO_CARGA))
            {
                produto.TMP_TIPO_CARGA = "GRANEL";
            }

            if (produto.PRO_CAMADAS_POR_PALETE == null || produto.PRO_CAMADAS_POR_PALETE <= 0)
            {
                produto.PRO_CAMADAS_POR_PALETE = 1;
            }

            if (produto.PRO_FARDOS_POR_CAMADA == null || produto.PRO_FARDOS_POR_CAMADA <= 0)
            {
                produto.PRO_FARDOS_POR_CAMADA = 1;
            }

            if (produto.PRO_PECAS_POR_FARDO == null || produto.PRO_PECAS_POR_FARDO <= 0)
            {
                produto.PRO_PECAS_POR_FARDO = 1;
            }

            if (produto.PRO_LARGURA_EMBALADA == null || produto.PRO_LARGURA_EMBALADA <= 0)
            {
                produto.PRO_LARGURA_EMBALADA = produto.PRO_LARGURA_PECA;
            }

            if (produto.PRO_COMPRIMENTO_EMBALADA == null || produto.PRO_COMPRIMENTO_EMBALADA <= 0)
            {
                produto.PRO_COMPRIMENTO_EMBALADA = produto.PRO_COMPRIMENTO_PECA;
            }

            if (produto.PRO_ALTURA_EMBALADA == null || produto.PRO_ALTURA_EMBALADA <= 0)
            {
                produto.PRO_ALTURA_EMBALADA = produto.PRO_ALTURA_PECA;
            }

            ClearDuplicateInkReferences(produto);
        }

        public static void Validate(IProdutoEntity produto, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            if (!LooksLikeProdutoCaixa(produto))
            {
                return;
            }

            if (produto.PRO_ARRANJO_LARGURA == null || produto.PRO_ARRANJO_LARGURA == 0)
            {
                errors.Add("O campo arranjo largura nao pode ser vazio e deve ser diferente de 0.");
            }

            if (produto.PRO_ARRANJO_COMPRIMENTO == null || produto.PRO_ARRANJO_COMPRIMENTO == 0)
            {
                errors.Add("O campo arranjo comprimento nao pode ser vazio e deve ser diferente de 0.");
            }

            if (context.Operation == DomainOperation.Alteracao && string.IsNullOrWhiteSpace(produto.PRO_OBS_ALTERACAO))
            {
                errors.Add("Preencher Obs Alteracao.");
            }

            if (context.Operation == DomainOperation.Registro
                && produto.Status != null
                && (produto.Status == "LM" || produto.Status == "LA"))
            {
                errors.Add("Nao e possivel definir o status LA ou LM para uma FT sem roteiro.");
            }
        }

        private static bool LooksLikeProdutoCaixa(IProdutoEntity produto)
        {
            return produto.UNI_ID == "PC"
                || produto.PRO_ARRANJO_LARGURA != null
                || produto.PRO_ARRANJO_COMPRIMENTO != null
                || !string.IsNullOrWhiteSpace(produto.CJN_ID)
                || !string.IsNullOrWhiteSpace(produto.PRO_ID_CHAPA)
                || !string.IsNullOrWhiteSpace(produto.PRO_ID_FACA)
                || !string.IsNullOrWhiteSpace(produto.PRO_ID_CLICHE);
        }

        private static void ClearDuplicateInkReferences(IProdutoEntity produto)
        {
            if (IsSameInk(produto.PRO_ID_TINTA_05, produto.PRO_ID_TINTA_04)
                || IsSameInk(produto.PRO_ID_TINTA_05, produto.PRO_ID_TINTA_03)
                || IsSameInk(produto.PRO_ID_TINTA_05, produto.PRO_ID_TINTA_02)
                || IsSameInk(produto.PRO_ID_TINTA_05, produto.PRO_ID_TINTA_01))
            {
                produto.PRO_ID_TINTA_05 = string.Empty;
            }

            if (IsSameInk(produto.PRO_ID_TINTA_04, produto.PRO_ID_TINTA_03)
                || IsSameInk(produto.PRO_ID_TINTA_04, produto.PRO_ID_TINTA_02)
                || IsSameInk(produto.PRO_ID_TINTA_04, produto.PRO_ID_TINTA_01))
            {
                produto.PRO_ID_TINTA_04 = string.Empty;
            }

            if (IsSameInk(produto.PRO_ID_TINTA_03, produto.PRO_ID_TINTA_02)
                || IsSameInk(produto.PRO_ID_TINTA_03, produto.PRO_ID_TINTA_01))
            {
                produto.PRO_ID_TINTA_03 = string.Empty;
            }

            if (IsSameInk(produto.PRO_ID_TINTA_02, produto.PRO_ID_TINTA_01))
            {
                produto.PRO_ID_TINTA_02 = string.Empty;
            }
        }

        private static bool IsSameInk(string current, string previous)
        {
            return !string.IsNullOrWhiteSpace(current) && current == previous;
        }
    }
}
