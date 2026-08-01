namespace Command.Interfaces.Patterns.FileStore
{
	public sealed class StorageLocation 
	{
		public string Path { get; }

		private StorageLocation(string path)
		{
			Path = path.Replace('/', System.IO.Path.DirectorySeparatorChar)
					   .Replace('\\', System.IO.Path.DirectorySeparatorChar);
		}

		// ===== VOLATILE =====
		public static class Volatile
		{
			public static StorageLocation TranscriptionsInput => new("volatile/ia/transcriptions/input");
			public static StorageLocation TranscriptionsOutput => new("volatile/ia/transcriptions/output");

			public static StorageLocation ReportsInput => new("volatile/reports/input");
			public static StorageLocation ReportsOutput => new("volatile/reports/output");
		}

		// ===== PERSISTENT =====
		public static class Persistent
		{
			public static StorageLocation DocsInput => new("persistent/docs/input");
			public static StorageLocation DocsOutput => new("persistent/docs/output");
		}
	}
}