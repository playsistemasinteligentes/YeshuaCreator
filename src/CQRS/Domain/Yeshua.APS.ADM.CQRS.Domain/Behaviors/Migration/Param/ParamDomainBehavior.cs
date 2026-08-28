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
    public static partial class ParamDomainBehavior
    {
        public static DomainBehaviorResult Apply(IParamEntity param, DomainOperationContext context)
        {
            PrepareCustom(param, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(param, context, result.Errors);
            ValidateCustom(param, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(param, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IParamEntity param, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => param.isValidInsert(),
                DomainOperation.Alteracao => param.isValidUpdate(),
                DomainOperation.Remocao => param.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(param.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IParamEntity param, DomainOperationContext context);
        static partial void ValidateCustom(IParamEntity param, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IParamEntity param, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration