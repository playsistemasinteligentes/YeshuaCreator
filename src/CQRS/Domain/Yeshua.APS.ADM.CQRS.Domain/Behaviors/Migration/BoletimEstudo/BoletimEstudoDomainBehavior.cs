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
    public static partial class BoletimEstudoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IBoletimEstudoEntity boletimestudo, DomainOperationContext context)
        {
            PrepareCustom(boletimestudo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(boletimestudo, context, result.Errors);
            ValidateCustom(boletimestudo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(boletimestudo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IBoletimEstudoEntity boletimestudo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => boletimestudo.isValidInsert(),
                DomainOperation.Alteracao => boletimestudo.isValidUpdate(),
                DomainOperation.Remocao => boletimestudo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(boletimestudo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IBoletimEstudoEntity boletimestudo, DomainOperationContext context);
        static partial void ValidateCustom(IBoletimEstudoEntity boletimestudo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IBoletimEstudoEntity boletimestudo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration