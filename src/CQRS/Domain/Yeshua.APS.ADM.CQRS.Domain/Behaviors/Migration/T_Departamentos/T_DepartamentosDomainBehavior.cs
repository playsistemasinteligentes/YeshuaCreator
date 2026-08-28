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
    public static partial class T_DepartamentosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_DepartamentosEntity t_departamentos, DomainOperationContext context)
        {
            PrepareCustom(t_departamentos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_departamentos, context, result.Errors);
            ValidateCustom(t_departamentos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_departamentos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_DepartamentosEntity t_departamentos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_departamentos.isValidInsert(),
                DomainOperation.Alteracao => t_departamentos.isValidUpdate(),
                DomainOperation.Remocao => t_departamentos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_departamentos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_DepartamentosEntity t_departamentos, DomainOperationContext context);
        static partial void ValidateCustom(IT_DepartamentosEntity t_departamentos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_DepartamentosEntity t_departamentos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration