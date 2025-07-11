using Dominio;
using System;
using System.IO;
using System.Text;
using static Dapper.SqlMapper;

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

                var novoSB = new StringBuilder();

                //novoSB.AppendLine("Assunto fabrica de software.");
                //novoSB.AppendLine("Criei uma meta linguagem para definições dos modelos ");
                //novoSB.AppendLine("Criei um motor para gerar codigo baseado na meta linguagem ");
                //novoSB.AppendLine("O motor implementa uma arquitetura com artefatos conhecidos respeitando alguns principios DDD e SOLID");
                //novoSB.AppendLine("Tenho principios tais como? O codigo gerado pelo motor deve evitar reflection para entregar o maximo de performance posivel.");
                ////novoSB.AppendLine("Enviarei meus modelos em tres partes, Modelo de Meta linguagem, artefatos da arquitetura divididos em duas etapas  ");
                //novoSB.AppendLine("Enviarei os artefatos da arquitetura em duas partes.");
                //novoSB.AppendLine("Pedirei para voce me ajudar a implementar usecases");

                //novoSB.AppendLine("");
                //novoSB.AppendLine("");
                //novoSB.AppendLine("");

                // Abre ou cria o arquivo com compartilhamento liberado para leitura
                using (var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (var writer = new StreamWriter(stream))
                {

                    string[] linhas = content.Split(Environment.NewLine);
                    string prefixoParaRemover = "using";
                    foreach (var linha in linhas)
                    {
                        var linhaTrimmed = linha.Trim();

                        // Ignora linhas em branco ou que comecem com o prefixo
                        if (string.IsNullOrWhiteSpace(linhaTrimmed)) continue;
                        if (linhaTrimmed.StartsWith(prefixoParaRemover)) continue;

                        novoSB.AppendLine(linha);
                    }
                    writer.WriteLine(novoSB);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao escrever no arquivo: " + ex.Message);
            }
        }


        public void WriteCode(StringBuilder code, string path, bool custon, bool context)
        {
            code.Append("");
            code.Append("");
            code.Append($"//{this.GetType()}");

            if (custon && File.Exists(path))
                return;

            WriteToFile(code, path);

            if (context)
                WriteContexto(code.ToString());
        }
        // Método público para gerar e salvar o código
        public void WriteCode(Entity entity, string filePathMigration, string filePathCuston, UseCase useCase = null)
        {
            StringBuilder code = GenerateCode();
            bool context = false;
            if ((entity != null && entity.EntityName == "Y_Tenant") || (useCase != null && useCase.Name._value == "createConta"))
                context = true;
            WriteCode(code, filePathMigration, false, context);

            if (!File.Exists(filePathCuston))
            {
                code = GenerateCustonCode();
                WriteCode(code, filePathCuston, true, context);
            }
        }
    }

}