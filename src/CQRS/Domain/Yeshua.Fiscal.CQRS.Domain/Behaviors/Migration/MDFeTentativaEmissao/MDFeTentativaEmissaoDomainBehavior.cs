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
    public static partial class MDFeTentativaEmissaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFeTentativaEmissaoEntity mdfetentativaemissao, DomainOperationContext context)
        {
            PrepareCustom(mdfetentativaemissao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfetentativaemissao, context, result.Errors);
            ValidateCustom(mdfetentativaemissao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfetentativaemissao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFeTentativaEmissaoEntity mdfetentativaemissao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfetentativaemissao.isValidInsert(),
                DomainOperation.Alteracao => mdfetentativaemissao.isValidUpdate(),
                DomainOperation.Remocao => mdfetentativaemissao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfetentativaemissao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFeTentativaEmissaoEntity mdfetentativaemissao, DomainOperationContext context);
        static partial void ValidateCustom(IMDFeTentativaEmissaoEntity mdfetentativaemissao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFeTentativaEmissaoEntity mdfetentativaemissao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration