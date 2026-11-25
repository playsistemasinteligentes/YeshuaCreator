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
    public static partial class IdentidadePublicadoraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IIdentidadePublicadoraEntity identidadepublicadora, DomainOperationContext context)
        {
            PrepareCustom(identidadepublicadora, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(identidadepublicadora, context, result.Errors);
            ValidateCustom(identidadepublicadora, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(identidadepublicadora, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IIdentidadePublicadoraEntity identidadepublicadora, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => identidadepublicadora.isValidInsert(),
                DomainOperation.Alteracao => identidadepublicadora.isValidUpdate(),
                DomainOperation.Remocao => identidadepublicadora.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(identidadepublicadora.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IIdentidadePublicadoraEntity identidadepublicadora, DomainOperationContext context);
        static partial void ValidateCustom(IIdentidadePublicadoraEntity identidadepublicadora, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IIdentidadePublicadoraEntity identidadepublicadora, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration