using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public sealed class SourceCodeDomainBehaviorMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeDomainBehaviorMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            var entityName = _entity.EntityName;
            var variableName = entityName.ToLower();

            var sb = new StringBuilder();
            sb.AppendLine("using Dominio.Entitys;");
            sb.AppendLine("using Dominio.Patterns.Domain;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine("namespace Dominio.Behaviors");
            sb.AppendLine("{");
            sb.AppendLine($"    public static partial class {entityName}DomainBehavior");
            sb.AppendLine("    {");
            sb.AppendLine($"        public static DomainBehaviorResult Apply(I{entityName}Entity {variableName}, DomainOperationContext context)");
            sb.AppendLine("        {");
            sb.AppendLine($"            PrepareCustom({variableName}, context);");
            sb.AppendLine();
            sb.AppendLine("            var result = new DomainBehaviorResult();");
            sb.AppendLine($"            ValidateGenerated({variableName}, context, result.Errors);");
            sb.AppendLine($"            ValidateCustom({variableName}, context, result.Errors);");
            sb.AppendLine();
            sb.AppendLine("            if (result.IsValid)");
            sb.AppendLine("            {");
            sb.AppendLine($"                CollectEventsCustom({variableName}, context, result.Events);");
            sb.AppendLine("            }");
            sb.AppendLine();
            sb.AppendLine("            return result;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        private static void ValidateGenerated(I{entityName}Entity {variableName}, DomainOperationContext context, List<string> errors)");
            sb.AppendLine("        {");
            sb.AppendLine("            var isValid = context.Operation switch");
            sb.AppendLine("            {");
            sb.AppendLine($"                DomainOperation.Registro => {variableName}.isValidInsert(),");
            sb.AppendLine($"                DomainOperation.Alteracao => {variableName}.isValidUpdate(),");
            sb.AppendLine($"                DomainOperation.Remocao => {variableName}.isValidDelete(),");
            sb.AppendLine("                _ => true");
            sb.AppendLine("            };");
            sb.AppendLine();
            sb.AppendLine("            if (!isValid)");
            sb.AppendLine("            {");
            sb.AppendLine($"                errors.AddRange({variableName}.getErroMensagens());");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        static partial void PrepareCustom(I{entityName}Entity {variableName}, DomainOperationContext context);");
            sb.AppendLine($"        static partial void ValidateCustom(I{entityName}Entity {variableName}, DomainOperationContext context, List<string> errors);");
            sb.AppendLine($"        static partial void CollectEventsCustom(I{entityName}Entity {variableName}, DomainOperationContext context, List<IDomainEvent> events);");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }

        protected override StringBuilder GenerateCustonCode()
        {
            var entityName = _entity.EntityName;
            var sb = new StringBuilder();
            sb.AppendLine("using Dominio.Entitys;");
            sb.AppendLine("using Dominio.Patterns.Domain;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine("namespace Dominio.Behaviors");
            sb.AppendLine("{");
            sb.AppendLine($"    public static partial class {entityName}DomainBehavior");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
    }
}
