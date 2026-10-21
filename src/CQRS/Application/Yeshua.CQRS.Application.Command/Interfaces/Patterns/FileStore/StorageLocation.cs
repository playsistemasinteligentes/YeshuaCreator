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
			public static StorageLocation For(string application, string area) => Create("volatile", application, area);
			public static StorageLocation TranscriptionsInput => new("volatile/ia/transcriptions/input");
			public static StorageLocation TranscriptionsOutput => new("volatile/ia/transcriptions/output");

			public static StorageLocation ReportsInput => new("volatile/reports/input");
			public static StorageLocation ReportsOutput => new("volatile/reports/output");
		}

		// ===== PERSISTENT =====
		public static class Persistent
		{
			public static StorageLocation For(string application, string area) => Create("persistent", application, area);
		}

		private static StorageLocation Create(string category, string application, string area)
		{
			if (string.IsNullOrWhiteSpace(application) || application.IndexOfAny(new[] { '/', '\\' }) >= 0)
				throw new ArgumentException("Application must be a single storage segment.", nameof(application));
			if (string.IsNullOrWhiteSpace(area))
				throw new ArgumentException("Storage area is required.", nameof(area));
			StoragePath.ValidateRelative(application);
			StoragePath.ValidateRelative(area);
			return new StorageLocation($"{category}/{application}/{area}");
		}
	}
}
