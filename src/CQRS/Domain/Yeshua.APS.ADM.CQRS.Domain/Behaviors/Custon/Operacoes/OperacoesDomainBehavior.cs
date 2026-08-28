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
using Dominio.Entitys.Custon.Operacoes;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class OperacoesDomainBehavior
    {
        static partial void ValidateCustom(IOperacoesEntity operacoes, DomainOperationContext context, List<string> errors)
        {
            OperacoesBusinessRules.Validate(operacoes, context, errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
