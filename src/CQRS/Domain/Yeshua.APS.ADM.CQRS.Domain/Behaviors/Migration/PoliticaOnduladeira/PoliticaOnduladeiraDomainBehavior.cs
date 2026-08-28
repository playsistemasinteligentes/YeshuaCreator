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
    public static partial class PoliticaOnduladeiraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPoliticaOnduladeiraEntity politicaonduladeira, DomainOperationContext context)
        {
            PrepareCustom(politicaonduladeira, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(politicaonduladeira, context, result.Errors);
            ValidateCustom(politicaonduladeira, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(politicaonduladeira, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPoliticaOnduladeiraEntity politicaonduladeira, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => politicaonduladeira.isValidInsert(),
                DomainOperation.Alteracao => politicaonduladeira.isValidUpdate(),
                DomainOperation.Remocao => politicaonduladeira.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(politicaonduladeira.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPoliticaOnduladeiraEntity politicaonduladeira, DomainOperationContext context);
        static partial void ValidateCustom(IPoliticaOnduladeiraEntity politicaonduladeira, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPoliticaOnduladeiraEntity politicaonduladeira, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration