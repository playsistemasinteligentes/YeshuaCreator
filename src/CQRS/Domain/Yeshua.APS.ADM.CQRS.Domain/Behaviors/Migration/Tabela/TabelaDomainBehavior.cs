// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class TabelaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITabelaEntity tabela, DomainOperationContext context)
        {
            PrepareCustom(tabela, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tabela, context, result.Errors);
            ValidateCustom(tabela, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tabela, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITabelaEntity tabela, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tabela.isValidInsert(),
                DomainOperation.Alteracao => tabela.isValidUpdate(),
                DomainOperation.Remocao => tabela.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tabela.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITabelaEntity tabela, DomainOperationContext context);
        static partial void ValidateCustom(ITabelaEntity tabela, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITabelaEntity tabela, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration