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
    public static partial class BoletimDomainBehavior
    {
        public static DomainBehaviorResult Apply(IBoletimEntity boletim, DomainOperationContext context)
        {
            PrepareCustom(boletim, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(boletim, context, result.Errors);
            ValidateCustom(boletim, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(boletim, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IBoletimEntity boletim, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => boletim.isValidInsert(),
                DomainOperation.Alteracao => boletim.isValidUpdate(),
                DomainOperation.Remocao => boletim.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(boletim.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IBoletimEntity boletim, DomainOperationContext context);
        static partial void ValidateCustom(IBoletimEntity boletim, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IBoletimEntity boletim, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration