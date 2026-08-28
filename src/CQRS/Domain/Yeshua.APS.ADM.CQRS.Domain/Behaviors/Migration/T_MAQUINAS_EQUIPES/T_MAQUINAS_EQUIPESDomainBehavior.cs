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
    public static partial class T_MAQUINAS_EQUIPESDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_MAQUINAS_EQUIPESEntity t_maquinas_equipes, DomainOperationContext context)
        {
            PrepareCustom(t_maquinas_equipes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_maquinas_equipes, context, result.Errors);
            ValidateCustom(t_maquinas_equipes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_maquinas_equipes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_MAQUINAS_EQUIPESEntity t_maquinas_equipes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_maquinas_equipes.isValidInsert(),
                DomainOperation.Alteracao => t_maquinas_equipes.isValidUpdate(),
                DomainOperation.Remocao => t_maquinas_equipes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_maquinas_equipes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_MAQUINAS_EQUIPESEntity t_maquinas_equipes, DomainOperationContext context);
        static partial void ValidateCustom(IT_MAQUINAS_EQUIPESEntity t_maquinas_equipes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_MAQUINAS_EQUIPESEntity t_maquinas_equipes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration