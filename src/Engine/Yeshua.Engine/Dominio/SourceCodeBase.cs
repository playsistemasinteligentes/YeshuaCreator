using Dominio;
using System;
using System.IO;
using System.Text;
using static Dapper.SqlMapper;
using static Migration.Dominio.Migration.S000002;

namespace Migration.Dominio
{
    public abstract class SourceCodeBase
    {
        protected SourceCodeBase()
        {

        }

        // Método protegido para verificar se o diretório existe e criar se não existir
        protected void EnsureDirectoryExists(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        // Método protegido para obter o conteúdo atual do arquivo
        protected string ReadFileContent(string filePath)
        {
            return File.Exists(filePath) ? File.ReadAllText(filePath, Encoding.UTF8) : string.Empty;
        }

        // Método protegido para escrever o código no arquivo
        protected void WriteToFile(StringBuilder content, string filePath)
        {
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, content.ToString(), Encoding.UTF8);
        }

        // Método abstrato para definir a lógica específica de geração de código
        protected abstract StringBuilder GenerateCode();
        protected abstract StringBuilder GenerateCustonCode();
        // Compatibility entry point for old generators. Context now comes from indexed DSL/source,
        // not an accumulating TXT. Do not read, append, truncate or delete existing Contexto.txt files.
        [Obsolete("Contexto.txt generation is disabled. Use indexed DSL and source evidence.")]
        public void WriteContexto(string content) { }

        public string GetFriendlyTypeName(Type type, bool isDTO = false)
        {
            if (Nullable.GetUnderlyingType(type) is { } underlying)
                return $"{GetFriendlyTypeName(underlying)}?";

            if (type.IsGenericType)
            {
                string typeName = type.Name.Substring(0, type.Name.IndexOf('`'));
                var genericArgs = type.GetGenericArguments()
                                      .Select(t => GetFriendlyTypeName(t));
                return $"{typeName}<{string.Join(", ", genericArgs)}>";
            }
            else if (type.IsArray)
            {
                return $"{GetFriendlyTypeName(type.GetElementType())}[]";
            }
            else
            {
                return type switch
                {
                    _ when type == typeof(int) => "int",
                    _ when type == typeof(string) => "string",
                    _ when type == typeof(bool) => "bool",
                    _ when type == typeof(double) => "double",
                    _ when type == typeof(float) => "float",
                    _ when type == typeof(long) => "long",
                    _ when type == typeof(decimal) => "decimal",
                    _ => type.Name
                };
            }
        }

        public void WriteCode(StringBuilder code, string path, bool custon, bool context)
        {
            AddOwnershipMarker(code, custon);
            code.Append("");
            code.Append("");
            code.Append($"//{this.GetType()}");

            if (custon && File.Exists(path))
                return;

            WriteToFile(code, path);

            // The legacy context argument is retained for existing generator callers; no TXT is written.
        }

        private void AddOwnershipMarker(StringBuilder code, bool custon)
        {
            if (code.ToString().Contains("// <yeshua>", StringComparison.Ordinal))
                return;

            var artifact = custon
                ? "DSL_SEEDED_CUSTOM_OWNED_BY_DEV"
                : "GENERATED_REGENERABLE";
            var ownership = custon ? "IA_DEV" : "ENGINE";
            var editable = custon ? "true" : "false";
            var regeneration = custon ? "NEVER_OVERWRITE" : "REPLACE";
            var sourceOfTruth = custon ? "THIS_FILE" : "DSL_OR_ENGINE_TEMPLATE";
            var marker = new StringBuilder()
                .AppendLine("// <yeshua>")
                .AppendLine($"// artifact: {artifact}")
                .AppendLine("// createdBy: DSL")
                .AppendLine($"// ownership: {ownership}")
                .AppendLine($"// editable: {editable}")
                .AppendLine($"// regeneration: {regeneration}")
                .AppendLine($"// sourceOfTruth: {sourceOfTruth}")
                .AppendLine($"// generator: {GetType()}")
                .AppendLine("// </yeshua>")
                .AppendLine();

            code.Insert(0, marker);
        }
        // Método público para gerar e salvar o código
        public void WriteCode(Entity entity, string filePathMigration, string filePathCuston, UseCaseCommand useCase = null)
        {
            StringBuilder code = GenerateCode();
            WriteCode(code, filePathMigration, false, false);

            if (!File.Exists(filePathCuston))
            {
                code = GenerateCustonCode();
                WriteCode(code, filePathCuston, true, false);
            }
        }
    }

}
