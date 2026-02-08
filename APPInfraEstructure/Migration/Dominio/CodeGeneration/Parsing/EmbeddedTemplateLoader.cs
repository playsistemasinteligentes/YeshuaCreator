namespace Migration.Dominio.CodeGeneration.Templates
{
    public static class EmbeddedTemplateLoader
    {
        public static string Load(string resourceName)
        {
            var assembly = typeof(EmbeddedTemplateLoader).Assembly;

            var fullName =
                $"Migration.Dominio.CodeGeneration.Templates.{resourceName}";

            using var stream = assembly.GetManifestResourceStream(fullName)
                ?? throw new InvalidOperationException(
                    $"Template não encontrado: {fullName}");

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
