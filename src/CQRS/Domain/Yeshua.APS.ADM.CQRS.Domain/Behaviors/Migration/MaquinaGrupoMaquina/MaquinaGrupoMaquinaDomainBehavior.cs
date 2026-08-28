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
    public static partial class MaquinaGrupoMaquinaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMaquinaGrupoMaquinaEntity maquinagrupomaquina, DomainOperationContext context)
        {
            PrepareCustom(maquinagrupomaquina, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(maquinagrupomaquina, context, result.Errors);
            ValidateCustom(maquinagrupomaquina, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(maquinagrupomaquina, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMaquinaGrupoMaquinaEntity maquinagrupomaquina, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => maquinagrupomaquina.isValidInsert(),
                DomainOperation.Alteracao => maquinagrupomaquina.isValidUpdate(),
                DomainOperation.Remocao => maquinagrupomaquina.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(maquinagrupomaquina.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMaquinaGrupoMaquinaEntity maquinagrupomaquina, DomainOperationContext context);
        static partial void ValidateCustom(IMaquinaGrupoMaquinaEntity maquinagrupomaquina, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMaquinaGrupoMaquinaEntity maquinagrupomaquina, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration