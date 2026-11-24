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
    public static partial class VinculoIdentidadePublicadoraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVinculoIdentidadePublicadoraEntity vinculoidentidadepublicadora, DomainOperationContext context)
        {
            PrepareCustom(vinculoidentidadepublicadora, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(vinculoidentidadepublicadora, context, result.Errors);
            ValidateCustom(vinculoidentidadepublicadora, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(vinculoidentidadepublicadora, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVinculoIdentidadePublicadoraEntity vinculoidentidadepublicadora, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => vinculoidentidadepublicadora.isValidInsert(),
                DomainOperation.Alteracao => vinculoidentidadepublicadora.isValidUpdate(),
                DomainOperation.Remocao => vinculoidentidadepublicadora.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(vinculoidentidadepublicadora.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVinculoIdentidadePublicadoraEntity vinculoidentidadepublicadora, DomainOperationContext context);
        static partial void ValidateCustom(IVinculoIdentidadePublicadoraEntity vinculoidentidadepublicadora, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVinculoIdentidadePublicadoraEntity vinculoidentidadepublicadora, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration