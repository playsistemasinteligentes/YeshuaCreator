using System;
using System.IO;

namespace Migration.Dominio
{
    public abstract class SourceCodeBase
    {
        protected string FilePath { get; private set; }
        protected bool IsCustonFile { get; private set; }
        protected bool Sobrescrever { get; private set; } = true;

        protected SourceCodeBase(string filePath, bool isCuston = false)
        {
            FilePath = filePath;
            IsCustonFile = isCuston;
        }

        // Método protegido para verificar se o diretório existe e criar se não existir
        protected void EnsureDirectoryExists()
        {
            var directory = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        // Método protegido para verificar se o arquivo existe e criar se não existir
        protected void EnsureFileExists()
        {
            if (File.Exists(FilePath))
            {
                if (IsCustonFile)
                    Sobrescrever = false;
            }
            else
            {
                File.Create(FilePath).Dispose(); // Cria o arquivo e fecha o handle
            }
        }

        // Método protegido para obter o conteúdo atual do arquivo
        protected string ReadFileContent()
        {
            return File.Exists(FilePath) ? File.ReadAllText(FilePath) : string.Empty;
        }

        // Método protegido para escrever o código no arquivo
        protected void WriteToFile(string content)
        {
            EnsureDirectoryExists();
            File.WriteAllText(FilePath, content);
        }

        // Método abstrato para definir a lógica específica de geração de código
        protected abstract string GenerateCode();

        // Método público para gerar e salvar o código
        public void WriteCode()
        {
            if (Sobrescrever)
            {
                var code = GenerateCode();
                WriteToFile(code);
            }
        }
    }

}