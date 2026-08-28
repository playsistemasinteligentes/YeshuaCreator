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
    public static partial class TesteFisicoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITesteFisicoEntity testefisico, DomainOperationContext context)
        {
            PrepareCustom(testefisico, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(testefisico, context, result.Errors);
            ValidateCustom(testefisico, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(testefisico, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITesteFisicoEntity testefisico, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => testefisico.isValidInsert(),
                DomainOperation.Alteracao => testefisico.isValidUpdate(),
                DomainOperation.Remocao => testefisico.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(testefisico.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITesteFisicoEntity testefisico, DomainOperationContext context);
        static partial void ValidateCustom(ITesteFisicoEntity testefisico, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITesteFisicoEntity testefisico, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration