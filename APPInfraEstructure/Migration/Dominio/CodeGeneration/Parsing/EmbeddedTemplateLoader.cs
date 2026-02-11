using System.Reflection;

namespace Dominio.CodeGeneration.Templates
{
    public static class EmbeddedTemplateLoader
    {
        public static string Load(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var fullName = assembly
                .GetManifestResourceNames()
                .First(x => x.EndsWith(resourceName));

            using var stream = assembly.GetManifestResourceStream(fullName)
                ?? throw new InvalidOperationException($"Template {resourceName} não encontrado.");

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
