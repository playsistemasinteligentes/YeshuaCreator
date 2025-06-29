using Dominio;
using System;
using System.IO;
using System.Text;

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
        protected void WriteToFile(StringBuilder content, string filePath)
        {
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, content.ToString());
        }

        // Método abstrato para definir a lógica específica de geração de código
        protected abstract StringBuilder GenerateCode();
        protected abstract StringBuilder GenerateCustonCode();

        public void WriteContexto(string content)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
                string filePath = Path.Combine(projectDir, "Contexto.txt");

                // Abre ou cria o arquivo com compartilhamento liberado para leitura
                using (var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao escrever no arquivo: " + ex.Message);
            }
        }
        // Método público para gerar e salvar o código
        public void WriteCode(Entity entity, string filePathMigration, string filePathCuston)
        {
            StringBuilder code = GenerateCode();
            code.Append("");
            code.Append("");
            code.Append($"//{this.GetType()}");

            WriteToFile(code, filePathMigration);

            if (entity != null && entity.EntityName == "Y_Tenant")
            {
                WriteContexto(filePathMigration);
                WriteContexto(this.GetType().ToString());
                WriteContexto(code.ToString());
            }
            if (!File.Exists(filePathCuston))
            {
                code = GenerateCustonCode();
                code.Append("");
                code.Append("");
                code.Append($"//{this.GetType()}");
                WriteToFile(code, filePathCuston);
            }
        }
    }

}