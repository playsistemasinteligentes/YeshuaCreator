using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yeshua.Studio.Central;

public sealed class GS
{
    private static readonly Lazy<GS> Instance = new(() => new GS());

    public MyConfig MYC { get; }

    private GS()
    {
        try
        {
            var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(json);
                MYC = jsonObject?["MyConfig"]?.ToObject<MyConfig>() ?? new MyConfig();
            }
            else
            {
                MYC = new MyConfig();
            }
        }
        catch
        {
            MYC = new MyConfig();
        }

        MYC.Source = ResolveDefault(MYC.Source, FindSolutionRoot());
        MYC.Project = ResolveDefault(MYC.Project, "Central");
    }

    private static string ResolveDefault(string? currentValue, string fallback)
    {
        return string.IsNullOrWhiteSpace(currentValue) ? fallback : currentValue;
    }

    private static string FindSolutionRoot()
    {
        var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        while (directory is not null)
        {
            if (directory.GetFiles("YeshuaCreator.sln").Length > 0)
                return directory.FullName;
            directory = directory.Parent;
        }

        return AppDomain.CurrentDomain.BaseDirectory;
    }

    public static GS I => Instance.Value;
}
