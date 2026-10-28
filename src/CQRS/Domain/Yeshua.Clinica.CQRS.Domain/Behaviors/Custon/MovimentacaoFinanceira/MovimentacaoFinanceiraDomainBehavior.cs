// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class MovimentacaoFinanceiraDomainBehavior
    {
        static partial void ValidateCustom(IMovimentacaoFinanceiraEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            ValidacaoCadastro.Valor(entity.Valor,"Valor da transação",errors);
            ValidacaoCadastro.Opcao(entity.TipoMovimentacao,1,2,"Tipo de movimentação",errors);
            ValidacaoCadastro.Referencia(entity.PacienteId,"o paciente",errors);
            ValidacaoCadastro.Referencia(entity.ServicoId,"o serviço",errors);
            if (entity.SaldoAtual is < -99999999.99m or > 99999999.99m) errors.Add("Saldo atual excede o limite permitido.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
