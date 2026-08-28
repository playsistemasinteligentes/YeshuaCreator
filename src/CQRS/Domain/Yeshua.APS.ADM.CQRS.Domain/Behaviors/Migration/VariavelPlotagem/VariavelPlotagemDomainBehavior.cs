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
    public static partial class VariavelPlotagemDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVariavelPlotagemEntity variavelplotagem, DomainOperationContext context)
        {
            PrepareCustom(variavelplotagem, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(variavelplotagem, context, result.Errors);
            ValidateCustom(variavelplotagem, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(variavelplotagem, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVariavelPlotagemEntity variavelplotagem, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => variavelplotagem.isValidInsert(),
                DomainOperation.Alteracao => variavelplotagem.isValidUpdate(),
                DomainOperation.Remocao => variavelplotagem.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(variavelplotagem.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVariavelPlotagemEntity variavelplotagem, DomainOperationContext context);
        static partial void ValidateCustom(IVariavelPlotagemEntity variavelplotagem, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVariavelPlotagemEntity variavelplotagem, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration