using System.Text;
using Dominio;
using Migration.Dominio;

namespace Migration.CodeGeneration.Templates
{
    public class CommandTemplateReplicator
    {
        public string Replicate(CommandTemplate template, Entity entity)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"namespace {template.Namespace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public struct {entity.EntityName}CrudCommand : ICommand");
            sb.AppendLine("    {");

            foreach (var prop in template.Properties)
            {
                if (prop.HasAttribute("IgnoreReplication"))
                    continue;

                if (prop.HasAttribute("FromEntityColumn"))
                {
                    var column = entity.AddColumns
                        .FirstOrDefault(c => c.Name == prop.Name);

                    if (column == null)
                        continue;

                    sb.AppendLine(
                        $"        public {column.getCsharpType(true, false)} {column.Name} {{ get; set; }}");
                }
                else
                {
                    // réplica literal (fallback)
                    sb.AppendLine(
                        $"        public {prop.Type} {prop.Name} {{ get; set; }}");
                }
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
