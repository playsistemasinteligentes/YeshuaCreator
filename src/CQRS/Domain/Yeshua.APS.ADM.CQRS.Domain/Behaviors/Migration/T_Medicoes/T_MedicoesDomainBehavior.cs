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
    public static partial class T_MedicoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_MedicoesEntity t_medicoes, DomainOperationContext context)
        {
            PrepareCustom(t_medicoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_medicoes, context, result.Errors);
            ValidateCustom(t_medicoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_medicoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_MedicoesEntity t_medicoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_medicoes.isValidInsert(),
                DomainOperation.Alteracao => t_medicoes.isValidUpdate(),
                DomainOperation.Remocao => t_medicoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_medicoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_MedicoesEntity t_medicoes, DomainOperationContext context);
        static partial void ValidateCustom(IT_MedicoesEntity t_medicoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_MedicoesEntity t_medicoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration