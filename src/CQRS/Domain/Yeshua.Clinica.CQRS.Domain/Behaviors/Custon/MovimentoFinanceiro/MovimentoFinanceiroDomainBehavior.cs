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
    public static partial class MovimentoFinanceiroDomainBehavior
    {
        static partial void PrepareCustom(IMovimentoFinanceiroEntity entity, DomainOperationContext context)
        { if (ValidacaoCadastro.Escrita(context)) entity.IdOrigem=entity.IdOrigem?.Trim()??""; }
        static partial void ValidateCustom(IMovimentoFinanceiroEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            ValidacaoCadastro.Texto(entity.IdOrigem,"Identificador de origem",100,errors);
            ValidacaoCadastro.Valor(entity.Valor,"Valor do movimento",errors);
            ValidacaoCadastro.Opcao(entity.Status,1,3,"Status do movimento",errors);
            if (entity.ContaDebitoId<=0) errors.Add("Selecione a conta de débito pela pesquisa.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
