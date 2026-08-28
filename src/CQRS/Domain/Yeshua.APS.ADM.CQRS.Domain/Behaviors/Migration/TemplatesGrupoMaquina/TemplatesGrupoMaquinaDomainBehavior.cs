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
    public static partial class TemplatesGrupoMaquinaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITemplatesGrupoMaquinaEntity templatesgrupomaquina, DomainOperationContext context)
        {
            PrepareCustom(templatesgrupomaquina, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(templatesgrupomaquina, context, result.Errors);
            ValidateCustom(templatesgrupomaquina, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(templatesgrupomaquina, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITemplatesGrupoMaquinaEntity templatesgrupomaquina, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => templatesgrupomaquina.isValidInsert(),
                DomainOperation.Alteracao => templatesgrupomaquina.isValidUpdate(),
                DomainOperation.Remocao => templatesgrupomaquina.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(templatesgrupomaquina.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITemplatesGrupoMaquinaEntity templatesgrupomaquina, DomainOperationContext context);
        static partial void ValidateCustom(ITemplatesGrupoMaquinaEntity templatesgrupomaquina, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITemplatesGrupoMaquinaEntity templatesgrupomaquina, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration