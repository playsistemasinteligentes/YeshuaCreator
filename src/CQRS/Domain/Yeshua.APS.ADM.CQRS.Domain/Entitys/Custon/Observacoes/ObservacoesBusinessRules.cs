using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Entitys.Custon.Observacoes
{
    public static class ObservacoesBusinessRules
    {
        public static void Prepare(IObservacoesEntity observacoes, DomainOperationContext context)
        {
            if (string.IsNullOrWhiteSpace(observacoes.CLI_ID))
            {
                observacoes.CLI_ID = null;
            }

            if (string.IsNullOrWhiteSpace(observacoes.MAQ_ID))
            {
                observacoes.MAQ_ID = null;
            }

            if (string.IsNullOrWhiteSpace(observacoes.PRO_ID))
            {
                observacoes.PRO_ID = null;
            }

            if (observacoes.ROT_SEQ_TRANFORMACAO == 0)
            {
                observacoes.ROT_SEQ_TRANFORMACAO = null;
            }
        }

        public static void Validate(IObservacoesEntity observacoes, DomainOperationContext context, List<string> errors)
        {
            if (context.Operation == DomainOperation.Remocao)
            {
                return;
            }

            var hasCliente = !string.IsNullOrWhiteSpace(observacoes.CLI_ID);
            var hasMaquina = !string.IsNullOrWhiteSpace(observacoes.MAQ_ID);
            var hasProduto = !string.IsNullOrWhiteSpace(observacoes.PRO_ID);
            var hasSequenciaTransformacao = observacoes.ROT_SEQ_TRANFORMACAO.HasValue
                && observacoes.ROT_SEQ_TRANFORMACAO.Value != 0;

            if (!hasCliente && !hasMaquina && !hasProduto && !hasSequenciaTransformacao)
            {
                errors.Add("Um dos seguintes campos deve ser preenchido: COD CLIENTE, COD MAQUINA, COD PRODUTO ou ROT_SEQ_TRANSFORMACAO.");
            }
        }
    }
}
