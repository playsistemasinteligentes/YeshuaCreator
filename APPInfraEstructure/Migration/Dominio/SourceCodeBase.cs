using System;
using System.IO;

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
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        // Método protegido para obter o conteúdo atual do arquivo
        protected string ReadFileContent(string filePath)
        {
            return File.Exists(filePath) ? File.ReadAllText(filePath) : string.Empty;
        }

        // Método protegido para escrever o código no arquivo
        protected void WriteToFile(string content, string filePath)
        {
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, content);
        }

        // Método abstrato para definir a lógica específica de geração de código
        protected abstract string GenerateCode();
        protected abstract string GenerateCustonCode();

        // Método público para gerar e salvar o código
        public void WriteCode(string filePathMigration, string filePathCuston)
        {
            var code = GenerateCode();
            WriteToFile(code, filePathMigration);

            if (!File.Exists(filePathCuston))
            {
                code = GenerateCustonCode();
                WriteToFile(code, filePathCuston);
            }
        }
    }

}