using System;
using System.Linq;
using System.Text;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeEntityInternalMigration : SourceCodeBase
    {
        private readonly List<Entity> _entities;
        private readonly string _namespaceName;

        public SourceCodeEntityInternalMigration(
            List<Entity> entities,
            string namespaceName = "MyApp.Domain.Entities")
        {
            _entities = entities;
            _namespaceName = namespaceName;
        }

        public void WriteMigrationCode(string filePath)
        {
            WriteCode(GenerateCode(), filePath, false, false);
        }

        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }
        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            // Cabeçalho do arquivo
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine($"namespace {_namespaceName}");
            sb.AppendLine("{");

            foreach (var entity in _entities)
            {
                sb.AppendLine($"    public class {entity.EntityName}");
                sb.AppendLine("    {");

                // Propriedades normais
                foreach (var column in entity.AddColumns)
                {
                    var type = column.getCsharpType(true);
                    sb.AppendLine($"        public {type} {column.Name} {{ get; set; }}");
                    if (column.IsFK)
                        sb.AppendLine($"        public {column.EntityFK.EntityName} {column.EntityFK.EntityName} {{ get; set; }}");

                }

                // Método de query estático
                sb.AppendLine();
                sb.AppendLine($"        public static MyApp.QueryBuilder.Query<{entity.EntityName}> Query() => new MyApp.QueryBuilder.Query<{entity.EntityName}>();");

                sb.AppendLine("    }");
                sb.AppendLine();
            }

            sb.AppendLine("}");

            return sb;
        }
    }
}
