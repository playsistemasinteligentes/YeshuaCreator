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
    public static partial class PerfilObjetoControlavelDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPerfilObjetoControlavelEntity perfilobjetocontrolavel, DomainOperationContext context)
        {
            PrepareCustom(perfilobjetocontrolavel, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(perfilobjetocontrolavel, context, result.Errors);
            ValidateCustom(perfilobjetocontrolavel, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(perfilobjetocontrolavel, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPerfilObjetoControlavelEntity perfilobjetocontrolavel, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => perfilobjetocontrolavel.isValidInsert(),
                DomainOperation.Alteracao => perfilobjetocontrolavel.isValidUpdate(),
                DomainOperation.Remocao => perfilobjetocontrolavel.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(perfilobjetocontrolavel.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPerfilObjetoControlavelEntity perfilobjetocontrolavel, DomainOperationContext context);
        static partial void ValidateCustom(IPerfilObjetoControlavelEntity perfilobjetocontrolavel, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPerfilObjetoControlavelEntity perfilobjetocontrolavel, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration