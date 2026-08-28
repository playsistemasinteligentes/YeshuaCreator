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
    public static partial class LaudoTesteFisicoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ILaudoTesteFisicoEntity laudotestefisico, DomainOperationContext context)
        {
            PrepareCustom(laudotestefisico, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(laudotestefisico, context, result.Errors);
            ValidateCustom(laudotestefisico, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(laudotestefisico, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ILaudoTesteFisicoEntity laudotestefisico, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => laudotestefisico.isValidInsert(),
                DomainOperation.Alteracao => laudotestefisico.isValidUpdate(),
                DomainOperation.Remocao => laudotestefisico.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(laudotestefisico.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ILaudoTesteFisicoEntity laudotestefisico, DomainOperationContext context);
        static partial void ValidateCustom(ILaudoTesteFisicoEntity laudotestefisico, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ILaudoTesteFisicoEntity laudotestefisico, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration