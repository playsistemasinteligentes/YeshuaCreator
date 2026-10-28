// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class EspecialidadeDomainBehavior
    {
        static partial void PrepareCustom(IEspecialidadeEntity entity, DomainOperationContext context)
        { if (ValidacaoCadastro.Escrita(context)) entity.Descricao=entity.Descricao?.Trim()??""; }
        static partial void ValidateCustom(IEspecialidadeEntity entity, DomainOperationContext context, List<string> errors)
        { if (ValidacaoCadastro.Escrita(context)) ValidacaoCadastro.Texto(entity.Descricao,"Descrição da especialidade",100,errors); }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
