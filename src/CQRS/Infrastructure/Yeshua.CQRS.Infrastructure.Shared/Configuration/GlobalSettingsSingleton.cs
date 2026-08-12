using Newtonsoft.Json;
using Shered.Configuration;


public sealed class GS
{
    private static readonly Lazy<GS> instance = new(() => new GS());

    public MyConfig MYC { get; private set; }

    private GS()
    {
        MYC = new MyConfig();

        try
        {
            var jsonPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "appsettings.json"
            );

            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
                var myConfig = jsonObject?.MyConfig?.ToObject<MyConfig>();
                if (myConfig is not null)
                    MYC = myConfig;
            }
            else
            {
                Console.WriteLine("appsettings.json não encontrado, usando defaults.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar configurações: {ex.Message}");
        }

        OverrideIfExists("MYCONFIG__READCONECTIONSTRING", v => MYC.ReadConectionString = v);
        OverrideIfExists("MYCONFIG__WRITECONECTIONSTRING", v => MYC.WriteConectionString = v);
    }

    private void OverrideIfExists(string envKey, Action<string> setter)
    {
        var value = Environment.GetEnvironmentVariable(envKey);
        if (!string.IsNullOrWhiteSpace(value))
            setter(value);
    }

    public static GS I => instance.Value;
}
